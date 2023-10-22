using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using maxcare;
using Newtonsoft.Json.Linq;

namespace MCommon
{
	internal class CommonRequest
	{
		public static List<string> GetListGroup(string cookie, string proxy, int typeProxy, bool isCheckKiemDuyet)
		{
			List<string> list = new List<string>();
			try
			{
				RequestXNet requestXNet = new RequestXNet(cookie, "", proxy, typeProxy);
				string input = requestXNet.RequestGet("https://mobile.facebook.com/help/");
				string value = Regex.Match(input, Common.Base64Decode("ImR0c2dfYWciOnsidG9rZW4iOiIoLio/KSI=")).Groups[1].Value;
				string value2 = Regex.Match(cookie + ";", "c_user=(.*?);").Groups[1].Value;
				string url = "https://www.facebook.com/ajax/typeahead/first_degree.php?fb_dtsg_ag=" + value + "&filter%5B0%5D=group&viewer=" + value2 + "&__user=" + value2 + "&__a=1&__dyn=&__comet_req=0&jazoest=26581";
				input = requestXNet.RequestGet(url).Replace("for (;;);", "");
				JObject jObject = JObject.Parse(input);
				foreach (JToken item in (IEnumerable<JToken>)(jObject["payload"]!["entries"]!))
				{
					try
					{
						string text = item["uid"]!.ToString();
						string text2 = item["text"]!.ToString();
						string text3 = item["size"]!.ToString();
						list.Add(text + "|" + text2 + "|" + text3);
					}
					catch
					{
					}
				}
				if (isCheckKiemDuyet)
				{
					list = GetGroupKhongKiemDuyet(list, cookie, "", proxy, typeProxy);
				}
			}
			catch (Exception)
			{
			}
			return list;
		}

		private static List<string> GetGroupKhongKiemDuyet(List<string> lstGroup, string cookie, string useragent, string proxy, int typeProxy)
		{
			try
			{
				int iThread = 0;
				int num = ((lstGroup.Count < 100) ? lstGroup.Count : 100);
				int num2 = 0;
				while (num2 < lstGroup.Count)
				{
					if (iThread < num)
					{
						Interlocked.Increment(ref iThread);
						int row = num2++;
						new Thread((ThreadStart)delegate
						{
							string text = lstGroup[row];
							bool flag = true;
							try
							{
								string text2 = text.Split('|')[0];
								RequestXNet requestXNet = new RequestXNet(cookie, useragent, proxy, typeProxy);
								string text3 = requestXNet.RequestGet("https://mobile.facebook.com/groups/" + text2 + "/madminpanel");
								flag = text3.Contains("madminpanel/pending/");
							}
							catch
							{
							}
							lstGroup[row] = $"{text}|{flag}";
							Interlocked.Decrement(ref iThread);
						}).Start();
					}
					else
					{
						Application.DoEvents();
						Thread.Sleep(200);
					}
				}
				while (iThread > 0)
				{
					Application.DoEvents();
					Thread.Sleep(100);
				}
			}
			catch
			{
			}
			return lstGroup;
		}

		public static string RandomText(int length = 16)
		{
			Random random = new Random();
			string text = "abcdef1234567890";
			string text2 = "";
			for (int i = 0; i < length; i++)
			{
				text2 += Convert.ToString(text[random.Next(0, text.Length)]);
			}
			return text2;
		}

		public static string CheckLiveCookie(string cookie, string userAgent, string proxy, int typeProxy)
		{
			string result = "0|0";
			string value = Regex.Match(cookie + ";", "c_user=(.*?);").Groups[1].Value;
			try
			{
				RequestXNet requestXNet = new RequestXNet(cookie, userAgent, proxy, typeProxy);
				if (value != "")
				{
					string text = requestXNet.RequestGet("https://m.facebook.com/me").ToString();
					if (text.Contains("id=\"code_in_cliff\"") || text.Contains("name=\"new\"") || text.Contains("name=\"c\"") || text.Contains("changeemail"))
					{
						result = "1|0";
					}
					else if (Regex.Match(text, "\"USER_ID\":\"(.*?)\"").Groups[1].Value.Trim() == value.Trim() && text.Contains("/friends/") && !text.Contains("checkpointSubmitButton") && !text.Contains("/checkpoint/dyi") && !text.Contains("checkpointBottomBar") && !text.Contains("captcha_response") && !text.Contains("https://www.facebook.com/communitystandards/") && !text.Contains("/help/203305893040179") && !text.Contains("FB:ACTION:OPEN_NT_SCREEN"))
					{
						result = "1|1";
					}
				}
			}
			catch
			{
			}
			return result;
		}

