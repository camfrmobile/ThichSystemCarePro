using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using maxcare;
using MCommon;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Common
{
	public class CommonCSharp
	{
		public static List<string> RemoveEmptyItems(List<string> lst)
		{
			List<string> list = new List<string>();
			string text = "";
			for (int i = 0; i < lst.Count; i++)
			{
				text = lst[i].Trim();
				if (text != "")
				{
					list.Add(text);
				}
			}
			return list;
		}

		public static void resetDcom(string profileDcom)
		{
			Process process = new Process();
			process.StartInfo.FileName = "rasdial.exe";
			process.StartInfo.Arguments = "\"" + profileDcom + "\" /disconnect";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.Start();
			process.WaitForExit();
			Thread.Sleep(3000);
			process = new Process();
			process.StartInfo.FileName = "rasdial.exe";
			process.StartInfo.Arguments = "\"" + profileDcom + "\"";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.Start();
			process.WaitForExit();
			Thread.Sleep(1500);
		}

		public static string TrimEnd(string text, string value)
		{
			if (!text.EndsWith(value))
			{
				return text;
			}
			return text.Remove(text.LastIndexOf(value));
		}

		public static void SaveDatagridview(DataGridView dgv, string namePath)
		{
			List<string> list = new List<string>();
			string text = "";
			object obj = null;
			for (int i = 0; i < dgv.RowCount; i++)
			{
				text = "";
				for (int j = 0; j < dgv.ColumnCount; j++)
				{
					obj = dgv.Rows[i].Cells[j].Value;
					text += ((obj == null) ? "" : (obj?.ToString() + "|"));
				}
				text = text.TrimEnd('|');
				list.Add(text);
			}
			File.WriteAllLines(namePath, list);
		}

		public static void LoadDatagridview(DataGridView dgv, string namePath)
		{
			List<string> list = File.ReadAllLines(namePath).ToList();
			string text = "";
			if (list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					text = list[i];
					DataGridViewRowCollection rows = dgv.Rows;
					object[] values = text.Split('|');
					rows.Add(values);
				}
			}
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

		public static void KillProcess(string nameProcess)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName(nameProcess);
				foreach (Process process in processesByName)
				{
					process.Kill();
				}
			}
			catch
			{
			}
		}

		public static bool CheckBasicString(string text)
		{
			bool result = true;
			foreach (char c in text)
			{
				if ((c < 'a' || c > 'z') && (c < 'A' || c > 'Z') && c != '.')
				{
					result = false;
					break;
				}
			}
			return result;
		}

		public static string RemoveCharNotLatin(string text)
		{
			string text2 = "";
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
				{
					text2 += c;
				}
			}
			return text2;
		}

		public static string ConvertToUTF8(string text)
		{
			byte[] bytes = Encoding.Default.GetBytes(text);
			text = Encoding.UTF8.GetString(bytes);
			return text;
		}

		public static bool IsContainNumber(string pValue)
		{
			int num = 0;
			while (true)
			{
				if (num < pValue.Length)
				{
					char c = pValue[num];
					if (char.IsDigit(c))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		public static void ReadHtmlText(string text)
		{
			string text2 = "zzz999.html";
			File.WriteAllText(text2, text);
			Process.Start(text2);
		}

		public static string ReadHTMLCode(string Url)
		{
			try
			{
				if (Url.Contains("datavery"))
				{
					Base.check++;
				}
				WebClient webClient = new WebClient();
				byte[] bytes = webClient.DownloadData(Url);
				UTF8Encoding uTF8Encoding = new UTF8Encoding();
				return uTF8Encoding.GetString(bytes);
			}
			catch (Exception)
			{
				try
				{
					return new RequestXNet("", "", "", 0).RequestGet(Url);
				}
				catch
				{
					return null;
				}
			}
		}

		public static bool IsValidMail(string emailaddress)
		{
			try
			{
				new MailAddress(emailaddress);
				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}

		public static string Md5Encode(string sChuoi)
		{
			MD5 mD = MD5.Create();
			byte[] array = mD.ComputeHash(Encoding.UTF8.GetBytes(sChuoi));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("X2"));
			}
			return stringBuilder.ToString();
		}

		public static string Base64Encode(string text)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			return Convert.ToBase64String(bytes);
		}

		public static string Base64Decode(string base64EncodedData)
		{
			byte[] bytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(bytes);
		}

		public static string CreateRandomString(int lengText, Random rd = null)
		{
			string text = "";
			if (rd == null)
			{
				rd = new Random();
			}
			string text2 = "abcdefghijklmnopqrstuvwxyz";
			for (int i = 0; i < lengText; i++)
			{
				text += text2[rd.Next(0, text2.Length)];
			}
			return text;
		}

		public static string CreateRandomNumber(int leng, Random rd = null)
		{
			string text = "";
			if (rd == null)
			{
				rd = new Random();
			}
			string text2 = "0123456789";
			for (int i = 0; i < leng; i++)
			{
				text += text2[rd.Next(0, text2.Length)];
			}
			return text;
		}

		public static string convertToUnSign(string s)
		{
			Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
			string input = s.Normalize(NormalizationForm.FormD);
			return regex.Replace(input, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
		}

		public static string RunCMD(string cmd)
		{
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c " + cmd;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			string text = process.StandardOutput.ReadToEnd();
			process.WaitForExit();
			if (string.IsNullOrEmpty(text))
			{
				return "";
			}
			return text;
		}

		public static void DelayTime(double second)
		{
			Application.DoEvents();
			Thread.Sleep(Convert.ToInt32(second * 1000.0));
		}

		public static void ExportError(ChromeDriver chrome, string error)
		{
			try
			{
				Random random = new Random();
				string text = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + random.Next(1000, 9999);
				string text2 = "";
				if (chrome != null)
				{
					text2 = chrome.ExecuteScript("var markup = document.documentElement.innerHTML;return markup;").ToString();
					Screenshot screenshot = ((ITakesScreenshot)chrome).GetScreenshot();
					screenshot.SaveAsFile("log\\images\\" + text + ".png");
					File.WriteAllText("log\\html\\" + text + ".html", text2);
				}
				File.AppendAllText("log\\log.txt", DateTime.Now.ToString() + "|<" + text + ">|" + error + Environment.NewLine);
			}
			catch
			{
			}
		}
	}
}
