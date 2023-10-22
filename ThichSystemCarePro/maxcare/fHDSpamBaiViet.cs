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
	public class fHDSpamBaiViet : Form
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

		private NumericUpDown nudSoLuongBaiVietTo;

		private NumericUpDown nudDelayFrom;

		private NumericUpDown nudSoLuongBaiVietFrom;

		private TextBox txtTenHanhDong;

		private Label label7;

		private Label label3;

		private Label label6;

		private Label label4;

		private Label label5;

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

		private Label label49;

		private NumericUpDown nudSoLuongUidFrom;

		private Label label68;

		private Label label19;

		private NumericUpDown nudSoLuongUidTo;

		private Label label66;

		private RichTextBox txtUid;

		private RichTextBox txtComment;

		private CheckBox ckbTuDongXoaUid;

		private RadioButton rbNganCachKyTu;

		private RadioButton rbNganCachMoiDong;

		private Label label9;

		private Label label10;

		private Button button3;

		private Button button2;

		private LinkLabel linkLabel1;

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

		private CheckBox ckbInteract;

		private Label label2;

		private RadioButton rbPage;

		private RadioButton rbGroup;

		private RadioButton rbUser;

		public fHDSpamBaiViet(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			if (InteractSQL.GetTuongTac("", "HDSpamBaiViet").Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\", \"MoTa\") VALUES ('HDSpamBaiViet', 'Spam ba\u0300i viê\u0301t');");
			}
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDSpamBaiViet");
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
			Language.GetValue(label19);
			Language.GetValue(label3);
			Language.GetValue(label4);
			Language.GetValue(label5);
			Language.GetValue(label7);
			Language.GetValue(label6);
			Language.GetValue(label10);
			Language.GetValue(ckbTuDongXoaUid);
			Language.GetValue(ckbInteract);
			Language.GetValue(ckbComment);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(label9);
			Language.GetValue(rbNganCachMoiDong);
			Language.GetValue(button2);
			Language.GetValue(rbNganCachKyTu);
			Language.GetValue(button3);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(label2);
			Language.GetValue(label25);
			Language.GetValue(label26);
			Language.GetValue(label28);
			Language.GetValue(label29);
			Language.GetValue(label30);
			Language.GetValue(label32);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudSoLuongUidFrom.Value = setting.GetValueInt("nudSoLuongUidFrom", 1);
				nudSoLuongUidTo.Value = setting.GetValueInt("nudSoLuongUidTo", 1);
				nudSoLuongBaiVietFrom.Value = setting.GetValueInt("nudSoLuongBaiVietFrom", 1);
				nudSoLuongBaiVietTo.Value = setting.GetValueInt("nudSoLuongBaiVietTo", 1);
				nudDelayFrom.Value = setting.GetValueInt("nudDelayFrom", 3);
				nudDelayTo.Value = setting.GetValueInt("nudDelayTo", 5);
				switch (setting.GetValueInt("typeID"))
				{
				case 0:
					rbUser.Checked = true;
					break;
				case 1:
					rbGroup.Checked = true;
					break;
				case 2:
					rbPage.Checked = true;
					break;
				}
				txtUid.Text = setting.GetValue("txtUid");
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
				ckbTuDongXoaUid.Checked = setting.GetValueBool("ckbTuDongXoaUid");
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
			List<string> lst = txtUid.Lines.ToList();
			lst = MCommon.Common.RemoveEmptyItems(lst);
			if (lst.Count == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p danh sa\u0301ch ID!"), 3);
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
			jSON_Settings.Update("nudSoLuongUidFrom", nudSoLuongUidFrom.Value);
			jSON_Settings.Update("nudSoLuongUidTo", nudSoLuongUidTo.Value);
			jSON_Settings.Update("nudSoLuongBaiVietFrom", nudSoLuongBaiVietFrom.Value);
			jSON_Settings.Update("nudSoLuongBaiVietTo", nudSoLuongBaiVietTo.Value);
			jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
			jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
			int num = 0;
			if (rbGroup.Checked)
			{
				num = 1;
			}
			if (rbPage.Checked)
			{
				num = 2;
			}
			jSON_Settings.Update("typeID", num);
			jSON_Settings.Update("txtUid", txtUid.Text.Trim());
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
			jSON_Settings.Update("ckbTuDongXoaUid", ckbTuDongXoaUid.Checked);
			int num2 = 0;
			if (rbNganCachKyTu.Checked)
			{
				num2 = 1;
			}
			jSON_Settings.Update("typeNganCach", num2);
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
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
			plComment.Enabled = ckbComment.Checked;
		}

		private void txtUid_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtUid.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				label10.Text = string.Format(Language.GetValue("Nhập danh sách ID User/Group/Page ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void txtComment_MouseLeave(object sender, EventArgs e)
		{
		}

		private void txtComment_MouseEnter(object sender, EventArgs e)
		{
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhập mỗi dòng là 1 nội dung!"));
			txtComment.Focus();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHelpNhapComment());
			txtComment.Focus();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Chú ý: Nếu là ID Fanpage thì cần thêm /posts vào sau ID.") + "\r\n" + Language.GetValue("Ví dụ") + ": 15465478242/posts");
		}

		private void rbNganCachMoiDong_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void rbNganCachKyTu_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MCommon.Common.ShowForm(new fHuongDanRandom());
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
		{
			plInteract.Enabled = ckbInteract.Checked;
		}

		private void label26_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDSpamBaiViet));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			rbPage = new System.Windows.Forms.RadioButton();
			rbGroup = new System.Windows.Forms.RadioButton();
			rbUser = new System.Windows.Forms.RadioButton();
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
			ckbInteract = new System.Windows.Forms.CheckBox();
			plComment = new System.Windows.Forms.Panel();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			rbNganCachKyTu = new System.Windows.Forms.RadioButton();
			rbNganCachMoiDong = new System.Windows.Forms.RadioButton();
			label9 = new System.Windows.Forms.Label();
			txtComment = new System.Windows.Forms.RichTextBox();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			txtUid = new System.Windows.Forms.RichTextBox();
			label10 = new System.Windows.Forms.Label();
			label49 = new System.Windows.Forms.Label();
			nudSoLuongUidFrom = new System.Windows.Forms.NumericUpDown();
			label68 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			nudSoLuongUidTo = new System.Windows.Forms.NumericUpDown();
			label66 = new System.Windows.Forms.Label();
			ckbComment = new System.Windows.Forms.CheckBox();
			ckbTuDongXoaUid = new System.Windows.Forms.CheckBox();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			nudSoLuongBaiVietTo = new System.Windows.Forms.NumericUpDown();
			nudDelayFrom = new System.Windows.Forms.NumericUpDown();
			nudSoLuongBaiVietFrom = new System.Windows.Forms.NumericUpDown();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			plInteract.SuspendLayout();
			plComment.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietFrom).BeginInit();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(680, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Spam ba\u0300i viê\u0301t";
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
			pnlHeader.Size = new System.Drawing.Size(680, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(649, 1);
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
			panel1.Controls.Add(label2);
			panel1.Controls.Add(rbPage);
			panel1.Controls.Add(rbGroup);
			panel1.Controls.Add(rbUser);
			panel1.Controls.Add(plInteract);
			panel1.Controls.Add(ckbInteract);
			panel1.Controls.Add(plComment);
			panel1.Controls.Add(txtUid);
			panel1.Controls.Add(label10);
			panel1.Controls.Add(label49);
			panel1.Controls.Add(nudSoLuongUidFrom);
			panel1.Controls.Add(label68);
			panel1.Controls.Add(label19);
			panel1.Controls.Add(nudSoLuongUidTo);
			panel1.Controls.Add(label66);
			panel1.Controls.Add(ckbComment);
			panel1.Controls.Add(ckbTuDongXoaUid);
			panel1.Controls.Add(nudDelayTo);
			panel1.Controls.Add(nudSoLuongBaiVietTo);
			panel1.Controls.Add(nudDelayFrom);
			panel1.Controls.Add(nudSoLuongBaiVietFrom);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(683, 453);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(28, 166);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(60, 16);
			label2.TabIndex = 174;
			label2.Text = "Loại ID : ";
			rbPage.AutoSize = true;
			rbPage.Cursor = System.Windows.Forms.Cursors.Hand;
			rbPage.Location = new System.Drawing.Point(266, 164);
			rbPage.Name = "rbPage";
			rbPage.Size = new System.Drawing.Size(54, 20);
			rbPage.TabIndex = 173;
			rbPage.Text = "Page";
			rbPage.UseVisualStyleBackColor = true;
			rbGroup.AutoSize = true;
			rbGroup.Cursor = System.Windows.Forms.Cursors.Hand;
			rbGroup.Location = new System.Drawing.Point(199, 164);
			rbGroup.Name = "rbGroup";
			rbGroup.Size = new System.Drawing.Size(60, 20);
			rbGroup.TabIndex = 172;
			rbGroup.Text = "Group";
			rbGroup.UseVisualStyleBackColor = true;
			rbUser.AutoSize = true;
			rbUser.Checked = true;
			rbUser.Cursor = System.Windows.Forms.Cursors.Hand;
			rbUser.Location = new System.Drawing.Point(135, 164);
			rbUser.Name = "rbUser";
			rbUser.Size = new System.Drawing.Size(52, 20);
			rbUser.TabIndex = 171;
			rbUser.TabStop = true;
			rbUser.Text = "User";
			rbUser.UseVisualStyleBackColor = true;
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
			plInteract.Location = new System.Drawing.Point(367, 105);
			plInteract.Name = "plInteract";
			plInteract.Size = new System.Drawing.Size(282, 40);
			plInteract.TabIndex = 170;
			label25.Cursor = System.Windows.Forms.Cursors.Hand;
			label25.Location = new System.Drawing.Point(4, 1);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(30, 16);
			label25.TabIndex = 0;
			label25.Text = "Like";
			label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label26.Cursor = System.Windows.Forms.Cursors.Hand;
			label26.Location = new System.Drawing.Point(44, 1);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(41, 16);
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
			label29.Cursor = System.Windows.Forms.Cursors.Hand;
			label29.Location = new System.Drawing.Point(140, 1);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(37, 16);
			label29.TabIndex = 8;
			label29.Text = "Wow";
			label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label30.Cursor = System.Windows.Forms.Cursors.Hand;
			label30.Location = new System.Drawing.Point(187, 1);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(36, 16);
			label30.TabIndex = 10;
			label30.Text = "Buồn";
			label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			label32.Location = new System.Drawing.Point(232, 1);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(41, 16);
			label32.TabIndex = 12;
			label32.Text = "Giận";
			label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbInteract.AutoSize = true;
			ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbInteract.Location = new System.Drawing.Point(349, 82);
			ckbInteract.Name = "ckbInteract";
			ckbInteract.Size = new System.Drawing.Size(113, 20);
			ckbInteract.TabIndex = 169;
			ckbInteract.Text = "Ba\u0300y to\u0309 ca\u0309m xu\u0301c";
			ckbInteract.UseVisualStyleBackColor = true;
			ckbInteract.CheckedChanged += new System.EventHandler(ckbInteract_CheckedChanged);
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(linkLabel1);
			plComment.Controls.Add(button3);
			plComment.Controls.Add(button2);
			plComment.Controls.Add(rbNganCachKyTu);
			plComment.Controls.Add(rbNganCachMoiDong);
			plComment.Controls.Add(label9);
			plComment.Controls.Add(txtComment);
			plComment.Controls.Add(label8);
			plComment.Controls.Add(lblStatus);
			plComment.Location = new System.Drawing.Point(367, 173);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(281, 193);
			plComment.TabIndex = 10;
			linkLabel1.AutoSize = true;
			linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel1.Location = new System.Drawing.Point(191, 126);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(82, 16);
			linkLabel1.TabIndex = 192;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Random icon";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			button3.Cursor = System.Windows.Forms.Cursors.Help;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Location = new System.Drawing.Point(229, 168);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(21, 23);
			button3.TabIndex = 4;
			button3.Text = "?";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.Cursor = System.Windows.Forms.Cursors.Help;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(229, 145);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(21, 23);
			button2.TabIndex = 4;
			button2.Text = "?";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click_1);
			rbNganCachKyTu.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			rbNganCachKyTu.AutoSize = true;
			rbNganCachKyTu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachKyTu.Location = new System.Drawing.Point(70, 168);
			rbNganCachKyTu.Name = "rbNganCachKyTu";
			rbNganCachKyTu.Size = new System.Drawing.Size(160, 20);
			rbNganCachKyTu.TabIndex = 3;
			rbNganCachKyTu.Text = "Nội dung có nhiều dòng";
			rbNganCachKyTu.UseVisualStyleBackColor = true;
			rbNganCachKyTu.CheckedChanged += new System.EventHandler(rbNganCachKyTu_CheckedChanged);
			rbNganCachMoiDong.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			rbNganCachMoiDong.AutoSize = true;
			rbNganCachMoiDong.Checked = true;
			rbNganCachMoiDong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachMoiDong.Location = new System.Drawing.Point(70, 147);
			rbNganCachMoiDong.Name = "rbNganCachMoiDong";
			rbNganCachMoiDong.Size = new System.Drawing.Size(156, 20);
			rbNganCachMoiDong.TabIndex = 3;
			rbNganCachMoiDong.TabStop = true;
			rbNganCachMoiDong.Text = "Nội dung chỉ có 1 dòng";
			rbNganCachMoiDong.UseVisualStyleBackColor = true;
			rbNganCachMoiDong.CheckedChanged += new System.EventHandler(rbNganCachMoiDong_CheckedChanged);
			label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(5, 147);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(65, 16);
			label9.TabIndex = 2;
			label9.Text = "Tùy chọn:";
			txtComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtComment.Location = new System.Drawing.Point(7, 25);
			txtComment.Name = "txtComment";
			txtComment.Size = new System.Drawing.Size(263, 99);
			txtComment.TabIndex = 1;
			txtComment.Text = "";
			txtComment.WordWrap = false;
			txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged);
			txtComment.MouseEnter += new System.EventHandler(txtComment_MouseEnter);
			txtComment.MouseLeave += new System.EventHandler(txtComment_MouseLeave);
			label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 127);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(144, 16);
			label8.TabIndex = 0;
			label8.Text = "(Spin nội dung {a|b|c})";
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 5);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(140, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Nội dung bình luận (0):";
			txtUid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtUid.Location = new System.Drawing.Point(31, 210);
			txtUid.Name = "txtUid";
			txtUid.Size = new System.Drawing.Size(299, 158);
			txtUid.TabIndex = 117;
			txtUid.Text = "";
			txtUid.WordWrap = false;
			txtUid.TextChanged += new System.EventHandler(txtUid_TextChanged);
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(27, 190);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(243, 16);
			label10.TabIndex = 116;
			label10.Text = "Nhập danh sách ID User/Group/Page (0):";
			label49.AutoSize = true;
			label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label49.Location = new System.Drawing.Point(27, 81);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(102, 16);
			label49.TabIndex = 92;
			label49.Text = "Sô\u0301 lươ\u0323ng ID/nick";
			nudSoLuongUidFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongUidFrom.Location = new System.Drawing.Point(137, 79);
			nudSoLuongUidFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongUidFrom.Name = "nudSoLuongUidFrom";
			nudSoLuongUidFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongUidFrom.TabIndex = 1;
			nudSoLuongUidFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label68.AutoSize = true;
			label68.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label68.Location = new System.Drawing.Point(292, 81);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(20, 16);
			label68.TabIndex = 99;
			label68.Text = "ID";
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label19.Location = new System.Drawing.Point(27, 110);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(90, 16);
			label19.TabIndex = 101;
			label19.Text = "Sô\u0301 ba\u0300i viết/ID:";
			nudSoLuongUidTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongUidTo.Location = new System.Drawing.Point(234, 79);
			nudSoLuongUidTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongUidTo.Name = "nudSoLuongUidTo";
			nudSoLuongUidTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongUidTo.TabIndex = 2;
			nudSoLuongUidTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label66.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label66.Location = new System.Drawing.Point(199, 81);
			label66.Name = "label66";
			label66.Size = new System.Drawing.Size(29, 16);
			label66.TabIndex = 105;
			label66.Text = "đê\u0301n";
			label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbComment.AutoSize = true;
			ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbComment.Location = new System.Drawing.Point(349, 149);
			ckbComment.Name = "ckbComment";
			ckbComment.Size = new System.Drawing.Size(128, 20);
			ckbComment.TabIndex = 9;
			ckbComment.Text = "Bi\u0300nh luâ\u0323n văn bản";
			ckbComment.UseVisualStyleBackColor = true;
			ckbComment.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
			ckbTuDongXoaUid.AutoSize = true;
			ckbTuDongXoaUid.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuDongXoaUid.Location = new System.Drawing.Point(31, 371);
			ckbTuDongXoaUid.Name = "ckbTuDongXoaUid";
			ckbTuDongXoaUid.Size = new System.Drawing.Size(191, 20);
			ckbTuDongXoaUid.TabIndex = 8;
			ckbTuDongXoaUid.Text = "Tự động xóa ID đã tương tác";
			ckbTuDongXoaUid.UseVisualStyleBackColor = true;
			nudDelayTo.Location = new System.Drawing.Point(234, 137);
			nudDelayTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 6;
			nudSoLuongBaiVietTo.Location = new System.Drawing.Point(234, 108);
			nudSoLuongBaiVietTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongBaiVietTo.Name = "nudSoLuongBaiVietTo";
			nudSoLuongBaiVietTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongBaiVietTo.TabIndex = 4;
			nudDelayFrom.Location = new System.Drawing.Point(137, 137);
			nudDelayFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 5;
			nudSoLuongBaiVietFrom.Location = new System.Drawing.Point(137, 108);
			nudSoLuongBaiVietFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongBaiVietFrom.Name = "nudSoLuongBaiVietFrom";
			nudSoLuongBaiVietFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongBaiVietFrom.TabIndex = 3;
			txtTenHanhDong.Location = new System.Drawing.Point(135, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(195, 23);
			txtTenHanhDong.TabIndex = 0;
			label7.Location = new System.Drawing.Point(199, 139);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 38;
			label7.Text = "đê\u0301n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label3.Location = new System.Drawing.Point(199, 110);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 16);
			label3.TabIndex = 37;
			label3.Text = "đê\u0301n";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(292, 139);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(31, 16);
			label6.TabIndex = 36;
			label6.Text = "giây";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(292, 110);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(25, 16);
			label4.TabIndex = 35;
			label4.Text = "ba\u0300i";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(27, 139);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(90, 16);
			label5.TabIndex = 34;
			label5.Text = "Thơ\u0300i gian chơ\u0300:";
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
			btnCancel.Location = new System.Drawing.Point(349, 411);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 12;
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
			btnAdd.Location = new System.Drawing.Point(242, 411);
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
			bunifuCards1.Size = new System.Drawing.Size(680, 37);
			bunifuCards1.TabIndex = 28;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(683, 453);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDSpamBaiViet";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plInteract.ResumeLayout(false);
			plInteract.PerformLayout();
			plComment.ResumeLayout(false);
			plComment.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
