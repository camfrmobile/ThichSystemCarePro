using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using OpenQA.Selenium.Interactions;

namespace MCommon
{
	public class AutoChrome
	{
		public Process process { get; set; }

		public IntPtr intPtrChrome { get; set; }

		public Chrome chrome { get; set; }

		public AutoChrome(Chrome chrome)
		{
			process = chrome.process;
			intPtrChrome = process.MainWindowHandle;
			this.chrome = chrome;
		}

		public Image CaptureWindow(IntPtr handle)
		{
			IntPtr windowDC = User32.GetWindowDC(handle);
			User32.RECT rect = default(User32.RECT);
			User32.GetWindowRect(handle, ref rect);
			int nWidth = rect.right - rect.left;
			int nHeight = rect.bottom - rect.top;
			IntPtr intPtr = GDI32.CreateCompatibleDC(windowDC);
			IntPtr intPtr2 = GDI32.CreateCompatibleBitmap(windowDC, nWidth, nHeight);
			IntPtr hObject = GDI32.SelectObject(intPtr, intPtr2);
			GDI32.BitBlt(intPtr, 0, 0, nWidth, nHeight, windowDC, 0, 0, 13369376);
			GDI32.SelectObject(intPtr, hObject);
			GDI32.DeleteDC(intPtr);
			User32.ReleaseDC(handle, windowDC);
			Image result = Image.FromHbitmap(intPtr2);
			GDI32.DeleteObject(intPtr2);
			return result;
		}

		public bool ScreenCapture(string imagePathFolder, string fileName)
		{
			bool result = false;
			try
			{
				(CaptureWindow(intPtrChrome) as Bitmap).Save(imagePathFolder + (imagePathFolder.EndsWith("\\") ? "" : "\\") + fileName + ".png", ImageFormat.Png);
				result = true;
				return result;
			}
			catch (Exception ex)
			{
				ExportError(null, ex, "AutoChrome.ScreenCapture(" + imagePathFolder + "," + fileName + ")");
				return result;
			}
		}

		public Bitmap ScreenCapture(int count = 1)
		{
			Bitmap result = null;
			try
			{
				for (int i = 0; i < count; i++)
				{
					try
					{
						result = (Bitmap)CaptureWindow(intPtrChrome);
					}
					catch (Exception ex)
					{
						ExportError(this, ex, "CaptureWindow");
						Common.DelayTime(1.0);
						continue;
					}
					break;
				}
			}
			catch (Exception ex2)
			{
				ExportError(null, ex2, "AutoChrome.ScreenCapture()");
			}
			return result;
		}

		public void DelayTime(double timeDelay_Seconds)
		{
			try
			{
				Thread.Sleep(Convert.ToInt32(timeDelay_Seconds * 1000.0));
			}
			catch (Exception ex)
			{
				ExportError(null, ex, $"chrome.DelayTime({timeDelay_Seconds})");
			}
		}

		public bool CompareImage(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.9)
		{
			if (subBitmap == null || mainBitmap == null)
			{
				return false;
			}
			Image<Bgr, byte> image = new Image<Bgr, byte>(mainBitmap);
			Image<Bgr, byte> template = new Image<Bgr, byte>(subBitmap);
			Point? point = null;
			using Image<Gray, float> image2 = image.MatchTemplate(template, TemplateMatchingType.CcoeffNormed);
			image2.MinMax(out var _, out var maxValues, out var _, out var _);
			return maxValues[0] > percent;
		}

		public bool CheckCanScroll(int force, double delayPerTimes, int timeDelay = 0, int type = 0)
		{
			Bitmap subBitmap = ScreenCapture();
			if (type == 0)
			{
				ScrollDown(force, delayPerTimes);
			}
			else
			{
				ScrollTop(force, delayPerTimes);
			}
			DelayTime(timeDelay);
			Bitmap mainBitmap = ScreenCapture();
			return !CompareImage(mainBitmap, subBitmap);
		}

