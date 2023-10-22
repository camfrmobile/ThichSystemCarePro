using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.KichBan;
using MCommon;
using MetroFramework.Controls;

namespace maxcare
{
	public class fCauHinhTuongTac : Form
	{
		private JSON_Settings settings;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnMinimize;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuDragControl bunifuDragControl1;

		private PictureBox pictureBox1;

		private GroupBox groupBox2;

		private CheckBox ckbRandomHanhDong;

		private ComboBox cbbKichBan;

		private MetroButton btnQuanLyKichBan;

		private Label label1;

		private CheckBox ckbGetCookie;

		private Panel panel1;

		private CheckBox ckbRepeatAll;

		private Label label2;

		private Panel panel2;

		private RadioButton rbLoginEmailPass;

		private RadioButton rbLoginUidPass;

		private Panel plRepeatAll;

		private Label label6;

		private Label label4;

		private NumericUpDown nudDelayTurnFrom;

		private Label label5;

		private NumericUpDown nudDelayTurnTo;

		private Label label11;

		private NumericUpDown nudSoLuotChay;

		private Label label10;

		private CheckBox ckbCheckLiveUid;

		private GroupBox groupBox1;

		private CheckBox ckbRandomThuTuTaiKhoan;

		private CheckBox ckbReloginIfLogout;

		private CheckBox ckbUpdateInfo;

		public fCauHinhTuongTac()
		{
			InitializeComponent();
			settings = new JSON_Settings("configInteractGeneral");
			ChangeLanguage();
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(ckbCheckLiveUid);
			Language.GetValue(ckbGetCookie);
			Language.GetValue(ckbRepeatAll);
			Language.GetValue(label6);
			Language.GetValue(label5);
			Language.GetValue(label4);
			Language.GetValue(label10);
			Language.GetValue(label11);
			Language.GetValue(groupBox2);
			Language.GetValue(label1);
			Language.GetValue(btnQuanLyKichBan);
			Language.GetValue(ckbRandomHanhDong);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(label2);
			Language.GetValue(ckbReloginIfLogout);
			Language.GetValue(ckbGetCookie);
			Language.GetValue(ckbUpdateInfo);
			Language.GetValue(ckbRandomThuTuTaiKhoan);
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			int num = 0;
			if (rbLoginEmailPass.Checked)
			{
				num = 1;
			}
			settings.Update("typeLogin", num);
			settings.Update("ckbGetCookie", ckbGetCookie.Checked);
			settings.Update("ckbUpdateInfo", ckbUpdateInfo.Checked);
			settings.Update("ckbCheckLiveUid", ckbCheckLiveUid.Checked);
			settings.Update("ckbRepeatAll", ckbRepeatAll.Checked);
			settings.Update("nudDelayTurnFrom", nudDelayTurnFrom.Value);
			settings.Update("nudDelayTurnTo", nudDelayTurnTo.Value);
			settings.Update("nudSoLuotChay", nudSoLuotChay.Value);
			settings.Update("RepeatAllVIP", "false");
			settings.Update("ckbRandomThuTuTaiKhoan", ckbRandomThuTuTaiKhoan.Checked);
			settings.Update("ckbReloginIfLogout", ckbReloginIfLogout.Checked);
			settings.Update("cbbKichBan", cbbKichBan.SelectedValue);
			settings.Update("ckbRandomHanhDong", ckbRandomHanhDong.Checked);
			settings.Save();
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Lưu thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?")) == DialogResult.Yes)
			{
				Close();
			}
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fConfigInteract());
		}

		private void metroButton2_Click(object sender, EventArgs e)
		{
			string kickBan = "";
			try
			{
				if (cbbKichBan.Items.Count > 0)
				{
					kickBan = cbbKichBan.SelectedValue.ToString();
				}
			}
			catch
			{
			}
			MCommon.Common.ShowForm(new fDanhSachKichBan_Old(kickBan));
			LoadcbbKichBan();
		}

		private void CheckedChangedFull()
		{
			ckbRepeatAll_CheckedChanged(null, null);
		}

		private void fCauHinhTuongTac_Load(object sender, EventArgs e)
		{
			LoadcbbKichBan();
			LoadSettings();
			CheckedChangedFull();
		}

