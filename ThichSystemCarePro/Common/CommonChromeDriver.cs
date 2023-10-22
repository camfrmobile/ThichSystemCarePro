using System;
using System.Drawing;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace Common
{
	public class CommonChromeDriver
	{
		public static ChromeDriver OpenChrome(ChromeDriver chrome, bool isHideChrome, bool isHideImage, bool isDisableSound, string UserAgent, string LinkProfile, Point Size, Point Position, string Proxy, int TimeWaitForSearchingElement = 0, int TimeWaitForLoadingPage = 60)
		{
			ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
			chromeDriverService.HideCommandPromptWindow = true;
			ChromeOptions chromeOptions = new ChromeOptions();
			chromeOptions.AddArguments("--disable-notifications", "--window-size=" + Size.X + "," + Size.Y, "--window-position=" + Position.X + "," + Position.Y, "--no-sandbox", "--disable-gpu", "--disable-dev-shm-usage", "--disable-web-security", "--disable-rtc-smoothness-algorithm", "--disable-webrtc-hw-decoding", "--disable-webrtc-hw-encoding", "--disable-webrtc-multiple-routes", "--disable-webrtc-hw-vp8-encoding", "--enforce-webrtc-ip-permission-check", "--force-webrtc-ip-handling-policy", "--ignore-certificate-errors", "--disable-infobars", "--disable-popup-blocking");
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.notifications", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.plugins", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.popups", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.auto_select_certificate", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.mixed_script", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.media_stream", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.media_stream_mic", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.media_stream_camera", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.protocol_handlers", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.midi_sysex", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.push_messaging", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.ssl_cert_decisions", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.metro_switch_to_desktop", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.protected_media_identifier", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.site_engagement", 1);
			chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.durable_storage", 1);
			chromeOptions.AddUserProfilePreference("useAutomationExtension", true);
			if (isDisableSound)
			{
				chromeOptions.AddArgument("--mute-audio");
			}
			if (!isHideChrome)
			{
				if (isHideImage)
				{
					chromeOptions.AddArgument("--blink-settings=imagesEnabled=false");
				}
				if (!string.IsNullOrEmpty(LinkProfile.Trim()))
				{
					chromeOptions.AddArgument("--user-data-dir=" + LinkProfile);
				}
			}
			else
			{
				chromeOptions.AddArgument("--blink-settings=imagesEnabled=false");
				chromeOptions.AddArgument("--headless");
			}
			if (!string.IsNullOrEmpty(Proxy.Trim()))
			{
				chromeOptions.AddArgument("--proxy-server= 127.0.0.1:" + Proxy);
			}
			if (!string.IsNullOrEmpty(UserAgent.Trim()))
			{
				chromeOptions.AddArgument("--user-agent=" + UserAgent);
			}
			chrome = new ChromeDriver(chromeDriverService, chromeOptions);
			chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TimeWaitForSearchingElement);
			chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(TimeWaitForLoadingPage);
			return chrome;
		}

		public static void QuitChrome(ChromeDriver chrome)
		{
			try
			{
				chrome.Quit();
			}
			catch
			{
			}
		}

		public static bool CheckChromeClosed(ChromeDriver chrome)
		{
			bool result = true;
			try
			{
				_ = chrome.Title;
				result = false;
				return result;
			}
			catch
			{
				return result;
			}
		}

		public static bool CheckExistElement(ChromeDriver chrome, int typeAttribute, string attributeValue, int timeOut = 0)
		{
			bool flag = false;
			TimeSpan implicitWait = chrome.Manage().Timeouts().ImplicitWait;
			chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(0.0);
			int tickCount = Environment.TickCount;
			do
			{
				switch (typeAttribute)
				{
				case 3:
					flag = chrome.FindElementsByXPath(attributeValue).Count > 0;
					break;
				case 2:
					flag = chrome.FindElementsByName(attributeValue).Count > 0;
					break;
				case 1:
					flag = chrome.FindElementsById(attributeValue).Count > 0;
					break;
				}
			}
			while (!flag && Environment.TickCount - tickCount <= timeOut * 1000);
			chrome.Manage().Timeouts().ImplicitWait = implicitWait;
			return flag;
		}

		public static bool NavigateChrome(ChromeDriver chrome, string url)
		{
			bool result = false;
			try
			{
				chrome.Navigate().GoToUrl(url);
				result = true;
				return result;
			}
			catch
			{
				return result;
			}
		}

		public static bool ScrollChrome(ChromeDriver chrome, int x, int y)
		{
			bool result = false;
			try
			{
				string script = $"window.scrollTo({x}, {y})";
				chrome.ExecuteScript(script);
				result = true;
				return result;
			}
			catch
			{
				return result;
			}
		}

		public static bool SendKeysChrome(ChromeDriver chrome, int typeAttribute, string attributeValue, string content, double timeDelay)
		{
			bool result = false;
			try
			{
				for (int i = 0; i < content.Length; i++)
				{
					switch (typeAttribute)
					{
					case 1:
						chrome.FindElementById(attributeValue).SendKeys(content[i].ToString());
						break;
					case 2:
						chrome.FindElementByName(attributeValue).SendKeys(content[i].ToString());
						break;
					case 3:
						chrome.FindElementByXPath(attributeValue).SendKeys(content[i].ToString());
						break;
					}
					if (i < content.Length - 1)
					{
						Thread.Sleep(Convert.ToInt32(timeDelay * 1000.0));
					}
				}
				result = true;
				return result;
			}
			catch
			{
				return result;
			}
		}

		public static bool SendKeysChrome(ChromeDriver chrome, int typeAttribute, string attributeValue, string content)
		{
			bool result = false;
			try
			{
				switch (typeAttribute)
				{
				case 1:
					chrome.FindElementById(attributeValue).SendKeys(content);
					break;
				case 2:
					chrome.FindElementByName(attributeValue).SendKeys(content);
					break;
				case 3:
					chrome.FindElementByXPath(attributeValue).SendKeys(content);
					break;
				}
				result = true;
				return result;
			}
			catch
			{
				return result;
			}
		}

		public static bool ClickChrome(ChromeDriver chrome, int typeAttribute, string attributeValue)
		{
			bool result = false;
			try
			{
				switch (typeAttribute)
				{
				case 1:
					chrome.FindElementById(attributeValue).Click();
					break;
				case 2:
					chrome.FindElementByName(attributeValue).Click();
					break;
				case 3:
					chrome.FindElementByXPath(attributeValue).Click();
					break;
				}
				result = true;
				return result;
			}
			catch
			{
				return result;
			}
		}

		public static bool ExecuteScriptChrome(ChromeDriver chrome, string script)
		{
			bool result = false;
			try
			{
				chrome.ExecuteScript(script);
				result = true;
				return result;
			}
			catch
			{
				return result;
			}
		}
	}
}
