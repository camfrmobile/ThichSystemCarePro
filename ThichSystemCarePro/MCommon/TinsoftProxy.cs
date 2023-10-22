using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;

namespace MCommon
{
	internal class TinsoftProxy
	{
		private object k1 = new object();

		private object k = new object();

		public string errorCode = "";

		private string svUrl = "http://proxy.tinsoftsv.com";

		private int lastRequest = 0;

		public bool canChangeIP = true;

		public int dangSuDung = 0;

		public int daSuDung = 0;

		public int limit_theads_use = 3;

		public string api_key { get; set; }

		public string proxy { get; set; }

		public string ip { get; set; }

		public int port { get; set; }

		public int timeout { get; set; }

		public int next_change { get; set; }

		public int location { get; set; }

		public TinsoftProxy(string api_key, int limit_theads_use, int location = 0)
		{
			this.api_key = api_key;
			proxy = "";
			ip = "";
			port = 0;
			timeout = 0;
			next_change = 0;
			this.location = location;
			this.limit_theads_use = limit_theads_use;
			dangSuDung = 0;
			daSuDung = 0;
			canChangeIP = true;
		}

		public string TryToGetMyIP()
		{
			lock (k1)
			{
				if (dangSuDung == 0)
				{
					if (daSuDung > 0 && daSuDung < limit_theads_use)
					{
						if (GetTimeOut() < 30 && !ChangeProxy())
						{
							return "0";
						}
					}
					else if (!ChangeProxy())
					{
						return "0";
					}
				}
				else
				{
					if (daSuDung >= limit_theads_use)
					{
						return "2";
					}
					if (GetTimeOut() < 30 && !ChangeProxy())
					{
						return "0";
					}
				}
				daSuDung++;
				dangSuDung++;
				return "1";
			}
		}

		public void DecrementDangSuDung()
		{
			lock (k)
			{
				dangSuDung--;
				if (dangSuDung == 0 && daSuDung == limit_theads_use)
				{
					daSuDung = 0;
				}
			}
		}

		public bool ChangeProxy()
		{
			lock (k)
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
							next_change = int.Parse(jObject["next_change"]!.ToString());
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
		}

		public string GetProxy()
		{
			while (!CheckStatusProxy())
			{
			}
			return proxy;
		}

		public int GetTimeOut()
		{
			while (!CheckStatusProxy())
			{
			}
			return timeout;
		}

		public int GetNextChange()
		{
			while (!CheckStatusProxy())
			{
			}
			return next_change;
		}

		public bool CheckStatusProxy()
		{
			lock (k)
			{
				errorCode = "";
				next_change = 0;
				proxy = "";
				ip = "";
				port = 0;
				timeout = 0;
				string sVContent = getSVContent(string.Concat(new object[3] { svUrl, "/api/getProxy.php?key=", api_key }));
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
						if (jObject["next_change"] != null)
						{
							next_change = int.Parse(jObject["next_change"]!.ToString());
						}
					}
					catch (Exception)
					{
					}
				}
				else
				{
					errorCode = "request server timeout!";
				}
				return false;
			}
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

		private static string GetSVContent(string url)
		{
			Console.WriteLine(url);
			string text = "";
			try
			{
				using (WebClient webClient = new WebClient())
				{
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

		public static bool CheckApiProxy(string apiProxy)
		{
			string sVContent = GetSVContent("http://proxy.tinsoftsv.com/api/getKeyInfo.php?key=" + apiProxy);
			if (sVContent != "")
			{
				JObject jObject = JObject.Parse(sVContent);
				if (bool.Parse(jObject["success"]!.ToString()))
				{
					return true;
				}
			}
			return false;
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
