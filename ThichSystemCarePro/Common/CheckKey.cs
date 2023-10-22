using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using maxcare;
using maxcare.Helper;
using MCommon;

namespace Common
{
	public class CheckKey
	{
		public static void CheckVersion(string softname = "test")
		{
			string text = "https://minsoftware.xyz/file/" + softname + "/";
			try
			{
				WebClient webClient = new WebClient();
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				Uri address = new Uri(text + "update.ini");
				webClient.DownloadFile(address, "./update/update.ini");
				CommonIniFile commonIniFile = new CommonIniFile("./update/update.ini");
				string text2 = commonIniFile.Read("Version", "maxsystemcarepro");
				double num = Convert.ToDouble(text2.Replace(".", "").Insert(1, "."));
				CommonIniFile commonIniFile2 = new CommonIniFile("update.ini");
				string text3 = commonIniFile2.Read("Version", "maxsystemcarepro");
				double num2 = Convert.ToDouble(text3.Replace(".", "").Insert(1, "."));
				if (num > num2)
				{
					string text4 = "\r\nVersion: " + text2;
					text4 = text4 + "\r\n" + Language.GetValue("Nô\u0323i dung update:");
					text4 = text4 + "\r\n" + CommonCSharp.Base64Decode(commonIniFile.Read("Content", "Infor"));
					text4 = text4 + "\r\n\r\n" + Language.GetValue("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t phâ\u0300n mê\u0300m?");
					if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Đa\u0303 co\u0301 ba\u0309n câ\u0323p nhâ\u0323t mơ\u0301i!") + "\r\n" + text4) == DialogResult.Yes)
					{
						Process.Start("AutoUpdate.exe");
						MCommon.Common.KillProcess(softname);
					}
				}
			}
			catch
			{
			}
		}
	}
}
