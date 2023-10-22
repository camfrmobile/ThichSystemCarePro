using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.KichBan;
using MCommon;

namespace maxcare
{
	public class fHDRoiNhom : Form
	{
		private JSON_Settings setting;

		private string id_KichBan;

		private string id_TuongTac;

		private string Id_HanhDong;

		private int type;

		public static bool isSave;

		private IContainer components = null;

		private BunifuDragControl bunifuDragControl1;

		private BunifuDragControl bunifuDragControl2;

		private Panel panel1;

		private NumericUpDown nudSoLuongTo;

		private NumericUpDown nudSoLuongFrom;

		private TextBox txtTenHanhDong;

		private Label label3;

		private Label label4;

		private Label label2;

		private Label label1;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private Button button1;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private NumericUpDown nudDelayTo;

		private NumericUpDown nudDelayFrom;

		private Label label7;

		private Label label6;

		private Label label5;

		private RadioButton rbRoiTheoDieuKien;

		private RadioButton rbNgauNhien;

		private Label label9;

		private Panel plUidChiDinh;

		private TextBox txtTuKhoa;

		private Label label10;

		private Label lblStatusUid;

		private Panel plDieuKienTuKhoa;

		private CheckBox ckbDieuKienTuKhoa;

		private CheckBox ckbDieuKienThanhVien;

		private NumericUpDown nudThanhVienToiDa;

		private Label label12;

		private RichTextBox txtIDNhomGiuLai;

		private Label label8;

		private RadioButton rbNhomKiemDuyet;

