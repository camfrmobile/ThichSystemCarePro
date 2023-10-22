using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace maxcare.Helper
{
	public class AutoHelper
	{
		private class User32
		{
			public struct Rect
			{
				public int left;

				public int top;

				public int right;

				public int bottom;
			}

			[DllImport("user32.dll")]
			public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
		}

		public static void CaptureApplication(Process proc, string pathToSave)
		{
			User32.Rect rect = default(User32.Rect);
			User32.GetWindowRect(proc.MainWindowHandle, ref rect);
			int width = rect.right - rect.left;
			int height = rect.bottom - rect.top;
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
			}
			bitmap.Save(pathToSave, ImageFormat.Png);
		}
	}
}
