using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace MCommon
{
	internal class XProxy
	{
		public static int ResetProxy(string ServicesURL, string proxy)
		{
			int result = 0;
			try
			{
				ServicesURL = ServicesURL.TrimEnd('/');
				string url = ServicesURL + "/reset?proxy=" + proxy;
				RequestXNet requestXNet = new RequestXNet("", "", "", 0);
				string json = requestXNet.RequestGet(url);
				if (JObject.Parse(json)["msg"]!.ToString() == "command_sent")
				{
					for (int i = 0; i < 120; i++)
					{
						if (!CheckLiveProxy(ServicesURL, proxy))
						{
							Common.DelayTime(1.0);
							continue;
						}
						return 1;
					}
				}
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		public static int ResetAllProxy(string ServicesURL, List<string> lstProxy)
		{
			int result = 0;
			try
			{
				ServicesURL = ServicesURL.TrimEnd('/');
				string url = ServicesURL + "/reset_all";
				RequestXNet requestXNet = new RequestXNet("", "", "", 0);
				string json = requestXNet.RequestGet(url);
				if (Convert.ToBoolean(JObject.Parse(json)["status"]!.ToString()))
				{
					string text = "";
					for (int i = 0; i < 120; i++)
					{
						for (int j = 0; j < lstProxy.Count; j++)
						{
							text = lstProxy[j];
							if (CheckLiveProxy(ServicesURL, text))
							{
								lstProxy.RemoveAt(j--);
							}
						}
						if (lstProxy.Count != 0)
						{
							Common.DelayTime(1.0);
							continue;
						}
						return 1;
					}
				}
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		public static List<string> CloneList(List<string> lstFrom)
		{
			List<string> list = new List<string>();
			try
			{
				for (int i = 0; i < lstFrom.Count; i++)
				{
					list.Add(lstFrom[i]);
				}
			}
			catch
			{
			}
			return list;
		}

		public static int ResetProxy(string ServicesURL, List<string> lstXProxy)
		{
			int result = 0;
			try
			{
				List<string> list = CloneList(lstXProxy);
				for (int i = 0; i < list.Count; i++)
				{
					ResetProxy(ServicesURL, list[i]);
				}
				string text = "";
				for (int j = 0; j < 120; j++)
				{
					for (int k = 0; k < list.Count; k++)
					{
						text = list[k];
						if (CheckLiveProxy(ServicesURL, text))
						{
							list.RemoveAt(k--);
						}
					}
					if (list.Count != 0)
					{
						Common.DelayTime(1.0);
						continue;
					}
					return 1;
				}
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		public static bool CheckLiveProxy(string ServicesURL, string proxy)
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
