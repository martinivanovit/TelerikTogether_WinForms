using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TelerikTogether.Sunburst;

namespace WinFormsSampleApp
{
	public partial class SunburstForm : Form
	{

		public SunburstForm()
		{
			InitializeComponent();

			this.Controls.Add(new Sunburst() { Dock = DockStyle.Fill });
		}		

		public class Sunburst : Control
		{
			private Random random = new Random();
			private SunburstItemCollection items = new SunburstItemCollection();

			public Sunburst()
			{
				this.ResizeRedraw = true;

				for (int i = 1; i <= 5; i++)
				{
					SunburstItem item = new SunburstItem(null, "Item " + i, i * 30);
					item.Children = new SunburstItemCollection();

					for (int j = 1; j <= 3; j++)
					{
						SunburstItem subItem = new SunburstItem(null, "Item " + i + "." + j, j * 24);
						item.Children.Add(subItem);
					}

					items.Add(item);
				}
			}
			
			protected override void OnPaint(PaintEventArgs e)
			{
				base.OnPaint(e);
				SunburstLayoutEngine engine = new SunburstLayoutEngine();

				SolidBrush brush = null;

				foreach (SunburstItemViewInfo viewInfo in engine.CalculateViewInfos(items))
				{

					if (viewInfo.Level == 0)
					{
						if (brush != null)
						{
							brush.Dispose();
						}

						brush = new SolidBrush(Color.FromArgb(this.random.Next(256), this.random.Next(256), this.random.Next(256)));
					}

					using (Pen pen = new Pen(Color.Black, 3))
					{
						GraphicsPath path = this.ConstructDonutGraphicsPath(viewInfo, this.Bounds, Math.Min(this.Bounds.Width, this.Bounds.Height));

						e.Graphics.FillPath(brush, path);
						e.Graphics.DrawPath(pen, path);
					}
				}

				if (brush != null)
				{
					brush.Dispose();
				}
			}

			protected GraphicsPath ConstructDonutGraphicsPath(SunburstItemViewInfo viewInfo, RectangleF modelLayoutSlot, float diameter)
			{
				float innerRadius = 0.666f; // ((DonutSeries)this.Element).InnerRadiusFactor;
				float arcSectorWidth = diameter / 2f * innerRadius;
				int levels = 2;
				int level = viewInfo.Level + 1;
				float levelWidth = arcSectorWidth / levels;

				GraphicsPath path = new GraphicsPath();
				//RectangleF outerArcRect = GetPieSectionRect(viewInfo, modelLayoutSlot, levelWidth * (2 + viewInfo.Level));
				//RectangleF innerArcRect = new RectangleF(outerArcRect.X + levelWidth, outerArcRect.Y + levelWidth,
				//						outerArcRect.Width - levelWidth, outerArcRect.Height - levelWidth);

				PointF center = new PointF(modelLayoutSlot.X + modelLayoutSlot.Width / 2f, modelLayoutSlot.Y + modelLayoutSlot.Height / 2f);
				RectangleF innerArcRect = new RectangleF(center.X - levelWidth * level, center.Y - levelWidth * level, levelWidth * 2f * level, levelWidth * 2 * level);
				RectangleF outerArcRect = new RectangleF(innerArcRect.X - levelWidth, innerArcRect.Y - levelWidth, innerArcRect.Width + 2f * levelWidth, innerArcRect.Height + 2f * levelWidth);

				GraphicsPath outerArcPath = new GraphicsPath();
				outerArcPath.AddArc(outerArcRect, (float)viewInfo.StartAngle, (float)viewInfo.SweepAngle);
				path.AddPath(outerArcPath, false);

				GraphicsPath innerArcPath = new GraphicsPath();
				innerArcPath.AddArc(innerArcRect, (float)viewInfo.StartAngle, (float)viewInfo.SweepAngle);
				innerArcPath.Reverse();
				path.AddPath(innerArcPath, true);

				path.CloseFigure();

				return path;
			}

			protected RectangleF GetPieSectionRect(SunburstItemViewInfo viewInfo, RectangleF modelLayoutSlot, float diameter)
			{
				RectangleF result;

				float x = (float)(modelLayoutSlot.X + (modelLayoutSlot.Width - diameter) / 2f);
				float y = (float)(modelLayoutSlot.Y + (modelLayoutSlot.Height - diameter) / 2f);

				result = new RectangleF(x, y, Math.Max(diameter, 1f), Math.Max(diameter, 1f));

				//if (viewInfo.OffsetFromCenter > 0)
				//{
				//	PointF offset = GetOffset(viewInfo.StartAngle + (viewInfo.SweepAngle / 2f), (diameter / 2f) * (viewInfo.OffsetFromCenter));
				//	result.X += offset.X;
				//	result.Y += offset.Y;
				//}

				return result;
			}
		}
	}
}
