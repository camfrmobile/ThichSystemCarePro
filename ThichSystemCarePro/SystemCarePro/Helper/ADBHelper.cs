using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using MCommon;

namespace SystemCarePro.Helper
{
	public class ADBHelper
	{
		public static List<string> GetListPackagesByUser(string deviceId)
		{
			List<string> result = new List<string>();
			try
			{
				string text = RunCMD(deviceId, ADBCommands.LIST_PACKAGES_USER_INSTALL).Replace("package:", "").Trim();
				if (text != "")
				{
					result = text.Split('\n').ToList();
				}
			}
			catch
			{
			}
			return result;
		}

		public static List<string> GetListPackages(string deviceId)
		{
			List<string> result = new List<string>();
			try
			{
				string text = RunCMD(deviceId, ADBCommands.LIST_PACKAGES).Replace("package:", "").Trim();
				if (text != "")
				{
					result = text.Split('\n').ToList();
				}
			}
			catch
			{
			}
			return result;
		}

		public static string UninstallApp(string deviceId, string package)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.UNINSTALL_APP, package));
			}
			catch
			{
			}
			return "";
		}

		public static string InstallApp(string deviceId, string filePathFromComputer)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.INSTALL_APP, filePathFromComputer), 60);
			}
			catch
			{
			}
			return "";
		}

		public static string CloseApp(string deviceId, string package)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.CLOSE_APP, package));
			}
			catch
			{
			}
			return "";
		}

		public static string OpenApp(string deviceId, string package)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.OPEN_APP, package));
			}
			catch
			{
			}
			return "";
		}

		public static string Tap(string deviceId, int x, int y)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.TAP, x, y));
			}
			catch
			{
			}
			return "";
		}

		public static string TapLong(string deviceId, int x, int y, int duration = 100)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.INPUT_SWIPE, x, y, x, y, duration));
			}
			catch
			{
			}
			return "";
		}

		public static string SwitchAndroidKeyboard(string deviceId, List<string> lstPackage)
		{
			try
			{
				string text = "com.android.inputmethod.pinyin";
				if (lstPackage.Count > 0 && !lstPackage.Contains(text))
				{
					text = "com.android.emu.inputservice";
				}
				return RunCMD(deviceId, "shell ime set " + text + "/.InputService");
			}
			catch
			{
			}
			return "";
		}

		public static string SwitchAdbkeyboard(string deviceId)
		{
			try
			{
				return RunCMD(deviceId, ADBCommands.SWITCH_ADBKEYBOARD);
			}
			catch
			{
			}
			return "";
		}

		public static string InputText(string deviceId, string text)
		{
			try
			{
				text = text.Replace(" ", "%s").Replace("&", "\\&").Replace("<", "\\<")
					.Replace(">", "\\>")
					.Replace("?", "\\?")
					.Replace(":", "\\:")
					.Replace("{", "\\{")
					.Replace("}", "\\}")
					.Replace("[", "\\[")
					.Replace("]", "\\]")
					.Replace("|", "\\|");
				return RunCMD(deviceId, string.Format(ADBCommands.INPUT_TEXT, text));
			}
			catch
			{
			}
			return "";
		}

		public static string Swipe(string deviceId, int x1, int y1, int x2, int y2, int duration = 100)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.INPUT_SWIPE, x1, y1, x2, y2, duration));
			}
			catch
			{
			}
			return "";
		}

		public static string RemoveHttpProxy(string deviceId)
		{
			try
			{
				ConnectHttpProxy(deviceId, ":0");
				RunCMD(deviceId, ADBCommands.DELETE_HTTP_PROXY);
				RunCMD(deviceId, ADBCommands.DELETE_HTTP_PROXY_HOST);
				RunCMD(deviceId, ADBCommands.DELETE_HTTP_PROXY_PORT);
			}
			catch
			{
			}
			return "";
		}

		public static string ConnectHttpProxy(string deviceId, string proxy)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.PUT_HTTP_PROXY, proxy));
			}
			catch
			{
			}
			return "";
		}

		public static string View(string deviceId, string link)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.CURL, link));
			}
			catch
			{
			}
			return "";
		}

		public static string Curl(string deviceId, string link)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.CURL, link));
			}
			catch
			{
			}
			return "";
		}

		public static string ScreenCap(string deviceId, string filePath)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.SCREENCAP, filePath));
			}
			catch
			{
			}
			return "";
		}

		public static string PullFile(string deviceId, string fromFilePath, string toFilePath)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.PULL_FILE, fromFilePath, toFilePath));
			}
			catch
			{
			}
			return "";
		}

		public static string PushFile(string deviceId, string fromFilePath, string toFilePath)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.PUSH_FILE, fromFilePath, toFilePath), 60);
			}
			catch
			{
			}
			return "";
		}

		public static string ImportContact(string deviceId, string filePath)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.IMPORT_CONTACT, filePath));
			}
			catch
			{
			}
			return "";
		}

		public static string ZipFile(string deviceId, string sourceFile, string toFile, int timeOut)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.ZIP_FILE, toFile, sourceFile), timeOut);
			}
			catch
			{
			}
			return "";
		}

		public static string UnZipFile(string deviceId, string filePath, int timeOut)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.UNZIP_FILE, filePath), timeOut);
			}
			catch
			{
			}
			return "";
		}

		public static string ClearDataApp(string deviceId, string package)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.CLEAR_DATA_APP, package));
			}
			catch
			{
			}
			return "";
		}

		public static string GetXML(string deviceId)
		{
			string text = "";
			try
			{
				for (int i = 0; i < 3; i++)
				{
					text = RunCMD(deviceId, "adb shell uiautomator dump && adb shell cat /sdcard/window_dump.xml && adb shell rm /sdcard/window_dump.xml").ToLower();
					if (!(text.Trim() != "ui hierchary dumped to: /sdcard/window_dump.xml") || !(text.Trim() != ""))
					{
						Thread.Sleep(1000);
						continue;
					}
					break;
				}
			}
			catch
			{
			}
			return Regex.Match(text, "<\\?xml(.*?)</hierarchy>").Value;
		}

		public static string ScreenShot(string deviceId, string filePathToSave)
		{
			string result = "";
			try
			{
				string fileName = Path.GetFileName(filePathToSave);
				ScreenCap(deviceId, "/sdcard/" + fileName);
				PullFile(deviceId, "/sdcard/" + fileName, filePathToSave);
				DeleteFile(deviceId, "/sdcard/" + fileName);
			}
			catch
			{
			}
			return result;
		}

		public static string DumpScreen(string deviceId, string filePath)
		{
			try
			{
				return RunCMD(deviceId, "shell uiautomator dump && adb shell cat /sdcard/window_dump.xml");
			}
			catch
			{
			}
			return "";
		}

		public static string DumpActivity(string deviceId)
		{
			try
			{
				return RunCMD(deviceId, ADBCommands.DUMP_ACTIVITY);
			}
			catch
			{
			}
			return "";
		}

		public static string DeleteFile(string deviceId, string filePath)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.DELETE_FILE, filePath));
			}
			catch
			{
			}
			return "";
		}

		public static string DeleteFolder(string deviceId, string folderPath)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.DELETE_FOLDER, folderPath));
			}
			catch
			{
			}
			return "";
		}

		public static string ReadFile(string deviceId, string filePath)
		{
			try
			{
				return RunCMD(deviceId, string.Format(ADBCommands.READ_FILE, filePath));
			}
			catch
			{
			}
			return "";
		}

		public static void DisconnectDevice(string deviceId)
		{
			try
			{
				RunCMD("adb disconnect " + deviceId);
			}
			catch
			{
			}
		}

		public static void ConnectDevice(string deviceId)
		{
			try
			{
				RunCMD("adb connect " + deviceId);
			}
			catch
			{
			}
		}

		public static List<string> GetDevices()
		{
			List<string> list = new List<string>();
			string text = RunCMD("adb devices");
			string[] array = text.Replace("List of devices attached", "").Trim().Split(new string[1] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].Contains("offline") && array[i].Contains("device"))
				{
					list.Add(array[i].Trim().Split('\t')[0]);
				}
			}
			return list;
		}

		public static List<string> GetListNameLDPlayer(string pathLd)
		{
			List<string> list = new List<string>();
			try
			{
				string text = RunCMD(pathLd + "\\dnconsole.exe list2");
				if (text.Trim() != "")
				{
					List<string> list2 = text.Trim().Split('\n').ToList();
					for (int i = 0; i < list2.Count; i++)
					{
						string item = list2[i].Split(',')[1];
						list.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "GetListLDPlayer(" + pathLd + ")");
			}
			return list;
		}

		public static List<string> GetListIndexLDPlayer(string pathLd)
		{
			List<string> list = new List<string>();
			try
			{
				string text = RunCMD(pathLd + "\\dnconsole.exe list2");
				if (text.Trim() != "")
				{
					List<string> list2 = text.Trim().Split('\n').ToList();
					for (int i = 0; i < list2.Count; i++)
					{
						list.Add(list2[i].Split(',')[0]);
					}
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "GetListIndexLDPlayer(" + pathLd + ")");
			}
			return list;
		}

		public static void RestoreDevice(string pathLD, int indexDevice, string filePathBackup)
		{
			try
			{
				RunCMD(pathLD + "\\dnconsole.exe restore --index " + indexDevice + " --file \"" + filePathBackup + "\"", 300);
			}
			catch
			{
			}
		}

		public static void AddDevice(string pathLD)
		{
			try
			{
				RunCMD(pathLD + "\\dnconsole.exe add", 30);
			}
			catch
			{
			}
		}

		public static void LaunchDevice(string pathLD, int indexDevice)
		{
			try
			{
				RunCMD(pathLD + "\\dnconsole.exe launch --index " + indexDevice);
			}
			catch
			{
			}
		}

		public static void QuitDevice(string pathLD, int indexDevice)
		{
			try
			{
				RunCMD(pathLD + "\\dnconsole.exe quit --index " + indexDevice);
			}
			catch
			{
			}
		}

		public static void QuitAllDevice(string pathLD)
		{
			try
			{
				RunCMD(pathLD + "\\dnconsole.exe quitall");
			}
			catch
			{
			}
		}

		public static string RunCMD(string deviceId, string cmd, int timeout = 10)
		{
			if (!string.IsNullOrEmpty(deviceId))
			{
				string newValue = "adb -s " + deviceId;
				cmd = (cmd.StartsWith("adb") ? cmd.Replace("adb", newValue) : ("adb -s " + deviceId + " " + cmd));
			}
			return RunCMD(cmd, timeout);
		}

		public static string RunCMD(string cmd, int timeout = 10)
		{
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c " + cmd;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
			process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
			StringBuilder output = new StringBuilder();
			process.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e)
			{
				if (!string.IsNullOrEmpty(e.Data))
				{
					output.Append(e.Data + "\n");
				}
			};
			process.Start();
			process.BeginOutputReadLine();
			if (timeout < 0)
			{
				process.WaitForExit();
			}
			else
			{
				process.WaitForExit(timeout * 1000);
			}
			process.Close();
			return output.ToString();
		}

		public static string CreateRandomString(int lengText)
		{
			string text = "";
			Random random = new Random();
			string text2 = "abcdefghijklmnopqrstuvwxyz";
			for (int i = 0; i < lengText; i++)
			{
				text += text2[random.Next(0, text2.Length)];
			}
			return text;
		}

		public static string GetDeviceByIndex(int IndexDevice)
		{
			string text = "";
			try
			{
				List<string> devices = GetDevices();
				List<string> lstDeviceIdCheck = new List<string>
				{
					"127.0.0.1:" + (IndexDevice * 2 + 5555),
					"emulator-" + (IndexDevice * 2 + 5554)
				};
				text = devices.Where((string x) => lstDeviceIdCheck.Contains(x)).FirstOrDefault();
				if (string.IsNullOrEmpty(text))
				{
					for (int i = 0; i < lstDeviceIdCheck.Count; i++)
					{
						DisconnectDevice(lstDeviceIdCheck[i]);
					}
					ConnectDevice(lstDeviceIdCheck[0]);
				}
			}
			catch
			{
			}
			return text;
		}
	}
}
