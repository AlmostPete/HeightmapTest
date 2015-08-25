using System;

namespace HeightmapTest
{
	public class PerlinNoiseGenerator
	{
		#region Generator Settings
		public double Persistence { get; private set; }
		public double Frequency { get; private set; }
		public double Amplitude { get; private set; }
		public int Octaves { get; private set; }
		public int Seed { get; private set; }
		#endregion

		public PerlinNoiseGenerator()
		{
			Persistence = Frequency = Amplitude = 0f;
			Octaves = Seed = 0;
		}

		public PerlinNoiseGenerator(double persitence, double freq, double amp, int octaves, int seed)
		{
			Persistence = persitence;
			Frequency = freq;
			Amplitude = amp;
			Octaves = octaves;
			Seed = seed;
		}

		#region Settings Modifiers
		public void Set(double persitence, double freq, double amp, int octaves, int seed)
		{
			Persistence = persitence;
			Frequency = freq;
			Amplitude = amp;
			Octaves = octaves;
			Seed = seed * seed + 2;
		}

		public void SetPersistence(double p)
		{
			Persistence = p;
		}

		public void SetFrequency(double f)
		{
			Frequency = f;
		}

		public void SetAmplitude(double a)
		{
			Amplitude = a;
		}

		public void SetOctaves(int o)
		{
			Octaves = o;
		}

		public void SetSeed(int s)
		{
			Seed = s * s + 2;
		}
		#endregion

		public double Generate(double x, double y)
		{
			return Amplitude * total(x, y);
		}

		private double total(double x, double y)
		{
			double t = 0f;
			double amp = 1f;
			double freq = Frequency;

			for (int k = 0; k < Octaves; ++k)
			{
				t += getValue(y * freq + Seed, x * freq + Seed) * amp;
				amp *= Persistence;
				freq *= 2;
			}

			return t;
		}

		private double getValue(double x, double y)
		{
			int ix = (int)x;
			int iy = (int)y;
			double fx = x - ix;
			double fy = y - iy;

			double n1 = noise(ix - 1, iy - 1);
			double n2 = noise(ix + 1, iy - 1);
			double n3 = noise(ix - 1, iy + 1);
			double n4 = noise(ix + 1, iy + 1);
			double n5 = noise(ix - 1, iy);
			double n6 = noise(ix + 1, iy);
			double n7 = noise(ix, iy - 1);
			double n8 = noise(ix, iy + 1);
			double n9 = noise(ix, iy);

			double n12 = noise(ix + 2, iy - 1);
			double n14 = noise(ix + 2, iy + 1);
			double n16 = noise(ix + 2, iy);

			double n23 = noise(ix - 1, iy + 2);
			double n24 = noise(ix + 1, iy + 2);
			double n28 = noise(ix, iy + 2);

			double n34 = noise(ix + 2, iy + 2);

			double x0y0 = 0.0625 * (n1 + n2 + n3 + n4) + 0.125 * (n5 + n6 + n7 + n8) + 0.25 * n9;
			double x1y0 = 0.0625 * (n7 + n12 + n8 + n14) + 0.125 * (n9 + n16 + n2 + n4) + 0.25 * n6;
			double x0y1 = 0.0625 * (n5 + n6 + n23 + n24) + 0.125 * (n3 + n4 + n9 + n28) + 0.25 * n8;
			double x1y1 = 0.0625 * (n9 + n16 + n28 + n34) + 0.125 * (n8 + n14 + n6 + n24) + 0.25 * n4;

			double v1 = interpolate(x0y0, x1y0, fx);
			double v2 = interpolate(x0y1, x1y1, fx);
			double fin = interpolate(v1, v2, fy);
			return fin;
		}

		private double interpolate(double x, double y, double a)
		{
			double nA = 1.0 - a;
			double nAs = nA * nA;
			double f1 = (3.0 * nAs) - (2.0 * nAs * nA);
			double aS = a * a;
			double f2 = (3.0 * aS) - (2.0 * aS * a);

			return x * f1 + y * f2;
		}

		private double noise(int x, int y)
		{
			int n = x + y * 57;
			//n = (n << 13) ^ n;
			int t = (n * (n * n * 15731 + 789221) + 1376312589) & 0x7fffffff;
			return 1.0 - (double)t * 0.931322574615478515625e-9;
        }
	}
}
