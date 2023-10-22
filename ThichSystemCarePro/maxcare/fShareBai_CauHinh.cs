using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;
using MetroFramework.Controls;

namespace maxcare
{
	public class fShareBai_CauHinh : Form
	{
		private JSON_Settings settings;

		private List<string> lstNhomTuNhap = new List<string>();

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

		private GroupBox groupBox3;

		private NumericUpDown nudDelayTo;

		private NumericUpDown nudDelayFrom;

		private Label label20;

		private Label label19;

		private Label label1;

		private Label label3;

		private CheckBox ckbVanBan;

		private Panel plDangBaiLenNhom;

		private NumericUpDown nudCountGroupTo;

		private NumericUpDown nudCountGroupFrom;

		private Label label24;

		private Label label25;

		private Label label26;

		private CheckBox ckbShareBaiLenNhom;

		private CheckBox ckbShareBaiLenTuong;

		private RadioButton rbShareOther;

		private RadioButton rbShareLivestream;

		private Label label7;

		private Panel plVanBan;

		private LinkLabel linkLabel1;

		private RichTextBox txtNoiDung;

		private Label label8;

		private Label lblStatus;

		private CheckBox ckbChiShareNhomKKD;

		private Panel plShareNhomNangCao;

		private CheckBox ckbUuTienShareNhomNhieuThanhVien;

		private CheckBox ckbKhongShareTrungNhom;

		private CheckBox ckbShareNhomNangCao;

		private Panel plTuongTacTruocKhiShare;

		private Label label22;

		private Panel plComment;

		private LinkLabel linkLabel2;

		private Panel plBinhLuanNhieuLan;

		private NumericUpDown nudBinhLuanNhieuLanDelayTo;

		private Label lblmc1;

		private NumericUpDown nudBinhLuanNhieuLanDelayFrom;

		private Label label9;

		private Label label12;

		private Label label13;

		private CheckBox ckbBinhLuanNhieuLan;

		private Label label14;

		private TextBox txtComment;

		private Label label15;

		private Label label21;

		private Panel plInteract;

		private Label label16;

		private Label label17;

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

		private Label label18;

		private CheckBox ckbComment;

		private NumericUpDown nudSoLuongFrom;

		private CheckBox ckbInteract;

		private NumericUpDown nudSoLuongTo;

		private CheckBox ckbTuongTacTruocKhiShare;

		private RichTextBox txtLinkChiaSe;

		private Panel panel3;

		private RadioButton rbShareRandomLink;

		private RadioButton rbShareDeuLink;

		private Label label23;

		private Panel panel4;

		private MetroButton btnNhapNhom;

		private RadioButton rbNhomTuNhap;

		private RadioButton rbNgauNhienNhomThamGia;

		private Label label27;

