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
	public class fHDHuyKetBan : Form
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

		private RadioButton rbHuyTheoUid;

		private RadioButton rbHuyNgauNhien;

		private Label label8;

		private Panel plHuyTheoUid;

		private Label lblStatus;

		private Label label9;

		private RichTextBox txtUid;

		private Panel plHuyNgauNhien;

		private Label label12;

		private RichTextBox txtUidKhongHuyKetBan;

		private Label label10;

		public fHDHuyKetBan(string id_KichBan, int type = 0, string id_HanhDong = "")
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
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDHuyKetBan");
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
			Language.GetValue(label5);
			Language.GetValue(label7);
			Language.GetValue(label6);
			Language.GetValue(label8);
			Language.GetValue(rbHuyNgauNhien);
			Language.GetValue(label2);
			Language.GetValue(label3);
			Language.GetValue(label4);
			Language.GetValue(rbHuyTheoUid);
			Language.GetValue(lblStatus);
			Language.GetValue(label9);
			Language.GetValue(label10);
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
				if (setting.GetValueInt("typeHuyKetBan") == 0)
				{
					rbHuyNgauNhien.Checked = true;
				}
				else
				{
					rbHuyTheoUid.Checked = true;
				}
				txtUid.Text = setting.GetValue("txtUid");
				txtUidKhongHuyKetBan.Text = setting.GetValue("txtUidKhongHuyKetBan");
				rbHuyNgauNhien_CheckedChanged(null, null);
				rbHuyTheoUid_CheckedChanged(null, null);
			}
			catch
			{
			}
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
			jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
			jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
			if (rbHuyNgauNhien.Checked)
			{
				jSON_Settings.Update("typeHuyKetBan", 0);
			}
			else
			{
				jSON_Settings.Update("typeHuyKetBan", 1);
			}
			jSON_Settings.Update("txtUid", txtUid.Text);
			jSON_Settings.Update("txtUidKhongHuyKetBan", txtUidKhongHuyKetBan.Text);
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

		private void txtUid_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtUid.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblStatus.Text = string.Format(Language.GetValue("Danh sa\u0301ch Uid cần hủy kết bạn ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void rbHuyNgauNhien_CheckedChanged(object sender, EventArgs e)
		{
			plHuyNgauNhien.Enabled = rbHuyNgauNhien.Checked;
		}

		private void rbHuyTheoUid_CheckedChanged(object sender, EventArgs e)
		{
			plHuyTheoUid.Enabled = rbHuyTheoUid.Checked;
		}

		private void txtUidKhongHuyKetBan_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtUidKhongHuyKetBan.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				label10.Text = string.Format(Language.GetValue("Danh sách UID bạn bè cần giữ lại ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void label12_Click(object sender, EventArgs e)
		{
		}

		private void label10_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDHuyKetBan));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			label12 = new System.Windows.Forms.Label();
			txtUidKhongHuyKetBan = new System.Windows.Forms.RichTextBox();
			plHuyTheoUid = new System.Windows.Forms.Panel();
			lblStatus = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			txtUid = new System.Windows.Forms.RichTextBox();
			plHuyNgauNhien = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
			rbHuyTheoUid = new System.Windows.Forms.RadioButton();
			rbHuyNgauNhien = new System.Windows.Forms.RadioButton();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			nudDelayFrom = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			plHuyTheoUid.SuspendLayout();
			plHuyNgauNhien.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(687, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Hủy kết bạn";
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
			pnlHeader.Size = new System.Drawing.Size(687, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(656, 1);
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
			panel1.Controls.Add(txtUidKhongHuyKetBan);
			panel1.Controls.Add(plHuyTheoUid);
			panel1.Controls.Add(plHuyNgauNhien);
			panel1.Controls.Add(rbHuyTheoUid);
			panel1.Controls.Add(rbHuyNgauNhien);
			panel1.Controls.Add(nudDelayTo);
			panel1.Controls.Add(nudDelayFrom);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label10);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(690, 411);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(539, 324);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(103, 16);
			label12.TabIndex = 115;
			label12.Text = "(Mỗi Uid 1 dòng)";
			label12.Click += new System.EventHandler(label12_Click);
			txtUidKhongHuyKetBan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtUidKhongHuyKetBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtUidKhongHuyKetBan.Location = new System.Drawing.Point(385, 102);
			txtUidKhongHuyKetBan.Name = "txtUidKhongHuyKetBan";
			txtUidKhongHuyKetBan.Size = new System.Drawing.Size(253, 221);
			txtUidKhongHuyKetBan.TabIndex = 117;
			txtUidKhongHuyKetBan.Text = "";
			txtUidKhongHuyKetBan.WordWrap = false;
			txtUidKhongHuyKetBan.TextChanged += new System.EventHandler(txtUidKhongHuyKetBan_TextChanged);
			plHuyTheoUid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plHuyTheoUid.Controls.Add(lblStatus);
			plHuyTheoUid.Controls.Add(label9);
			plHuyTheoUid.Controls.Add(txtUid);
			plHuyTheoUid.Location = new System.Drawing.Point(59, 208);
			plHuyTheoUid.Name = "plHuyTheoUid";
			plHuyTheoUid.Size = new System.Drawing.Size(267, 134);
			plHuyTheoUid.TabIndex = 118;
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 3);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(209, 16);
			lblStatus.TabIndex = 116;
			lblStatus.Text = "Danh sa\u0301ch Uid cần hủy kết bạn (0):";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(161, 112);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(103, 16);
			label9.TabIndex = 115;
			label9.Text = "(Mỗi Uid 1 dòng)";
			txtUid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtUid.Location = new System.Drawing.Point(7, 23);
			txtUid.Name = "txtUid";
			txtUid.Size = new System.Drawing.Size(253, 86);
			txtUid.TabIndex = 117;
			txtUid.Text = "";
			txtUid.WordWrap = false;
			txtUid.TextChanged += new System.EventHandler(txtUid_TextChanged);
			plHuyNgauNhien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plHuyNgauNhien.Controls.Add(label2);
			plHuyNgauNhien.Controls.Add(label4);
			plHuyNgauNhien.Controls.Add(label3);
			plHuyNgauNhien.Controls.Add(nudSoLuongFrom);
			plHuyNgauNhien.Controls.Add(nudSoLuongTo);
			plHuyNgauNhien.Location = new System.Drawing.Point(59, 155);
			plHuyNgauNhien.Name = "plHuyNgauNhien";
			plHuyNgauNhien.Size = new System.Drawing.Size(267, 27);
			plHuyNgauNhien.TabIndex = 118;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 3);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(64, 16);
			label2.TabIndex = 32;
			label2.Text = "Sô\u0301 lươ\u0323ng:";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(225, 3);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(29, 16);
			label4.TabIndex = 35;
			label4.Text = "ba\u0323n";
			label3.Location = new System.Drawing.Point(135, 3);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 16);
			label3.TabIndex = 37;
			label3.Text = "đê\u0301n";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudSoLuongFrom.Location = new System.Drawing.Point(73, 1);
			nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongFrom.Name = "nudSoLuongFrom";
			nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongFrom.TabIndex = 1;
			nudSoLuongTo.Location = new System.Drawing.Point(167, 1);
			nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongTo.Name = "nudSoLuongTo";
			nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongTo.TabIndex = 2;
			rbHuyTheoUid.AutoSize = true;
			rbHuyTheoUid.Cursor = System.Windows.Forms.Cursors.Hand;
			rbHuyTheoUid.Location = new System.Drawing.Point(46, 185);
			rbHuyTheoUid.Name = "rbHuyTheoUid";
			rbHuyTheoUid.Size = new System.Drawing.Size(146, 20);
			rbHuyTheoUid.TabIndex = 47;
			rbHuyTheoUid.Text = "Hủy kết bạn theo UID";
			rbHuyTheoUid.UseVisualStyleBackColor = true;
			rbHuyTheoUid.CheckedChanged += new System.EventHandler(rbHuyTheoUid_CheckedChanged);
			rbHuyNgauNhien.AutoSize = true;
			rbHuyNgauNhien.Checked = true;
			rbHuyNgauNhien.Cursor = System.Windows.Forms.Cursors.Hand;
			rbHuyNgauNhien.Location = new System.Drawing.Point(46, 132);
			rbHuyNgauNhien.Name = "rbHuyNgauNhien";
			rbHuyNgauNhien.Size = new System.Drawing.Size(177, 20);
			rbHuyNgauNhien.TabIndex = 47;
			rbHuyNgauNhien.TabStop = true;
			rbHuyNgauNhien.Text = "Ngẫu nhiên danh sách bạn";
			rbHuyNgauNhien.UseVisualStyleBackColor = true;
			rbHuyNgauNhien.CheckedChanged += new System.EventHandler(rbHuyNgauNhien_CheckedChanged);
			nudDelayTo.Location = new System.Drawing.Point(226, 78);
			nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 4;
			nudDelayFrom.Location = new System.Drawing.Point(132, 78);
			nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 3;
			label7.Location = new System.Drawing.Point(192, 80);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 46;
			label7.Text = "đê\u0301n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(285, 80);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(31, 16);
			label6.TabIndex = 45;
			label6.Text = "giây";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(382, 83);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(223, 16);
			label10.TabIndex = 44;
			label10.Text = "Danh sách UID bạn bè cần giữ lại (0):";
			label10.Click += new System.EventHandler(label10_Click);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(27, 110);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(135, 16);
			label8.TabIndex = 44;
			label8.Text = "Tùy chọn hủy kết bạn:";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(27, 80);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(90, 16);
			label5.TabIndex = 44;
			label5.Text = "Thơ\u0300i gian chơ\u0300:";
			txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
			txtTenHanhDong.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(27, 52);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(99, 16);
			label1.TabIndex = 31;
			label1.Text = "Tên ha\u0300nh đô\u0323ng:";
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(352, 364);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 7;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(245, 364);
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
			bunifuCards1.Size = new System.Drawing.Size(687, 37);
			bunifuCards1.TabIndex = 28;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(690, 411);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDHuyKetBan";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plHuyTheoUid.ResumeLayout(false);
			plHuyTheoUid.PerformLayout();
			plHuyNgauNhien.ResumeLayout(false);
			plHuyNgauNhien.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
