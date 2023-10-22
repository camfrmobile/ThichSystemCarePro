using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;

namespace MCommon
{
	internal class Tinsoft
	{
		public string errorCode = "";

		private string svUrl = "http://proxy.tinsoftsv.com";

		private int lastRequest = 0;

		public string api_key { get; set; }

		public string proxy { get; set; }

		public string ip { get; set; }

		public int port { get; set; }

		public int timeout { get; set; }

		public int next_change { get; set; }

		public int location { get; set; }

		public int countConnected { get; set; }

		public int connecting { get; set; }

		public Tinsoft(string api_key, int location = 0)
		{
			this.api_key = api_key;
			proxy = "";
			ip = "";
			port = 0;
			timeout = 0;
			next_change = 0;
			this.location = location;
		}

		public bool changeProxy()
		{
			if (checkLastRequest())
			{
				errorCode = "";
				next_change = 0;
				proxy = "";
				ip = "";
				port = 0;
				timeout = 0;
				string sVContent = getSVContent(svUrl + "/api/changeProxy.php?key=" + api_key + "&location=" + location);
				if (sVContent != "")
				{
					try
					{
						JObject jObject = JObject.Parse(sVContent);
						if (bool.Parse(jObject["success"]!.ToString()))
						{
							proxy = jObject["proxy"]!.ToString();
							string[] array = proxy.Split(':');
							ip = array[0];
							port = int.Parse(array[1]);
							timeout = int.Parse(jObject["timeout"]!.ToString());
							next_change = int.Parse(jObject["next_change"]!.ToString());
							errorCode = "";
							return true;
						}
						errorCode = jObject["description"]!.ToString();
					}
					catch
					{
					}
				}
				else
				{
					errorCode = "request server timeout!";
				}
			}
			else
			{
				errorCode = "Request so fast!";
			}
			return false;
		}

		public void stopProxy()
		{
			errorCode = "";
			proxy = "";
			ip = "";
			port = 0;
			timeout = 0;
			if (api_key != "")
			{
				getSVContent(svUrl + "/api/stopProxy.php?key=" + api_key);
			}
		}

		public bool getProxyStatus()
		{
			if (checkLastRequest())
			{
				errorCode = "";
				proxy = "";
				ip = "";
				port = 0;
				timeout = 0;
				string sVContent = getSVContent(svUrl + "/api/getProxy.php?key=" + api_key);
				if (sVContent != "")
				{
					try
					{
						JObject jObject = JObject.Parse(sVContent);
						if (bool.Parse(jObject["success"]!.ToString()))
						{
							proxy = jObject["proxy"]!.ToString();
							string[] array = proxy.Split(':');
							ip = array[0];
							port = int.Parse(array[1]);
							timeout = int.Parse(jObject["timeout"]!.ToString());
							next_change = int.Parse(jObject["next_change"]!.ToString());
							errorCode = "";
							return true;
						}
						errorCode = jObject["description"]!.ToString();
					}
					catch
					{
					}
				}
			}
			else
			{
				errorCode = "Request so fast!";
			}
			return false;
		}

		private bool checkLastRequest()
		{
			try
			{
				DateTime dateTime = new DateTime(2001, 1, 1);
				long ticks = DateTime.Now.Ticks - dateTime.Ticks;
				int num = (int)new TimeSpan(ticks).TotalSeconds;
				if (num - lastRequest >= 10)
				{
					lastRequest = num;
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private string getSVContent(string url)
		{
			Console.WriteLine(url);
			string text = "";
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
					text = webClient.DownloadString(url);
				}
				if (string.IsNullOrEmpty(text))
				{
					text = "";
				}
			}
			catch
			{
				text = "";
			}
			return text;
		}

		public static List<string> GetListKey(string api_user)
		{
			List<string> list = new List<string>();
			try
			{
				RequestXNet requestXNet = new RequestXNet("", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)", "", 0);
				string json = requestXNet.RequestGet("http://proxy.tinsoftsv.com/api/getUserKeys.php?key=" + api_user);
				JObject jObject = JObject.Parse(json);
				foreach (JToken item in (IEnumerable<JToken>)(jObject["data"]!))
				{
					if (Convert.ToBoolean(item["success"]!.ToString()))
					{
						list.Add(item["key"]!.ToString());
					}
				}
			}
			catch
			{
			}
			return list;
		}
	}
}
