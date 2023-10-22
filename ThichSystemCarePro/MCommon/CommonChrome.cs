using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using maxcare;
using maxcare.Enum;
using Newtonsoft.Json.Linq;

namespace MCommon
{
	public class CommonChrome
	{
		public static bool CheckFacebookBlocked(Chrome chrome)
		{
			if (chrome.GetURL().StartsWith("https://m.facebook.com/feature_limit_notice/") || chrome.CheckExistElements(0.0, "[href=\"https://www.facebook.com/help/177066345680802\"]", "[href*=\"https://m.facebook.com/help/contact/\"]") != 0)
			{
				return true;
			}
			return false;
		}

		public static void AnswerQuestionWhenJoinGroup(Chrome chrome, List<string> lstCauTraLoi)
		{
			List<string> list = new List<string>();
			string text = "";
			int num = chrome.CountElement("textarea");
			chrome.ScrollSmooth("document.querySelector('textarea')");
			chrome.DelayThaoTacNho();
			for (int i = 0; i < num; i++)
			{
				if (list.Count == 0)
				{
					list = Common.CloneList(lstCauTraLoi);
				}
				text = list[Base.rd.Next(0, list.Count)];
				text = Common.SpinText(text, Base.rd);
				list.Remove(text);
				chrome.SendKeys(4, "textarea", i, text, 0.1);
				chrome.DelayThaoTacNho();
			}
		}

		public static bool IsCheckpointWhenLoginWhenGiaiCP(Chrome chrome)
		{
			try
			{
				return chrome.CheckExistElement("#captcha_response") == 1 || chrome.CheckExistElement("[name=\"captcha_response\"]") == 1 || chrome.CheckExistElement("[name=\"verification_method\"]") == 1 || chrome.CheckExistElement("[name=\"password_new\"]") == 1 || chrome.CheckExistElement("[href=\"https://www.facebook.com/communitystandards/\"]") == 1;
			}
			catch
			{
				return false;
			}
		}

		public static int LoginFacebookUsingUidPassWhenGiaiCP(Chrome chrome, string uid, string pass, string fa2 = "", string URL = "https://www.facebook.com")
		{
			new Random();
			int result = 0;
			try
			{
				int num = 0;
				num = CheckTypeWebFacebookFromUrl(chrome.GetURL());
				if (num != 0)
				{
					goto IL_005b;
				}
				if (chrome.GotoURL(URL) != -2)
				{
					num = CheckTypeWebFacebookFromUrl(chrome.GetURL());
					goto IL_005b;
				}
				result = -2;
				goto end_IL_000c;
				IL_005b:
				if (chrome.CheckExistElement("[data-cookiebanner=\"accept_button\"]") == 1)
				{
					chrome.Click(4, "[data-cookiebanner=\"accept_button\"]");
					chrome.DelayTime(1.0);
				}
				if (num == 1)
				{
					chrome.GotoURLIfNotExist("https://www.facebook.com/login");
					if (chrome.CheckExistElement("[data-cookiebanner=\"accept_button\"]") == 1)
					{
						chrome.Click(4, "[data-cookiebanner=\"accept_button\"]");
						chrome.DelayTime(1.0);
					}
					if (chrome.SendKeys(1, "email", uid, 0.1) == -2)
					{
						result = -2;
					}
					else
					{
						chrome.DelayTime(1.0);
						if (chrome.SendKeys(1, "pass", pass, 0.1) == -2)
						{
							result = -2;
						}
						else
						{
							chrome.DelayTime(1.0);
							if (chrome.Click(1, "loginbutton") != -2)
							{
								chrome.DelayTime(1.0);
								if (chrome.CheckExistElement("#approvals_code", 5.0) == 1 && fa2 != "")
								{
									string totp = Common.GetTotp(fa2.Replace(" ", "").Replace("\n", ""));
									if (totp != "")
									{
										chrome.SendKeys(1, "approvals_code", totp, 0.1);
										chrome.DelayTime(1.0);
										chrome.Click(1, "checkpointSubmitButton");
										chrome.DelayTime(1.0);
									}
								}
								int num2 = 0;
								while (chrome.CheckExistElement("#checkpointSubmitButton", 3.0) == 1)
								{
									if (chrome.CheckIsLive())
									{
										if (IsCheckpointWhenLoginWhenGiaiCP(chrome) || num2 == 7)
										{
											break;
										}
										chrome.Click(1, "checkpointSubmitButton");
										chrome.DelayTime(1.0);
										num2++;
										continue;
									}
									result = -2;
									goto end_IL_000c;
								}
								goto IL_08be;
							}
							result = -2;
						}
					}
				}
				else
				{
					int num3 = chrome.GotoURLIfNotExist("https://m.facebook.com/login");
					if (chrome.CheckExistElement("[data-cookiebanner=\"accept_button\"]") == 1)
					{
						chrome.Click(4, "[data-cookiebanner=\"accept_button\"]");
						chrome.DelayTime(1.0);
					}
					num3 = chrome.CheckExistElement("[data-sigil=\"login_profile_form\"] div[role=\"button\"]", 1.0);
					int num4 = num3;
					int num5 = num4;
					if (num5 != -2)
					{
						if (num5 != 1)
						{
							if (chrome.SendKeys(1, "m_login_email", uid, 0.1) == 1)
							{
								chrome.DelayThaoTacNho();
								string attributeValue = ((chrome.CheckExistElements(3.0, "#m_login_password", "[name=\"pass\"]") == 1) ? "#m_login_password" : "[name=\"pass\"]");
								chrome.SendKeys(4, attributeValue, pass, 0.1);
								chrome.DelayThaoTacNho();
								chrome.Click(2, "login");
								chrome.DelayThaoTacNho();
							}
							goto IL_06e4;
						}
						chrome.DelayThaoTacNho();
						if (chrome.Click(4, "[data-sigil=\"login_profile_form\"] div[role=\"button\"]") != -2)
						{
							chrome.DelayThaoTacNho(2);
							switch (chrome.CheckExistElements(10.0, "[name=\"pass\"]", "#approvals_code"))
							{
							case -2:
								result = -2;
								goto end_IL_000c;
							case 1:
								if (chrome.SendKeys(2, "pass", pass, 0.1) == 1)
								{
									chrome.DelayThaoTacNho();
									if (chrome.Click(4, chrome.GetCssSelector("button", "data-sigil", "password_login_button")) == 1)
									{
										chrome.DelayTime(1.0);
									}
								}
								break;
							}
							goto IL_06e4;
						}
						result = -2;
					}
					else
					{
						result = -2;
					}
				}
				goto end_IL_000c;
				IL_08be:
				chrome.DelayTime(1.0);
				return CheckLiveCookie(chrome);
				IL_06e4:
				int num6;
				int num7;
				switch (chrome.CheckExistElement("#approvals_code", 5.0))
				{
				case -2:
					result = -2;
					goto end_IL_000c;
				case 1:
					num6 = ((fa2.Trim() != "") ? 1 : 0);
					goto IL_0736;
				default:
					{
						num6 = 0;
						goto IL_0736;
					}
					IL_0736:
					if (num6 != 0)
					{
						string totp2 = Common.GetTotp(fa2.Replace(" ", "").Replace("\n", ""));
						if (totp2 != "")
						{
							chrome.SendKeys(1, "approvals_code", totp2, 0.1);
							chrome.DelayThaoTacNho(-1);
							chrome.Click(1, "checkpointSubmitButton-actual-button");
							chrome.DelayThaoTacNho();
						}
					}
					num7 = 0;
					while (chrome.CheckExistElement("#checkpointSubmitButton-actual-button", 3.0) == 1 && chrome.CheckExistElement("[name=\"password_new\"]") != 1)
					{
						if (chrome.CheckIsLive())
						{
							if (IsCheckpointWhenLogin(chrome) || num7 == 7)
							{
								break;
							}
							chrome.Click(1, "checkpointSubmitButton-actual-button");
							chrome.DelayThaoTacNho();
							num7++;
							continue;
						}
						result = -2;
						goto end_IL_000c;
					}
					break;
				}
				goto IL_08be;
				end_IL_000c:;
			}
			catch (Exception ex)
			{
				Common.ExportError(chrome, ex, "Login Uid Pass Fail");
			}
			return result;
		}

		public static string GetNameFromPost(Chrome chrome)
		{
			return chrome.ExecuteScript("var x='';document.querySelectorAll('[property=\"og:title\"]').length>0&&(x=document.querySelector('[property=\"og:title\"]').getAttribute('content')),''==x&&document.querySelectorAll('[data-gt] a').length>0&&(x=document.querySelector('[data-gt] a').innerText),''==x&&document.querySelectorAll('.actor').length>0&&(x=document.querySelector('.actor').innerText), x+''; return x;").ToString();
		}

		public static string GetNameFromStory(Chrome chrome)
		{
			return chrome.ExecuteScript("var x='';document.querySelectorAll('.overflowText').length>0&&(x=document.querySelector('.overflowText').innerText), x+''; return x;").ToString();
		}

