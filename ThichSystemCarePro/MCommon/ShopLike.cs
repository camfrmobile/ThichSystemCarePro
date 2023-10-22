using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MCommon
{
	internal class ShopLike
	{
		private Random rd = new Random();

		private object k = new object();

		public int dangSuDung = 0;

		public int daSuDung = 0;

		public int limit_theads_use = 3;

		public string api_key { get; set; }

		public string proxy { get; set; }

		public int typeProxy { get; set; }

		public string ip { get; set; }

		public int port { get; set; }

		public ShopLike(string api_key, int typeProxy, int limit_theads_use)
		{
			this.api_key = api_key;
			proxy = "";
			ip = "";
			port = 0;
			this.typeProxy = typeProxy;
			this.limit_theads_use = limit_theads_use;
			dangSuDung = 0;
			daSuDung = 0;
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
			proxy = "";
			ip = "";
			port = 0;
			string text = RequestGet("http://proxy.shoplike.vn/Api/getNewProxy?access_token=" + api_key);
			if (text != "")
			{
				try
				{
					JObject jObject = JObject.Parse(text);
					if (jObject["status"]!.ToString() == "success")
					{
						if (typeProxy == 0)
						{
							proxy = jObject["data"]!["proxy"]!.ToString();
							string[] array = proxy.Split(':');
							ip = array[0];
							port = int.Parse(array[1]);
						}
						return true;
					}
				}
				catch
				{
				}
			}
			return false;
		}

		public bool CheckStatusProxy()
		{
			proxy = "";
			ip = "";
			port = 0;
			string text = RequestGet("http://proxy.shoplike.vn/Api/getCurrentProxy?access_token=" + api_key);
			if (text != "")
			{
				try
				{
					JObject jObject = JObject.Parse(text);
					if (jObject["status"]!.ToString() == "success")
					{
						proxy = jObject["data"]!["proxy"]!.ToString();
						string[] array = proxy.Split(':');
						ip = array[0];
						port = int.Parse(array[1]);
						return true;
					}
				}
				catch
				{
				}
			}
			return false;
		}

		public string GetProxy()
		{
			while (!CheckStatusProxy())
			{
			}
			return proxy;
		}

		private static string RequestPost(string url, string data)
		{
			string text = "";
			try
			{
				new HttpClient();
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				HttpContent c = default(HttpContent);
				Task<string> task = Task.Run(() => PostURI(new Uri(url), c));
				task.Wait();
				return task.Result;
			}
			catch (Exception ex)
			{
				Common.ExportError(null, ex, "Request Post");
				return "";
			}
		}

		public static string RequestGet(string url)
		{
			string text = "";
			try
			{
				new HttpClient();
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				Task<string> task = Task.Run(() => GetURI(new Uri(url)));
				task.Wait();
				return task.Result;
			}
			catch (Exception ex)
			{
				Common.ExportError(null, ex, "Request get");
				return "";
			}
		}

		private static async Task<string> PostURI(Uri u, HttpContent c)
		{
			string response = string.Empty;
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage result = await client.PostAsync(u, c);
				if (result.IsSuccessStatusCode)
				{
					response = await result.Content.ReadAsStringAsync();
				}
			}
			return response;
		}

		private static async Task<string> GetURI(Uri u)
		{
			string response = string.Empty;
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage result = await client.GetAsync(u);
				if (result.IsSuccessStatusCode)
				{
					response = await result.Content.ReadAsStringAsync();
				}
			}
			return response;
		}
	}
}