		public fHDRoiNhom(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDRoiNhom");
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
			Language.GetValue(label2);
			Language.GetValue(label3);
			Language.GetValue(label4);
			Language.GetValue(label5);
			Language.GetValue(label7);
			Language.GetValue(label6);
			Language.GetValue(label9);
			Language.GetValue(rbNgauNhien);
			Language.GetValue(rbNhomKiemDuyet);
			Language.GetValue(rbRoiTheoDieuKien);
			Language.GetValue(ckbDieuKienThanhVien);
			Language.GetValue(ckbDieuKienTuKhoa);
			Language.GetValue(lblStatusUid);
			Language.GetValue(label10);
			Language.GetValue(label8);
			Language.GetValue(label12);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudSoLuongFrom.Value = setting.GetValueInt("nudSoLuongFrom");
				nudSoLuongTo.Value = setting.GetValueInt("nudSoLuongTo");
				nudDelayFrom.Value = setting.GetValueInt("nudDelayFrom");
				nudDelayTo.Value = setting.GetValueInt("nudDelayTo");
				if (setting.GetValueInt("typeRoiNhom") == 0)
				{
					rbNgauNhien.Checked = true;
				}
				else if (setting.GetValueInt("typeRoiNhom") == 1)
				{
					rbNhomKiemDuyet.Checked = true;
				}
				else
				{
					rbRoiTheoDieuKien.Checked = true;
				}
				ckbDieuKienThanhVien.Checked = setting.GetValueBool("ckbDieuKienThanhVien");
				nudThanhVienToiDa.Value = setting.GetValueInt("nudThanhVienToiDa");
				ckbDieuKienTuKhoa.Checked = setting.GetValueBool("ckbDieuKienTuKhoa");
				txtTuKhoa.Text = setting.GetValue("txtTuKhoa");
				txtIDNhomGiuLai.Text = setting.GetValue("txtIDNhomGiuLai");
			}
			catch
			{
			}
			CheckedChangedFull();
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
			if (rbRoiTheoDieuKien.Checked)
			{
				if (!ckbDieuKienThanhVien.Checked && !ckbDieuKienTuKhoa.Checked)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng cho\u0323n i\u0301t nhâ\u0301t mô\u0323t điê\u0300u kiê\u0323n rơ\u0300i nho\u0301m!"), 3);
					return;
				}
				if (ckbDieuKienTuKhoa.Checked)
				{
					List<string> lst = txtTuKhoa.Lines.ToList();
					lst = MCommon.Common.RemoveEmptyItems(lst);
					if (lst.Count == 0)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p danh sa\u0301ch tư\u0300 kho\u0301a!"), 3);
						return;
					}
				}
			}
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("nudSoLuongFrom", nudSoLuongFrom.Value);
			jSON_Settings.Update("nudSoLuongTo", nudSoLuongTo.Value);
			jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
			jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
			if (rbNgauNhien.Checked)
			{
				jSON_Settings.Update("typeRoiNhom", 0);
			}
			else if (rbNhomKiemDuyet.Checked)
			{
				jSON_Settings.Update("typeRoiNhom", 1);
			}
			else
			{
				jSON_Settings.Update("typeRoiNhom", 2);
			}
			jSON_Settings.Update("ckbDieuKienThanhVien", ckbDieuKienThanhVien.Checked);
			jSON_Settings.Update("nudThanhVienToiDa", nudThanhVienToiDa.Value);
			jSON_Settings.Update("ckbDieuKienTuKhoa", ckbDieuKienTuKhoa.Checked);
			jSON_Settings.Update("txtTuKhoa", txtTuKhoa.Text.Trim());
			jSON_Settings.Update("txtIDNhomGiuLai", txtIDNhomGiuLai.Text);
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

		private void rbUidChiDinh_CheckedChanged(object sender, EventArgs e)
		{
			CheckTypeDoiTuong();
		}

		private void CheckTypeDoiTuong()
		{
			plUidChiDinh.Enabled = rbRoiTheoDieuKien.Checked;
		}

		private void txtComment_TextChanged_1(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtTuKhoa.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblStatusUid.Text = string.Format(Language.GetValue("Danh sách tư\u0300 kho\u0301a ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void CheckedChangedFull()
		{
			ckbThanhVienToiDa_CheckedChanged(null, null);
			ckbDieuKienTuKhoa_CheckedChanged(null, null);
			CheckTypeDoiTuong();
		}

		private void ckbThanhVienToiDa_CheckedChanged(object sender, EventArgs e)
		{
			nudThanhVienToiDa.Enabled = ckbDieuKienThanhVien.Checked;
		}

		private void ckbDieuKienTuKhoa_CheckedChanged(object sender, EventArgs e)
		{
			plDieuKienTuKhoa.Enabled = ckbDieuKienTuKhoa.Checked;
		}

		private void label8_Click(object sender, EventArgs e)
		{
		}

		private void txtUidKhongHuyKetBan_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtIDNhomGiuLai.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				label8.Text = string.Format(Language.GetValue("Danh sách ID nhóm cần giữ lại ({0}):"), lst.Count);
			}
			catch
			{
			}
		}

		private void label12_Click(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDRoiNhom));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			label12 = new System.Windows.Forms.Label();
			txtIDNhomGiuLai = new System.Windows.Forms.RichTextBox();
			label8 = new System.Windows.Forms.Label();
			plUidChiDinh = new System.Windows.Forms.Panel();
			plDieuKienTuKhoa = new System.Windows.Forms.Panel();
			lblStatusUid = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			txtTuKhoa = new System.Windows.Forms.TextBox();
			ckbDieuKienTuKhoa = new System.Windows.Forms.CheckBox();
			ckbDieuKienThanhVien = new System.Windows.Forms.CheckBox();
			nudThanhVienToiDa = new System.Windows.Forms.NumericUpDown();
			rbRoiTheoDieuKien = new System.Windows.Forms.RadioButton();
			rbNhomKiemDuyet = new System.Windows.Forms.RadioButton();
			rbNgauNhien = new System.Windows.Forms.RadioButton();
			label9 = new System.Windows.Forms.Label();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			nudDelayFrom = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
			nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			plUidChiDinh.SuspendLayout();
			plDieuKienTuKhoa.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudThanhVienToiDa).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(644, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Rơ\u0300i nho\u0301m";
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
			pnlHeader.Size = new System.Drawing.Size(644, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(613, 1);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(30, 30);
			button1.TabIndex = 77;
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
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(label12);
			panel1.Controls.Add(txtIDNhomGiuLai);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(plUidChiDinh);
			panel1.Controls.Add(rbRoiTheoDieuKien);
			panel1.Controls.Add(rbNhomKiemDuyet);
			panel1.Controls.Add(rbNgauNhien);
			panel1.Controls.Add(label9);
			panel1.Controls.Add(nudDelayTo);
			panel1.Controls.Add(nudDelayFrom);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(nudSoLuongTo);
			panel1.Controls.Add(nudSoLuongFrom);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(647, 519);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(519, 456);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(97, 16);
			label12.TabIndex = 119;
			label12.Text = "(Mỗi ID 1 dòng)";
			label12.Click += new System.EventHandler(label12_Click);
			txtIDNhomGiuLai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtIDNhomGiuLai.Location = new System.Drawing.Point(359, 162);
			txtIDNhomGiuLai.Name = "txtIDNhomGiuLai";
			txtIDNhomGiuLai.Size = new System.Drawing.Size(253, 293);
			txtIDNhomGiuLai.TabIndex = 120;
			txtIDNhomGiuLai.Text = "";
			txtIDNhomGiuLai.WordWrap = false;
			txtIDNhomGiuLai.TextChanged += new System.EventHandler(txtUidKhongHuyKetBan_TextChanged);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(356, 143);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(208, 16);
			label8.TabIndex = 118;
			label8.Text = "Danh sách ID nhóm cần giữ lại (0):";
			label8.Click += new System.EventHandler(label8_Click);
			plUidChiDinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plUidChiDinh.Controls.Add(plDieuKienTuKhoa);
			plUidChiDinh.Controls.Add(ckbDieuKienTuKhoa);
			plUidChiDinh.Controls.Add(ckbDieuKienThanhVien);
			plUidChiDinh.Controls.Add(nudThanhVienToiDa);
			plUidChiDinh.Location = new System.Drawing.Point(31, 234);
			plUidChiDinh.Name = "plUidChiDinh";
			plUidChiDinh.Size = new System.Drawing.Size(295, 221);
			plUidChiDinh.TabIndex = 49;
			plDieuKienTuKhoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plDieuKienTuKhoa.Controls.Add(lblStatusUid);
			plDieuKienTuKhoa.Controls.Add(label10);
			plDieuKienTuKhoa.Controls.Add(txtTuKhoa);
			plDieuKienTuKhoa.Location = new System.Drawing.Point(24, 55);
			plDieuKienTuKhoa.Name = "plDieuKienTuKhoa";
			plDieuKienTuKhoa.Size = new System.Drawing.Size(265, 160);
			plDieuKienTuKhoa.TabIndex = 50;
			lblStatusUid.AutoSize = true;
			lblStatusUid.Location = new System.Drawing.Point(3, 3);
			lblStatusUid.Name = "lblStatusUid";
			lblStatusUid.Size = new System.Drawing.Size(140, 16);
			lblStatusUid.TabIndex = 0;
			lblStatusUid.Text = "Danh sách tư\u0300 kho\u0301a (0):";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(4, 139);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(128, 16);
			label10.TabIndex = 0;
			label10.Text = "(Mỗi tư\u0300 kho\u0301a 1 dòng)";
			txtTuKhoa.Location = new System.Drawing.Point(7, 25);
			txtTuKhoa.Multiline = true;
			txtTuKhoa.Name = "txtTuKhoa";
			txtTuKhoa.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtTuKhoa.Size = new System.Drawing.Size(253, 111);
			txtTuKhoa.TabIndex = 1;
			txtTuKhoa.WordWrap = false;
			txtTuKhoa.TextChanged += new System.EventHandler(txtComment_TextChanged_1);
			ckbDieuKienTuKhoa.AutoSize = true;
			ckbDieuKienTuKhoa.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbDieuKienTuKhoa.Location = new System.Drawing.Point(6, 29);
			ckbDieuKienTuKhoa.Name = "ckbDieuKienTuKhoa";
			ckbDieuKienTuKhoa.Size = new System.Drawing.Size(210, 20);
			ckbDieuKienTuKhoa.TabIndex = 2;
			ckbDieuKienTuKhoa.Text = "Tên nho\u0301m co\u0301 chư\u0301a tư\u0300 kho\u0301a sau:";
			ckbDieuKienTuKhoa.UseVisualStyleBackColor = true;
			ckbDieuKienTuKhoa.CheckedChanged += new System.EventHandler(ckbDieuKienTuKhoa_CheckedChanged);
			ckbDieuKienThanhVien.AutoSize = true;
			ckbDieuKienThanhVien.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbDieuKienThanhVien.Location = new System.Drawing.Point(6, 3);
			ckbDieuKienThanhVien.Name = "ckbDieuKienThanhVien";
			ckbDieuKienThanhVien.Size = new System.Drawing.Size(182, 20);
			ckbDieuKienThanhVien.TabIndex = 2;
			ckbDieuKienThanhVien.Text = "Sô\u0301 lươ\u0323ng tha\u0300nh viên i\u0301t hơn:";
			ckbDieuKienThanhVien.UseVisualStyleBackColor = true;
			ckbDieuKienThanhVien.CheckedChanged += new System.EventHandler(ckbThanhVienToiDa_CheckedChanged);
			nudThanhVienToiDa.Location = new System.Drawing.Point(197, 2);
			nudThanhVienToiDa.Maximum = new decimal(new int[4] { 999999999, 0, 0, 0 });
			nudThanhVienToiDa.Name = "nudThanhVienToiDa";
			nudThanhVienToiDa.Size = new System.Drawing.Size(92, 23);
			nudThanhVienToiDa.TabIndex = 1;
			rbRoiTheoDieuKien.AutoSize = true;
			rbRoiTheoDieuKien.Cursor = System.Windows.Forms.Cursors.Hand;
			rbRoiTheoDieuKien.Location = new System.Drawing.Point(31, 210);
			rbRoiTheoDieuKien.Name = "rbRoiTheoDieuKien";
			rbRoiTheoDieuKien.Size = new System.Drawing.Size(164, 20);
			rbRoiTheoDieuKien.TabIndex = 48;
			rbRoiTheoDieuKien.Text = "Rơ\u0300i nho\u0301m theo điê\u0300u kiê\u0323n";
			rbRoiTheoDieuKien.UseVisualStyleBackColor = true;
			rbRoiTheoDieuKien.CheckedChanged += new System.EventHandler(rbUidChiDinh_CheckedChanged);
			rbNhomKiemDuyet.AutoSize = true;
			rbNhomKiemDuyet.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNhomKiemDuyet.Location = new System.Drawing.Point(31, 186);
			rbNhomKiemDuyet.Name = "rbNhomKiemDuyet";
			rbNhomKiemDuyet.Size = new System.Drawing.Size(191, 20);
			rbNhomKiemDuyet.TabIndex = 48;
			rbNhomKiemDuyet.Text = "Rời nhóm kiểm duyệt bài viết";
			rbNhomKiemDuyet.UseVisualStyleBackColor = true;
			rbNgauNhien.AutoSize = true;
			rbNgauNhien.Checked = true;
			rbNgauNhien.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNgauNhien.Location = new System.Drawing.Point(31, 162);
			rbNgauNhien.Name = "rbNgauNhien";
			rbNgauNhien.Size = new System.Drawing.Size(188, 20);
			rbNgauNhien.TabIndex = 48;
			rbNgauNhien.TabStop = true;
			rbNgauNhien.Text = "Ngẫu nhiên danh sách nho\u0301m";
			rbNgauNhien.UseVisualStyleBackColor = true;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(28, 140);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(138, 16);
			label9.TabIndex = 47;
			label9.Text = "Tùy chọn nho\u0301m đê\u0309 rơ\u0300i:";
			nudDelayTo.Location = new System.Drawing.Point(229, 111);
			nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 4;
			nudDelayFrom.Location = new System.Drawing.Point(132, 111);
			nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 3;
			label7.Location = new System.Drawing.Point(194, 113);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 46;
			label7.Text = "đê\u0301n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(287, 113);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(31, 16);
			label6.TabIndex = 45;
			label6.Text = "giây";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(27, 113);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(90, 16);
			label5.TabIndex = 44;
			label5.Text = "Thơ\u0300i gian chơ\u0300:";
			nudSoLuongTo.Location = new System.Drawing.Point(229, 80);
			nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongTo.Name = "nudSoLuongTo";
			nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongTo.TabIndex = 2;
			nudSoLuongFrom.Location = new System.Drawing.Point(132, 80);
			nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongFrom.Name = "nudSoLuongFrom";
			nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongFrom.TabIndex = 1;
			txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
			txtTenHanhDong.TabIndex = 0;
			label3.Location = new System.Drawing.Point(194, 82);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 16);
			label3.TabIndex = 37;
			label3.Text = "đê\u0301n";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(287, 82);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(40, 16);
			label4.TabIndex = 35;
			label4.Text = "nho\u0301m";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(27, 82);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(100, 16);
			label2.TabIndex = 32;
			label2.Text = "Sô\u0301 lươ\u0323ng nhóm:";
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
			btnCancel.Location = new System.Drawing.Point(350, 477);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 7;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(243, 477);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 6;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
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
			bunifuCards1.Size = new System.Drawing.Size(644, 37);
			bunifuCards1.TabIndex = 28;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(647, 519);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDRoiNhom";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plUidChiDinh.ResumeLayout(false);
			plUidChiDinh.PerformLayout();
			plDieuKienTuKhoa.ResumeLayout(false);
			plDieuKienTuKhoa.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudThanhVienToiDa).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
