using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;

namespace maxcare
{
	public class fDangBai_CauHinh : Form
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

		private GroupBox groupBox2;

		private Label label19;

		private Label label20;

		private NumericUpDown nudKhoangCachTo;

		private NumericUpDown nudKhoangCachFrom;

		private Label label18;

		private Label label17;

		private NumericUpDown nudSoLuongBaiTo;

		private NumericUpDown nudSoLuongBaiFrom;

		private Label label16;

		private Label label15;

		private Panel plVanBan;

		private LinkLabel linkLabel1;

		private Button button3;

		private Button button2;

		private RadioButton rbNganCachKyTu;

		private RadioButton rbNganCachMoiDong;

		private Label label9;

		private RichTextBox txtNoiDung;

		private Label label8;

		private Label lblStatus;

		private CheckBox ckbUseBackground;

		private CheckBox ckbAnh;

		private CheckBox ckbXoaNguyenLieuDaDung;

		private CheckBox ckbVanBan;

		private Label label12;

		private Label label13;

		private NumericUpDown nudSoLuongNhomTo;

		private NumericUpDown nudSoLuongNhomFrom;

		private Label label21;

		private CheckBox ckbChiDangNhomKKD;

		private GroupBox groupBox3;

		private Panel plDangNhom;

		private Panel plDangTuong;

		private CheckBox ckbDangNhom;

		private CheckBox ckbDangTuong;

		private Button btnNhapAnh;

		private Panel plAnh;

		private Label label1;

		private NumericUpDown nudSoAnhFrom;

		private NumericUpDown nudSoAnhTo;

		private Label label3;

		private Label label7;

