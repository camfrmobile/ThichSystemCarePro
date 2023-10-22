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
	public class fHDTruyCapWebsite : Form
	{
		private JSON_Settings setting = null;

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

		private Label label8;

		private Label lblStatus;

		private RichTextBox txtLinkWeb;

		private NumericUpDown nudCountLinkClickTo;

		private NumericUpDown nudCountLinkTo;

		private NumericUpDown nudCountLinkClickFrom;

		private NumericUpDown nudCountLinkFrom;

		private Label label17;

		private Label label13;

		private Label label16;

		private Label label11;

		private Label label15;

		private Label label9;

		private CheckBox ckbLuot;

		private NumericUpDown nudCountTimeScrollTo;

		private Label label2;

		private Label label3;

		private Label label4;

		private NumericUpDown nudCountTimeScrollFrom;

		public fHDTruyCapWebsite(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			if (InteractSQL.GetTuongTac("", "HDTruyCapWebsite").Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\", \"MoTa\") VALUES ('HDTruyCapWebsite', 'Truy cập Website');");
			}
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDTruyCapWebsite");
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
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(label9);
			Language.GetValue(label13);
			Language.GetValue(label11);
			Language.GetValue(label15);
			Language.GetValue(label17);
			Language.GetValue(label16);
			Language.GetValue(label2);
			Language.GetValue(label4);
			Language.GetValue(label3);
			Language.GetValue(ckbLuot);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudCountLinkFrom.Value = setting.GetValueInt("nudCountLinkFrom", 1);
				nudCountLinkTo.Value = setting.GetValueInt("nudCountLinkTo", 1);
				nudCountLinkClickFrom.Value = setting.GetValueInt("nudCountLinkClickFrom", 3);
				nudCountLinkClickTo.Value = setting.GetValueInt("nudCountLinkClickTo", 5);
				nudCountTimeScrollFrom.Value = setting.GetValueInt("nudCountTimeScrollFrom", 30);
				nudCountTimeScrollTo.Value = setting.GetValueInt("nudCountTimeScrollTo", 30);
				txtLinkWeb.Text = setting.GetValue("txtLinkWeb");
				ckbLuot.Checked = setting.GetValueBool("ckbLuot", valueDefault: true);
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
			jSON_Settings.Update("nudCountLinkFrom", nudCountLinkFrom.Value);
			jSON_Settings.Update("nudCountLinkTo", nudCountLinkTo.Value);
			jSON_Settings.Update("nudCountLinkClickFrom", nudCountLinkClickFrom.Value);
			jSON_Settings.Update("nudCountLinkClickTo", nudCountLinkClickTo.Value);
			jSON_Settings.Update("nudCountTimeScrollFrom", nudCountTimeScrollFrom.Value);
			jSON_Settings.Update("nudCountTimeScrollTo", nudCountTimeScrollTo.Value);
			jSON_Settings.Update("txtLinkWeb", txtLinkWeb.Text.Trim());
			jSON_Settings.Update("ckbLuot", ckbLuot.Checked);
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
				List<string> lst = txtLinkWeb.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblStatus.Text = string.Format(Language.GetValue("Danh sa\u0301ch Link Web ({0}):"), lst.Count.ToString());
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDTruyCapWebsite));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			nudCountTimeScrollTo = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			ckbLuot = new System.Windows.Forms.CheckBox();
			label4 = new System.Windows.Forms.Label();
			txtLinkWeb = new System.Windows.Forms.RichTextBox();
			nudCountTimeScrollFrom = new System.Windows.Forms.NumericUpDown();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			nudCountLinkClickTo = new System.Windows.Forms.NumericUpDown();
			nudCountLinkTo = new System.Windows.Forms.NumericUpDown();
			nudCountLinkClickFrom = new System.Windows.Forms.NumericUpDown();
			nudCountLinkFrom = new System.Windows.Forms.NumericUpDown();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label17 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountTimeScrollTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountTimeScrollFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountLinkClickTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountLinkTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountLinkClickFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountLinkFrom).BeginInit();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(359, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Truy cập Website";
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
			pnlHeader.Size = new System.Drawing.Size(359, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(328, 1);
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
			panel1.Controls.Add(nudCountTimeScrollTo);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(ckbLuot);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(txtLinkWeb);
			panel1.Controls.Add(nudCountTimeScrollFrom);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(lblStatus);
			panel1.Controls.Add(nudCountLinkClickTo);
			panel1.Controls.Add(nudCountLinkTo);
			panel1.Controls.Add(nudCountLinkClickFrom);
			panel1.Controls.Add(nudCountLinkFrom);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label17);
			panel1.Controls.Add(label13);
			panel1.Controls.Add(label16);
			panel1.Controls.Add(label11);
			panel1.Controls.Add(label15);
			panel1.Controls.Add(label9);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(362, 419);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			nudCountTimeScrollTo.Location = new System.Drawing.Point(263, 316);
			nudCountTimeScrollTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountTimeScrollTo.Name = "nudCountTimeScrollTo";
			nudCountTimeScrollTo.Size = new System.Drawing.Size(36, 23);
			nudCountTimeScrollTo.TabIndex = 2;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(28, 318);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(121, 16);
			label2.TabIndex = 32;
			label2.Text = "Thời gian trên web:";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(299, 318);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(31, 16);
			label3.TabIndex = 35;
			label3.Text = "giây";
			ckbLuot.AutoSize = true;
			ckbLuot.Checked = true;
			ckbLuot.CheckState = System.Windows.Forms.CheckState.Checked;
			ckbLuot.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbLuot.Location = new System.Drawing.Point(30, 343);
			ckbLuot.Name = "ckbLuot";
			ckbLuot.Size = new System.Drawing.Size(158, 20);
			ckbLuot.TabIndex = 43;
			ckbLuot.Text = "Tự động lướt trên Web";
			ckbLuot.UseVisualStyleBackColor = true;
			label4.Location = new System.Drawing.Point(231, 318);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(29, 16);
			label4.TabIndex = 37;
			label4.Text = "đê\u0301n";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			txtLinkWeb.Location = new System.Drawing.Point(30, 94);
			txtLinkWeb.Name = "txtLinkWeb";
			txtLinkWeb.Size = new System.Drawing.Size(298, 142);
			txtLinkWeb.TabIndex = 42;
			txtLinkWeb.Text = "";
			txtLinkWeb.WordWrap = false;
			txtLinkWeb.TextChanged += new System.EventHandler(txtComment_TextChanged);
			nudCountTimeScrollFrom.Location = new System.Drawing.Point(192, 316);
			nudCountTimeScrollFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountTimeScrollFrom.Name = "nudCountTimeScrollFrom";
			nudCountTimeScrollFrom.Size = new System.Drawing.Size(36, 23);
			nudCountTimeScrollFrom.TabIndex = 1;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(28, 239);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(134, 16);
			label8.TabIndex = 0;
			label8.Text = "(Mỗi nội dung 1 do\u0300ng)";
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(27, 75);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(149, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Danh sa\u0301ch Link Web (0):";
			nudCountLinkClickTo.Location = new System.Drawing.Point(263, 288);
			nudCountLinkClickTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountLinkClickTo.Name = "nudCountLinkClickTo";
			nudCountLinkClickTo.Size = new System.Drawing.Size(36, 23);
			nudCountLinkClickTo.TabIndex = 2;
			nudCountLinkTo.Location = new System.Drawing.Point(263, 260);
			nudCountLinkTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountLinkTo.Name = "nudCountLinkTo";
			nudCountLinkTo.Size = new System.Drawing.Size(36, 23);
			nudCountLinkTo.TabIndex = 2;
			nudCountLinkClickFrom.Location = new System.Drawing.Point(192, 288);
			nudCountLinkClickFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountLinkClickFrom.Name = "nudCountLinkClickFrom";
			nudCountLinkClickFrom.Size = new System.Drawing.Size(36, 23);
			nudCountLinkClickFrom.TabIndex = 1;
			nudCountLinkFrom.Location = new System.Drawing.Point(192, 260);
			nudCountLinkFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountLinkFrom.Name = "nudCountLinkFrom";
			nudCountLinkFrom.Size = new System.Drawing.Size(36, 23);
			nudCountLinkFrom.TabIndex = 1;
			txtTenHanhDong.Location = new System.Drawing.Point(134, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
			txtTenHanhDong.TabIndex = 0;
			label17.Location = new System.Drawing.Point(231, 290);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(29, 16);
			label17.TabIndex = 37;
			label17.Text = "đê\u0301n";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label13.Location = new System.Drawing.Point(231, 262);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(29, 16);
			label13.TabIndex = 37;
			label13.Text = "đê\u0301n";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(299, 290);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(27, 16);
			label16.TabIndex = 35;
			label16.Text = "link";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(299, 262);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(27, 16);
			label11.TabIndex = 35;
			label11.Text = "link";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(28, 290);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(165, 16);
			label15.TabIndex = 34;
			label15.Text = "Click random link trên web:";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(27, 262);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(153, 16);
			label9.TabIndex = 32;
			label9.Text = "Sô\u0301 link web cần truy cập:";
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
			btnCancel.Location = new System.Drawing.Point(189, 375);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 10;
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
			btnAdd.Location = new System.Drawing.Point(82, 375);
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
			bunifuCards1.Size = new System.Drawing.Size(359, 37);
			bunifuCards1.TabIndex = 28;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(362, 419);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDTruyCapWebsite";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountTimeScrollTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountTimeScrollFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountLinkClickTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountLinkTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountLinkClickFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountLinkFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