		public static int GoToHome(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					if (!(chrome.GetURL() == "https://m.facebook.com/home.php") && !(chrome.GetURL() == "https://m.facebook.com"))
					{
						if (chrome.CheckExistElement("#feed_jewel a") == 1)
						{
							chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('#feed_jewel a')");
							chrome.DelayThaoTacNho();
						}
						if (chrome.Click(4, "#feed_jewel a") != 1)
						{
							chrome.GotoURL("https://m.facebook.com/home.php");
						}
						chrome.DelayTime(1.0);
						if (chrome.CheckExistElement("#nux-nav-button", 2.0) == 1)
						{
							chrome.ClickWithAction(1, "nux-nav-button");
							chrome.DelayTime(2.0);
						}
					}
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					if (chrome.GetURL() == "https://m.facebook.com/home.php" || chrome.GetURL() == "https://m.facebook.com/home.php?ref=wizard&_rdr" || chrome.GetURL() == "https://m.facebook.com")
					{
						return 1;
					}
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToFriend(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					if (chrome.CheckExistElement("#requests_jewel a") == 1)
					{
						chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('#requests_jewel a')");
						chrome.DelayThaoTacNho();
					}
					int num = chrome.Click(4, "#requests_jewel a");
					if (num != 1)
					{
						GoToHome(chrome);
						chrome.DelayThaoTacNho(2);
						num = chrome.Click(4, "#requests_jewel a");
					}
					if (num == 1)
					{
						chrome.DelayThaoTacNho(1);
						if (chrome.Click(4, "[href=\"/friends/center/friends/?mff_nav=1\"]") == 1)
						{
							chrome.DelayThaoTacNho();
							return 1;
						}
					}
					return chrome.GotoURL("https://m.facebook.com/friends/center/friends/?mff_nav=1");
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToFriendSuggest(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					if (chrome.CheckExistElement("#requests_jewel a") == 1)
					{
						chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('#requests_jewel a')");
						chrome.DelayThaoTacNho();
					}
					int num = chrome.Click(4, "#requests_jewel a");
					if (num != 1)
					{
						GoToHome(chrome);
						chrome.DelayThaoTacNho(2);
						num = chrome.Click(4, "#requests_jewel a");
					}
					if (num == 1)
					{
						chrome.DelayThaoTacNho(1);
						if (chrome.Click(4, "[href=\"/friends/center/suggestions/?mff_nav=1&ref=bookmarks\"]") == 1)
						{
							chrome.DelayThaoTacNho();
							return 1;
						}
					}
					return chrome.GotoURL("https://m.facebook.com/friends/center/suggestions/?mff_nav=1&ref=bookmarks");
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToGroup(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					if (chrome.CheckExistElement("[data-sigil=\"nav-popover bookmarks\"]>a") == 1)
					{
						chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('[data-sigil=\"nav-popover bookmarks\"]>a')");
						chrome.DelayThaoTacNho();
					}
					int num = chrome.Click(4, "[data-sigil=\"nav-popover bookmarks\"]>a");
					if (num != 1)
					{
						GoToHome(chrome);
						chrome.DelayThaoTacNho(2);
						num = chrome.Click(4, "[data-sigil=\"nav-popover bookmarks\"]>a");
					}
					if (num == 1)
					{
						chrome.DelayThaoTacNho(1);
						string cssSelector = chrome.GetCssSelector("a", "href", "/groups/");
						if (cssSelector != "")
						{
							chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('" + cssSelector + "')");
							chrome.DelayThaoTacNho();
							if (chrome.Click(4, cssSelector) == 1)
							{
								chrome.DelayThaoTacNho(2);
								if (chrome.Click(4, "[href=\"/groups_browse/your_groups/\"]") == 1)
								{
									chrome.DelayThaoTacNho();
									return 1;
								}
							}
						}
					}
					return chrome.GotoURL("https://m.facebook.com/groups_browse/your_groups/");
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToWatch(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					if (chrome.CheckExistElement("[data-sigil=\"nav-popover bookmarks\"]>a") == 1)
					{
						chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('[data-sigil=\"nav-popover bookmarks\"]>a')");
						chrome.DelayThaoTacNho();
					}
					int num = chrome.Click(4, "[data-sigil=\"nav-popover bookmarks\"]>a");
					if (num != 1)
					{
						GoToHome(chrome);
						chrome.DelayThaoTacNho(2);
						num = chrome.Click(4, "[data-sigil=\"nav-popover bookmarks\"]>a");
					}
					if (num == 1)
					{
						chrome.DelayThaoTacNho(1);
						string cssSelector = chrome.GetCssSelector("a", "href", "/watch/");
						if (cssSelector != "")
						{
							chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('" + cssSelector + "')");
							chrome.DelayThaoTacNho();
							if (chrome.Click(4, cssSelector) == 1)
							{
								chrome.DelayThaoTacNho();
								return 1;
							}
						}
					}
					return chrome.GotoURL("https://m.facebook.com/watch/?ref=bookmarks");
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToSetting(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					if (chrome.CheckExistElement("[data-sigil=\"nav-popover bookmarks\"]>a") == 1)
					{
						chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('[data-sigil=\"nav-popover bookmarks\"]>a')");
						chrome.DelayThaoTacNho();
					}
					int num = chrome.Click(4, "[data-sigil=\"nav-popover bookmarks\"]>a");
					if (num != 1)
					{
						GoToHome(chrome);
						chrome.DelayThaoTacNho(2);
						num = chrome.Click(4, "[data-sigil=\"nav-popover bookmarks\"]>a");
					}
					if (num == 1)
					{
						chrome.DelayThaoTacNho(1);
						string cssSelector = chrome.GetCssSelector("a", "href", "/settings/");
						if (cssSelector != "")
						{
							chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('" + cssSelector + "')");
							chrome.DelayThaoTacNho();
							if (chrome.Click(4, cssSelector) == 1)
							{
								chrome.DelayThaoTacNho();
								return 1;
							}
						}
					}
					return chrome.GotoURL("https://m.facebook.com/settings/?entry_point=bookmark");
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToSetting_TimelineAndTagging(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					GoToSetting(chrome);
					string cssSelector = chrome.GetCssSelector("a", "href", "/privacy/touch/timeline_and_tagging/");
					if (cssSelector != "")
					{
						chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('" + cssSelector + "')");
						chrome.DelayThaoTacNho();
						if (chrome.Click(4, cssSelector) == 1)
						{
							chrome.DelayThaoTacNho();
							return 1;
						}
					}
					return chrome.GotoURL("https://m.facebook.com/privacy/touch/timeline_and_tagging/");
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToNotifications(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					if (chrome.CheckExistElement("#notifications_jewel a") == 1)
					{
						chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('#notifications_jewel a')");
						chrome.DelayThaoTacNho();
					}
					int num = chrome.Click(4, "#notifications_jewel a");
					if (num != 1)
					{
						GoToHome(chrome);
						num = chrome.Click(4, "#notifications_jewel a");
					}
					if (num == 1)
					{
						chrome.DelayThaoTacNho(1);
						return 1;
					}
					return chrome.GotoURL("https://m.facebook.com/notifications.php?ref=bookmarks");
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToMessages(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					if (chrome.CheckExistElement("#messages_jewel a") == 1)
					{
						chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('#messages_jewel a')");
						chrome.DelayThaoTacNho();
					}
					int num = chrome.Click(4, "#messages_jewel a");
					if (num != 1)
					{
						GoToHome(chrome);
						chrome.DelayThaoTacNho(2);
						num = chrome.Click(4, "#messages_jewel a");
					}
					if (num == 1)
					{
						chrome.DelayThaoTacNho(1);
						return 1;
					}
					return chrome.GotoURL("https://m.facebook.com/messages/?entrypoint=jewel&no_hist=1&ref=bookmarks");
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToMessagesUnread(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (GoToMessages(chrome) == 1 && chrome.Click(4, "[href=\"/messages/?folder=unread&refid=11&ref=bookmarks\"]") == 1)
					{
						chrome.DelayRandom(3, 5);
						return 1;
					}
					return chrome.GotoURL("https://m.facebook.com/messages/?folder=unread&ref=bookmarks");
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToSearch(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					if (chrome.CheckExistElement("#notifications_jewel a") == 1)
					{
						chrome.ScrollSmoothIfNotExistOnScreen("document.querySelector('#search_jewel a')");
						chrome.DelayThaoTacNho();
					}
					int num = chrome.Click(4, "#search_jewel a");
					if (num != 1)
					{
						GoToHome(chrome);
						chrome.DelayThaoTacNho(2);
						num = chrome.Click(4, "#search_jewel a");
					}
					if (num == 1 && chrome.CheckExistElement("#main-search-input") == 1)
					{
						chrome.DelayThaoTacNho(1);
						return 1;
					}
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToSearchGroup(Chrome chrome, string tuKhoa, int tocDoGoVanBan = 0)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					if (GoToSearch(chrome) == 1)
					{
						bool flag = false;
						if (chrome.CheckExistElement("#main-search-input") == 1)
						{
							tuKhoa = Common.SpinText(tuKhoa, Base.rd);
							switch (tocDoGoVanBan)
							{
							case 0:
								chrome.SendKeys(Base.rd, 1, "main-search-input", tuKhoa, 0.1);
								break;
							case 1:
								chrome.SendKeys(1, "main-search-input", tuKhoa, 0.1);
								break;
							case 2:
								chrome.SendKeys(1, "main-search-input", tuKhoa);
								break;
							}
							chrome.DelayThaoTacNho();
							chrome.SendEnter(1, "main-search-input");
							chrome.DelayThaoTacNho(2);
							string cssSelector = chrome.GetCssSelector("[data-sigil=\"mlayer-hide-on-click search-tabbar-tab\"]", "href", "/search/groups");
							if (cssSelector != "")
							{
								if (chrome.Click(4, cssSelector) == 0)
								{
									if (chrome.Click(4, "[data-sigil=\" flyout-causal\"]") == 1)
									{
										chrome.DelayThaoTacNho();
										cssSelector = chrome.GetCssSelector("[data-sigil=\"mlayer-hide-on-click search-tabbar-tab\"]", "href", "/search/groups");
										if (cssSelector != "")
										{
											flag = true;
											chrome.Click(4, cssSelector);
											chrome.DelayThaoTacNho(2);
										}
									}
								}
								else
								{
									flag = true;
									chrome.DelayThaoTacNho(2);
								}
							}
						}
						if (!flag)
						{
							chrome.GotoURL("https://m.facebook.com/search/groups/?q=" + tuKhoa);
							chrome.DelayThaoTacNho(2);
							flag = true;
						}
						if (flag)
						{
							chrome.DelayThaoTacNho(1);
							return 1;
						}
					}
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToSearchFriend(Chrome chrome, string tuKhoa, int tocDoGoVanBan = 0)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					if (GoToSearch(chrome) == 1)
					{
						bool flag = false;
						if (chrome.CheckExistElement("#main-search-input") == 1)
						{
							tuKhoa = Common.SpinText(tuKhoa, Base.rd);
							switch (tocDoGoVanBan)
							{
							case 0:
								chrome.SendKeys(Base.rd, 1, "main-search-input", tuKhoa, 0.1);
								break;
							case 1:
								chrome.SendKeys(1, "main-search-input", tuKhoa, 0.1);
								break;
							case 2:
								chrome.SendKeys(1, "main-search-input", tuKhoa);
								break;
							}
							chrome.DelayThaoTacNho();
							chrome.SendEnter(1, "main-search-input");
							chrome.DelayThaoTacNho(2);
							string cssSelector = chrome.GetCssSelector("[data-sigil=\"mlayer-hide-on-click search-tabbar-tab\"]", "href", "/search/people");
							if (cssSelector != "")
							{
								if (chrome.Click(4, cssSelector) == 0)
								{
									if (chrome.Click(4, "[data-sigil=\" flyout-causal\"]") == 1)
									{
										chrome.DelayThaoTacNho();
										cssSelector = chrome.GetCssSelector("[data-sigil=\"mlayer-hide-on-click search-tabbar-tab\"]", "href", "/search/people");
										if (cssSelector != "")
										{
											flag = true;
											chrome.Click(4, cssSelector);
											chrome.DelayThaoTacNho(2);
										}
									}
								}
								else
								{
									flag = true;
									chrome.DelayThaoTacNho(2);
								}
							}
						}
						if (!flag)
						{
							chrome.GotoURL("https://m.facebook.com/search/people/?q=" + tuKhoa + "&source=filter&isTrending=0");
							chrome.DelayThaoTacNho(2);
							flag = true;
						}
						if (flag)
						{
							chrome.DelayThaoTacNho(1);
							return 1;
						}
					}
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToBirthday(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.GotoURL("https://m.facebook.com/browse/birthdays/") != -2)
					{
						chrome.DelayRandom(2, 5);
						return 1;
					}
					return -2;
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int GoToPoke(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.GotoURL("https://m.facebook.com/pokes/") != -2)
					{
						chrome.DelayRandom(2, 5);
						return 1;
					}
					return -2;
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int ScrollRandom(Chrome chrome, int from = 3, int to = 5)
		{
			try
			{
				if (chrome.CheckChromeClosed())
				{
					return -2;
				}
				int num = Base.rd.Next(from, to + 1);
				int num2 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelector('html').getBoundingClientRect().y+''").ToString());
				if (chrome.ScrollSmooth(Base.rd.Next(chrome.GetSizeChrome().Y / 2, chrome.GetSizeChrome().Y)) == 1)
				{
					chrome.DelayRandom(1, 3);
					int num3 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelector('html').getBoundingClientRect().y+''").ToString());
					if (num2 != num3)
					{
						for (int i = 0; i < num - 1; i++)
						{
							num2 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelector('html').getBoundingClientRect().y+''").ToString());
							if (chrome.ScrollSmooth(((Base.rd.Next(1, 1000) % 5 != 0) ? 1 : (-1)) * Base.rd.Next(chrome.GetSizeChrome().Y / 2, chrome.GetSizeChrome().Y)) != -2)
							{
								chrome.DelayRandom(1, 3);
								num3 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelector('html').getBoundingClientRect().y+''").ToString());
								if (num2 == num3)
								{
									break;
								}
								chrome.DelayRandom(1, 2);
								continue;
							}
							return -2;
						}
					}
					return 1;
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int CheckStatusChrome(Chrome chrome)
		{
			try
			{
				if (chrome != null)
				{
					if (chrome.CheckChromeClosed())
					{
						return -2;
					}
					switch (chrome.CheckExistElement("[jsselect=\"suggestionsSummaryList\"]"))
					{
					default:
						if (IsCheckpoint(chrome))
						{
							return -1;
						}
						break;
					case 1:
						return -3;
					case -2:
						return -2;
					}
				}
			}
			catch
			{
			}
			return 0;
		}

		public static int ConvertInterfaceFacebook(Chrome chrome, int type)
		{
			int result = 0;
			int num = 0;
			try
			{
				string text = "https://www.facebook.com";
				if (chrome.GetURL().StartsWith(text))
				{
					goto IL_004a;
				}
				num = chrome.GotoURL(text);
				if (num != -2)
				{
					goto IL_004a;
				}
				result = -2;
				goto end_IL_000c;
				IL_004a:
				object obj = chrome.ExecuteScript("async function ConvertFacebook(e) { var t = require([\"DTSGInitData\"]).token, a = require([\"CurrentUserInitialData\"]).USER_ID, r = \"\", o = \"\"; 0 == e ? (r = \"https://www.facebook.com/api/graphql/\", o = \"av=\" + a + \"&__user=\" + a + \"&__a=1&dpr=1&fb_dtsg=\" + t + \"&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=CometTrialParticipationChangeMutation&variables=%7B%22input%22%3A%7B%22change_type%22%3A%22OPT_OUT%22%2C%22source%22%3A%22SETTINGS_MENU%22%2C%22actor_id%22%3A%22\" + a + \"%22%2C%22client_mutation_id%22%3A%221%22%7D%7D&server_timestamps=true&doc_id=2317726921658975\") : (r = \"https://www.facebook.com/comet/try/\", o = \"source=SETTINGS_MENU&nctr[_mod]=pagelet_bluebar&__user=\" + a + \"&__a=1dpr=1&fb_dtsg=\" + t); var output = ''; try { var response = await fetch(r, { method: 'POST', body: o, headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }); if (response.ok) { var body = await response.text(); return body; } } catch {} return output; } var c = await ConvertFacebook(" + type + ");");
				if (obj != null && obj.ToString() == "-2")
				{
					result = -2;
				}
				else if (chrome.Refresh() == -2)
				{
					result = -2;
				}
				else
				{
					switch (chrome.CheckExistElement("[role=\"navigation\"]", 10.0))
					{
					case 1:
						if ((type == 0 && chrome.CountElement("[role=\"navigation\"]") < 3) || (type == 1 && chrome.CountElement("[role=\"navigation\"]") == 3))
						{
							result = 1;
						}
						break;
					case -2:
						result = -2;
						break;
					}
				}
				end_IL_000c:;
			}
			catch (Exception)
			{
			}
			return result;
		}

		public static string GetUserAgentDefault()
		{
			string text = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36";
			try
			{
				JSON_Settings jSON_Settings = new JSON_Settings("configGeneral");
				Chrome chrome = new Chrome
				{
					HideBrowser = true,
					PathExtension = ""
				};
				if (jSON_Settings.GetValueInt("typeBrowser") != 0)
				{
					chrome.LinkToOtherBrowser = jSON_Settings.GetValue("txtLinkToOtherBrowser");
				}
				if (chrome.Open())
				{
					text = chrome.GetUseragent();
					text = text.Replace("Headless", "");
					chrome.Close();
				}
			}
			catch
			{
			}
			return text;
		}

		public static bool CheckInvalidChrome()
		{
			try
			{
				JSON_Settings jSON_Settings = new JSON_Settings("configGeneral");
				Chrome chrome = new Chrome
				{
					HideBrowser = true,
					PathExtension = ""
				};
				if (jSON_Settings.GetValueInt("typeBrowser") != 0)
				{
					chrome.LinkToOtherBrowser = jSON_Settings.GetValue("txtLinkToOtherBrowser");
				}
				if (chrome.Open())
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		public static bool ConnectProxy(Chrome chrome, string username, string password)
		{
			bool result = false;
			try
			{
				chrome.GotoURL("chrome-extension://ggmdpepbjljkkkdaklfihhngmmgmpggp/options.html");
				chrome.SendKeys(1, "login", username);
				chrome.SendKeys(1, "password", password);
				chrome.ClearText(1, "retry");
				chrome.SendKeys(1, "retry", "2");
				chrome.Click(1, "save");
				chrome.DelayTime(2.0);
				chrome.GotoURL("http://lumtest.com/myip.json");
				string json = chrome.ExecuteScript("return document.documentElement.innerText;").ToString();
				string text = JObject.Parse(json)["ip"]!.ToString();
				if (text != "")
				{
					result = true;
					return result;
				}
				return result;
			}
			catch
			{
				return result;
			}
		}

		public static int LoginFacebookUsingCookie(Chrome chrome, string cookie, string URL = "https://www.facebook.com")
		{
			try
			{
				if (chrome.GotoURLIfNotExist(URL) == -2)
				{
					return -2;
				}
				if (chrome.AddCookieIntoChrome(cookie) == -2)
				{
					return -2;
				}
				if (chrome.Refresh() == -2)
				{
					return -2;
				}
				return CheckLiveCookie(chrome);
			}
			catch
			{
			}
			return 0;
		}

		public static int CheckTypeWebFacebookFromUrl(string url)
		{
			int result = 0;
			if (url.StartsWith("https://www.facebook") || url.StartsWith("https://facebook") || url.StartsWith("https://web.facebook"))
			{
				result = 1;
			}
			else if (url.StartsWith("https://m.facebook") || url.StartsWith("https://d.facebook") || url.StartsWith("https://mobile.facebook"))
			{
				result = 2;
			}
			else if (url.StartsWith("https://mbasic.facebook"))
			{
				result = 3;
			}
			return result;
		}

		public static int CheckFacebookWebsite(Chrome chrome, string url)
		{
			if (!chrome.CheckIsLive())
			{
				return -2;
			}
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (chrome.GetURL().StartsWith("https://www.facebook") || chrome.GetURL().StartsWith("https://facebook") || chrome.GetURL().StartsWith("https://web.facebook"))
				{
					num = 1;
				}
				else if (chrome.GetURL().StartsWith("https://m.facebook") || chrome.GetURL().StartsWith("https://mobile.facebook"))
				{
					num = 2;
				}
				else if (chrome.GetURL().StartsWith("https://mbasic.facebook"))
				{
					num = 3;
				}
				if (num != 0 && num == CheckTypeWebFacebookFromUrl(url))
				{
					break;
				}
				chrome.GotoURL(url);
				chrome.DelayTime(1.0);
			}
			return num;
		}

		public static List<string> GetListLinkFromWebsite(Chrome chrome)
		{
			List<string> result = new List<string>();
			try
			{
				result = chrome.ExecuteScript("var arr=[]; document.querySelectorAll('a').forEach(e=>{arr.push(e.href)});var s=arr.join('|'); return s").ToString().Split('|')
					.ToList();
			}
			catch
			{
			}
			return result;
		}

		public static string LoginFacebookUsingUidPassNew(Chrome chrome, string uid, string pass, string fa2 = "", string Url = "https://m.facebook.com", int tocDoGoVanBan = 0, bool isDontSaveBrowser = false, int timeOut = 120)
		{
			int num = 0;
			int num2 = 0;
			int tickCount = Environment.TickCount;
			try
			{
				int typeWeb = CheckFacebookWebsite(chrome, Url);
				switch (chrome.CheckExistElements(0.0, "[data-cookiebanner=\"accept_button\"]", "[name=\"pass\"]"))
				{
				case 1:
					chrome.FindAndClick(0.0, 4, "[data-cookiebanner=\"accept_button\"]");
					if (chrome.CheckExistElement("[name=\"pass\"]") != 1)
					{
						chrome.GotoLogin(typeWeb);
						chrome.FindAndClick(0.0, 4, "[data-cookiebanner=\"accept_button\"]");
					}
					break;
				case 0:
					chrome.GotoLogin(typeWeb);
					chrome.FindAndClick(0.0, 4, "[data-cookiebanner=\"accept_button\"]");
					break;
				}
				if (CheckTypeWebFacebookFromUrl(chrome.GetURL()) == 2 && chrome.FindAndClick(0.0, 4, "[data-sigil=\"login_profile_form\"] div[role=\"button\"]") == 1)
				{
					chrome.DelayTime(1.0);
					num2 = chrome.CheckExistElements(5.0, "[name=\"pass\"]", "#approvals_code");
					if (num2 == 1 && chrome.SendKeysWithSpeed(tocDoGoVanBan, 2, "pass", pass, 0.1) == 1)
					{
						chrome.DelayTime(1.0);
						if (chrome.Click(4, chrome.GetCssSelector("button", "data-sigil", "password_login_button")) == 1)
						{
							chrome.DelayTime(1.0);
						}
					}
					goto IL_0455;
				}
				if (chrome.CheckExistElement("[data-sigil=\"touchable\"]") == 1 && chrome.CheckExistElement("#m_login_auto_search_form_forgot_password_button") != 1)
				{
					chrome.FindAndClick(0.0, 4, "[data-sigil=\"touchable\"]");
				}
				int num3 = 1;
				bool flag = false;
				int num4 = 1;
				int num5 = 1;
				while (true)
				{
					IL_0415:
					num2 = chrome.SendKeysWithSpeed(tocDoGoVanBan, 2, "email", uid, 0.1);
					while (true)
					{
						if (num2 != -2)
						{
							chrome.DelayTime(1.0);
							num3++;
							if (!flag)
							{
								switch (num3)
								{
								default:
									flag = true;
									continue;
								case 2:
									num2 = chrome.SendKeysWithSpeed(tocDoGoVanBan, 2, "pass", pass, 0.1);
									continue;
								case 3:
									num2 = chrome.Click(2, "login");
									chrome.DelayTime(3.0);
									flag = true;
									continue;
								case 1:
									break;
								}
								goto IL_0415;
							}
							goto IL_0455;
						}
						num = -2;
						break;
					}
					break;
				}
				goto end_IL_0012;
				IL_0455:
				int num6 = 0;
				int num7 = 0;
				while (Environment.TickCount - tickCount < timeOut * 1000)
				{
					switch (chrome.CheckExistElements(0.0, "[name=\"login\"]", "[name=\"approvals_code\"]", "#checkpointSubmitButton", "#qf_skip_dialog_skip_link", "#nux-nav-button", "[name=\"n\"]", "[name=\"reset_action\"]", "#checkpointBottomBar"))
					{
					default:
						if (chrome.GetURL().Contains("facebook.com/nt/screen/?params=%7B%22token") || chrome.CheckExistElements(0.0, "[name=\"verification_method\"]", "[name=\"submit[Yes]\"]", "[name=\"password_new\"]", "[name=\"send_code\"]", "#captcha_response", "[href=\"https://www.facebook.com/communitystandards/\"]", "[action=\"/login/checkpoint/\"] [name=\"contact_index\"]") != 0 || CheckStringContainKeyword(chrome.GetPageSource(), new List<string> { "/checkpoint/dyi", "https://www.facebook.com/communitystandards/", "help/121104481304395" }))
						{
							num = 2;
						}
						else if (chrome.CheckExistElement("a[href*='/friends/']") == 1)
						{
							num = 1;
						}
						else if (CheckTypeWebFacebookFromUrl(chrome.GetURL()) == 2)
						{
							if (chrome.GetURL().StartsWith("https://m.facebook.com/zero/policy/optin"))
							{
								chrome.DelayTime(1.0);
								chrome.ExecuteScript("document.querySelector('a[data-sigil=\"touchable\"]').click()");
								chrome.DelayTime(3.0);
								if (chrome.CheckExistElement("button[data-sigil=\"touchable\"]", 10.0) == 1)
								{
									chrome.DelayTime(1.0);
									chrome.ExecuteScript("document.querySelector('button[data-sigil=\"touchable\"]').click()");
									chrome.DelayTime(3.0);
								}
							}
							if (Convert.ToBoolean(chrome.ExecuteScript("var check='false';var x=document.querySelectorAll('a');for(i=0;i<x.length;i++){if(x[i].href.includes('legal_consent/basic/?consent_step=1')){x[i].click();break;check='true'}} return check")))
							{
								for (int i = 0; i < 5; i++)
								{
									Common.DelayTime(2.0);
									if (!Convert.ToBoolean(chrome.ExecuteScript("var check='false';var x=document.querySelectorAll('a');for(i=0;i<x.length;i++){if(x[i].href.includes('legal_consent/basic/?consent_step=1')){x[i].click();break;check='true'}} return check")))
									{
										break;
									}
								}
								for (int j = 0; j < 5; j++)
								{
									Common.DelayTime(2.0);
									if (!Convert.ToBoolean(chrome.ExecuteScript("var check='false';var x=document.querySelectorAll('a');for(i=0;i<x.length;i++){if(x[i].href.includes('consent/basic/log')){x[i].click();break;check='true'}} return check")))
									{
										break;
									}
								}
								if (chrome.CheckExistElement("[href=\"/home.php\"]") == 1)
								{
									chrome.Click(4, "[href=\"/home.php\"]");
								}
							}
							if (chrome.GetURL().StartsWith("https://m.facebook.com/legal_consent"))
							{
								chrome.ExecuteScript("document.querySelector('button').click()");
								chrome.DelayTime(1.0);
								chrome.ExecuteScript("document.querySelectorAll('button')[1].click()");
								chrome.DelayTime(1.0);
								chrome.ExecuteScript("document.querySelector('button').click()");
								chrome.DelayTime(1.0);
								chrome.ExecuteScript("document.querySelectorAll('button')[1].click()");
								chrome.DelayTime(1.0);
							}
							if (chrome.GetURL().StartsWith("https://m.facebook.com/si/actor_experience/actor_gateway"))
							{
								chrome.Click(4, "[data-sigil=\"touchable\"]");
								chrome.DelayTime(1.0);
							}
							if (chrome.CheckExistElement("button[value=\"OK\"]") == 1)
							{
								chrome.Click(4, "button[value=\"OK\"]");
								chrome.DelayTime(1.0);
							}
							if (chrome.CheckExistElement("[data-store-id=\"2\"]>span") == 1)
							{
								chrome.Click(4, "[data-store-id=\"2\"]>span");
								chrome.DelayTime(1.0);
							}
							if (chrome.CheckExistElement("[data-nt=\"FB:HEADER_FOOTER_VIEW\"]>div>div>div>span>span") == 1)
							{
								chrome.Click(4, "[data-nt=\"FB:HEADER_FOOTER_VIEW\"]>div>div>div>span>span");
								chrome.DelayTime(3.0);
							}
						}
						else if (chrome.GetURL().StartsWith("https://www.facebook.com/legal_consent"))
						{
							for (int k = 0; k < 5; k++)
							{
								if (chrome.CheckExistElement("button") != 1)
								{
									break;
								}
								chrome.ExecuteScript("document.querySelector('button').click()");
								chrome.DelayTime(1.0);
							}
						}
						goto IL_104c;
					case 2:
						if (fa2 == "")
						{
							num = 3;
						}
						else if (num6 == 3)
						{
							num = 6;
						}
						else
						{
							string totp = Common.GetTotp(fa2.Replace(" ", "").Replace("\n", "").Trim());
							if (totp != "")
							{
								num6++;
								chrome.SendKeysWithSpeed(tocDoGoVanBan, 2, "approvals_code", totp, 0.1);
								chrome.DelayTime(1.0);
								num2 = chrome.CheckExistElements(0.0, "button#checkpointSubmitButton", "#checkpointSubmitButton [type=\"submit\"]");
								if (num2 == 1)
								{
									chrome.Click(4, "button#checkpointSubmitButton");
								}
								else
								{
									chrome.Click(4, "#checkpointSubmitButton [type=\"submit\"]");
								}
								chrome.DelayTime(1.0);
							}
							else
							{
								num = 6;
							}
						}
						goto IL_104c;
					case 4:
						chrome.ClickWithAction(1, "qf_skip_dialog_skip_link");
						chrome.DelayTime(2.0);
						goto IL_104c;
					case 5:
						chrome.Click(1, "nux-nav-button");
						chrome.DelayTime(2.0);
						goto IL_104c;
					case 6:
						num = 5;
						goto IL_104c;
					case 1:
					case 7:
						if (num6 == 0 && num7 == 0)
						{
							string text = "";
							switch (CheckTypeWebFacebookFromUrl(chrome.GetURL()))
							{
							case 2:
								text = chrome.ExecuteScript("var out='';var x=document.querySelector('#login_error');if(x!=null) out=x.innerText;return out;").ToString();
								break;
							case 1:
								text = chrome.ExecuteScript("var out='';var x=document.querySelector('#error_box');if(x!=null) out=x.innerText;return out;").ToString();
								text = ((text.Split(new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Count() > 1) ? text.Split(new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1] : text);
								break;
							}
							if (text != "")
							{
								return text;
							}
							if (chrome.CheckExistElement("[href=\"/login/identify/\"]") == 1)
							{
								num = 4;
							}
							else if (chrome.CheckExistElement("#account_recovery_initiate_view_label") == 1)
							{
								num = 5;
							}
							else if (!Convert.ToBoolean(chrome.ExecuteScript("return (document.querySelector('[name=\"email\"]').value!='' && document.querySelector('[name=\"pass\"]').value!='')+''").ToString()))
							{
								if (chrome.ExecuteScript("return document.querySelector('[name=\"email\"]').value").ToString().Trim() == "")
								{
									num = 4;
								}
								else if (chrome.ExecuteScript("return document.querySelector('[name=\"pass\"]').value").ToString().Trim() == "")
								{
									num = 5;
								}
							}
						}
						else if (chrome.ExecuteScript("return document.querySelector('[name=\"email\"]').value").ToString().Trim() == "")
						{
							num = 0;
							break;
						}
						goto IL_104c;
					case 3:
					case 8:
						{
							if (num6 > 1)
							{
								num = 6;
							}
							else if (chrome.CheckExistElements(0.0, "[name=\"verification_method\"]", "[name=\"submit[Yes]\"]", "[name=\"password_new\"]", "[name=\"send_code\"]", "#captcha_response", "[href=\"https://www.facebook.com/communitystandards/\"]", "[name=\"code_1\"]", "[action=\"/login/checkpoint/\"] [name=\"contact_index\"]") != 0 || CheckStringContainKeyword(chrome.GetPageSource(), new List<string> { "/checkpoint/dyi", "https://www.facebook.com/communitystandards/", "help/121104481304395" }))
							{
								num = 2;
							}
							else
							{
								num2 = chrome.CheckExistElements(0.0, "button#checkpointSubmitButton", "#checkpointSubmitButton [type=\"submit\"]");
								if (num7 < 10)
								{
									if (chrome.CheckExistElement("[value=\"dont_save\"]") == 1 && isDontSaveBrowser)
									{
										chrome.Click(4, "[value=\"dont_save\"]");
									}
									num7++;
									if (num2 == 1)
									{
										chrome.Click(4, "button#checkpointSubmitButton");
									}
									else
									{
										chrome.Click(4, "#checkpointSubmitButton [type=\"submit\"]");
									}
									chrome.DelayTime(1.0);
								}
								else
								{
									num = 0;
								}
							}
							goto IL_104c;
						}
						IL_104c:
						if (num == 0)
						{
							continue;
						}
						break;
					}
					break;
				}
				end_IL_0012:;
			}
			catch (Exception ex)
			{
				Common.ExportError(chrome, ex, "Error Login Uid Pass");
			}
			return num.ToString() ?? "";
		}

		public static int LoginFacebookUsingUidPass(Chrome chrome, string uid, string pass, string fa2 = "", string URL = "https://www.facebook.com", int tocDoGoVanBan = 0)
		{
			Random rd = new Random();
			int result = 0;
			int num = 0;
			try
			{
				int num2 = 0;
				if (chrome.GetURL().StartsWith("https://www.facebook") || chrome.GetURL().StartsWith("https://facebook") || chrome.GetURL().StartsWith("https://web.facebook"))
				{
					num2 = 1;
				}
				else if (chrome.GetURL().StartsWith("https://m.facebook") || chrome.GetURL().StartsWith("https://mobile.facebook"))
				{
					num2 = 2;
				}
				if (num2 != 0)
				{
					goto IL_011c;
				}
				if (chrome.GotoURL(URL) != -2)
				{
					if (chrome.GetURL().StartsWith("https://www.facebook") || chrome.GetURL().StartsWith("https://facebook"))
					{
						num2 = 1;
					}
					else if (chrome.GetURL().StartsWith("https://m.facebook"))
					{
						num2 = 2;
					}
					goto IL_011c;
				}
				result = -2;
				goto end_IL_0012;
				IL_011c:
				if (chrome.CheckExistElement("[data-cookiebanner=\"accept_button\"]") == 1)
				{
					chrome.Click(4, "[data-cookiebanner=\"accept_button\"]");
					chrome.DelayTime(1.0);
				}
				if (num2 == 1)
				{
					chrome.GotoURLIfNotExist("https://www.facebook.com/login");
					if (chrome.CheckExistElement("[data-cookiebanner=\"accept_button\"]") == 1)
					{
						chrome.Click(4, "[data-cookiebanner=\"accept_button\"]");
						chrome.DelayTime(1.0);
					}
					chrome.DelayTime(1.0);
					switch (tocDoGoVanBan)
					{
					case 0:
						num = chrome.SendKeys(Base.rd, 1, "email", uid, 0.1);
						break;
					case 1:
						num = chrome.SendKeys(1, "email", uid, 0.1);
						break;
					case 2:
						num = chrome.SendKeys(1, "email", uid);
						break;
					}
					if (num == -2)
					{
						result = -2;
					}
					else
					{
						chrome.DelayTime(1.0);
						switch (tocDoGoVanBan)
						{
						case 0:
							num = chrome.SendKeys(Base.rd, 1, "pass", pass, 0.1);
							break;
						case 1:
							num = chrome.SendKeys(1, "pass", pass, 0.1);
							break;
						case 2:
							num = chrome.SendKeys(1, "pass", pass);
							break;
						}
						if (num == -2)
						{
							result = -2;
						}
						else
						{
							chrome.DelayTime(1.0);
							if (chrome.Click(1, "loginbutton") != -2)
							{
								chrome.DelayTime(1.0);
								if (chrome.CheckExistElement("#approvals_code", 5.0) == 1 && fa2 != "")
								{
									string totp = Common.GetTotp(fa2.Replace(" ", "").Replace("\n", ""));
									if (totp != "")
									{
										chrome.SendKeys(1, "approvals_code", totp, 0.1);
										chrome.DelayTime(1.0);
										chrome.Click(1, "checkpointSubmitButton");
										chrome.DelayTime(1.0);
									}
								}
								int num3 = 0;
								while (chrome.CheckExistElement("#checkpointSubmitButton", 3.0) == 1)
								{
									if (chrome.CheckIsLive())
									{
										if (IsCheckpointWhenLogin(chrome) || num3 == 7)
										{
											break;
										}
										chrome.Click(1, "checkpointSubmitButton");
										chrome.DelayTime(1.0);
										num3++;
										continue;
									}
									result = -2;
									goto end_IL_0012;
								}
								goto IL_0c33;
							}
							result = -2;
						}
					}
				}
				else
				{
					int num4 = chrome.GotoURLIfNotExist("https://m.facebook.com/login");
					if (chrome.CheckExistElement("[data-cookiebanner=\"accept_button\"]") == 1)
					{
						chrome.Click(4, "[data-cookiebanner=\"accept_button\"]");
						chrome.DelayTime(1.0);
					}
					num4 = chrome.CheckExistElement("[data-sigil=\"login_profile_form\"] div[role=\"button\"]", 1.0);
					int num5 = num4;
					int num6 = num5;
					if (num6 != -2)
					{
						if (num6 != 1)
						{
							switch (tocDoGoVanBan)
							{
							case 0:
								num = chrome.SendKeys(rd, 1, "m_login_email", uid, 0.1);
								break;
							case 1:
								num = chrome.SendKeys(1, "m_login_email", uid, 0.1);
								break;
							case 2:
								num = chrome.SendKeys(1, "m_login_email", uid);
								break;
							}
							if (num == 1)
							{
								chrome.DelayThaoTacNho();
								string attributeValue = ((chrome.CheckExistElements(3.0, "#m_login_password", "[name=\"pass\"]") == 1) ? "#m_login_password" : "[name=\"pass\"]");
								switch (tocDoGoVanBan)
								{
								case 0:
									chrome.SendKeys(rd, 4, attributeValue, pass, 0.1);
									break;
								case 1:
									chrome.SendKeys(4, attributeValue, pass, 0.1);
									break;
								case 2:
									chrome.SendKeys(4, attributeValue, pass);
									break;
								}
								chrome.DelayThaoTacNho();
								chrome.Click(2, "login");
								chrome.DelayThaoTacNho();
							}
							goto IL_0a2d;
						}
						chrome.DelayThaoTacNho();
						if (chrome.Click(4, "[data-sigil=\"login_profile_form\"] div[role=\"button\"]") != -2)
						{
							chrome.DelayThaoTacNho(2);
							switch (chrome.CheckExistElements(10.0, "[name=\"pass\"]", "#approvals_code"))
							{
							case -2:
								result = -2;
								goto end_IL_0012;
							case 1:
								switch (tocDoGoVanBan)
								{
								case 0:
									num = chrome.SendKeys(rd, 2, "pass", pass, 0.1);
									break;
								case 1:
									num = chrome.SendKeys(2, "pass", pass, 0.1);
									break;
								case 2:
									num = chrome.SendKeys(2, "pass", pass);
									break;
								}
								if (num == 1)
								{
									chrome.DelayThaoTacNho();
									if (chrome.Click(4, chrome.GetCssSelector("button", "data-sigil", "password_login_button")) == 1)
									{
										chrome.DelayTime(1.0);
									}
								}
								break;
							}
							goto IL_0a2d;
						}
						result = -2;
					}
					else
					{
						result = -2;
					}
				}
				goto end_IL_0012;
				IL_0a2d:
				int num7 = 0;
				while (chrome.CheckExistElement("#checkpointSubmitButton-actual-button", 3.0) == 1)
				{
					int num4 = chrome.CheckExistElements(2.0, "#approvals_code", "[name=\"approvals_code\"]");
					if (num4 != 0)
					{
						string attributeValue2 = ((num4 == 1) ? "#approvals_code" : "[name=\"approvals_code\"]");
						if (fa2.Trim() != "")
						{
							string text = "";
							for (int i = 0; i < 10; i++)
							{
								text = Common.GetTotp(fa2);
								if (text != "")
								{
									break;
								}
								Common.DelayTime(1.0);
							}
							if (text != "")
							{
								chrome.SendKeys(4, attributeValue2, text, 0.1);
								chrome.DelayThaoTacNho(-1);
								chrome.Click(1, "checkpointSubmitButton-actual-button");
								chrome.DelayThaoTacNho();
							}
							else
							{
								Common.ExportError(null, "Khong Lay Duoc 2FA: " + fa2);
							}
							num7 = 0;
						}
					}
					if (chrome.CheckIsLive())
					{
						if (IsCheckpointWhenLogin(chrome) || num7 == 10)
						{
							break;
						}
						chrome.Click(1, "checkpointSubmitButton-actual-button");
						chrome.DelayThaoTacNho();
						num7++;
						continue;
					}
					result = -2;
					goto end_IL_0012;
				}
				goto IL_0c33;
				IL_0c33:
				chrome.DelayTime(1.0);
				return CheckLiveCookie(chrome);
				end_IL_0012:;
			}
			catch (Exception ex)
			{
				Common.ExportError(chrome, ex, "Login Uid Pass Fail");
			}
			return result;
		}

		public static string GetInfoAccountFromUidUsingCookie(Chrome chrome)
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
			string text11 = "";
			try
			{
				string cookieFromChrome = chrome.GetCookieFromChrome();
				string value = Regex.Match(cookieFromChrome + ";", "c_user=(.*?);").Groups[1].Value;
				string input = RequestGet(chrome, "https://m.facebook.com/composer/ocelot/async_loader/?publisher=feed", "https://m.facebook.com/");
				string value2 = Regex.Match(input, Common.Base64Decode("bmFtZT1cXCJmYl9kdHNnXFwiIHZhbHVlPVxcIiguKj8pXFwi")).Groups[1].Value;
				text9 = Regex.Match(input, "EAAA(.*?)\"").Value.TrimEnd('"', '\\');
				text2 = Regex.Match(input, Common.Base64Decode("cHJvZnBpY1xcIiBhcmlhLWxhYmVsPVxcIiguKj8pLA==")).Groups[1].Value;
				text2 = WebUtility.HtmlDecode(text2);
				string text12 = Common.Base64Decode("LS0tLS0tV2ViS2l0Rm9ybUJvdW5kYXJ5MnlnMEV6RHBTWk9DWGdCUgpDb250ZW50LURpc3Bvc2l0aW9uOiBmb3JtLWRhdGE7IG5hbWU9ImZiX2R0c2ciCgp7e2ZiX2R0c2d9fQotLS0tLS1XZWJLaXRGb3JtQm91bmRhcnkyeWcwRXpEcFNaT0NYZ0JSCkNvbnRlbnQtRGlzcG9zaXRpb246IGZvcm0tZGF0YTsgbmFtZT0icSIKCm5vZGUoe3t1aWR9fSl7ZnJpZW5kc3tjb3VudH0sc3Vic2NyaWJlcnN7Y291bnR9LGdyb3Vwc3tjb3VudH0sY3JlYXRlZF90aW1lfQotLS0tLS1XZWJLaXRGb3JtQm91bmRhcnkyeWcwRXpEcFNaT0NYZ0JSLS0=");
				text12 = text12.Replace("{{fb_dtsg}}", value2);
				text12 = text12.Replace("{{uid}}", value);
				input = RequestPost(chrome, "https://www.facebook.com/api/graphql/", text12, "https://www.facebook.com/api/graphql/", "multipart/form-data; boundary=----WebKitFormBoundary2yg0EzDpSZOCXgBR");
				string infoAccountFromUidUsingToken = GetInfoAccountFromUidUsingToken(chrome, text9);
				string[] array = infoAccountFromUidUsingToken.Split('|');
				text3 = array[2];
				text4 = array[3];
				text6 = array[5];
				JObject jObject = JObject.Parse(input);
				try
				{
					text11 = jObject[value]!["subscribers"]!["count"]!.ToString();
				}
				catch
				{
				}
				try
				{
					text7 = jObject[value]!["friends"]!["count"]!.ToString();
				}
				catch
				{
				}
				try
				{
					text8 = jObject[value]!["groups"]!["count"]!.ToString();
				}
				catch
				{
				}
				try
				{
					text10 = jObject[value]!["created_time"]!.ToString();
					if (!text10.Contains("/"))
					{
						text10 = Common.ConvertTimeStampToDateTime(Convert.ToDouble(text10)).ToString("dd/MM/yyyy HH:mm:ss");
					}
				}
				catch
				{
				}
				if (text11 == "")
				{
					text11 = "0";
				}
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
				if (CheckLiveCookie(chrome, "https://m.facebook.com/") == 0)
				{
					return "-1";
				}
			}
			return $"{flag}|{text2}|{text3}|{text4}|{text5}|{text6}|{text7}|{text8}|{text9}|{text10}|{text11}";
		}

		public static string GetInfoAccountFromUidUsingToken(Chrome chrome, string token)
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
				string json = RequestGet(chrome, "https://graph.facebook.com/v2.11/me?fields=name,email,gender,birthday&access_token=" + token, "https://graph.facebook.com/");
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
			}
			catch
			{
			}
			return $"{flag}|{text2}|{text3}|{text4}|{text5}|{text6}|{text7}|{text8}";
		}

		public static string GetTokenEAAAAZ(Chrome chrome)
		{
			string result = "";
			try
			{
				string input = RequestGet(chrome, "https://m.facebook.com/composer/ocelot/async_loader/?publisher=feed", "https://m.facebook.com");
				result = Regex.Match(input, "EAAAAZ(.*?)\"").Value.Replace("\"", "").Replace("\\", "");
			}
			catch
			{
			}
			return result;
		}

		public static int CheckLiveCookie(Chrome chrome, string url = "https://m.facebook.com")
		{
			try
			{
				if (chrome.CheckChromeClosed())
				{
					return -2;
				}
				if (CheckTypeWebFacebookFromUrl(chrome.GetURL()) == 0)
				{
					chrome.GotoURL(url);
				}
				string uRL = chrome.GetURL();
				if (uRL.Contains("facebook.com/checkpoint/") || uRL.Contains("facebook.com/nt/screen/?params=%7B%22token") || uRL.Contains("facebook.com/x/checkpoint/"))
				{
					return 2;
				}
				switch (CheckFacebookWebsite(chrome, url))
				{
				case 2:
					if (chrome.GetURL().StartsWith("https://m.facebook.com/zero/policy/optin"))
					{
						chrome.DelayTime(1.0);
						chrome.ExecuteScript("document.querySelector('a[data-sigil=\"touchable\"]').click()");
						chrome.DelayTime(3.0);
						if (chrome.CheckExistElement("button[data-sigil=\"touchable\"]", 10.0) == 1)
						{
							chrome.DelayTime(1.0);
							chrome.ExecuteScript("document.querySelector('button[data-sigil=\"touchable\"]').click()");
							chrome.DelayTime(3.0);
						}
					}
					if (Convert.ToBoolean(chrome.ExecuteScript("var check='false';var x=document.querySelectorAll('a');for(i=0;i<x.length;i++){if(x[i].href.includes('legal_consent/basic/?consent_step=1')){x[i].click();break;check='true'}} return check")))
					{
						for (int j = 0; j < 5; j++)
						{
							Common.DelayTime(2.0);
							if (!Convert.ToBoolean(chrome.ExecuteScript("var check='false';var x=document.querySelectorAll('a');for(i=0;i<x.length;i++){if(x[i].href.includes('legal_consent/basic/?consent_step=1')){x[i].click();break;check='true'}} return check")))
							{
								break;
							}
						}
						for (int k = 0; k < 5; k++)
						{
							Common.DelayTime(2.0);
							if (!Convert.ToBoolean(chrome.ExecuteScript("var check='false';var x=document.querySelectorAll('a');for(i=0;i<x.length;i++){if(x[i].href.includes('consent/basic/log')){x[i].click();break;check='true'}} return check")))
							{
								break;
							}
						}
						if (chrome.CheckExistElement("[href=\"/home.php\"]") == 1)
						{
							chrome.Click(4, "[href=\"/home.php\"]");
						}
					}
					if (chrome.GetURL().StartsWith("https://m.facebook.com/legal_consent"))
					{
						chrome.ExecuteScript("document.querySelector('button').click()");
						chrome.DelayTime(1.0);
						chrome.ExecuteScript("document.querySelectorAll('button')[1].click()");
						chrome.DelayTime(1.0);
						chrome.ExecuteScript("document.querySelector('button').click()");
						chrome.DelayTime(1.0);
						chrome.ExecuteScript("document.querySelectorAll('button')[1].click()");
						chrome.DelayTime(1.0);
					}
					if (chrome.GetURL().StartsWith("https://m.facebook.com/si/actor_experience/actor_gateway"))
					{
						chrome.Click(4, "[data-sigil=\"touchable\"]");
						chrome.DelayTime(1.0);
					}
					if (chrome.CheckExistElement("button[value=\"OK\"]") == 1)
					{
						chrome.Click(4, "button[value=\"OK\"]");
						chrome.DelayTime(1.0);
					}
					if (chrome.CheckExistElement("[data-store-id=\"2\"]>span") == 1)
					{
						chrome.Click(4, "[data-store-id=\"2\"]>span");
						chrome.DelayTime(1.0);
					}
					if (chrome.CheckExistElement("[data-nt=\"FB:HEADER_FOOTER_VIEW\"]>div>div>div>span>span") == 1)
					{
						chrome.Click(4, "[data-nt=\"FB:HEADER_FOOTER_VIEW\"]>div>div>div>span>span");
						chrome.DelayTime(3.0);
					}
					break;
				case 1:
				{
					if (!chrome.GetURL().StartsWith("https://www.facebook.com/legal_consent"))
					{
						break;
					}
					for (int i = 0; i < 5; i++)
					{
						if (chrome.CheckExistElement("button") != 1)
						{
							break;
						}
						chrome.ExecuteScript("document.querySelector('button').click()");
						chrome.DelayTime(1.0);
					}
					break;
				}
				}
				CheckStatusAccount(chrome, isSendRequest: true);
				switch (chrome.Status)
				{
				case StatusChromeAccount.ChromeClosed:
					return -2;
				case StatusChromeAccount.LoginWithUserPass:
				case StatusChromeAccount.LoginWithSelectAccount:
					return 0;
				case StatusChromeAccount.Checkpoint:
					return 2;
				case StatusChromeAccount.Logined:
					return 1;
				case StatusChromeAccount.NoInternet:
					return -3;
				}
			}
			catch
			{
			}
			return 0;
		}

		public static bool IsCheckpoint(Chrome chrome)
		{
			try
			{
				if (chrome.CheckExistElements(0.0, "#checkpointSubmitButton", "#captcha_response", "[name=\"verification_method\"]", "#checkpointBottomBar", "[href =\"https://www.facebook.com/communitystandards/\"]") > 0)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		public static bool IsCheckpointWhenLogin(Chrome chrome)
		{
			try
			{
				if (chrome.CheckExistElements(0.0, "[name=\"captcha_response\"]", "#captcha_response", "[name=\"password_new\"]", "[name=\"verification_method\"]", "[href =\"https://www.facebook.com/communitystandards/\"]") > 0)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		public static string GetTokenEAAG(Chrome chrome)
		{
			string result = "";
			try
			{
				if (!chrome.GetURL().Contains("https://business.facebook.com/"))
				{
					chrome.GotoURL("https://business.facebook.com/");
				}
				result = (string)chrome.ExecuteScript("async function GetTokenEaag() { var output = ''; try { var response = await fetch('https://business.facebook.com/business_locations/'); if (response.ok) { var body = await response.text(); output=body.match(new RegExp('EAAG(.*?)\"'))[0].replace('\"',''); } } catch {} return output; }; var c = await GetTokenEaag(); return c;");
			}
			catch
			{
			}
			return result;
		}

		public static string RequestGet(Chrome chrome, string url, string website)
		{
			try
			{
				if (!chrome.GetURL().StartsWith(website))
				{
					chrome.GotoURL(website);
				}
				return (string)chrome.ExecuteScript("async function RequestGet() { var output = ''; try { var response = await fetch('" + url + "'); if (response.ok) { var body = await response.text(); return body; } } catch {} return output; }; var c = await RequestGet(); return c;");
			}
			catch
			{
			}
			return "";
		}

		public static string RequestPost(Chrome chrome, string url, string data, string website, string contentType = "application/x-www-form-urlencoded")
		{
			try
			{
				if (!chrome.GetURL().StartsWith(website))
				{
					chrome.GotoURL(website);
				}
				chrome.DelayTime(1.0);
				data = data.Replace("\n", "\\n").Replace("\"", "\\\"");
				return (string)chrome.ExecuteScript("async function RequestPost() { var output = ''; try { var response = await fetch('" + url + "', { method: 'POST', body: '" + data + "', headers: { 'Content-Type': '" + contentType + "' } }); if (response.ok) { var body = await response.text(); return body; } } catch {} return output; }; var c = await RequestPost(); return c;");
			}
			catch
			{
			}
			return "";
		}

		public static string GetBirthday(Chrome chrome, string token)
		{
			string result = "";
			try
			{
				if (!chrome.GetURL().Contains("https://graph.facebook.com/"))
				{
					chrome.GotoURL("https://graph.facebook.com/");
				}
				string json = (string)chrome.ExecuteScript("async function RequestGet() { var output = ''; try { var response = await fetch('https://graph.facebook.com/me?fields=id,birthday,name&access_token=" + token + "'); if (response.ok) { var body = await response.text(); return body; } } catch {} return output; }; var c = await RequestGet(); return c;");
				JObject jObject = JObject.Parse(json);
				return jObject["id"]!.ToString() + "|" + jObject["birthday"]!.ToString() + "|" + jObject["name"]!.ToString();
			}
			catch
			{
			}
			return result;
		}

		public static List<string> GetMyListUidMessage(Chrome chrome)
		{
			List<string> list = new List<string>();
			try
			{
				if (!chrome.GetURL().Contains("https://mbasic.facebook.com/"))
				{
					chrome.GotoURL("https://mbasic.facebook.com/");
				}
				string input = (string)chrome.ExecuteScript("async function GetListUidNameFriend() { var output = ''; try { var response = await fetch('https://mbasic.facebook.com/messages/'); if (response.ok) { var body = await response.text(); return body; } } catch {} return output; }; var c = await GetListUidNameFriend(); return c;");
				int num = 1;
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
							text2 = WebUtility.HtmlDecode(text2);
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
					input = (string)chrome.ExecuteScript("async function GetListUidNameFriend() { var output = ''; try { var response = await fetch('https://mbasic.facebook.com" + text + "'); if (response.ok) { var body = await response.text(); return body; } } catch {} return output; }; var c = await GetListUidNameFriend(); return c;");
					num++;
				}
				while (num < 5 && text != "");
			}
			catch
			{
			}
			return list;
		}

		public static List<string> GetMyListComments(Chrome chrome, int numberMonth)
		{
			List<string> list = new List<string>();
			try
			{
				if (!chrome.GetURL().Contains("https://mbasic.facebook.com/"))
				{
					chrome.GotoURL("https://mbasic.facebook.com/");
				}
				string format = "https://mbasic.facebook.com/{0}/allactivity/?category_key=commentscluster&timestart={1}&timeend={2}";
				string text = chrome.ExecuteScript("return (document.cookie + ';').match(new RegExp('c_user=(.*?);'))[1]").ToString();
				string text2 = "";
				string text3 = "";
				string text4 = "";
				string text5 = "";
				MatchCollection matchCollection = null;
				List<string> list2 = new List<string>();
				for (int i = 0; i < numberMonth; i++)
				{
					DateTime dateTime = DateTime.Now.AddMonths(2 - i);
					DateTime dateTime2 = DateTime.Now.AddMonths(1 - i);
					text2 = Common.ConvertDatetimeToTimestamp(new DateTime(dateTime.Year, dateTime.Month, 1)).ToString();
					text3 = Common.ConvertDatetimeToTimestamp(new DateTime(dateTime2.Year, dateTime2.Month, 1)).ToString();
					text4 = string.Format(format, text, text2, text3);
					list2.Add(text4);
				}
				for (int j = 0; j < list2.Count; j++)
				{
					text4 = list2[j];
					bool flag = false;
					do
					{
						flag = false;
						text5 = RequestGet(chrome, text4, "https://mbasic.facebook.com/");
						text5 = WebUtility.HtmlDecode(text5);
						matchCollection = Regex.Matches(text5, "<span>(.*?)</h4>");
						for (int k = 0; k < matchCollection.Count; k++)
						{
							string value = matchCollection[k].Groups[1].Value;
							value = value.Substring(0, value.LastIndexOf('<'));
							MatchCollection matchCollection2 = Regex.Matches(value, "<(.*?)>");
							for (int l = 0; l < matchCollection2.Count; l++)
							{
								value = value.Replace(matchCollection2[l].Value, "");
							}
							if (value != "" && !list.Contains(value))
							{
								list.Add(value);
							}
						}
						if (Regex.IsMatch(text5, "/" + text + "/allactivity/\\?category_key=commentscluster&timeend(.*?)\""))
						{
							text4 = "https://mbasic.facebook.com" + Regex.Match(text5, "/" + text + "/allactivity/\\?category_key=commentscluster&timeend(.*?)\"").Value.Replace("\"", "");
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

		public static List<string> GetMyListUidNameFriend(Chrome chrome, string token)
		{
			List<string> list = new List<string>();
			try
			{
				if (!chrome.GetURL().Contains("https://graph.facebook.com/"))
				{
					chrome.GotoURL("https://graph.facebook.com/");
				}
				string json = (string)chrome.ExecuteScript("async function GetListUidNameFriend() { var output = ''; try { var response = await fetch('https://graph.facebook.com/me/friends?limit=5000&fields=id,name&access_token=" + token + "'); if (response.ok) { var body = await response.text(); return body; } } catch {} return output; }; var c = await GetListUidNameFriend(); return c;");
				JObject jObject = JObject.Parse(json);
				if (jObject["data"].Count() > 0)
				{
					for (int i = 0; i < jObject["data"].Count(); i++)
					{
						string text = jObject["data"]![i]!["id"]!.ToString();
						string text2 = jObject["data"]![i]!["name"]!.ToString();
						list.Add(text + "|" + text2);
					}
				}
			}
			catch
			{
			}
			return list;
		}

		internal static void CheckStatusAccount(Chrome chrome, bool isSendRequest)
		{
			try
			{
				if (chrome.CheckChromeClosed())
				{
					chrome.Status = StatusChromeAccount.ChromeClosed;
					return;
				}
				string text = "";
				if (isSendRequest)
				{
					text = RequestGet(chrome, "https://m.facebook.com/login", "https://m.facebook.com/");
				}
				if (text == "")
				{
					text = chrome.GetPageSource();
				}
				if (text == null || text == "" || text == "-2")
				{
					chrome.Status = StatusChromeAccount.ChromeClosed;
					return;
				}
				if (text.Contains("error-information-popup-content") || text.Contains("suggestionsSummaryList"))
				{
					chrome.Status = StatusChromeAccount.NoInternet;
					return;
				}
				if (Regex.IsMatch(text, "login_form"))
				{
					chrome.Status = StatusChromeAccount.LoginWithUserPass;
					return;
				}
				if (Regex.IsMatch(text, "login_profile_form") || Regex.IsMatch(text, "/login/device-based/validate-pin"))
				{
					chrome.Status = StatusChromeAccount.LoginWithSelectAccount;
					return;
				}
				if (Convert.ToBoolean(chrome.ExecuteScript("var kq=false;if(document.querySelector('#mErrorView')!=null && !document.querySelector('#mErrorView').getAttribute('style').includes('display:none')) kq=true;return kq+''")) || Regex.IsMatch(text, "href=\"https://m.facebook.com/login.php"))
				{
					chrome.Status = StatusChromeAccount.LoginWithSelectAccount;
					return;
				}
				string uRL = chrome.GetURL();
				if (uRL.Contains("facebook.com/checkpoint/") || uRL.Contains("facebook.com/nt/screen/?params=%7B%22token") || uRL.Contains("facebook.com/x/checkpoint/") || CheckStringContainKeyword(text, new List<string> { "verification_method", "checkpointBottomBar", "submit[Yes]", "password_new", "send_code", "/checkpoint/dyi", "captcha_response", "https://www.facebook.com/communitystandards/", "help/121104481304395" }))
				{
					chrome.Status = StatusChromeAccount.Checkpoint;
				}
				else if (Regex.IsMatch(text, "/friends/") || chrome.CheckExistElement("a[href*='/friends/']") == 1 || uRL == "https://m.facebook.com/home.php?ref=wizard&_rdr")
				{
					chrome.Status = StatusChromeAccount.Logined;
				}
			}
			catch
			{
			}
		}

		private static bool CheckStringContainKeyword(string content, List<string> lstKerword)
		{
			int num = 0;
			while (true)
			{
				if (num < lstKerword.Count)
				{
					if (Regex.IsMatch(content, lstKerword[num]))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		public static List<string> BackupImageOne(Chrome chrome, string uidFr, string nameFr, string token, int countImage = 20)
		{
			List<string> list = new List<string>();
			try
			{
				if (!chrome.GetURL().Contains("https://graph.facebook.com/"))
				{
					chrome.GotoURL("https://graph.facebook.com/");
				}
				string text = (string)chrome.ExecuteScript("async function GetListUidNameFriend() { var output = ''; try { var response = await fetch('https://graph.facebook.com/" + uidFr + "/photos?fields=images&limit=" + countImage + "&access_token=" + token + "'); if (response.ok) { var body = await response.text(); return body; } } catch {} return output; }; var c = await GetListUidNameFriend(); return c;");
				JObject jObject = JObject.Parse(text);
				int num = 0;
				if (jObject != null && text.Contains("images"))
				{
					for (int i = 0; i < jObject["data"].Count(); i++)
					{
						num = jObject["data"]![i]!["images"].ToList().Count - 1;
						list.Add(uidFr + "*" + nameFr + "*" + jObject["data"]![i]!["images"]![num]!["source"]?.ToString() + "|" + jObject["data"]![i]!["images"]![num]!["width"]?.ToString() + "|" + jObject["data"]![i]!["images"]![num]!["height"]);
					}
				}
			}
			catch
			{
			}
			return list;
		}

		public static List<string> GetMyListUidFriend(Chrome chrome)
		{
			List<string> list = new List<string>();
			try
			{
				string tokenEAAAAZ = GetTokenEAAAAZ(chrome);
				if (!chrome.GetURL().Contains("https://graph.facebook.com/"))
				{
					chrome.GotoURL("https://graph.facebook.com/");
				}
				string json = (string)chrome.ExecuteScript("async function GetListUidNameFriend() { var output = ''; try { var response = await fetch('https://graph.facebook.com/me/friends?limit=5000&fields=id&access_token=" + tokenEAAAAZ + "'); if (response.ok) { var body = await response.text(); return body; } } catch {} return output; }; var c = await GetListUidNameFriend(); return c;");
				JObject jObject = JObject.Parse(json);
				if (jObject["data"].Count() > 0)
				{
					for (int i = 0; i < jObject["data"].Count(); i++)
					{
						string item = jObject["data"]![i]!["id"]!.ToString();
						list.Add(item);
					}
				}
			}
			catch
			{
			}
			return list;
		}

		public static bool SkipNotifyWhenAddFriend(Chrome chrome)
		{
			bool result = true;
			string text = "";
			switch (chrome.CheckExistElements(2.0, "[data-sigil=\" m-overlay-layer\"] button", "[data-sigil=\" m-overlay-layer\"] [value=\"OK\"]", "[data-sigil=\"touchable m-error-overlay-done\"]", "[data-sigil=\"touchable m-overlay-layer\"]", "[data-sigil=\"touchable m-error-overlay-cancel\"]"))
			{
			case 0:
				result = false;
				break;
			case 1:
				text = "[data-sigil=\" m-overlay-layer\"] button";
				break;
			case 2:
				text = "[data-sigil=\" m-overlay-layer\"] [value=\"OK\"]";
				break;
			case 3:
				text = "[data-sigil=\"touchable m-error-overlay-done\"]";
				break;
			case 4:
				text = "[data-sigil=\"touchable m-overlay-layer\"]";
				break;
			case 5:
				text = "[data-sigil=\"touchable m-error-overlay-cancel\"]";
				break;
			}
			if (text != "")
			{
				chrome.ExecuteScript("document.querySelector('" + text + "').click();");
			}
			return result;
		}

		public static string GetFbDtag(Chrome chrome)
		{
			try
			{
				string input = RequestGet(chrome, "https://m.facebook.com/help/", "https://m.facebook.com");
				return Regex.Match(input, Common.Base64Decode("ImR0c2dfYWciOnsidG9rZW4iOiIoLio/KSI=")).Groups[1].Value;
			}
			catch
			{
				return "";
			}
		}

		public static List<string> GetListGroup(Chrome chrome)
		{
			List<string> list = new List<string>();
			try
			{
				string fbDtag = GetFbDtag(chrome);
				string value = Regex.Match(chrome.GetCookieFromChrome(), "c_user=(.*?);").Groups[1].Value;
				string url = "https://www.facebook.com/ajax/typeahead/first_degree.php?fb_dtsg_ag=" + fbDtag + "&filter%5B0%5D=group&viewer=" + value + "&__user=" + value + "&__a=1&__dyn=&__comet_req=0&jazoest=26581";
				string json = RequestGet(chrome, url, "https://www.facebook.com/ajax/typeahead/first_degree.php").Replace("for (;;);", "");
				JObject jObject = JObject.Parse(json);
				foreach (JToken item in (IEnumerable<JToken>)(jObject["payload"]!["entries"]!))
				{
					try
					{
						list.Add(string.Format("{0}|{1}|{2}", item["uid"], item["text"], item["size"]));
					}
					catch
					{
					}
				}
			}
			catch (Exception)
			{
			}
			return list;
		}

		public static List<string> GetListPage(Chrome chrome)
		{
			List<string> list = new List<string>();
			try
			{
				string text = "";
				string tokenEAAAAZ = GetTokenEAAAAZ(chrome);
				text = RequestGet(chrome, "https://graph.facebook.com/v3.0/me/accounts?access_token=" + tokenEAAAAZ + "&limit=5000&fields=id,name,like,country_page_likes", "https://graph.facebook.com").ToString();
				JObject jObject = JObject.Parse(text);
				foreach (JToken item in (IEnumerable<JToken>)(jObject["data"]!))
				{
					list.Add(item["id"]!.ToString());
				}
			}
			catch
			{
			}
			return list;
		}
	}
}
