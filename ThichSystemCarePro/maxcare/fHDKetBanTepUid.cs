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
	public class fHDKetBanTepUid : Form
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

		private Label label8;

		private Label lblStatus;

		private NumericUpDown nudDelayTo;

		private NumericUpDown nudDelayFrom;

		private Label label7;

		private Label label6;

		private Label label5;

		private RichTextBox txtUid;

		private CheckBox ckbTuDongXoaUid;

		private ToolTip toolTip1;

		private Panel plTuongTac;

		private CheckBox ckbTuongTac;

		private Panel plTuongTacComment;

		private RichTextBox txtComment;

		private Label label9;

		private Label lblStatusComment;

		private CheckBox ckbTuongTacComment;

		private Panel plCountComment;

		private NumericUpDown nudCountCommentFrom;

		private Label label13;

		private Label label14;

		private NumericUpDown nudCountCommentTo;

		private Label label21;

		private NumericUpDown nudTimeFrom;

		private CheckBox ckbTuongTacLike;

		private NumericUpDown nudTimeTo;

		private Label label18;

		private Label label16;

		private Panel plCountLike;

		private NumericUpDown nudCountLikeFrom;

		private Label label10;

		private Label label11;

		private NumericUpDown nudCountLikeTo;

		public fHDKetBanTepUid(string id_KichBan, int type = 0, string id_HanhDong = "")
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
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDKetBanTepUid");
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
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(ckbTuDongXoaUid);
			Language.GetValue(ckbTuongTac);
			Language.GetValue(ckbTuongTacComment);
			Language.GetValue(lblStatusComment);
			Language.GetValue(label9);
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
				ckbTuDongXoaUid.Checked = setting.GetValueBool("ckbKetBanTrungNhau");
				txtUid.Text = setting.GetValue("txtUid");
				ckbTuongTac.Checked = setting.GetValueBool("ckbTuongTac");
				nudTimeFrom.Value = setting.GetValueInt("nudTimeFrom", 5);
				nudTimeTo.Value = setting.GetValueInt("nudTimeTo", 10);
				nudCountLikeFrom.Value = setting.GetValueInt("nudCountLikeFrom", 1);
				nudCountLikeTo.Value = setting.GetValueInt("nudCountLikeTo", 3);
				nudCountCommentFrom.Value = setting.GetValueInt("nudCountCommentFrom", 1);
				nudCountCommentTo.Value = setting.GetValueInt("nudCountCommentTo", 3);
				ckbTuongTacLike.Checked = setting.GetValueBool("ckbTuongTacLike");
				ckbTuongTacComment.Checked = setting.GetValueBool("ckbTuongTacComment");
				ckbTuDongXoaUid.Checked = setting.GetValueBool("ckbTuDongXoaUid");
				txtComment.Text = setting.GetValue("txtComment");
			}
			catch
			{
			}
			CheckedChangeFull();
		}

		private void CheckedChangeFull()
		{
			ckbTuongTac_CheckedChanged(null, null);
			ckbTuongTacLike_CheckedChanged(null, null);
			ckbTuongTacComment_CheckedChanged(null, null);
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
			List<string> lst = txtUid.Lines.ToList();
			lst = MCommon.Common.RemoveEmptyItems(lst);
			if (lst.Count == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p danh sách uid cần kết bạn!"), 3);
				return;
			}
			if (ckbTuongTac.Checked && ckbTuongTacComment.Checked)
			{
				lst = txtComment.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				if (lst.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p nội dung bình luận!"), 3);
					return;
				}
			}
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("nudSoLuongFrom", nudSoLuongFrom.Value);
			jSON_Settings.Update("nudSoLuongTo", nudSoLuongTo.Value);
			jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
			jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
			jSON_Settings.Update("ckbKetBanTrungNhau", ckbTuDongXoaUid.Checked);
			jSON_Settings.Update("txtUid", txtUid.Text.Trim());
			jSON_Settings.Update("ckbTuongTac", ckbTuongTac.Checked);
			jSON_Settings.Update("nudTimeFrom", nudTimeFrom.Value);
			jSON_Settings.Update("nudTimeTo", nudTimeTo.Value);
			jSON_Settings.Update("nudCountLikeFrom", nudCountLikeFrom.Value);
			jSON_Settings.Update("nudCountLikeTo", nudCountLikeTo.Value);
			jSON_Settings.Update("nudCountCommentFrom", nudCountCommentFrom.Value);
			jSON_Settings.Update("nudCountCommentTo", nudCountCommentTo.Value);
			jSON_Settings.Update("ckbTuongTacLike", ckbTuongTacLike.Checked);
			jSON_Settings.Update("ckbTuongTacComment", ckbTuongTacComment.Checked);
			jSON_Settings.Update("txtComment", txtComment.Text.Trim());
			jSON_Settings.Update("ckbTuDongXoaUid", ckbTuDongXoaUid.Checked);
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

		private void txtComment_Click(object sender, EventArgs e)
		{
		}

		private void txtComment_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtUid.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblStatus.Text = string.Format(Language.GetValue("Danh sa\u0301ch Uid cần kết bạn ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void txtComment_TextChanged_1(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtComment.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblStatusComment.Text = string.Format(Language.GetValue("Nội dung bình luận ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void ckbTuongTac_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTac.Enabled = ckbTuongTac.Checked;
		}

		private void ckbTuongTacComment_CheckedChanged(object sender, EventArgs e)
		{
			plCountComment.Enabled = ckbTuongTacComment.Checked;
			plTuongTacComment.Enabled = ckbTuongTacComment.Checked;
		}

		private void ckbTuongTacLike_CheckedChanged(object sender, EventArgs e)
		{
			plCountLike.Enabled = ckbTuongTacLike.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDKetBanTepUid));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			plTuongTac = new System.Windows.Forms.Panel();
			plTuongTacComment = new System.Windows.Forms.Panel();
			txtComment = new System.Windows.Forms.RichTextBox();
			label9 = new System.Windows.Forms.Label();
			lblStatusComment = new System.Windows.Forms.Label();
			ckbTuongTacComment = new System.Windows.Forms.CheckBox();
			plCountComment = new System.Windows.Forms.Panel();
			nudCountCommentFrom = new System.Windows.Forms.NumericUpDown();
			label13 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			nudCountCommentTo = new System.Windows.Forms.NumericUpDown();
			label21 = new System.Windows.Forms.Label();
			nudTimeFrom = new System.Windows.Forms.NumericUpDown();
			ckbTuongTacLike = new System.Windows.Forms.CheckBox();
			nudTimeTo = new System.Windows.Forms.NumericUpDown();
			label18 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			plCountLike = new System.Windows.Forms.Panel();
			nudCountLikeFrom = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			nudCountLikeTo = new System.Windows.Forms.NumericUpDown();
			ckbTuongTac = new System.Windows.Forms.CheckBox();
			txtUid = new System.Windows.Forms.RichTextBox();
			ckbTuDongXoaUid = new System.Windows.Forms.CheckBox();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
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
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			plTuongTac.SuspendLayout();
			plTuongTacComment.SuspendLayout();
			plCountComment.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountCommentFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountCommentTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTimeFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTimeTo).BeginInit();
			plCountLike.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountLikeFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountLikeTo).BeginInit();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(687, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Kết bạn theo tệp UID";
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
			panel1.Controls.Add(plTuongTac);
			panel1.Controls.Add(ckbTuongTac);
			panel1.Controls.Add(txtUid);
			panel1.Controls.Add(ckbTuDongXoaUid);
			panel1.Controls.Add(nudDelayTo);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(lblStatus);
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
			panel1.Size = new System.Drawing.Size(690, 406);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			plTuongTac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTac.Controls.Add(plTuongTacComment);
			plTuongTac.Controls.Add(ckbTuongTacComment);
			plTuongTac.Controls.Add(plCountComment);
			plTuongTac.Controls.Add(label21);
			plTuongTac.Controls.Add(nudTimeFrom);
			plTuongTac.Controls.Add(ckbTuongTacLike);
			plTuongTac.Controls.Add(nudTimeTo);
			plTuongTac.Controls.Add(label18);
			plTuongTac.Controls.Add(label16);
			plTuongTac.Controls.Add(plCountLike);
			plTuongTac.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plTuongTac.Location = new System.Drawing.Point(360, 74);
			plTuongTac.Name = "plTuongTac";
			plTuongTac.Size = new System.Drawing.Size(310, 272);
			plTuongTac.TabIndex = 116;
			plTuongTacComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTacComment.Controls.Add(txtComment);
			plTuongTacComment.Controls.Add(label9);
			plTuongTacComment.Controls.Add(lblStatusComment);
			plTuongTacComment.Location = new System.Drawing.Point(24, 94);
			plTuongTacComment.Name = "plTuongTacComment";
			plTuongTacComment.Size = new System.Drawing.Size(278, 169);
			plTuongTacComment.TabIndex = 135;
			txtComment.Location = new System.Drawing.Point(6, 24);
			txtComment.Name = "txtComment";
			txtComment.Size = new System.Drawing.Size(266, 120);
			txtComment.TabIndex = 107;
			txtComment.Text = "";
			txtComment.WordWrap = false;
			txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged_1);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(2, 147);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(266, 16);
			label9.TabIndex = 0;
			label9.Text = "(Mỗi nội dung 1 dòng, spin nội dung {a|b|c})";
			lblStatusComment.AutoSize = true;
			lblStatusComment.Location = new System.Drawing.Point(3, 5);
			lblStatusComment.Name = "lblStatusComment";
			lblStatusComment.Size = new System.Drawing.Size(140, 16);
			lblStatusComment.TabIndex = 0;
			lblStatusComment.Text = "Nội dung bình luận (0):";
			ckbTuongTacComment.AutoSize = true;
			ckbTuongTacComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacComment.Location = new System.Drawing.Point(6, 65);
			ckbTuongTacComment.Name = "ckbTuongTacComment";
			ckbTuongTacComment.Size = new System.Drawing.Size(82, 20);
			ckbTuongTacComment.TabIndex = 133;
			ckbTuongTacComment.Text = "Comment";
			ckbTuongTacComment.UseVisualStyleBackColor = true;
			ckbTuongTacComment.CheckedChanged += new System.EventHandler(ckbTuongTacComment_CheckedChanged);
			plCountComment.Controls.Add(nudCountCommentFrom);
			plCountComment.Controls.Add(label13);
			plCountComment.Controls.Add(label14);
			plCountComment.Controls.Add(nudCountCommentTo);
			plCountComment.Location = new System.Drawing.Point(113, 64);
			plCountComment.Name = "plCountComment";
			plCountComment.Size = new System.Drawing.Size(189, 25);
			plCountComment.TabIndex = 134;
			nudCountCommentFrom.Location = new System.Drawing.Point(1, 1);
			nudCountCommentFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountCommentFrom.Name = "nudCountCommentFrom";
			nudCountCommentFrom.Size = new System.Drawing.Size(56, 23);
			nudCountCommentFrom.TabIndex = 1;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(157, 3);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(30, 16);
			label13.TabIndex = 35;
			label13.Text = "lươ\u0323t";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(63, 3);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(29, 16);
			label14.TabIndex = 37;
			label14.Text = "đê\u0301n";
			nudCountCommentTo.Location = new System.Drawing.Point(98, 1);
			nudCountCommentTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountCommentTo.Name = "nudCountCommentTo";
			nudCountCommentTo.Size = new System.Drawing.Size(56, 23);
			nudCountCommentTo.TabIndex = 2;
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(3, 7);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(92, 16);
			label21.TabIndex = 129;
			label21.Text = "Thơ\u0300i gian lươ\u0301t:";
			nudTimeFrom.Location = new System.Drawing.Point(114, 5);
			nudTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeFrom.Name = "nudTimeFrom";
			nudTimeFrom.Size = new System.Drawing.Size(56, 23);
			nudTimeFrom.TabIndex = 127;
			ckbTuongTacLike.AutoSize = true;
			ckbTuongTacLike.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacLike.Location = new System.Drawing.Point(6, 35);
			ckbTuongTacLike.Name = "ckbTuongTacLike";
			ckbTuongTacLike.Size = new System.Drawing.Size(49, 20);
			ckbTuongTacLike.TabIndex = 126;
			ckbTuongTacLike.Text = "Like";
			ckbTuongTacLike.UseVisualStyleBackColor = true;
			ckbTuongTacLike.CheckedChanged += new System.EventHandler(ckbTuongTacLike_CheckedChanged);
			nudTimeTo.Location = new System.Drawing.Point(211, 5);
			nudTimeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeTo.Name = "nudTimeTo";
			nudTimeTo.Size = new System.Drawing.Size(56, 23);
			nudTimeTo.TabIndex = 128;
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(272, 7);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(31, 16);
			label18.TabIndex = 130;
			label18.Text = "giây";
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(176, 7);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(29, 16);
			label16.TabIndex = 131;
			label16.Text = "đê\u0301n";
			plCountLike.Controls.Add(nudCountLikeFrom);
			plCountLike.Controls.Add(label10);
			plCountLike.Controls.Add(label11);
			plCountLike.Controls.Add(nudCountLikeTo);
			plCountLike.Location = new System.Drawing.Point(113, 33);
			plCountLike.Name = "plCountLike";
			plCountLike.Size = new System.Drawing.Size(189, 25);
			plCountLike.TabIndex = 132;
			nudCountLikeFrom.Location = new System.Drawing.Point(1, 1);
			nudCountLikeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountLikeFrom.Name = "nudCountLikeFrom";
			nudCountLikeFrom.Size = new System.Drawing.Size(56, 23);
			nudCountLikeFrom.TabIndex = 1;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(157, 3);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(30, 16);
			label10.TabIndex = 35;
			label10.Text = "lươ\u0323t";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(63, 3);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(29, 16);
			label11.TabIndex = 37;
			label11.Text = "đê\u0301n";
			nudCountLikeTo.Location = new System.Drawing.Point(98, 1);
			nudCountLikeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountLikeTo.Name = "nudCountLikeTo";
			nudCountLikeTo.Size = new System.Drawing.Size(56, 23);
			nudCountLikeTo.TabIndex = 2;
			ckbTuongTac.AutoSize = true;
			ckbTuongTac.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTac.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTac.Location = new System.Drawing.Point(342, 51);
			ckbTuongTac.Name = "ckbTuongTac";
			ckbTuongTac.Size = new System.Drawing.Size(185, 20);
			ckbTuongTac.TabIndex = 115;
			ckbTuongTac.Text = "Tương tác trước khi kết bạn";
			ckbTuongTac.UseVisualStyleBackColor = true;
			ckbTuongTac.CheckedChanged += new System.EventHandler(ckbTuongTac_CheckedChanged);
			txtUid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtUid.Location = new System.Drawing.Point(24, 163);
			txtUid.Name = "txtUid";
			txtUid.Size = new System.Drawing.Size(295, 141);
			txtUid.TabIndex = 114;
			txtUid.Text = "";
			txtUid.WordWrap = false;
			txtUid.TextChanged += new System.EventHandler(txtComment_TextChanged);
			ckbTuDongXoaUid.AutoSize = true;
			ckbTuDongXoaUid.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuDongXoaUid.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuDongXoaUid.Location = new System.Drawing.Point(23, 326);
			ckbTuDongXoaUid.Name = "ckbTuDongXoaUid";
			ckbTuDongXoaUid.Size = new System.Drawing.Size(249, 20);
			ckbTuDongXoaUid.TabIndex = 113;
			ckbTuDongXoaUid.Text = "Tư\u0323 đô\u0323ng xo\u0301a Uid đa\u0303 gư\u0309i lơ\u0300i mơ\u0300i kê\u0301t ba\u0323n";
			ckbTuDongXoaUid.UseVisualStyleBackColor = true;
			nudDelayTo.Location = new System.Drawing.Point(222, 111);
			nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 4;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(220, 307);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(103, 16);
			label8.TabIndex = 0;
			label8.Text = "(Mỗi Uid 1 dòng)";
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(20, 141);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(185, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Danh sa\u0301ch Uid cần kết bạn (0):";
			nudDelayFrom.Location = new System.Drawing.Point(125, 111);
			nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 3;
			label7.Location = new System.Drawing.Point(187, 113);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 46;
			label7.Text = "đê\u0301n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(280, 113);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(31, 16);
			label6.TabIndex = 45;
			label6.Text = "giây";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(20, 113);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(90, 16);
			label5.TabIndex = 44;
			label5.Text = "Thơ\u0300i gian chơ\u0300:";
			nudSoLuongTo.Location = new System.Drawing.Point(222, 80);
			nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongTo.Name = "nudSoLuongTo";
			nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongTo.TabIndex = 2;
			nudSoLuongFrom.Location = new System.Drawing.Point(125, 80);
			nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongFrom.Name = "nudSoLuongFrom";
			nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongFrom.TabIndex = 1;
			txtTenHanhDong.Location = new System.Drawing.Point(125, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
			txtTenHanhDong.TabIndex = 0;
			label3.Location = new System.Drawing.Point(187, 82);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 16);
			label3.TabIndex = 37;
			label3.Text = "đê\u0301n";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(280, 82);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(29, 16);
			label4.TabIndex = 35;
			label4.Text = "ba\u0323n";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(20, 82);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(89, 16);
			label2.TabIndex = 32;
			label2.Text = "Sô\u0301 lươ\u0323ng ba\u0323n:";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(20, 52);
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
			btnCancel.Location = new System.Drawing.Point(355, 362);
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
			btnAdd.Location = new System.Drawing.Point(248, 362);
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
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 0;
			toolTip1.InitialDelay = 0;
			toolTip1.ReshowDelay = 0;
			toolTip1.ShowAlways = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(690, 406);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDKetBanTepUid";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plTuongTac.ResumeLayout(false);
			plTuongTac.PerformLayout();
			plTuongTacComment.ResumeLayout(false);
			plTuongTacComment.PerformLayout();
			plCountComment.ResumeLayout(false);
			plCountComment.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountCommentFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountCommentTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTimeFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTimeTo).EndInit();
			plCountLike.ResumeLayout(false);
			plCountLike.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountLikeFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountLikeTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
