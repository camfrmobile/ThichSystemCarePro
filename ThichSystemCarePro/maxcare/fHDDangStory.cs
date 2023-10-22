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
	public class fHDDangStory : Form
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

		private TextBox txtTenHanhDong;

		private Label label1;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private Button button1;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Label lblStatus;

		private CheckBox ckbUseBackground;

		private TextBox txtNoiDung;

		private Label label8;

		private Panel plDangText;

		private Label label2;

		private Panel plDangNhac;

		private Panel plBaiHatChiDinh;

		private Label label3;

		private TextBox txtDanhSachBaiHat;

		private Label label4;

		private RadioButton rbBaiHatChiDinh;

		private RadioButton rbBaiHatNgauNhien;

		private RadioButton rbDangNhac;

		private RadioButton rbDangText;

		private Label label5;

		private NumericUpDown nudSoLuongTo;

		private NumericUpDown nudSoLuongFrom;

		private Label label6;

		private Label label7;

		public fHDDangStory(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			if (InteractSQL.GetTuongTac("", "HDDangStory").Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\", \"MoTa\") VALUES ('HDDangStory', 'Đăng story');");
			}
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDDangStory");
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
			Language.GetValue(ckbUseBackground);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(rbDangText);
			Language.GetValue(rbDangNhac);
			Language.GetValue(rbBaiHatNgauNhien);
			Language.GetValue(rbBaiHatChiDinh);
			Language.GetValue(label5);
			Language.GetValue(label6);
			Language.GetValue(label7);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudSoLuongFrom.Value = setting.GetValueInt("nudSoLuongFrom", 1);
				nudSoLuongTo.Value = setting.GetValueInt("nudSoLuongTo", 1);
				if (setting.GetValueInt("typeDang") == 0)
				{
					rbDangText.Checked = true;
				}
				else
				{
					rbDangNhac.Checked = true;
				}
				txtNoiDung.Text = setting.GetValue("txtNoiDung");
				ckbUseBackground.Checked = setting.GetValueBool("ckbUseBackground");
				if (setting.GetValueInt("typeBaiHat") == 0)
				{
					rbBaiHatNgauNhien.Checked = true;
				}
				else
				{
					rbBaiHatChiDinh.Checked = true;
				}
				txtDanhSachBaiHat.Text = setting.GetValue("txtDanhSachBaiHat");
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
			jSON_Settings.Update("nudSoLuongFrom", nudSoLuongFrom.Value);
			jSON_Settings.Update("nudSoLuongTo", nudSoLuongTo.Value);
			if (rbDangText.Checked)
			{
				jSON_Settings.Update("typeDang", 0);
			}
			else
			{
				jSON_Settings.Update("typeDang", 1);
			}
			jSON_Settings.Update("txtNoiDung", txtNoiDung.Text);
			jSON_Settings.Update("ckbUseBackground", ckbUseBackground.Checked);
			if (rbBaiHatNgauNhien.Checked)
			{
				jSON_Settings.Update("typeBaiHat", 0);
			}
			else
			{
				jSON_Settings.Update("typeBaiHat", 1);
			}
			jSON_Settings.Update("txtDanhSachBaiHat", txtDanhSachBaiHat.Text);
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

		private void txtComment_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtNoiDung.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblStatus.Text = string.Format(Language.GetValue("Nội dung story ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void CheckedChangeFull()
		{
			radioButton1_CheckedChanged(null, null);
			rbDangNhac_CheckedChanged(null, null);
			rbBaiHatChiDinh_CheckedChanged(null, null);
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			plDangText.Enabled = rbDangText.Checked;
		}

		private void rbDangNhac_CheckedChanged(object sender, EventArgs e)
		{
			plDangNhac.Enabled = rbDangNhac.Checked;
		}

		private void txtDanhSachBaiHat_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtDanhSachBaiHat.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				label4.Text = string.Format(Language.GetValue("Danh sa\u0301ch ba\u0300i ha\u0301t ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void rbBaiHatChiDinh_CheckedChanged(object sender, EventArgs e)
		{
			plBaiHatChiDinh.Enabled = rbBaiHatChiDinh.Checked;
		}

		private void plBaiHatChiDinh_Paint(object sender, PaintEventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDDangStory));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
			nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			plDangNhac = new System.Windows.Forms.Panel();
			plBaiHatChiDinh = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			txtDanhSachBaiHat = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			rbBaiHatChiDinh = new System.Windows.Forms.RadioButton();
			rbBaiHatNgauNhien = new System.Windows.Forms.RadioButton();
			plDangText = new System.Windows.Forms.Panel();
			label8 = new System.Windows.Forms.Label();
			ckbUseBackground = new System.Windows.Forms.CheckBox();
			lblStatus = new System.Windows.Forms.Label();
			txtNoiDung = new System.Windows.Forms.TextBox();
			rbDangNhac = new System.Windows.Forms.RadioButton();
			rbDangText = new System.Windows.Forms.RadioButton();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
			plDangNhac.SuspendLayout();
			plBaiHatChiDinh.SuspendLayout();
			plDangText.SuspendLayout();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(472, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Đăng Story";
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
			pnlHeader.Size = new System.Drawing.Size(472, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(441, 1);
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
			panel1.Controls.Add(nudSoLuongTo);
			panel1.Controls.Add(nudSoLuongFrom);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(plDangNhac);
			panel1.Controls.Add(plDangText);
			panel1.Controls.Add(rbDangNhac);
			panel1.Controls.Add(rbDangText);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(475, 597);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			nudSoLuongTo.Location = new System.Drawing.Point(229, 78);
			nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongTo.Name = "nudSoLuongTo";
			nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongTo.TabIndex = 39;
			nudSoLuongFrom.Location = new System.Drawing.Point(132, 78);
			nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongFrom.Name = "nudSoLuongFrom";
			nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongFrom.TabIndex = 38;
			label6.Location = new System.Drawing.Point(194, 80);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(29, 16);
			label6.TabIndex = 41;
			label6.Text = "đê\u0301n";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(290, 80);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(36, 16);
			label7.TabIndex = 40;
			label7.Text = "story";
			plDangNhac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plDangNhac.Controls.Add(plBaiHatChiDinh);
			plDangNhac.Controls.Add(rbBaiHatChiDinh);
			plDangNhac.Controls.Add(rbBaiHatNgauNhien);
			plDangNhac.Location = new System.Drawing.Point(132, 314);
			plDangNhac.Name = "plDangNhac";
			plDangNhac.Size = new System.Drawing.Size(305, 221);
			plDangNhac.TabIndex = 33;
			plBaiHatChiDinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plBaiHatChiDinh.Controls.Add(label3);
			plBaiHatChiDinh.Controls.Add(txtDanhSachBaiHat);
			plBaiHatChiDinh.Controls.Add(label4);
			plBaiHatChiDinh.Location = new System.Drawing.Point(18, 51);
			plBaiHatChiDinh.Name = "plBaiHatChiDinh";
			plBaiHatChiDinh.Size = new System.Drawing.Size(278, 161);
			plBaiHatChiDinh.TabIndex = 8;
			plBaiHatChiDinh.Paint += new System.Windows.Forms.PaintEventHandler(plBaiHatChiDinh_Paint);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(3, 138);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(134, 16);
			label3.TabIndex = 2;
			label3.Text = "(Mỗi nội dung 1 dòng)";
			txtDanhSachBaiHat.Location = new System.Drawing.Point(7, 24);
			txtDanhSachBaiHat.Multiline = true;
			txtDanhSachBaiHat.Name = "txtDanhSachBaiHat";
			txtDanhSachBaiHat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtDanhSachBaiHat.Size = new System.Drawing.Size(261, 111);
			txtDanhSachBaiHat.TabIndex = 1;
			txtDanhSachBaiHat.WordWrap = false;
			txtDanhSachBaiHat.TextChanged += new System.EventHandler(txtDanhSachBaiHat_TextChanged);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(3, 3);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(136, 16);
			label4.TabIndex = 0;
			label4.Text = "Danh sa\u0301ch ba\u0300i ha\u0301t (0):";
			rbBaiHatChiDinh.AutoSize = true;
			rbBaiHatChiDinh.Cursor = System.Windows.Forms.Cursors.Hand;
			rbBaiHatChiDinh.Location = new System.Drawing.Point(6, 29);
			rbBaiHatChiDinh.Name = "rbBaiHatChiDinh";
			rbBaiHatChiDinh.Size = new System.Drawing.Size(113, 20);
			rbBaiHatChiDinh.TabIndex = 32;
			rbBaiHatChiDinh.TabStop = true;
			rbBaiHatChiDinh.Text = "Ba\u0300i ha\u0301t chi\u0309 đi\u0323nh";
			rbBaiHatChiDinh.UseVisualStyleBackColor = true;
			rbBaiHatChiDinh.CheckedChanged += new System.EventHandler(rbBaiHatChiDinh_CheckedChanged);
			rbBaiHatNgauNhien.AutoSize = true;
			rbBaiHatNgauNhien.Cursor = System.Windows.Forms.Cursors.Hand;
			rbBaiHatNgauNhien.Location = new System.Drawing.Point(6, 3);
			rbBaiHatNgauNhien.Name = "rbBaiHatNgauNhien";
			rbBaiHatNgauNhien.Size = new System.Drawing.Size(132, 20);
			rbBaiHatNgauNhien.TabIndex = 32;
			rbBaiHatNgauNhien.TabStop = true;
			rbBaiHatNgauNhien.Text = "Ba\u0300i ha\u0301t ngâ\u0303u nhiên";
			rbBaiHatNgauNhien.UseVisualStyleBackColor = true;
			plDangText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plDangText.Controls.Add(label8);
			plDangText.Controls.Add(ckbUseBackground);
			plDangText.Controls.Add(lblStatus);
			plDangText.Controls.Add(txtNoiDung);
			plDangText.Location = new System.Drawing.Point(132, 125);
			plDangText.Name = "plDangText";
			plDangText.Size = new System.Drawing.Size(305, 183);
			plDangText.TabIndex = 33;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(14, 137);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(266, 16);
			label8.TabIndex = 2;
			label8.Text = "(Mỗi nội dung 1 dòng, spin nội dung {a|b|c})";
			ckbUseBackground.AutoSize = true;
			ckbUseBackground.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbUseBackground.Location = new System.Drawing.Point(6, 157);
			ckbUseBackground.Name = "ckbUseBackground";
			ckbUseBackground.Size = new System.Drawing.Size(145, 20);
			ckbUseBackground.TabIndex = 7;
			ckbUseBackground.Text = "Sư\u0309 du\u0323ng background";
			ckbUseBackground.UseVisualStyleBackColor = true;
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 3);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(116, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Nội dung story (0):";
			txtNoiDung.Location = new System.Drawing.Point(18, 23);
			txtNoiDung.Multiline = true;
			txtNoiDung.Name = "txtNoiDung";
			txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtNoiDung.Size = new System.Drawing.Size(261, 111);
			txtNoiDung.TabIndex = 1;
			txtNoiDung.WordWrap = false;
			txtNoiDung.TextChanged += new System.EventHandler(txtComment_TextChanged);
			rbDangNhac.AutoSize = true;
			rbDangNhac.Cursor = System.Windows.Forms.Cursors.Hand;
			rbDangNhac.Location = new System.Drawing.Point(39, 314);
			rbDangNhac.Name = "rbDangNhac";
			rbDangNhac.Size = new System.Drawing.Size(87, 20);
			rbDangNhac.TabIndex = 32;
			rbDangNhac.TabStop = true;
			rbDangNhac.Text = "Đăng nha\u0323c";
			rbDangNhac.UseVisualStyleBackColor = true;
			rbDangNhac.CheckedChanged += new System.EventHandler(rbDangNhac_CheckedChanged);
			rbDangText.AutoSize = true;
			rbDangText.Cursor = System.Windows.Forms.Cursors.Hand;
			rbDangText.Location = new System.Drawing.Point(39, 125);
			rbDangText.Name = "rbDangText";
			rbDangText.Size = new System.Drawing.Size(81, 20);
			rbDangText.TabIndex = 32;
			rbDangText.TabStop = true;
			rbDangText.Text = "Đăng text";
			rbDangText.UseVisualStyleBackColor = true;
			rbDangText.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
			txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(305, 23);
			txtTenHanhDong.TabIndex = 0;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(27, 80);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(96, 16);
			label5.TabIndex = 31;
			label5.Text = "Sô\u0301 lươ\u0323ng story:";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(27, 103);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(97, 16);
			label2.TabIndex = 31;
			label2.Text = "Tu\u0300y cho\u0323n đăng:";
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
			btnCancel.Location = new System.Drawing.Point(245, 554);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 10;
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
			btnAdd.Location = new System.Drawing.Point(138, 554);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 9;
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
			bunifuCards1.Size = new System.Drawing.Size(472, 37);
			bunifuCards1.TabIndex = 28;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(475, 597);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDDangStory";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
			plDangNhac.ResumeLayout(false);
			plDangNhac.PerformLayout();
			plBaiHatChiDinh.ResumeLayout(false);
			plBaiHatChiDinh.PerformLayout();
			plDangText.ResumeLayout(false);
			plDangText.PerformLayout();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
