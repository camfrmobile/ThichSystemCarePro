using System;
using System.IO;
using System.Windows.Forms;

namespace maxcare.Helper
{
	public class FileHelper
	{
		public static string GetPathToCurrentFolder()
		{
			return Path.GetDirectoryName(Application.ExecutablePath);
		}

		public static string SelectFolder()
		{
			string result = "";
			try
			{
				using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				DialogResult dialogResult = folderBrowserDialog.ShowDialog();
				if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
				{
					result = folderBrowserDialog.SelectedPath;
				}
			}
			catch
			{
			}
			return result;
		}

		public static string SelectFile(string title = "Chọn File txt", string defaultFolder = "C:\\", string filter = "txt Files (*.txt)|*.txt|All files (*.*)|*.*")
		{
			string result = "";
			try
			{
				using OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = filter;
				openFileDialog.InitialDirectory = defaultFolder;
				openFileDialog.Title = title;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					result = openFileDialog.FileName;
				}
			}
			catch
			{
			}
			return result;
		}

		public static bool DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
		{
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirName);
				if (!directoryInfo.Exists)
				{
					return false;
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				Directory.CreateDirectory(destDirName);
				FileInfo[] files = directoryInfo.GetFiles();
				FileInfo[] array = files;
				foreach (FileInfo fileInfo in array)
				{
					string destFileName = Path.Combine(destDirName, fileInfo.Name);
					fileInfo.CopyTo(destFileName, overwrite: true);
				}
				if (copySubDirs)
				{
					DirectoryInfo[] array2 = directories;
					foreach (DirectoryInfo directoryInfo2 in array2)
					{
						string destDirName2 = Path.Combine(destDirName, directoryInfo2.Name);
						DirectoryCopy(directoryInfo2.FullName, destDirName2, copySubDirs);
					}
				}
				return true;
			}
			catch (Exception)
			{
			}
			return false;
		}

		public static void CreateFile(string pathFile)
		{
			try
			{
				File.AppendAllText(pathFile, "");
			}
			catch
			{
			}
		}

		public static void CreateFolderIfNotExist(string pathFolder)
		{
			try
			{
				Directory.CreateDirectory(pathFolder);
			}
			catch
			{
			}
		}
	}
}