		public static List<string> GetNameFriend(string token, string proxy, int typeProxy)
		{
			List<string> list = new List<string>();
			try
			{
				RequestXNet requestXNet = new RequestXNet("", "", proxy, typeProxy);
				string json = requestXNet.RequestGet("https://graph.facebook.com/v3.0/me/friends?access_token=" + token + "&limit=5000&fields=id,name");
				JObject jObject = JObject.Parse(json);
				foreach (JToken item in (IEnumerable<JToken>)(jObject["data"]!))
				{
					list.Add(item["name"]!.ToString());
				}
			}
			catch
			{
			}
			return list;
		}

		public static List<string> GetMyListUidNameFriend(string cookie, string token, string userAgent, string proxy, int typeProxy)
		{
			List<string> list = new List<string>();
			try
			{
				string value = Regex.Match(cookie + ";", "c_user=(.*?);").Groups[1].Value;
				RequestXNet requestXNet = new RequestXNet(cookie, userAgent, proxy, typeProxy);
				requestXNet.request.AddHeader("Authorization", "OAuth " + token);
				string json = requestXNet.RequestGet("https://graph.facebook.com/?ids=" + value + "&fields=friends{id,name}");
				JObject jObject = JObject.Parse(json);
				JToken jToken = jObject[value]!["friends"];
				if (jToken["data"].Count() > 0)
				{
					for (int i = 0; i < jToken["data"].Count(); i++)
					{
						string item = jToken["data"]![i]!["id"]!.ToString();
						list.Add(item);
					}
				}
			}
			catch (Exception)
			{
			}
			return list;
		}

		public static List<string> BackupImageOne(string uids, string cookie, string token, string userAgent, string proxy, int typeProxy, int countImage = 20, bool isBackupNangCao = false)
		{
			List<string> list = new List<string>();
			try
			{
				Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
				string[] array = uids.Split(',');
				for (int i = 0; i < array.Length; i++)
				{
					dictionary.Add(array[i], new List<string>());
				}
				RequestXNet requestXNet = new RequestXNet(cookie, userAgent, proxy, typeProxy);
				requestXNet.request.AddHeader("Authorization", "OAuth " + token);
				string url = "https://graph.facebook.com/?ids=" + uids + "&pretty=0&fields=id,name,photos.limit(" + countImage + "){images}";
				string text = requestXNet.RequestGet(url);
				JObject jObject = JObject.Parse(text);
				if (jObject != null && text.Contains("images"))
				{
					string[] array2 = uids.Split(',');
					foreach (string text2 in array2)
					{
						string text3 = jObject[text2]!["name"]!.ToString();
						try
						{
							foreach (JToken item in (IEnumerable<JToken>)(jObject[text2]!["photos"]!["data"]!))
							{
								try
								{
									int num = item["images"].ToList().Count - 1;
									dictionary[text2].Add(text2 + "*" + text3 + "*" + item["images"]![num]!["source"]?.ToString() + "|" + item["images"]![num]!["width"]?.ToString() + "|" + item["images"]![num]!["height"]);
								}
								catch
								{
								}
							}
						}
						catch
						{
						}
					}
				}
				if (isBackupNangCao)
				{
					RequestXNet requestXNet2 = new RequestXNet(cookie, userAgent, proxy, typeProxy);
					requestXNet2.request.AddHeader("Authorization", "OAuth " + token);
					string url2 = "https://graph.facebook.com/?ids=" + uids + "&pretty=0&fields=name,albums.limit(3){photos.limit(10){width,height,images}}";
					string text4 = requestXNet2.RequestGet(url2);
					JObject jObject2 = JObject.Parse(text4);
					if (jObject2 != null && text4.Contains("images"))
					{
						string[] array3 = uids.Split(',');
						foreach (string text5 in array3)
						{
							string text6 = jObject2[text5]!["name"]!.ToString();
							foreach (JToken item2 in (IEnumerable<JToken>)(jObject2[text5]!["albums"]!["data"]!))
							{
								try
								{
									foreach (JToken item3 in (IEnumerable<JToken>)(item2["photos"]!["data"]!))
									{
										try
										{
											int num2 = item3["images"].ToList().Count - 1;
											if (dictionary[text5].Count < countImage)
											{
												dictionary[text5].Add(text5 + "*" + text6 + "*" + item3["images"]![num2]!["source"]?.ToString() + "|" + item3["images"]![num2]!["width"]?.ToString() + "|" + item3["images"]![num2]!["height"]);
												continue;
											}
										}
										catch (Exception)
										{
											continue;
										}
										goto IL_0594;
									}
								}
								catch (Exception)
								{
								}
							}
							IL_0594:;
						}
					}
				}
				foreach (KeyValuePair<string, List<string>> item4 in dictionary)
				{
					if (item4.Value.Count > 0)
					{
						list.AddRange(item4.Value);
						list.Add("");
					}
				}
			}
			catch (Exception)
			{
			}
			return list;
		}

