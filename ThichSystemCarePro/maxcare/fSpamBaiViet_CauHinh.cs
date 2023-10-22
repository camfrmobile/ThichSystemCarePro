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
	public class fSpamBaiViet_CauHinh : Form
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

		private Label label1;

		private RadioButton rbPage;

		private RadioButton rbGroup;

		private RadioButton rbUser;

		private Panel plInteract;

		private Label label25;

		private Label label26;

		private Label label28;

		private Label label29;

		private Label label30;

		private CheckBox ckbGian;

		private CheckBox ckbBuon;

		private CheckBox ckbWow;

		private CheckBox ckbHaha;

		private CheckBox ckbTym;

		private CheckBox ckbLike;

		private Label label32;

		private CheckBox ckbInteract;

		private Panel plComment;

		private LinkLabel linkLabel1;

		private Button button3;

		private Button button2;

		private RadioButton rbNganCachKyTu;

		private RadioButton rbNganCachMoiDong;

		private Label label9;

		private RichTextBox txtComment;

		private Label label8;

		private Label lblStatus;

		private CheckBox ckbSendAnh;

		private RichTextBox txtUid;

		private Label label3;

		private Label label49;

		private NumericUpDown nudSoLuongUidFrom;

		private Label label68;

		private Label label19;

		private NumericUpDown nudSoLuongUidTo;

		private Label label66;

		private CheckBox ckbComment;

		private CheckBox ckbTuDongXoaUid;

		private NumericUpDown nudDelayTo;

		private NumericUpDown nudSoLuongBaiVietTo;

		private NumericUpDown nudDelayFrom;

		private NumericUpDown nudSoLuongBaiVietFrom;

		private Label label7;

		private Label label13;

		private Label label14;

		private Label label15;

		private Label label16;

		private Button btnNhapAnh;

		public fSpamBaiViet_CauHinh()
		{
			InitializeComponent();
			settings = new JSON_Settings("configSpamBaiViet");
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
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(label2);
			Language.GetValue(label3);
			Language.GetValue(ckbTuDongXoaUid);
			Language.GetValue(label49);
			Language.GetValue(label66);
			Language.GetValue(label19);
			Language.GetValue(label13);
			Language.GetValue(label15);
			Language.GetValue(label16);
			Language.GetValue(label7);
			Language.GetValue(label14);
			Language.GetValue(ckbInteract);
			Language.GetValue(label30);
			Language.GetValue(label32);
			Language.GetValue(label26);
			Language.GetValue(ckbComment);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(label9);
			Language.GetValue(rbNganCachMoiDong);
			Language.GetValue(rbNganCachKyTu);
			Language.GetValue(ckbSendAnh);
			Language.GetValue(btnNhapAnh);
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
			List<string> lst = txtUid.Lines.ToList();
			lst = MCommon.Common.RemoveEmptyItems(lst);
			if (lst.Count == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p danh sa\u0301ch ID!"), 3);
				return;
			}
			if (ckbComment.Checked)
			{
				List<string> lst2 = txtComment.Lines.ToList();
				lst2 = MCommon.Common.RemoveEmptyItems(lst2);
				if (lst2.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p nô\u0323i dung bi\u0300nh luâ\u0323n!"), 3);
					return;
				}
			}
			settings.Update("nudSoLuongUidFrom", nudSoLuongUidFrom.Value);
			settings.Update("nudSoLuongUidTo", nudSoLuongUidTo.Value);
			settings.Update("nudSoLuongBaiVietFrom", nudSoLuongBaiVietFrom.Value);
			settings.Update("nudSoLuongBaiVietTo", nudSoLuongBaiVietTo.Value);
			settings.Update("nudDelayFrom", nudDelayFrom.Value);
			settings.Update("nudDelayTo", nudDelayTo.Value);
			int num2 = 0;
			if (rbGroup.Checked)
			{
				num2 = 1;
			}
			if (rbPage.Checked)
			{
				num2 = 2;
			}
			settings.Update("typeID", num2);
			settings.Update("txtUid", txtUid.Text.Trim());
			settings.Update("ckbInteract", ckbInteract.Checked);
			string text = "";
			List<CheckBox> list = new List<CheckBox> { ckbLike, ckbTym, ckbHaha, ckbWow, ckbBuon, ckbGian };
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Checked)
				{
					text += i;
				}
			}
			settings.Update("typeReaction", text);
			settings.Update("ckbComment", ckbComment.Checked);
			settings.Update("txtComment", txtComment.Text.Trim());
			settings.Update("ckbSendAnh", ckbSendAnh.Checked);
			settings.Update("ckbTuDongXoaUid", ckbTuDongXoaUid.Checked);
			int num3 = 0;
			if (rbNganCachKyTu.Checked)
			{
				num3 = 1;
			}
			settings.Update("typeNganCach", num3);
			settings.Update("ckbSendAnh", ckbSendAnh.Checked);
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
			ckbInteract_CheckedChanged(null, null);
			ckbComment_CheckedChanged(null, null);
			ckbSendAnh_CheckedChanged(null, null);
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
				nudSoLuongUidFrom.Value = settings.GetValueInt("nudSoLuongUidFrom", 1);
				nudSoLuongUidTo.Value = settings.GetValueInt("nudSoLuongUidTo", 1);
				nudSoLuongBaiVietFrom.Value = settings.GetValueInt("nudSoLuongBaiVietFrom", 1);
				nudSoLuongBaiVietTo.Value = settings.GetValueInt("nudSoLuongBaiVietTo", 1);
				nudDelayFrom.Value = settings.GetValueInt("nudDelayFrom", 3);
				nudDelayTo.Value = settings.GetValueInt("nudDelayTo", 5);
				switch (settings.GetValueInt("typeID"))
				{
				case 0:
					rbUser.Checked = true;
					break;
				case 1:
					rbGroup.Checked = true;
					break;
				case 2:
					rbPage.Checked = true;
					break;
				}
				txtUid.Text = settings.GetValue("txtUid");
				ckbInteract.Checked = settings.GetValueBool("ckbInteract");
				string value = settings.GetValue("typeReaction");
				List<CheckBox> list = new List<CheckBox> { ckbLike, ckbTym, ckbHaha, ckbWow, ckbBuon, ckbGian };
				for (int i = 0; i < list.Count; i++)
				{
					if (value.Contains(i.ToString()))
					{
						list[i].Checked = true;
					}
				}
				ckbComment.Checked = settings.GetValueBool("ckbComment");
				txtComment.Text = settings.GetValue("txtComment");
				ckbSendAnh.Checked = settings.GetValueBool("ckbSendAnh");
				ckbTuDongXoaUid.Checked = settings.GetValueBool("ckbTuDongXoaUid");
				if (settings.GetValueInt("typeNganCach") == 1)
				{
					rbNganCachKyTu.Checked = true;
				}
				else
				{
					rbNganCachMoiDong.Checked = true;
				}
			}
			catch
			{
			}
		}

		private void ckbRepeatAll_CheckedChanged(object sender, EventArgs e)
		{
			plRepeatAll.Enabled = ckbRepeatAll.Checked;
		}

		private void txtUid_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtUid.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				label3.Text = string.Format(Language.GetValue("Nhập danh sách ID User/Group/Page ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void ckbSendAnh_CheckedChanged(object sender, EventArgs e)
		{
			btnNhapAnh.Enabled = ckbSendAnh.Checked;
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
		{
			plInteract.Enabled = ckbInteract.Checked;
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
			plComment.Enabled = ckbComment.Checked;
		}

		private void rbNganCachMoiDong_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHelpNhapComment());
			txtComment.Focus();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhập mỗi dòng là 1 nội dung!"));
			txtComment.Focus();
		}

		private void rbNganCachKyTu_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void txtComment_TextChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void UpdateSoLuongBinhLuan()
		{
			try
			{
				List<string> list = new List<string>();
				list = ((!rbNganCachMoiDong.Checked) ? txtComment.Text.Split(new string[1] { "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).ToList() : txtComment.Lines.ToList());
				list = MCommon.Common.RemoveEmptyItems(list);
				lblStatus.Text = string.Format(Language.GetValue("Nội dung bình luận ({0}):"), list.Count.ToString());
			}
			catch
			{
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MCommon.Common.ShowForm(new fHuongDanRandom());
		}

		private void btnNhapAnh_Click(object sender, EventArgs e)
		{
			string pathPictureLDPlayer = ConfigHelper.GetPathPictureLDPlayer();
			if (Directory.Exists(pathPictureLDPlayer))
			{
				Process.Start(pathPictureLDPlayer);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fSpamBaiViet_CauHinh));
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
			btnNhapAnh = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			plInteract = new System.Windows.Forms.Panel();
			label25 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			label30 = new System.Windows.Forms.Label();
			ckbGian = new System.Windows.Forms.CheckBox();
			ckbBuon = new System.Windows.Forms.CheckBox();
			ckbWow = new System.Windows.Forms.CheckBox();
			ckbHaha = new System.Windows.Forms.CheckBox();
			ckbTym = new System.Windows.Forms.CheckBox();
			ckbLike = new System.Windows.Forms.CheckBox();
			label32 = new System.Windows.Forms.Label();
			ckbInteract = new System.Windows.Forms.CheckBox();
			rbPage = new System.Windows.Forms.RadioButton();
			plComment = new System.Windows.Forms.Panel();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			rbNganCachKyTu = new System.Windows.Forms.RadioButton();
			rbNganCachMoiDong = new System.Windows.Forms.RadioButton();
			label9 = new System.Windows.Forms.Label();
			txtComment = new System.Windows.Forms.RichTextBox();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			rbUser = new System.Windows.Forms.RadioButton();
			rbGroup = new System.Windows.Forms.RadioButton();
			ckbSendAnh = new System.Windows.Forms.CheckBox();
			label49 = new System.Windows.Forms.Label();
			txtUid = new System.Windows.Forms.RichTextBox();
			label16 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			ckbComment = new System.Windows.Forms.CheckBox();
			label14 = new System.Windows.Forms.Label();
			ckbTuDongXoaUid = new System.Windows.Forms.CheckBox();
			label13 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			nudSoLuongUidTo = new System.Windows.Forms.NumericUpDown();
			nudSoLuongBaiVietFrom = new System.Windows.Forms.NumericUpDown();
			label68 = new System.Windows.Forms.Label();
			nudDelayFrom = new System.Windows.Forms.NumericUpDown();
			label66 = new System.Windows.Forms.Label();
			nudSoLuongBaiVietTo = new System.Windows.Forms.NumericUpDown();
			nudSoLuongUidFrom = new System.Windows.Forms.NumericUpDown();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			groupBox1.SuspendLayout();
			panel2.SuspendLayout();
			plRepeatAll.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuotChay).BeginInit();
			groupBox2.SuspendLayout();
			plInteract.SuspendLayout();
			plComment.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
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
			bunifuCards1.Size = new System.Drawing.Size(1090, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1090, 32);
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
			btnMinimize.Location = new System.Drawing.Point(1056, -2);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(1090, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Cấu hình Spam ba\u0300i viê\u0301t";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(548, 423);
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
			btnAdd.Location = new System.Drawing.Point(444, 423);
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
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(groupBox2);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1092, 466);
			panel1.TabIndex = 8;
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
			plRepeatAll.Size = new System.Drawing.Size(376, 64);
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
			label5.Location = new System.Drawing.Point(222, 7);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(44, 16);
			label5.TabIndex = 10;
			label5.Text = "lươ\u0323t";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			groupBox2.Controls.Add(btnNhapAnh);
			groupBox2.Controls.Add(label1);
			groupBox2.Controls.Add(plInteract);
			groupBox2.Controls.Add(ckbInteract);
			groupBox2.Controls.Add(rbPage);
			groupBox2.Controls.Add(plComment);
			groupBox2.Controls.Add(rbUser);
			groupBox2.Controls.Add(rbGroup);
			groupBox2.Controls.Add(ckbSendAnh);
			groupBox2.Controls.Add(label49);
			groupBox2.Controls.Add(txtUid);
			groupBox2.Controls.Add(label16);
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(label15);
			groupBox2.Controls.Add(ckbComment);
			groupBox2.Controls.Add(label14);
			groupBox2.Controls.Add(ckbTuDongXoaUid);
			groupBox2.Controls.Add(label13);
			groupBox2.Controls.Add(label19);
			groupBox2.Controls.Add(label7);
			groupBox2.Controls.Add(nudSoLuongUidTo);
			groupBox2.Controls.Add(nudSoLuongBaiVietFrom);
			groupBox2.Controls.Add(label68);
			groupBox2.Controls.Add(nudDelayFrom);
			groupBox2.Controls.Add(label66);
			groupBox2.Controls.Add(nudSoLuongBaiVietTo);
			groupBox2.Controls.Add(nudSoLuongUidFrom);
			groupBox2.Controls.Add(nudDelayTo);
			groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			groupBox2.Location = new System.Drawing.Point(444, 44);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(637, 368);
			groupBox2.TabIndex = 7;
			groupBox2.TabStop = false;
			groupBox2.Text = "Câ\u0301u hi\u0300nh cha\u0323y";
			btnNhapAnh.Cursor = System.Windows.Forms.Cursors.Hand;
			btnNhapAnh.Location = new System.Drawing.Point(473, 334);
			btnNhapAnh.Name = "btnNhapAnh";
			btnNhapAnh.Size = new System.Drawing.Size(76, 25);
			btnNhapAnh.TabIndex = 0;
			btnNhapAnh.Text = "Nhâ\u0323p a\u0309nh";
			btnNhapAnh.UseVisualStyleBackColor = true;
			btnNhapAnh.Click += new System.EventHandler(btnNhapAnh_Click);
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(9, 255);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(60, 16);
			label1.TabIndex = 204;
			label1.Text = "Loại ID : ";
			plInteract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plInteract.Controls.Add(label25);
			plInteract.Controls.Add(label26);
			plInteract.Controls.Add(label28);
			plInteract.Controls.Add(label29);
			plInteract.Controls.Add(label30);
			plInteract.Controls.Add(ckbGian);
			plInteract.Controls.Add(ckbBuon);
			plInteract.Controls.Add(ckbWow);
			plInteract.Controls.Add(ckbHaha);
			plInteract.Controls.Add(ckbTym);
			plInteract.Controls.Add(ckbLike);
			plInteract.Controls.Add(label32);
			plInteract.Location = new System.Drawing.Point(347, 43);
			plInteract.Name = "plInteract";
			plInteract.Size = new System.Drawing.Size(282, 40);
			plInteract.TabIndex = 200;
			label25.Cursor = System.Windows.Forms.Cursors.Hand;
			label25.Location = new System.Drawing.Point(4, 1);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(30, 16);
			label25.TabIndex = 0;
			label25.Text = "Like";
			label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label26.Cursor = System.Windows.Forms.Cursors.Hand;
			label26.Location = new System.Drawing.Point(48, 1);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(39, 16);
			label26.TabIndex = 2;
			label26.Text = "Tym";
			label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label28.Cursor = System.Windows.Forms.Cursors.Hand;
			label28.Location = new System.Drawing.Point(93, 1);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(37, 16);
			label28.TabIndex = 6;
			label28.Text = "Haha";
			label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label29.Cursor = System.Windows.Forms.Cursors.Hand;
			label29.Location = new System.Drawing.Point(140, 1);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(37, 16);
			label29.TabIndex = 8;
			label29.Text = "Wow";
			label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label30.Cursor = System.Windows.Forms.Cursors.Hand;
			label30.Location = new System.Drawing.Point(187, 1);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(36, 16);
			label30.TabIndex = 10;
			label30.Text = "Buồn";
			label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbGian.AutoSize = true;
			ckbGian.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbGian.Location = new System.Drawing.Point(246, 20);
			ckbGian.Name = "ckbGian";
			ckbGian.Size = new System.Drawing.Size(15, 14);
			ckbGian.TabIndex = 13;
			ckbGian.UseVisualStyleBackColor = true;
			ckbBuon.AutoSize = true;
			ckbBuon.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbBuon.Location = new System.Drawing.Point(199, 20);
			ckbBuon.Name = "ckbBuon";
			ckbBuon.Size = new System.Drawing.Size(15, 14);
			ckbBuon.TabIndex = 11;
			ckbBuon.UseVisualStyleBackColor = true;
			ckbWow.AutoSize = true;
			ckbWow.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbWow.Location = new System.Drawing.Point(152, 20);
			ckbWow.Name = "ckbWow";
			ckbWow.Size = new System.Drawing.Size(15, 14);
			ckbWow.TabIndex = 9;
			ckbWow.UseVisualStyleBackColor = true;
			ckbHaha.AutoSize = true;
			ckbHaha.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbHaha.Location = new System.Drawing.Point(105, 20);
			ckbHaha.Name = "ckbHaha";
			ckbHaha.Size = new System.Drawing.Size(15, 14);
			ckbHaha.TabIndex = 7;
			ckbHaha.UseVisualStyleBackColor = true;
			ckbTym.AutoSize = true;
			ckbTym.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTym.Location = new System.Drawing.Point(58, 20);
			ckbTym.Name = "ckbTym";
			ckbTym.Size = new System.Drawing.Size(15, 14);
			ckbTym.TabIndex = 3;
			ckbTym.UseVisualStyleBackColor = true;
			ckbLike.AutoSize = true;
			ckbLike.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbLike.Location = new System.Drawing.Point(11, 20);
			ckbLike.Name = "ckbLike";
			ckbLike.Size = new System.Drawing.Size(15, 14);
			ckbLike.TabIndex = 1;
			ckbLike.UseVisualStyleBackColor = true;
			label32.Cursor = System.Windows.Forms.Cursors.Hand;
			label32.Location = new System.Drawing.Point(234, 1);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(41, 16);
			label32.TabIndex = 12;
			label32.Text = "Giận";
			label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbInteract.AutoSize = true;
			ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbInteract.Location = new System.Drawing.Point(329, 20);
			ckbInteract.Name = "ckbInteract";
			ckbInteract.Size = new System.Drawing.Size(113, 20);
			ckbInteract.TabIndex = 199;
			ckbInteract.Text = "Ba\u0300y to\u0309 ca\u0309m xu\u0301c";
			ckbInteract.UseVisualStyleBackColor = true;
			ckbInteract.CheckedChanged += new System.EventHandler(ckbInteract_CheckedChanged);
			rbPage.AutoSize = true;
			rbPage.Cursor = System.Windows.Forms.Cursors.Hand;
			rbPage.Location = new System.Drawing.Point(247, 253);
			rbPage.Name = "rbPage";
			rbPage.Size = new System.Drawing.Size(54, 20);
			rbPage.TabIndex = 203;
			rbPage.Text = "Page";
			rbPage.UseVisualStyleBackColor = true;
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(linkLabel1);
			plComment.Controls.Add(button3);
			plComment.Controls.Add(button2);
			plComment.Controls.Add(rbNganCachKyTu);
			plComment.Controls.Add(rbNganCachMoiDong);
			plComment.Controls.Add(label9);
			plComment.Controls.Add(txtComment);
			plComment.Controls.Add(label8);
			plComment.Controls.Add(lblStatus);
			plComment.Location = new System.Drawing.Point(347, 111);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(281, 217);
			plComment.TabIndex = 184;
			linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			linkLabel1.AutoSize = true;
			linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel1.Location = new System.Drawing.Point(191, 150);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(82, 16);
			linkLabel1.TabIndex = 192;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Random icon";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			button3.Cursor = System.Windows.Forms.Cursors.Help;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Location = new System.Drawing.Point(229, 192);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(21, 23);
			button3.TabIndex = 4;
			button3.Text = "?";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			button2.Cursor = System.Windows.Forms.Cursors.Help;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(229, 169);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(21, 23);
			button2.TabIndex = 4;
			button2.Text = "?";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			rbNganCachKyTu.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			rbNganCachKyTu.AutoSize = true;
			rbNganCachKyTu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachKyTu.Location = new System.Drawing.Point(70, 192);
			rbNganCachKyTu.Name = "rbNganCachKyTu";
			rbNganCachKyTu.Size = new System.Drawing.Size(160, 20);
			rbNganCachKyTu.TabIndex = 3;
			rbNganCachKyTu.Text = "Nội dung có nhiều dòng";
			rbNganCachKyTu.UseVisualStyleBackColor = true;
			rbNganCachKyTu.CheckedChanged += new System.EventHandler(rbNganCachKyTu_CheckedChanged);
			rbNganCachMoiDong.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			rbNganCachMoiDong.AutoSize = true;
			rbNganCachMoiDong.Checked = true;
			rbNganCachMoiDong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachMoiDong.Location = new System.Drawing.Point(70, 171);
			rbNganCachMoiDong.Name = "rbNganCachMoiDong";
			rbNganCachMoiDong.Size = new System.Drawing.Size(156, 20);
			rbNganCachMoiDong.TabIndex = 3;
			rbNganCachMoiDong.TabStop = true;
			rbNganCachMoiDong.Text = "Nội dung chỉ có 1 dòng";
			rbNganCachMoiDong.UseVisualStyleBackColor = true;
			rbNganCachMoiDong.CheckedChanged += new System.EventHandler(rbNganCachMoiDong_CheckedChanged);
			label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(5, 171);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(65, 16);
			label9.TabIndex = 2;
			label9.Text = "Tùy chọn:";
			txtComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtComment.Location = new System.Drawing.Point(7, 25);
			txtComment.Name = "txtComment";
			txtComment.Size = new System.Drawing.Size(263, 123);
			txtComment.TabIndex = 1;
			txtComment.Text = "";
			txtComment.WordWrap = false;
			txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged);
			label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 151);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(144, 16);
			label8.TabIndex = 0;
			label8.Text = "(Spin nội dung {a|b|c})";
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 5);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(140, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Nội dung bình luận (0):";
			rbUser.AutoSize = true;
			rbUser.Checked = true;
			rbUser.Cursor = System.Windows.Forms.Cursors.Hand;
			rbUser.Location = new System.Drawing.Point(116, 253);
			rbUser.Name = "rbUser";
			rbUser.Size = new System.Drawing.Size(52, 20);
			rbUser.TabIndex = 201;
			rbUser.TabStop = true;
			rbUser.Text = "User";
			rbUser.UseVisualStyleBackColor = true;
			rbGroup.AutoSize = true;
			rbGroup.Cursor = System.Windows.Forms.Cursors.Hand;
			rbGroup.Location = new System.Drawing.Point(180, 253);
			rbGroup.Name = "rbGroup";
			rbGroup.Size = new System.Drawing.Size(60, 20);
			rbGroup.TabIndex = 202;
			rbGroup.Text = "Group";
			rbGroup.UseVisualStyleBackColor = true;
			ckbSendAnh.AutoSize = true;
			ckbSendAnh.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbSendAnh.Location = new System.Drawing.Point(329, 337);
			ckbSendAnh.Name = "ckbSendAnh";
			ckbSendAnh.Size = new System.Drawing.Size(104, 20);
			ckbSendAnh.TabIndex = 197;
			ckbSendAnh.Text = "Bình luận ảnh";
			ckbSendAnh.UseVisualStyleBackColor = true;
			ckbSendAnh.CheckedChanged += new System.EventHandler(ckbSendAnh_CheckedChanged);
			label49.AutoSize = true;
			label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label49.Location = new System.Drawing.Point(8, 280);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(102, 16);
			label49.TabIndex = 191;
			label49.Text = "Sô\u0301 lươ\u0323ng ID/nick";
			txtUid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtUid.Location = new System.Drawing.Point(12, 41);
			txtUid.Name = "txtUid";
			txtUid.Size = new System.Drawing.Size(299, 184);
			txtUid.TabIndex = 196;
			txtUid.Text = "";
			txtUid.WordWrap = false;
			txtUid.TextChanged += new System.EventHandler(txtUid_TextChanged);
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(8, 338);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(90, 16);
			label16.TabIndex = 186;
			label16.Text = "Thơ\u0300i gian chơ\u0300:";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 21);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(243, 16);
			label3.TabIndex = 195;
			label3.Text = "Nhập danh sách ID User/Group/Page (0):";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(273, 309);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(25, 16);
			label15.TabIndex = 187;
			label15.Text = "ba\u0300i";
			ckbComment.AutoSize = true;
			ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbComment.Location = new System.Drawing.Point(329, 87);
			ckbComment.Name = "ckbComment";
			ckbComment.Size = new System.Drawing.Size(128, 20);
			ckbComment.TabIndex = 183;
			ckbComment.Text = "Bi\u0300nh luâ\u0323n văn bản";
			ckbComment.UseVisualStyleBackColor = true;
			ckbComment.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(273, 338);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(31, 16);
			label14.TabIndex = 188;
			label14.Text = "giây";
			ckbTuDongXoaUid.AutoSize = true;
			ckbTuDongXoaUid.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuDongXoaUid.Location = new System.Drawing.Point(12, 229);
			ckbTuDongXoaUid.Name = "ckbTuDongXoaUid";
			ckbTuDongXoaUid.Size = new System.Drawing.Size(191, 20);
			ckbTuDongXoaUid.TabIndex = 182;
			ckbTuDongXoaUid.Text = "Tự động xóa ID đã tương tác";
			ckbTuDongXoaUid.UseVisualStyleBackColor = true;
			label13.Location = new System.Drawing.Point(180, 309);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(29, 16);
			label13.TabIndex = 189;
			label13.Text = "đê\u0301n";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label19.Location = new System.Drawing.Point(8, 309);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(90, 16);
			label19.TabIndex = 193;
			label19.Text = "Sô\u0301 ba\u0300i viết/ID:";
			label7.Location = new System.Drawing.Point(180, 338);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 190;
			label7.Text = "đê\u0301n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudSoLuongUidTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongUidTo.Location = new System.Drawing.Point(215, 278);
			nudSoLuongUidTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongUidTo.Name = "nudSoLuongUidTo";
			nudSoLuongUidTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongUidTo.TabIndex = 177;
			nudSoLuongUidTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			nudSoLuongBaiVietFrom.Location = new System.Drawing.Point(118, 307);
			nudSoLuongBaiVietFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongBaiVietFrom.Name = "nudSoLuongBaiVietFrom";
			nudSoLuongBaiVietFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongBaiVietFrom.TabIndex = 178;
			label68.AutoSize = true;
			label68.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label68.Location = new System.Drawing.Point(273, 280);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(20, 16);
			label68.TabIndex = 192;
			label68.Text = "ID";
			nudDelayFrom.Location = new System.Drawing.Point(118, 336);
			nudDelayFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 180;
			label66.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label66.Location = new System.Drawing.Point(180, 280);
			label66.Name = "label66";
			label66.Size = new System.Drawing.Size(29, 16);
			label66.TabIndex = 194;
			label66.Text = "đê\u0301n";
			label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudSoLuongBaiVietTo.Location = new System.Drawing.Point(215, 307);
			nudSoLuongBaiVietTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongBaiVietTo.Name = "nudSoLuongBaiVietTo";
			nudSoLuongBaiVietTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongBaiVietTo.TabIndex = 179;
			nudSoLuongUidFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongUidFrom.Location = new System.Drawing.Point(118, 278);
			nudSoLuongUidFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongUidFrom.Name = "nudSoLuongUidFrom";
			nudSoLuongUidFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongUidFrom.TabIndex = 176;
			nudSoLuongUidFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			nudDelayTo.Location = new System.Drawing.Point(215, 336);
			nudDelayTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 181;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1092, 466);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fSpamBaiViet_CauHinh";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fCauHinhTuongTac_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			plInteract.ResumeLayout(false);
			plInteract.PerformLayout();
			plComment.ResumeLayout(false);
			plComment.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			ResumeLayout(false);
		}
	}
}
