using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using MCommon;
using MetroFramework.Controls;

namespace maxcare
{
	public class fMoLDPlayer : Form
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

		private MetroButton btnCauHinh;

		private Panel panel2;

		private RadioButton rbLoginEmailPass;

		private RadioButton rbLoginUidPass;

		private Label label3;

		private Label label2;

		private Button btnSave;

		private CheckBox ckbGetCookie;

		private CheckBox ckbAutoCloseChromeLoginFail;

		private CheckBox ckbBackupAccount;

		public fMoLDPlayer()
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
			Language.GetValue(label2);
			Language.GetValue(ckbGetCookie);
			Language.GetValue(ckbAutoCloseChromeLoginFail);
			Language.GetValue(btnSave);
			Language.GetValue(btnCancel);
			Language.GetValue(ckbBackupAccount);
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
			switch (jSON_Settings.GetValueInt("typeLogin"))
			{
			case 1:
				rbLoginEmailPass.Checked = true;
				break;
			case 0:
				rbLoginUidPass.Checked = true;
				break;
			}
			ckbGetCookie.Checked = jSON_Settings.GetValueBool("isGetCookie");
			ckbAutoCloseChromeLoginFail.Checked = jSON_Settings.GetValueBool("isAutoCloseChromeLoginFail");
			ckbBackupAccount.Checked = jSON_Settings.GetValueBool("isBackupAccount");
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			JSON_Settings jSON_Settings = new JSON_Settings("configOpenBrowser");
			if (rbLoginUidPass.Checked)
			{
				jSON_Settings.Update("typeLogin", 0);
			}
			else
			{
				jSON_Settings.Update("typeLogin", 1);
			}
			jSON_Settings.Update("isGetCookie", ckbGetCookie.Checked);
			jSON_Settings.Update("isAutoCloseChromeLoginFail", ckbAutoCloseChromeLoginFail.Checked);
			jSON_Settings.Update("isBackupAccount", ckbBackupAccount.Checked);
			jSON_Settings.Save();
			isOK = true;
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fMoLDPlayer));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			panel1 = new System.Windows.Forms.Panel();
			btnCauHinh = new MetroFramework.Controls.MetroButton();
			ckbBackupAccount = new System.Windows.Forms.CheckBox();
			ckbAutoCloseChromeLoginFail = new System.Windows.Forms.CheckBox();
			ckbGetCookie = new System.Windows.Forms.CheckBox();
			btnSave = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			rbLoginEmailPass = new System.Windows.Forms.RadioButton();
			rbLoginUidPass = new System.Windows.Forms.RadioButton();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
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
			bunifuCards1.Size = new System.Drawing.Size(402, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(402, 32);
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
			btnMinimize.Location = new System.Drawing.Point(369, -1);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(402, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Cấu hình Mở LDPlayer";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(208, 208);
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
			panel1.Controls.Add(btnCauHinh);
			panel1.Controls.Add(ckbBackupAccount);
			panel1.Controls.Add(ckbAutoCloseChromeLoginFail);
			panel1.Controls.Add(ckbGetCookie);
			panel1.Controls.Add(btnSave);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label2);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(403, 250);
			panel1.TabIndex = 5;
			btnCauHinh.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCauHinh.Location = new System.Drawing.Point(160, 62);
			btnCauHinh.Name = "btnCauHinh";
			btnCauHinh.Size = new System.Drawing.Size(75, 23);
			btnCauHinh.TabIndex = 5;
			btnCauHinh.Text = "Cấu hình";
			btnCauHinh.UseSelectable = true;
			btnCauHinh.Click += new System.EventHandler(metroButton1_Click);
			ckbBackupAccount.AutoSize = true;
			ckbBackupAccount.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbBackupAccount.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbBackupAccount.Location = new System.Drawing.Point(37, 172);
			ckbBackupAccount.Name = "ckbBackupAccount";
			ckbBackupAccount.Size = new System.Drawing.Size(314, 20);
			ckbBackupAccount.TabIndex = 21;
			ckbBackupAccount.Text = "Backup dữ liệu LDPlayer khi đăng nhập thành công";
			ckbBackupAccount.UseVisualStyleBackColor = true;
			ckbAutoCloseChromeLoginFail.AutoSize = true;
			ckbAutoCloseChromeLoginFail.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbAutoCloseChromeLoginFail.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbAutoCloseChromeLoginFail.Location = new System.Drawing.Point(37, 146);
			ckbAutoCloseChromeLoginFail.Name = "ckbAutoCloseChromeLoginFail";
			ckbAutoCloseChromeLoginFail.Size = new System.Drawing.Size(301, 20);
			ckbAutoCloseChromeLoginFail.TabIndex = 21;
			ckbAutoCloseChromeLoginFail.Text = "Tự động đóng những thiết bị đăng nhập thất bại";
			ckbAutoCloseChromeLoginFail.UseVisualStyleBackColor = true;
			ckbGetCookie.AutoSize = true;
			ckbGetCookie.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbGetCookie.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbGetCookie.Location = new System.Drawing.Point(37, 120);
			ckbGetCookie.Name = "ckbGetCookie";
			ckbGetCookie.Size = new System.Drawing.Size(328, 20);
			ckbGetCookie.TabIndex = 21;
			ckbGetCookie.Text = "Tự động lấy Token/Cookie khi đăng nhập thành công";
			ckbGetCookie.UseVisualStyleBackColor = true;
			btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnSave.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			btnSave.FlatAppearance.BorderSize = 0;
			btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnSave.ForeColor = System.Drawing.Color.White;
			btnSave.Location = new System.Drawing.Point(100, 208);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(92, 29);
			btnSave.TabIndex = 20;
			btnSave.Text = "Lưu";
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += new System.EventHandler(btnSave_Click);
			panel2.Controls.Add(rbLoginEmailPass);
			panel2.Controls.Add(rbLoginUidPass);
			panel2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			panel2.Location = new System.Drawing.Point(157, 88);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(207, 26);
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
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(34, 64);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(99, 16);
			label3.TabIndex = 7;
			label3.Text = "Cấu hình đổi IP:";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(34, 93);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(101, 16);
			label2.TabIndex = 7;
			label2.Text = "Kiểu đăng nhâ\u0323p:";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(403, 250);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fMoLDPlayer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fMoTrinhDuyet_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
