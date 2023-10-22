using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using MCommon;
using MetroFramework.Controls;

namespace maxcare
{
	public class fMoTrinhDuyet : Form
	{
		public static bool isOK;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnMinimize;

		private Button btnCancel;

		private BunifuDragControl bunifuDragControl1;

		private PictureBox pictureBox1;

		private Panel panel1;

		private Panel panel3;

		private RadioButton rbSuDungProfile;

		private RadioButton rbKhongDungProfile;

		private MetroButton btnCauHinh;

		private Panel panel2;

		private RadioButton rbLoginEmailPass;

		private RadioButton rbLoginUidPass;

		private RadioButton rbLoginCookie;

		private Label label3;

		private Label label1;

		private Label label2;

		private Button btnSave;

		private CheckBox ckbGetCookie;

		private Panel panel5;

		private RadioButton rbLoginWWW;

		private RadioButton rbLoginMFB;

		private Label label4;

		private CheckBox ckbAutoCloseChromeLoginFail;

		private TextBox txtLink;

		private CheckBox ckbAutoOpenLink;

		private CheckBox ckbKhongLuuTrinhDuyet;

		public fMoTrinhDuyet()
		{
			InitializeComponent();
			ChangeLanguage();
			isOK = false;
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label3);
			Language.GetValue(btnCauHinh);
			Language.GetValue(label1);
			Language.GetValue(rbSuDungProfile);
			Language.GetValue(rbKhongDungProfile);
			Language.GetValue(label2);
			Language.GetValue(label4);
			Language.GetValue(ckbKhongLuuTrinhDuyet);
			Language.GetValue(ckbGetCookie);
			Language.GetValue(ckbAutoCloseChromeLoginFail);
			Language.GetValue(ckbAutoOpenLink);
			Language.GetValue(btnSave);
			Language.GetValue(btnCancel);
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fCauHinhChung());
		}

		private void fMoTrinhDuyet_Load(object sender, EventArgs e)
		{
			JSON_Settings jSON_Settings = new JSON_Settings("configOpenBrowser");
			if (jSON_Settings.GetValueBool("isUseProfile", valueDefault: true))
			{
				rbSuDungProfile.Checked = true;
			}
			else
			{
				rbKhongDungProfile.Checked = true;
			}
			if (jSON_Settings.GetValueInt("typeBrowserLogin") == 0)
			{
				rbLoginMFB.Checked = true;
			}
			else
			{
				rbLoginWWW.Checked = true;
			}
			switch (jSON_Settings.GetValueInt("typeLogin"))
			{
			case 0:
				rbLoginUidPass.Checked = true;
				break;
			case 1:
				rbLoginEmailPass.Checked = true;
				break;
			case 2:
				rbLoginCookie.Checked = true;
				break;
			}
			ckbKhongLuuTrinhDuyet.Checked = jSON_Settings.GetValueBool("ckbKhongLuuTrinhDuyet");
			ckbGetCookie.Checked = jSON_Settings.GetValueBool("isGetCookie");
			ckbAutoCloseChromeLoginFail.Checked = jSON_Settings.GetValueBool("isAutoCloseChromeLoginFail");
			ckbAutoOpenLink.Checked = jSON_Settings.GetValueBool("ckbAutoOpenLink");
			txtLink.Text = jSON_Settings.GetValue("txtLink");
			ckbAutoOpenLink_CheckedChanged(null, null);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			JSON_Settings jSON_Settings = new JSON_Settings("configOpenBrowser");
			if (rbSuDungProfile.Checked)
			{
				jSON_Settings.Update("isUseProfile", true);
			}
			else
			{
				jSON_Settings.Update("isUseProfile", false);
			}
			if (rbLoginUidPass.Checked)
			{
				jSON_Settings.Update("typeLogin", 0);
			}
			else if (rbLoginEmailPass.Checked)
			{
				jSON_Settings.Update("typeLogin", 1);
			}
			else
			{
				jSON_Settings.Update("typeLogin", 2);
			}
			if (rbLoginMFB.Checked)
			{
				jSON_Settings.Update("typeBrowserLogin", 0);
			}
			else
			{
				jSON_Settings.Update("typeBrowserLogin", 1);
			}
			jSON_Settings.Update("isGetCookie", ckbGetCookie.Checked);
			jSON_Settings.Update("ckbKhongLuuTrinhDuyet", ckbKhongLuuTrinhDuyet.Checked);
			jSON_Settings.Update("isAutoCloseChromeLoginFail", ckbAutoCloseChromeLoginFail.Checked);
			jSON_Settings.Update("ckbAutoOpenLink", ckbAutoOpenLink.Checked);
			jSON_Settings.Update("txtLink", txtLink.Text);
			jSON_Settings.Save();
			isOK = true;
			Close();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void ckbAutoOpenLink_CheckedChanged(object sender, EventArgs e)
		{
			txtLink.Enabled = ckbAutoOpenLink.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fMoTrinhDuyet));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			panel1 = new System.Windows.Forms.Panel();
			txtLink = new System.Windows.Forms.TextBox();
			btnCauHinh = new MetroFramework.Controls.MetroButton();
			panel5 = new System.Windows.Forms.Panel();
			rbLoginWWW = new System.Windows.Forms.RadioButton();
			rbLoginMFB = new System.Windows.Forms.RadioButton();
			label4 = new System.Windows.Forms.Label();
			ckbAutoOpenLink = new System.Windows.Forms.CheckBox();
			ckbAutoCloseChromeLoginFail = new System.Windows.Forms.CheckBox();
			ckbKhongLuuTrinhDuyet = new System.Windows.Forms.CheckBox();
			ckbGetCookie = new System.Windows.Forms.CheckBox();
			btnSave = new System.Windows.Forms.Button();
			panel3 = new System.Windows.Forms.Panel();
			rbSuDungProfile = new System.Windows.Forms.RadioButton();
			rbKhongDungProfile = new System.Windows.Forms.RadioButton();
			panel2 = new System.Windows.Forms.Panel();
			rbLoginEmailPass = new System.Windows.Forms.RadioButton();
			rbLoginUidPass = new System.Windows.Forms.RadioButton();
			rbLoginCookie = new System.Windows.Forms.RadioButton();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			panel5.SuspendLayout();
			panel3.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.SaddleBrown;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(1, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(452, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(452, 32);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 17;
			pictureBox1.TabStop = false;
			btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(419, -1);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 32);
			btnMinimize.TabIndex = 9;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(BtnMinimize_Click);
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(452, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Cấu hình Mở trình duyệt";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(233, 299);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Đo\u0301ng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(txtLink);
			panel1.Controls.Add(btnCauHinh);
			panel1.Controls.Add(panel5);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(ckbAutoOpenLink);
			panel1.Controls.Add(ckbAutoCloseChromeLoginFail);
			panel1.Controls.Add(ckbKhongLuuTrinhDuyet);
			panel1.Controls.Add(ckbGetCookie);
			panel1.Controls.Add(btnSave);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(panel3);
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(label2);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(453, 341);
			panel1.TabIndex = 5;
			txtLink.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtLink.Location = new System.Drawing.Point(183, 263);
			txtLink.Name = "txtLink";
			txtLink.Size = new System.Drawing.Size(233, 23);
			txtLink.TabIndex = 24;
			txtLink.TextChanged += new System.EventHandler(textBox1_TextChanged);
			btnCauHinh.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCauHinh.Location = new System.Drawing.Point(160, 62);
			btnCauHinh.Name = "btnCauHinh";
			btnCauHinh.Size = new System.Drawing.Size(75, 23);
			btnCauHinh.TabIndex = 5;
			btnCauHinh.Text = "Cấu hình";
			btnCauHinh.UseSelectable = true;
			btnCauHinh.Click += new System.EventHandler(metroButton1_Click);
			panel5.Controls.Add(rbLoginWWW);
			panel5.Controls.Add(rbLoginMFB);
			panel5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			panel5.Location = new System.Drawing.Point(157, 155);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(273, 26);
			panel5.TabIndex = 23;
			rbLoginWWW.AutoSize = true;
			rbLoginWWW.Cursor = System.Windows.Forms.Cursors.Hand;
			rbLoginWWW.Location = new System.Drawing.Point(127, 3);
			rbLoginWWW.Name = "rbLoginWWW";
			rbLoginWWW.Size = new System.Drawing.Size(99, 20);
			rbLoginWWW.TabIndex = 4;
			rbLoginWWW.Text = "www.fb.com";
			rbLoginWWW.UseVisualStyleBackColor = true;
			rbLoginMFB.AutoSize = true;
			rbLoginMFB.Checked = true;
			rbLoginMFB.Cursor = System.Windows.Forms.Cursors.Hand;
			rbLoginMFB.Location = new System.Drawing.Point(3, 3);
			rbLoginMFB.Name = "rbLoginMFB";
			rbLoginMFB.Size = new System.Drawing.Size(120, 20);
			rbLoginMFB.TabIndex = 4;
			rbLoginMFB.TabStop = true;
			rbLoginMFB.Text = "m.facebook.com";
			rbLoginMFB.UseVisualStyleBackColor = true;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(34, 160);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(111, 16);
			label4.TabIndex = 22;
			label4.Text = "Trang đăng nhâ\u0323p:";
			ckbAutoOpenLink.AutoSize = true;
			ckbAutoOpenLink.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbAutoOpenLink.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbAutoOpenLink.Location = new System.Drawing.Point(37, 265);
			ckbAutoOpenLink.Name = "ckbAutoOpenLink";
			ckbAutoOpenLink.Size = new System.Drawing.Size(150, 20);
			ckbAutoOpenLink.TabIndex = 21;
			ckbAutoOpenLink.Text = "Tự động mở website:";
			ckbAutoOpenLink.UseVisualStyleBackColor = true;
			ckbAutoOpenLink.CheckedChanged += new System.EventHandler(ckbAutoOpenLink_CheckedChanged);
			ckbAutoCloseChromeLoginFail.AutoSize = true;
			ckbAutoCloseChromeLoginFail.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbAutoCloseChromeLoginFail.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbAutoCloseChromeLoginFail.Location = new System.Drawing.Point(37, 239);
			ckbAutoCloseChromeLoginFail.Name = "ckbAutoCloseChromeLoginFail";
			ckbAutoCloseChromeLoginFail.Size = new System.Drawing.Size(327, 20);
			ckbAutoCloseChromeLoginFail.TabIndex = 21;
			ckbAutoCloseChromeLoginFail.Text = "Tự động đóng những tab chrome đăng nhập thất bại";
			ckbAutoCloseChromeLoginFail.UseVisualStyleBackColor = true;
			ckbKhongLuuTrinhDuyet.AutoSize = true;
			ckbKhongLuuTrinhDuyet.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbKhongLuuTrinhDuyet.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbKhongLuuTrinhDuyet.Location = new System.Drawing.Point(37, 187);
			ckbKhongLuuTrinhDuyet.Name = "ckbKhongLuuTrinhDuyet";
			ckbKhongLuuTrinhDuyet.Size = new System.Drawing.Size(233, 20);
			ckbKhongLuuTrinhDuyet.TabIndex = 21;
			ckbKhongLuuTrinhDuyet.Text = "Không lưu trình duyệt khi đăng nhập";
			ckbKhongLuuTrinhDuyet.UseVisualStyleBackColor = true;
			ckbGetCookie.AutoSize = true;
			ckbGetCookie.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbGetCookie.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbGetCookie.Location = new System.Drawing.Point(37, 213);
			ckbGetCookie.Name = "ckbGetCookie";
			ckbGetCookie.Size = new System.Drawing.Size(345, 20);
			ckbGetCookie.TabIndex = 21;
			ckbGetCookie.Text = "Tự động cập nhật Cookie sau khi đăng nhập thành công";
			ckbGetCookie.UseVisualStyleBackColor = true;
			btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnSave.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			btnSave.FlatAppearance.BorderSize = 0;
			btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnSave.ForeColor = System.Drawing.Color.White;
			btnSave.Location = new System.Drawing.Point(125, 299);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(92, 29);
			btnSave.TabIndex = 20;
			btnSave.Text = "Lưu";
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += new System.EventHandler(btnSave_Click);
			panel3.Controls.Add(rbSuDungProfile);
			panel3.Controls.Add(rbKhongDungProfile);
			panel3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			panel3.Location = new System.Drawing.Point(157, 91);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(273, 26);
			panel3.TabIndex = 8;
			rbSuDungProfile.AutoSize = true;
			rbSuDungProfile.Checked = true;
			rbSuDungProfile.Cursor = System.Windows.Forms.Cursors.Hand;
			rbSuDungProfile.Location = new System.Drawing.Point(3, 3);
			rbSuDungProfile.Name = "rbSuDungProfile";
			rbSuDungProfile.Size = new System.Drawing.Size(114, 20);
			rbSuDungProfile.TabIndex = 4;
			rbSuDungProfile.TabStop = true;
			rbSuDungProfile.Text = "Sử dụng Profile";
			rbSuDungProfile.UseVisualStyleBackColor = true;
			rbKhongDungProfile.AutoSize = true;
			rbKhongDungProfile.Cursor = System.Windows.Forms.Cursors.Hand;
			rbKhongDungProfile.Location = new System.Drawing.Point(127, 3);
			rbKhongDungProfile.Name = "rbKhongDungProfile";
			rbKhongDungProfile.Size = new System.Drawing.Size(133, 20);
			rbKhongDungProfile.TabIndex = 4;
			rbKhongDungProfile.Text = "Không dùng Profile";
			rbKhongDungProfile.UseVisualStyleBackColor = true;
			panel2.Controls.Add(rbLoginEmailPass);
			panel2.Controls.Add(rbLoginUidPass);
			panel2.Controls.Add(rbLoginCookie);
			panel2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			panel2.Location = new System.Drawing.Point(157, 123);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(273, 26);
			panel2.TabIndex = 8;
			rbLoginEmailPass.AutoSize = true;
			rbLoginEmailPass.Cursor = System.Windows.Forms.Cursors.Hand;
			rbLoginEmailPass.Location = new System.Drawing.Point(93, 3);
			rbLoginEmailPass.Name = "rbLoginEmailPass";
			rbLoginEmailPass.Size = new System.Drawing.Size(89, 20);
			rbLoginEmailPass.TabIndex = 4;
			rbLoginEmailPass.Text = "Email|Pass";
			rbLoginEmailPass.UseVisualStyleBackColor = true;
			rbLoginUidPass.AutoSize = true;
			rbLoginUidPass.Checked = true;
			rbLoginUidPass.Cursor = System.Windows.Forms.Cursors.Hand;
			rbLoginUidPass.Location = new System.Drawing.Point(3, 3);
			rbLoginUidPass.Name = "rbLoginUidPass";
			rbLoginUidPass.Size = new System.Drawing.Size(76, 20);
			rbLoginUidPass.TabIndex = 4;
			rbLoginUidPass.TabStop = true;
			rbLoginUidPass.Text = "Uid|Pass";
			rbLoginUidPass.UseVisualStyleBackColor = true;
			rbLoginCookie.AutoSize = true;
			rbLoginCookie.Cursor = System.Windows.Forms.Cursors.Hand;
			rbLoginCookie.Location = new System.Drawing.Point(196, 3);
			rbLoginCookie.Name = "rbLoginCookie";
			rbLoginCookie.Size = new System.Drawing.Size(64, 20);
			rbLoginCookie.TabIndex = 4;
			rbLoginCookie.Text = "Cookie";
			rbLoginCookie.UseVisualStyleBackColor = true;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(34, 64);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(99, 16);
			label3.TabIndex = 7;
			label3.Text = "Cấu hình đổi IP:";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(34, 96);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(105, 16);
			label1.TabIndex = 7;
			label1.Text = "Tùy chọn Profile:";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(34, 128);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(101, 16);
			label2.TabIndex = 7;
			label2.Text = "Kiểu đăng nhâ\u0323p:";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(453, 341);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fMoTrinhDuyet";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fMoTrinhDuyet_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
