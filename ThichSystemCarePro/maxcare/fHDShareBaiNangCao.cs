using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.KichBan;
using MCommon;
using MetroFramework.Controls;

namespace maxcare
{
	public class fHDShareBaiNangCao : Form
	{
		private JSON_Settings setting;

		private string id_KichBan;

		private string id_TuongTac;

		private string Id_HanhDong;

		private int type;

		public static bool isSave;

		private List<string> lstNhomTuNhap = new List<string>();

		private IContainer components = null;

		private BunifuDragControl bunifuDragControl1;

		private BunifuDragControl bunifuDragControl2;

		private Panel panel1;

		private TextBox txtTenHanhDong;

		private Label label1;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private Button button1;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private GroupBox groupBox2;

		private Panel plShareBaiLenNhom;

		private NumericUpDown nudCountGroupTo;

		private NumericUpDown nudCountGroupFrom;

		private Label label24;

		private Label label25;

		private Label label26;

		private CheckBox ckbShareBaiLenNhom;

		private CheckBox ckbShareBaiLenTuong;

		private Panel plShareNhomNangCao;

		private CheckBox ckbChiShareNhomKKD;

		private CheckBox ckbUuTienShareNhomNhieuThanhVien;

		private CheckBox ckbKhongShareTrungNhom;

		private CheckBox ckbShareNhomNangCao;

		private GroupBox groupBox1;

		private Panel panel3;

		private RadioButton rbShareRandomLink;

		private RadioButton rbShareDeuLink;

		private RichTextBox txtLinkChiaSe;

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

		private Panel plVanBan;

		private LinkLabel linkLabel1;

		private RichTextBox txtNoiDung;

		private Label label8;

		private Label lblStatus;

		private RadioButton rbShareOther;

		private RadioButton rbShareLivestream;

		private CheckBox ckbTuongTacTruocKhiShare;

		private Label label23;

		private Label label7;

		private Label label3;

		private CheckBox ckbVanBan;

		private NumericUpDown nudDelayTo;

		private NumericUpDown nudDelayFrom;

		private Label label20;

		private Label label19;

		private Label label2;

		private Panel panel4;

		private MetroButton btnNhapNhom;

		private RadioButton rbNhomTuNhap;

		private RadioButton rbNgauNhienNhomThamGia;

		private Label label27;

