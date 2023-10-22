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
using MetroFramework.Controls;

namespace maxcare
{
	public class fHDBuffLikeComment : Form
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

		private NumericUpDown nudDelayTo;

		private NumericUpDown nudDelayFrom;

		private TextBox txtTenHanhDong;

		private Label label7;

		private Label label6;

		private Label label5;

		private Label label1;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private Button button1;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private CheckBox ckbInteract;

		private CheckBox ckbShareWall;

		private Label label10;

		private Label label2;

		private NumericUpDown nudTimeTo;

		private NumericUpDown nudTimeFrom;

		private Label label9;

		private Label label4;

		private Label label3;

		private Panel plComment;

		private RadioButton rbNganCachKyTu;

		private RadioButton rbNganCachMoiDong;

		private Label label8;

		private RichTextBox txtComment;

		private Label label11;

		private Label lblStatus;

		private Panel plAnh;

		private TextBox txtAnh;

		private RichTextBox txtIdPost;

		private CheckBox ckbSendAnh;

		private CheckBox ckbComment;

		private Label label12;

		private Label label49;

		private NumericUpDown nudSoLuongUidFrom;

		private Label label68;

		private NumericUpDown nudSoLuongUidTo;

		private Label label66;

		private RadioButton rbCommentNgauNhien;

		private RadioButton rbCommentTheoThuTu;

		private Label label13;

		private MetroButton btnDown;

		private MetroButton btnUp;

		private Panel panel2;

		private Panel panel3;

		private Button button3;

		private Button button2;

		private Button button4;

