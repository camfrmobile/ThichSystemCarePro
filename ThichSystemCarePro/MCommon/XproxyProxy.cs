using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace MCommon
{
	internal class XproxyProxy
	{
		private object k = new object();

		private object k1 = new object();

		public int typeProxy;

		private string ServicesURL;

		public string proxy;

		public string ip = "";

		public bool isProxyLive = true;

		public int dangSuDung = 0;

		public int daSuDung = 0;

		public int limit_theads_use = 3;

		public XproxyProxy(string ServicesURL, string proxy, int typeProxy, int limit_theads_use)
		{
			this.ServicesURL = ServicesURL;
			this.proxy = proxy;
			this.limit_theads_use = limit_theads_use;
			ip = "";
			this.typeProxy = typeProxy;
		}

		private void ExportToFile(string content)
		{
			try
			{
				File.AppendAllText("GetProxy.txt", content + "\r\n");
			}
			catch
			{
			}
		}

		public bool ChangeProxy()
		{
			int num = new JSON_Settings("configGeneral").GetValueInt("nudDelayResetXProxy", 5) * 60;
			bool result = false;
			try
			{
				int tickCount = Environment.TickCount;
				ServicesURL = ServicesURL.TrimEnd('/');
				string text = ServicesURL + "/reset?proxy=" + proxy;
				RequestXNet requestXNet = new RequestXNet("", "", "", 0);
				string text2 = requestXNet.RequestGet(text);
				ExportToFile(text + ": " + text2);
				JObject jObject = JObject.Parse(text2);
				bool flag = false;
				if (jObject.ContainsKey("msg") && (JObject.Parse(text2)["msg"]!.ToString() == "command_sent" || JObject.Parse(text2)["msg"]!.ToString() == "OK" || JObject.Parse(text2)["msg"]!.ToString().ToLower() == "ok"))
				{
					flag = true;
				}
				else if (jObject.ContainsKey("error_code") && JObject.Parse(text2)["error_code"]!.ToString().ToLower() == "0")
				{
					flag = true;
				}
				if (flag)
				{
					do
					{
						if (!CheckLiveProxy())
						{
							Thread.Sleep(1000);
							continue;
						}
						Thread.Sleep(1000);
						return true;
					}
					while (Environment.TickCount - tickCount < num * 1000);
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
				string text = ServicesURL + "/status?proxy=" + proxy;
				RequestXNet requestXNet = new RequestXNet("", "", "", 0);
				string text2 = requestXNet.RequestGet(text);
				ExportToFile(text + ": " + text2);
				try
				{
					if (!text2.Contains("public_ip_v6") && !text2.Contains("public_ip"))
					{
						result = Convert.ToBoolean(JObject.Parse(text2)["status"]!.ToString());
						return result;
					}
					string text3 = proxy.Split(':')[1];
					if (text3.StartsWith("4") || text3.StartsWith("5"))
					{
						result = JObject.Parse(text2)["public_ip"]!.ToString() != "" && JObject.Parse(text2)["public_ip"]!.ToString() != "CONNECT_INTERNET_ERROR";
						return result;
					}
					if (text3.StartsWith("6") || text3.StartsWith("7"))
					{
						result = JObject.Parse(text2)["public_ip_v6"]!.ToString() != "" && JObject.Parse(text2)["public_ip_v6"]!.ToString() != "CONNECT_INTERNET_ERROR";
						return result;
					}
					return result;
				}
				catch
				{
					result = JObject.Parse(text2)["error_code"]!.ToString() == "0";
					return result;
				}
			}
			catch
			{
				return result;
			}
		}
	}
}
