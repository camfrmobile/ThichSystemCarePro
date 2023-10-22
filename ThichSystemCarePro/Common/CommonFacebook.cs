using System.Net;
using System.Text.RegularExpressions;
using MCommon;
using Newtonsoft.Json.Linq;

namespace Common
{
	public class CommonFacebook
	{
		public static string CheckLiveCookie(string cookie, string userAgent, string proxy, int typeProxy)
		{
			string result = "0|";
			string value = Regex.Match(cookie, "c_user=(.*?);").Groups[1].Value;
			RequestXNet requestXNet = new RequestXNet(cookie, userAgent, proxy, typeProxy);
			if (value != "")
			{
				try
				{
					string text = requestXNet.RequestGet("https://www.facebook.com/me").ToString();
					if (text.Contains("id=\"code_in_cliff\""))
					{
						result = "1|0";
					}
					else if (Regex.Match(text, "\"USER_ID\":\"(.*?)\"").Groups[1].Value.Trim() == value.Trim() && !text.Contains("checkpointSubmitButton"))
					{
						result = "1|1";
					}
				}
				catch
				{
					result = "2|";
				}
			}
			return result;
		}

		public static string GetFbdtsg(string cookie, string userAgent, string proxy, int typeProxy)
		{
			try
			{
				string input = new RequestXNet(cookie, userAgent, proxy, typeProxy).RequestGet("https://m.facebook.com/ajax/dtsg/?__ajax__=true").ToString();
				return Regex.Match(input, "\"token\":\"(.*?)\"").Groups[1].Value;
			}
			catch
			{
				return "";
			}
		}

		public static string GetCookieFromFacebookAccount(string email, string pass, string userAgent, string proxy, int typeProxy)
		{
			string data = "email=" + WebUtility.UrlEncode(email) + "&pass=" + WebUtility.UrlEncode(pass);
			RequestXNet requestXNet = new RequestXNet("", userAgent, proxy, typeProxy);
			requestXNet.RequestPost("https://mbasic.facebook.com/login/device-based/regular/login/?refsrc=https%3A%2F%2Fmbasic.facebook.com%2F&lwv=100&refid=8", data).ToString();
			return requestXNet.GetCookie();
		}

		public static string GetNameByUID(string uid, string token, string useragent, string proxy, int typeProxy)
		{
			try
			{
				RequestXNet requestXNet = new RequestXNet("", useragent, proxy, typeProxy);
				string json = requestXNet.RequestGet("https://graph.facebook.com/" + uid + "?fields=name&access_token=" + token);
				JObject jObject = JObject.Parse(json);
				return jObject["name"]!.ToString();
			}
			catch
			{
				return "";
			}
		}
	}
}
