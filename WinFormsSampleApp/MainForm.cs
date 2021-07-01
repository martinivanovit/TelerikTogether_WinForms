using System;
using System.Windows.Forms;
using TelerikTogether.Barcode;
using TelerikTogether.Math;

namespace WinFormsSampleApp
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void buttonFive_Click(object sender, EventArgs e)
		{
			double pet = RadMath.DaiPet();
			MessageBox.Show(pet.ToString());
		}

		private void buttonBarcode_Click(object sender, EventArgs e)
		{
			string barcodeImage = BarcodeEngine.GetFakeBarcodeImageFromText("https://www.telerik.com/");
			MessageBox.Show(barcodeImage);
		}

		private void buttonSunburst_Click(object sender, EventArgs e)
		{
			SunburstForm form = new SunburstForm();
			form.Show();
		}
	}
}