		public bool CheckCanScrollChrome(int distance, int timeDelay = 0, int type = 0)
		{
			distance *= 100;
			Bitmap subBitmap = ScreenCapture();
			if (type == 0)
			{
				ScrollChrome(distance);
			}
			else
			{
				ScrollChrome(-distance);
			}
			DelayTime(timeDelay);
			Bitmap mainBitmap = ScreenCapture();
			return !CompareImage(mainBitmap, subBitmap);
		}

		public Point? FindImage(string ImagePath, int timeSearchImage_Second = 0)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(ImagePath);
			FileInfo[] files = directoryInfo.GetFiles();
			int tickCount = Environment.TickCount;
			do
			{
				Bitmap bitmap = ScreenCapture(3);
				if (bitmap == null)
				{
					break;
				}
				Point? point = null;
				FileInfo[] array = files;
				foreach (FileInfo fileInfo in array)
				{
					Bitmap bitmap2 = (Bitmap)Image.FromFile(fileInfo.FullName);
					point = ImageScanOpenCV.FindOutPoint(bitmap, bitmap2);
					if (point.HasValue)
					{
						int x = point.Value.X + new Random().Next(0, bitmap2.Width * 3 / 4);
						int y = point.Value.Y + new Random().Next(0, bitmap2.Height * 3 / 4);
						return new Point(x, y);
					}
				}
				Common.DelayTime(1.0);
			}
			while (Environment.TickCount - tickCount <= timeSearchImage_Second * 1000);
			return null;
		}

		public bool CheckExistImage(string ImagePath, int timeSearchImage_Second = 0)
		{
			if (FindImage(ImagePath, timeSearchImage_Second).HasValue)
			{
				return true;
			}
			return false;
		}

