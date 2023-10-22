using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.Properties;
using MCommon;

namespace maxcare
{
	public class fNhapDuLieu2 : Form
	{
		private string linkPathFolder = "";

		private Random rd = new Random();

		private bool isAdd = false;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel panel1;

		private BunifuDragControl bunifuDragControl1;

		private ToolTip toolTip1;

		private BunifuCards bunifuCards2;

		private Panel pnlHeader;

		private Button button2;

		private PictureBox pictureBox1;

		private Button btnMinimize;

		private BunifuCustomLabel lblTitle;

		private Button btnSave;

		private TextBox txtContent;

		private GroupBox groupBox1;

		private GroupBox groupBox2;

		public DataGridView dtgvDanhSach;

		private Button btnAdd;

		private DataGridViewTextBoxColumn cSTT;

		private DataGridViewTextBoxColumn cName;

		private DataGridViewButtonColumn cChiTiet;

		private DataGridViewButtonColumn cSua;

		private DataGridViewButtonColumn cXoa;

		private Button btnHuy;

		public fNhapDuLieu2(string linkPathFolder, string title)
		{
			InitializeComponent();
			ChangeLanguage();
			this.linkPathFolder = linkPathFolder;
			lblTitle.Text = title;
		}

		private void ChangeLanguage()
		{
			Language.GetValue(lblTitle);
			Language.GetValue(groupBox1);
			Language.GetValue(groupBox2);
			foreach (DataGridViewColumn column in dtgvDanhSach.Columns)
			{
				Language.GetValue(column);
			}
			Language.GetValue(btnAdd);
			Language.GetValue(btnSave);
			Language.GetValue(btnHuy);
		}

		private void FConfigGenneral_Load(object sender, EventArgs e)
		{
			MCommon.Common.CreateFolder(linkPathFolder);
			LoadDsFile(linkPathFolder);
		}

		private void LoadContentFileFromDtgv(int row)
		{
			txtContent.Lines = File.ReadAllLines(DatagridviewHelper.GetStatusDataGridView(dtgvDanhSach, row, "cName"));
		}

		private void LoadDsFile(string linkPathFolder)
		{
			int num = -1;
			switch (dtgvDanhSach.RowCount)
			{
			default:
				num = dtgvDanhSach.SelectedRows[0].Index;
				break;
			case 1:
				num = 0;
				break;
			case 0:
				break;
			}
			dtgvDanhSach.Rows.Clear();
			List<string> list = Directory.GetFiles(linkPathFolder).ToList();
			for (int i = 0; i < list.Count; i++)
			{
				dtgvDanhSach.Rows.Add(i + 1, list[i], Language.GetValue("Chi tiê\u0301t"), Language.GetValue("Sư\u0309a"), Language.GetValue("Xo\u0301a"));
			}
			if (num == -1 && dtgvDanhSach.RowCount > 0)
			{
				num = 0;
			}
			else if (num + 1 > dtgvDanhSach.RowCount)
			{
				num = dtgvDanhSach.RowCount - 1;
			}
			if (num == -1)
			{
				txtContent.Text = "";
				return;
			}
			MCommon.Common.ClearSelectedOnDatagridview(dtgvDanhSach);
			dtgvDanhSach.Rows[num].Selected = true;
			LoadContentFileFromDtgv(num);
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void rControl(int type)
		{
			if (type == 1)
			{
				dtgvDanhSach.Enabled = false;
				btnAdd.Enabled = false;
				btnSave.Enabled = true;
				btnHuy.Enabled = true;
				txtContent.ReadOnly = false;
				txtContent.Focus();
			}
			else
			{
				dtgvDanhSach.Enabled = true;
				btnAdd.Enabled = true;
				btnSave.Enabled = false;
				btnHuy.Enabled = false;
				txtContent.ReadOnly = true;
			}
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				string text = "";
				string text2;
				do
				{
					text2 = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_") + MCommon.Common.CreateRandomString(3, rd) + ".txt";
				}
				while (File.Exists(text2));
				text = linkPathFolder + "\\" + text2;
				MCommon.Common.CreateFile(text);
				txtContent.Lines = File.ReadAllLines(text);
				dtgvDanhSach.Rows.Add(dtgvDanhSach.RowCount + 1, text, Language.GetValue("Chi tiê\u0301t"), Language.GetValue("Sư\u0309a"), Language.GetValue("Xo\u0301a"));
				MCommon.Common.ClearSelectedOnDatagridview(dtgvDanhSach);
				dtgvDanhSach.Rows[dtgvDanhSach.RowCount - 1].Selected = true;
				rControl(1);
				isAdd = true;
			}
			catch
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đã có lỗi xảy ra, vui lòng thử lại sau!"), 2);
			}
		}

		private void TxtComment_TextChanged(object sender, EventArgs e)
		{
		}