		public fHDShareBaiNangCao(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string text = base.Name.Substring(1);
			string text2 = "Share bài nâng cao";
			if (InteractSQL.GetTuongTac("", text).Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\",\"MoTa\") VALUES ('" + text + "', '" + text2 + "');");
			}
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", text);
				jsonStringOrPathFile = tuongTac.Rows[0]["CauHinh"].ToString();
				id_TuongTac = tuongTac.Rows[0]["Id_TuongTac"].ToString();
				txtTenHanhDong.Text = Language.GetValue(tuongTac.Rows[0]["MoTa"].ToString());
				break;
			}
			case 1:
			{
				DataTable hanhDongById = InteractSQL.GetHanhDongById(id_HanhDong);
				jsonStringOrPathFile = hanhDongById.Rows[0]["CauHinh"].ToString();
				btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
				txtTenHanhDong.Text = hanhDongById.Rows[0]["TenHanhDong"].ToString();
				break;
			}
			}
			setting = new JSON_Settings(jsonStringOrPathFile, isJsonString: true);
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label1);
			Language.GetValue(label15);
			Language.GetValue(label20);
			Language.GetValue(label19);
			Language.GetValue(groupBox2);
			Language.GetValue(ckbShareBaiLenTuong);
			Language.GetValue(ckbShareBaiLenNhom);
			Language.GetValue(label26);
			Language.GetValue(label24);
			Language.GetValue(label25);
			Language.GetValue(label2);
			Language.GetValue(ckbVanBan);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(label9);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudDelayFrom.Value = setting.GetValueInt("nudDelayFrom", 3);
				nudDelayTo.Value = setting.GetValueInt("nudDelayTo", 5);
				ckbShareBaiLenTuong.Checked = setting.GetValueBool("ckbShareBaiLenTuong");
				ckbShareBaiLenNhom.Checked = setting.GetValueBool("ckbShareBaiLenNhom");
				nudCountGroupFrom.Value = setting.GetValueInt("nudCountGroupFrom", 1);
				nudCountGroupTo.Value = setting.GetValueInt("nudCountGroupTo", 1);
				if (setting.GetValueInt("typeNhomToShare") == 0)
				{
					rbNgauNhienNhomThamGia.Checked = true;
				}
				else
				{
					rbNhomTuNhap.Checked = true;
				}
				lstNhomTuNhap = setting.GetValueList("lstNhomTuNhap");
				ckbShareNhomNangCao.Checked = setting.GetValueBool("ckbShareNhomNangCao");
				ckbChiShareNhomKKD.Checked = setting.GetValueBool("ckbChiShareNhomKKD");
				ckbUuTienShareNhomNhieuThanhVien.Checked = setting.GetValueBool("ckbUuTienShareNhomNhieuThanhVien");
				ckbKhongShareTrungNhom.Checked = setting.GetValueBool("ckbKhongShareTrungNhom");
				txtLinkChiaSe.Text = setting.GetValue("txtLinkChiaSe");
				if (setting.GetValueInt("typeShareLink") == 0)
				{
					rbShareRandomLink.Checked = true;
				}
				else
				{
					rbShareDeuLink.Checked = true;
				}
				if (setting.GetValueInt("typeLinkShare") == 1)
				{
					rbShareOther.Checked = true;
				}
				else
				{
					rbShareLivestream.Checked = true;
				}
				ckbVanBan.Checked = setting.GetValueBool("ckbVanBan");
				txtNoiDung.Text = setting.GetValue("txtNoiDung");
				ckbTuongTacTruocKhiShare.Checked = setting.GetValueBool("ckbTuongTacTruocKhiShare");
				nudSoLuongFrom.Value = setting.GetValueInt("nudSoLuongFrom", 30);
				nudSoLuongTo.Value = setting.GetValueInt("nudSoLuongTo", 30);
				ckbInteract.Checked = setting.GetValueBool("ckbInteract");
				string value = setting.GetValue("typeReaction");
				List<CheckBox> list = new List<CheckBox> { ckbLike, ckbTym, ckbHaha, ckbWow, ckbBuon, ckbGian };
				for (int i = 0; i < list.Count; i++)
				{
					if (value.Contains(i.ToString()))
					{
						list[i].Checked = true;
					}
				}
				ckbComment.Checked = setting.GetValueBool("ckbComment");
				txtComment.Text = setting.GetValue("txtComment");
				ckbBinhLuanNhieuLan.Checked = setting.GetValueBool("ckbBinhLuanNhieuLan");
				nudBinhLuanNhieuLanDelayFrom.Value = setting.GetValueInt("nudBinhLuanNhieuLanDelayFrom", 10);
				nudBinhLuanNhieuLanDelayTo.Value = setting.GetValueInt("nudBinhLuanNhieuLanDelayTo", 10);
			}
			catch
			{
			}
			CheckedChangeFull();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string text = txtTenHanhDong.Text.Trim();
			if (text == "")
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!"), 3);
				return;
			}
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
			jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
			jSON_Settings.Update("ckbShareBaiLenTuong", ckbShareBaiLenTuong.Checked);
			jSON_Settings.Update("ckbShareBaiLenNhom", ckbShareBaiLenNhom.Checked);
			jSON_Settings.Update("nudCountGroupFrom", nudCountGroupFrom.Value);
			jSON_Settings.Update("nudCountGroupTo", nudCountGroupTo.Value);
			if (rbNgauNhienNhomThamGia.Checked)
			{
				jSON_Settings.Update("typeNhomToShare", 0);
			}
			else
			{
				jSON_Settings.Update("typeNhomToShare", 1);
			}
			jSON_Settings.Update("lstNhomTuNhap", lstNhomTuNhap);
			jSON_Settings.Update("ckbShareNhomNangCao", ckbShareNhomNangCao.Checked);
			jSON_Settings.Update("ckbChiShareNhomKKD", ckbChiShareNhomKKD.Checked);
			jSON_Settings.Update("ckbUuTienShareNhomNhieuThanhVien", ckbUuTienShareNhomNhieuThanhVien.Checked);
			jSON_Settings.Update("ckbKhongShareTrungNhom", ckbKhongShareTrungNhom.Checked);
			if (txtLinkChiaSe.Text.Trim() == "")
			{
				MCommon.Common.ShowMessageBox("Vui lo\u0300ng nhâ\u0323p Link câ\u0300n share!", 3);
				return;
			}
			jSON_Settings.Update("txtLinkChiaSe", txtLinkChiaSe.Text.Trim());
			int num = 0;
			if (rbShareDeuLink.Checked)
			{
				num = 1;
			}
			jSON_Settings.Update("typeShareLink", num);
			int num2 = 0;
			if (rbShareOther.Checked)
			{
				num2 = 1;
			}
			jSON_Settings.Update("typeLinkShare", num2);
			jSON_Settings.Update("ckbVanBan", ckbVanBan.Checked);
			jSON_Settings.Update("txtNoiDung", txtNoiDung.Text.Trim());
			jSON_Settings.Update("ckbTuongTacTruocKhiShare", ckbTuongTacTruocKhiShare.Checked);
			jSON_Settings.Update("nudSoLuongFrom", nudSoLuongFrom.Value);
			jSON_Settings.Update("nudSoLuongTo", nudSoLuongTo.Value);
			jSON_Settings.Update("ckbInteract", ckbInteract.Checked);
			string text2 = "";
			List<CheckBox> list = new List<CheckBox> { ckbLike, ckbTym, ckbHaha, ckbWow, ckbBuon, ckbGian };
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Checked)
				{
					text2 += i;
				}
			}
			jSON_Settings.Update("typeReaction", text2);
			jSON_Settings.Update("ckbComment", ckbComment.Checked);
			jSON_Settings.Update("txtComment", txtComment.Text.Trim());
			jSON_Settings.Update("ckbBinhLuanNhieuLan", ckbBinhLuanNhieuLan.Checked);
			jSON_Settings.Update("nudBinhLuanNhieuLanDelayFrom", nudBinhLuanNhieuLanDelayFrom.Value);
			jSON_Settings.Update("nudBinhLuanNhieuLanDelayTo", nudBinhLuanNhieuLanDelayTo.Value);
			string fullString = jSON_Settings.GetFullString();
			if (type == 0)
			{
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?")) == DialogResult.Yes)
				{
					if (InteractSQL.InsertHanhDong(id_KichBan, text, id_TuongTac, fullString))
					{
						isSave = true;
						Close();
					}
					else
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
					}
				}
			}
			else if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?")) == DialogResult.Yes)
			{
				if (InteractSQL.UpdateHanhDong(Id_HanhDong, text, fullString))
				{
					isSave = true;
					Close();
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			if (panel1.BorderStyle == BorderStyle.FixedSingle)
			{
				int num = 1;
				int num2 = 0;
				using Pen pen = new Pen(Color.DarkViolet, 1f);
				e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
			}
		}

		private void CheckedChangeFull()
		{
			ckbVanBan_CheckedChanged_1(null, null);
			ckbTuongTacTruocKhiShare_CheckedChanged(null, null);
			ckbInteract_CheckedChanged(null, null);
			ckbComment_CheckedChanged(null, null);
			ckbBinhLuanNhieuLan_CheckedChanged(null, null);
			ckbShareNhomNangCao_CheckedChanged(null, null);
			ckbDangBaiLenNhom_CheckedChanged(null, null);
			rbNhomTuNhap_CheckedChanged(null, null);
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
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

		private void ckbVanBan_CheckedChanged_1(object sender, EventArgs e)
		{
			plVanBan.Enabled = ckbVanBan.Checked;
		}

		private void txtNoiDung_TextChanged_1(object sender, EventArgs e)
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

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MCommon.Common.ShowForm(new fHuongDanRandom());
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

		private void ckbTuongTacTruocKhiShare_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTacTruocKhiShare.Enabled = ckbTuongTacTruocKhiShare.Checked;
		}

		private void ckbDangBaiLenNhom_CheckedChanged(object sender, EventArgs e)
		{
			plShareBaiLenNhom.Enabled = ckbShareBaiLenNhom.Checked;
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

		private void ckbShareNhomNangCao_CheckedChanged(object sender, EventArgs e)
		{
			plShareNhomNangCao.Enabled = ckbShareNhomNangCao.Checked;
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

		private void rbNhomTuNhap_CheckedChanged(object sender, EventArgs e)
		{
			btnNhapNhom.Enabled = rbNhomTuNhap.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDShareBaiNangCao));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			groupBox1 = new System.Windows.Forms.GroupBox();
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
			label2 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			plShareBaiLenNhom = new System.Windows.Forms.Panel();
			panel4 = new System.Windows.Forms.Panel();
			btnNhapNhom = new MetroFramework.Controls.MetroButton();
			rbNhomTuNhap = new System.Windows.Forms.RadioButton();
			rbNgauNhienNhomThamGia = new System.Windows.Forms.RadioButton();
			label27 = new System.Windows.Forms.Label();
			plShareNhomNangCao = new System.Windows.Forms.Panel();
			ckbChiShareNhomKKD = new System.Windows.Forms.CheckBox();
			ckbUuTienShareNhomNhieuThanhVien = new System.Windows.Forms.CheckBox();
			ckbKhongShareTrungNhom = new System.Windows.Forms.CheckBox();
			ckbShareNhomNangCao = new System.Windows.Forms.CheckBox();
			nudCountGroupTo = new System.Windows.Forms.NumericUpDown();
			nudCountGroupFrom = new System.Windows.Forms.NumericUpDown();
			label24 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			ckbShareBaiLenNhom = new System.Windows.Forms.CheckBox();
			ckbShareBaiLenTuong = new System.Windows.Forms.CheckBox();
			btnAdd = new System.Windows.Forms.Button();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			groupBox1.SuspendLayout();
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
			groupBox2.SuspendLayout();
			plShareBaiLenNhom.SuspendLayout();
			panel4.SuspendLayout();
			plShareNhomNangCao.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountGroupTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountGroupFrom).BeginInit();
			bunifuCards1.SuspendLayout();
			SuspendLayout();
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(1257, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Share bài nâng cao";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = pnlHeader;
			bunifuDragControl2.Vertical = true;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(button1);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1257, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(1226, 1);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(30, 30);
			button1.TabIndex = 0;
			button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 76;
			pictureBox1.TabStop = false;
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(groupBox2);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1260, 582);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			groupBox1.Controls.Add(panel3);
			groupBox1.Controls.Add(txtLinkChiaSe);
			groupBox1.Controls.Add(plTuongTacTruocKhiShare);
			groupBox1.Controls.Add(plVanBan);
			groupBox1.Controls.Add(rbShareOther);
			groupBox1.Controls.Add(rbShareLivestream);
			groupBox1.Controls.Add(ckbTuongTacTruocKhiShare);
			groupBox1.Controls.Add(label23);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(ckbVanBan);
			groupBox1.Controls.Add(nudDelayTo);
			groupBox1.Controls.Add(nudDelayFrom);
			groupBox1.Controls.Add(label20);
			groupBox1.Controls.Add(label19);
			groupBox1.Controls.Add(label2);
			groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			groupBox1.Location = new System.Drawing.Point(30, 80);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(853, 447);
			groupBox1.TabIndex = 8;
			groupBox1.TabStop = false;
			groupBox1.Text = "Câ\u0301u hi\u0300nh cha\u0323y";
			panel3.Controls.Add(rbShareRandomLink);
			panel3.Controls.Add(rbShareDeuLink);
			panel3.Location = new System.Drawing.Point(138, 161);
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
			txtLinkChiaSe.Location = new System.Drawing.Point(17, 67);
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
			plTuongTacTruocKhiShare.Size = new System.Drawing.Size(309, 345);
			plTuongTacTruocKhiShare.TabIndex = 10;
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(3, 7);
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
			label21.Location = new System.Drawing.Point(266, 7);
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
			label18.Location = new System.Drawing.Point(170, 7);
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
			nudSoLuongFrom.Location = new System.Drawing.Point(108, 5);
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
			nudSoLuongTo.Location = new System.Drawing.Point(205, 5);
			nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongTo.Name = "nudSoLuongTo";
			nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongTo.TabIndex = 39;
			plVanBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plVanBan.Controls.Add(linkLabel1);
			plVanBan.Controls.Add(txtNoiDung);
			plVanBan.Controls.Add(label8);
			plVanBan.Controls.Add(lblStatus);
			plVanBan.Location = new System.Drawing.Point(35, 236);
			plVanBan.Name = "plVanBan";
			plVanBan.Size = new System.Drawing.Size(456, 199);
			plVanBan.TabIndex = 72;
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
			txtNoiDung.TextChanged += new System.EventHandler(txtNoiDung_TextChanged_1);
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
			rbShareOther.Location = new System.Drawing.Point(278, 187);
			rbShareOther.Name = "rbShareOther";
			rbShareOther.Size = new System.Drawing.Size(191, 20);
			rbShareOther.TabIndex = 71;
			rbShareOther.TabStop = true;
			rbShareOther.Text = "Kha\u0301c (ba\u0300i viê\u0301t, a\u0309nh, video,...)";
			rbShareOther.UseVisualStyleBackColor = true;
			rbShareLivestream.AutoSize = true;
			rbShareLivestream.Cursor = System.Windows.Forms.Cursors.Hand;
			rbShareLivestream.Location = new System.Drawing.Point(141, 188);
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
			label23.Location = new System.Drawing.Point(14, 165);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(124, 16);
			label23.TabIndex = 70;
			label23.Text = "Tu\u0300y cho\u0323n share link:";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(14, 190);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(95, 16);
			label7.TabIndex = 70;
			label7.Text = "Loa\u0323i link share:";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(14, 49);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(116, 16);
			label3.TabIndex = 70;
			label3.Text = "Link cần share (0):";
			ckbVanBan.AutoSize = true;
			ckbVanBan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbVanBan.Location = new System.Drawing.Point(17, 213);
			ckbVanBan.Name = "ckbVanBan";
			ckbVanBan.Size = new System.Drawing.Size(113, 20);
			ckbVanBan.TabIndex = 67;
			ckbVanBan.Text = "Nội dung share";
			ckbVanBan.UseVisualStyleBackColor = true;
			ckbVanBan.CheckedChanged += new System.EventHandler(ckbVanBan_CheckedChanged_1);
			nudDelayTo.Location = new System.Drawing.Point(238, 22);
			nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 63;
			nudDelayFrom.Location = new System.Drawing.Point(141, 22);
			nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 62;
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(203, 24);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(29, 16);
			label20.TabIndex = 66;
			label20.Text = "đê\u0301n";
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(297, 24);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(31, 16);
			label19.TabIndex = 65;
			label19.Text = "giây";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(14, 24);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(121, 16);
			label2.TabIndex = 64;
			label2.Text = "Khoảng cách share:";
			groupBox2.Controls.Add(plShareBaiLenNhom);
			groupBox2.Controls.Add(ckbShareBaiLenNhom);
			groupBox2.Controls.Add(ckbShareBaiLenTuong);
			groupBox2.Location = new System.Drawing.Point(889, 80);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(343, 290);
			groupBox2.TabIndex = 62;
			groupBox2.TabStop = false;
			groupBox2.Text = "Tùy chọn share";
			plShareBaiLenNhom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plShareBaiLenNhom.Controls.Add(panel4);
			plShareBaiLenNhom.Controls.Add(label27);
			plShareBaiLenNhom.Controls.Add(plShareNhomNangCao);
			plShareBaiLenNhom.Controls.Add(ckbShareNhomNangCao);
			plShareBaiLenNhom.Controls.Add(nudCountGroupTo);
			plShareBaiLenNhom.Controls.Add(nudCountGroupFrom);
			plShareBaiLenNhom.Controls.Add(label24);
			plShareBaiLenNhom.Controls.Add(label25);
			plShareBaiLenNhom.Controls.Add(label26);
			plShareBaiLenNhom.Location = new System.Drawing.Point(23, 73);
			plShareBaiLenNhom.Name = "plShareBaiLenNhom";
			plShareBaiLenNhom.Size = new System.Drawing.Size(312, 210);
			plShareBaiLenNhom.TabIndex = 1;
			panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel4.Controls.Add(btnNhapNhom);
			panel4.Controls.Add(rbNhomTuNhap);
			panel4.Controls.Add(rbNgauNhienNhomThamGia);
			panel4.Location = new System.Drawing.Point(19, 48);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(285, 50);
			panel4.TabIndex = 59;
			btnNhapNhom.Cursor = System.Windows.Forms.Cursors.Hand;
			btnNhapNhom.Location = new System.Drawing.Point(205, 23);
			btnNhapNhom.Name = "btnNhapNhom";
			btnNhapNhom.Size = new System.Drawing.Size(75, 23);
			btnNhapNhom.TabIndex = 1;
			btnNhapNhom.Text = "Nhâ\u0323p";
			btnNhapNhom.UseSelectable = true;
			btnNhapNhom.Click += new System.EventHandler(btnNhapNhom_Click);
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
			rbNgauNhienNhomThamGia.AutoSize = true;
			rbNgauNhienNhomThamGia.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNgauNhienNhomThamGia.Location = new System.Drawing.Point(4, 3);
			rbNgauNhienNhomThamGia.Name = "rbNgauNhienNhomThamGia";
			rbNgauNhienNhomThamGia.Size = new System.Drawing.Size(198, 20);
			rbNgauNhienNhomThamGia.TabIndex = 0;
			rbNgauNhienNhomThamGia.TabStop = true;
			rbNgauNhienNhomThamGia.Text = "Ngâ\u0303u nhiên nho\u0301m đa\u0303 tham gia";
			rbNgauNhienNhomThamGia.UseVisualStyleBackColor = true;
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(3, 29);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(155, 16);
			label27.TabIndex = 60;
			label27.Text = "Tu\u0300y cho\u0323n nho\u0301m đê\u0309 share:";
			plShareNhomNangCao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plShareNhomNangCao.Controls.Add(ckbChiShareNhomKKD);
			plShareNhomNangCao.Controls.Add(ckbUuTienShareNhomNhieuThanhVien);
			plShareNhomNangCao.Controls.Add(ckbKhongShareTrungNhom);
			plShareNhomNangCao.Location = new System.Drawing.Point(19, 123);
			plShareNhomNangCao.Name = "plShareNhomNangCao";
			plShareNhomNangCao.Size = new System.Drawing.Size(285, 80);
			plShareNhomNangCao.TabIndex = 58;
			ckbChiShareNhomKKD.AutoSize = true;
			ckbChiShareNhomKKD.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbChiShareNhomKKD.Location = new System.Drawing.Point(4, 3);
			ckbChiShareNhomKKD.Name = "ckbChiShareNhomKKD";
			ckbChiShareNhomKKD.Size = new System.Drawing.Size(221, 20);
			ckbChiShareNhomKKD.TabIndex = 3;
			ckbChiShareNhomKKD.Text = "Chi\u0309 share nho\u0301m không kiê\u0309m duyê\u0323t";
			ckbChiShareNhomKKD.UseVisualStyleBackColor = true;
			ckbUuTienShareNhomNhieuThanhVien.AutoSize = true;
			ckbUuTienShareNhomNhieuThanhVien.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbUuTienShareNhomNhieuThanhVien.Location = new System.Drawing.Point(4, 29);
			ckbUuTienShareNhomNhieuThanhVien.Name = "ckbUuTienShareNhomNhieuThanhVien";
			ckbUuTienShareNhomNhieuThanhVien.Size = new System.Drawing.Size(255, 20);
			ckbUuTienShareNhomNhieuThanhVien.TabIndex = 3;
			ckbUuTienShareNhomNhieuThanhVien.Text = "Ưu tiên share nho\u0301m co\u0301 nhiê\u0300u tha\u0300nh viên";
			ckbUuTienShareNhomNhieuThanhVien.UseVisualStyleBackColor = true;
			ckbKhongShareTrungNhom.AutoSize = true;
			ckbKhongShareTrungNhom.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbKhongShareTrungNhom.Location = new System.Drawing.Point(4, 55);
			ckbKhongShareTrungNhom.Name = "ckbKhongShareTrungNhom";
			ckbKhongShareTrungNhom.Size = new System.Drawing.Size(168, 20);
			ckbKhongShareTrungNhom.TabIndex = 3;
			ckbKhongShareTrungNhom.Text = "Không share tru\u0300ng nho\u0301m";
			ckbKhongShareTrungNhom.UseVisualStyleBackColor = true;
			ckbShareNhomNangCao.AutoSize = true;
			ckbShareNhomNangCao.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbShareNhomNangCao.Location = new System.Drawing.Point(6, 101);
			ckbShareNhomNangCao.Name = "ckbShareNhomNangCao";
			ckbShareNhomNangCao.Size = new System.Drawing.Size(133, 20);
			ckbShareNhomNangCao.TabIndex = 57;
			ckbShareNhomNangCao.Text = "Câ\u0301u hi\u0300nh nâng cao";
			ckbShareNhomNangCao.UseVisualStyleBackColor = true;
			ckbShareNhomNangCao.CheckedChanged += new System.EventHandler(ckbShareNhomNangCao_CheckedChanged);
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
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(170, 5);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(29, 16);
			label24.TabIndex = 56;
			label24.Text = "đê\u0301n";
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
			ckbShareBaiLenNhom.Location = new System.Drawing.Point(11, 50);
			ckbShareBaiLenNhom.Name = "ckbShareBaiLenNhom";
			ckbShareBaiLenNhom.Size = new System.Drawing.Size(139, 20);
			ckbShareBaiLenNhom.TabIndex = 0;
			ckbShareBaiLenNhom.Text = "Share bài lên nhóm";
			ckbShareBaiLenNhom.UseVisualStyleBackColor = true;
			ckbShareBaiLenNhom.CheckedChanged += new System.EventHandler(ckbDangBaiLenNhom_CheckedChanged);
			ckbShareBaiLenTuong.AutoSize = true;
			ckbShareBaiLenTuong.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbShareBaiLenTuong.Location = new System.Drawing.Point(11, 23);
			ckbShareBaiLenTuong.Name = "ckbShareBaiLenTuong";
			ckbShareBaiLenTuong.Size = new System.Drawing.Size(140, 20);
			ckbShareBaiLenTuong.TabIndex = 0;
			ckbShareBaiLenTuong.Text = "Share bài lên tường";
			ckbShareBaiLenTuong.UseVisualStyleBackColor = true;
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(534, 540);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(193, 23);
			txtTenHanhDong.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(27, 52);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(99, 16);
			label1.TabIndex = 31;
			label1.Text = "Tên ha\u0300nh đô\u0323ng:";
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(633, 540);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.DarkViolet;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(1, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(1257, 37);
			bunifuCards1.TabIndex = 28;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1260, 582);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDShareBaiNangCao";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
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
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			plShareBaiLenNhom.ResumeLayout(false);
			plShareBaiLenNhom.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			plShareNhomNangCao.ResumeLayout(false);
			plShareNhomNangCao.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountGroupTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountGroupFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