		public fDangBai_CauHinh()
		{
			InitializeComponent();
			settings = new JSON_Settings("configDangBai");
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
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(label2);
			Language.GetValue(groupBox3);
			Language.GetValue(ckbDangTuong);
			Language.GetValue(label15);
			Language.GetValue(label17);
			Language.GetValue(label18);
			Language.GetValue(ckbDangNhom);
			Language.GetValue(label21);
			Language.GetValue(label13);
			Language.GetValue(label12);
			Language.GetValue(ckbChiDangNhomKKD);
			Language.GetValue(label16);
			Language.GetValue(label20);
			Language.GetValue(label19);
			Language.GetValue(ckbVanBan);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(ckbUseBackground);
			Language.GetValue(ckbXoaNguyenLieuDaDung);
			Language.GetValue(label9);
			Language.GetValue(rbNganCachMoiDong);
			Language.GetValue(rbNganCachKyTu);
			Language.GetValue(ckbAnh);
			Language.GetValue(btnNhapAnh);
			Language.GetValue(label1);
			Language.GetValue(label3);
			Language.GetValue(label7);
			Language.GetValue(ckbReloginIfLogout);
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
			settings.Update("ckbCheckLiveUid", ckbCheckLiveUid.Checked);
			settings.Update("ckbRepeatAll", ckbRepeatAll.Checked);
			settings.Update("nudDelayTurnFrom", nudDelayTurnFrom.Value);
			settings.Update("nudDelayTurnTo", nudDelayTurnTo.Value);
			settings.Update("nudSoLuotChay", nudSoLuotChay.Value);
			settings.Update("RepeatAllVIP", "false");
			settings.Update("ckbRandomThuTuTaiKhoan", ckbRandomThuTuTaiKhoan.Checked);
			settings.Update("ckbReloginIfLogout", ckbReloginIfLogout.Checked);
			settings.Update("ckbDangTuong", ckbDangTuong.Checked);
			settings.Update("nudSoLuongBaiFrom", nudSoLuongBaiFrom.Value);
			settings.Update("nudSoLuongBaiTo", nudSoLuongBaiTo.Value);
			settings.Update("ckbDangNhom", ckbDangNhom.Checked);
			settings.Update("nudSoLuongNhomFrom", nudSoLuongNhomFrom.Value);
			settings.Update("nudSoLuongNhomTo", nudSoLuongNhomTo.Value);
			settings.Update("ckbChiDangNhomKKD", ckbChiDangNhomKKD.Checked);
			settings.Update("nudKhoangCachFrom", nudKhoangCachFrom.Value);
			settings.Update("nudKhoangCachTo", nudKhoangCachTo.Value);
			settings.Update("ckbVanBan", ckbVanBan.Checked);
			settings.Update("txtNoiDung", txtNoiDung.Text.Trim());
			int num2 = 0;
			if (rbNganCachKyTu.Checked)
			{
				num2 = 1;
			}
			settings.Update("typeNganCach", num2);
			settings.Update("ckbUseBackground", ckbUseBackground.Checked);
			settings.Update("ckbAnh", ckbAnh.Checked);
			settings.Update("nudSoAnhFrom", nudSoAnhFrom.Value);
			settings.Update("nudSoAnhTo", nudSoAnhTo.Value);
			settings.Update("ckbXoaNguyenLieuDaDung", ckbXoaNguyenLieuDaDung.Checked);
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

		private void CheckedChangedFull()
		{
			ckbRepeatAll_CheckedChanged(null, null);
			ckbAnh_CheckedChanged(null, null);
			ckbVanBan_CheckedChanged(null, null);
			checkBox1_CheckedChanged(null, null);
			ckbDangNhom_CheckedChanged(null, null);
		}

		private void fCauHinhTuongTac_Load(object sender, EventArgs e)
		{
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
				ckbCheckLiveUid.Checked = settings.GetValueBool("ckbCheckLiveUid");
				ckbRepeatAll.Checked = settings.GetValueBool("ckbRepeatAll");
				nudDelayTurnFrom.Value = settings.GetValueInt("nudDelayTurnFrom");
				nudDelayTurnTo.Value = settings.GetValueInt("nudDelayTurnTo");
				nudSoLuotChay.Value = settings.GetValueInt("nudSoLuotChay");
				ckbRandomThuTuTaiKhoan.Checked = settings.GetValueBool("ckbRandomThuTuTaiKhoan");
				ckbReloginIfLogout.Checked = settings.GetValueBool("ckbReloginIfLogout");
				ckbDangTuong.Checked = settings.GetValueBool("ckbDangTuong");
				nudSoLuongBaiFrom.Value = settings.GetValueInt("nudSoLuongBaiFrom", 1);
				nudSoLuongBaiTo.Value = settings.GetValueInt("nudSoLuongBaiTo", 1);
				ckbDangNhom.Checked = settings.GetValueBool("ckbDangNhom");
				nudSoLuongNhomFrom.Value = settings.GetValueInt("nudSoLuongNhomFrom", 1);
				nudSoLuongNhomTo.Value = settings.GetValueInt("nudSoLuongNhomTo", 1);
				ckbChiDangNhomKKD.Checked = settings.GetValueBool("ckbChiDangNhomKKD");
				nudKhoangCachFrom.Value = settings.GetValueInt("nudKhoangCachFrom", 5);
				nudKhoangCachTo.Value = settings.GetValueInt("nudKhoangCachTo", 10);
				ckbVanBan.Checked = settings.GetValueBool("ckbVanBan");
				txtNoiDung.Text = settings.GetValue("txtNoiDung");
				if (settings.GetValueInt("typeNganCach") == 1)
				{
					rbNganCachKyTu.Checked = true;
				}
				else
				{
					rbNganCachMoiDong.Checked = true;
				}
				ckbUseBackground.Checked = settings.GetValueBool("ckbUseBackground");
				ckbAnh.Checked = settings.GetValueBool("ckbAnh");
				nudSoAnhFrom.Value = settings.GetValueInt("nudSoAnhFrom", 1);
				nudSoAnhTo.Value = settings.GetValueInt("nudSoAnhTo", 1);
				ckbXoaNguyenLieuDaDung.Checked = settings.GetValueBool("ckbXoaNguyenLieuDaDung");
			}
			catch
			{
			}
		}

