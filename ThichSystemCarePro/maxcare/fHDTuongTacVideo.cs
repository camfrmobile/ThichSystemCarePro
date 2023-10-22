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
	public class fHDTuongTacVideo : Form
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

		private Panel plComment;

		private Label lblStatus;

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

		private CheckBox ckbComment;

		private CheckBox ckbInteract;

		private TextBox txtComment;

		private Label label8;

		private Panel plBinhLuanNhieuLan;

		private NumericUpDown nudBinhLuanNhieuLanDelayTo;

		private Label lblmc1;

		private NumericUpDown nudBinhLuanNhieuLanDelayFrom;

		private Label label5;

		private Label label7;

		private Label label6;

		private CheckBox ckbBinhLuanNhieuLan;

		private TextBox txtLinkVideo;

		private Label label9;

		private LinkLabel linkLabel1;

		public fHDTuongTacVideo(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string text = base.Name.Substring(1);
			string text2 = "Tương tác Video";
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
			Language.GetValue(label2);
			Language.GetValue(label3);
			Language.GetValue(label4);
			Language.GetValue(ckbInteract);
			Language.GetValue(label26);
			Language.GetValue(label30);
			Language.GetValue(label32);
			Language.GetValue(ckbComment);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(ckbBinhLuanNhieuLan);
			Language.GetValue(label6);
			Language.GetValue(label5);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				txtLinkVideo.Text = setting.GetValue("txtLinkVideo");
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
			if (ckbComment.Checked)
			{
				List<string> lst = txtComment.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				if (lst.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p nô\u0323i dung bi\u0300nh luâ\u0323n!"), 3);
					return;
				}
			}
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("txtLinkVideo", txtLinkVideo.Text.Trim());
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

		private void txtComment_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtComment.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblStatus.Text = string.Format(Language.GetValue("Nội dung bình luận ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void CheckedChangeFull()
		{
			ckbInteract_CheckedChanged(null, null);
			ckbComment_CheckedChanged(null, null);
			ckbBinhLuanNhieuLan_CheckedChanged(null, null);
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
		{
			plInteract.Enabled = ckbInteract.Checked;
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
			plComment.Enabled = ckbComment.Checked;
		}

		private void label25_Click(object sender, EventArgs e)
		{
			ckbLike.Checked = !ckbLike.Checked;
		}

		private void label26_Click(object sender, EventArgs e)
		{
			ckbTym.Checked = !ckbTym.Checked;
		}

		private void label28_Click(object sender, EventArgs e)
		{
			ckbHaha.Checked = !ckbHaha.Checked;
		}

		private void label29_Click(object sender, EventArgs e)
		{
			ckbWow.Checked = !ckbWow.Checked;
		}

		private void label30_Click(object sender, EventArgs e)
		{
			ckbBuon.Checked = !ckbBuon.Checked;
		}

		private void label32_Click(object sender, EventArgs e)
		{
			ckbGian.Checked = !ckbGian.Checked;
		}

		private void ckbBinhLuanNhieuLan_CheckedChanged(object sender, EventArgs e)
		{
			plBinhLuanNhieuLan.Enabled = ckbBinhLuanNhieuLan.Checked;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MCommon.Common.ShowForm(new fHuongDanRandom());
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDTuongTacVideo));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			plComment = new System.Windows.Forms.Panel();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			plBinhLuanNhieuLan = new System.Windows.Forms.Panel();
			nudBinhLuanNhieuLanDelayTo = new System.Windows.Forms.NumericUpDown();
			lblmc1 = new System.Windows.Forms.Label();
			nudBinhLuanNhieuLanDelayFrom = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			ckbBinhLuanNhieuLan = new System.Windows.Forms.CheckBox();
			label8 = new System.Windows.Forms.Label();
			txtComment = new System.Windows.Forms.TextBox();
			lblStatus = new System.Windows.Forms.Label();
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
			ckbComment = new System.Windows.Forms.CheckBox();
			ckbInteract = new System.Windows.Forms.CheckBox();
			nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
			nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			txtLinkVideo = new System.Windows.Forms.TextBox();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			plComment.SuspendLayout();
			plBinhLuanNhieuLan.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudBinhLuanNhieuLanDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudBinhLuanNhieuLanDelayFrom).BeginInit();
			plInteract.SuspendLayout();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(359, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Tương tác Video";
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
			panel1.Controls.Add(plComment);
			panel1.Controls.Add(plInteract);
			panel1.Controls.Add(ckbComment);
			panel1.Controls.Add(ckbInteract);
			panel1.Controls.Add(nudSoLuongTo);
			panel1.Controls.Add(nudSoLuongFrom);
			panel1.Controls.Add(txtLinkVideo);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label9);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(362, 503);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(linkLabel1);
			plComment.Controls.Add(plBinhLuanNhieuLan);
			plComment.Controls.Add(ckbBinhLuanNhieuLan);
			plComment.Controls.Add(label8);
			plComment.Controls.Add(txtComment);
			plComment.Controls.Add(lblStatus);
			plComment.Location = new System.Drawing.Point(48, 229);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(278, 213);
			plComment.TabIndex = 8;
			linkLabel1.AutoSize = true;
			linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel1.Location = new System.Drawing.Point(190, 141);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(82, 16);
			linkLabel1.TabIndex = 192;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Random icon";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			plBinhLuanNhieuLan.Controls.Add(nudBinhLuanNhieuLanDelayTo);
			plBinhLuanNhieuLan.Controls.Add(lblmc1);
			plBinhLuanNhieuLan.Controls.Add(nudBinhLuanNhieuLanDelayFrom);
			plBinhLuanNhieuLan.Controls.Add(label5);
			plBinhLuanNhieuLan.Controls.Add(label7);
			plBinhLuanNhieuLan.Controls.Add(label6);
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
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(226, 4);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(31, 16);
			label5.TabIndex = 20;
			label5.Text = "giây";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(75, 4);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(20, 16);
			label7.TabIndex = 20;
			label7.Text = "từ";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(143, 4);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(29, 16);
			label6.TabIndex = 20;
			label6.Text = "đến";
			ckbBinhLuanNhieuLan.AutoSize = true;
			ckbBinhLuanNhieuLan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbBinhLuanNhieuLan.Location = new System.Drawing.Point(7, 163);
			ckbBinhLuanNhieuLan.Name = "ckbBinhLuanNhieuLan";
			ckbBinhLuanNhieuLan.Size = new System.Drawing.Size(135, 20);
			ckbBinhLuanNhieuLan.TabIndex = 133;
			ckbBinhLuanNhieuLan.Text = "Bình luận nhiều lần";
			ckbBinhLuanNhieuLan.UseVisualStyleBackColor = true;
			ckbBinhLuanNhieuLan.CheckedChanged += new System.EventHandler(ckbBinhLuanNhieuLan_CheckedChanged);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(3, 141);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(144, 16);
			label8.TabIndex = 2;
			label8.Text = "(Spin nội dung {a|b|c})";
			txtComment.Location = new System.Drawing.Point(7, 27);
			txtComment.Multiline = true;
			txtComment.Name = "txtComment";
			txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtComment.Size = new System.Drawing.Size(261, 111);
			txtComment.TabIndex = 1;
			txtComment.WordWrap = false;
			txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged);
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 5);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(140, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Nội dung bình luận (0):";
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
			plInteract.Location = new System.Drawing.Point(48, 160);
			plInteract.Name = "plInteract";
			plInteract.Size = new System.Drawing.Size(278, 40);
			plInteract.TabIndex = 6;
			label25.Cursor = System.Windows.Forms.Cursors.Hand;
			label25.Location = new System.Drawing.Point(4, 1);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(30, 16);
			label25.TabIndex = 0;
			label25.Text = "Like";
			label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label25.Click += new System.EventHandler(label25_Click);
			label26.Cursor = System.Windows.Forms.Cursors.Hand;
			label26.Location = new System.Drawing.Point(46, 1);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(39, 16);
			label26.TabIndex = 2;
			label26.Text = "Tym";
			label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label26.Click += new System.EventHandler(label26_Click);
			label28.Cursor = System.Windows.Forms.Cursors.Hand;
			label28.Location = new System.Drawing.Point(93, 1);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(37, 16);
			label28.TabIndex = 6;
			label28.Text = "Haha";
			label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label28.Click += new System.EventHandler(label28_Click);
			label29.Cursor = System.Windows.Forms.Cursors.Hand;
			label29.Location = new System.Drawing.Point(140, 1);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(37, 16);
			label29.TabIndex = 8;
			label29.Text = "Wow";
			label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label29.Click += new System.EventHandler(label29_Click);
			label30.Cursor = System.Windows.Forms.Cursors.Hand;
			label30.Location = new System.Drawing.Point(187, 1);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(36, 16);
			label30.TabIndex = 10;
			label30.Text = "Buồn";
			label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label30.Click += new System.EventHandler(label30_Click);
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
			label32.Click += new System.EventHandler(label32_Click);
			ckbComment.AutoSize = true;
			ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbComment.Location = new System.Drawing.Point(30, 204);
			ckbComment.Name = "ckbComment";
			ckbComment.Size = new System.Drawing.Size(131, 20);
			ckbComment.TabIndex = 7;
			ckbComment.Text = "Tư\u0323 đô\u0323ng bi\u0300nh luâ\u0323n";
			ckbComment.UseVisualStyleBackColor = true;
			ckbComment.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
			ckbInteract.AutoSize = true;
			ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbInteract.Location = new System.Drawing.Point(30, 136);
			ckbInteract.Name = "ckbInteract";
			ckbInteract.Size = new System.Drawing.Size(113, 20);
			ckbInteract.TabIndex = 5;
			ckbInteract.Text = "Ba\u0300y to\u0309 ca\u0309m xu\u0301c";
			ckbInteract.UseVisualStyleBackColor = true;
			ckbInteract.CheckedChanged += new System.EventHandler(ckbInteract_CheckedChanged);
			nudSoLuongTo.Location = new System.Drawing.Point(229, 107);
			nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongTo.Name = "nudSoLuongTo";
			nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongTo.TabIndex = 2;
			nudSoLuongFrom.Location = new System.Drawing.Point(132, 107);
			nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongFrom.Name = "nudSoLuongFrom";
			nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongFrom.TabIndex = 1;
			txtLinkVideo.Location = new System.Drawing.Point(132, 78);
			txtLinkVideo.Name = "txtLinkVideo";
			txtLinkVideo.Size = new System.Drawing.Size(194, 23);
			txtLinkVideo.TabIndex = 0;
			txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
			txtTenHanhDong.TabIndex = 0;
			label3.Location = new System.Drawing.Point(194, 109);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 16);
			label3.TabIndex = 37;
			label3.Text = "đê\u0301n";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(290, 109);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(31, 16);
			label4.TabIndex = 35;
			label4.Text = "giây";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(27, 81);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(69, 16);
			label9.TabIndex = 31;
			label9.Text = "Link video:";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(27, 109);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(94, 16);
			label2.TabIndex = 32;
			label2.Text = "Thời gian xem:";
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
			btnCancel.Location = new System.Drawing.Point(189, 459);
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
			btnAdd.Location = new System.Drawing.Point(82, 459);
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
			base.ClientSize = new System.Drawing.Size(362, 503);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDTuongTacVideo";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plComment.ResumeLayout(false);
			plComment.PerformLayout();
			plBinhLuanNhieuLan.ResumeLayout(false);
			plBinhLuanNhieuLan.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudBinhLuanNhieuLanDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudBinhLuanNhieuLanDelayFrom).EndInit();
			plInteract.ResumeLayout(false);
			plInteract.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
