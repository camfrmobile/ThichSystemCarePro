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
	public class fHDDangBaiNhom : Form
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

		private CheckBox ckbVanBan;

		private Panel plVanBan;

		private Label label8;

		private Label lblStatus;

		private RichTextBox txtNoiDung;

		private RadioButton rbNganCachKyTu;

		private RadioButton rbNganCachMoiDong;

		private Label label9;

		private CheckBox ckbUseBackground;

		private Label label19;

		private Label label20;

		private NumericUpDown nudKhoangCachTo;

		private NumericUpDown nudKhoangCachFrom;

		private Label label18;

		private Label label17;

		private NumericUpDown nudSoLuongTo;

		private NumericUpDown nudSoLuongFrom;

		private Label label16;

		private Label label15;

		private CheckBox ckbXoaNguyenLieuDaDung;

		private LinkLabel linkLabel1;

		private Button button3;

		private Button button2;

		private CheckBox ckbChiDangNhomKKD;

		public fHDDangBaiNhom(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string text = base.Name.Substring(1);
			string text2 = "Đăng ba\u0300i lên nho\u0301m";
			if (InteractSQL.GetTuongTac("", text).Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\", \"MoTa\") VALUES ('" + text + "', '" + text2 + "');");
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
			Language.GetValue(label17);
			Language.GetValue(label18);
			Language.GetValue(label16);
			Language.GetValue(label20);
			Language.GetValue(label19);
			Language.GetValue(ckbVanBan);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(ckbUseBackground);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(ckbChiDangNhomKKD);
			Language.GetValue(label9);
			Language.GetValue(rbNganCachMoiDong);
			Language.GetValue(rbNganCachKyTu);
			Language.GetValue(ckbXoaNguyenLieuDaDung);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudSoLuongFrom.Value = setting.GetValueInt("nudSoLuongFrom", 1);
				nudSoLuongTo.Value = setting.GetValueInt("nudSoLuongTo", 1);
				nudKhoangCachFrom.Value = setting.GetValueInt("nudKhoangCachFrom", 5);
				nudKhoangCachTo.Value = setting.GetValueInt("nudKhoangCachTo", 10);
				ckbChiDangNhomKKD.Checked = setting.GetValueBool("ckbChiDangNhomKKD");
				ckbVanBan.Checked = setting.GetValueBool("ckbVanBan");
				ckbUseBackground.Checked = setting.GetValueBool("ckbUseBackground");
				ckbXoaNguyenLieuDaDung.Checked = setting.GetValueBool("ckbXoaNguyenLieuDaDung");
				txtNoiDung.Text = setting.GetValue("txtNoiDung");
				if (setting.GetValueInt("typeNganCach") == 1)
				{
					rbNganCachKyTu.Checked = true;
				}
				else
				{
					rbNganCachMoiDong.Checked = true;
				}
			}
			catch (Exception)
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
			jSON_Settings.Update("nudKhoangCachFrom", nudKhoangCachFrom.Value);
			jSON_Settings.Update("nudKhoangCachTo", nudKhoangCachTo.Value);
			jSON_Settings.Update("ckbChiDangNhomKKD", ckbChiDangNhomKKD.Checked);
			jSON_Settings.Update("ckbVanBan", ckbVanBan.Checked);
			jSON_Settings.Update("ckbUseBackground", ckbUseBackground.Checked);
			jSON_Settings.Update("ckbXoaNguyenLieuDaDung", ckbXoaNguyenLieuDaDung.Checked);
			jSON_Settings.Update("txtNoiDung", txtNoiDung.Text.Trim());
			int num = 0;
			if (rbNganCachKyTu.Checked)
			{
				num = 1;
			}
			jSON_Settings.Update("typeNganCach", num);
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
			ckbVanBan_CheckedChanged(null, null);
			ckbAnh_CheckedChanged(null, null);
		}

		private void ckbVanBan_CheckedChanged(object sender, EventArgs e)
		{
			plVanBan.Enabled = ckbVanBan.Checked;
			if (!ckbVanBan.Checked)
			{
				ckbUseBackground.Checked = false;
			}
		}

		private void ckbAnh_CheckedChanged(object sender, EventArgs e)
		{
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

		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		private void rbNganCachMoiDong_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void rbNganCachKyTu_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void ckbUseBackground_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MCommon.Common.ShowForm(new fHuongDanRandom());
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhập mỗi dòng là 1 nội dung!"));
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHelpNhapComment());
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDDangBaiNhom));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			label19 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			nudKhoangCachTo = new System.Windows.Forms.NumericUpDown();
			nudKhoangCachFrom = new System.Windows.Forms.NumericUpDown();
			label18 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
			nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			label16 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			plVanBan = new System.Windows.Forms.Panel();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			rbNganCachKyTu = new System.Windows.Forms.RadioButton();
			rbNganCachMoiDong = new System.Windows.Forms.RadioButton();
			label9 = new System.Windows.Forms.Label();
			txtNoiDung = new System.Windows.Forms.RichTextBox();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			ckbUseBackground = new System.Windows.Forms.CheckBox();
			btnAdd = new System.Windows.Forms.Button();
			ckbXoaNguyenLieuDaDung = new System.Windows.Forms.CheckBox();
			ckbChiDangNhomKKD = new System.Windows.Forms.CheckBox();
			ckbVanBan = new System.Windows.Forms.CheckBox();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
			plVanBan.SuspendLayout();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(674, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Đăng ba\u0300i lên nho\u0301m";
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
			pnlHeader.Size = new System.Drawing.Size(674, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(643, 1);
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
			panel1.Controls.Add(label19);
			panel1.Controls.Add(label20);
			panel1.Controls.Add(nudKhoangCachTo);
			panel1.Controls.Add(nudKhoangCachFrom);
			panel1.Controls.Add(label18);
			panel1.Controls.Add(label17);
			panel1.Controls.Add(nudSoLuongTo);
			panel1.Controls.Add(nudSoLuongFrom);
			panel1.Controls.Add(label16);
			panel1.Controls.Add(label15);
			panel1.Controls.Add(plVanBan);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(ckbXoaNguyenLieuDaDung);
			panel1.Controls.Add(ckbChiDangNhomKKD);
			panel1.Controls.Add(ckbVanBan);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(677, 505);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(291, 108);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(31, 16);
			label19.TabIndex = 43;
			label19.Text = "giây";
			label20.Location = new System.Drawing.Point(205, 108);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(29, 16);
			label20.TabIndex = 42;
			label20.Text = "đến";
			label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudKhoangCachTo.Location = new System.Drawing.Point(236, 106);
			nudKhoangCachTo.Name = "nudKhoangCachTo";
			nudKhoangCachTo.Size = new System.Drawing.Size(51, 23);
			nudKhoangCachTo.TabIndex = 41;
			nudKhoangCachFrom.Location = new System.Drawing.Point(151, 106);
			nudKhoangCachFrom.Name = "nudKhoangCachFrom";
			nudKhoangCachFrom.Size = new System.Drawing.Size(51, 23);
			nudKhoangCachFrom.TabIndex = 40;
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(291, 83);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(40, 16);
			label18.TabIndex = 39;
			label18.Text = "nho\u0301m";
			label17.Location = new System.Drawing.Point(205, 83);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(29, 16);
			label17.TabIndex = 38;
			label17.Text = "đến";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudSoLuongTo.Location = new System.Drawing.Point(236, 78);
			nudSoLuongTo.Name = "nudSoLuongTo";
			nudSoLuongTo.Size = new System.Drawing.Size(51, 23);
			nudSoLuongTo.TabIndex = 37;
			nudSoLuongFrom.Location = new System.Drawing.Point(151, 78);
			nudSoLuongFrom.Name = "nudSoLuongFrom";
			nudSoLuongFrom.Size = new System.Drawing.Size(51, 23);
			nudSoLuongFrom.TabIndex = 36;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(30, 108);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(117, 16);
			label16.TabIndex = 35;
			label16.Text = "Khoảng cách đăng:";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(30, 83);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(100, 16);
			label15.TabIndex = 34;
			label15.Text = "Số lượng nho\u0301m:";
			plVanBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plVanBan.Controls.Add(linkLabel1);
			plVanBan.Controls.Add(button3);
			plVanBan.Controls.Add(button2);
			plVanBan.Controls.Add(rbNganCachKyTu);
			plVanBan.Controls.Add(rbNganCachMoiDong);
			plVanBan.Controls.Add(label9);
			plVanBan.Controls.Add(txtNoiDung);
			plVanBan.Controls.Add(label8);
			plVanBan.Controls.Add(lblStatus);
			plVanBan.Controls.Add(ckbUseBackground);
			plVanBan.Location = new System.Drawing.Point(47, 181);
			plVanBan.Name = "plVanBan";
			plVanBan.Size = new System.Drawing.Size(597, 248);
			plVanBan.TabIndex = 33;
			linkLabel1.AutoSize = true;
			linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel1.Location = new System.Drawing.Point(154, 198);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(82, 16);
			linkLabel1.TabIndex = 195;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Random icon";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			button3.Cursor = System.Windows.Forms.Cursors.Help;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Location = new System.Drawing.Point(571, 220);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(21, 23);
			button3.TabIndex = 193;
			button3.Text = "?";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.Cursor = System.Windows.Forms.Cursors.Help;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(571, 197);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(21, 23);
			button2.TabIndex = 194;
			button2.Text = "?";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			rbNganCachKyTu.AutoSize = true;
			rbNganCachKyTu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachKyTu.Location = new System.Drawing.Point(412, 221);
			rbNganCachKyTu.Name = "rbNganCachKyTu";
			rbNganCachKyTu.Size = new System.Drawing.Size(160, 20);
			rbNganCachKyTu.TabIndex = 37;
			rbNganCachKyTu.Text = "Nội dung có nhiều dòng";
			rbNganCachKyTu.UseVisualStyleBackColor = true;
			rbNganCachKyTu.CheckedChanged += new System.EventHandler(rbNganCachKyTu_CheckedChanged);
			rbNganCachMoiDong.AutoSize = true;
			rbNganCachMoiDong.Checked = true;
			rbNganCachMoiDong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachMoiDong.Location = new System.Drawing.Point(412, 199);
			rbNganCachMoiDong.Name = "rbNganCachMoiDong";
			rbNganCachMoiDong.Size = new System.Drawing.Size(156, 20);
			rbNganCachMoiDong.TabIndex = 36;
			rbNganCachMoiDong.TabStop = true;
			rbNganCachMoiDong.Text = "Nội dung chỉ có 1 dòng";
			rbNganCachMoiDong.UseVisualStyleBackColor = true;
			rbNganCachMoiDong.CheckedChanged += new System.EventHandler(rbNganCachMoiDong_CheckedChanged);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(347, 199);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(65, 16);
			label9.TabIndex = 35;
			label9.Text = "Tùy chọn:";
			txtNoiDung.Location = new System.Drawing.Point(7, 24);
			txtNoiDung.Name = "txtNoiDung";
			txtNoiDung.Size = new System.Drawing.Size(585, 172);
			txtNoiDung.TabIndex = 34;
			txtNoiDung.Text = "";
			txtNoiDung.WordWrap = false;
			txtNoiDung.TextChanged += new System.EventHandler(txtNoiDung_TextChanged);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 198);
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
			ckbUseBackground.AutoSize = true;
			ckbUseBackground.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbUseBackground.Location = new System.Drawing.Point(6, 221);
			ckbUseBackground.Name = "ckbUseBackground";
			ckbUseBackground.Size = new System.Drawing.Size(145, 20);
			ckbUseBackground.TabIndex = 32;
			ckbUseBackground.Text = "Sử dụng Background";
			ckbUseBackground.UseVisualStyleBackColor = true;
			ckbUseBackground.CheckedChanged += new System.EventHandler(ckbUseBackground_CheckedChanged);
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(242, 464);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			ckbXoaNguyenLieuDaDung.AutoSize = true;
			ckbXoaNguyenLieuDaDung.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbXoaNguyenLieuDaDung.Location = new System.Drawing.Point(33, 432);
			ckbXoaNguyenLieuDaDung.Name = "ckbXoaNguyenLieuDaDung";
			ckbXoaNguyenLieuDaDung.Size = new System.Drawing.Size(152, 20);
			ckbXoaNguyenLieuDaDung.TabIndex = 32;
			ckbXoaNguyenLieuDaDung.Text = "Xóa nội dung đã đăng";
			ckbXoaNguyenLieuDaDung.UseVisualStyleBackColor = true;
			ckbXoaNguyenLieuDaDung.CheckedChanged += new System.EventHandler(ckbVanBan_CheckedChanged);
			ckbChiDangNhomKKD.AutoSize = true;
			ckbChiDangNhomKKD.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbChiDangNhomKKD.Location = new System.Drawing.Point(33, 133);
			ckbChiDangNhomKKD.Name = "ckbChiDangNhomKKD";
			ckbChiDangNhomKKD.Size = new System.Drawing.Size(217, 20);
			ckbChiDangNhomKKD.TabIndex = 32;
			ckbChiDangNhomKKD.Text = "Chi\u0309 đăng nho\u0301m không kiê\u0309m duyê\u0323t";
			ckbChiDangNhomKKD.UseVisualStyleBackColor = true;
			ckbVanBan.AutoSize = true;
			ckbVanBan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbVanBan.Location = new System.Drawing.Point(33, 157);
			ckbVanBan.Name = "ckbVanBan";
			ckbVanBan.Size = new System.Drawing.Size(74, 20);
			ckbVanBan.TabIndex = 32;
			ckbVanBan.Text = "Văn ba\u0309n";
			ckbVanBan.UseVisualStyleBackColor = true;
			ckbVanBan.CheckedChanged += new System.EventHandler(ckbVanBan_CheckedChanged);
			txtTenHanhDong.Location = new System.Drawing.Point(151, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(174, 23);
			txtTenHanhDong.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(30, 52);
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
			btnCancel.Location = new System.Drawing.Point(341, 464);
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
			bunifuCards1.Size = new System.Drawing.Size(674, 37);
			bunifuCards1.TabIndex = 28;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(677, 505);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDDangBaiNhom";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKhoangCachFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
			plVanBan.ResumeLayout(false);
			plVanBan.PerformLayout();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