		public fHDBuffLikeComment(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			if (InteractSQL.GetTuongTac("", "HDBuffLikeComment").Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\", \"MoTa\") VALUES ('HDBuffLikeComment', 'Buff Like, Comment');");
			}
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDBuffLikeComment");
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
			Language.GetValue(label49);
			Language.GetValue(label66);
			Language.GetValue(label2);
			Language.GetValue(label10);
			Language.GetValue(label3);
			Language.GetValue(label9);
			Language.GetValue(label4);
			Language.GetValue(ckbInteract);
			Language.GetValue(ckbShareWall);
			Language.GetValue(ckbComment);
			Language.GetValue(lblStatus);
			Language.GetValue(label11);
			Language.GetValue(label8);
			Language.GetValue(rbNganCachMoiDong);
			Language.GetValue(button2);
			Language.GetValue(rbNganCachKyTu);
			Language.GetValue(button3);
			Language.GetValue(ckbSendAnh);
			Language.GetValue(label12);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(label13);
			Language.GetValue(rbCommentTheoThuTu);
			Language.GetValue(rbCommentNgauNhien);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudTimeFrom.Value = setting.GetValueInt("nudTimeFrom", 3);
				nudTimeTo.Value = setting.GetValueInt("nudTimeTo", 5);
				nudDelayFrom.Value = setting.GetValueInt("nudDelayFrom", 3);
				nudDelayTo.Value = setting.GetValueInt("nudDelayTo", 5);
				nudSoLuongUidFrom.Value = setting.GetValueInt("nudSoLuongUidFrom", 1);
				nudSoLuongUidTo.Value = setting.GetValueInt("nudSoLuongUidTo", 3);
				ckbInteract.Checked = setting.GetValueBool("ckbInteract");
				ckbShareWall.Checked = setting.GetValueBool("ckbShareWall");
				ckbComment.Checked = setting.GetValueBool("ckbComment");
				txtComment.Text = setting.GetValue("txtComment");
				txtIdPost.Text = setting.GetValue("txtIdPost");
				ckbSendAnh.Checked = setting.GetValueBool("ckbSendAnh");
				txtAnh.Text = setting.GetValue("txtAnh");
				if (setting.GetValueInt("typeNganCach") == 1)
				{
					rbNganCachKyTu.Checked = true;
				}
				else
				{
					rbNganCachMoiDong.Checked = true;
				}
				if (setting.GetValueInt("typeComment") == 1)
				{
					rbCommentNgauNhien.Checked = true;
				}
				else
				{
					rbCommentTheoThuTu.Checked = true;
				}
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
			List<string> lst = txtIdPost.Lines.ToList();
			lst = MCommon.Common.RemoveEmptyItems(lst);
			if (lst.Count == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p danh sa\u0301ch Id ba\u0300i viê\u0301t câ\u0300n buff like, comment!"), 3);
				return;
			}
			if (ckbComment.Checked)
			{
				List<string> lst2 = txtComment.Lines.ToList();
				lst2 = MCommon.Common.RemoveEmptyItems(lst2);
				if (lst2.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p nô\u0323i dung bi\u0300nh luâ\u0323n!"), 3);
					return;
				}
			}
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("nudTimeFrom", nudTimeFrom.Value);
			jSON_Settings.Update("nudTimeTo", nudTimeTo.Value);
			jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
			jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
			jSON_Settings.Update("nudSoLuongUidFrom", nudSoLuongUidFrom.Value);
			jSON_Settings.Update("nudSoLuongUidTo", nudSoLuongUidTo.Value);
			jSON_Settings.Update("ckbInteract", ckbInteract.Checked);
			jSON_Settings.Update("ckbShareWall", ckbShareWall.Checked);
			jSON_Settings.Update("ckbComment", ckbComment.Checked);
			jSON_Settings.Update("txtComment", txtComment.Text.Trim());
			jSON_Settings.Update("txtIdPost", txtIdPost.Text.Trim());
			jSON_Settings.Update("ckbSendAnh", ckbSendAnh.Checked);
			jSON_Settings.Update("txtAnh", txtAnh.Text.Trim());
			int num = 0;
			if (rbNganCachKyTu.Checked)
			{
				num = 1;
			}
			jSON_Settings.Update("typeNganCach", num);
			int num2 = 0;
			if (rbCommentNgauNhien.Checked)
			{
				num2 = 1;
			}
			jSON_Settings.Update("typeComment", num2);
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
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
			plComment.Enabled = ckbComment.Checked;
		}

		private void txtIdPost_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtIdPost.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				label2.Text = string.Format(Language.GetValue("Danh sa\u0301ch ID bài viết ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void ckbSendAnh_CheckedChanged(object sender, EventArgs e)
		{
			plAnh.Enabled = ckbSendAnh.Checked;
		}

		private void panel1_Click(object sender, EventArgs e)
		{
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		private void label12_Click(object sender, EventArgs e)
		{
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void label13_Click(object sender, EventArgs e)
		{
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			plComment.Height = 195;
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			plComment.Height = 237;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhập mỗi dòng là 1 nội dung!"));
			txtComment.Focus();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHelpNhapComment());
			txtComment.Focus();
		}

		private void txtComment_TextChanged_1(object sender, EventArgs e)
		{
		}

		private void button4_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDBuffLikeComment));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			button3 = new System.Windows.Forms.Button();
			rbNganCachMoiDong = new System.Windows.Forms.RadioButton();
			button2 = new System.Windows.Forms.Button();
			rbNganCachKyTu = new System.Windows.Forms.RadioButton();
			label49 = new System.Windows.Forms.Label();
			nudSoLuongUidFrom = new System.Windows.Forms.NumericUpDown();
			label68 = new System.Windows.Forms.Label();
			nudSoLuongUidTo = new System.Windows.Forms.NumericUpDown();
			label66 = new System.Windows.Forms.Label();
			plComment = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			rbCommentTheoThuTu = new System.Windows.Forms.RadioButton();
			rbCommentNgauNhien = new System.Windows.Forms.RadioButton();
			btnDown = new MetroFramework.Controls.MetroButton();
			button4 = new System.Windows.Forms.Button();
			btnUp = new MetroFramework.Controls.MetroButton();
			label13 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			txtComment = new System.Windows.Forms.RichTextBox();
			label11 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			plAnh = new System.Windows.Forms.Panel();
			txtAnh = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			txtIdPost = new System.Windows.Forms.RichTextBox();
			ckbSendAnh = new System.Windows.Forms.CheckBox();
			ckbComment = new System.Windows.Forms.CheckBox();
			label10 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			ckbShareWall = new System.Windows.Forms.CheckBox();
			ckbInteract = new System.Windows.Forms.CheckBox();
			nudTimeTo = new System.Windows.Forms.NumericUpDown();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			nudTimeFrom = new System.Windows.Forms.NumericUpDown();
			nudDelayFrom = new System.Windows.Forms.NumericUpDown();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).BeginInit();
			plComment.SuspendLayout();
			panel3.SuspendLayout();
			plAnh.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudTimeTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTimeFrom).BeginInit();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(684, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Buff Like, Comment ba\u0300i viê\u0301t";
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
			pnlHeader.Size = new System.Drawing.Size(684, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(653, 1);
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
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(label49);
			panel1.Controls.Add(nudSoLuongUidFrom);
			panel1.Controls.Add(label68);
			panel1.Controls.Add(nudSoLuongUidTo);
			panel1.Controls.Add(label66);
			panel1.Controls.Add(plComment);
			panel1.Controls.Add(plAnh);
			panel1.Controls.Add(txtIdPost);
			panel1.Controls.Add(ckbSendAnh);
			panel1.Controls.Add(ckbComment);
			panel1.Controls.Add(label10);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(ckbShareWall);
			panel1.Controls.Add(ckbInteract);
			panel1.Controls.Add(nudTimeTo);
			panel1.Controls.Add(nudDelayTo);
			panel1.Controls.Add(nudTimeFrom);
			panel1.Controls.Add(nudDelayFrom);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label9);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(687, 437);
			panel1.TabIndex = 0;
			panel1.Click += new System.EventHandler(panel1_Click);
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(rbNganCachMoiDong);
			panel2.Controls.Add(button2);
			panel2.Controls.Add(rbNganCachKyTu);
			panel2.Location = new System.Drawing.Point(439, 274);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(200, 43);
			panel2.TabIndex = 42;
			button3.Cursor = System.Windows.Forms.Cursors.Help;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Location = new System.Drawing.Point(165, 22);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(21, 21);
			button3.TabIndex = 172;
			button3.Text = "?";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			rbNganCachMoiDong.AutoSize = true;
			rbNganCachMoiDong.Checked = true;
			rbNganCachMoiDong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachMoiDong.Location = new System.Drawing.Point(3, 3);
			rbNganCachMoiDong.Name = "rbNganCachMoiDong";
			rbNganCachMoiDong.Size = new System.Drawing.Size(156, 20);
			rbNganCachMoiDong.TabIndex = 3;
			rbNganCachMoiDong.TabStop = true;
			rbNganCachMoiDong.Text = "Nội dung chỉ có 1 dòng";
			rbNganCachMoiDong.UseVisualStyleBackColor = true;
			button2.Cursor = System.Windows.Forms.Cursors.Help;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(165, 1);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(21, 21);
			button2.TabIndex = 173;
			button2.Text = "?";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			rbNganCachKyTu.AutoSize = true;
			rbNganCachKyTu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachKyTu.Location = new System.Drawing.Point(3, 24);
			rbNganCachKyTu.Name = "rbNganCachKyTu";
			rbNganCachKyTu.Size = new System.Drawing.Size(160, 20);
			rbNganCachKyTu.TabIndex = 3;
			rbNganCachKyTu.Text = "Nội dung có nhiều dòng";
			rbNganCachKyTu.UseVisualStyleBackColor = true;
			label49.AutoSize = true;
			label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label49.Location = new System.Drawing.Point(26, 108);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(108, 16);
			label49.TabIndex = 169;
			label49.Text = "Sô\u0301 lươ\u0323ng ID/Nick:";
			nudSoLuongUidFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongUidFrom.Location = new System.Drawing.Point(134, 106);
			nudSoLuongUidFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongUidFrom.Name = "nudSoLuongUidFrom";
			nudSoLuongUidFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongUidFrom.TabIndex = 167;
			nudSoLuongUidFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label68.AutoSize = true;
			label68.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label68.Location = new System.Drawing.Point(289, 108);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(20, 16);
			label68.TabIndex = 170;
			label68.Text = "ID";
			nudSoLuongUidTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongUidTo.Location = new System.Drawing.Point(231, 106);
			nudSoLuongUidTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongUidTo.Name = "nudSoLuongUidTo";
			nudSoLuongUidTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongUidTo.TabIndex = 168;
			nudSoLuongUidTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label66.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label66.Location = new System.Drawing.Point(196, 108);
			label66.Name = "label66";
			label66.Size = new System.Drawing.Size(29, 16);
			label66.TabIndex = 171;
			label66.Text = "đê\u0301n";
			label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(panel3);
			plComment.Controls.Add(btnDown);
			plComment.Controls.Add(button4);
			plComment.Controls.Add(btnUp);
			plComment.Controls.Add(label13);
			plComment.Controls.Add(label8);
			plComment.Controls.Add(txtComment);
			plComment.Controls.Add(label11);
			plComment.Controls.Add(lblStatus);
			plComment.Location = new System.Drawing.Point(371, 126);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(281, 195);
			plComment.TabIndex = 164;
			panel3.Controls.Add(rbCommentTheoThuTu);
			panel3.Controls.Add(rbCommentNgauNhien);
			panel3.Location = new System.Drawing.Point(67, 191);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(200, 43);
			panel3.TabIndex = 43;
			rbCommentTheoThuTu.AutoSize = true;
			rbCommentTheoThuTu.Checked = true;
			rbCommentTheoThuTu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbCommentTheoThuTu.Location = new System.Drawing.Point(3, 2);
			rbCommentTheoThuTu.Name = "rbCommentTheoThuTu";
			rbCommentTheoThuTu.Size = new System.Drawing.Size(202, 20);
			rbCommentTheoThuTu.TabIndex = 3;
			rbCommentTheoThuTu.TabStop = true;
			rbCommentTheoThuTu.Text = "Comment theo thứ tự nội dung";
			rbCommentTheoThuTu.UseVisualStyleBackColor = true;
			rbCommentTheoThuTu.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
			rbCommentNgauNhien.AutoSize = true;
			rbCommentNgauNhien.Cursor = System.Windows.Forms.Cursors.Hand;
			rbCommentNgauNhien.Location = new System.Drawing.Point(3, 23);
			rbCommentNgauNhien.Name = "rbCommentNgauNhien";
			rbCommentNgauNhien.Size = new System.Drawing.Size(201, 20);
			rbCommentNgauNhien.TabIndex = 3;
			rbCommentNgauNhien.Text = "Comment ngẫu nhiên nội dung";
			rbCommentNgauNhien.UseVisualStyleBackColor = true;
			rbCommentNgauNhien.CheckedChanged += new System.EventHandler(radioButton2_CheckedChanged);
			btnDown.BackgroundImage = maxcare.Properties.Resources.icons8_expand_arrow_24px;
			btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
			btnDown.Location = new System.Drawing.Point(224, -1);
			btnDown.Name = "btnDown";
			btnDown.Size = new System.Drawing.Size(25, 25);
			btnDown.TabIndex = 40;
			btnDown.UseSelectable = true;
			btnDown.Click += new System.EventHandler(btnDown_Click);
			button4.Cursor = System.Windows.Forms.Cursors.Help;
			button4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button4.Location = new System.Drawing.Point(136, 126);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(21, 21);
			button4.TabIndex = 173;
			button4.Text = "?";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			btnUp.BackgroundImage = maxcare.Properties.Resources.icons8_collapse_arrow_24px;
			btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
			btnUp.Location = new System.Drawing.Point(255, -1);
			btnUp.Name = "btnUp";
			btnUp.Size = new System.Drawing.Size(25, 25);
			btnUp.TabIndex = 41;
			btnUp.UseSelectable = true;
			btnUp.Click += new System.EventHandler(btnUp_Click);
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(4, 193);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(65, 16);
			label13.TabIndex = 2;
			label13.Text = "Tùy chọn:";
			label13.Click += new System.EventHandler(label13_Click);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 150);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(65, 16);
			label8.TabIndex = 2;
			label8.Text = "Tùy chọn:";
			txtComment.Location = new System.Drawing.Point(7, 25);
			txtComment.Name = "txtComment";
			txtComment.Size = new System.Drawing.Size(263, 102);
			txtComment.TabIndex = 1;
			txtComment.Text = "";
			txtComment.WordWrap = false;
			txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged_1);
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(5, 128);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(134, 16);
			label11.TabIndex = 0;
			label11.Text = "Spin nội dung {a|b|c}";
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 5);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(119, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Nội dung bình luận:";
			plAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plAnh.Controls.Add(txtAnh);
			plAnh.Controls.Add(label12);
			plAnh.Enabled = false;
			plAnh.Location = new System.Drawing.Point(371, 348);
			plAnh.Name = "plAnh";
			plAnh.Size = new System.Drawing.Size(281, 31);
			plAnh.TabIndex = 166;
			txtAnh.Location = new System.Drawing.Point(136, 3);
			txtAnh.Name = "txtAnh";
			txtAnh.Size = new System.Drawing.Size(140, 23);
			txtAnh.TabIndex = 155;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(3, 6);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(138, 16);
			label12.TabIndex = 39;
			label12.Text = "Đường dẫn folder ảnh:";
			label12.Click += new System.EventHandler(label12_Click);
			txtIdPost.Location = new System.Drawing.Point(30, 152);
			txtIdPost.Name = "txtIdPost";
			txtIdPost.Size = new System.Drawing.Size(297, 207);
			txtIdPost.TabIndex = 1;
			txtIdPost.Text = "";
			txtIdPost.WordWrap = false;
			txtIdPost.TextChanged += new System.EventHandler(txtIdPost_TextChanged);
			ckbSendAnh.AutoSize = true;
			ckbSendAnh.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbSendAnh.Location = new System.Drawing.Point(353, 324);
			ckbSendAnh.Name = "ckbSendAnh";
			ckbSendAnh.Size = new System.Drawing.Size(104, 20);
			ckbSendAnh.TabIndex = 165;
			ckbSendAnh.Text = "Bình luận ảnh";
			ckbSendAnh.UseVisualStyleBackColor = true;
			ckbSendAnh.CheckedChanged += new System.EventHandler(ckbSendAnh_CheckedChanged);
			ckbComment.AutoSize = true;
			ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbComment.Location = new System.Drawing.Point(353, 103);
			ckbComment.Name = "ckbComment";
			ckbComment.Size = new System.Drawing.Size(128, 20);
			ckbComment.TabIndex = 163;
			ckbComment.Text = "Bi\u0300nh luâ\u0323n văn bản";
			ckbComment.UseVisualStyleBackColor = true;
			ckbComment.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(27, 362);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(97, 16);
			label10.TabIndex = 39;
			label10.Text = "(Mỗi ID 1 dòng)";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(27, 132);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(154, 16);
			label2.TabIndex = 40;
			label2.Text = "Danh sa\u0301ch ID bài viết (0):";
			ckbShareWall.AutoSize = true;
			ckbShareWall.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbShareWall.Location = new System.Drawing.Point(508, 79);
			ckbShareWall.Name = "ckbShareWall";
			ckbShareWall.Size = new System.Drawing.Size(144, 20);
			ckbShareWall.TabIndex = 6;
			ckbShareWall.Text = "Chia sẻ bài về tường";
			ckbShareWall.UseVisualStyleBackColor = true;
			ckbInteract.AutoSize = true;
			ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbInteract.Location = new System.Drawing.Point(353, 79);
			ckbInteract.Name = "ckbInteract";
			ckbInteract.Size = new System.Drawing.Size(94, 20);
			ckbInteract.TabIndex = 5;
			ckbInteract.Text = "Like ba\u0300i viê\u0301t";
			ckbInteract.UseVisualStyleBackColor = true;
			nudTimeTo.Location = new System.Drawing.Point(568, 50);
			nudTimeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeTo.Name = "nudTimeTo";
			nudTimeTo.Size = new System.Drawing.Size(51, 23);
			nudTimeTo.TabIndex = 4;
			nudDelayTo.Location = new System.Drawing.Point(231, 78);
			nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 4;
			nudTimeFrom.Location = new System.Drawing.Point(490, 50);
			nudTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeFrom.Name = "nudTimeFrom";
			nudTimeFrom.Size = new System.Drawing.Size(51, 23);
			nudTimeFrom.TabIndex = 3;
			nudDelayFrom.Location = new System.Drawing.Point(134, 78);
			nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 3;
			txtTenHanhDong.Location = new System.Drawing.Point(134, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
			txtTenHanhDong.TabIndex = 0;
			label9.Location = new System.Drawing.Point(541, 52);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(29, 16);
			label9.TabIndex = 38;
			label9.Text = "đê\u0301n";
			label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label7.Location = new System.Drawing.Point(196, 80);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 38;
			label7.Text = "đê\u0301n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(621, 52);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(31, 16);
			label4.TabIndex = 36;
			label4.Text = "giây";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(289, 80);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(31, 16);
			label6.TabIndex = 36;
			label6.Text = "giây";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(350, 52);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(139, 16);
			label3.TabIndex = 34;
			label3.Text = "Thơ\u0300i gian xem bài viết:";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(27, 80);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(90, 16);
			label5.TabIndex = 34;
			label5.Text = "Thơ\u0300i gian chờ:";
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
			btnCancel.Location = new System.Drawing.Point(349, 395);
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
			btnAdd.Location = new System.Drawing.Point(242, 395);
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
			bunifuCards1.Size = new System.Drawing.Size(684, 37);
			bunifuCards1.TabIndex = 28;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(687, 437);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDBuffLikeComment";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).EndInit();
			plComment.ResumeLayout(false);
			plComment.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			plAnh.ResumeLayout(false);
			plAnh.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudTimeTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTimeFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