		private void dtgvDanhSach_MouseHover(object sender, EventArgs e)
		{
		}

		private void dtgvDanhSach_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			string name = dtgvDanhSach.Columns[e.ColumnIndex].Name;
			if (name != "cChiTiet" && name != "cSua" && name != "cXoa")
			{
				dtgvDanhSach.Cursor = Cursors.Default;
			}
			else if (e.RowIndex < dtgvDanhSach.RowCount)
			{
				dtgvDanhSach.Cursor = Cursors.Hand;
			}
		}

		private void dtgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			if (!(dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0)
			{
				return;
			}
			switch (dataGridView.Columns[e.ColumnIndex].Name)
			{
			case "cXoa":
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Bạn có muốn xóa?")) == DialogResult.Yes)
				{
					File.Delete(DatagridviewHelper.GetStatusDataGridView(dtgvDanhSach, e.RowIndex, "cName"));
					LoadDsFile(linkPathFolder);
				}
				break;
			case "cSua":
				txtContent.Lines = File.ReadAllLines(DatagridviewHelper.GetStatusDataGridView(dtgvDanhSach, e.RowIndex, "cName"));
				isAdd = false;
				rControl(1);
				break;
			case "cChiTiet":
				LoadContentFileFromDtgv(e.RowIndex);
				break;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				string text = dtgvDanhSach.SelectedRows[0].Cells["cName"].Value.ToString();
				MCommon.Common.CreateFile(text);
				if (txtContent.Text.Trim() == "")
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhập nội dung cần lưu!"), 3);
				}
				else if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Bạn có muốn lưu lại?")) == DialogResult.Yes)
				{
					File.WriteAllLines(text, txtContent.Lines);
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Lưu thành công!"));
					rControl(2);
				}
			}
			catch
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đã có lỗi xảy ra, vui lòng thử lại sau!"), 2);
			}
		}

		private void btnHuy_Click(object sender, EventArgs e)
		{
			try
			{
				string text = dtgvDanhSach.SelectedRows[0].Cells["cName"].Value.ToString();
				MCommon.Common.CreateFile(text);
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Bạn có muốn hủy?")) == DialogResult.Yes)
				{
					if (isAdd)
					{
						File.Delete(text);
					}
					rControl(2);
					LoadDsFile(linkPathFolder);
				}
			}
			catch
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đã có lỗi xảy ra, vui lòng thử lại sau!"), 2);
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			panel1 = new System.Windows.Forms.Panel();
			groupBox1 = new System.Windows.Forms.GroupBox();
			dtgvDanhSach = new System.Windows.Forms.DataGridView();
			cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cChiTiet = new System.Windows.Forms.DataGridViewButtonColumn();
			cSua = new System.Windows.Forms.DataGridViewButtonColumn();
			cXoa = new System.Windows.Forms.DataGridViewButtonColumn();
			btnAdd = new System.Windows.Forms.Button();
			groupBox2 = new System.Windows.Forms.GroupBox();
			txtContent = new System.Windows.Forms.TextBox();
			btnSave = new System.Windows.Forms.Button();
			bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			btnHuy = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dtgvDanhSach).BeginInit();
			groupBox2.SuspendLayout();
			bunifuCards2.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 5;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.SaddleBrown;
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(0, 0);
			bunifuCards1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(425, 47);
			bunifuCards1.TabIndex = 12;
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(groupBox2);
			panel1.Controls.Add(bunifuCards2);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(754, 388);
			panel1.TabIndex = 37;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			groupBox1.Controls.Add(dtgvDanhSach);
			groupBox1.Controls.Add(btnAdd);
			groupBox1.Location = new System.Drawing.Point(3, 43);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(284, 339);
			groupBox1.TabIndex = 50;
			groupBox1.TabStop = false;
			groupBox1.Text = " Danh sa\u0301ch nô\u0323i dung";
			dtgvDanhSach.AllowUserToAddRows = false;
			dtgvDanhSach.AllowUserToDeleteRows = false;
			dtgvDanhSach.AllowUserToResizeRows = false;
			dtgvDanhSach.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dtgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dtgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dtgvDanhSach.Columns.AddRange(cSTT, cName, cChiTiet, cSua, cXoa);
			dtgvDanhSach.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			dtgvDanhSach.Location = new System.Drawing.Point(6, 22);
			dtgvDanhSach.Name = "dtgvDanhSach";
			dtgvDanhSach.RowHeadersVisible = false;
			dtgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dtgvDanhSach.Size = new System.Drawing.Size(272, 277);
			dtgvDanhSach.TabIndex = 76;
			dtgvDanhSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvDanhSach_CellContentClick);
			dtgvDanhSach.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvDanhSach_CellMouseEnter);
			dtgvDanhSach.MouseHover += new System.EventHandler(dtgvDanhSach_MouseHover);
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			cSTT.DefaultCellStyle = dataGridViewCellStyle2;
			cSTT.HeaderText = "STT";
			cSTT.Name = "cSTT";
			cSTT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cSTT.Width = 40;
			cName.HeaderText = "Tên file";
			cName.Name = "cName";
			cName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cName.Visible = false;
			cChiTiet.HeaderText = "Chi tiê\u0301t";
			cChiTiet.Name = "cChiTiet";
			cChiTiet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			cChiTiet.Width = 80;
			cSua.HeaderText = "Sư\u0309a";
			cSua.Name = "cSua";
			cSua.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			cSua.Width = 71;
			cXoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			cXoa.HeaderText = "Xo\u0301a";
			cXoa.Name = "cXoa";
			cXoa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			btnAdd.BackColor = System.Drawing.Color.Green;
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(186, 303);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 45;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			groupBox2.Controls.Add(txtContent);
			groupBox2.Controls.Add(btnHuy);
			groupBox2.Controls.Add(btnSave);
			groupBox2.Location = new System.Drawing.Point(293, 43);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(455, 339);
			groupBox2.TabIndex = 50;
			groupBox2.TabStop = false;
			groupBox2.Text = "Chi tiê\u0301t";
			txtContent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtContent.Location = new System.Drawing.Point(5, 22);
			txtContent.Multiline = true;
			txtContent.Name = "txtContent";
			txtContent.ReadOnly = true;
			txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtContent.Size = new System.Drawing.Size(444, 277);
			txtContent.TabIndex = 48;
			txtContent.WordWrap = false;
			txtContent.TextChanged += new System.EventHandler(TxtComment_TextChanged);
			btnSave.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			btnSave.Enabled = false;
			btnSave.FlatAppearance.BorderSize = 0;
			btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnSave.ForeColor = System.Drawing.Color.White;
			btnSave.Location = new System.Drawing.Point(256, 304);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(92, 29);
			btnSave.TabIndex = 45;
			btnSave.Text = "Lưu";
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += new System.EventHandler(btnSave_Click);
			bunifuCards2.BackColor = System.Drawing.Color.White;
			bunifuCards2.BorderRadius = 0;
			bunifuCards2.BottomSahddow = true;
			bunifuCards2.color = System.Drawing.Color.SaddleBrown;
			bunifuCards2.Controls.Add(pnlHeader);
			bunifuCards2.Dock = System.Windows.Forms.DockStyle.Top;
			bunifuCards2.LeftSahddow = false;
			bunifuCards2.Location = new System.Drawing.Point(0, 0);
			bunifuCards2.Name = "bunifuCards2";
			bunifuCards2.RightSahddow = true;
			bunifuCards2.ShadowDepth = 20;
			bunifuCards2.Size = new System.Drawing.Size(752, 37);
			bunifuCards2.TabIndex = 43;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(button2);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(lblTitle);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(752, 31);
			pnlHeader.TabIndex = 9;
			button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Image = maxcare.Properties.Resources.btnMinimize_Image;
			button2.Location = new System.Drawing.Point(721, 1);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(30, 30);
			button2.TabIndex = 77;
			button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = maxcare.Properties.Resources.icon_64;
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 76;
			pictureBox1.TabStop = false;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Location = new System.Drawing.Point(899, 1);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(30, 30);
			btnMinimize.TabIndex = 9;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			lblTitle.BackColor = System.Drawing.Color.Transparent;
			lblTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
			lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			lblTitle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblTitle.ForeColor = System.Drawing.Color.Black;
			lblTitle.Location = new System.Drawing.Point(0, 0);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new System.Drawing.Size(752, 31);
			lblTitle.TabIndex = 12;
			lblTitle.Text = "Nhập nội dung comment";
			lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = lblTitle;
			bunifuDragControl1.Vertical = true;
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 10000;
			toolTip1.InitialDelay = 200;
			toolTip1.ReshowDelay = 40;
			btnHuy.BackColor = System.Drawing.Color.FromArgb(128, 64, 0);
			btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
			btnHuy.Enabled = false;
			btnHuy.FlatAppearance.BorderSize = 0;
			btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnHuy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnHuy.ForeColor = System.Drawing.Color.White;
			btnHuy.Location = new System.Drawing.Point(357, 304);
			btnHuy.Name = "btnHuy";
			btnHuy.Size = new System.Drawing.Size(92, 29);
			btnHuy.TabIndex = 45;
			btnHuy.Text = "Hủy";
			btnHuy.UseVisualStyleBackColor = false;
			btnHuy.Click += new System.EventHandler(btnHuy_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(754, 388);
			base.Controls.Add(panel1);
			base.Controls.Add(bunifuCards1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fNhapDuLieu2";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình chung";
			base.Load += new System.EventHandler(FConfigGenneral_Load);
			panel1.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dtgvDanhSach).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			bunifuCards2.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