		public fShareBai_CauHinh()
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
			Language.GetValue(label20);
			Language.GetValue(label19);
			Language.GetValue(ckbVanBan);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(label1);
			Language.GetValue(label3);
			Language.GetValue(label7);
			Language.GetValue(label26);
			Language.GetValue(label24);
			Language.GetValue(label25);
			Language.GetValue(rbShareLivestream);
			Language.GetValue(rbShareOther);
			Language.GetValue(ckbReloginIfLogout);
			Language.GetValue(ckbRandomThuTuTaiKhoan);
			Language.GetValue(ckbShareBaiLenTuong);
			Language.GetValue(ckbShareBaiLenNhom);
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
			settings.Update("nudDelayFrom", nudDelayFrom.Value);
			settings.Update("nudDelayTo", nudDelayTo.Value);
			settings.Update("ckbShareBaiLenTuong", ckbShareBaiLenTuong.Checked);
			settings.Update("ckbShareBaiLenNhom", ckbShareBaiLenNhom.Checked);
			settings.Update("nudCountGroupFrom", nudCountGroupFrom.Value);
			settings.Update("nudCountGroupTo", nudCountGroupTo.Value);
			if (rbNgauNhienNhomThamGia.Checked)
			{
				settings.Update("typeNhomToShare", 0);
			}
			else
			{
				settings.Update("typeNhomToShare", 1);
			}
			settings.Update("lstNhomTuNhap", lstNhomTuNhap);
			settings.Update("ckbShareNhomNangCao", ckbShareNhomNangCao.Checked);
			settings.Update("ckbChiShareNhomKKD", ckbChiShareNhomKKD.Checked);
			settings.Update("ckbUuTienShareNhomNhieuThanhVien", ckbUuTienShareNhomNhieuThanhVien.Checked);
			settings.Update("ckbKhongShareTrungNhom", ckbKhongShareTrungNhom.Checked);
			if (txtLinkChiaSe.Text.Trim() == "")
			{
				MCommon.Common.ShowMessageBox("Vui lo\u0300ng nhâ\u0323p Link câ\u0300n share!", 3);
				return;
			}
			settings.Update("txtLinkChiaSe", txtLinkChiaSe.Text.Trim());
			int num2 = 0;
			if (rbShareDeuLink.Checked)
			{
				num2 = 1;
			}
			settings.Update("typeShareLink", num2);
			int num3 = 0;
			if (rbShareOther.Checked)
			{
				num3 = 1;
			}
			settings.Update("typeLinkShare", num3);
			settings.Update("ckbVanBan", ckbVanBan.Checked);
			settings.Update("txtNoiDung", txtNoiDung.Text.Trim());
			settings.Update("ckbTuongTacTruocKhiShare", ckbTuongTacTruocKhiShare.Checked);
			settings.Update("nudSoLuongFrom", nudSoLuongFrom.Value);
			settings.Update("nudSoLuongTo", nudSoLuongTo.Value);
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
			settings.Update("ckbBinhLuanNhieuLan", ckbBinhLuanNhieuLan.Checked);
			settings.Update("nudBinhLuanNhieuLanDelayFrom", nudBinhLuanNhieuLanDelayFrom.Value);
			settings.Update("nudBinhLuanNhieuLanDelayTo", nudBinhLuanNhieuLanDelayTo.Value);
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
			ckbShareBaiLenNhom_CheckedChanged(null, null);
			ckbVanBan_CheckedChanged_1(null, null);
			ckbTuongTacTruocKhiShare_CheckedChanged(null, null);
			ckbInteract_CheckedChanged(null, null);
			ckbComment_CheckedChanged(null, null);
			ckbBinhLuanNhieuLan_CheckedChanged(null, null);
			rbNhomTuNhap_CheckedChanged(null, null);
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
				nudDelayFrom.Value = settings.GetValueInt("nudDelayFrom", 3);
				nudDelayTo.Value = settings.GetValueInt("nudDelayTo", 5);
				ckbShareBaiLenTuong.Checked = settings.GetValueBool("ckbShareBaiLenTuong");
				ckbShareBaiLenNhom.Checked = settings.GetValueBool("ckbShareBaiLenNhom");
				nudCountGroupFrom.Value = settings.GetValueInt("nudCountGroupFrom", 1);
				nudCountGroupTo.Value = settings.GetValueInt("nudCountGroupTo", 1);
				if (settings.GetValueInt("typeNhomToShare") == 0)
				{
					rbNgauNhienNhomThamGia.Checked = true;
				}
				else
				{
					rbNhomTuNhap.Checked = true;
				}
				lstNhomTuNhap = settings.GetValueList("lstNhomTuNhap");
				ckbShareNhomNangCao.Checked = settings.GetValueBool("ckbShareNhomNangCao");
				ckbChiShareNhomKKD.Checked = settings.GetValueBool("ckbChiShareNhomKKD");
				ckbUuTienShareNhomNhieuThanhVien.Checked = settings.GetValueBool("ckbUuTienShareNhomNhieuThanhVien");
				ckbKhongShareTrungNhom.Checked = settings.GetValueBool("ckbKhongShareTrungNhom");
				txtLinkChiaSe.Text = settings.GetValue("txtLinkChiaSe");
				if (settings.GetValueInt("typeShareLink") == 0)
				{
					rbShareRandomLink.Checked = true;
				}
				else
				{
					rbShareDeuLink.Checked = true;
				}
				if (settings.GetValueInt("typeLinkShare") == 1)
				{
					rbShareOther.Checked = true;
				}
				else
				{
					rbShareLivestream.Checked = true;
				}
				ckbVanBan.Checked = settings.GetValueBool("ckbVanBan");
				txtNoiDung.Text = settings.GetValue("txtNoiDung");
				ckbTuongTacTruocKhiShare.Checked = settings.GetValueBool("ckbTuongTacTruocKhiShare");
				nudSoLuongFrom.Value = settings.GetValueInt("nudSoLuongFrom", 30);
				nudSoLuongTo.Value = settings.GetValueInt("nudSoLuongTo", 30);
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
				ckbBinhLuanNhieuLan.Checked = settings.GetValueBool("ckbBinhLuanNhieuLan");
				nudBinhLuanNhieuLanDelayFrom.Value = settings.GetValueInt("nudBinhLuanNhieuLanDelayFrom", 10);
				nudBinhLuanNhieuLanDelayTo.Value = settings.GetValueInt("nudBinhLuanNhieuLanDelayTo", 10);
			}
			catch
			{
			}
		}

		private void ckbRepeatAll_CheckedChanged(object sender, EventArgs e)
		{
			plRepeatAll.Enabled = ckbRepeatAll.Checked;
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
				list = txtNoiDung.Lines.ToList();
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

		private void ckbShareBaiLenNhom_CheckedChanged(object sender, EventArgs e)
		{
			plDangBaiLenNhom.Enabled = ckbShareBaiLenNhom.Checked;
		}

		private void ckbVanBan_CheckedChanged_1(object sender, EventArgs e)
		{
			plVanBan.Enabled = ckbVanBan.Checked;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MCommon.Common.ShowForm(new fHuongDanRandom());
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhập mỗi dòng là 1 nội dung!"));
			txtNoiDung.Focus();
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHelpNhapComment());
			txtNoiDung.Focus();
		}

		private void plVanBan_Paint(object sender, PaintEventArgs e)
		{
		}

		private void ckbShareBaiLenTuong_CheckedChanged(object sender, EventArgs e)
		{
			plShareNhomNangCao.Enabled = ckbShareNhomNangCao.Checked;
		}

		private void ckbTuongTacTruocKhiShare_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTacTruocKhiShare.Enabled = ckbTuongTacTruocKhiShare.Checked;
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
		{
			plInteract.Enabled = ckbInteract.Checked;
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
			plComment.Enabled = ckbComment.Checked;
		}

		private void ckbBinhLuanNhieuLan_CheckedChanged(object sender, EventArgs e)
		{
			plBinhLuanNhieuLan.Enabled = ckbBinhLuanNhieuLan.Checked;
		}

		private void txtComment_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtComment.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				label15.Text = string.Format(Language.GetValue("Nội dung bình luận ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MCommon.Common.ShowForm(new fHuongDanRandom());
		}

		private void txtLinkChiaSe_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> list = new List<string>();
				list = txtLinkChiaSe.Lines.ToList();
				list = MCommon.Common.RemoveEmptyItems(list);
				label3.Text = string.Format(Language.GetValue("Link cần share ({0}):"), list.Count.ToString());
			}
			catch
			{
			}
		}

		private void rbNhomTuNhap_CheckedChanged(object sender, EventArgs e)
		{
			btnNhapNhom.Enabled = rbNhomTuNhap.Checked;
		}

		private void btnNhapNhom_Click(object sender, EventArgs e)
		{
			string text = Guid.NewGuid().ToString() + ".txt";
			MCommon.Common.ShowForm(new fNhapDuLieu1(text, "Nhâ\u0323p danh sa\u0301ch ID nho\u0301m", "Danh sa\u0301ch ID nho\u0301m", "(Mô\u0303i nô\u0323i dung 1 do\u0300ng)", lstNhomTuNhap));
			lstNhomTuNhap = File.ReadAllLines(text).ToList();
			try
			{
				File.Delete(text);
			}
			catch
			{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fShareBai_CauHinh));
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
			plDangBaiLenNhom = new System.Windows.Forms.Panel();
			plShareNhomNangCao = new System.Windows.Forms.Panel();
			ckbChiShareNhomKKD = new System.Windows.Forms.CheckBox();
			ckbUuTienShareNhomNhieuThanhVien = new System.Windows.Forms.CheckBox();
			ckbKhongShareTrungNhom = new System.Windows.Forms.CheckBox();
			nudCountGroupTo = new System.Windows.Forms.NumericUpDown();
			nudCountGroupFrom = new System.Windows.Forms.NumericUpDown();
			ckbShareNhomNangCao = new System.Windows.Forms.CheckBox();
			label24 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			ckbShareBaiLenNhom = new System.Windows.Forms.CheckBox();
			ckbShareBaiLenTuong = new System.Windows.Forms.CheckBox();
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
			panel3 = new System.Windows.Forms.Panel();
			rbShareRandomLink = new System.Windows.Forms.RadioButton();
			rbShareDeuLink = new System.Windows.Forms.RadioButton();
			txtLinkChiaSe = new System.Windows.Forms.RichTextBox();
			plTuongTacTruocKhiShare = new System.Windows.Forms.Panel();
			label22 = new System.Windows.Forms.Label();
			plComment = new System.Windows.Forms.Panel();
			linkLabel2 = new System.Windows.Forms.LinkLabel();
			plBinhLuanNhieuLan = new System.Windows.Forms.Panel();
			nudBinhLuanNhieuLanDelayTo = new System.Windows.Forms.NumericUpDown();
			lblmc1 = new System.Windows.Forms.Label();
			nudBinhLuanNhieuLanDelayFrom = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			ckbBinhLuanNhieuLan = new System.Windows.Forms.CheckBox();
			label14 = new System.Windows.Forms.Label();
			txtComment = new System.Windows.Forms.TextBox();
			label15 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			plInteract = new System.Windows.Forms.Panel();
			label16 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
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
			label18 = new System.Windows.Forms.Label();
			ckbComment = new System.Windows.Forms.CheckBox();
			nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			ckbInteract = new System.Windows.Forms.CheckBox();
			nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
			plVanBan = new System.Windows.Forms.Panel();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			txtNoiDung = new System.Windows.Forms.RichTextBox();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			rbShareOther = new System.Windows.Forms.RadioButton();
			rbShareLivestream = new System.Windows.Forms.RadioButton();
			ckbTuongTacTruocKhiShare = new System.Windows.Forms.CheckBox();
			label23 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			ckbVanBan = new System.Windows.Forms.CheckBox();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			nudDelayFrom = new System.Windows.Forms.NumericUpDown();
			label20 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			panel4 = new System.Windows.Forms.Panel();
			rbNgauNhienNhomThamGia = new System.Windows.Forms.RadioButton();
			rbNhomTuNhap = new System.Windows.Forms.RadioButton();
			btnNhapNhom = new MetroFramework.Controls.MetroButton();
			label27 = new System.Windows.Forms.Label();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			groupBox3.SuspendLayout();
			plDangBaiLenNhom.SuspendLayout();
			plShareNhomNangCao.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountGroupTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountGroupFrom).BeginInit();
			groupBox1.SuspendLayout();
			panel2.SuspendLayout();
			plRepeatAll.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTurnTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuotChay).BeginInit();
			groupBox2.SuspendLayout();
			panel3.SuspendLayout();
			plTuongTacTruocKhiShare.SuspendLayout();
			plComment.SuspendLayout();
			plBinhLuanNhieuLan.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudBinhLuanNhieuLanDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudBinhLuanNhieuLanDelayFrom).BeginInit();
			plInteract.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
			plVanBan.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
			panel4.SuspendLayout();
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
			bunifuCards1.Size = new System.Drawing.Size(1304, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1304, 32);
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
			btnMinimize.Location = new System.Drawing.Point(1270, -2);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(1304, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Cấu hình Share ba\u0300i";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(659, 529);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(555, 529);
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
			panel1.Size = new System.Drawing.Size(1306, 576);
			panel1.TabIndex = 8;
			groupBox3.Controls.Add(plDangBaiLenNhom);
			groupBox3.Controls.Add(ckbShareBaiLenNhom);
			groupBox3.Controls.Add(ckbShareBaiLenTuong);
			groupBox3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			groupBox3.Location = new System.Drawing.Point(11, 275);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(420, 281);
			groupBox3.TabIndex = 9;
			groupBox3.TabStop = false;
			groupBox3.Text = "Tu\u0300y cho\u0323n Share ba\u0300i";
			plDangBaiLenNhom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plDangBaiLenNhom.Controls.Add(panel4);
			plDangBaiLenNhom.Controls.Add(plShareNhomNangCao);
			plDangBaiLenNhom.Controls.Add(nudCountGroupTo);
			plDangBaiLenNhom.Controls.Add(nudCountGroupFrom);
			plDangBaiLenNhom.Controls.Add(ckbShareNhomNangCao);
			plDangBaiLenNhom.Controls.Add(label24);
			plDangBaiLenNhom.Controls.Add(label25);
			plDangBaiLenNhom.Controls.Add(label27);
			plDangBaiLenNhom.Controls.Add(label26);
			plDangBaiLenNhom.Location = new System.Drawing.Point(39, 71);
			plDangBaiLenNhom.Name = "plDangBaiLenNhom";
			plDangBaiLenNhom.Size = new System.Drawing.Size(363, 203);
			plDangBaiLenNhom.TabIndex = 4;
			plShareNhomNangCao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plShareNhomNangCao.Controls.Add(ckbChiShareNhomKKD);
			plShareNhomNangCao.Controls.Add(ckbUuTienShareNhomNhieuThanhVien);
			plShareNhomNangCao.Controls.Add(ckbKhongShareTrungNhom);
			plShareNhomNangCao.Location = new System.Drawing.Point(19, 124);
			plShareNhomNangCao.Name = "plShareNhomNangCao";
			plShareNhomNangCao.Size = new System.Drawing.Size(339, 72);
			plShareNhomNangCao.TabIndex = 10;
			ckbChiShareNhomKKD.AutoSize = true;
			ckbChiShareNhomKKD.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbChiShareNhomKKD.Location = new System.Drawing.Point(4, 3);
			ckbChiShareNhomKKD.Name = "ckbChiShareNhomKKD";
			ckbChiShareNhomKKD.Size = new System.Drawing.Size(221, 20);
			ckbChiShareNhomKKD.TabIndex = 3;
			ckbChiShareNhomKKD.Text = "Chi\u0309 share nho\u0301m không kiê\u0309m duyê\u0323t";
			ckbChiShareNhomKKD.UseVisualStyleBackColor = true;
			ckbChiShareNhomKKD.CheckedChanged += new System.EventHandler(ckbShareBaiLenTuong_CheckedChanged);
			ckbUuTienShareNhomNhieuThanhVien.AutoSize = true;
			ckbUuTienShareNhomNhieuThanhVien.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbUuTienShareNhomNhieuThanhVien.Location = new System.Drawing.Point(4, 26);
			ckbUuTienShareNhomNhieuThanhVien.Name = "ckbUuTienShareNhomNhieuThanhVien";
			ckbUuTienShareNhomNhieuThanhVien.Size = new System.Drawing.Size(255, 20);
			ckbUuTienShareNhomNhieuThanhVien.TabIndex = 3;
			ckbUuTienShareNhomNhieuThanhVien.Text = "Ưu tiên share nho\u0301m co\u0301 nhiê\u0300u tha\u0300nh viên";
			ckbUuTienShareNhomNhieuThanhVien.UseVisualStyleBackColor = true;
			ckbUuTienShareNhomNhieuThanhVien.CheckedChanged += new System.EventHandler(ckbShareBaiLenTuong_CheckedChanged);
			ckbKhongShareTrungNhom.AutoSize = true;
			ckbKhongShareTrungNhom.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbKhongShareTrungNhom.Location = new System.Drawing.Point(4, 49);
			ckbKhongShareTrungNhom.Name = "ckbKhongShareTrungNhom";
			ckbKhongShareTrungNhom.Size = new System.Drawing.Size(168, 20);
			ckbKhongShareTrungNhom.TabIndex = 3;
			ckbKhongShareTrungNhom.Text = "Không share tru\u0300ng nho\u0301m";
			ckbKhongShareTrungNhom.UseVisualStyleBackColor = true;
			ckbKhongShareTrungNhom.CheckedChanged += new System.EventHandler(ckbShareBaiLenTuong_CheckedChanged);
			nudCountGroupTo.Location = new System.Drawing.Point(205, 3);
			nudCountGroupTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountGroupTo.Name = "nudCountGroupTo";
			nudCountGroupTo.Size = new System.Drawing.Size(56, 23);
			nudCountGroupTo.TabIndex = 53;
			nudCountGroupFrom.Location = new System.Drawing.Point(108, 3);
			nudCountGroupFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountGroupFrom.Name = "nudCountGroupFrom";
			nudCountGroupFrom.Size = new System.Drawing.Size(56, 23);
			nudCountGroupFrom.TabIndex = 52;
			ckbShareNhomNangCao.AutoSize = true;
			ckbShareNhomNangCao.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbShareNhomNangCao.Location = new System.Drawing.Point(6, 101);
			ckbShareNhomNangCao.Name = "ckbShareNhomNangCao";
			ckbShareNhomNangCao.Size = new System.Drawing.Size(133, 20);
			ckbShareNhomNangCao.TabIndex = 3;
			ckbShareNhomNangCao.Text = "Câ\u0301u hi\u0300nh nâng cao";
			ckbShareNhomNangCao.UseVisualStyleBackColor = true;
			ckbShareNhomNangCao.CheckedChanged += new System.EventHandler(ckbShareBaiLenTuong_CheckedChanged);
			label24.Location = new System.Drawing.Point(170, 5);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(29, 16);
			label24.TabIndex = 56;
			label24.Text = "đê\u0301n";
			label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(264, 5);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(40, 16);
			label25.TabIndex = 55;
			label25.Text = "nhóm";
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(3, 5);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(100, 16);
			label26.TabIndex = 54;
			label26.Text = "Số lượng nhóm:";
			ckbShareBaiLenNhom.AutoSize = true;
			ckbShareBaiLenNhom.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbShareBaiLenNhom.Location = new System.Drawing.Point(19, 50);
			ckbShareBaiLenNhom.Name = "ckbShareBaiLenNhom";
			ckbShareBaiLenNhom.Size = new System.Drawing.Size(139, 20);
			ckbShareBaiLenNhom.TabIndex = 2;
			ckbShareBaiLenNhom.Text = "Share bài lên nhóm";
			ckbShareBaiLenNhom.UseVisualStyleBackColor = true;
			ckbShareBaiLenNhom.CheckedChanged += new System.EventHandler(ckbShareBaiLenNhom_CheckedChanged);
			ckbShareBaiLenTuong.AutoSize = true;
			ckbShareBaiLenTuong.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbShareBaiLenTuong.Location = new System.Drawing.Point(19, 23);
			ckbShareBaiLenTuong.Name = "ckbShareBaiLenTuong";
			ckbShareBaiLenTuong.Size = new System.Drawing.Size(140, 20);
			ckbShareBaiLenTuong.TabIndex = 3;
			ckbShareBaiLenTuong.Text = "Share bài lên tường";
			ckbShareBaiLenTuong.UseVisualStyleBackColor = true;
			ckbShareBaiLenTuong.CheckedChanged += new System.EventHandler(ckbShareBaiLenTuong_CheckedChanged);
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
			groupBox2.Controls.Add(panel3);
			groupBox2.Controls.Add(txtLinkChiaSe);
			groupBox2.Controls.Add(plTuongTacTruocKhiShare);
			groupBox2.Controls.Add(plVanBan);
			groupBox2.Controls.Add(rbShareOther);
			groupBox2.Controls.Add(rbShareLivestream);
			groupBox2.Controls.Add(ckbTuongTacTruocKhiShare);
			groupBox2.Controls.Add(label23);
			groupBox2.Controls.Add(label7);
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(ckbVanBan);
			groupBox2.Controls.Add(nudDelayTo);
			groupBox2.Controls.Add(nudDelayFrom);
			groupBox2.Controls.Add(label20);
			groupBox2.Controls.Add(label19);
			groupBox2.Controls.Add(label1);
			groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			groupBox2.Location = new System.Drawing.Point(445, 44);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(853, 447);
			groupBox2.TabIndex = 7;
			groupBox2.TabStop = false;
			groupBox2.Text = "Câ\u0301u hi\u0300nh cha\u0323y";
			panel3.Controls.Add(rbShareRandomLink);
			panel3.Controls.Add(rbShareDeuLink);
			panel3.Location = new System.Drawing.Point(143, 161);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(286, 25);
			panel3.TabIndex = 74;
			rbShareRandomLink.AutoSize = true;
			rbShareRandomLink.Cursor = System.Windows.Forms.Cursors.Hand;
			rbShareRandomLink.Location = new System.Drawing.Point(3, 3);
			rbShareRandomLink.Name = "rbShareRandomLink";
			rbShareRandomLink.Size = new System.Drawing.Size(131, 20);
			rbShareRandomLink.TabIndex = 71;
			rbShareRandomLink.TabStop = true;
			rbShareRandomLink.Text = "Share random link";
			rbShareRandomLink.UseVisualStyleBackColor = true;
			rbShareDeuLink.AutoSize = true;
			rbShareDeuLink.Cursor = System.Windows.Forms.Cursors.Hand;
			rbShareDeuLink.Location = new System.Drawing.Point(140, 3);
			rbShareDeuLink.Name = "rbShareDeuLink";
			rbShareDeuLink.Size = new System.Drawing.Size(131, 20);
			rbShareDeuLink.TabIndex = 71;
			rbShareDeuLink.TabStop = true;
			rbShareDeuLink.Text = "Share đê\u0300u ca\u0301c link";
			rbShareDeuLink.UseVisualStyleBackColor = true;
			txtLinkChiaSe.Location = new System.Drawing.Point(22, 67);
			txtLinkChiaSe.Name = "txtLinkChiaSe";
			txtLinkChiaSe.Size = new System.Drawing.Size(474, 93);
			txtLinkChiaSe.TabIndex = 73;
			txtLinkChiaSe.Text = "";
			txtLinkChiaSe.WordWrap = false;
			txtLinkChiaSe.TextChanged += new System.EventHandler(txtLinkChiaSe_TextChanged);
			plTuongTacTruocKhiShare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTacTruocKhiShare.Controls.Add(label22);
			plTuongTacTruocKhiShare.Controls.Add(plComment);
			plTuongTacTruocKhiShare.Controls.Add(label21);
			plTuongTacTruocKhiShare.Controls.Add(plInteract);
			plTuongTacTruocKhiShare.Controls.Add(label18);
			plTuongTacTruocKhiShare.Controls.Add(ckbComment);
			plTuongTacTruocKhiShare.Controls.Add(nudSoLuongFrom);
			plTuongTacTruocKhiShare.Controls.Add(ckbInteract);
			plTuongTacTruocKhiShare.Controls.Add(nudSoLuongTo);
			plTuongTacTruocKhiShare.Font = new System.Drawing.Font("Tahoma", 9.75f);
			plTuongTacTruocKhiShare.Location = new System.Drawing.Point(527, 90);
			plTuongTacTruocKhiShare.Name = "plTuongTacTruocKhiShare";
			plTuongTacTruocKhiShare.Size = new System.Drawing.Size(309, 346);
			plTuongTacTruocKhiShare.TabIndex = 10;
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(3, 4);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(94, 16);
			label22.TabIndex = 44;
			label22.Text = "Thời gian xem:";
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(linkLabel2);
			plComment.Controls.Add(plBinhLuanNhieuLan);
			plComment.Controls.Add(ckbBinhLuanNhieuLan);
			plComment.Controls.Add(label14);
			plComment.Controls.Add(txtComment);
			plComment.Controls.Add(label15);
			plComment.Location = new System.Drawing.Point(24, 124);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(278, 213);
			plComment.TabIndex = 43;
			linkLabel2.AutoSize = true;
			linkLabel2.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel2.Location = new System.Drawing.Point(190, 141);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new System.Drawing.Size(82, 16);
			linkLabel2.TabIndex = 192;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "Random icon";
			linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
			plBinhLuanNhieuLan.Controls.Add(nudBinhLuanNhieuLanDelayTo);
			plBinhLuanNhieuLan.Controls.Add(lblmc1);
			plBinhLuanNhieuLan.Controls.Add(nudBinhLuanNhieuLanDelayFrom);
			plBinhLuanNhieuLan.Controls.Add(label9);
			plBinhLuanNhieuLan.Controls.Add(label12);
			plBinhLuanNhieuLan.Controls.Add(label13);
			plBinhLuanNhieuLan.Location = new System.Drawing.Point(19, 182);
			plBinhLuanNhieuLan.Name = "plBinhLuanNhieuLan";
			plBinhLuanNhieuLan.Size = new System.Drawing.Size(254, 27);
			plBinhLuanNhieuLan.TabIndex = 134;
			nudBinhLuanNhieuLanDelayTo.Cursor = System.Windows.Forms.Cursors.Hand;
			nudBinhLuanNhieuLanDelayTo.Location = new System.Drawing.Point(174, 2);
			nudBinhLuanNhieuLanDelayTo.Maximum = new decimal(new int[4] { 100000000, 0, 0, 0 });
			nudBinhLuanNhieuLanDelayTo.Name = "nudBinhLuanNhieuLanDelayTo";
			nudBinhLuanNhieuLanDelayTo.Size = new System.Drawing.Size(50, 23);
			nudBinhLuanNhieuLanDelayTo.TabIndex = 22;
			lblmc1.AutoSize = true;
			lblmc1.Location = new System.Drawing.Point(4, 4);
			lblmc1.Name = "lblmc1";
			lblmc1.Size = new System.Drawing.Size(73, 16);
			lblmc1.TabIndex = 18;
			lblmc1.Text = "Delay time:";
			nudBinhLuanNhieuLanDelayFrom.Cursor = System.Windows.Forms.Cursors.Hand;
			nudBinhLuanNhieuLanDelayFrom.Location = new System.Drawing.Point(96, 2);
			nudBinhLuanNhieuLanDelayFrom.Maximum = new decimal(new int[4] { 100000000, 0, 0, 0 });
			nudBinhLuanNhieuLanDelayFrom.Name = "nudBinhLuanNhieuLanDelayFrom";
			nudBinhLuanNhieuLanDelayFrom.Size = new System.Drawing.Size(45, 23);
			nudBinhLuanNhieuLanDelayFrom.TabIndex = 21;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(226, 4);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(31, 16);
			label9.TabIndex = 20;
			label9.Text = "giây";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(75, 4);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(20, 16);
			label12.TabIndex = 20;
			label12.Text = "từ";
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(143, 4);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(29, 16);
			label13.TabIndex = 20;
			label13.Text = "đến";
			ckbBinhLuanNhieuLan.AutoSize = true;
			ckbBinhLuanNhieuLan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbBinhLuanNhieuLan.Location = new System.Drawing.Point(7, 163);
			ckbBinhLuanNhieuLan.Name = "ckbBinhLuanNhieuLan";
			ckbBinhLuanNhieuLan.Size = new System.Drawing.Size(135, 20);
			ckbBinhLuanNhieuLan.TabIndex = 133;
			ckbBinhLuanNhieuLan.Text = "Bình luận nhiều lần";
			ckbBinhLuanNhieuLan.UseVisualStyleBackColor = true;
			ckbBinhLuanNhieuLan.CheckedChanged += new System.EventHandler(ckbBinhLuanNhieuLan_CheckedChanged);
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(3, 141);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(144, 16);
			label14.TabIndex = 2;
			label14.Text = "(Spin nội dung {a|b|c})";
			txtComment.Location = new System.Drawing.Point(7, 27);
			txtComment.Multiline = true;
			txtComment.Name = "txtComment";
			txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtComment.Size = new System.Drawing.Size(261, 111);
			txtComment.TabIndex = 1;
			txtComment.WordWrap = false;
			txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged);
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(3, 5);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(140, 16);
			label15.TabIndex = 0;
			label15.Text = "Nội dung bình luận (0):";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(266, 4);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(31, 16);
			label21.TabIndex = 45;
			label21.Text = "giây";
			plInteract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plInteract.Controls.Add(label16);
			plInteract.Controls.Add(label17);
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
			plInteract.Location = new System.Drawing.Point(24, 55);
			plInteract.Name = "plInteract";
			plInteract.Size = new System.Drawing.Size(278, 40);
			plInteract.TabIndex = 41;
			label16.Cursor = System.Windows.Forms.Cursors.Hand;
			label16.Location = new System.Drawing.Point(4, 1);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(30, 16);
			label16.TabIndex = 0;
			label16.Text = "Like";
			label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label17.Cursor = System.Windows.Forms.Cursors.Hand;
			label17.Location = new System.Drawing.Point(46, 1);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(39, 16);
			label17.TabIndex = 2;
			label17.Text = "Tym";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			label32.Location = new System.Drawing.Point(233, 1);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(40, 16);
			label32.TabIndex = 12;
			label32.Text = "Giận";
			label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label18.Location = new System.Drawing.Point(170, 4);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(29, 16);
			label18.TabIndex = 46;
			label18.Text = "đê\u0301n";
			label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbComment.AutoSize = true;
			ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbComment.Location = new System.Drawing.Point(6, 99);
			ckbComment.Name = "ckbComment";
			ckbComment.Size = new System.Drawing.Size(131, 20);
			ckbComment.TabIndex = 42;
			ckbComment.Text = "Tư\u0323 đô\u0323ng bi\u0300nh luâ\u0323n";
			ckbComment.UseVisualStyleBackColor = true;
			ckbComment.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
			nudSoLuongFrom.Location = new System.Drawing.Point(108, 2);
			nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongFrom.Name = "nudSoLuongFrom";
			nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongFrom.TabIndex = 38;
			ckbInteract.AutoSize = true;
			ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbInteract.Location = new System.Drawing.Point(6, 31);
			ckbInteract.Name = "ckbInteract";
			ckbInteract.Size = new System.Drawing.Size(113, 20);
			ckbInteract.TabIndex = 40;
			ckbInteract.Text = "Ba\u0300y to\u0309 ca\u0309m xu\u0301c";
			ckbInteract.UseVisualStyleBackColor = true;
			ckbInteract.CheckedChanged += new System.EventHandler(ckbInteract_CheckedChanged);
			nudSoLuongTo.Location = new System.Drawing.Point(205, 2);
			nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongTo.Name = "nudSoLuongTo";
			nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongTo.TabIndex = 39;
			plVanBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plVanBan.Controls.Add(linkLabel1);
			plVanBan.Controls.Add(txtNoiDung);
			plVanBan.Controls.Add(label8);
			plVanBan.Controls.Add(lblStatus);
			plVanBan.Location = new System.Drawing.Point(40, 236);
			plVanBan.Name = "plVanBan";
			plVanBan.Size = new System.Drawing.Size(456, 199);
			plVanBan.TabIndex = 72;
			plVanBan.Paint += new System.Windows.Forms.PaintEventHandler(plVanBan_Paint);
			linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			linkLabel1.AutoSize = true;
			linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel1.Location = new System.Drawing.Point(155, 177);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(82, 16);
			linkLabel1.TabIndex = 195;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Random icon";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			txtNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtNoiDung.Location = new System.Drawing.Point(7, 24);
			txtNoiDung.Name = "txtNoiDung";
			txtNoiDung.Size = new System.Drawing.Size(444, 150);
			txtNoiDung.TabIndex = 34;
			txtNoiDung.Text = "";
			txtNoiDung.WordWrap = false;
			txtNoiDung.TextChanged += new System.EventHandler(txtNoiDung_TextChanged);
			label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(5, 177);
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
			rbShareOther.AutoSize = true;
			rbShareOther.Cursor = System.Windows.Forms.Cursors.Hand;
			rbShareOther.Location = new System.Drawing.Point(283, 187);
			rbShareOther.Name = "rbShareOther";
			rbShareOther.Size = new System.Drawing.Size(191, 20);
			rbShareOther.TabIndex = 71;
			rbShareOther.TabStop = true;
			rbShareOther.Text = "Kha\u0301c (ba\u0300i viê\u0301t, a\u0309nh, video,...)";
			rbShareOther.UseVisualStyleBackColor = true;
			rbShareLivestream.AutoSize = true;
			rbShareLivestream.Cursor = System.Windows.Forms.Cursors.Hand;
			rbShareLivestream.Location = new System.Drawing.Point(146, 188);
			rbShareLivestream.Name = "rbShareLivestream";
			rbShareLivestream.Size = new System.Drawing.Size(88, 20);
			rbShareLivestream.TabIndex = 71;
			rbShareLivestream.TabStop = true;
			rbShareLivestream.Text = "Livestream";
			rbShareLivestream.UseVisualStyleBackColor = true;
			ckbTuongTacTruocKhiShare.AutoSize = true;
			ckbTuongTacTruocKhiShare.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacTruocKhiShare.Location = new System.Drawing.Point(527, 67);
			ckbTuongTacTruocKhiShare.Name = "ckbTuongTacTruocKhiShare";
			ckbTuongTacTruocKhiShare.Size = new System.Drawing.Size(175, 20);
			ckbTuongTacTruocKhiShare.TabIndex = 3;
			ckbTuongTacTruocKhiShare.Text = "Tương ta\u0301c trươ\u0301c khi share";
			ckbTuongTacTruocKhiShare.UseVisualStyleBackColor = true;
			ckbTuongTacTruocKhiShare.CheckedChanged += new System.EventHandler(ckbTuongTacTruocKhiShare_CheckedChanged);
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(19, 165);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(124, 16);
			label23.TabIndex = 70;
			label23.Text = "Tu\u0300y cho\u0323n share link:";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(19, 190);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(95, 16);
			label7.TabIndex = 70;
			label7.Text = "Loa\u0323i link share:";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(19, 49);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(116, 16);
			label3.TabIndex = 70;
			label3.Text = "Link cần share (0):";
			ckbVanBan.AutoSize = true;
			ckbVanBan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbVanBan.Location = new System.Drawing.Point(22, 213);
			ckbVanBan.Name = "ckbVanBan";
			ckbVanBan.Size = new System.Drawing.Size(113, 20);
			ckbVanBan.TabIndex = 67;
			ckbVanBan.Text = "Nội dung share";
			ckbVanBan.UseVisualStyleBackColor = true;
			ckbVanBan.CheckedChanged += new System.EventHandler(ckbVanBan_CheckedChanged_1);
			nudDelayTo.Location = new System.Drawing.Point(243, 22);
			nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 63;
			nudDelayFrom.Location = new System.Drawing.Point(146, 22);
			nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 62;
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(208, 24);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(29, 16);
			label20.TabIndex = 66;
			label20.Text = "đê\u0301n";
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(302, 24);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(31, 16);
			label19.TabIndex = 65;
			label19.Text = "giây";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(19, 24);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(121, 16);
			label1.TabIndex = 64;
			label1.Text = "Khoảng cách share:";
			panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel4.Controls.Add(btnNhapNhom);
			panel4.Controls.Add(rbNhomTuNhap);
			panel4.Controls.Add(rbNgauNhienNhomThamGia);
			panel4.Location = new System.Drawing.Point(19, 49);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(339, 50);
			panel4.TabIndex = 10;
			rbNgauNhienNhomThamGia.AutoSize = true;
			rbNgauNhienNhomThamGia.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNgauNhienNhomThamGia.Location = new System.Drawing.Point(4, 3);
			rbNgauNhienNhomThamGia.Name = "rbNgauNhienNhomThamGia";
			rbNgauNhienNhomThamGia.Size = new System.Drawing.Size(198, 20);
			rbNgauNhienNhomThamGia.TabIndex = 0;
			rbNgauNhienNhomThamGia.TabStop = true;
			rbNgauNhienNhomThamGia.Text = "Ngâ\u0303u nhiên nho\u0301m đa\u0303 tham gia";
			rbNgauNhienNhomThamGia.UseVisualStyleBackColor = true;
			rbNhomTuNhap.AutoSize = true;
			rbNhomTuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNhomTuNhap.Location = new System.Drawing.Point(4, 25);
			rbNhomTuNhap.Name = "rbNhomTuNhap";
			rbNhomTuNhap.Size = new System.Drawing.Size(177, 20);
			rbNhomTuNhap.TabIndex = 0;
			rbNhomTuNhap.TabStop = true;
			rbNhomTuNhap.Text = "Nho\u0301m do ngươ\u0300i du\u0300ng nhâ\u0323p";
			rbNhomTuNhap.UseVisualStyleBackColor = true;
			rbNhomTuNhap.CheckedChanged += new System.EventHandler(rbNhomTuNhap_CheckedChanged);
			btnNhapNhom.Cursor = System.Windows.Forms.Cursors.Hand;
			btnNhapNhom.Location = new System.Drawing.Point(205, 23);
			btnNhapNhom.Name = "btnNhapNhom";
			btnNhapNhom.Size = new System.Drawing.Size(75, 23);
			btnNhapNhom.TabIndex = 1;
			btnNhapNhom.Text = "Nhâ\u0323p";
			btnNhapNhom.UseSelectable = true;
			btnNhapNhom.Click += new System.EventHandler(btnNhapNhom_Click);
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(3, 30);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(155, 16);
			label27.TabIndex = 54;
			label27.Text = "Tu\u0300y cho\u0323n nho\u0301m đê\u0309 share:";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1306, 576);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fShareBai_CauHinh";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fCauHinhTuongTac_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			plDangBaiLenNhom.ResumeLayout(false);
			plDangBaiLenNhom.PerformLayout();
			plShareNhomNangCao.ResumeLayout(false);
			plShareNhomNangCao.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountGroupTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountGroupFrom).EndInit();
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
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			plTuongTacTruocKhiShare.ResumeLayout(false);
			plTuongTacTruocKhiShare.PerformLayout();
			plComment.ResumeLayout(false);
			plComment.PerformLayout();
			plBinhLuanNhieuLan.ResumeLayout(false);
			plBinhLuanNhieuLan.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudBinhLuanNhieuLanDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudBinhLuanNhieuLanDelayFrom).EndInit();
			plInteract.ResumeLayout(false);
			plInteract.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
			plVanBan.ResumeLayout(false);
			plVanBan.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			ResumeLayout(false);
		}
	}
}
