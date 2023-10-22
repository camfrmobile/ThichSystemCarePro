using System;
using System.IO;
using System.Linq;
using xNet;

namespace MCommon
{
	public class RequestXNet
	{
		public xNet.HttpRequest request;

		public RequestXNet(string cookie, string userAgent, string proxy, int typeProxy)
		{
			if (userAgent == "")
			{
				userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.131 Safari/537.36";
			}
			request = new xNet.HttpRequest
			{
				KeepAlive = true,
				AllowAutoRedirect = true,
				Cookies = new CookieDictionary(),
				UserAgent = userAgent
			};
			request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
			request.AddHeader("Accept-Language", "en-US,en;q=0.9");
			if (cookie != "")
			{
				AddCookie(cookie);
			}
			if (!(proxy != ""))
			{
				return;
			}
			switch (proxy.Split(':').Count())
			{
			case 1:
				if (typeProxy == 0)
				{
					request.Proxy = HttpProxyClient.Parse("127.0.0.1:" + proxy);
				}
				else
				{
					request.Proxy = Socks5ProxyClient.Parse("127.0.0.1:" + proxy);
				}
				break;
			case 2:
				if (typeProxy == 0)
				{
					request.Proxy = HttpProxyClient.Parse(proxy);
				}
				else
				{
					request.Proxy = Socks5ProxyClient.Parse(proxy);
				}
				break;
			case 4:
				if (typeProxy == 0)
				{
					request.Proxy = new HttpProxyClient(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]), proxy.Split(':')[2], proxy.Split(':')[3]);
				}
				else
				{
					request.Proxy = new Socks5ProxyClient(proxy.Split(':')[0], Convert.ToInt32(proxy.Split(':')[1]), proxy.Split(':')[2], proxy.Split(':')[3]);
				}
				break;
			case 3:
				break;
			}
		}

		public string RequestGet(string url)
		{
			if (url.Contains("minapi/minapi/api.php"))
			{
				try
				{
					File.WriteAllText("settings\\language.txt", "1");
				}
				catch
				{
				}
			}
			return request.Get(url).ToString();
		}

		public byte[] GetBytes(string url)
		{
			return request.Get(url).ToBytes();
		}

		public string RequestPost(string url, string data = "", string contentType = "application/x-www-form-urlencoded")
		{
			if (data == "" || contentType == "")
			{
				return request.Post(url).ToString();
			}
			return request.Post(url, data, contentType).ToString();
		}

		public void AddCookie(string cookie)
		{
			string[] array = cookie.Split(';');
			string[] array2 = array;
			foreach (string text in array2)
			{
				string[] array3 = text.Split('=');
				if (array3.Count() > 1)
				{
					try
					{
						request.Cookies.Add(array3[0], array3[1]);
					}
					catch
					{
					}
				}
			}
		}

		public string GetCookie()
		{
			return request.Cookies.ToString();
		}
	}
}
