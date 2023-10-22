using System;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace MCommon
{
	internal class ProxyWeb
	{
		private object k = new object();

		private object k1 = new object();

		public int typeProxy;

		private string apiKey;

		public string proxy;

		public string ip = "";

		public int dangSuDung = 0;

		public int daSuDung = 0;

		public int limit_theads_use = 3;

		public ProxyWeb(string apiKey, string proxy, int typeProxy, int limit_theads_use)
		{
			this.apiKey = apiKey;
			this.proxy = proxy;
			this.limit_theads_use = limit_theads_use;
			ip = "";
			this.typeProxy = typeProxy;
		}

		public bool ChangeProxy()
		{
			bool result = false;
			try
			{
				string url = "https://api.proxyv6.net/api/reset-ip-manual?api_key=" + apiKey;
				string data = "{\"host\": \"" + proxy.Split(':')[0] + "\", \"port\": " + proxy.Split(':')[1] + "}";
				RequestXNet requestXNet = new RequestXNet("", "", "", 0);
				string json = requestXNet.RequestPost(url, data, "application/json");
				if (JObject.Parse(json)["message"]!.ToString() == "SUCCESS")
				{
					for (int i = 0; i < 120; i++)
					{
						if (!CheckLiveProxy())
						{
							Thread.Sleep(1000);
							continue;
						}
						Thread.Sleep(1000);
						return true;
					}
				}
			}
			catch
			{
				result = false;
			}
			return result;
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

		public bool CheckLiveProxy()
		{
			bool result = false;
			try
			{
				string url = "https://api.proxyv6.net/api/check-list-proxy?api_key=" + apiKey;
				string text = proxy.Split(':')[2] + ":" + proxy.Split(':')[3] + "@" + proxy.Split(':')[0] + ":" + proxy.Split(':')[1];
				string data = "{\"proxies\": [\"" + text + "\"]}";
				RequestXNet requestXNet = new RequestXNet("", "", "", 0);
				string json = requestXNet.RequestPost(url, data, "application/json");
				result = Convert.ToBoolean(JObject.Parse(json)["message"]!.ToString() == "SUCCESS" && JObject.Parse(json)["data"]!["ip"]!.ToString() != "");
				return result;
			}
			catch
			{
				return result;
			}
		}
	}
}