		public static List<string> GetMyListComments(string cookie, string userAgent, string proxy, int typeProxy)
		{
			List<string> list = new List<string>();
			try
			{
				RequestXNet requestXNet = new RequestXNet(cookie, userAgent, proxy, typeProxy);
				string value = Regex.Match(cookie + ";", "c_user=(.*?);").Groups[1].Value;
				string format = "https://mbasic.facebook.com/{0}/allactivity/?category_key=commentscluster&timestart={1}&timeend={2}";
				string text = "";
				string text2 = "";
				string text3 = "";
				string text4 = "";
				MatchCollection matchCollection = null;
				List<string> list2 = new List<string>();
				for (int i = 0; i < 5; i++)
				{
					DateTime dateTime = DateTime.Now.AddMonths(2 - i);
					DateTime dateTime2 = DateTime.Now.AddMonths(1 - i);
					text = Common.ConvertDatetimeToTimestamp(new DateTime(dateTime.Year, dateTime.Month, 1)).ToString();
					text2 = Common.ConvertDatetimeToTimestamp(new DateTime(dateTime2.Year, dateTime2.Month, 1)).ToString();
					text3 = string.Format(format, value, text, text2);
					list2.Add(text3);
				}
				for (int j = 0; j < list2.Count; j++)
				{
					text3 = list2[j];
					bool flag = false;
					do
					{
						flag = false;
						text4 = requestXNet.RequestGet(text3);
						text4 = WebUtility.HtmlDecode(text4);
						matchCollection = Regex.Matches(text4, "<span>(.*?)</h4>");
						for (int k = 0; k < matchCollection.Count; k++)
						{
							string value2 = matchCollection[k].Groups[1].Value;
							value2 = value2.Substring(0, value2.LastIndexOf('<'));
							MatchCollection matchCollection2 = Regex.Matches(value2, "<(.*?)>");
							for (int l = 0; l < matchCollection2.Count; l++)
							{
								value2 = value2.Replace(matchCollection2[l].Value, "");
							}
							if (value2 != "" && !list.Contains(value2))
							{
								list.Add(value2);
							}
						}
						if (Regex.IsMatch(text4, "/" + value + "/allactivity/\\?category_key=commentscluster&timeend(.*?)\""))
						{
							text3 = "https://mbasic.facebook.com" + Regex.Match(text4, "/" + value + "/allactivity/\\?category_key=commentscluster&timeend(.*?)\"").Value.Replace("\"", "");
							flag = true;
						}
					}
					while (flag);
				}
			}
			catch
			{
			}
			return list;
		}

		public static List<string> GetMyListUidMessage(string cookie, string userAgent, string proxy, int typeProxy)
		{
			List<string> list = new List<string>();
			try
			{
				RequestXNet requestXNet = new RequestXNet(cookie, userAgent, proxy, typeProxy);
				int num = 1;
				string input = requestXNet.RequestGet("https://mbasic.facebook.com/messages/");
				string text = "";
				string text2 = "";
				do
				{
					MatchCollection matchCollection = Regex.Matches(input, "#fua\">(.*?)<");
					for (int i = 0; i < matchCollection.Count; i++)
					{
						try
						{
							text2 = matchCollection[i].Groups[1].Value.Replace("\"", "");
							text2 = Common.HtmlDecode(text2);
							if (!list.Contains(text2))
							{
								list.Add(text2);
							}
						}
						catch
						{
						}
					}
					text = Regex.Match(input, "/messages/.pageNum=(.*?)\"").Value.Replace("amp;", "");
					input = requestXNet.RequestGet("https://mbasic.facebook.com" + text);
					num++;
				}
				while (num < 5 && text != "");
			}
			catch
			{
			}
			return list;
		}

