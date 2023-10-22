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
	public class fHDTuongTacBanBe : Form
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

		private Panel plComment;

		private Label label8;

		private Label lblStatus;

		private CheckBox ckbComment;

		private CheckBox ckbInteract;

		private CheckBox ckbShareWall;

		private Label label9;

		private MetroButton btnDown;

		private MetroButton btnUp;

		private RichTextBox txtComment;

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

		private Label label2;

		private Label label10;

		private NumericUpDown nudCountLikeTo;

		private NumericUpDown nudTimeTo;

		private NumericUpDown nudTimeFrom;

		private Label label16;

		private Label label18;

		private Label label21;

		private GroupBox groupBox1;

		private Label label49;

		private NumericUpDown nudSoLuongBanBeFrom;

		private Label label68;

		private NumericUpDown nudSoLuongBanBeTo;

		private Label label66;

		private Button button3;

		private Button button2;

		private RadioButton rbNganCachKyTu;

		private RadioButton rbNganCachMoiDong;

		public fHDTuongTacBanBe(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			if (InteractSQL.GetTuongTac("", "HDTuongTacBanBe").Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\", \"MoTa\") VALUES ('HDTuongTacBanBe', 'Tương tác Bạn bè');");
			}
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDTuongTacBanBe");
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
			Language.GetValue(label49);
			Language.GetValue(label66);
			Language.GetValue(label68);
			Language.GetValue(groupBox1);
			Language.GetValue(label21);
			Language.GetValue(label16);
			Language.GetValue(label18);
			Language.GetValue(label10);
			Language.GetValue(label2);
			Language.GetValue(label12);
			Language.GetValue(label11);
			Language.GetValue(label14);
			Language.GetValue(label13);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(ckbInteract);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudSoLuongBanBeFrom.Value = setting.GetValueInt("nudSoLuongBanBeFrom", 1);
				nudSoLuongBanBeTo.Value = setting.GetValueInt("nudSoLuongBanBeTo", 3);
				nudTimeFrom.Value = setting.GetValueInt("nudTimeFrom", 10);
				nudTimeTo.Value = setting.GetValueInt("nudTimeTo", 30);
				nudCountLikeFrom.Value = setting.GetValueInt("nudCountLikeFrom", 1);
				nudCountLikeTo.Value = setting.GetValueInt("nudCountLikeTo", 3);
				nudCountShareFrom.Value = setting.GetValueInt("nudCountShareFrom", 1);
				nudCountShareTo.Value = setting.GetValueInt("nudCountShareTo", 3);
				nudCountCommentFrom.Value = setting.GetValueInt("nudCountCommentFrom", 1);
				nudCountCommentTo.Value = setting.GetValueInt("nudCountCommentTo", 3);
				ckbInteract.Checked = setting.GetValueBool("ckbInteract");
				ckbShareWall.Checked = setting.GetValueBool("ckbShareWall");
				ckbComment.Checked = setting.GetValueBool("ckbComment");
				txtComment.Text = setting.GetValue("txtComment");
				if (setting.GetValueInt("typeNganCach") == 1)
				{
					rbNganCachKyTu.Checked = true;
				}
				else
				{
					rbNganCachMoiDong.Checked = true;
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
			jSON_Settings.Update("nudSoLuongBanBeFrom", nudSoLuongBanBeFrom.Value);
			jSON_Settings.Update("nudSoLuongBanBeTo", nudSoLuongBanBeTo.Value);
			jSON_Settings.Update("nudTimeFrom", nudTimeFrom.Value);
			jSON_Settings.Update("nudTimeTo", nudTimeTo.Value);
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

		private void txtComment_TextChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void UpdateSoLuongBinhLuan()
		{
			try
			{
				List<string> list = new List<string>();
				list = ((!rbNganCachMoiDong.Checked) ? txtComment.Text.Split(new string[1] { "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).ToList() : txtComment.Lines.ToList());
				list = MCommon.Common.RemoveEmptyItems(list);
				lblStatus.Text = string.Format(Language.GetValue("Nội dung bình luận ({0}):"), list.Count.ToString());
			}
			catch
			{
			}
		}

		private void CheckedChangeFull()
		{
			ckbInteract_CheckedChanged(null, null);
			ckbComment_CheckedChanged(null, null);
			ckbShareWall_CheckedChanged(null, null);
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
			plCountComment.Enabled = ckbComment.Checked;
			plComment.Enabled = ckbComment.Checked;
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			groupBox1.Height = 341;
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			groupBox1.Height = 382;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
			{
				btnUp.Visible = true;
				btnDown.Visible = true;
			}
		}

		private void rbNganCachMoiDong_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void rbNganCachKyTu_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
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

		private void button2_Click_1(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDTuongTacBanBe));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			groupBox1 = new System.Windows.Forms.GroupBox();
			plComment = new System.Windows.Forms.Panel();
			txtComment = new System.Windows.Forms.RichTextBox();
			btnDown = new MetroFramework.Controls.MetroButton();
			btnUp = new MetroFramework.Controls.MetroButton();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			ckbInteract = new System.Windows.Forms.CheckBox();
			ckbShareWall = new System.Windows.Forms.CheckBox();
			ckbComment = new System.Windows.Forms.CheckBox();
			plCountComment = new System.Windows.Forms.Panel();
			nudCountCommentFrom = new System.Windows.Forms.NumericUpDown();
			label13 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			nudCountCommentTo = new System.Windows.Forms.NumericUpDown();
			label18 = new System.Windows.Forms.Label();
			plCountShareWall = new System.Windows.Forms.Panel();
			nudCountShareFrom = new System.Windows.Forms.NumericUpDown();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			nudCountShareTo = new System.Windows.Forms.NumericUpDown();
			plCountLike = new System.Windows.Forms.Panel();
			nudCountLikeFrom = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			nudCountLikeTo = new System.Windows.Forms.NumericUpDown();
			label16 = new System.Windows.Forms.Label();
			nudTimeTo = new System.Windows.Forms.NumericUpDown();
			nudTimeFrom = new System.Windows.Forms.NumericUpDown();
			label49 = new System.Windows.Forms.Label();
			nudSoLuongBanBeFrom = new System.Windows.Forms.NumericUpDown();
			label68 = new System.Windows.Forms.Label();
			nudSoLuongBanBeTo = new System.Windows.Forms.NumericUpDown();
			label66 = new System.Windows.Forms.Label();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			rbNganCachKyTu = new System.Windows.Forms.RadioButton();
			rbNganCachMoiDong = new System.Windows.Forms.RadioButton();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			groupBox1.SuspendLayout();
			plComment.SuspendLayout();
			plCountComment.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountCommentFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountCommentTo).BeginInit();
			plCountShareWall.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountShareFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountShareTo).BeginInit();
			plCountLike.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountLikeFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountLikeTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTimeTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTimeFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBanBeFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBanBeTo).BeginInit();
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
			bunifuCustomLabel1.Text = "Cấu hình Tương tác Bạn bè";
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
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(label49);
			panel1.Controls.Add(nudSoLuongBanBeFrom);
			panel1.Controls.Add(label68);
			panel1.Controls.Add(nudSoLuongBanBeTo);
			panel1.Controls.Add(label66);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(362, 482);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			groupBox1.Controls.Add(plComment);
			groupBox1.Controls.Add(label21);
			groupBox1.Controls.Add(ckbInteract);
			groupBox1.Controls.Add(ckbShareWall);
			groupBox1.Controls.Add(ckbComment);
			groupBox1.Controls.Add(plCountComment);
			groupBox1.Controls.Add(label18);
			groupBox1.Controls.Add(plCountShareWall);
			groupBox1.Controls.Add(plCountLike);
			groupBox1.Controls.Add(label16);
			groupBox1.Controls.Add(nudTimeTo);
			groupBox1.Controls.Add(nudTimeFrom);
			groupBox1.Location = new System.Drawing.Point(21, 111);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(321, 312);
			groupBox1.TabIndex = 124;
			groupBox1.TabStop = false;
			groupBox1.Text = "Cấu hình tương tác/Bạn bè";
			plComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(button3);
			plComment.Controls.Add(button2);
			plComment.Controls.Add(rbNganCachKyTu);
			plComment.Controls.Add(rbNganCachMoiDong);
			plComment.Controls.Add(txtComment);
			plComment.Controls.Add(btnDown);
			plComment.Controls.Add(btnUp);
			plComment.Controls.Add(label9);
			plComment.Controls.Add(label8);
			plComment.Controls.Add(lblStatus);
			plComment.Location = new System.Drawing.Point(32, 141);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(281, 162);
			plComment.TabIndex = 10;
			txtComment.Location = new System.Drawing.Point(7, 27);
			txtComment.Name = "txtComment";
			txtComment.Size = new System.Drawing.Size(266, 111);
			txtComment.TabIndex = 106;
			txtComment.Text = "";
			txtComment.WordWrap = false;
			txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged);
			btnDown.BackgroundImage = maxcare.Properties.Resources.icons8_expand_arrow_24px;
			btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
			btnDown.Location = new System.Drawing.Point(224, -1);
			btnDown.Name = "btnDown";
			btnDown.Size = new System.Drawing.Size(25, 25);
			btnDown.TabIndex = 7;
			btnDown.UseSelectable = true;
			btnDown.Visible = false;
			btnDown.Click += new System.EventHandler(pictureBox3_Click);
			btnUp.BackgroundImage = maxcare.Properties.Resources.icons8_collapse_arrow_24px;
			btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
			btnUp.Location = new System.Drawing.Point(255, -1);
			btnUp.Name = "btnUp";
			btnUp.Size = new System.Drawing.Size(25, 25);
			btnUp.TabIndex = 7;
			btnUp.UseSelectable = true;
			btnUp.Visible = false;
			btnUp.Click += new System.EventHandler(pictureBox2_Click);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(4, 161);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(65, 16);
			label9.TabIndex = 4;
			label9.Text = "Tùy chọn:";
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
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(6, 25);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(92, 16);
			label21.TabIndex = 110;
			label21.Text = "Thơ\u0300i gian lươ\u0301t:";
			ckbInteract.AutoSize = true;
			ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbInteract.Location = new System.Drawing.Point(10, 53);
			ckbInteract.Name = "ckbInteract";
			ckbInteract.Size = new System.Drawing.Size(76, 20);
			ckbInteract.TabIndex = 7;
			ckbInteract.Text = "Cảm xúc";
			ckbInteract.UseVisualStyleBackColor = true;
			ckbInteract.CheckedChanged += new System.EventHandler(ckbInteract_CheckedChanged);
			ckbShareWall.AutoSize = true;
			ckbShareWall.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbShareWall.Location = new System.Drawing.Point(10, 82);
			ckbShareWall.Name = "ckbShareWall";
			ckbShareWall.Size = new System.Drawing.Size(90, 20);
			ckbShareWall.TabIndex = 8;
			ckbShareWall.Text = "Share Wall";
			ckbShareWall.UseVisualStyleBackColor = true;
			ckbShareWall.CheckedChanged += new System.EventHandler(ckbShareWall_CheckedChanged);
			ckbComment.AutoSize = true;
			ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbComment.Location = new System.Drawing.Point(10, 111);
			ckbComment.Name = "ckbComment";
			ckbComment.Size = new System.Drawing.Size(82, 20);
			ckbComment.TabIndex = 9;
			ckbComment.Text = "Comment";
			ckbComment.UseVisualStyleBackColor = true;
			ckbComment.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
			plCountComment.Controls.Add(nudCountCommentFrom);
			plCountComment.Controls.Add(label13);
			plCountComment.Controls.Add(label14);
			plCountComment.Controls.Add(nudCountCommentTo);
			plCountComment.Location = new System.Drawing.Point(117, 110);
			plCountComment.Name = "plCountComment";
			plCountComment.Size = new System.Drawing.Size(196, 25);
			plCountComment.TabIndex = 118;
			nudCountCommentFrom.Location = new System.Drawing.Point(1, 1);
			nudCountCommentFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountCommentFrom.Name = "nudCountCommentFrom";
			nudCountCommentFrom.Size = new System.Drawing.Size(56, 23);
			nudCountCommentFrom.TabIndex = 1;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(156, 3);
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
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(273, 25);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(31, 16);
			label18.TabIndex = 112;
			label18.Text = "giây";
			plCountShareWall.Controls.Add(nudCountShareFrom);
			plCountShareWall.Controls.Add(label11);
			plCountShareWall.Controls.Add(label12);
			plCountShareWall.Controls.Add(nudCountShareTo);
			plCountShareWall.Location = new System.Drawing.Point(117, 80);
			plCountShareWall.Name = "plCountShareWall";
			plCountShareWall.Size = new System.Drawing.Size(196, 25);
			plCountShareWall.TabIndex = 117;
			nudCountShareFrom.Location = new System.Drawing.Point(1, 1);
			nudCountShareFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountShareFrom.Name = "nudCountShareFrom";
			nudCountShareFrom.Size = new System.Drawing.Size(56, 23);
			nudCountShareFrom.TabIndex = 1;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(156, 3);
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
			plCountLike.Controls.Add(label2);
			plCountLike.Controls.Add(label10);
			plCountLike.Controls.Add(nudCountLikeTo);
			plCountLike.Location = new System.Drawing.Point(117, 51);
			plCountLike.Name = "plCountLike";
			plCountLike.Size = new System.Drawing.Size(196, 25);
			plCountLike.TabIndex = 116;
			nudCountLikeFrom.Location = new System.Drawing.Point(1, 1);
			nudCountLikeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountLikeFrom.Name = "nudCountLikeFrom";
			nudCountLikeFrom.Size = new System.Drawing.Size(56, 23);
			nudCountLikeFrom.TabIndex = 1;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(156, 3);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 16);
			label2.TabIndex = 35;
			label2.Text = "lần";
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
			label16.Location = new System.Drawing.Point(179, 25);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(29, 16);
			label16.TabIndex = 114;
			label16.Text = "đê\u0301n";
			label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudTimeTo.Location = new System.Drawing.Point(214, 23);
			nudTimeTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeTo.Name = "nudTimeTo";
			nudTimeTo.Size = new System.Drawing.Size(56, 23);
			nudTimeTo.TabIndex = 107;
			nudTimeFrom.Location = new System.Drawing.Point(117, 23);
			nudTimeFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTimeFrom.Name = "nudTimeFrom";
			nudTimeFrom.Size = new System.Drawing.Size(56, 23);
			nudTimeFrom.TabIndex = 106;
			label49.AutoSize = true;
			label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label49.Location = new System.Drawing.Point(18, 82);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(107, 16);
			label49.TabIndex = 121;
			label49.Text = "Sô\u0301 lươ\u0323ng ba\u0323n be\u0300:";
			nudSoLuongBanBeFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongBanBeFrom.Location = new System.Drawing.Point(129, 80);
			nudSoLuongBanBeFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongBanBeFrom.Name = "nudSoLuongBanBeFrom";
			nudSoLuongBanBeFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongBanBeFrom.TabIndex = 119;
			nudSoLuongBanBeFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label68.AutoSize = true;
			label68.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label68.Location = new System.Drawing.Point(287, 82);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(29, 16);
			label68.TabIndex = 122;
			label68.Text = "ba\u0323n";
			nudSoLuongBanBeTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongBanBeTo.Location = new System.Drawing.Point(226, 80);
			nudSoLuongBanBeTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongBanBeTo.Name = "nudSoLuongBanBeTo";
			nudSoLuongBanBeTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongBanBeTo.TabIndex = 120;
			nudSoLuongBanBeTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label66.AutoSize = true;
			label66.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label66.Location = new System.Drawing.Point(191, 82);
			label66.Name = "label66";
			label66.Size = new System.Drawing.Size(29, 16);
			label66.TabIndex = 123;
			label66.Text = "đê\u0301n";
			txtTenHanhDong.Location = new System.Drawing.Point(129, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(213, 23);
			txtTenHanhDong.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(18, 52);
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
			btnCancel.Location = new System.Drawing.Point(186, 440);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 12;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(79, 440);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 11;
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
			button3.Cursor = System.Windows.Forms.Cursors.Help;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Location = new System.Drawing.Point(223, 184);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(21, 23);
			button3.TabIndex = 111;
			button3.Text = "?";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.Cursor = System.Windows.Forms.Cursors.Help;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(223, 161);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(21, 23);
			button2.TabIndex = 112;
			button2.Text = "?";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click_1);
			rbNganCachKyTu.AutoSize = true;
			rbNganCachKyTu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachKyTu.Location = new System.Drawing.Point(68, 182);
			rbNganCachKyTu.Name = "rbNganCachKyTu";
			rbNganCachKyTu.Size = new System.Drawing.Size(160, 20);
			rbNganCachKyTu.TabIndex = 110;
			rbNganCachKyTu.Text = "Nội dung có nhiều dòng";
			rbNganCachKyTu.UseVisualStyleBackColor = true;
			rbNganCachMoiDong.AutoSize = true;
			rbNganCachMoiDong.Checked = true;
			rbNganCachMoiDong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachMoiDong.Location = new System.Drawing.Point(68, 161);
			rbNganCachMoiDong.Name = "rbNganCachMoiDong";
			rbNganCachMoiDong.Size = new System.Drawing.Size(156, 20);
			rbNganCachMoiDong.TabIndex = 109;
			rbNganCachMoiDong.TabStop = true;
			rbNganCachMoiDong.Text = "Nội dung chỉ có 1 dòng";
			rbNganCachMoiDong.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(362, 482);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDTuongTacBanBe";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			plComment.ResumeLayout(false);
			plComment.PerformLayout();
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
			((System.ComponentModel.ISupportInitialize)nudTimeTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTimeFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBanBeFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBanBeTo).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