		private void ckbRepeatAll_CheckedChanged(object sender, EventArgs e)
		{
			plRepeatAll.Enabled = ckbRepeatAll.Checked;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHelpNhapComment());
			txtNoiDung.Focus();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhập mỗi dòng là 1 nội dung!"));
			txtNoiDung.Focus();
		}

		private void rbNganCachKyTu_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void txtNoiDung_TextChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void UpdateSoLuongBinhLuan()
		{
			try
			{
				List<string> list = new List<string>();
				list = ((!rbNganCachMoiDong.Checked) ? txtNoiDung.Text.Split(new string[1] { "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).ToList() : txtNoiDung.Lines.ToList());
				list = MCommon.Common.RemoveEmptyItems(list);
				lblStatus.Text = string.Format(Language.GetValue("Danh sa\u0301ch nô\u0323i dung ({0}):"), list.Count.ToString());
			}
			catch
			{
			}
		}

		private void rbNganCachKyTu_CheckedChanged_1(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void ckbVanBan_CheckedChanged(object sender, EventArgs e)
		{
			plVanBan.Enabled = ckbVanBan.Checked;
		}

		private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MCommon.Common.ShowForm(new fHuongDanRandom());
		}

		private void ckbAnh_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbAnh.Checked)
			{
				ckbUseBackground.Checked = false;
			}
			plAnh.Enabled = ckbAnh.Checked;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			plDangTuong.Enabled = ckbDangTuong.Checked;
		}

		private void ckbDangNhom_CheckedChanged(object sender, EventArgs e)
		{
			plDangNhom.Enabled = ckbDangNhom.Checked;
		}

		private void btnNhapAnh_Click_1(object sender, EventArgs e)
		{
			string pathPictureLDPlayer = ConfigHelper.GetPathPictureLDPlayer();
			if (Directory.Exists(pathPictureLDPlayer))
			{
				Process.Start(pathPictureLDPlayer);
			}
		}

		private void ckbUseBackground_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbUseBackground.Checked)
			{
				ckbAnh.Checked = false;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fDangBai_CauHinh));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			label2 = new System.Windows.Forms.Label();
			ckbGetCookie = new System.Windows.Forms.CheckBox();
			ckbRepeatAll = new System.Windows.Forms.CheckBox();
			panel1 = new System.Windows.Forms.Panel();
			groupBox3 = new System.Windows.Forms.GroupBox();
			plDangNhom = new System.Windows.Forms.Panel();
			label21 = new System.Windows.Forms.Label();
			nudSoLuongNhomFrom = new System.Windows.Forms.NumericUpDown();
			nudSoLuongNhomTo = new System.Windows.Forms.NumericUpDown();
			label13 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			ckbChiDangNhomKKD = new System.Windows.Forms.CheckBox();
			plDangTuong = new System.Windows.Forms.Panel();
			label15 = new System.Windows.Forms.Label();
			nudSoLuongBaiFrom = new System.Windows.Forms.NumericUpDown();
			nudSoLuongBaiTo = new System.Windows.Forms.NumericUpDown();
			label17 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			ckbDangNhom = new System.Windows.Forms.CheckBox();
			ckbDangTuong = new System.Windows.Forms.CheckBox();
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
			ckbReloginIfLogout = new System.Windows.Forms.CheckBox();
			ckbRandomThuTuTaiKhoan = new System.Windows.Forms.CheckBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			plAnh = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			btnNhapAnh = new System.Windows.Forms.Button();
			nudSoAnhFrom = new System.Windows.Forms.NumericUpDown();
			nudSoAnhTo = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			nudKhoangCachTo = new System.Windows.Forms.NumericUpDown();
			nudKhoangCachFrom = new System.Windows.Forms.NumericUpDown();
			label16 = new System.Windows.Forms.Label();
			plVanBan = new System.Windows.Forms.Panel();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			rbNganCachKyTu = new System.Windows.Forms.RadioButton();
			rbNganCachMoiDong = new System.Windows.Forms.RadioButton();
			ckbXoaNguyenLieuDaDung = new System.Windows.Forms.CheckBox();
			label9 = new System.Windows.Forms.Label();
			txtNoiDung = new System.Windows.Forms.RichTextBox();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			ckbUseBackground = new System.Windows.Forms.CheckBox();
			ckbAnh = new System.Windows.Forms.CheckBox();
			ckbVanBan = new System.Windows.Forms.CheckBox();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			groupBox3.SuspendLayout();
			plDangNhom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongNhomFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongNhomTo).BeginInit();
			plDangTuong.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiTo).BeginInit();
			groupBox1.SuspendLayout();
			panel2.SuspendLayout();
			plRepeatAll.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuotChay).BeginInit();
			groupBox2.SuspendLayout();
			plAnh.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoAnhFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoAnhTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachFrom).BeginInit();
			plVanBan.SuspendLayout();
			SuspendLayout();
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
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
			bunifuCards1.Size = new System.Drawing.Size(1098, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1098, 32);
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
			btnMinimize.Location = new System.Drawing.Point(1064, -2);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(1098, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Cấu hình Đăng ba\u0300i";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(548, 458);
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
			btnAdd.Location = new System.Drawing.Point(444, 458);
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
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(16, 24);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(101, 16);
			label2.TabIndex = 3;
			label2.Text = "Kiểu đăng nhâ\u0323p:";
			ckbGetCookie.AutoSize = true;
			ckbGetCookie.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbGetCookie.Location = new System.Drawing.Point(225, 51);
			ckbGetCookie.Name = "ckbGetCookie";
			ckbGetCookie.Size = new System.Drawing.Size(177, 20);
			ckbGetCookie.TabIndex = 2;
			ckbGetCookie.Text = "Tự động lấy Token/Cookie";
			ckbGetCookie.UseVisualStyleBackColor = true;
			ckbRepeatAll.AutoSize = true;
			ckbRepeatAll.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbRepeatAll.Location = new System.Drawing.Point(19, 129);
			ckbRepeatAll.Name = "ckbRepeatAll";
			ckbRepeatAll.Size = new System.Drawing.Size(287, 20);
			ckbRepeatAll.TabIndex = 2;
			ckbRepeatAll.Text = "Chạy lại toàn bộ tài khoản sau khi hoàn thành";
			ckbRepeatAll.UseVisualStyleBackColor = true;
			ckbRepeatAll.CheckedChanged += new System.EventHandler(ckbRepeatAll_CheckedChanged);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(groupBox3);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(groupBox2);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1100, 501);
			panel1.TabIndex = 8;
			groupBox3.Controls.Add(plDangNhom);
			groupBox3.Controls.Add(plDangTuong);
			groupBox3.Controls.Add(ckbDangNhom);
			groupBox3.Controls.Add(ckbDangTuong);
			groupBox3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			groupBox3.Location = new System.Drawing.Point(11, 275);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(420, 170);
			groupBox3.TabIndex = 9;
			groupBox3.TabStop = false;
			groupBox3.Text = "Tu\u0300y cho\u0323n Đăng ba\u0300i";
			plDangNhom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plDangNhom.Controls.Add(label21);
			plDangNhom.Controls.Add(nudSoLuongNhomFrom);
			plDangNhom.Controls.Add(nudSoLuongNhomTo);
			plDangNhom.Controls.Add(label13);
			plDangNhom.Controls.Add(label12);
			plDangNhom.Controls.Add(ckbChiDangNhomKKD);
			plDangNhom.Location = new System.Drawing.Point(39, 101);
			plDangNhom.Name = "plDangNhom";
			plDangNhom.Size = new System.Drawing.Size(363, 60);
			plDangNhom.TabIndex = 1;
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(3, 9);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(100, 16);
			label21.TabIndex = 45;
			label21.Text = "Số lượng nho\u0301m:";
			nudSoLuongNhomFrom.Location = new System.Drawing.Point(124, 5);
			nudSoLuongNhomFrom.Name = "nudSoLuongNhomFrom";
			nudSoLuongNhomFrom.Size = new System.Drawing.Size(51, 23);
			nudSoLuongNhomFrom.TabIndex = 47;
			nudSoLuongNhomTo.Location = new System.Drawing.Point(209, 5);
			nudSoLuongNhomTo.Name = "nudSoLuongNhomTo";
			nudSoLuongNhomTo.Size = new System.Drawing.Size(51, 23);
			nudSoLuongNhomTo.TabIndex = 48;
			label13.Location = new System.Drawing.Point(178, 9);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(29, 16);
			label13.TabIndex = 49;
			label13.Text = "đến";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(264, 9);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(40, 16);
			label12.TabIndex = 50;
			label12.Text = "nho\u0301m";
			ckbChiDangNhomKKD.AutoSize = true;
			ckbChiDangNhomKKD.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbChiDangNhomKKD.Location = new System.Drawing.Point(6, 34);
			ckbChiDangNhomKKD.Name = "ckbChiDangNhomKKD";
			ckbChiDangNhomKKD.Size = new System.Drawing.Size(217, 20);
			ckbChiDangNhomKKD.TabIndex = 44;
			ckbChiDangNhomKKD.Text = "Chi\u0309 đăng nho\u0301m không kiê\u0309m duyê\u0323t";
			ckbChiDangNhomKKD.UseVisualStyleBackColor = true;
			plDangTuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plDangTuong.Controls.Add(label15);
			plDangTuong.Controls.Add(nudSoLuongBaiFrom);
			plDangTuong.Controls.Add(nudSoLuongBaiTo);
			plDangTuong.Controls.Add(label17);
			plDangTuong.Controls.Add(label18);
			plDangTuong.Location = new System.Drawing.Point(39, 43);
			plDangTuong.Name = "plDangTuong";
			plDangTuong.Size = new System.Drawing.Size(363, 31);
			plDangTuong.TabIndex = 1;
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(3, 6);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(109, 16);
			label15.TabIndex = 49;
			label15.Text = "Số lượng bài viết:";
			nudSoLuongBaiFrom.Location = new System.Drawing.Point(124, 3);
			nudSoLuongBaiFrom.Name = "nudSoLuongBaiFrom";
			nudSoLuongBaiFrom.Size = new System.Drawing.Size(51, 23);
			nudSoLuongBaiFrom.TabIndex = 51;
			nudSoLuongBaiTo.Location = new System.Drawing.Point(209, 3);
			nudSoLuongBaiTo.Name = "nudSoLuongBaiTo";
			nudSoLuongBaiTo.Size = new System.Drawing.Size(51, 23);
			nudSoLuongBaiTo.TabIndex = 52;
			label17.Location = new System.Drawing.Point(178, 6);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(29, 16);
			label17.TabIndex = 53;
			label17.Text = "đến";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(264, 6);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(25, 16);
			label18.TabIndex = 54;
			label18.Text = "bài";
			ckbDangNhom.AutoSize = true;
			ckbDangNhom.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbDangNhom.Location = new System.Drawing.Point(19, 78);
			ckbDangNhom.Name = "ckbDangNhom";
			ckbDangNhom.Size = new System.Drawing.Size(135, 20);
			ckbDangNhom.TabIndex = 0;
			ckbDangNhom.Text = "Đăng ba\u0300i lên nho\u0301m";
			ckbDangNhom.UseVisualStyleBackColor = true;
			ckbDangNhom.CheckedChanged += new System.EventHandler(ckbDangNhom_CheckedChanged);
			ckbDangTuong.AutoSize = true;
			ckbDangTuong.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbDangTuong.Location = new System.Drawing.Point(19, 23);
			ckbDangTuong.Name = "ckbDangTuong";
			ckbDangTuong.Size = new System.Drawing.Size(136, 20);
			ckbDangTuong.TabIndex = 0;
			ckbDangTuong.Text = "Đăng ba\u0300i lên tươ\u0300ng";
			ckbDangTuong.UseVisualStyleBackColor = true;
			ckbDangTuong.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
			groupBox1.Controls.Add(panel2);
			groupBox1.Controls.Add(plRepeatAll);
			groupBox1.Controls.Add(ckbCheckLiveUid);
			groupBox1.Controls.Add(ckbGetCookie);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(ckbReloginIfLogout);
			groupBox1.Controls.Add(ckbRandomThuTuTaiKhoan);
			groupBox1.Controls.Add(ckbRepeatAll);
			groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75f);
			groupBox1.Location = new System.Drawing.Point(11, 44);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(420, 224);
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
			plRepeatAll.Location = new System.Drawing.Point(39, 151);
			plRepeatAll.Name = "plRepeatAll";
			plRepeatAll.Size = new System.Drawing.Size(363, 64);
			plRepeatAll.TabIndex = 13;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(3, 6);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(84, 16);
			label6.TabIndex = 5;
			label6.Text = "Sô\u0301 lươ\u0323t cha\u0323y:";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(3, 35);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(145, 16);
			label4.TabIndex = 6;
			label4.Text = "Chờ cha\u0323y lươ\u0323t tiê\u0301p theo:";
			nudDelayTurnFrom.Location = new System.Drawing.Point(154, 33);
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
			nudDelayTurnTo.Location = new System.Drawing.Point(252, 33);
			nudDelayTurnTo.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudDelayTurnTo.Name = "nudDelayTurnTo";
			nudDelayTurnTo.Size = new System.Drawing.Size(65, 23);
			nudDelayTurnTo.TabIndex = 8;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(320, 36);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(33, 16);
			label11.TabIndex = 11;
			label11.Text = "phút";
			nudSoLuotChay.Location = new System.Drawing.Point(154, 4);
			nudSoLuotChay.Maximum = new decimal(new int[4] { 276447231, 23283, 0, 0 });
			nudSoLuotChay.Name = "nudSoLuotChay";
			nudSoLuotChay.Size = new System.Drawing.Size(65, 23);
			nudSoLuotChay.TabIndex = 7;
			label10.Location = new System.Drawing.Point(222, 36);
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
			ckbRandomThuTuTaiKhoan.Location = new System.Drawing.Point(19, 103);
			ckbRandomThuTuTaiKhoan.Name = "ckbRandomThuTuTaiKhoan";
			ckbRandomThuTuTaiKhoan.Size = new System.Drawing.Size(255, 20);
			ckbRandomThuTuTaiKhoan.TabIndex = 2;
			ckbRandomThuTuTaiKhoan.Text = "Xáo trộn thứ tự tài khoản trước khi chạy";
			ckbRandomThuTuTaiKhoan.UseVisualStyleBackColor = true;
			groupBox2.Controls.Add(plAnh);
			groupBox2.Controls.Add(label19);
			groupBox2.Controls.Add(label20);
			groupBox2.Controls.Add(nudKhoangCachTo);
			groupBox2.Controls.Add(nudKhoangCachFrom);
			groupBox2.Controls.Add(label16);
			groupBox2.Controls.Add(plVanBan);
			groupBox2.Controls.Add(ckbAnh);
			groupBox2.Controls.Add(ckbVanBan);
			groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			groupBox2.Location = new System.Drawing.Point(445, 44);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(641, 401);
			groupBox2.TabIndex = 7;
			groupBox2.TabStop = false;
			groupBox2.Text = "Câ\u0301u hi\u0300nh cha\u0323y";
			plAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plAnh.Controls.Add(label1);
			plAnh.Controls.Add(btnNhapAnh);
			plAnh.Controls.Add(nudSoAnhFrom);
			plAnh.Controls.Add(nudSoAnhTo);
			plAnh.Controls.Add(label3);
			plAnh.Controls.Add(label7);
			plAnh.Location = new System.Drawing.Point(34, 360);
			plAnh.Name = "plAnh";
			plAnh.Size = new System.Drawing.Size(597, 32);
			plAnh.TabIndex = 1;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(100, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(75, 16);
			label1.TabIndex = 45;
			label1.Text = "Số a\u0309nh/ba\u0300i:";
			btnNhapAnh.Cursor = System.Windows.Forms.Cursors.Hand;
			btnNhapAnh.Location = new System.Drawing.Point(6, 3);
			btnNhapAnh.Name = "btnNhapAnh";
			btnNhapAnh.Size = new System.Drawing.Size(76, 25);
			btnNhapAnh.TabIndex = 59;
			btnNhapAnh.Text = "Nhâ\u0323p a\u0309nh";
			btnNhapAnh.UseVisualStyleBackColor = true;
			btnNhapAnh.Click += new System.EventHandler(btnNhapAnh_Click_1);
			nudSoAnhFrom.Location = new System.Drawing.Point(187, 4);
			nudSoAnhFrom.Name = "nudSoAnhFrom";
			nudSoAnhFrom.Size = new System.Drawing.Size(51, 23);
			nudSoAnhFrom.TabIndex = 47;
			nudSoAnhTo.Location = new System.Drawing.Point(272, 4);
			nudSoAnhTo.Name = "nudSoAnhTo";
			nudSoAnhTo.Size = new System.Drawing.Size(51, 23);
			nudSoAnhTo.TabIndex = 48;
			label3.Location = new System.Drawing.Point(241, 8);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 16);
			label3.TabIndex = 49;
			label3.Text = "đến";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(327, 8);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 50;
			label7.Text = "a\u0309nh";
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(278, 24);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(31, 16);
			label19.TabIndex = 58;
			label19.Text = "giây";
			label20.Location = new System.Drawing.Point(192, 24);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(29, 16);
			label20.TabIndex = 57;
			label20.Text = "đến";
			label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudKhoangCachTo.Location = new System.Drawing.Point(223, 22);
			nudKhoangCachTo.Name = "nudKhoangCachTo";
			nudKhoangCachTo.Size = new System.Drawing.Size(51, 23);
			nudKhoangCachTo.TabIndex = 56;
			nudKhoangCachFrom.Location = new System.Drawing.Point(138, 22);
			nudKhoangCachFrom.Name = "nudKhoangCachFrom";
			nudKhoangCachFrom.Size = new System.Drawing.Size(51, 23);
			nudKhoangCachFrom.TabIndex = 55;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(17, 24);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(117, 16);
			label16.TabIndex = 50;
			label16.Text = "Khoảng cách đăng:";
			plVanBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plVanBan.Controls.Add(linkLabel1);
			plVanBan.Controls.Add(button3);
			plVanBan.Controls.Add(button2);
			plVanBan.Controls.Add(rbNganCachKyTu);
			plVanBan.Controls.Add(rbNganCachMoiDong);
			plVanBan.Controls.Add(ckbXoaNguyenLieuDaDung);
			plVanBan.Controls.Add(label9);
			plVanBan.Controls.Add(txtNoiDung);
			plVanBan.Controls.Add(label8);
			plVanBan.Controls.Add(lblStatus);
			plVanBan.Controls.Add(ckbUseBackground);
			plVanBan.Location = new System.Drawing.Point(34, 71);
			plVanBan.Name = "plVanBan";
			plVanBan.Size = new System.Drawing.Size(597, 262);
			plVanBan.TabIndex = 47;
			linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			linkLabel1.AutoSize = true;
			linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel1.Location = new System.Drawing.Point(154, 212);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(82, 16);
			linkLabel1.TabIndex = 195;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Random icon";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked_1);
			button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			button3.Cursor = System.Windows.Forms.Cursors.Help;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Location = new System.Drawing.Point(571, 234);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(21, 23);
			button3.TabIndex = 193;
			button3.Text = "?";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			button2.Cursor = System.Windows.Forms.Cursors.Help;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(571, 211);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(21, 23);
			button2.TabIndex = 194;
			button2.Text = "?";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			rbNganCachKyTu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			rbNganCachKyTu.AutoSize = true;
			rbNganCachKyTu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachKyTu.Location = new System.Drawing.Point(412, 235);
			rbNganCachKyTu.Name = "rbNganCachKyTu";
			rbNganCachKyTu.Size = new System.Drawing.Size(160, 20);
			rbNganCachKyTu.TabIndex = 37;
			rbNganCachKyTu.Text = "Nội dung có nhiều dòng";
			rbNganCachKyTu.UseVisualStyleBackColor = true;
			rbNganCachKyTu.CheckedChanged += new System.EventHandler(rbNganCachKyTu_CheckedChanged_1);
			rbNganCachMoiDong.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			rbNganCachMoiDong.AutoSize = true;
			rbNganCachMoiDong.Checked = true;
			rbNganCachMoiDong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachMoiDong.Location = new System.Drawing.Point(412, 213);
			rbNganCachMoiDong.Name = "rbNganCachMoiDong";
			rbNganCachMoiDong.Size = new System.Drawing.Size(156, 20);
			rbNganCachMoiDong.TabIndex = 36;
			rbNganCachMoiDong.TabStop = true;
			rbNganCachMoiDong.Text = "Nội dung chỉ có 1 dòng";
			rbNganCachMoiDong.UseVisualStyleBackColor = true;
			rbNganCachMoiDong.CheckedChanged += new System.EventHandler(rbNganCachKyTu_CheckedChanged);
			ckbXoaNguyenLieuDaDung.AutoSize = true;
			ckbXoaNguyenLieuDaDung.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbXoaNguyenLieuDaDung.Location = new System.Drawing.Point(157, 235);
			ckbXoaNguyenLieuDaDung.Name = "ckbXoaNguyenLieuDaDung";
			ckbXoaNguyenLieuDaDung.Size = new System.Drawing.Size(152, 20);
			ckbXoaNguyenLieuDaDung.TabIndex = 45;
			ckbXoaNguyenLieuDaDung.Text = "Xóa nội dung đã đăng";
			ckbXoaNguyenLieuDaDung.UseVisualStyleBackColor = true;
			label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(347, 213);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(65, 16);
			label9.TabIndex = 35;
			label9.Text = "Tùy chọn:";
			txtNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtNoiDung.Location = new System.Drawing.Point(7, 24);
			txtNoiDung.Name = "txtNoiDung";
			txtNoiDung.Size = new System.Drawing.Size(585, 186);
			txtNoiDung.TabIndex = 34;
			txtNoiDung.Text = "";
			txtNoiDung.WordWrap = false;
			txtNoiDung.TextChanged += new System.EventHandler(txtNoiDung_TextChanged);
			label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 212);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(144, 16);
			label8.TabIndex = 0;
			label8.Text = "(Spin nội dung {a|b|c})";
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 5);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(146, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Danh sa\u0301ch nô\u0323i dung (0):";
			ckbUseBackground.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			ckbUseBackground.AutoSize = true;
			ckbUseBackground.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbUseBackground.Location = new System.Drawing.Point(6, 235);
			ckbUseBackground.Name = "ckbUseBackground";
			ckbUseBackground.Size = new System.Drawing.Size(145, 20);
			ckbUseBackground.TabIndex = 32;
			ckbUseBackground.Text = "Sử dụng Background";
			ckbUseBackground.UseVisualStyleBackColor = true;
			ckbUseBackground.CheckedChanged += new System.EventHandler(ckbUseBackground_CheckedChanged);
			ckbAnh.AutoSize = true;
			ckbAnh.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbAnh.Location = new System.Drawing.Point(20, 339);
			ckbAnh.Name = "ckbAnh";
			ckbAnh.Size = new System.Drawing.Size(49, 20);
			ckbAnh.TabIndex = 44;
			ckbAnh.Text = "A\u0309nh";
			ckbAnh.UseVisualStyleBackColor = true;
			ckbAnh.CheckedChanged += new System.EventHandler(ckbAnh_CheckedChanged);
			ckbVanBan.AutoSize = true;
			ckbVanBan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbVanBan.Location = new System.Drawing.Point(20, 47);
			ckbVanBan.Name = "ckbVanBan";
			ckbVanBan.Size = new System.Drawing.Size(74, 20);
			ckbVanBan.TabIndex = 46;
			ckbVanBan.Text = "Văn ba\u0309n";
			ckbVanBan.UseVisualStyleBackColor = true;
			ckbVanBan.CheckedChanged += new System.EventHandler(ckbVanBan_CheckedChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1100, 501);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fDangBai_CauHinh";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fCauHinhTuongTac_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			plDangNhom.ResumeLayout(false);
			plDangNhom.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongNhomFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongNhomTo).EndInit();
			plDangTuong.ResumeLayout(false);
			plDangTuong.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiTo).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			plRepeatAll.ResumeLayout(false);
			plRepeatAll.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuotChay).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			plAnh.ResumeLayout(false);
			plAnh.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoAnhFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoAnhTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachFrom).EndInit();
			plVanBan.ResumeLayout(false);
			plVanBan.PerformLayout();
			ResumeLayout(false);
		}
	}
}
