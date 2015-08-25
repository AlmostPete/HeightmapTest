using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PerlinTester
{
	public partial class MainForm : Form
	{
		const int BITMAPSIZE = 2000;

		private HeightmapTest.PerlinNoiseGenerator NoiseGenerator;
		private Bitmap OldBitmap;

		public MainForm()
		{
			InitializeComponent();
		}

		private void GenerateButton_Click(object sender, EventArgs e)
		{
			double pval = this.PersistenceTrackBar.Value / 100.0;
			double fval = this.FrequencyTrackBar.Value / 100.0;
			double aval = this.AmplitudeTrackBar.Value / 100.0;
			int octaves = Int32.Parse(this.OctaveUpDown.SelectedItem.ToString());
			int seed;
			if (!Int32.TryParse(this.SeedTextBox.Text, out seed))
			{
				seed = (new Random()).Next();
				this.SeedTextBox.Text = seed.ToString();
			}

			NoiseGenerator = new HeightmapTest.PerlinNoiseGenerator(pval, fval, aval, octaves, seed);

			Thread thread = new Thread(() =>
			{
				if (OldBitmap != null)
					OldBitmap.Dispose();

				OldBitmap = new Bitmap(BITMAPSIZE, BITMAPSIZE);
				for (int x = 0; x < BITMAPSIZE; ++x)
				{
					for (int y = 0; y < BITMAPSIZE; ++y)
					{
						double val = NoiseGenerator.Generate(x, y);
						val = clampval(val * 255.0);
						int ival = (int)val;
						OldBitmap.SetPixel(x, y, Color.FromArgb(255, ival, ival, ival));
					}
				}

				this.Invoke(new MethodInvoker(delegate { this.OutputPictureBox.Image = OldBitmap; }));
			});
			thread.Start();
		}

		private double clampval(double d)
		{
			return (d > 255.0) ? 255.0 : ((d < 0.0) ? 0.0 : d);
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (OldBitmap == null)
				return;

			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "terrain.bmp");
			OldBitmap.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
		}
	}
}
