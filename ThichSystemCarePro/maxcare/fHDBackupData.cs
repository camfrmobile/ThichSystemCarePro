using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.KichBan;
using MCommon;

namespace maxcare
{
	public class fHDBackupData : Form
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

		private Panel plAnh;

		private CheckBox ckbAnhBanBe;

		private CheckBox ckbNgaySinh;

		private CheckBox ckbNhanTin;

		private NumericUpDown nudSoLuongAnh;

		private Label label10;

		private Label label7;

		private Label label3;

		private CheckBox ckbBinhLuan;

		private GroupBox groupBox1;

		private CheckBox ckbCreateHTML;

		private Panel plComment;

		private NumericUpDown nudSoThang;

		private Label label2;

		private Label label4;

		private Label label5;

		private CheckBox ckbBackupImageNangCao;

		private Button button2;

		public fHDBackupData(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			if (InteractSQL.GetTuongTac("", "HDBackupData").Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\", \"CauHinh\", \"MoTa\") VALUES ('HDBackupData', '{  \"ckbNgaySinh\": \"True\",  \"ckbAnhBanBe\": \"True\",  \"nudSoLuongAnh\": \"20\",  \"ckbNhanTin\": \"True\",  \"ckbBinhLuan\": \"True\",  \"ckbCreateHTML\": \"True\"}', 'Backup dữ liệu');");
			}
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDBackupData");
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
			Language.GetValue(groupBox1);
			Language.GetValue(ckbNgaySinh);
			Language.GetValue(ckbAnhBanBe);
			Language.GetValue(label7);
			Language.GetValue(label10);
			Language.GetValue(ckbBackupImageNangCao);
			Language.GetValue(button2);
			Language.GetValue(ckbNhanTin);
			Language.GetValue(ckbBinhLuan);
			Language.GetValue(label4);
			Language.GetValue(label2);
			Language.GetValue(ckbCreateHTML);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				ckbNgaySinh.Checked = setting.GetValueBool("ckbNgaySinh", valueDefault: true);
				ckbAnhBanBe.Checked = setting.GetValueBool("ckbAnhBanBe", valueDefault: true);
				ckbBackupImageNangCao.Checked = setting.GetValueBool("ckbBackupImageNangCao");
				nudSoLuongAnh.Value = setting.GetValueInt("nudSoLuongAnh", 20);
				nudSoThang.Value = setting.GetValueInt("nudSoThang", 5);
				ckbNhanTin.Checked = setting.GetValueBool("ckbNhanTin", valueDefault: true);
				ckbBinhLuan.Checked = setting.GetValueBool("ckbBinhLuan", valueDefault: true);
				ckbCreateHTML.Checked = setting.GetValueBool("ckbCreateHTML", valueDefault: true);
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
			if (!ckbNgaySinh.Checked && !ckbAnhBanBe.Checked && !ckbNhanTin.Checked && !ckbBinhLuan.Checked)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng chọn cấu hình backup!"), 3);
				return;
			}
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("ckbNgaySinh", ckbNgaySinh.Checked);
			jSON_Settings.Update("ckbAnhBanBe", ckbAnhBanBe.Checked);
			jSON_Settings.Update("ckbBackupImageNangCao", ckbBackupImageNangCao.Checked);
			jSON_Settings.Update("nudSoLuongAnh", nudSoLuongAnh.Value);
			jSON_Settings.Update("ckbNhanTin", ckbNhanTin.Checked);
			jSON_Settings.Update("ckbBinhLuan", ckbBinhLuan.Checked);
			jSON_Settings.Update("nudSoThang", nudSoThang.Value);
			jSON_Settings.Update("ckbCreateHTML", ckbCreateHTML.Checked);
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

		private void CheckedChangeFull()
		{
			ckbInteract_CheckedChanged(null, null);
			ckbComment_CheckedChanged(null, null);
			ckbBinhLuan_CheckedChanged(null, null);
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
			plAnh.Enabled = ckbAnhBanBe.Checked;
		}

		private void ckbBinhLuan_CheckedChanged(object sender, EventArgs e)
		{
			plComment.Enabled = ckbBinhLuan.Checked;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Nếu tích tùy chọn này thì sẽ backup được nhiều ảnh bạn bè hơn.") + "\r\n" + Language.GetValue("Đồng nghĩa với việc tốc độ backup sẽ chậm hơn!"));
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDBackupData));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			groupBox1 = new System.Windows.Forms.GroupBox();
			ckbNgaySinh = new System.Windows.Forms.CheckBox();
			ckbNhanTin = new System.Windows.Forms.CheckBox();
			plComment = new System.Windows.Forms.Panel();
			nudSoThang = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			plAnh = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			ckbBackupImageNangCao = new System.Windows.Forms.CheckBox();
			nudSoLuongAnh = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			ckbBinhLuan = new System.Windows.Forms.CheckBox();
			ckbAnhBanBe = new System.Windows.Forms.CheckBox();
			ckbCreateHTML = new System.Windows.Forms.CheckBox();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			groupBox1.SuspendLayout();
			plComment.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoThang).BeginInit();
			plAnh.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongAnh).BeginInit();
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
			bunifuCustomLabel1.Text = "Cấu hình Backup dữ liệu";
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
			button1.TabIndex = 0;
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
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(ckbCreateHTML);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(362, 373);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			groupBox1.Controls.Add(ckbNgaySinh);
			groupBox1.Controls.Add(ckbNhanTin);
			groupBox1.Controls.Add(plComment);
			groupBox1.Controls.Add(plAnh);
			groupBox1.Controls.Add(ckbBinhLuan);
			groupBox1.Controls.Add(ckbAnhBanBe);
			groupBox1.Location = new System.Drawing.Point(30, 82);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(295, 205);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Cấu hình backup";
			ckbNgaySinh.AutoSize = true;
			ckbNgaySinh.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbNgaySinh.Location = new System.Drawing.Point(12, 20);
			ckbNgaySinh.Name = "ckbNgaySinh";
			ckbNgaySinh.Size = new System.Drawing.Size(82, 20);
			ckbNgaySinh.TabIndex = 0;
			ckbNgaySinh.Text = "Ngày sinh";
			ckbNgaySinh.UseVisualStyleBackColor = true;
			ckbNhanTin.AutoSize = true;
			ckbNhanTin.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbNhanTin.Location = new System.Drawing.Point(12, 122);
			ckbNhanTin.Name = "ckbNhanTin";
			ckbNhanTin.Size = new System.Drawing.Size(185, 20);
			ckbNhanTin.TabIndex = 2;
			ckbNhanTin.Text = "Danh sách nhắn tin gần đây";
			ckbNhanTin.UseVisualStyleBackColor = true;
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(nudSoThang);
			plComment.Controls.Add(label2);
			plComment.Controls.Add(label4);
			plComment.Controls.Add(label5);
			plComment.Location = new System.Drawing.Point(30, 169);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(221, 27);
			plComment.TabIndex = 8;
			nudSoThang.Location = new System.Drawing.Point(119, 1);
			nudSoThang.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nudSoThang.Name = "nudSoThang";
			nudSoThang.Size = new System.Drawing.Size(52, 23);
			nudSoThang.TabIndex = 0;
			nudSoThang.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label2.Location = new System.Drawing.Point(172, 3);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(40, 16);
			label2.TabIndex = 151;
			label2.Text = "tháng";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label4.Location = new System.Drawing.Point(2, 3);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(100, 16);
			label4.TabIndex = 152;
			label4.Text = "Số lượng tháng:";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(3, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(0, 16);
			label5.TabIndex = 31;
			plAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plAnh.Controls.Add(button2);
			plAnh.Controls.Add(ckbBackupImageNangCao);
			plAnh.Controls.Add(nudSoLuongAnh);
			plAnh.Controls.Add(label10);
			plAnh.Controls.Add(label7);
			plAnh.Controls.Add(label3);
			plAnh.Location = new System.Drawing.Point(30, 69);
			plAnh.Name = "plAnh";
			plAnh.Size = new System.Drawing.Size(221, 50);
			plAnh.TabIndex = 8;
			button2.Cursor = System.Windows.Forms.Cursors.Help;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(154, 25);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(23, 23);
			button2.TabIndex = 153;
			button2.Text = "?";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			ckbBackupImageNangCao.AutoSize = true;
			ckbBackupImageNangCao.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbBackupImageNangCao.Location = new System.Drawing.Point(5, 26);
			ckbBackupImageNangCao.Name = "ckbBackupImageNangCao";
			ckbBackupImageNangCao.Size = new System.Drawing.Size(148, 20);
			ckbBackupImageNangCao.TabIndex = 0;
			ckbBackupImageNangCao.Text = "Backup ảnh nâng cao";
			ckbBackupImageNangCao.UseVisualStyleBackColor = true;
			nudSoLuongAnh.Location = new System.Drawing.Point(119, 1);
			nudSoLuongAnh.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nudSoLuongAnh.Name = "nudSoLuongAnh";
			nudSoLuongAnh.Size = new System.Drawing.Size(52, 23);
			nudSoLuongAnh.TabIndex = 0;
			nudSoLuongAnh.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label10.Location = new System.Drawing.Point(173, 3);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(29, 16);
			label10.TabIndex = 151;
			label10.Text = "a\u0309nh";
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label7.Location = new System.Drawing.Point(2, 3);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(115, 16);
			label7.TabIndex = 152;
			label7.Text = "Số lươ\u0323ng a\u0309nh/ba\u0323n:";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(3, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(0, 16);
			label3.TabIndex = 31;
			ckbBinhLuan.AutoSize = true;
			ckbBinhLuan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbBinhLuan.Location = new System.Drawing.Point(12, 148);
			ckbBinhLuan.Name = "ckbBinhLuan";
			ckbBinhLuan.Size = new System.Drawing.Size(142, 20);
			ckbBinhLuan.TabIndex = 3;
			ckbBinhLuan.Text = "Danh sách bình luận";
			ckbBinhLuan.UseVisualStyleBackColor = true;
			ckbBinhLuan.CheckedChanged += new System.EventHandler(ckbBinhLuan_CheckedChanged);
			ckbAnhBanBe.AutoSize = true;
			ckbAnhBanBe.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbAnhBanBe.Location = new System.Drawing.Point(12, 46);
			ckbAnhBanBe.Name = "ckbAnhBanBe";
			ckbAnhBanBe.Size = new System.Drawing.Size(92, 20);
			ckbAnhBanBe.TabIndex = 1;
			ckbAnhBanBe.Text = "Ảnh bạn bè";
			ckbAnhBanBe.UseVisualStyleBackColor = true;
			ckbAnhBanBe.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
			ckbCreateHTML.AutoSize = true;
			ckbCreateHTML.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbCreateHTML.Location = new System.Drawing.Point(30, 293);
			ckbCreateHTML.Name = "ckbCreateHTML";
			ckbCreateHTML.Size = new System.Drawing.Size(267, 20);
			ckbCreateHTML.TabIndex = 2;
			ckbCreateHTML.Text = "Tự động tạo luôn File Html sau khi backup";
			ckbCreateHTML.UseVisualStyleBackColor = true;
			txtTenHanhDong.Location = new System.Drawing.Point(132, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(193, 23);
			txtTenHanhDong.TabIndex = 0;
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
			btnCancel.Location = new System.Drawing.Point(189, 327);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
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
			btnAdd.Location = new System.Drawing.Point(82, 327);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
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
			base.ClientSize = new System.Drawing.Size(362, 373);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDBackupData";
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
			((System.ComponentModel.ISupportInitialize)nudSoThang).EndInit();
			plAnh.ResumeLayout(false);
			plAnh.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongAnh).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
