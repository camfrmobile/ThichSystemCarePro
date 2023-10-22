using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace MCommon
{
	public class Firefox
	{
		private FirefoxDriver firefox;

		public bool isAlive = false;

		public bool HideBrowser { get; set; }

		public bool DisableImage { get; set; }

		public bool DisableSound { get; set; }

		public bool AutoPlayVideo { get; set; }

		public string UserAgent { get; set; }

		public string ProfilePath { get; set; }

		public Point Size { get; set; }

		public int Size_Heigh { get; set; }

		public int Size_Width { get; set; }

		public Point Position { get; set; }

		public int Position_X { get; set; }

		public int Position_Y { get; set; }

		public int TimeWaitForSearchingElement { get; set; }

		public int TimeWaitForLoadingPage { get; set; }

		public string Proxy { get; set; }

		public int TypeProxy { get; set; }

		public string App { get; set; }

		public string LinkToOtherBrowser { get; set; }

		public string PathExtension { get; set; }

		public Firefox()
		{
			DisableImage = true;
			DisableSound = false;
			UserAgent = "";
			ProfilePath = "";
			Size_Heigh = 300;
			Size_Width = 300;
			Size = new Point(Size_Width, Size_Heigh);
			Position_X = 300;
			Position_Y = 0;
			Proxy = "";
			TypeProxy = 0;
			Position = new Point(Position_X, Position_Y);
			TimeWaitForSearchingElement = 0;
			TimeWaitForLoadingPage = 5;
			App = "";
			AutoPlayVideo = false;
			LinkToOtherBrowser = "";
			PathExtension = "data\\extension";
		}

		public bool Open()
		{
			bool result = false;
			isAlive = true;
			try
			{
				FirefoxDriverService firefoxDriverService = FirefoxDriverService.CreateDefaultService();
				firefoxDriverService.HideCommandPromptWindow = true;
				FirefoxOptions firefoxOptions = new FirefoxOptions();
				firefoxOptions.SetPreference("security.notification_enable_delay", 0);
				firefoxOptions.SetPreference("dom.webnotifications.enabled", preferenceValue: false);
				firefoxOptions.SetPreference("permissions.default.image", DisableImage ? 1 : 0);
				firefoxOptions.SetPreference("browser.download.folderList", 2);
				firefoxOptions.SetPreference("browser.download.manager.alertOnEXEOpen", preferenceValue: false);
				firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/msword, application/csv, application/ris, text/csv, image/png, application/pdf, text/html, text/plain, application/zip, application/x-zip, application/x-zip-compressed, application/download, application/octet-stream");
				firefoxOptions.SetPreference("browser.download.manager.showWhenStarting", preferenceValue: false);
				firefoxOptions.SetPreference("browser.download.manager.focusWhenStarting", preferenceValue: false);
				firefoxOptions.SetPreference("browser.download.useDownloadDir", preferenceValue: true);
				firefoxOptions.SetPreference("browser.helperApps.alwaysAsk.force", preferenceValue: false);
				firefoxOptions.SetPreference("browser.download.manager.alertOnEXEOpen", preferenceValue: false);
				firefoxOptions.SetPreference("browser.download.manager.closeWhenDone", preferenceValue: true);
				firefoxOptions.SetPreference("browser.download.manager.showAlertOnComplete", preferenceValue: false);
				firefoxOptions.SetPreference("browser.download.manager.useWindow", preferenceValue: false);
				firefoxOptions.SetPreference("services.sync.prefs.sync.browser.download.manager.showWhenStarting", preferenceValue: false);
				firefoxOptions.SetPreference("pdfjs.disabled", preferenceValue: true);
				firefoxOptions.AddArguments("-width=" + Size.X, "-height=" + Size.Y);
				if (UserAgent != "")
				{
					firefoxOptions.SetPreference("general.useragent.override", UserAgent);
				}
				else
				{
					firefoxOptions.SetPreference("general.useragent.override", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:82.0) Gecko/20100101 Firefox/82.0");
				}
				new FirefoxProfileManager();
				firefox = new FirefoxDriver(firefoxDriverService, firefoxOptions);
				firefox.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(TimeWaitForLoadingPage);
				firefox.Manage().Window.Position = Position;
				result = true;
				return result;
			}
			catch (Exception ex)
			{
				ExportError(null, ex, "firefox.Open()");
				return result;
			}
		}

		public static string SetPositionAndSizeFireFox(FirefoxOptions option, int i)
		{
			int num = 0;
			int num2 = 0;
			int width = Screen.PrimaryScreen.Bounds.Width;
			int height = Screen.PrimaryScreen.Bounds.Height;
			int num3 = width / 3;
			int num4 = height / 2;
			if (i < 3)
			{
				num = num3 * i;
				num2 = 0;
			}
			else
			{
				num = num3 * (i % 3);
				int num5 = i / 2;
				num2 = ((num5 % 2 != 0) ? num4 : 0);
			}
			option.AddArgument($"--width={num3}");
			option.AddArgument($"--height={num4}");
			return num + "|" + num2;
		}

		public string GetCssSelector(string querySelector, string attributeName, string attributeValue)
		{
			string result = "";
			if (isAlive)
			{
				try
				{
					result = firefox.ExecuteScript("function GetSelector(el){let path=[],parent;while(parent=el.parentNode){path.unshift(`${el.tagName}:nth-child(${[].indexOf.call(parent.children, el)+1})`);el=parent}return `${path.join('>')}`.toLowerCase()}; function GetCssSelector(selector, attribute, value){var c = document.querySelectorAll(selector); for (i = 0; i < c.length; i++) { if (c[i].getAttribute(attribute)!=null && c[i].getAttribute(attribute).includes(value)) { return GetSelector(c[i])} }; return '';}; return GetCssSelector('" + querySelector + "','" + attributeName + "','" + attributeValue + "')").ToString();
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "firefox.GetCssSelector(" + querySelector + "," + attributeName + "," + attributeValue + ")");
				}
			}
			return result;
		}

		public string GetAttributeValue(string querySelector, string attributeName)
		{
			string result = "";
			if (isAlive)
			{
				try
				{
					result = firefox.ExecuteScript("return document.querySelector('" + querySelector + "').getAttribute('" + attributeName + "')").ToString();
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "firefox.GetAttributeValue(" + querySelector + "," + attributeName + ")");
				}
			}
			return result;
		}

		public void ScrollSmooth(int distance)
		{
			if (isAlive)
			{
				try
				{
					firefox.ExecuteScript("window.scrollBy({ top: " + distance + ",behavior: 'smooth'});");
				}
				catch (Exception ex)
				{
					ExportError(null, ex, $"chrome.ScrollSmooth({distance})");
				}
			}
		}

		public string GetUseragent()
		{
			string result = "";
			try
			{
				result = firefox.ExecuteScript("return navigator.userAgent").ToString();
			}
			catch
			{
			}
			return result;
		}

		public bool SendKeyDown(int typeAttribute, string attributeValue)
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					switch (typeAttribute)
					{
					case 1:
						firefox.FindElementById(attributeValue).SendKeys(OpenQA.Selenium.Keys.ArrowDown);
						break;
					case 2:
						firefox.FindElementByName(attributeValue).SendKeys(OpenQA.Selenium.Keys.ArrowDown);
						break;
					case 3:
						firefox.FindElementByXPath(attributeValue).SendKeys(OpenQA.Selenium.Keys.ArrowDown);
						break;
					case 4:
						firefox.FindElementByCssSelector(attributeValue).SendKeys(OpenQA.Selenium.Keys.ArrowDown);
						break;
					}
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, $"firefox.SendKeyDown({typeAttribute},{attributeValue})");
					return result;
				}
			}
			return result;
		}

		public string GetURL()
		{
			if (isAlive)
			{
				try
				{
					return firefox.Url;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "firefox.GetURL()");
				}
			}
			return "";
		}

		public bool GotoURL(string url)
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					firefox.Navigate().GoToUrl(url);
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "firefox.GotoURL(" + url + ")");
					return result;
				}
			}
			return result;
		}

		public bool Refresh()
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					firefox.Navigate().Refresh();
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "firefox.Refresh()");
					return result;
				}
			}
			return result;
		}

		public bool GotoBackPage()
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					firefox.Navigate().Back();
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "firefox.GotoBackPage()");
					return result;
				}
			}
			return result;
		}

		public bool HoverElement(int typeAttribute, string attributeValue, double timeHover_second)
		{
			if (isAlive)
			{
				try
				{
					switch (typeAttribute)
					{
					case 1:
						new Actions(firefox).MoveToElement(firefox.FindElement(By.Id(attributeValue))).Perform();
						break;
					case 2:
						new Actions(firefox).MoveToElement(firefox.FindElement(By.Name(attributeValue))).Perform();
						break;
					case 3:
						new Actions(firefox).MoveToElement(firefox.FindElement(By.XPath(attributeValue))).Perform();
						break;
					case 4:
						new Actions(firefox).MoveToElement(firefox.FindElement(By.CssSelector(attributeValue))).Perform();
						break;
					}
					Thread.Sleep(Convert.ToInt32(timeHover_second * 1000.0));
					return true;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, $"firefox.HoverElement({typeAttribute}, {attributeValue}, {timeHover_second})");
				}
			}
			return false;
		}

		public bool Click(int typeAttribute, string attributeValue, int index = 0, int subTypeAttribute = 0, string subAttributeValue = "", int subIndex = 0)
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					if (subTypeAttribute == 0)
					{
						switch (typeAttribute)
						{
						case 1:
							firefox.FindElementsById(attributeValue)[index].Click();
							break;
						case 2:
							firefox.FindElementsByName(attributeValue)[index].Click();
							break;
						case 3:
							firefox.FindElementsByXPath(attributeValue)[index].Click();
							break;
						case 4:
							firefox.FindElementsByCssSelector(attributeValue)[index].Click();
							break;
						}
					}
					else
					{
						switch (typeAttribute)
						{
						case 1:
							firefox.FindElementsById(attributeValue)[index].FindElements(By.Id(subAttributeValue))[subIndex].Click();
							break;
						case 2:
							firefox.FindElementsByName(attributeValue)[index].FindElements(By.Name(subAttributeValue))[subIndex].Click();
							break;
						case 3:
							firefox.FindElementsByXPath(attributeValue)[index].FindElements(By.XPath(subAttributeValue))[subIndex].Click();
							break;
						case 4:
							firefox.FindElementsByCssSelector(attributeValue)[index].FindElements(By.CssSelector(subAttributeValue))[subIndex].Click();
							break;
						}
					}
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, $"firefox.Click({typeAttribute},{attributeValue})");
					return result;
				}
			}
			return result;
		}

		public bool ClickWithAction(int typeAttribute, string attributeValue, int index = 0, int subTypeAttribute = 0, string subAttributeValue = "", int subIndex = 0)
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					if (subTypeAttribute != 0)
					{
						switch (typeAttribute)
						{
						case 1:
							new Actions(firefox).Click(firefox.FindElementsById(attributeValue)[index].FindElements(By.Id(subAttributeValue))[subIndex]).Perform();
							break;
						case 2:
							new Actions(firefox).Click(firefox.FindElementsByName(attributeValue)[index].FindElements(By.Name(subAttributeValue))[subIndex]).Perform();
							break;
						case 3:
							new Actions(firefox).Click(firefox.FindElementsByXPath(attributeValue)[index].FindElements(By.XPath(subAttributeValue))[subIndex]).Perform();
							break;
						case 4:
							new Actions(firefox).Click(firefox.FindElementsByCssSelector(attributeValue)[index].FindElements(By.CssSelector(subAttributeValue))[subIndex]).Perform();
							break;
						}
					}
					else
					{
						switch (typeAttribute)
						{
						case 1:
							new Actions(firefox).Click(firefox.FindElementsById(attributeValue)[index]).Perform();
							break;
						case 2:
							new Actions(firefox).Click(firefox.FindElementsByName(attributeValue)[index]).Perform();
							break;
						case 3:
							new Actions(firefox).Click(firefox.FindElementsByXPath(attributeValue)[index]).Perform();
							break;
						case 4:
							new Actions(firefox).Click(firefox.FindElementsByCssSelector(attributeValue)[index]).Perform();
							break;
						}
					}
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, $"firefox.ClickWithAction({typeAttribute},{attributeValue})");
					return result;
				}
			}
			return result;
		}

		public bool SendKeys(int typeAttribute, string attributeValue, string content, bool isClick = true)
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					if (isClick)
					{
						Click(typeAttribute, attributeValue);
					}
					switch (typeAttribute)
					{
					case 1:
						firefox.FindElementById(attributeValue).SendKeys(content);
						break;
					case 2:
						firefox.FindElementByName(attributeValue).SendKeys(content);
						break;
					case 3:
						firefox.FindElementByXPath(attributeValue).SendKeys(content);
						break;
					case 4:
						firefox.FindElementByCssSelector(attributeValue).SendKeys(content);
						break;
					}
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, $"firefox.SendKeys({typeAttribute},{attributeValue},{content},{isClick})");
					return result;
				}
			}
			return result;
		}

		public bool SendKeys(int typeAttribute, string attributeValue, string content, double timeDelay_Second, bool isClick = true)
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					if (isClick)
					{
						Click(typeAttribute, attributeValue);
					}
					for (int i = 0; i < content.Length; i++)
					{
						switch (typeAttribute)
						{
						case 1:
							firefox.FindElementById(attributeValue).SendKeys(content[i].ToString());
							break;
						case 2:
							firefox.FindElementByName(attributeValue).SendKeys(content[i].ToString());
							break;
						case 3:
							firefox.FindElementByXPath(attributeValue).SendKeys(content[i].ToString());
							break;
						case 4:
							firefox.FindElementByCssSelector(attributeValue).SendKeys(content[i].ToString());
							break;
						}
						Thread.Sleep(Convert.ToInt32(timeDelay_Second * 1000.0));
					}
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, $"firefox.SendKeys({typeAttribute},{attributeValue},{content},{timeDelay_Second},{isClick})");
					return result;
				}
			}
			return result;
		}

		public bool SelectText(int typeAttribute, string attributeValue)
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					switch (typeAttribute)
					{
					case 1:
						firefox.FindElementById(attributeValue).SendKeys(OpenQA.Selenium.Keys.Control + "a");
						break;
					case 2:
						firefox.FindElementByName(attributeValue).SendKeys(OpenQA.Selenium.Keys.Control + "a");
						break;
					case 3:
						firefox.FindElementByXPath(attributeValue).SendKeys(OpenQA.Selenium.Keys.Control + "a");
						break;
					case 4:
						firefox.FindElementByCssSelector(attributeValue).SendKeys(OpenQA.Selenium.Keys.Control + "a");
						break;
					}
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, $"firefox.SelectText({typeAttribute},{attributeValue})");
					return result;
				}
			}
			return result;
		}

		public bool ClearText(int typeAttribute, string attributeValue)
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					switch (typeAttribute)
					{
					case 1:
						firefox.FindElementById(attributeValue).Clear();
						break;
					case 2:
						firefox.FindElementByName(attributeValue).Clear();
						break;
					case 3:
						firefox.FindElementByXPath(attributeValue).Clear();
						break;
					case 4:
						firefox.FindElementByCssSelector(attributeValue).Clear();
						break;
					}
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, $"firefox.ClearText({typeAttribute},{attributeValue})");
					return result;
				}
			}
			return result;
		}

		public bool CheckExistElement(string querySelector, double timeWait_Second = 0.0)
		{
			bool result = true;
			if (isAlive)
			{
				try
				{
					int tickCount = Environment.TickCount;
					while ((string)firefox.ExecuteScript("return document.querySelectorAll('" + querySelector + "').length+''") == "0")
					{
						if ((double)(Environment.TickCount - tickCount) > timeWait_Second * 1000.0)
						{
							return false;
						}
						Thread.Sleep(1000);
					}
					return result;
				}
				catch (Exception ex)
				{
					result = false;
					ExportError(null, ex, $"firefox.CheckExistElement({querySelector},{timeWait_Second})");
					return result;
				}
			}
			return result;
		}

		public bool CheckExistElementv2(string JSPath, double timeWait_Second = 0.0)
		{
			bool result = true;
			if (isAlive)
			{
				try
				{
					int tickCount = Environment.TickCount;
					while ((string)firefox.ExecuteScript("return " + JSPath + ".length+''") == "0")
					{
						if ((double)(Environment.TickCount - tickCount) > timeWait_Second * 1000.0)
						{
							return false;
						}
						Thread.Sleep(1000);
					}
					return result;
				}
				catch (Exception ex)
				{
					result = false;
					ExportError(null, ex, $"firefox.CheckExistElement({JSPath},{timeWait_Second})");
					return result;
				}
			}
			return result;
		}

		public bool CheckChromeClosed()
		{
			bool result = true;
			if (isAlive)
			{
				try
				{
					_ = firefox.Title;
					result = false;
					return result;
				}
				catch (Exception ex)
				{
					isAlive = false;
					ExportError(null, ex, "firefox.CheckChromeClosed()");
					return result;
				}
			}
			return result;
		}

		public bool WaitForSearchElement(string querySelector, int typeSearch = 0, double timeWait_Second = 0.0)
		{
			bool result = true;
			if (isAlive)
			{
				try
				{
					int tickCount = Environment.TickCount;
					if (typeSearch != 0)
					{
						while ((string)firefox.ExecuteScript("return document.querySelectorAll('" + querySelector + "').length+''") != "0")
						{
							if ((double)(Environment.TickCount - tickCount) > timeWait_Second * 1000.0)
							{
								return false;
							}
							Thread.Sleep(1000);
						}
						return result;
					}
					while ((string)firefox.ExecuteScript("return document.querySelectorAll('" + querySelector + "').length+''") == "0")
					{
						if ((double)(Environment.TickCount - tickCount) > timeWait_Second * 1000.0)
						{
							return false;
						}
						Thread.Sleep(1000);
					}
					return result;
				}
				catch (Exception ex)
				{
					result = false;
					ExportError(null, ex, $"firefox.WaitForSearchElement({querySelector},{typeSearch},{timeWait_Second})");
					return result;
				}
			}
			return result;
		}

		public int CheckExistElements(double timeWait_Second = 0.0, params string[] querySelectors)
		{
			int result = 0;
			if (isAlive)
			{
				try
				{
					int tickCount = Environment.TickCount;
					while (true)
					{
						for (int i = 0; i < querySelectors.Length; i++)
						{
							if (CheckExistElement(querySelectors[i]))
							{
								return i + 1;
							}
						}
						if (!((double)(Environment.TickCount - tickCount) > timeWait_Second * 1000.0))
						{
							Thread.Sleep(1000);
							continue;
						}
						break;
					}
				}
				catch (Exception ex)
				{
					ExportError(null, ex, string.Format("firefox.CheckExistElements({0},{1})", timeWait_Second, string.Join("|", querySelectors)));
				}
			}
			return result;
		}

		public bool SendEnter(int typeAttribute, string attributeValue)
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					switch (typeAttribute)
					{
					case 1:
						firefox.FindElementById(attributeValue).SendKeys(OpenQA.Selenium.Keys.Enter);
						break;
					case 2:
						firefox.FindElementByName(attributeValue).SendKeys(OpenQA.Selenium.Keys.Enter);
						break;
					case 3:
						firefox.FindElementByXPath(attributeValue).SendKeys(OpenQA.Selenium.Keys.Enter);
						break;
					case 4:
						firefox.FindElementByCssSelector(attributeValue).SendKeys(OpenQA.Selenium.Keys.Enter);
						break;
					}
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, $"firefox.SendEnter({typeAttribute},{attributeValue})");
					return result;
				}
			}
			return result;
		}

		public bool Scroll(int x, int y)
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					string script = $"window.scrollTo({x}, {y})";
					firefox.ExecuteScript(script);
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, $"firefox.Scroll({x},{y})");
					return result;
				}
			}
			return result;
		}

		public void ScrollSmooth(string JSpath)
		{
			if (isAlive)
			{
				try
				{
					firefox.ExecuteScript(JSpath + ".scrollIntoView({ behavior: 'smooth', block: 'center'});");
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "firefox.ScrollSmooth(" + JSpath + ")");
				}
			}
		}

		public int CheckExistElementOnScreen(string JSpath)
		{
			int result = -2;
			if (isAlive)
			{
				try
				{
					result = Convert.ToInt32(firefox.ExecuteScript("var check='';x=" + JSpath + ";if(x.getBoundingClientRect().top<=0) check='-1'; else if(x.getBoundingClientRect().top+x.getBoundingClientRect().height>window.innerHeight) check='1'; else check='0'; return check;"));
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "firefox.CheckExistElementOnScreen(" + JSpath + ")");
				}
			}
			return result;
		}

		public Point GetSizeChrome()
		{
			Point result = new Point(0, 0);
			if (isAlive)
			{
				try
				{
					string text = firefox.ExecuteScript("return window.innerHeight+'|'+window.innerWidth").ToString();
					result.X = Convert.ToInt32(text.Split('|')[1]);
					result.Y = Convert.ToInt32(text.Split('|')[0]);
				}
				catch
				{
				}
			}
			return result;
		}

		public void Close()
		{
			try
			{
				if (firefox != null)
				{
					firefox.Quit();
				}
				isAlive = false;
			}
			catch (Exception ex)
			{
				ExportError(null, ex, "firefox.Close()");
			}
		}

		public void AddCookieIntoFirefox(string cookie, string domain = ".facebook.com")
		{
			if (!isAlive)
			{
				return;
			}
			try
			{
				string[] array = cookie.Split(';');
				string[] array2 = array;
				foreach (string text in array2)
				{
					if (text.Trim() != "")
					{
						string[] array3 = text.Split('=');
						if (array3.Count() > 1 && array3[0].Trim() != "")
						{
							Cookie cookie2 = new Cookie(array3[0].Trim(), text.Substring(text.IndexOf('=') + 1).Trim(), domain, "/", DateTime.Now.AddDays(10.0));
							firefox.Manage().Cookies.AddCookie(cookie2);
						}
					}
				}
			}
			catch (Exception ex)
			{
				ExportError(null, ex, "firefox.AddCookieIntoChrome(" + cookie + "," + domain + ")");
			}
		}

		public string GetCookieFromChrome(string domain = "facebook")
		{
			string text = "";
			if (isAlive)
			{
				try
				{
					Cookie[] array = firefox.Manage().Cookies.AllCookies.ToArray();
					Cookie[] array2 = array;
					foreach (Cookie cookie in array2)
					{
						if (cookie.Domain.Contains(domain))
						{
							text = text + cookie.Name + "=" + cookie.Value + ";";
						}
					}
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "firefox.GetCookieFromChrome(" + domain + ")");
				}
			}
			return text;
		}

		public void OpenNewTab(string url, bool switchToLastTab = true)
		{
			if (!isAlive)
			{
				return;
			}
			try
			{
				firefox.ExecuteScript("window.open('" + url + "', '_blank').focus();");
				if (switchToLastTab)
				{
					firefox.SwitchTo().Window(firefox.WindowHandles.Last());
				}
			}
			catch (Exception ex)
			{
				ExportError(null, ex, $"firefox.OpenNewTab({url},{switchToLastTab})");
			}
		}

		public void CloseCurrentTab()
		{
			if (isAlive)
			{
				try
				{
					firefox.Close();
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "firefox.CloseCurrentTab()");
				}
			}
		}

		public void SwitchToFirstTab()
		{
			if (isAlive)
			{
				try
				{
					firefox.SwitchTo().Window(firefox.WindowHandles.First());
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "firefox.SwitchToFirstTab()");
				}
			}
		}

		public void SwitchToLastTab()
		{
			if (isAlive)
			{
				try
				{
					firefox.SwitchTo().Window(firefox.WindowHandles.Last());
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "firefox.SwitchToLastTab()");
				}
			}
		}

		public void DelayTime(double timeDelay_Seconds)
		{
			if (isAlive)
			{
				try
				{
					Thread.Sleep(Convert.ToInt32(timeDelay_Seconds * 1000.0));
				}
				catch (Exception ex)
				{
					ExportError(null, ex, $"firefox.DelayTime({timeDelay_Seconds})");
				}
			}
		}

		public bool Select(int typeAttribute, string attributeValue, string value)
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					switch (typeAttribute)
					{
					case 1:
						new SelectElement(firefox.FindElementById(attributeValue)).SelectByValue(value);
						break;
					case 2:
						new SelectElement(firefox.FindElementByName(attributeValue)).SelectByValue(value);
						break;
					case 3:
						new SelectElement(firefox.FindElementByXPath(attributeValue)).SelectByValue(value);
						break;
					case 4:
						new SelectElement(firefox.FindElementByCssSelector(attributeValue)).SelectByValue(value);
						break;
					}
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, $"firefox.Select({typeAttribute},{attributeValue},{value})");
					return result;
				}
			}
			return result;
		}

		public bool ScreenCapture(string imagePath, string fileName)
		{
			bool result = false;
			if (isAlive)
			{
				try
				{
					Screenshot screenshot = ((ITakesScreenshot)firefox).GetScreenshot();
					screenshot.SaveAsFile(imagePath + (imagePath.EndsWith("\\") ? "" : "\\") + fileName + ".png");
					result = true;
					return result;
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "chrome.ScreenCapture(" + imagePath + "," + fileName + ")");
					return result;
				}
			}
			return result;
		}

		public object ExecuteScript(string script)
		{
			if (isAlive)
			{
				try
				{
					return firefox.ExecuteScript(script);
				}
				catch (Exception ex)
				{
					ExportError(null, ex, "firefox.ExecuteScript(" + script + ")");
				}
			}
			return "";
		}

		public static void ExportError(Chrome firefox, Exception ex, string error = "")
		{
			try
			{
				if (!Directory.Exists("log"))
				{
					Directory.CreateDirectory("log");
				}
				if (!Directory.Exists("log\\html"))
				{
					Directory.CreateDirectory("log\\html");
				}
				if (!Directory.Exists("log\\images"))
				{
					Directory.CreateDirectory("log\\images");
				}
				Random random = new Random();
				string text = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + random.Next(1000, 9999);
				if (firefox != null)
				{
					string contents = firefox.ExecuteScript("var markup = document.documentElement.innerHTML;return markup;").ToString();
					firefox.ScreenCapture("log\\images\\", text);
					File.WriteAllText("log\\html\\" + text + ".html", contents);
				}
				using StreamWriter streamWriter = new StreamWriter("log\\log.txt", append: true);
				streamWriter.WriteLine("-----------------------------------------------------------------------------");
				streamWriter.WriteLine("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
				streamWriter.WriteLine("File: " + text);
				if (error != "")
				{
					streamWriter.WriteLine("Error: " + error);
				}
				streamWriter.WriteLine();
				if (ex != null)
				{
					streamWriter.WriteLine("Type: " + ex.GetType().FullName);
					streamWriter.WriteLine("Message: " + ex.Message);
					streamWriter.WriteLine("StackTrace: " + ex.StackTrace);
					ex = ex.InnerException;
				}
			}
			catch
			{
			}
		}
	}
}