		public static string GetMyBirthday(string cookie, string token, string userAgent, string proxy, int typeProxy)
		{
			string result = "";
			try
			{
				RequestXNet requestXNet = new RequestXNet(cookie, userAgent, proxy, typeProxy);
				string json = requestXNet.RequestGet("https://graph.facebook.com/me?fields=id,name,birthday&access_token=" + token);
				JObject jObject = JObject.Parse(json);
				return jObject["id"]!.ToString() + "|" + jObject["birthday"]!.ToString() + "|" + jObject["name"]!.ToString();
			}
			catch
			{
				if (!CheckLiveToken(cookie, token, userAgent, proxy, typeProxy))
				{
					result = "-1";
				}
			}
			return result;
		}

		public static string GetFbDtsg(string cookie, string useragent, string proxy, int typeProxy)
		{
			try
			{
				string input = new RequestXNet(cookie, useragent, proxy, typeProxy).RequestGet("https://m.facebook.com/help/");
				return Regex.Match(input, Common.Base64Decode("ZHRzZyI6eyJ0b2tlbiI6IiguKj8pIg==")).Groups[1].Value;
			}
			catch
			{
				return "";
			}
		}

		public static bool CheckAvatarFromUid(string uid, string filePath = "mau.jpg")
		{
			bool result = false;
			try
			{
				List<bool> hash = GetHash(new Bitmap(filePath));
				List<bool> hash2 = GetHash(GetImageFromUid(uid));
				double num = hash.Zip(hash2, (bool i, bool j) => i == j).Count((bool eq) => eq) / 256;
				result = num == 0.0;
				return result;
			}
			catch
			{
				return result;
			}
		}

		private static Bitmap GetImageFromUid(string uid)
		{
			RequestXNet requestXNet = new RequestXNet("", "", "", 0);
			string url = "https://graph.facebook.com/" + uid + "/picture?access_token=6628568379|c1e620fa708a1d5696fb991c1bde5662";
			byte[] bytes = requestXNet.GetBytes(url);
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(bytes, 0, Convert.ToInt32(bytes.Length));
			Bitmap result = new Bitmap(memoryStream, useIcm: false);
			memoryStream.Dispose();
			return result;
		}

		private static Bitmap GetImageFromUid(string uid, string token)
		{
			RequestXNet requestXNet = new RequestXNet("", "", "", 0);
			string url = "https://graph.facebook.com/" + uid + "/picture?access_token=" + token;
			byte[] bytes = requestXNet.GetBytes(url);
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(bytes, 0, Convert.ToInt32(bytes.Length));
			Bitmap result = new Bitmap(memoryStream, useIcm: false);
			memoryStream.Dispose();
			return result;
		}

