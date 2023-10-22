using System;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace MCommon
{
	internal class XproxyProxy_
	{
		private object k = new object();

		private object k1 = new object();

		public int typeProxy;

		private string ServicesURL;

		public string proxy;

		public string ip = "";

		public int dangSuDung = 0;

		public int daSuDung = 0;

		public int limit_theads_use = 3;

		public XproxyProxy_(string ServicesURL, string proxy, int typeProxy, int limit_theads_use)
		{
			this.ServicesURL = ServicesURL;
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
				ServicesURL = ServicesURL.TrimEnd('/');
				string url = ServicesURL + "/reset?proxy=" + proxy;
				RequestXNet requestXNet = new RequestXNet("", "", "", 0);
				string json = requestXNet.RequestGet(url);
				if (JObject.Parse(json)["msg"]!.ToString() == "command_sent" || JObject.Parse(json)["msg"]!.ToString() == "OK" || JObject.Parse(json)["msg"]!.ToString().ToLower() == "ok")
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
				ServicesURL = ServicesURL.TrimEnd('/');
				string url = ServicesURL + "/status?proxy=" + proxy;
				RequestXNet requestXNet = new RequestXNet("", "", "", 0);
				string json = requestXNet.RequestGet(url);
				result = Convert.ToBoolean(JObject.Parse(json)["status"]!.ToString());
				return result;
			}
			catch
			{
				return result;
			}
		}
	}
}