		public int CheckExistImages(double timeWait_Second = 0.0, params string[] ImagePaths)
		{
			int result = 0;
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					for (int i = 0; i < ImagePaths.Length; i++)
					{
						if (CheckExistImage(ImagePaths[i]))
						{
							return i + 1;
						}
					}
					if (!((double)(Environment.TickCount - tickCount) > timeWait_Second * 1000.0))
					{
						Thread.Sleep(1000);
						continue;
					}
					break;
				}
			}
			catch (Exception ex)
			{
				ExportError(null, ex, string.Format("AutoChrome.CheckExistImages({0},{1})", timeWait_Second, string.Join("|", ImagePaths)));
			}
			return result;
		}

		public bool Click(string ImagePath, int timeSearchImage_Second = 3)
		{
			bool result = false;
			try
			{
				Point? point = FindImage(ImagePath, timeSearchImage_Second);
				if (point.HasValue)
				{
					AutoControl.SendClickOnPosition(intPtrChrome, point.Value.X, point.Value.Y);
					result = true;
					return result;
				}
				return result;
			}
			catch (Exception)
			{
				return result;
			}
		}

		public bool SendKeys(string content)
		{
			bool result = false;
			try
			{
				AutoControl.SendTextKeyBoard(intPtrChrome, content);
				result = true;
				return result;
			}
			catch (Exception ex)
			{
				ExportError(null, ex, "AutoChrome.SendKeys(" + content + ")");
				return result;
			}
		}

		public bool SendKeys(string content, double timeDelay_Second)
		{
			bool result = false;
			try
			{
				for (int i = 0; i < content.Length; i++)
				{
					AutoControl.SendTextKeyBoard(intPtrChrome, content[i].ToString());
					Thread.Sleep(Convert.ToInt32(timeDelay_Second * 1000.0));
				}
				result = true;
				return result;
			}
			catch (Exception ex)
			{
				ExportError(null, ex, "AutoChrome.SendKeys(" + content + ")");
				return result;
			}
		}

		public bool SendKeysChrome(string content)
		{
			bool result = false;
			try
			{
				new Actions(chrome.chrome).SendKeys(content).Perform();
				result = true;
				return result;
			}
			catch (Exception ex)
			{
				ExportError(null, ex, "AutoChrome.SendKeys(" + content + ")");
				return result;
			}
		}

		public bool SendKeysChrome(string content, double timeDelay_Second)
		{
			bool result = false;
			try
			{
				for (int i = 0; i < content.Length; i++)
				{
					new Actions(chrome.chrome).SendKeys(content[i].ToString()).Perform();
					Thread.Sleep(Convert.ToInt32(timeDelay_Second * 1000.0));
				}
				result = true;
				return result;
			}
			catch (Exception ex)
			{
				ExportError(null, ex, $"AutoChrome.SendKeys({content},{timeDelay_Second})");
				return result;
			}
		}

		public bool SendEnter()
		{
			bool result = false;
			try
			{
				AutoControl.SendKeyBoardPress(intPtrChrome, VKeys.VK_RETURN);
				result = true;
				return result;
			}
			catch (Exception ex)
			{
				ExportError(null, ex, "AutoChrome.SendEnter()");
				return result;
			}
		}

		public void Close()
		{
			try
			{
				process.Kill();
			}
			catch (Exception ex)
			{
				ExportError(null, ex, "AutoChrome.Close()");
			}
		}

		public void ScrollChrome(int distance)
		{
			try
			{
				chrome.ExecuteScript("window.scrollBy({ top: " + distance + ",behavior: 'smooth'});");
			}
			catch
			{
			}
		}

		public bool Click(int X, int Y)
		{
			bool result = false;
			try
			{
				AutoControl.SendClickOnPosition(intPtrChrome, X, Y);
				result = true;
				return result;
			}
			catch
			{
				return result;
			}
		}

		public bool Click(Point? point)
		{
			bool result = false;
			try
			{
				if (point.HasValue)
				{
					AutoControl.SendClickOnPosition(intPtrChrome, point.Value.X, point.Value.Y);
					result = true;
					return result;
				}
				return result;
			}
			catch
			{
				return result;
			}
		}

		public void ScrollDown(int force = 10, double delay = 100.0)
		{
			try
			{
				for (int i = 0; i < force; i++)
				{
					AutoControl.SendKeyBoardPress(intPtrChrome, VKeys.VK_DOWN);
					DelayTime(delay);
				}
			}
			catch
			{
			}
		}

		public void ScrollTop(int force = 10, double delay = 100.0)
		{
			try
			{
				for (int i = 0; i < force; i++)
				{
					AutoControl.SendKeyBoardPress(intPtrChrome, VKeys.VK_UP);
					DelayTime(delay);
				}
			}
			catch
			{
			}
		}

		public static void ExportError(AutoChrome autoChrome, Exception ex, string error = "")
		{
			try
			{
				if (!Directory.Exists("log"))
				{
					Directory.CreateDirectory("log");
				}
				if (!Directory.Exists("log\\images"))
				{
					Directory.CreateDirectory("log\\images");
				}
				Random random = new Random();
				string text = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + random.Next(1000, 9999);
				autoChrome?.ScreenCapture("log\\images\\", text);
				using StreamWriter streamWriter = new StreamWriter("log\\log.txt", append: true);
				streamWriter.WriteLine("-----------------------------------------------------------------------------");
				streamWriter.WriteLine("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
				streamWriter.WriteLine("File: " + text);
				if (error != "")
				{
					streamWriter.WriteLine("Error: " + error);
				}
				streamWriter.WriteLine();
				if (ex != null)
				{
					streamWriter.WriteLine("Type: " + ex.GetType().FullName);
					streamWriter.WriteLine("Message: " + ex.Message);
					streamWriter.WriteLine("StackTrace: " + ex.StackTrace);
					ex = ex.InnerException;
				}
			}
			catch
			{
			}
		}
	}
}
