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
using maxcare.Properties;
using MCommon;

namespace maxcare
{
	public class fHDDongBoDanhBa : Form
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

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private NumericUpDown nudSoLuongTo;

		private NumericUpDown nudSoLuongFrom;

		private Label label7;

		private Label label6;

		private Label label5;

		private Label label10;

		private Label lblStatusUid;

		private CheckBox ckbTuDongXoa;

		private Button button1;

		private RichTextBox txtSdt;

		private Panel plAutoAddFriend;

		private NumericUpDown nudDelayTo;

		private NumericUpDown nudDelayFrom;

		private Label label2;

		private Label label3;

		private Label label4;

		private NumericUpDown nudSoLuongKetBanTo;

		private NumericUpDown nudSoLuongKetBanFrom;

		private Label label8;

		private Label label9;

		private Label label11;

		private CheckBox ckbAutoAddFriend;

		public fHDDongBoDanhBa(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string text = "HDDongBoDanhBa";
			string text2 = "Đồng bộ danh bạ";
			if (InteractSQL.GetTuongTac("", "HDDongBoDanhBa").Rows.Count == 0)
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
				txtTenHanhDong.Text = tuongTac.Rows[0]["MoTa"].ToString();
				break;
			}
			case 1:
			{
				DataTable hanhDongById = InteractSQL.GetHanhDongById(id_HanhDong);
				jsonStringOrPathFile = hanhDongById.Rows[0]["CauHinh"].ToString();
				btnAdd.Text = "Câ\u0323p nhâ\u0323t";
				txtTenHanhDong.Text = hanhDongById.Rows[0]["TenHanhDong"].ToString();
				break;
			}
			}
			setting = new JSON_Settings(jsonStringOrPathFile, isJsonString: true);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				txtSdt.Text = setting.GetValue("txtSdt");
				nudSoLuongFrom.Value = setting.GetValueInt("nudSoLuongFrom", 10);
				nudSoLuongTo.Value = setting.GetValueInt("nudSoLuongTo", 10);
				ckbTuDongXoa.Checked = setting.GetValueBool("ckbTuDongXoa");
				ckbAutoAddFriend.Checked = setting.GetValueBool("ckbAutoAddFriend");
				nudSoLuongKetBanFrom.Value = setting.GetValueInt("nudSoLuongKetBanFrom", 2);
				nudSoLuongKetBanTo.Value = setting.GetValueInt("nudSoLuongKetBanTo", 5);
				nudDelayFrom.Value = setting.GetValueInt("nudDelayFrom", 2);
				nudDelayTo.Value = setting.GetValueInt("nudDelayTo", 5);
				ckbAutoAddFriend_CheckedChanged(null, null);
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
				MessageBoxHelper.ShowMessageBox("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
				return;
			}
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("txtSdt", txtSdt.Text.Trim());
			jSON_Settings.Update("nudSoLuongFrom", nudSoLuongFrom.Value);
			jSON_Settings.Update("nudSoLuongTo", nudSoLuongTo.Value);
			jSON_Settings.Update("ckbTuDongXoa", ckbTuDongXoa.Checked);
			jSON_Settings.Update("ckbAutoAddFriend", ckbAutoAddFriend.Checked);
			jSON_Settings.Update("nudSoLuongKetBanFrom", nudSoLuongKetBanFrom.Value);
			jSON_Settings.Update("nudSoLuongKetBanTo", nudSoLuongKetBanTo.Value);
			jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
			jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
			string fullString = jSON_Settings.GetFullString();
			if (type == 0)
			{
				if (MessageBox.Show("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?", "Thông ba\u0301o", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (InteractSQL.InsertHanhDong(id_KichBan, text, id_TuongTac, fullString))
					{
						isSave = true;
						Close();
					}
					else
					{
						MessageBoxHelper.ShowMessageBox("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
					}
				}
			}
			else if (MessageBox.Show("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?", "Thông ba\u0301o", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (InteractSQL.UpdateHanhDong(Id_HanhDong, text, fullString))
				{
					isSave = true;
					Close();
				}
				else
				{
					MessageBoxHelper.ShowMessageBox("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
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

		private void txtComment_TextChanged_1(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtSdt.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblStatusUid.Text = "Nhập danh sách số điện thoại (" + lst.Count + "):";
			}
			catch
			{
			}
		}

		private void ckbAutoAddFriend_CheckedChanged(object sender, EventArgs e)
		{
			plAutoAddFriend.Enabled = ckbAutoAddFriend.Checked;
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
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			txtSdt = new System.Windows.Forms.RichTextBox();
			ckbTuDongXoa = new System.Windows.Forms.CheckBox();
			lblStatusUid = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
			nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			plAutoAddFriend = new System.Windows.Forms.Panel();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			nudDelayFrom = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			nudSoLuongKetBanTo = new System.Windows.Forms.NumericUpDown();
			nudSoLuongKetBanFrom = new System.Windows.Forms.NumericUpDown();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			ckbAutoAddFriend = new System.Windows.Forms.CheckBox();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
			bunifuCards1.SuspendLayout();
			plAutoAddFriend.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongKetBanTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongKetBanFrom).BeginInit();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(354, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Đồng bộ danh bạ";
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
			pnlHeader.Size = new System.Drawing.Size(354, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = maxcare.Properties.Resources.btnMinimize_Image;
			button1.Location = new System.Drawing.Point(324, 1);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(30, 30);
			button1.TabIndex = 80;
			button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = maxcare.Properties.Resources.icon_64;
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 76;
			pictureBox1.TabStop = false;
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(plAutoAddFriend);
			panel1.Controls.Add(txtSdt);
			panel1.Controls.Add(ckbAutoAddFriend);
			panel1.Controls.Add(ckbTuDongXoa);
			panel1.Controls.Add(lblStatusUid);
			panel1.Controls.Add(label10);
			panel1.Controls.Add(nudSoLuongTo);
			panel1.Controls.Add(nudSoLuongFrom);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label6);
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
			panel1.Size = new System.Drawing.Size(357, 505);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			txtSdt.Location = new System.Drawing.Point(31, 101);
			txtSdt.Name = "txtSdt";
			txtSdt.Size = new System.Drawing.Size(295, 183);
			txtSdt.TabIndex = 50;
			txtSdt.Text = "";
			txtSdt.TextChanged += new System.EventHandler(txtComment_TextChanged_1);
			ckbTuDongXoa.AutoSize = true;
			ckbTuDongXoa.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuDongXoa.Location = new System.Drawing.Point(30, 340);
			ckbTuDongXoa.Name = "ckbTuDongXoa";
			ckbTuDongXoa.Size = new System.Drawing.Size(260, 20);
			ckbTuDongXoa.TabIndex = 2;
			ckbTuDongXoa.Text = "Tự động xóa những sđt đã được đồng bộ";
			ckbTuDongXoa.UseVisualStyleBackColor = true;
			lblStatusUid.AutoSize = true;
			lblStatusUid.Location = new System.Drawing.Point(27, 81);
			lblStatusUid.Name = "lblStatusUid";
			lblStatusUid.Size = new System.Drawing.Size(202, 16);
			lblStatusUid.TabIndex = 0;
			lblStatusUid.Text = "Nhập danh sách số điện thoại (0):";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(27, 287);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(158, 16);
			label10.TabIndex = 0;
			label10.Text = "(Mỗi số điện thoại 1 dòng)";
			nudSoLuongTo.Location = new System.Drawing.Point(243, 311);
			nudSoLuongTo.Maximum = new decimal(new int[4] { 1215752191, 23, 0, 0 });
			nudSoLuongTo.Name = "nudSoLuongTo";
			nudSoLuongTo.Size = new System.Drawing.Size(50, 23);
			nudSoLuongTo.TabIndex = 4;
			nudSoLuongFrom.Location = new System.Drawing.Point(160, 311);
			nudSoLuongFrom.Maximum = new decimal(new int[4] { 1215752191, 23, 0, 0 });
			nudSoLuongFrom.Name = "nudSoLuongFrom";
			nudSoLuongFrom.Size = new System.Drawing.Size(50, 23);
			nudSoLuongFrom.TabIndex = 3;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(212, 313);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 46;
			label7.Text = "đê\u0301n";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(295, 313);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(21, 16);
			label6.TabIndex = 45;
			label6.Text = "số";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(28, 313);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(131, 16);
			label5.TabIndex = 44;
			label5.Text = "Số lượng Sđt/thiết bị:";
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
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(187, 463);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 7;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(80, 463);
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
			bunifuCards1.Size = new System.Drawing.Size(354, 37);
			bunifuCards1.TabIndex = 28;
			plAutoAddFriend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plAutoAddFriend.Controls.Add(nudDelayTo);
			plAutoAddFriend.Controls.Add(nudDelayFrom);
			plAutoAddFriend.Controls.Add(label2);
			plAutoAddFriend.Controls.Add(label3);
			plAutoAddFriend.Controls.Add(label4);
			plAutoAddFriend.Controls.Add(nudSoLuongKetBanTo);
			plAutoAddFriend.Controls.Add(nudSoLuongKetBanFrom);
			plAutoAddFriend.Controls.Add(label8);
			plAutoAddFriend.Controls.Add(label9);
			plAutoAddFriend.Controls.Add(label11);
			plAutoAddFriend.Location = new System.Drawing.Point(49, 391);
			plAutoAddFriend.Name = "plAutoAddFriend";
			plAutoAddFriend.Size = new System.Drawing.Size(277, 60);
			plAutoAddFriend.TabIndex = 51;
			nudDelayTo.Location = new System.Drawing.Point(186, 32);
			nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 51;
			nudDelayFrom.Location = new System.Drawing.Point(89, 32);
			nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 50;
			label2.Location = new System.Drawing.Point(151, 34);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(29, 16);
			label2.TabIndex = 58;
			label2.Text = "đê\u0301n";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(244, 34);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(31, 16);
			label3.TabIndex = 57;
			label3.Text = "giây";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(3, 34);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(90, 16);
			label4.TabIndex = 56;
			label4.Text = "Thời gian chờ:";
			nudSoLuongKetBanTo.Location = new System.Drawing.Point(186, 4);
			nudSoLuongKetBanTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongKetBanTo.Name = "nudSoLuongKetBanTo";
			nudSoLuongKetBanTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongKetBanTo.TabIndex = 49;
			nudSoLuongKetBanFrom.Location = new System.Drawing.Point(89, 4);
			nudSoLuongKetBanFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongKetBanFrom.Name = "nudSoLuongKetBanFrom";
			nudSoLuongKetBanFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongKetBanFrom.TabIndex = 48;
			label8.Location = new System.Drawing.Point(151, 6);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(29, 16);
			label8.TabIndex = 55;
			label8.Text = "đê\u0301n";
			label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(244, 6);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(29, 16);
			label9.TabIndex = 54;
			label9.Text = "ba\u0323n";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(3, 6);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(64, 16);
			label11.TabIndex = 53;
			label11.Text = "Sô\u0301 lươ\u0323ng:";
			ckbAutoAddFriend.AutoSize = true;
			ckbAutoAddFriend.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbAutoAddFriend.Location = new System.Drawing.Point(30, 366);
			ckbAutoAddFriend.Name = "ckbAutoAddFriend";
			ckbAutoAddFriend.Size = new System.Drawing.Size(209, 20);
			ckbAutoAddFriend.TabIndex = 2;
			ckbAutoAddFriend.Text = "Tự động kết bạn nếu có đề xuất";
			ckbAutoAddFriend.UseVisualStyleBackColor = true;
			ckbAutoAddFriend.CheckedChanged += new System.EventHandler(ckbAutoAddFriend_CheckedChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(357, 505);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDDongBoDanhBa";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			plAutoAddFriend.ResumeLayout(false);
			plAutoAddFriend.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongKetBanTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongKetBanFrom).EndInit();
			ResumeLayout(false);
		}
	}
}
