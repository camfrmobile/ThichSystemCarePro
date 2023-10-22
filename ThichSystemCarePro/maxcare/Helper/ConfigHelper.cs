using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace maxcare.Helper
{
	public class ConfigHelper
	{
		public static string GetPathProfile()
		{
			JsonHelper jsonHelper = new JsonHelper("configGeneral");
			string text = jsonHelper.GetValue("txbPathProfile");
			if (!text.Contains('\\'))
			{
				text = FileHelper.GetPathToCurrentFolder() + "\\" + ((jsonHelper.GetValue("txbPathProfile") == "") ? "profiles" : jsonHelper.GetValue("txbPathProfile"));
			}
			return text;
		}

		public static string GetPathBackup()
		{
			return FileHelper.GetPathToCurrentFolder() + "\\backup";
		}

		public static string GetPathLDPlayer(int type = 0)
		{
			JsonHelper jsonHelper = new JsonHelper("configGeneral");
			switch (type)
			{
			default:
				if (jsonHelper.GetValueBool("isRunSwap"))
				{
					return jsonHelper.GetValue("txtLDPathSwap").Trim();
				}
				return jsonHelper.GetValue("txtLDPathThuong").Trim();
			case 2:
				return jsonHelper.GetValue("txtLDPathSwap").Trim();
			case 1:
				return jsonHelper.GetValue("txtLDPathThuong").Trim();
			}
		}

		public static string GetPathPictureLDPlayer()
		{
			string result = "";
			try
			{
				string path = GetPathLDPlayer() + "\\vms\\config\\leidian0.config";
				string text = GetPathLDPlayer() + "\\vms\\config\\leidian1.config";
				if (File.Exists(text))
				{
					path = text;
				}
				JObject jObject = JObject.Parse(File.ReadAllText(path));
				result = jObject["statusSettings.sharedPictures"]!.ToString();
			}
			catch
			{
			}
			return result;
		}
	}
}
