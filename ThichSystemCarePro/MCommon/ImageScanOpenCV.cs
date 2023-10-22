using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace MCommon
{
	internal class ImageScanOpenCV
	{
		public static Bitmap GetImage(string path)
		{
			return new Bitmap(path);
		}

		public static Bitmap Find(string main, string sub, double percent = 0.9)
		{
			GetImage(main);
			GetImage(sub);
			return Find(main, sub, percent);
		}

		public static Bitmap Find(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.9)
		{
			Image<Bgr, byte> image = new Image<Bgr, byte>(mainBitmap);
			Image<Bgr, byte> image2 = new Image<Bgr, byte>(subBitmap);
			Image<Bgr, byte> image3 = image.Copy();
			using (Image<Gray, float> image4 = image.MatchTemplate(image2, TemplateMatchingType.CcoeffNormed))
			{
				image4.MinMax(out var _, out var maxValues, out var _, out var maxLocations);
				if (maxValues[0] > percent)
				{
					Rectangle rect = new Rectangle(maxLocations[0], image2.Size);
					image3.Draw(rect, new Bgr(Color.Red), 2);
				}
				else
				{
					image3 = null;
				}
			}
			return image3?.ToBitmap();
		}

		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObject);

		public static Point? FindOutPoint(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.9)
		{
			Point? result;
			if (subBitmap == null || mainBitmap == null)
			{
				result = null;
			}
			else
			{
				if (subBitmap.Width <= mainBitmap.Width && subBitmap.Height <= mainBitmap.Height)
				{
					Image<Bgr, byte> image = new Image<Bgr, byte>(mainBitmap);
					Image<Bgr, byte> template = new Image<Bgr, byte>(subBitmap);
					Point? result2 = null;
					using (Image<Gray, float> image2 = image.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
					{
						image2.MinMax(out var _, out var maxValues, out var _, out var maxLocations);
						if (maxValues[0] > percent)
						{
							result2 = maxLocations[0];
						}
					}
					GC.Collect();
					GC.WaitForPendingFinalizers();
					return result2;
				}
				result = null;
			}
			return result;
		}

		public static List<Point> FindOutPoints(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.9)
		{
			Image<Bgr, byte> image = new Image<Bgr, byte>(mainBitmap);
			Image<Bgr, byte> image2 = new Image<Bgr, byte>(subBitmap);
			List<Point> list = new List<Point>();
			while (true)
			{
				using Image<Gray, float> image3 = image.MatchTemplate(image2, TemplateMatchingType.CcoeffNormed);
				image3.MinMax(out var _, out var maxValues, out var _, out var maxLocations);
				if (!(maxValues[0] > percent))
				{
					break;
				}
				Rectangle rect = new Rectangle(maxLocations[0], image2.Size);
				image.Draw(rect, new Bgr(Color.Blue), -1);
				list.Add(maxLocations[0]);
				continue;
			}
			return list;
		}

		public static List<Point> FindColor(Bitmap mainBitmap, Color color)
		{
			int num = color.ToArgb();
			List<Point> list = new List<Point>();
			try
			{
				for (int i = 0; i < mainBitmap.Width; i++)
				{
					for (int j = 0; j < mainBitmap.Height; j++)
					{
						if (num.Equals(mainBitmap.GetPixel(i, j).ToArgb()))
						{
							list.Add(new Point(i, j));
						}
					}
				}
			}
			finally
			{
				((IDisposable)mainBitmap)?.Dispose();
			}
			return list;
		}
	}
}
