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
	public class fHDXemWatch_Old : Form
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

		private NumericUpDown nudTimeWatchTo;

		private NumericUpDown nudSoLuongTo;

		private NumericUpDown nudTimeWatchFrom;

		private NumericUpDown nudSoLuongFrom;

		private TextBox txtTenHanhDong;

		private Label label7;

		private Label label3;

		private Label label6;

		private Label label4;

		private Label label5;

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

		private Label label8;

		private Label lblStatus;

		private CheckBox ckbComment;

		private CheckBox ckbInteract;

		private CheckBox ckbShareWall;

		private Panel plCountComment;

		private NumericUpDown nudCountCommentFrom;

		private Label label13;

		private Label label14;

		private NumericUpDown nudCountCommentTo;

		private Panel plCountShareWall;

		private NumericUpDown nudCountShareFrom;

		private Label label11;

		private Label label12;

		private NumericUpDown nudCountShareTo;

		private Panel plCountLike;

		private NumericUpDown nudCountLikeFrom;

		private Label label9;

		private Label label10;

		private NumericUpDown nudCountLikeTo;

		private RichTextBox txtComment;

		public fHDXemWatch_Old(string id_KichBan, int type = 0, string id_HanhDong = "")
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
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDXemWatch");
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
			Language.GetValue(label10);
			Language.GetValue(label9);
			Language.GetValue(label12);
			Language.GetValue(label11);
			Language.GetValue(label14);
			Language.GetValue(label13);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudSoLuongFrom.Value = setting.GetValueInt("nudSoLuongFrom");
				nudSoLuongTo.Value = setting.GetValueInt("nudSoLuongTo");
				nudTimeWatchFrom.Value = setting.GetValueInt("nudTimeWatchFrom");
				nudTimeWatchTo.Value = setting.GetValueInt("nudTimeWatchTo");
				ckbInteract.Checked = setting.GetValueBool("ckbInteract");
				ckbComment.Checked = setting.GetValueBool("ckbComment");
				ckbShareWall.Checked = setting.GetValueBool("ckbShareWall");
				txtComment.Text = setting.GetValue("txtComment");
				nudCountLikeFrom.Value = setting.GetValueInt("nudCountLikeFrom", 1);
				nudCountLikeTo.Value = setting.GetValueInt("nudCountLikeTo", 3);
				nudCountShareFrom.Value = setting.GetValueInt("nudCountShareFrom", 1);
				nudCountShareTo.Value = setting.GetValueInt("nudCountShareTo", 3);
				nudCountCommentFrom.Value = setting.GetValueInt("nudCountCommentFrom", 1);
				nudCountCommentTo.Value = setting.GetValueInt("nudCountCommentTo", 3);
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
			jSON_Settings.Update("nudSoLuongFrom", nudSoLuongFrom.Value);
			jSON_Settings.Update("nudSoLuongTo", nudSoLuongTo.Value);
			jSON_Settings.Update("nudTimeWatchFrom", nudTimeWatchFrom.Value);
			jSON_Settings.Update("nudTimeWatchTo", nudTimeWatchTo.Value);
			jSON_Settings.Update("ckbInteract", ckbInteract.Checked);
			jSON_Settings.Update("ckbShareWall", ckbShareWall.Checked);
			jSON_Settings.Update("ckbComment", ckbComment.Checked);
			jSON_Settings.Update("txtComment", txtComment.Text.Trim());
			jSON_Settings.Update("nudCountLikeFrom", nudCountLikeFrom.Value);
			jSON_Settings.Update("nudCountLikeTo", nudCountLikeTo.Value);
			jSON_Settings.Update("nudCountShareFrom", nudCountShareFrom.Value);
			jSON_Settings.Update("nudCountShareTo", nudCountShareTo.Value);
			jSON_Settings.Update("nudCountCommentFrom", nudCountCommentFrom.Value);
			jSON_Settings.Update("nudCountCommentTo", nudCountCommentTo.Value);
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
			ckbInteract_CheckedChanged_1(null, null);
			ckbComment_CheckedChanged(null, null);
			ckbShareWall_CheckedChanged(null, null);
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
			plComment.Enabled = ckbComment.Checked;
			plCountComment.Enabled = ckbComment.Checked;
		}

		private void ckbInteract_CheckedChanged_1(object sender, EventArgs e)
		{
			plCountLike.Enabled = ckbInteract.Checked;
		}

		private void ckbShareWall_CheckedChanged(object sender, EventArgs e)
		{
			plCountShareWall.Enabled = ckbShareWall.Checked;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Có thể dùng [u] để thay thế tên của người đăng bài!"));
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDXemWatch));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			plCountComment = new System.Windows.Forms.Panel();
			nudCountCommentFrom = new System.Windows.Forms.NumericUpDown();
			label13 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			nudCountCommentTo = new System.Windows.Forms.NumericUpDown();
			plCountShareWall = new System.Windows.Forms.Panel();
			nudCountShareFrom = new System.Windows.Forms.NumericUpDown();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			nudCountShareTo = new System.Windows.Forms.NumericUpDown();
			plCountLike = new System.Windows.Forms.Panel();
			nudCountLikeFrom = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			nudCountLikeTo = new System.Windows.Forms.NumericUpDown();
			plComment = new System.Windows.Forms.Panel();
			txtComment = new System.Windows.Forms.RichTextBox();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			ckbComment = new System.Windows.Forms.CheckBox();
			ckbShareWall = new System.Windows.Forms.CheckBox();
			ckbInteract = new System.Windows.Forms.CheckBox();
			nudTimeWatchTo = new System.Windows.Forms.NumericUpDown();
			nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
			nudTimeWatchFrom = new System.Windows.Forms.NumericUpDown();
			nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			plCountComment.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountCommentFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountCommentTo).BeginInit();
			plCountShareWall.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountShareFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountShareTo).BeginInit();
			plCountLike.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountLikeFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountLikeTo).BeginInit();
			plComment.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudTimeWatchTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTimeWatchFrom).BeginInit();
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
			bunifuCustomLabel1.Text = "Cấu hình Xem Watch";
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
			panel1.Controls.Add(plCountComment);
			panel1.Controls.Add(plCountShareWall);
			panel1.Controls.Add(plCountLike);
			panel1.Controls.Add(plComment);
			panel1.Controls.Add(ckbComment);
			panel1.Controls.Add(ckbShareWall);
			panel1.Controls.Add(ckbInteract);
			panel1.Controls.Add(nudTimeWatchTo);
			panel1.Controls.Add(nudSoLuongTo);
			panel1.Controls.Add(nudTimeWatchFrom);
			panel1.Controls.Add(nudSoLuongFrom);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label4);
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
			panel1.Size = new System.Drawing.Size(362, 436);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			plCountComment.Controls.Add(nudCountCommentFrom);
			plCountComment.Controls.Add(label13);
			plCountComment.Controls.Add(label14);
			plCountComment.Controls.Add(nudCountCommentTo);
			plCountComment.Location = new System.Drawing.Point(132, 186);
			plCountComment.Name = "plCountComment";
			plCountComment.Size = new System.Drawing.Size(200, 25);
			plCountComment.TabIndex = 44;
			nudCountCommentFrom.Location = new System.Drawing.Point(1, 1);
			nudCountCommentFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountCommentFrom.Name = "nudCountCommentFrom";
			nudCountCommentFrom.Size = new System.Drawing.Size(56, 23);
			nudCountCommentFrom.TabIndex = 1;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(159, 3);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(25, 16);
			label13.TabIndex = 35;
			label13.Text = "lần";
			label14.Location = new System.Drawing.Point(63, 3);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(29, 16);
			label14.TabIndex = 37;
			label14.Text = "đê\u0301n";
			label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudCountCommentTo.Location = new System.Drawing.Point(98, 1);
			nudCountCommentTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountCommentTo.Name = "nudCountCommentTo";
			nudCountCommentTo.Size = new System.Drawing.Size(56, 23);
			nudCountCommentTo.TabIndex = 2;
			plCountShareWall.Controls.Add(nudCountShareFrom);
			plCountShareWall.Controls.Add(label11);
			plCountShareWall.Controls.Add(label12);
			plCountShareWall.Controls.Add(nudCountShareTo);
			plCountShareWall.Location = new System.Drawing.Point(132, 158);
			plCountShareWall.Name = "plCountShareWall";
			plCountShareWall.Size = new System.Drawing.Size(200, 25);
			plCountShareWall.TabIndex = 43;
			nudCountShareFrom.Location = new System.Drawing.Point(1, 1);
			nudCountShareFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountShareFrom.Name = "nudCountShareFrom";
			nudCountShareFrom.Size = new System.Drawing.Size(56, 23);
			nudCountShareFrom.TabIndex = 1;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(159, 3);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(25, 16);
			label11.TabIndex = 35;
			label11.Text = "lần";
			label12.Location = new System.Drawing.Point(63, 3);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(29, 16);
			label12.TabIndex = 37;
			label12.Text = "đê\u0301n";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudCountShareTo.Location = new System.Drawing.Point(98, 1);
			nudCountShareTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountShareTo.Name = "nudCountShareTo";
			nudCountShareTo.Size = new System.Drawing.Size(56, 23);
			nudCountShareTo.TabIndex = 2;
			plCountLike.Controls.Add(nudCountLikeFrom);
			plCountLike.Controls.Add(label9);
			plCountLike.Controls.Add(label10);
			plCountLike.Controls.Add(nudCountLikeTo);
			plCountLike.Location = new System.Drawing.Point(132, 130);
			plCountLike.Name = "plCountLike";
			plCountLike.Size = new System.Drawing.Size(200, 25);
			plCountLike.TabIndex = 42;
			nudCountLikeFrom.Location = new System.Drawing.Point(1, 1);
			nudCountLikeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountLikeFrom.Name = "nudCountLikeFrom";
			nudCountLikeFrom.Size = new System.Drawing.Size(56, 23);
			nudCountLikeFrom.TabIndex = 1;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(159, 3);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 16);
			label9.TabIndex = 35;
			label9.Text = "lần";
			label10.Location = new System.Drawing.Point(63, 3);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(29, 16);
			label10.TabIndex = 37;
			label10.Text = "đê\u0301n";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudCountLikeTo.Location = new System.Drawing.Point(98, 1);
			nudCountLikeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountLikeTo.Name = "nudCountLikeTo";
			nudCountLikeTo.Size = new System.Drawing.Size(56, 23);
			nudCountLikeTo.TabIndex = 2;
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(txtComment);
			plComment.Controls.Add(label8);
			plComment.Controls.Add(lblStatus);
			plComment.Location = new System.Drawing.Point(48, 214);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(278, 164);
			plComment.TabIndex = 8;
			txtComment.Location = new System.Drawing.Point(6, 24);
			txtComment.Name = "txtComment";
			txtComment.Size = new System.Drawing.Size(264, 114);
			txtComment.TabIndex = 45;
			txtComment.Text = "";
			txtComment.WordWrap = false;
			txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 141);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(266, 16);
			label8.TabIndex = 0;
			label8.Text = "(Mỗi nội dung 1 dòng, spin nội dung {a|b|c})";
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 5);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(140, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Nội dung bình luận (0):";
			ckbComment.AutoSize = true;
			ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbComment.Location = new System.Drawing.Point(30, 188);
			ckbComment.Name = "ckbComment";
			ckbComment.Size = new System.Drawing.Size(82, 20);
			ckbComment.TabIndex = 7;
			ckbComment.Text = "Comment";
			ckbComment.UseVisualStyleBackColor = true;
			ckbComment.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
			ckbShareWall.AutoSize = true;
			ckbShareWall.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbShareWall.Location = new System.Drawing.Point(30, 160);
			ckbShareWall.Name = "ckbShareWall";
			ckbShareWall.Size = new System.Drawing.Size(90, 20);
			ckbShareWall.TabIndex = 6;
			ckbShareWall.Text = "Share Wall";
			ckbShareWall.UseVisualStyleBackColor = true;
			ckbShareWall.CheckedChanged += new System.EventHandler(ckbShareWall_CheckedChanged);
			ckbInteract.AutoSize = true;
			ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbInteract.Location = new System.Drawing.Point(30, 132);
			ckbInteract.Name = "ckbInteract";
			ckbInteract.Size = new System.Drawing.Size(49, 20);
			ckbInteract.TabIndex = 5;
			ckbInteract.Text = "Like";
			ckbInteract.UseVisualStyleBackColor = true;
			ckbInteract.CheckedChanged += new System.EventHandler(ckbInteract_CheckedChanged_1);
			nudTimeWatchTo.Location = new System.Drawing.Point(229, 103);
			nudTimeWatchTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeWatchTo.Name = "nudTimeWatchTo";
			nudTimeWatchTo.Size = new System.Drawing.Size(56, 23);
			nudTimeWatchTo.TabIndex = 4;
			nudSoLuongTo.Location = new System.Drawing.Point(229, 76);
			nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongTo.Name = "nudSoLuongTo";
			nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongTo.TabIndex = 2;
			nudTimeWatchFrom.Location = new System.Drawing.Point(132, 103);
			nudTimeWatchFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeWatchFrom.Name = "nudTimeWatchFrom";
			nudTimeWatchFrom.Size = new System.Drawing.Size(56, 23);
			nudTimeWatchFrom.TabIndex = 3;
			nudSoLuongFrom.Location = new System.Drawing.Point(132, 76);
			nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongFrom.Name = "nudSoLuongFrom";
			nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongFrom.TabIndex = 1;
			txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
			txtTenHanhDong.TabIndex = 0;
			label7.Location = new System.Drawing.Point(194, 105);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 38;
			label7.Text = "đê\u0301n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label3.Location = new System.Drawing.Point(194, 78);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 16);
			label3.TabIndex = 37;
			label3.Text = "đê\u0301n";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(290, 105);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(31, 16);
			label6.TabIndex = 36;
			label6.Text = "giây";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(290, 78);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(38, 16);
			label4.TabIndex = 35;
			label4.Text = "video";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(27, 105);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(94, 16);
			label5.TabIndex = 34;
			label5.Text = "Thơ\u0300i gian xem:";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(27, 78);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(98, 16);
			label2.TabIndex = 32;
			label2.Text = "Sô\u0301 lươ\u0323ng video:";
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
			btnCancel.Location = new System.Drawing.Point(189, 393);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 10;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(82, 393);
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
			base.ClientSize = new System.Drawing.Size(362, 436);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDXemWatch";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plCountComment.ResumeLayout(false);
			plCountComment.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountCommentFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountCommentTo).EndInit();
			plCountShareWall.ResumeLayout(false);
			plCountShareWall.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountShareFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountShareTo).EndInit();
			plCountLike.ResumeLayout(false);
			plCountLike.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountLikeFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountLikeTo).EndInit();
			plComment.ResumeLayout(false);
			plComment.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudTimeWatchTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTimeWatchFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
