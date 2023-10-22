using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MCommon;
using Newtonsoft.Json.Linq;

namespace Common
{
	public class CommonOther
	{
		public static string CreateMailGenerator(string tenMail = "")
		{
			string text = "";
			int num = 0;
			do
			{
				if (text == "")
				{
					num++;
					text = GetDuoiMail();
					continue;
				}
				if (tenMail == "")
				{
					tenMail = CommonCSharp.CreateRandomString(10);
				}
				return tenMail + text;
			}
			while (num != 10);
			return "";
		}

		public static string GetDuoiMail()
		{
			RequestHttp requestHttp = new RequestHttp();
			string input = requestHttp.RequestGet("https://generator.email/");
			MatchCollection matchCollection = Regex.Matches(input, "change_dropdown_list\\(this.innerHTML\\)\" id=\"(.*?)\"");
			List<string> list = new List<string>();
			string text = "";
			for (int i = 0; i < matchCollection.Count; i++)
			{
				text = matchCollection[i].Groups[1].Value;
				if (CommonCSharp.CheckBasicString(text) && !CommonCSharp.IsContainNumber(text) && !text.Contains("-") && (text.EndsWith(".com") || text.EndsWith(".org") || text.EndsWith(".info")))
				{
					list.Add(text);
				}
			}
			if (list.Count <= 0)
			{
				return "";
			}
			Random random = new Random();
			return "@" + list[random.Next(0, list.Count)];
		}

		public static string GetOTPGenerator(string mail, int timeOut = 30)
		{
			RequestHttp requestHttp = new RequestHttp();
			string text = "";
			_ = "/" + mail.Split('@')[1] + "/" + mail.Split('@')[0] + "/(.*?)\"";
			int tickCount = Environment.TickCount;
			while (Environment.TickCount - tickCount <= timeOut * 1000)
			{
				string input = requestHttp.RequestGet("https://generator.email/" + mail);
				text = Regex.Match(input, "https://www.facebook.com/n/\\?confirmemail.php(.*?)\"").Value.TrimEnd('"');
				text = Regex.Match(text, "c=(.*?)&").Groups[1].Value;
				if (text != "")
				{
					break;
				}
			}
			return text;
		}

		public static bool DelAllMail(string mail)
		{
			RequestHttp requestHttp = new RequestHttp();
			string input = requestHttp.RequestGet("https://generator.email/" + mail);
			string value = Regex.Match(input, "delll: \"(.*?)\"").Groups[1].Value;
			string data = "delll=" + value;
			input = requestHttp.RequestPost("https://generator.email/del_mail.php", data);
			if (input.Contains("successfully"))
			{
				return true;
			}
			return false;
		}

		public static string CheckCountry(string hometown)
		{
			RequestHttp requestHttp = new RequestHttp();
			string text = requestHttp.RequestGet("https://minsoftware.xyz/minsoftware/api1.php/GetCodeCheckCountry");
			string text2 = text.Replace("\"", "");
			string result = "";
			string json = requestHttp.RequestPost("https://www.mapdevelopers.com/data.php?operation=geocode&address=" + hometown + "&region=US&code=" + text2).ToString();
			JObject jObject = JObject.Parse(json);
			string text3 = jObject["data"]!["country"]!.ToString();
			if (text3 != "")
			{
				result = text3;
			}
			return result;
		}

		public static string CheckBalance(string apikey)
		{
			string text = "";
			RequestXNet requestXNet = new RequestXNet("", "", "", 0);
			string json = requestXNet.RequestGet("https://api.rentcode.net/api/ig/balance?apiKey=" + Uri.EscapeDataString(apikey));
			JObject jObject = JObject.Parse(json);
			if (Convert.ToBoolean(jObject["success"]))
			{
				try
				{
					text = jObject["results"]!["balance"]!.ToString();
				}
				catch
				{
				}
			}
			return (text == "") ? "" : Convert.ToInt32(text).ToString();
		}

		public static string GetPhoneRentcode(string apikey, int id_service = 3, int id_provider = 2, int timeOut = 60)
		{
			string text = "";
			RequestXNet requestXNet = new RequestXNet("", "", "", 0);
			string data = "{ \"serviceProviderId\": " + id_service + ", \"networkProvider\": " + id_provider + " }";
			string text2 = "";
			string text3 = "";
			for (int i = 0; i < 5; i++)
			{
				try
				{
					text2 = requestXNet.RequestPost("https://api.rentcode.net/api/ig/create-request?apiKey=" + Uri.EscapeDataString(apikey), data, "application/json");
					text3 = JObject.Parse(text2)["results"]!["id"]!.ToString();
					if (text3 != "")
					{
						break;
					}
				}
				catch
				{
				}
			}
			if (text3 != "")
			{
				int tickCount = Environment.TickCount;
				while (Environment.TickCount - tickCount <= timeOut * 1000)
				{
					text2 = requestXNet.RequestGet("https://api.rentcode.net/api/ig/orders/" + text3 + "/check-status?apiKey=" + Uri.EscapeDataString(apikey));
					JObject jObject = JObject.Parse(text2);
					if (!Convert.ToBoolean(jObject["success"]))
					{
						continue;
					}
					try
					{
						text = jObject["results"]!["phoneNumber"]!.ToString();
						if (text != "")
						{
							goto IL_0196;
						}
					}
					catch
					{
					}
				}
			}
			goto IL_0196;
			IL_0196:
			return text3 + "|" + text;
		}

		public static string GetOTPRentcode(string apikey, string id_order, int timeOut = 60)
		{
			string text = "";
			RequestXNet requestXNet = new RequestXNet("", "", "", 0);
			string data = "{ \"pageIndex\": 0, \"pageSize\": 0, \"sortColumnName\": \"string\", \"isAsc\": true, \"searchObject\": { \"additionalProp1\": { }, \"additionalProp2\": { }, \"additionalProp3\": { } } }";
			string text2 = "";
			int tickCount = Environment.TickCount;
			while (Environment.TickCount - tickCount <= timeOut * 1000)
			{
				text2 = requestXNet.RequestPost("https://api.rentcode.net/api/ig/orders/" + id_order + "/results?apiKey=" + Uri.EscapeDataString(apikey), data, "application/json");
				JObject jObject = JObject.Parse(text2);
				if (Convert.ToInt32(jObject["total"]) <= 0)
				{
					continue;
				}
				try
				{
					text = jObject["results"]![0]!["message"]!.ToString();
					text = Regex.Match(text, "\\d{6}").Value;
					if (!(text != ""))
					{
						continue;
					}
					return text;
				}
				catch
				{
				}
			}
			return text;
		}
	}
}
