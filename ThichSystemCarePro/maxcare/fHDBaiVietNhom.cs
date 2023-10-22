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
using Newtonsoft.Json.Linq;

namespace maxcare
{
	public class fHDBaiVietNhom : Form
	{
		private JObject setting;

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

		private CheckBox ckbComment;

		private CheckBox ckbInteract;

		private CheckBox ckbShareWall;

		private Label label49;

		private NumericUpDown nudSoLuongNhomFrom;

		private Label label68;

		private Label label19;

		private NumericUpDown nudSoLuongNhomTo;

		private Label label66;

		private Panel plComment;

		private RichTextBox txtComment;

		private MetroButton btnDown;

		private MetroButton btnUp;

		private RadioButton rbNganCachKyTu;

		private RadioButton rbNganCachMoiDong;

		private Label label9;

		private Label label8;

		private Label lblStatus;

		private Panel plAnh;

		private Button button2;

		private TextBox txtAnh;

		private CheckBox ckbSendAnh;

		private Button button3;

		public fHDBaiVietNhom(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string json = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDBaiVietNhom");
				json = tuongTac.Rows[0]["CauHinh"].ToString();
				id_TuongTac = tuongTac.Rows[0]["Id_TuongTac"].ToString();
				txtTenHanhDong.Text = Language.GetValue(tuongTac.Rows[0]["MoTa"].ToString());
				break;
			}
			case 1:
			{
				DataTable hanhDongById = InteractSQL.GetHanhDongById(id_HanhDong);
				json = hanhDongById.Rows[0]["CauHinh"].ToString();
				btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
				txtTenHanhDong.Text = hanhDongById.Rows[0]["TenHanhDong"].ToString();
				break;
			}
			}
			setting = JObject.Parse(json);
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label1);
			Language.GetValue(label49);
			Language.GetValue(label66);
			Language.GetValue(label68);
			Language.GetValue(label19);
			Language.GetValue(label3);
			Language.GetValue(label4);
			Language.GetValue(label5);
			Language.GetValue(label7);
			Language.GetValue(label6);
			Language.GetValue(ckbShareWall);
			Language.GetValue(ckbSendAnh);
			Language.GetValue(button2);
			Language.GetValue(ckbComment);
			Language.GetValue(lblStatus);
			Language.GetValue(button3);
			Language.GetValue(label8);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudSoLuongNhomFrom.Value = Convert.ToInt32(setting["nudSoLuongNhomFrom"]);
				nudSoLuongNhomTo.Value = Convert.ToInt32(setting["nudSoLuongNhomTo"]);
				nudSoLuongBaiVietFrom.Value = Convert.ToInt32(setting["nudSoLuongBaiVietFrom"]);
				nudSoLuongBaiVietTo.Value = Convert.ToInt32(setting["nudSoLuongBaiVietTo"]);
				nudDelayFrom.Value = Convert.ToInt32(setting["nudDelayFrom"]);
				nudDelayTo.Value = Convert.ToInt32(setting["nudDelayTo"]);
				ckbInteract.Checked = Convert.ToBoolean(setting["ckbInteract"]);
				ckbShareWall.Checked = Convert.ToBoolean(setting["ckbShareWall"]);
				ckbComment.Checked = Convert.ToBoolean(setting["ckbComment"]);
				txtComment.Text = setting["txtComment"]!.ToString();
				if (Convert.ToInt32(setting["typeNganCach"]) == 1)
				{
					rbNganCachKyTu.Checked = true;
				}
				else
				{
					rbNganCachMoiDong.Checked = true;
				}
				ckbSendAnh.Checked = Convert.ToBoolean(setting["ckbSendAnh"]);
				txtAnh.Text = setting["txtAnh"]!.ToString();
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
			if (type == 0)
			{
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?")) != DialogResult.Yes)
				{
					return;
				}
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
				if (ckbSendAnh.Checked && txtAnh.Text.Trim().Length == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng chọn folder ảnh!"), 3);
					return;
				}
				JSON_Settings jSON_Settings = new JSON_Settings();
				jSON_Settings.Update("nudSoLuongNhomFrom", nudSoLuongNhomFrom.Value);
				jSON_Settings.Update("nudSoLuongNhomTo", nudSoLuongNhomTo.Value);
				jSON_Settings.Update("nudSoLuongBaiVietFrom", nudSoLuongBaiVietFrom.Value);
				jSON_Settings.Update("nudSoLuongBaiVietTo", nudSoLuongBaiVietTo.Value);
				jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
				jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
				jSON_Settings.Update("ckbInteract", ckbInteract.Checked);
				jSON_Settings.Update("ckbShareWall", ckbShareWall.Checked);
				jSON_Settings.Update("ckbComment", ckbComment.Checked);
				jSON_Settings.Update("txtComment", txtComment.Text.Trim());
				int num = 0;
				if (rbNganCachKyTu.Checked)
				{
					num = 1;
				}
				jSON_Settings.Update("typeNganCach", num);
				jSON_Settings.Update("ckbSendAnh", ckbSendAnh.Checked);
				jSON_Settings.Update("txtAnh", txtAnh.Text.Trim());
				string fullString = jSON_Settings.GetFullString();
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
			else
			{
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?")) != DialogResult.Yes)
				{
					return;
				}
				string text2 = txtTenHanhDong.Text.Trim();
				if (text2 == "")
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!"), 3);
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
				if (ckbSendAnh.Checked && txtAnh.Text.Trim().Length == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng chọn folder ảnh!"), 3);
					return;
				}
				JSON_Settings jSON_Settings2 = new JSON_Settings();
				jSON_Settings2.Update("nudSoLuongNhomFrom", nudSoLuongNhomFrom.Value);
				jSON_Settings2.Update("nudSoLuongNhomTo", nudSoLuongNhomTo.Value);
				jSON_Settings2.Update("nudSoLuongBaiVietFrom", nudSoLuongBaiVietFrom.Value);
				jSON_Settings2.Update("nudSoLuongBaiVietTo", nudSoLuongBaiVietTo.Value);
				jSON_Settings2.Update("nudDelayFrom", nudDelayFrom.Value);
				jSON_Settings2.Update("nudDelayTo", nudDelayTo.Value);
				jSON_Settings2.Update("ckbInteract", ckbInteract.Checked);
				jSON_Settings2.Update("ckbShareWall", ckbShareWall.Checked);
				jSON_Settings2.Update("ckbComment", ckbComment.Checked);
				jSON_Settings2.Update("txtComment", txtComment.Text.Trim());
				int num2 = 0;
				if (rbNganCachKyTu.Checked)
				{
					num2 = 1;
				}
				jSON_Settings2.Update("typeNganCach", num2);
				jSON_Settings2.Update("ckbSendAnh", ckbSendAnh.Checked);
				jSON_Settings2.Update("txtAnh", txtAnh.Text.Trim());
				string fullString2 = jSON_Settings2.GetFullString();
				if (InteractSQL.UpdateHanhDong(Id_HanhDong, text2, fullString2))
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
			ckbSendAnh_CheckedChanged(null, null);
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
			plComment.Enabled = ckbComment.Checked;
		}

		private void rbNganCachMoiDong_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void rbNganCachKyTu_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			plComment.Height = 207;
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			plComment.Height = 163;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
			{
				btnUp.Visible = true;
				btnDown.Visible = true;
			}
		}

		private void ckbSendAnh_CheckedChanged(object sender, EventArgs e)
		{
			plAnh.Enabled = ckbSendAnh.Checked;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			txtAnh.Text = MCommon.Common.SelectFolder();
		}

		private void button3_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDBaiVietNhom));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			plAnh = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			txtAnh = new System.Windows.Forms.TextBox();
			ckbSendAnh = new System.Windows.Forms.CheckBox();
			plComment = new System.Windows.Forms.Panel();
			button3 = new System.Windows.Forms.Button();
			txtComment = new System.Windows.Forms.RichTextBox();
			btnDown = new MetroFramework.Controls.MetroButton();
			btnUp = new MetroFramework.Controls.MetroButton();
			rbNganCachKyTu = new System.Windows.Forms.RadioButton();
			rbNganCachMoiDong = new System.Windows.Forms.RadioButton();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			label49 = new System.Windows.Forms.Label();
			nudSoLuongNhomFrom = new System.Windows.Forms.NumericUpDown();
			label68 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			nudSoLuongNhomTo = new System.Windows.Forms.NumericUpDown();
			label66 = new System.Windows.Forms.Label();
			ckbComment = new System.Windows.Forms.CheckBox();
			ckbShareWall = new System.Windows.Forms.CheckBox();
			ckbInteract = new System.Windows.Forms.CheckBox();
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
			plAnh.SuspendLayout();
			plComment.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongNhomFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongNhomTo).BeginInit();
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
			bunifuCustomLabel1.Text = "Cấu hình Bài viết Nhóm";
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
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(plAnh);
			panel1.Controls.Add(ckbSendAnh);
			panel1.Controls.Add(plComment);
			panel1.Controls.Add(label49);
			panel1.Controls.Add(nudSoLuongNhomFrom);
			panel1.Controls.Add(label68);
			panel1.Controls.Add(label19);
			panel1.Controls.Add(nudSoLuongNhomTo);
			panel1.Controls.Add(label66);
			panel1.Controls.Add(ckbComment);
			panel1.Controls.Add(ckbShareWall);
			panel1.Controls.Add(ckbInteract);
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
			panel1.Size = new System.Drawing.Size(683, 308);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			plAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plAnh.Controls.Add(button2);
			plAnh.Controls.Add(txtAnh);
			plAnh.Enabled = false;
			plAnh.Location = new System.Drawing.Point(48, 217);
			plAnh.Name = "plAnh";
			plAnh.Size = new System.Drawing.Size(281, 31);
			plAnh.TabIndex = 164;
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.Location = new System.Drawing.Point(215, 2);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(61, 25);
			button2.TabIndex = 156;
			button2.Text = "Chọn";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			txtAnh.Location = new System.Drawing.Point(3, 3);
			txtAnh.Name = "txtAnh";
			txtAnh.Size = new System.Drawing.Size(206, 23);
			txtAnh.TabIndex = 155;
			ckbSendAnh.AutoSize = true;
			ckbSendAnh.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbSendAnh.Location = new System.Drawing.Point(30, 195);
			ckbSendAnh.Name = "ckbSendAnh";
			ckbSendAnh.Size = new System.Drawing.Size(104, 20);
			ckbSendAnh.TabIndex = 163;
			ckbSendAnh.Text = "Bình luận ảnh";
			ckbSendAnh.UseVisualStyleBackColor = true;
			ckbSendAnh.CheckedChanged += new System.EventHandler(ckbSendAnh_CheckedChanged);
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(button3);
			plComment.Controls.Add(txtComment);
			plComment.Controls.Add(btnDown);
			plComment.Controls.Add(btnUp);
			plComment.Controls.Add(rbNganCachKyTu);
			plComment.Controls.Add(rbNganCachMoiDong);
			plComment.Controls.Add(label9);
			plComment.Controls.Add(label8);
			plComment.Controls.Add(lblStatus);
			plComment.Location = new System.Drawing.Point(369, 84);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(281, 163);
			plComment.TabIndex = 106;
			button3.Cursor = System.Windows.Forms.Cursors.Help;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Location = new System.Drawing.Point(199, 2);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(23, 23);
			button3.TabIndex = 165;
			button3.Text = "?";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
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
			btnDown.Click += new System.EventHandler(btnDown_Click);
			btnUp.BackgroundImage = maxcare.Properties.Resources.icons8_collapse_arrow_24px;
			btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
			btnUp.Location = new System.Drawing.Point(255, -1);
			btnUp.Name = "btnUp";
			btnUp.Size = new System.Drawing.Size(25, 25);
			btnUp.TabIndex = 7;
			btnUp.UseSelectable = true;
			btnUp.Visible = false;
			btnUp.Click += new System.EventHandler(btnUp_Click);
			rbNganCachKyTu.AutoSize = true;
			rbNganCachKyTu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachKyTu.Location = new System.Drawing.Point(69, 182);
			rbNganCachKyTu.Name = "rbNganCachKyTu";
			rbNganCachKyTu.Size = new System.Drawing.Size(203, 20);
			rbNganCachKyTu.TabIndex = 6;
			rbNganCachKyTu.Text = "Các nội dung ngăn cách bởi \"|\"";
			rbNganCachKyTu.UseVisualStyleBackColor = true;
			rbNganCachKyTu.CheckedChanged += new System.EventHandler(rbNganCachKyTu_CheckedChanged);
			rbNganCachMoiDong.AutoSize = true;
			rbNganCachMoiDong.Checked = true;
			rbNganCachMoiDong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachMoiDong.Location = new System.Drawing.Point(69, 161);
			rbNganCachMoiDong.Name = "rbNganCachMoiDong";
			rbNganCachMoiDong.Size = new System.Drawing.Size(171, 20);
			rbNganCachMoiDong.TabIndex = 5;
			rbNganCachMoiDong.TabStop = true;
			rbNganCachMoiDong.Text = "Mỗi dòng là một nội dung";
			rbNganCachMoiDong.UseVisualStyleBackColor = true;
			rbNganCachMoiDong.CheckedChanged += new System.EventHandler(rbNganCachMoiDong_CheckedChanged);
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
			label49.AutoSize = true;
			label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label49.Location = new System.Drawing.Point(27, 81);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(100, 16);
			label49.TabIndex = 92;
			label49.Text = "Sô\u0301 lươ\u0323ng nhóm:";
			nudSoLuongNhomFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongNhomFrom.Location = new System.Drawing.Point(135, 79);
			nudSoLuongNhomFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongNhomFrom.Name = "nudSoLuongNhomFrom";
			nudSoLuongNhomFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongNhomFrom.TabIndex = 1;
			nudSoLuongNhomFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label68.AutoSize = true;
			label68.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label68.Location = new System.Drawing.Point(293, 81);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(40, 16);
			label68.TabIndex = 99;
			label68.Text = "nhóm";
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label19.Location = new System.Drawing.Point(27, 112);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(86, 16);
			label19.TabIndex = 101;
			label19.Text = "Sô\u0301 ba\u0300i/nhóm:";
			nudSoLuongNhomTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongNhomTo.Location = new System.Drawing.Point(232, 79);
			nudSoLuongNhomTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongNhomTo.Name = "nudSoLuongNhomTo";
			nudSoLuongNhomTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongNhomTo.TabIndex = 2;
			nudSoLuongNhomTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label66.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label66.Location = new System.Drawing.Point(197, 81);
			label66.Name = "label66";
			label66.Size = new System.Drawing.Size(29, 16);
			label66.TabIndex = 105;
			label66.Text = "đê\u0301n";
			label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbComment.AutoSize = true;
			ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbComment.Location = new System.Drawing.Point(369, 62);
			ckbComment.Name = "ckbComment";
			ckbComment.Size = new System.Drawing.Size(128, 20);
			ckbComment.TabIndex = 9;
			ckbComment.Text = "Bi\u0300nh luâ\u0323n văn bản";
			ckbComment.UseVisualStyleBackColor = true;
			ckbComment.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
			ckbShareWall.AutoSize = true;
			ckbShareWall.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbShareWall.Location = new System.Drawing.Point(135, 171);
			ckbShareWall.Name = "ckbShareWall";
			ckbShareWall.Size = new System.Drawing.Size(123, 20);
			ckbShareWall.TabIndex = 8;
			ckbShareWall.Text = "Chia sẻ về tường";
			ckbShareWall.UseVisualStyleBackColor = true;
			ckbInteract.AutoSize = true;
			ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbInteract.Location = new System.Drawing.Point(30, 171);
			ckbInteract.Name = "ckbInteract";
			ckbInteract.Size = new System.Drawing.Size(49, 20);
			ckbInteract.TabIndex = 7;
			ckbInteract.Text = "Like";
			ckbInteract.UseVisualStyleBackColor = true;
			nudDelayTo.Location = new System.Drawing.Point(232, 140);
			nudDelayTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 6;
			nudSoLuongBaiVietTo.Location = new System.Drawing.Point(232, 110);
			nudSoLuongBaiVietTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongBaiVietTo.Name = "nudSoLuongBaiVietTo";
			nudSoLuongBaiVietTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongBaiVietTo.TabIndex = 4;
			nudDelayFrom.Location = new System.Drawing.Point(135, 140);
			nudDelayFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 5;
			nudSoLuongBaiVietFrom.Location = new System.Drawing.Point(135, 110);
			nudSoLuongBaiVietFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongBaiVietFrom.Name = "nudSoLuongBaiVietFrom";
			nudSoLuongBaiVietFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongBaiVietFrom.TabIndex = 3;
			txtTenHanhDong.Location = new System.Drawing.Point(135, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(194, 23);
			txtTenHanhDong.TabIndex = 0;
			label7.Location = new System.Drawing.Point(197, 142);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 38;
			label7.Text = "đê\u0301n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label3.Location = new System.Drawing.Point(197, 112);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 16);
			label3.TabIndex = 37;
			label3.Text = "đê\u0301n";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(293, 142);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(31, 16);
			label6.TabIndex = 36;
			label6.Text = "giây";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(293, 112);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(25, 16);
			label4.TabIndex = 35;
			label4.Text = "ba\u0300i";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(27, 142);
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
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(351, 263);
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
			btnAdd.Location = new System.Drawing.Point(244, 263);
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
			base.ClientSize = new System.Drawing.Size(683, 308);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDBaiVietNhom";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plAnh.ResumeLayout(false);
			plAnh.PerformLayout();
			plComment.ResumeLayout(false);
			plComment.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongNhomFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongNhomTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiVietFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
