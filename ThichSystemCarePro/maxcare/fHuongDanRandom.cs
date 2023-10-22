using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Properties;

namespace maxcare
{
	public class fHuongDanRandom : Form
	{
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

		private BunifuCustomLabel bunifuCustomLabel1;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem thêmMớiToolStripMenuItem;

		private ToolStripMenuItem sửaToolStripMenuItem;

		private ToolStripMenuItem xóaToolStripMenuItem;

		private DataGridView dgv;

		private DataGridViewTextBoxColumn cSTT;

		private DataGridViewTextBoxColumn cTuKhoa;

		private DataGridViewImageColumn cNoiDung;

		public fHuongDanRandom()
		{
			InitializeComponent();
			ChangeLanguage();
			LoadDgv();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			foreach (DataGridViewColumn column in dgv.Columns)
			{
				Language.GetValue(column);
			}
		}

		private void LoadDgv()
		{
			new Random();
			dgv.Rows.Add(dgv.RowCount + 1, "[r1]", Resources.icon11);
			dgv.Rows.Add(dgv.RowCount + 1, "[r2]", Resources.icon12);
			dgv.Rows.Add(dgv.RowCount + 1, "[r3]", Resources.icon13);
			dgv.Rows.Add(dgv.RowCount + 1, "[r4]", Resources.icon14);
			dgv.Rows.Add(dgv.RowCount + 1, "[r5]", Resources.icon15);
			dgv.Rows.Add(dgv.RowCount + 1, "[r6]", Resources.icon16);
			dgv.Rows.Add(dgv.RowCount + 1, "[r7]", Resources.icon17);
			dgv.Rows.Add(dgv.RowCount + 1, "[r8]", Resources.icon18);
			dgv.Rows.Add(dgv.RowCount + 1, "[d]", Resources.icon19);
			dgv.Rows.Add(dgv.RowCount + 1, "[t]", Resources.icon20);
			dgv.Rows.Add(dgv.RowCount + 1, "[n*]", Resources.icon21);
			dgv.Rows.Add(dgv.RowCount + 1, "[s*]", Resources.icon22);
			dgv.Rows.Add(dgv.RowCount + 1, "[q***]", Resources.icon23);
		}

		private void FConfigGenneral_Load(object sender, EventArgs e)
		{
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
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
			dgv = new System.Windows.Forms.DataGridView();
			cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cTuKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cNoiDung = new System.Windows.Forms.DataGridViewImageColumn();
			bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			thêmMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
			bunifuCards2.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			contextMenuStrip1.SuspendLayout();
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
			bunifuCards1.Size = new System.Drawing.Size(243, 47);
			bunifuCards1.TabIndex = 12;
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(dgv);
			panel1.Controls.Add(bunifuCards2);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(572, 503);
			panel1.TabIndex = 37;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			dgv.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Columns.AddRange(cSTT, cTuKhoa, cNoiDung);
			dgv.Location = new System.Drawing.Point(11, 43);
			dgv.Name = "dgv";
			dgv.ReadOnly = true;
			dgv.RowHeadersVisible = false;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
			dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dgv.Size = new System.Drawing.Size(547, 447);
			dgv.TabIndex = 75;
			cSTT.HeaderText = "STT";
			cSTT.Name = "cSTT";
			cSTT.ReadOnly = true;
			cSTT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cSTT.Width = 40;
			cTuKhoa.HeaderText = "Từ khóa";
			cTuKhoa.Name = "cTuKhoa";
			cTuKhoa.ReadOnly = true;
			cTuKhoa.Width = 80;
			cNoiDung.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			cNoiDung.HeaderText = "Nội dung random";
			cNoiDung.Name = "cNoiDung";
			cNoiDung.ReadOnly = true;
			cNoiDung.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			cNoiDung.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
			bunifuCards2.Size = new System.Drawing.Size(570, 37);
			bunifuCards2.TabIndex = 43;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(button2);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(570, 31);
			pnlHeader.TabIndex = 9;
			button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Image = maxcare.Properties.Resources.btnMinimize_Image;
			button2.Location = new System.Drawing.Point(539, 1);
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
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(570, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Hướng dẫn random nội dung";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { thêmMớiToolStripMenuItem, sửaToolStripMenuItem, xóaToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
			thêmMớiToolStripMenuItem.Name = "thêmMớiToolStripMenuItem";
			thêmMớiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			thêmMớiToolStripMenuItem.Text = "Thêm chủ đề";
			sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
			sửaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			sửaToolStripMenuItem.Text = "Sửa tên chủ đề";
			xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
			xóaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			xóaToolStripMenuItem.Text = "Xóa chủ đề";
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 10000;
			toolTip1.InitialDelay = 200;
			toolTip1.ReshowDelay = 40;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(572, 503);
			base.Controls.Add(panel1);
			base.Controls.Add(bunifuCards1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHuongDanRandom";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Cấu hình chung";
			base.Load += new System.EventHandler(FConfigGenneral_Load);
			panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgv).EndInit();
			bunifuCards2.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
