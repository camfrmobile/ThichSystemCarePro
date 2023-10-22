using System;
using System.Linq;
using System.Text.RegularExpressions;
using AE.Net.Mail;
using MCommon;

namespace maxcare.Helper
{
	internal class EmailHelper
	{
		public static void DeleteMail(string username, string password)
		{
			int num = 0;
			while (true)
			{
				try
				{
					string text = "outlook.office365.com";
					if (username.EndsWith("@hotmail.com") || username.EndsWith("@outlook.com"))
					{
						text = "outlook.office365.com";
					}
					else if (username.EndsWith("@yandex.com"))
					{
						text = "imap.yandex.com";
					}
					ImapClient imapClient = new ImapClient(text, username, password, AuthMethods.Login, 993, secure: true);
					Lazy<MailMessage>[] array = null;
					array = ((!(text == "imap.yandex.com")) ? imapClient.SearchMessages(SearchCondition.From("security@facebookmail.com").And(SearchCondition.Unseen())) : imapClient.SearchMessages(SearchCondition.Unseen()));
					if (array.Length != 0)
					{
						for (int num2 = array.Length - 1; num2 >= 0; num2--)
						{
							Lazy<MailMessage> lazy = array[num2];
							imapClient.DeleteMessage(lazy.Value);
						}
					}
					if (imapClient.IsDisposed)
					{
						imapClient.Dispose();
					}
					if (imapClient.IsConnected)
					{
						imapClient.Disconnect();
					}
					return;
				}
				catch (Exception ex)
				{
					if (ex.ToString().Contains("The remote certificate is invalid according to the validation procedure"))
					{
						num++;
						if (num < 10)
						{
							continue;
						}
						return;
					}
					return;
				}
			}
		}

		public static string GetOtpFromMail(int type, string username, string password, int timeout = 60)
		{
			int num = 0;
			int num2 = 10;
			string text = "outlook.office365.com";
			if (username.EndsWith("@hotmail.com") || username.EndsWith("@outlook.com"))
			{
				text = "outlook.office365.com";
			}
			else if (username.EndsWith("@yandex.com"))
			{
				text = "imap.yandex.com";
			}
			while (true)
			{
				try
				{
					ImapClient imapClient = new ImapClient(text, username, password, AuthMethods.Login, 993, secure: true);
					for (int i = 0; i < timeout; i++)
					{
						try
						{
							for (int j = 0; j < 2; j++)
							{
								if (text == "imap.yandex.com")
								{
									j = 1;
								}
								if (j == 0)
								{
									imapClient.SelectMailbox("Inbox");
								}
								else
								{
									imapClient.SelectMailbox("Spam");
								}
								int messageCount = imapClient.GetMessageCount();
								if (messageCount <= 0)
								{
									continue;
								}
								Lazy<MailMessage>[] array = null;
								array = ((!(text == "imap.yandex.com")) ? imapClient.SearchMessages(SearchCondition.From("security@facebookmail.com").Or(SearchCondition.From("registration@facebookmail.com")).And(SearchCondition.Unseen())) : imapClient.SearchMessages(SearchCondition.Unseen()));
								if (array.Length == 0)
								{
									continue;
								}
								int num3 = array.Count() - 1;
								while (num3 >= 0)
								{
									string input = array[num3].Value.Body.ToString();
									string text2 = "";
									switch (type)
									{
									case 0:
										text2 = Regex.Match(input, "https://www.facebook.com/confirmcontact.php(.*?)\n").Value.Trim();
										break;
									case 1:
										text2 = Regex.Match(input, "\\d{8}").Value.Trim();
										break;
									case 2:
										text2 = Regex.Match(input, "https://www.facebook.com/n/\\?confirmemail.php(.*?)\n").Value.Trim();
										break;
									}
									if (!(text2 != ""))
									{
										num3--;
										continue;
									}
									if (imapClient.IsDisposed)
									{
										imapClient.Dispose();
									}
									if (imapClient.IsConnected)
									{
										imapClient.Disconnect();
									}
									return text2;
								}
							}
						}
						catch
						{
						}
						MCommon.Common.DelayTime(1.0);
					}
					if (imapClient.IsDisposed)
					{
						imapClient.Dispose();
					}
					if (imapClient.IsConnected)
					{
						imapClient.Disconnect();
					}
				}
				catch (Exception ex)
				{
					if (ex.ToString().ToLower().Contains("blocked"))
					{
						return "block";
					}
					num++;
					if (num < num2)
					{
						continue;
					}
				}
				break;
			}
			return "";
		}
	}
}
