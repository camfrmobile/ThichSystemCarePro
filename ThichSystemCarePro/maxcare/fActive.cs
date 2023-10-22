using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Common;
using DeviceId;
using License.RNCryptor;
using maxcare.Helper;
using maxcare.Properties;
using MCommon;

namespace maxcare
{
	public class fActive : Form
	{
		private int typeError = 0;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private BunifuMetroTextbox txbUserName;

		private BunifuCustomLabel bunifuCustomLabel2;

		private BunifuCustomLabel bunifuCustomLabel3;

		private BunifuMetroTextbox txbPassword;

		private Button btnLogin;

		private Label lblStatus;

		private LinkLabel linkLabel1;

		private Label label1;

		private Button btnMinimize;

		private BunifuDragControl bunifuDragControl1;

		private PictureBox pictureBox2;

		private BunifuCustomLabel bunifuCustomLabel8;

		private BunifuCustomLabel bunifuCustomLabel5;

		private BunifuCustomLabel bunifuCustomLabel6;

		private BunifuCustomLabel bunifuCustomLabel4;

		private BunifuCustomLabel lblKey;

		private BunifuCustomLabel bunifuCustomLabel7;

		private BunifuDragControl bunifuDragControl2;

		public fActive(int typeError, string idKey)
		{
			InitializeComponent();
			this.typeError = typeError;
			lblStatus.Text = GetStatusFromCode(typeError);
			lblKey.Text = idKey;
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(this);
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(bunifuCustomLabel3);
			Language.GetValue(btnLogin);
			Language.GetValue(label1);
			Language.GetValue(linkLabel1);
			Language.GetValue(bunifuCustomLabel7);
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private string GetStatusFromCode(int typeError = 0)
		{
			return typeError switch
			{
				0 => "", 
				1 => Language.GetValue("Vui lòng đăng nhập để sử dụng phần mềm!!!"), 
				2 => Language.GetValue("Thiết bị của bạn chưa được kích hoạt!!!"), 
				3 => Language.GetValue("Thiết bị của bạn đã hết hạn sử dụng!!!"), 
				4 => Language.GetValue("Tài khoản hoặc mật khẩu bạn nhập không đúng!!!"), 
				_ => Language.GetValue("Lỗi không xác định!!!"), 
			};
		}

		private void BtnLogin_Click(object sender, EventArgs e)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\drivers\\etc\\hosts";
			if (File.Exists(path))
			{
				try
				{
					List<string> list = new List<string> { "app.minsoftware.vn", "minsoftware.vn" };
					using StreamReader streamReader = new StreamReader(path);
					string empty = string.Empty;
					while ((empty = streamReader.ReadLine()) != null)
					{
						foreach (string item in list)
						{
							if (empty.ToLower().Contains(item))
							{
								MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng cấu hình lại file hosts nếu muốn mở phần mềm!"), 2);
								Environment.Exit(0);
							}
						}
					}
				}
				catch
				{
				}
			}
			string userName = txbUserName.Text.Trim();
			string pass = txbPassword.Text.Trim();
			if (userName == "" || pass == "")
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng điền đầy đủ thông tin!"), 3);
				return;
			}
			if (!CommonCSharp.IsValidMail(txbUserName.Text))
			{
				lblStatus.Invoke((MethodInvoker)delegate
				{
					lblStatus.Text = Language.GetValue("Email bạn nhập không đúng đi\u0323nh da\u0323ng!");
				});
				return;
			}
			new Thread((ThreadStart)delegate
			{
				btnLogin.Invoke((MethodInvoker)delegate
				{
					btnLogin.Enabled = false;
				});
				lblStatus.Invoke((MethodInvoker)delegate
				{
					lblStatus.Text = Language.GetValue("Đang kiểm tra đăng nhập...");
				});
				try
				{
					Encryptor encryptor = new Encryptor();
					string text = CommonCSharp.Md5Encode(new DeviceIdBuilder().AddMachineName().AddProcessorId().AddMotherboardSerialNumber()
						.AddSystemDriveSerialNumber()
						.ToString());
					RequestXNet requestXNet = new RequestXNet("", "", "", 0);
					Decryptor decryptor = new Decryptor();
					Random random = new Random();
					string text2 = CommonCSharp.ReadHTMLCode("http://app.minsoftware.vn/api/auth?datavery=" + CommonCSharp.Base64Encode(userName + "|" + pass)).Replace("\"", "");
					if (text2.Trim() == "")
					{
						lblStatus.Invoke((MethodInvoker)delegate
						{
							lblStatus.Text = GetStatusFromCode(4);
						});
						btnLogin.Invoke((MethodInvoker)delegate
						{
							btnLogin.Enabled = true;
						});
						return;
					}
					int num = random.Next(0, 10000) + random.Next(100, 1000);
					string text3 = "http://app.minsoftware.vn/minapi/minapi/api.php/active32345?data=";
					string plaintext = text + "|" + text2 + "|" + 42 + "|" + num + "|code1";
					string text4 = encryptor.Encrypt(plaintext, "pass1");
					string base64EncodedData = requestXNet.RequestGet(text3 + text4).Replace("\"", "");
					base64EncodedData = CommonCSharp.Base64Decode(base64EncodedData);
					base64EncodedData = decryptor.Decrypt(base64EncodedData, "pass1" + num);
					if (base64EncodedData.Contains("chuakichhoat"))
					{
						lblStatus.Invoke((MethodInvoker)delegate
						{
							lblStatus.Text = GetStatusFromCode(2);
						});
						btnLogin.Invoke((MethodInvoker)delegate
						{
							btnLogin.Enabled = true;
						});
						return;
					}
					if (base64EncodedData.Contains("error"))
					{
						lblStatus.Invoke((MethodInvoker)delegate
						{
							lblStatus.Text = GetStatusFromCode(5);
						});
						btnLogin.Invoke((MethodInvoker)delegate
						{
							btnLogin.Enabled = true;
						});
						return;
					}
					if (base64EncodedData.Contains("hethan"))
					{
						lblStatus.Invoke((MethodInvoker)delegate
						{
							lblStatus.Text = GetStatusFromCode(3);
						});
						btnLogin.Invoke((MethodInvoker)delegate
						{
							btnLogin.Enabled = true;
						});
						return;
					}
					_ = base64EncodedData.Split('|')[0];
					string text5 = base64EncodedData.Split('|')[1];
					_ = base64EncodedData.Split('|')[2];
					string text6 = base64EncodedData.Split('|')[3];
					string text7 = base64EncodedData.Split('|')[4];
					string text8 = base64EncodedData.Split('|')[5];
					if (text != text6 || text5 != text2 || text7 != num.ToString() || text8 != "code1")
					{
						lblStatus.Invoke((MethodInvoker)delegate
						{
							lblStatus.Text = Language.GetValue("Không thể kích hoạt tài khoản của bạn, vui lòng thử lại!!!");
						});
						btnLogin.Invoke((MethodInvoker)delegate
						{
							btnLogin.Enabled = true;
						});
						return;
					}
					lblStatus.Invoke((MethodInvoker)delegate
					{
						lblStatus.Text = Language.GetValue("Đăng nhập thành công!");
					});
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Thiết bị của bạn đã được kích hoạt, cảm ơn đã sử dụng phần mềm của Min Software.") + "\r\n" + Language.GetValue("Vui lòng mở lại phần mềm để sử dụng!"));
					Settings.Default.UserName = txbUserName.Text;
					Settings.Default.PassWord = txbPassword.Text;
					Settings.Default.Save();
					Environment.Exit(0);
				}
				catch (Exception ex)
				{
					MCommon.Common.ExportError(null, ex, "Active error");
					MessageBoxHelper.ShowMessageBox("Lỗi không xác định!!!", 2);
				}
				btnLogin.Invoke((MethodInvoker)delegate
				{
					btnLogin.Enabled = true;
				});
			}).Start();
		}

