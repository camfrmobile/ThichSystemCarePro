using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MCommon
{
	internal class Vitech
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

		public Vitech(string apiKey, string proxy, int typeProxy, int limit_theads_use)
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
				string url = "https://apiv2-public.vitechcheap.com/v1/public/rotate";
				string data = "{\"proxy\": \"" + proxy + "\"}";
				RequestPost(url, apiKey, data);
				return result;
			}
			catch
			{
				return false;
			}
		}

		private static string RequestPost(string url, string apiKey, string data)
		{
			string text = "";
			try
			{
				HttpClient httpClient = new HttpClient();
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
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
				return result;
			}
			catch
			{
				return result;
			}
		}
	}
}