		private void LoadSettings()
		{
			try
			{
				switch (settings.GetValueInt("typeLogin"))
				{
				case 1:
					rbLoginEmailPass.Checked = true;
					break;
				case 0:
					rbLoginUidPass.Checked = true;
					break;
				}
				ckbGetCookie.Checked = settings.GetValueBool("ckbGetCookie");
				ckbUpdateInfo.Checked = settings.GetValueBool("ckbUpdateInfo");
				ckbCheckLiveUid.Checked = settings.GetValueBool("ckbCheckLiveUid");
				ckbRepeatAll.Checked = settings.GetValueBool("ckbRepeatAll");
				nudDelayTurnFrom.Value = settings.GetValueInt("nudDelayTurnFrom");
				nudDelayTurnTo.Value = settings.GetValueInt("nudDelayTurnTo");
				nudSoLuotChay.Value = settings.GetValueInt("nudSoLuotChay");
				ckbRandomThuTuTaiKhoan.Checked = settings.GetValueBool("ckbRandomThuTuTaiKhoan");
				ckbReloginIfLogout.Checked = settings.GetValueBool("ckbReloginIfLogout");
				cbbKichBan.SelectedValue = settings.GetValue("cbbKichBan");
				ckbRandomHanhDong.Checked = settings.GetValueBool("ckbRandomHanhDong");
			}
			catch
			{
			}
		}

		private void LoadcbbKichBan()
		{
			int num = -1;
			if (cbbKichBan.SelectedIndex != -1)
			{
				num = cbbKichBan.SelectedIndex;
			}
			DataTable allKichBan = InteractSQL.GetAllKichBan();
			cbbKichBan.DataSource = allKichBan;
			cbbKichBan.ValueMember = "Id_KichBan";
			cbbKichBan.DisplayMember = "TenKichBan";
			if (num != -1 && num != 0 && cbbKichBan.Items.Count >= num + 1)
			{
				cbbKichBan.SelectedIndex = num;
			}
			else if (cbbKichBan.Items.Count > 0)
			{
				cbbKichBan.SelectedIndex = 0;
			}
		}