		private void FActive_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(0);
		}

		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("chrome.exe", "http://app.minsoftware.vn/signup");
			}
			catch
			{
				Process.Start("http://app.minsoftware.vn/signup");
			}
		}

		private void pictureBox2_Click_1(object sender, EventArgs e)
		{
			Clipboard.SetText(lblKey.Text);
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Đã copy mã thiết bị!"));
		}

		private void txbUserName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				BtnLogin_Click(null, null);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fActive));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			btnMinimize = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			txbUserName = new Bunifu.Framework.UI.BunifuMetroTextbox();
			bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
			txbPassword = new Bunifu.Framework.UI.BunifuMetroTextbox();
			btnLogin = new System.Windows.Forms.Button();
			lblStatus = new System.Windows.Forms.Label();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			label1 = new System.Windows.Forms.Label();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pictureBox2 = new System.Windows.Forms.PictureBox();
			bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
			lblKey = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.SaddleBrown;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(0, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(395, 38);
			bunifuCards1.TabIndex = 11;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(393, 32);
			pnlHeader.TabIndex = 9;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(361, 0);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 32);
			btnMinimize.TabIndex = 13;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(BtnMinimize_Click);
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(6, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(42, 7);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(306, 16);
			bunifuCustomLabel1.TabIndex = 7;
			bunifuCustomLabel1.Text = "MAX SYSTEM CARE PRO - Kích hoạt bản quyền";
			txbUserName.BorderColorFocused = System.Drawing.Color.FromArgb(192, 64, 0);
			txbUserName.BorderColorIdle = System.Drawing.Color.FromArgb(64, 64, 64);
			txbUserName.BorderColorMouseHover = System.Drawing.Color.FromArgb(192, 64, 0);
			txbUserName.BorderThickness = 3;
			txbUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txbUserName.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txbUserName.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txbUserName.isPassword = false;
			txbUserName.Location = new System.Drawing.Point(117, 46);
			txbUserName.Margin = new System.Windows.Forms.Padding(4);
			txbUserName.Name = "txbUserName";
			txbUserName.Size = new System.Drawing.Size(228, 29);
			txbUserName.TabIndex = 0;
			txbUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			txbUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(txbUserName_KeyDown);
			bunifuCustomLabel2.AutoSize = true;
			bunifuCustomLabel2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel2.Location = new System.Drawing.Point(37, 52);
			bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			bunifuCustomLabel2.Size = new System.Drawing.Size(45, 16);
			bunifuCustomLabel2.TabIndex = 13;
			bunifuCustomLabel2.Text = "Email:";
			bunifuCustomLabel3.AutoSize = true;
			bunifuCustomLabel3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel3.Location = new System.Drawing.Point(37, 91);
			bunifuCustomLabel3.Name = "bunifuCustomLabel3";
			bunifuCustomLabel3.Size = new System.Drawing.Size(73, 16);
			bunifuCustomLabel3.TabIndex = 15;
			bunifuCustomLabel3.Text = "Mật khẩu:";
			txbPassword.BorderColorFocused = System.Drawing.Color.FromArgb(192, 64, 0);
			txbPassword.BorderColorIdle = System.Drawing.Color.FromArgb(64, 64, 64);
			txbPassword.BorderColorMouseHover = System.Drawing.Color.FromArgb(192, 64, 0);
			txbPassword.BorderThickness = 3;
			txbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
			txbPassword.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txbPassword.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			txbPassword.isPassword = true;
			txbPassword.Location = new System.Drawing.Point(117, 83);
			txbPassword.Margin = new System.Windows.Forms.Padding(4);
			txbPassword.Name = "txbPassword";
			txbPassword.Size = new System.Drawing.Size(228, 29);
			txbPassword.TabIndex = 1;
			txbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			txbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(txbUserName_KeyDown);
			btnLogin.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
			btnLogin.FlatAppearance.BorderSize = 0;
			btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnLogin.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnLogin.ForeColor = System.Drawing.Color.White;
			btnLogin.Location = new System.Drawing.Point(149, 136);
			btnLogin.Name = "btnLogin";
			btnLogin.Size = new System.Drawing.Size(115, 29);
			btnLogin.TabIndex = 2;
			btnLogin.Text = "Đăng nhập";
			btnLogin.UseVisualStyleBackColor = false;
			btnLogin.Click += new System.EventHandler(BtnLogin_Click);
			lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.ForeColor = System.Drawing.Color.Red;
			lblStatus.Location = new System.Drawing.Point(10, 115);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(371, 18);
			lblStatus.TabIndex = 28;
			lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			linkLabel1.AutoSize = true;
			linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel1.LinkColor = System.Drawing.Color.FromArgb(53, 120, 229);
			linkLabel1.Location = new System.Drawing.Point(274, 172);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(25, 13);
			linkLabel1.TabIndex = 3;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "đây";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(LinkLabel1_LinkClicked);
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(118, 172);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(157, 13);
			label1.TabIndex = 30;
			label1.Text = "Đăng ký tài khoản mới bấm vào";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = pnlHeader;
			bunifuDragControl1.Vertical = true;
			pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new System.Drawing.Point(357, 208);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(20, 20);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 42;
			pictureBox2.TabStop = false;
			pictureBox2.Click += new System.EventHandler(pictureBox2_Click_1);
			bunifuCustomLabel8.Anchor = System.Windows.Forms.AnchorStyles.Right;
			bunifuCustomLabel8.AutoSize = true;
			bunifuCustomLabel8.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel8.ForeColor = System.Drawing.Color.Gray;
			bunifuCustomLabel8.Location = new System.Drawing.Point(224, 195);
			bunifuCustomLabel8.Name = "bunifuCustomLabel8";
			bunifuCustomLabel8.Size = new System.Drawing.Size(140, 13);
			bunifuCustomLabel8.TabIndex = 40;
			bunifuCustomLabel8.Text = "https://minsoftware.vn";
			bunifuCustomLabel5.Anchor = System.Windows.Forms.AnchorStyles.Right;
			bunifuCustomLabel5.AutoSize = true;
			bunifuCustomLabel5.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel5.ForeColor = System.Drawing.Color.Gray;
			bunifuCustomLabel5.Location = new System.Drawing.Point(73, 195);
			bunifuCustomLabel5.Name = "bunifuCustomLabel5";
			bunifuCustomLabel5.Size = new System.Drawing.Size(83, 13);
			bunifuCustomLabel5.TabIndex = 41;
			bunifuCustomLabel5.Text = "0358.39.4040";
			bunifuCustomLabel6.Anchor = System.Windows.Forms.AnchorStyles.Right;
			bunifuCustomLabel6.AutoSize = true;
			bunifuCustomLabel6.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel6.Location = new System.Drawing.Point(168, 195);
			bunifuCustomLabel6.Name = "bunifuCustomLabel6";
			bunifuCustomLabel6.Size = new System.Drawing.Size(56, 13);
			bunifuCustomLabel6.TabIndex = 38;
			bunifuCustomLabel6.Text = "Website:";
			bunifuCustomLabel4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			bunifuCustomLabel4.AutoSize = true;
			bunifuCustomLabel4.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel4.Location = new System.Drawing.Point(22, 195);
			bunifuCustomLabel4.Name = "bunifuCustomLabel4";
			bunifuCustomLabel4.Size = new System.Drawing.Size(53, 13);
			bunifuCustomLabel4.TabIndex = 39;
			bunifuCustomLabel4.Text = "Hotline: ";
			lblKey.Anchor = System.Windows.Forms.AnchorStyles.Right;
			lblKey.AutoSize = true;
			lblKey.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblKey.ForeColor = System.Drawing.Color.Gray;
			lblKey.Location = new System.Drawing.Point(94, 213);
			lblKey.Name = "lblKey";
			lblKey.Size = new System.Drawing.Size(231, 13);
			lblKey.TabIndex = 37;
			lblKey.Text = "********************************";
			bunifuCustomLabel7.Anchor = System.Windows.Forms.AnchorStyles.Right;
			bunifuCustomLabel7.AutoSize = true;
			bunifuCustomLabel7.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel7.Location = new System.Drawing.Point(22, 213);
			bunifuCustomLabel7.Name = "bunifuCustomLabel7";
			bunifuCustomLabel7.Size = new System.Drawing.Size(70, 13);
			bunifuCustomLabel7.TabIndex = 36;
			bunifuCustomLabel7.Text = "Mã thiết bị:";
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = bunifuCustomLabel1;
			bunifuDragControl2.Vertical = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(393, 238);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(bunifuCustomLabel8);
			base.Controls.Add(bunifuCustomLabel5);
			base.Controls.Add(bunifuCustomLabel6);
			base.Controls.Add(bunifuCustomLabel4);
			base.Controls.Add(lblKey);
			base.Controls.Add(bunifuCustomLabel7);
			base.Controls.Add(linkLabel1);
			base.Controls.Add(label1);
			base.Controls.Add(lblStatus);
			base.Controls.Add(btnLogin);
			base.Controls.Add(bunifuCustomLabel3);
			base.Controls.Add(txbPassword);
			base.Controls.Add(bunifuCustomLabel2);
			base.Controls.Add(txbUserName);
			base.Controls.Add(bunifuCards1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "fActive";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "MAX SYSTEM CARE PRO - Kích hoạt bản quyền";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FActive_FormClosing);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
