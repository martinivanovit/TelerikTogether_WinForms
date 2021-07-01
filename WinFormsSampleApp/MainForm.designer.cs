
namespace WinFormsSampleApp
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button1.Location = new System.Drawing.Point(203, 142);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(147, 53);
			this.button1.TabIndex = 0;
			this.button1.Text = "Give me five";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.buttonFive_Click);
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button2.Location = new System.Drawing.Point(203, 214);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(147, 53);
			this.button2.TabIndex = 0;
			this.button2.Text = "Render barcode image";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.buttonBarcode_Click);
			// 
			// button3
			// 
			this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button3.Location = new System.Drawing.Point(203, 282);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(147, 53);
			this.button3.TabIndex = 0;
			this.button3.Text = "Show Sunburst";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.buttonSunburst_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 461);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "Telerik Together WF";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}