		private void ckbRepeatAll_CheckedChanged(object sender, EventArgs e)
		{
			plRepeatAll.Enabled = ckbRepeatAll.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fCauHinhTuongTac));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			groupBox2 = new System.Windows.Forms.GroupBox();
			ckbRandomHanhDong = new System.Windows.Forms.CheckBox();
			cbbKichBan = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			btnQuanLyKichBan = new MetroFramework.Controls.MetroButton();
			label2 = new System.Windows.Forms.Label();
			ckbGetCookie = new System.Windows.Forms.CheckBox();
			ckbRepeatAll = new System.Windows.Forms.CheckBox();
			panel1 = new System.Windows.Forms.Panel();
			groupBox1 = new System.Windows.Forms.GroupBox();
			panel2 = new System.Windows.Forms.Panel();
			rbLoginEmailPass = new System.Windows.Forms.RadioButton();
			rbLoginUidPass = new System.Windows.Forms.RadioButton();
			plRepeatAll = new System.Windows.Forms.Panel();
			label6 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			nudDelayTurnFrom = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			nudDelayTurnTo = new System.Windows.Forms.NumericUpDown();
			label11 = new System.Windows.Forms.Label();
			nudSoLuotChay = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			ckbCheckLiveUid = new System.Windows.Forms.CheckBox();
			ckbUpdateInfo = new System.Windows.Forms.CheckBox();
			ckbReloginIfLogout = new System.Windows.Forms.CheckBox();
			ckbRandomThuTuTaiKhoan = new System.Windows.Forms.CheckBox();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			groupBox2.SuspendLayout();
			panel1.SuspendLayout();
			groupBox1.SuspendLayout();
			panel2.SuspendLayout();
			plRepeatAll.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuotChay).BeginInit();
			SuspendLayout();
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.FromArgb(24, 119, 242);
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(2, 1);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(440, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(440, 32);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 78;
			pictureBox1.TabStop = false;
			btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(406, -2);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(440, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Cấu hình Tương tác";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(226, 420);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(122, 420);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Lưu";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			groupBox2.Controls.Add(ckbRandomHanhDong);
			groupBox2.Controls.Add(cbbKichBan);
			groupBox2.Controls.Add(label1);
			groupBox2.Controls.Add(btnQuanLyKichBan);
			groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			groupBox2.Location = new System.Drawing.Point(11, 324);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(420, 81);
			groupBox2.TabIndex = 7;
			groupBox2.TabStop = false;
			groupBox2.Text = "Tùy chọn kiểu tương tác";
			ckbRandomHanhDong.AutoSize = true;
			ckbRandomHanhDong.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbRandomHanhDong.Location = new System.Drawing.Point(19, 53);
			ckbRandomHanhDong.Name = "ckbRandomHanhDong";
			ckbRandomHanhDong.Size = new System.Drawing.Size(200, 20);
			ckbRandomHanhDong.TabIndex = 2;
			ckbRandomHanhDong.Text = "Random thứ tự các hành động";
			ckbRandomHanhDong.UseVisualStyleBackColor = true;
			cbbKichBan.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbKichBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbKichBan.DropDownWidth = 200;
			cbbKichBan.FormattingEnabled = true;
			cbbKichBan.Location = new System.Drawing.Point(115, 23);
			cbbKichBan.Name = "cbbKichBan";
			cbbKichBan.Size = new System.Drawing.Size(171, 24);
			cbbKichBan.TabIndex = 1;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 26);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(93, 16);
			label1.TabIndex = 0;
			label1.Text = "Chọn kịch bản:";
			btnQuanLyKichBan.Cursor = System.Windows.Forms.Cursors.Hand;
			btnQuanLyKichBan.Location = new System.Drawing.Point(292, 23);
			btnQuanLyKichBan.Name = "btnQuanLyKichBan";
			btnQuanLyKichBan.Size = new System.Drawing.Size(100, 25);
			btnQuanLyKichBan.TabIndex = 1;
			btnQuanLyKichBan.Text = "Quản lý kịch bản";
			btnQuanLyKichBan.UseSelectable = true;
			btnQuanLyKichBan.Click += new System.EventHandler(metroButton2_Click);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(16, 24);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(101, 16);
			label2.TabIndex = 3;
			label2.Text = "Kiểu đăng nhâ\u0323p:";
			ckbGetCookie.AutoSize = true;
			ckbGetCookie.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbGetCookie.Location = new System.Drawing.Point(19, 103);
			ckbGetCookie.Name = "ckbGetCookie";
			ckbGetCookie.Size = new System.Drawing.Size(177, 20);
			ckbGetCookie.TabIndex = 2;
			ckbGetCookie.Text = "Tự động lấy Token/Cookie";
			ckbGetCookie.UseVisualStyleBackColor = true;
			ckbRepeatAll.AutoSize = true;
			ckbRepeatAll.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbRepeatAll.Location = new System.Drawing.Point(19, 179);
			ckbRepeatAll.Name = "ckbRepeatAll";
			ckbRepeatAll.Size = new System.Drawing.Size(345, 20);
			ckbRepeatAll.TabIndex = 2;
			ckbRepeatAll.Text = "Chạy tương tác lại toàn bộ tài khoản sau khi hoàn thành";
			ckbRepeatAll.UseVisualStyleBackColor = true;
			ckbRepeatAll.CheckedChanged += new System.EventHandler(ckbRepeatAll_CheckedChanged);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(groupBox2);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(442, 462);
			panel1.TabIndex = 8;
			groupBox1.Controls.Add(panel2);
			groupBox1.Controls.Add(plRepeatAll);
			groupBox1.Controls.Add(ckbCheckLiveUid);
			groupBox1.Controls.Add(ckbUpdateInfo);
			groupBox1.Controls.Add(ckbGetCookie);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(ckbReloginIfLogout);
			groupBox1.Controls.Add(ckbRandomThuTuTaiKhoan);
			groupBox1.Controls.Add(ckbRepeatAll);
			groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75f);
			groupBox1.Location = new System.Drawing.Point(11, 44);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(420, 274);
			groupBox1.TabIndex = 8;
			groupBox1.TabStop = false;
			groupBox1.Text = "Tùy chọn";
			panel2.Controls.Add(rbLoginEmailPass);
			panel2.Controls.Add(rbLoginUidPass);
			panel2.Location = new System.Drawing.Point(134, 21);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(273, 26);
			panel2.TabIndex = 6;
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
			plRepeatAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plRepeatAll.Controls.Add(label6);
			plRepeatAll.Controls.Add(label4);
			plRepeatAll.Controls.Add(nudDelayTurnFrom);
			plRepeatAll.Controls.Add(label5);
			plRepeatAll.Controls.Add(nudDelayTurnTo);
			plRepeatAll.Controls.Add(label11);
			plRepeatAll.Controls.Add(nudSoLuotChay);
			plRepeatAll.Controls.Add(label10);
			plRepeatAll.Location = new System.Drawing.Point(39, 201);
			plRepeatAll.Name = "plRepeatAll";
			plRepeatAll.Size = new System.Drawing.Size(376, 64);
			plRepeatAll.TabIndex = 13;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(3, 6);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(84, 16);
			label6.TabIndex = 5;
			label6.Text = "Sô\u0301 lươ\u0323t cha\u0323y:";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(3, 34);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(145, 16);
			label4.TabIndex = 6;
			label4.Text = "Chờ cha\u0323y lươ\u0323t tiê\u0301p theo:";
			nudDelayTurnFrom.Location = new System.Drawing.Point(154, 32);
			nudDelayTurnFrom.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudDelayTurnFrom.Name = "nudDelayTurnFrom";
			nudDelayTurnFrom.Size = new System.Drawing.Size(65, 23);
			nudDelayTurnFrom.TabIndex = 9;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(222, 7);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(30, 16);
			label5.TabIndex = 10;
			label5.Text = "lươ\u0323t";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudDelayTurnTo.Location = new System.Drawing.Point(252, 32);
			nudDelayTurnTo.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudDelayTurnTo.Name = "nudDelayTurnTo";
			nudDelayTurnTo.Size = new System.Drawing.Size(65, 23);
			nudDelayTurnTo.TabIndex = 8;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(320, 35);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(33, 16);
			label11.TabIndex = 11;
			label11.Text = "phút";
			nudSoLuotChay.Location = new System.Drawing.Point(154, 4);
			nudSoLuotChay.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudSoLuotChay.Name = "nudSoLuotChay";
			nudSoLuotChay.Size = new System.Drawing.Size(65, 23);
			nudSoLuotChay.TabIndex = 7;
			label10.Location = new System.Drawing.Point(222, 35);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(29, 16);
			label10.TabIndex = 12;
			label10.Text = "đến";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbCheckLiveUid.AutoSize = true;
			ckbCheckLiveUid.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbCheckLiveUid.Location = new System.Drawing.Point(19, 51);
			ckbCheckLiveUid.Name = "ckbCheckLiveUid";
			ckbCheckLiveUid.Size = new System.Drawing.Size(193, 20);
			ckbCheckLiveUid.TabIndex = 2;
			ckbCheckLiveUid.Text = "Check Live Uid trước khi chạy";
			ckbCheckLiveUid.UseVisualStyleBackColor = true;
			ckbUpdateInfo.AutoSize = true;
			ckbUpdateInfo.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbUpdateInfo.Location = new System.Drawing.Point(19, 129);
			ckbUpdateInfo.Name = "ckbUpdateInfo";
			ckbUpdateInfo.Size = new System.Drawing.Size(363, 20);
			ckbUpdateInfo.TabIndex = 2;
			ckbUpdateInfo.Text = "Tư\u0323 đô\u0323ng câ\u0323p nhâ\u0323t thông tin ta\u0300i khoa\u0309n (Co\u0301 thê\u0309 la\u0300m Die Nick)";
			ckbUpdateInfo.UseVisualStyleBackColor = true;
			ckbReloginIfLogout.AutoSize = true;
			ckbReloginIfLogout.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbReloginIfLogout.Location = new System.Drawing.Point(19, 77);
			ckbReloginIfLogout.Name = "ckbReloginIfLogout";
			ckbReloginIfLogout.Size = new System.Drawing.Size(255, 20);
			ckbReloginIfLogout.TabIndex = 2;
			ckbReloginIfLogout.Text = "Tự động đăng nhập lại nếu bị đăng xuất";
			ckbReloginIfLogout.UseVisualStyleBackColor = true;
			ckbRandomThuTuTaiKhoan.AutoSize = true;
			ckbRandomThuTuTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbRandomThuTuTaiKhoan.Location = new System.Drawing.Point(19, 153);
			ckbRandomThuTuTaiKhoan.Name = "ckbRandomThuTuTaiKhoan";
			ckbRandomThuTuTaiKhoan.Size = new System.Drawing.Size(255, 20);
			ckbRandomThuTuTaiKhoan.TabIndex = 2;
			ckbRandomThuTuTaiKhoan.Text = "Xáo trộn thứ tự tài khoản trước khi chạy";
			ckbRandomThuTuTaiKhoan.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(442, 462);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fCauHinhTuongTac";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fCauHinhTuongTac_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			panel1.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			plRepeatAll.ResumeLayout(false);
			plRepeatAll.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuotChay).EndInit();
			ResumeLayout(false);
		}
	}
}