		public static bool DownLoadImageByUid(string uid, string token, string pathFolder)
		{
			try
			{
				string address = "https://graph.facebook.com/" + uid + "/picture?width=736&access_token=" + token;
				using (WebClient webClient = new WebClient())
				{
					byte[] buffer = webClient.DownloadData(address);
					using MemoryStream stream = new MemoryStream(buffer);
					using Image image = Image.FromStream(stream);
					string text = pathFolder + "\\" + uid;
					try
					{
						image.Save(text + ".png", ImageFormat.Png);
					}
					catch
					{
						image.Save(text + ".jpg", ImageFormat.Jpeg);
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				Common.ExportError(null, ex, "Error DownLoadImageByUid");
				return false;
			}
		}

		private static List<bool> GetHash(Bitmap bmpSource)
		{
			List<bool> list = new List<bool>();
			Bitmap bitmap = new Bitmap(bmpSource, new Size(16, 16));
			for (int i = 0; i < bitmap.Height; i++)
			{
				for (int j = 0; j < bitmap.Width; j++)
				{
					list.Add(bitmap.GetPixel(j, i).GetBrightness() < 0.5f);
				}
			}
			return list;
		}

		public static string CheckLiveWall(string uid)
		{
			RequestXNet requestXNet = new RequestXNet("", SetupFolder.GetUseragentIPhone(Base.rd), "", 0);
			string text = "";
			try
			{
				text = requestXNet.RequestGet("https://graph.facebook.com/" + uid + "/picture?redirect=false");
				if (!string.IsNullOrEmpty(text))
				{
					if (text.Contains("height") && text.Contains("width"))
					{
						return "1|";
					}
					return "0|";
				}
			}
			catch (Exception)
			{
			}
			return "2|";
		}

		public static string CheckInfoUsingUid(string uid)
		{
			RequestHttp requestHttp = new RequestHttp("", "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:50.0) Gecko/20100101 Firefox/50.0");
			string text = "";
			try
			{
				string text2 = "";
				string text3 = "";
				string text4 = "";
				string text5 = "";
				string text6 = "";
				string text7 = "";
				string text8 = "";
				text = requestHttp.RequestPost("https://www.facebook.com/api/graphql", "q=user(" + uid + "){friends{count},groups{count},id,name,gender,birthday,email_addresses,username}");
				if (!string.IsNullOrEmpty(text))
				{
					JObject jObject = JObject.Parse(text);
					if (string.IsNullOrEmpty(jObject[uid]!.ToString()))
					{
						return "0|";
					}
					if (jObject[uid]!["name"] != null)
					{
						if (jObject[uid]!["friends"]!["count"] != null)
						{
							text2 = jObject[uid]!["friends"]!["count"]!.ToString();
						}
						if (jObject[uid]!["groups"]!["count"] != null)
						{
							text3 = jObject[uid]!["groups"]!["count"]!.ToString();
						}
						if (jObject[uid]!["name"] != null)
						{
							text4 = jObject[uid]!["name"]!.ToString();
						}
						if (jObject[uid]!["gender"] != null)
						{
							text5 = jObject[uid]!["gender"]!.ToString();
						}
						if (jObject[uid]!["username"] != null)
						{
							text6 = jObject[uid]!["username"]!.ToString();
						}
						if (jObject[uid]!["birthday"] != null)
						{
							text7 = jObject[uid]!["birthday"]!.ToString();
						}
						if (jObject[uid]!["email_addresses"]!.ToString() != "[]")
						{
							text8 = jObject[uid]!["email_addresses"]!.ToString();
						}
						return "1|" + text6 + "|" + text4 + "|" + text5 + "|" + text7 + "|" + text2 + "|" + text3 + "|" + text8;
					}
				}
			}
			catch (Exception)
			{
			}
			return "2|";
		}

		public static bool CheckLiveToken(string cookie, string token, string useragent, string proxy, int typeProxy = 0)
		{
			bool result = false;
			try
			{
				RequestXNet requestXNet = new RequestXNet(cookie, useragent, proxy, typeProxy);
				requestXNet.RequestGet("https://graph.facebook.com/me?access_token=" + token);
				result = true;
				return result;
			}
			catch
			{
				return result;
			}
		}

		public static string GetTokenEAAAAZ(string cookie, string useragent, string proxy, int typeProxy = 0)
		{
			string text = "";
			try
			{
				_ = Regex.Match(cookie + ";", "c_user=(.*?);").Groups[1].Value;
				GetFbDtsg(cookie, useragent, proxy, typeProxy);
				RequestXNet requestXNet = new RequestXNet(cookie, useragent, proxy, typeProxy);
				string url = "https://m.facebook.com/composer/ocelot/async_loader/?publisher=feed";
				string input = requestXNet.RequestGet(url);
				text = Regex.Match(input, "EAAAAZ(.*?)\"").Value.Replace("\"", "").Replace("\\", "");
			}
			catch
			{
				if (!CheckLiveCookie(cookie, useragent, proxy, typeProxy).StartsWith("1|"))
				{
					return "-1";
				}
			}
			if (text == "" && !CheckLiveCookie(cookie, useragent, proxy, typeProxy).StartsWith("1|"))
			{
				return "-1";
			}
			return text;
		}

		public static string GetTokenEAAG(string cookie, string userAgent, string proxy, int typeProxy)
		{
			string text = "";
			try
			{
				RequestXNet requestXNet = new RequestXNet(cookie, "", proxy, typeProxy);
				string input = requestXNet.RequestGet("https://business.facebook.com/business_locations/");
				text = Regex.Match(input, "EAAG(.*?)\"").Value.Replace("\"", "").Replace("\\", "");
			}
			catch
			{
				if (!CheckLiveCookie(cookie, userAgent, proxy, typeProxy).StartsWith("1|"))
				{
					return "-1";
				}
			}
			if (text == "" && !CheckLiveCookie(cookie, userAgent, proxy, typeProxy).StartsWith("1|"))
			{
				return "-1";
			}
			return text;
		}

		public static string CheckCheckpoint(string idMethod)
		{
			string result = "";
			int num = 0;
			switch (idMethod)
			{
			case "14":
				result = ((num != 0) ? "device" : "Thiết bị");
				break;
			case "18":
				result = ((num != 0) ? "comment" : "Bình luận");
				break;
			case "2":
				result = ((num != 0) ? "Birthday" : "Ngày sinh");
				break;
			case "3":
				result = ((num != 0) ? "Image" : "Ảnh");
				break;
			case "id_upload":
				result = "Up a\u0309nh";
				break;
			case "72h":
				result = ((num != 0) ? "72 hours" : "72h");
				break;
			case "4":
			case "34":
				result = "Otp";
				break;
			case "37":
				result = "Gư\u0309i OTP vê\u0300 mail";
				break;
			case "2fa":
				result = "Co\u0301 2fa";
				break;
			case "35":
				result = "Login Google";
				break;
			case "26":
				result = ((num != 0) ? "Friend" : "Nhơ\u0300 bạn bè");
				break;
			case "vhh":
				result = ((num != 0) ? "disable" : "Vô hiệu hóa");
				break;
			default:
				File.AppendAllText("data\\dangcp.txt", idMethod);
				break;
			case "20":
				result = ((num != 0) ? "Message" : "Tin nhắn");
				break;
			}
			return result;
		}

		public static string CheckFacebookAccount(string email, string pass, string userAgent, string proxy, int typeProxy)
		{
			string text = "";
			try
			{
				string data = "email=" + WebUtility.UrlEncode(email) + "&pass=" + WebUtility.UrlEncode(pass);
				RequestXNet requestXNet = new RequestXNet("", userAgent, proxy, typeProxy);
				string text2 = requestXNet.RequestPost("https://mbasic.facebook.com/login/device-based/regular/login/?refsrc=https%3A%2F%2Fmbasic.facebook.com%2F&lwv=100&refid=8", data).ToString();
				if (text2.Contains("id=\"checkpointSubmitButton\""))
				{
					if (text2.Contains("id=\"approvals_code\""))
					{
						text = "5|";
					}
					else
					{
						text = "2|";
						requestXNet = new RequestXNet("", userAgent, proxy, typeProxy);
						requestXNet.RequestGet("https://www.facebook.com").ToString();
						text2 = requestXNet.RequestPost("https://www.facebook.com/login/device-based/regular/login/?login_attempt=1&lwv=100", data).ToString();
						string value = Regex.Match(text2, "name=\"fb_dtsg\" value=\"(.*?)\"").Groups[1].Value;
						string value2 = Regex.Match(text2, "name=\"jazoest\" value=\"(.*?)\"").Groups[1].Value;
						string value3 = Regex.Match(text2, "name=\"nh\" value=\"(.*?)\"").Groups[1].Value;
						string value4 = Regex.Match(text2, "\"__spin_r\":(.*?),").Groups[1].Value;
						string value5 = Regex.Match(text2, "\"__spin_t\":(.*?),").Groups[1].Value;
						string data2 = "jazoest=" + value2 + "&fb_dtsg=" + value + "&nh=" + value3 + "&submit[Continue]=Ti%E1%BA%BFp%20t%E1%BB%A5c&__user=0&__a=1&__dyn=7xe6Fo4OQ1PyUhxOnFwn84a2i5U4e1Fx-ewSwMxW0DUeUhw5cx60Vo1upE4W0OE2WxO0SobEa87i0n2US1vw4Ugao881FU3rw&__csr=&__req=5&__beoa=0&__pc=PHASED%3ADEFAULT&dpr=1&__rev=" + value4 + "&__s=op5tkm%3A2d4a9m%3A37z92b&__hsi=6789153697588537525-0&__spin_r=" + value4 + "&__spin_b=trunk&__spin_t=" + value5;
						text2 = requestXNet.RequestPost("https://www.facebook.com/checkpoint/async?next=https%3A%2F%2Fwww.facebook.com%2F", data2);
						text2 = requestXNet.RequestGet("https://www.facebook.com/checkpoint/?next");
						MatchCollection matchCollection = Regex.Matches(text2, "verification_method\" value=\"(.*?)\"");
						if (matchCollection.Count > 0)
						{
							for (int i = 0; i < matchCollection.Count; i++)
							{
								text = text + CheckCheckpoint(matchCollection[i].Groups[1].Value) + "-";
							}
							text = text.TrimEnd('-');
						}
						else if (text2.Contains("/checkpoint/dyi/?referrer=disabled_checkpoint"))
						{
							text += CheckCheckpoint("vhh");
						}
						else if (text2.Contains("captcha-recaptcha"))
						{
							text += CheckCheckpoint("72h");
						}
						else if (text2.Contains("name=\"submit[Log Out]\"") || text2.Contains("name=\"submit[__placeholder__]\""))
						{
							text += "không thê\u0309 xmdt";
						}
						else if (text2.Contains("name=\"submit[Continue]\""))
						{
							text += "Thiê\u0301t bi\u0323";
						}
					}
				}
				else if (text2.Contains("login_error"))
				{
					text = ((!text2.Contains("m_login_email")) ? "0|" : "3|");
				}
				else if (text2.Contains("action_set_contact_point"))
				{
					text = "2|" + CheckCheckpoint("34");
				}
				else
				{
					string cookie = requestXNet.GetCookie();
					text = ((!CheckLiveCookie(cookie, userAgent, proxy, typeProxy).StartsWith("1|")) ? "2|" : (text + "1|" + cookie));
				}
			}
			catch
			{
				text = "0|";
			}
			return text;
		}

		public static string GetInfoAccountFromUidUsingToken(string tokenTrungGian, string uid, string useragent, string proxy, int typeProxy)
		{
			string text = "";
			bool flag = false;
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			try
			{
				RequestXNet requestXNet = new RequestXNet("", useragent, proxy, typeProxy);
				if (uid == "")
				{
					uid = "me";
				}
				string json = requestXNet.RequestGet("https://graph.facebook.com/v2.11/" + uid + "?fields=name,email,gender,birthday,friends.limit(0)&access_token=" + tokenTrungGian);
				JObject jObject = JObject.Parse(json);
				flag = true;
				text2 = jObject["name"]!.ToString();
				try
				{
					text3 = jObject["gender"]!.ToString();
				}
				catch
				{
				}
				try
				{
					text4 = jObject["birthday"]!.ToString();
				}
				catch
				{
				}
				try
				{
					text6 = jObject["email"]!.ToString();
				}
				catch
				{
				}
				try
				{
					text7 = jObject["friends"]!["summary"]!["total_count"]!.ToString();
				}
				catch
				{
				}
				if (text7 == "")
				{
					text7 = "0";
				}
				json = requestXNet.RequestGet("https://graph.facebook.com/v2.11/" + uid + "/groups?fields=id&limit=5000&access_token=" + tokenTrungGian);
				jObject = JObject.Parse(json);
				try
				{
					text8 = jObject["data"].Count().ToString() ?? "";
				}
				catch
				{
				}
				if (text8 == "")
				{
					text8 = "0";
				}
			}
			catch
			{
				if (!CheckLiveToken("", tokenTrungGian, "", ""))
				{
					return "-1";
				}
			}
			return $"{flag}|{text2}|{text3}|{text4}|{text5}|{text6}|{text7}|{text8}";
		}

		public static string GetInfoAccountFromUidUsingCookie(string cookie, string useragent, string proxy, int typeProxy)
		{
			string text = "";
			bool flag = false;
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			string text9 = "";
			string text10 = "";
			try
			{
				string value = Regex.Match(cookie + ";", "c_user=(.*?);").Groups[1].Value;
				RequestXNet requestXNet = new RequestXNet(cookie, useragent, proxy, typeProxy);
				string input = requestXNet.RequestGet("https://m.facebook.com/composer/ocelot/async_loader/?publisher=feed");
				string value2 = Regex.Match(input, Common.Base64Decode("bmFtZT1cXCJmYl9kdHNnXFwiIHZhbHVlPVxcIiguKj8pXFwi")).Groups[1].Value;
				text9 = Regex.Match(input, "EAAA(.*?)\"").Value.TrimEnd('"', '\\');
				text2 = Regex.Match(input, Common.Base64Decode("cHJvZnBpY1xcIiBhcmlhLWxhYmVsPVxcIiguKj8pLA==")).Groups[1].Value;
				text2 = WebUtility.HtmlDecode(text2);
				string text11 = Common.Base64Decode("LS0tLS0tV2ViS2l0Rm9ybUJvdW5kYXJ5MnlnMEV6RHBTWk9DWGdCUgpDb250ZW50LURpc3Bvc2l0aW9uOiBmb3JtLWRhdGE7IG5hbWU9ImZiX2R0c2ciCgp7e2ZiX2R0c2d9fQotLS0tLS1XZWJLaXRGb3JtQm91bmRhcnkyeWcwRXpEcFNaT0NYZ0JSCkNvbnRlbnQtRGlzcG9zaXRpb246IGZvcm0tZGF0YTsgbmFtZT0icSIKCm5vZGUoe3t1aWR9fSl7ZnJpZW5kc3tjb3VudH0sc3Vic2NyaWJlcnN7Y291bnR9LGdyb3VwcyxjcmVhdGVkX3RpbWV9Ci0tLS0tLVdlYktpdEZvcm1Cb3VuZGFyeTJ5ZzBFekRwU1pPQ1hnQlItLQ==");
				text11 = text11.Replace("{{fb_dtsg}}", value2);
				text11 = text11.Replace("{{uid}}", value);
				input = requestXNet.RequestPost("https://www.facebook.com/api/graphql/", text11, "multipart/form-data; boundary=----WebKitFormBoundary2yg0EzDpSZOCXgBR");
				JObject jObject = JObject.Parse(input);
				text7 = jObject[value]!["friends"]!["count"]!.ToString();
				text8 = jObject[value]!["groups"]!["count"]!.ToString();
				text10 = jObject[value]!["created_time"]!.ToString();
				if (text7 == "")
				{
					text7 = "0";
				}
				if (text8 == "")
				{
					text8 = "0";
				}
			}
			catch
			{
				if (!CheckLiveCookie(cookie, useragent, proxy, typeProxy).Contains("1|"))
				{
					return "-1";
				}
			}
			return $"{flag}|{text2}|{text3}|{text4}|{text5}|{text6}|{text7}|{text8}|{text9}|{text10}";
		}

		public static string GetInfoAccountFromUidUsingCookieTrungGian(string uid, string cookie_ori)
		{
			string text = "";
			bool flag = false;
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			string text9 = "";
			string text10 = "";
			try
			{
				string text11 = "c_user=" + Regex.Match(cookie_ori + ";", "c_user=(.*?);").Groups[1].Value + "; xs=xs=" + Regex.Match(cookie_ori + ";", "xs=(.*?);").Groups[1].Value + ";";
				RequestXNet requestXNet = new RequestXNet(text11 + " useragent=TW96aWxsYS81LjAgKFdpbmRvd3MgTlQgMTAuMDsgV2luNjQ7IHg2NCkgQXBwbGVXZWJLaXQvNTM3LjM2IChLSFRNTCwgbGlrZSBHZWNrbykgQ2hyb21lLzc0LjAuMjMwMi42MSBTYWZhcmkvNTM3LjM2", "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:50.0) Gecko/20100101 Firefox/50.0", "", 0);
				string url = "https://www.facebook.com/api/graphql";
				string data = "q=user(" + uid + ")%7Bfriends%7Bcount%7D%2Cgroups%7Bcount%7D%2Cid%2Cname%2Cgender%2Cbirthday%2Cemail_addresses%2Cusername%7D";
				string json = requestXNet.RequestPost(url, data);
				JObject jObject = JObject.Parse(json);
				text7 = jObject[uid]!["friends"]!["count"]!.ToString();
				text8 = jObject[uid]!["groups"]!["count"]!.ToString();
				text2 = jObject[uid]!["name"]!.ToString();
				text4 = ((jObject[uid]!["birthday"] != null) ? jObject[uid]!["birthday"]!.ToString() : "");
				text3 = jObject[uid]!["gender"]!.ToString().ToLower();
				if (text7 == "")
				{
					text7 = "0";
				}
				if (text8 == "")
				{
					text8 = "0";
				}
				flag = true;
			}
			catch
			{
				if (!CheckLiveCookie(cookie_ori, "", "", 0).StartsWith("1|"))
				{
					return "-1";
				}
				flag = false;
			}
			return $"{flag}|{text2}|{text3}|{text4}|{text5}|{text6}|{text7}|{text8}|{text9}|{text10}";
		}

		public static bool DownLoadImageByUid(string uid, string pathFolder)
		{
			try
			{
				string address = "https://graph.facebook.com/" + uid + "/picture?width=736&access_token=6628568379|c1e620fa708a1d5696fb991c1bde5662";
				using (WebClient webClient = new WebClient())
				{
					byte[] buffer = webClient.DownloadData(address);
					using MemoryStream stream = new MemoryStream(buffer);
					using Image image = Image.FromStream(stream);
					string text = pathFolder + "\\" + uid;
					try
					{
						image.Save(text + ".png", ImageFormat.Png);
					}
					catch
					{
						image.Save(text + ".jpg", ImageFormat.Jpeg);
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				Common.ExportError(null, ex, "Error DownLoadImageByUid");
				return false;
			}
		}
	}
}
