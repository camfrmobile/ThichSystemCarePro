using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.KichBan;
using maxcare.Properties;
using MCommon;

namespace maxcare
{
	public class fChonKichBan : Form
	{
		private JSON_Settings settings;

		private IContainer components = null;

		private ToolTip toolTip1;

		private BunifuDragControl bunifuDragControl1;

		private BunifuDragControl bunifuDragControl2;

		private GroupBox groupBox1;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button button1;

		public DataGridView dtgvKichBan;

		private Panel panel1;

		private Button button2;

		private Button button3;

		private GroupBox groupBox2;

		private Label label2;

		private Button btnCancel;

		private Button btnSave;

		private Label lblCountAcc;

		private Label label7;

		private Label label1;

		public DataGridView dtgvKichBanChoose;

		private DataGridViewTextBoxColumn cStt;

		private DataGridViewTextBoxColumn cIdKichBan;

		private DataGridViewTextBoxColumn cTenKichBan;

		private DataGridViewTextBoxColumn cSTTChoose;

		private DataGridViewTextBoxColumn cIdKichBanChoose;

		private DataGridViewTextBoxColumn cTenKichBanChoose;

		public fChonKichBan()
		{
			InitializeComponent();
			settings = new JSON_Settings("configInteractGeneral");
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(groupBox1);
			Language.GetValue(label2);
			Language.GetValue(groupBox2);
			Language.GetValue(label1);
			Language.GetValue(label7);
			Language.GetValue(btnSave);
			Language.GetValue(btnCancel);
			foreach (DataGridViewColumn column in dtgvKichBan.Columns)
			{
				Language.GetValue(column);
			}
			foreach (DataGridViewColumn column2 in dtgvKichBanChoose.Columns)
			{
				Language.GetValue(column2);
			}
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			LoadKichBan();
			LoadKichBan(settings.GetValueList("lstIdKichBan"));
		}

		private void LoadKichBan(List<string> lstIdKichBan = null)
		{
			try
			{
				if (lstIdKichBan != null && lstIdKichBan.Count > 0)
				{
					dtgvKichBanChoose.Rows.Clear();
					for (int i = 0; i < lstIdKichBan.Count; i++)
					{
						DataTable kichBanById = InteractSQL.GetKichBanById(lstIdKichBan[i]);
						if (kichBanById.Rows.Count > 0)
						{
							DataRow dataRow = kichBanById.Rows[0];
							dtgvKichBanChoose.Rows.Add(dtgvKichBanChoose.RowCount + 1, dataRow["Id_KichBan"], dataRow["TenKichBan"]);
						}
					}
					return;
				}
				dtgvKichBan.Rows.Clear();
				DataTable allKichBan = InteractSQL.GetAllKichBan();
				if (allKichBan.Rows.Count > 0)
				{
					for (int j = 0; j < allKichBan.Rows.Count; j++)
					{
						DataRow dataRow2 = allKichBan.Rows[j];
						dtgvKichBan.Rows.Add(j + 1, dataRow2["Id_KichBan"], dataRow2["TenKichBan"]);
					}
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		public void DoiChoDgv(ref DataGridView dgv, int oldRow, int newRow)
		{
			string text = "";
			for (int i = 1; i < dgv.Columns.Count; i++)
			{
				text = DatagridviewHelper.GetStatusDataGridView(dgv, oldRow, i);
				DatagridviewHelper.SetStatusDataGridView(dgv, oldRow, i, DatagridviewHelper.GetStatusDataGridView(dgv, newRow, i));
				DatagridviewHelper.SetStatusDataGridView(dgv, newRow, i, text);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int index = dtgvKichBanChoose.SelectedRows[0].Index;
			if (index != 0)
			{
				string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvKichBanChoose, index - 1, "cIdKichBanChoose");
				string statusDataGridView2 = DatagridviewHelper.GetStatusDataGridView(dtgvKichBanChoose, index, "cIdKichBanChoose");
				if (statusDataGridView + statusDataGridView2 != "")
				{
					DoiChoDgv(ref dtgvKichBanChoose, index, index - 1);
					dtgvKichBanChoose.Rows[index - 1].Selected = true;
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			int index = dtgvKichBanChoose.SelectedRows[0].Index;
			if (index != dtgvKichBanChoose.RowCount - 1)
			{
				string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvKichBanChoose, index + 1, "cIdKichBanChoose");
				string statusDataGridView2 = DatagridviewHelper.GetStatusDataGridView(dtgvKichBanChoose, index, "cIdKichBanChoose");
				if (statusDataGridView + statusDataGridView2 != "")
				{
					DoiChoDgv(ref dtgvKichBanChoose, index, index + 1);
					dtgvKichBanChoose.Rows[index + 1].Selected = true;
				}
			}
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

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private bool CheckTrung(string id)
		{
			bool result = false;
			for (int i = 0; i < dtgvKichBanChoose.RowCount; i++)
			{
				if (id == dtgvKichBanChoose.Rows[i].Cells[1].Value.ToString())
				{
					result = true;
					break;
				}
			}
			return result;
		}

		private void dtgvKichBan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int num = Convert.ToInt32(dtgvKichBan.SelectedRows[0].Cells[1].Value);
			string text = dtgvKichBan.SelectedRows[0].Cells[2].Value.ToString();
			if (!CheckTrung(num.ToString()))
			{
				dtgvKichBanChoose.Rows.Add(dtgvKichBanChoose.RowCount + 1, num, text);
			}
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			dtgvKichBanChoose.Rows.RemoveAt(dtgvKichBanChoose.SelectedRows[0].Index);
			for (int i = 0; i < dtgvKichBanChoose.RowCount; i++)
			{
				DatagridviewHelper.SetStatusDataGridView(dtgvKichBanChoose, i, "cSTTChoose", i + 1);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				List<string> list = new List<string>();
				for (int i = 0; i < dtgvKichBanChoose.RowCount; i++)
				{
					list.Add(DatagridviewHelper.GetStatusDataGridView(dtgvKichBanChoose, i, "cIdKichBanChoose"));
				}
				settings.Update("lstIdKichBan", list);
				settings.Save();
				Close();
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đã có lỗi xảy ra, vui lòng thử lại sau!"), 3);
			}
		}

		private void dtgvKichBanChoose_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			lblCountAcc.Text = dtgvKichBanChoose.RowCount.ToString();
		}

		private void dtgvKichBanChoose_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			lblCountAcc.Text = dtgvKichBanChoose.RowCount.ToString();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fChonKichBan));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label2 = new System.Windows.Forms.Label();
			dtgvKichBan = new System.Windows.Forms.DataGridView();
			cStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cIdKichBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cTenKichBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			panel1 = new System.Windows.Forms.Panel();
			btnCancel = new System.Windows.Forms.Button();
			btnSave = new System.Windows.Forms.Button();
			groupBox2 = new System.Windows.Forms.GroupBox();
			lblCountAcc = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			dtgvKichBanChoose = new System.Windows.Forms.DataGridView();
			cSTTChoose = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cIdKichBanChoose = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cTenKichBanChoose = new System.Windows.Forms.DataGridViewTextBoxColumn();
			button2 = new System.Windows.Forms.Button();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dtgvKichBan).BeginInit();
			bunifuCards1.SuspendLayout();
			panel1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dtgvKichBanChoose).BeginInit();
			SuspendLayout();
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 10000;
			toolTip1.InitialDelay = 200;
			toolTip1.ReshowDelay = 40;
			toolTip1.ToolTipTitle = "Chú thích";
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(696, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Chọn danh sách kịch bản chạy";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = pnlHeader;
			bunifuDragControl2.Vertical = true;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(button1);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(696, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(667, 2);
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
			groupBox1.BackColor = System.Drawing.Color.White;
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(dtgvKichBan);
			groupBox1.Location = new System.Drawing.Point(12, 41);
			groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox1.Size = new System.Drawing.Size(308, 302);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Danh sách kịch bản";
			label2.AutoSize = true;
			label2.ForeColor = System.Drawing.Color.Red;
			label2.Location = new System.Drawing.Point(3, 281);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(193, 16);
			label2.TabIndex = 81;
			label2.Text = "(Click đúp vào kịch bản để chọn)";
			dtgvKichBan.AllowUserToAddRows = false;
			dtgvKichBan.AllowUserToDeleteRows = false;
			dtgvKichBan.AllowUserToResizeRows = false;
			dtgvKichBan.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dtgvKichBan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dtgvKichBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dtgvKichBan.Columns.AddRange(cStt, cIdKichBan, cTenKichBan);
			dtgvKichBan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			dtgvKichBan.Location = new System.Drawing.Point(6, 20);
			dtgvKichBan.MultiSelect = false;
			dtgvKichBan.Name = "dtgvKichBan";
			dtgvKichBan.RowHeadersVisible = false;
			dtgvKichBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dtgvKichBan.Size = new System.Drawing.Size(296, 258);
			dtgvKichBan.TabIndex = 76;
			dtgvKichBan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvKichBan_CellDoubleClick);
			cStt.HeaderText = "STT";
			cStt.Name = "cStt";
			cStt.Width = 35;
			cIdKichBan.HeaderText = "Id kịch bản";
			cIdKichBan.Name = "cIdKichBan";
			cIdKichBan.Visible = false;
			cTenKichBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			cTenKichBan.HeaderText = "Tên kịch bản";
			cTenKichBan.Name = "cTenKichBan";
			cTenKichBan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
			bunifuCards1.Size = new System.Drawing.Size(699, 37);
			bunifuCards1.TabIndex = 12;
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnSave);
			panel1.Controls.Add(bunifuCards1);
			panel1.Controls.Add(groupBox2);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(702, 391);
			panel1.TabIndex = 13;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(359, 350);
			btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 22;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnSave.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			btnSave.FlatAppearance.BorderSize = 0;
			btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnSave.ForeColor = System.Drawing.Color.White;
			btnSave.Location = new System.Drawing.Point(252, 350);
			btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(92, 29);
			btnSave.TabIndex = 21;
			btnSave.Text = "Lưu";
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += new System.EventHandler(btnSave_Click);
			groupBox2.BackColor = System.Drawing.Color.White;
			groupBox2.Controls.Add(lblCountAcc);
			groupBox2.Controls.Add(label7);
			groupBox2.Controls.Add(label1);
			groupBox2.Controls.Add(button3);
			groupBox2.Controls.Add(dtgvKichBanChoose);
			groupBox2.Controls.Add(button2);
			groupBox2.Location = new System.Drawing.Point(325, 40);
			groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox2.Size = new System.Drawing.Size(363, 302);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Kịch bản cần chạy";
			lblCountAcc.AutoSize = true;
			lblCountAcc.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			lblCountAcc.ForeColor = System.Drawing.Color.Blue;
			lblCountAcc.Location = new System.Drawing.Point(297, 281);
			lblCountAcc.Name = "lblCountAcc";
			lblCountAcc.Size = new System.Drawing.Size(16, 16);
			lblCountAcc.TabIndex = 82;
			lblCountAcc.Text = "0";
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label7.Location = new System.Drawing.Point(255, 281);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 16);
			label7.TabIndex = 83;
			label7.Text = "Tổng:";
			label1.AutoSize = true;
			label1.ForeColor = System.Drawing.Color.Red;
			label1.Location = new System.Drawing.Point(4, 282);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(186, 16);
			label1.TabIndex = 81;
			label1.Text = "(Click đúp vào kịch bản để xóa)";
			button3.Cursor = System.Windows.Forms.Cursors.Hand;
			button3.Image = maxcare.Properties.Resources.icons8_down_arrow_32px;
			button3.Location = new System.Drawing.Point(314, 64);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(41, 38);
			button3.TabIndex = 78;
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			dtgvKichBanChoose.AllowUserToAddRows = false;
			dtgvKichBanChoose.AllowUserToDeleteRows = false;
			dtgvKichBanChoose.AllowUserToResizeRows = false;
			dtgvKichBanChoose.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dtgvKichBanChoose.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dtgvKichBanChoose.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dtgvKichBanChoose.Columns.AddRange(cSTTChoose, cIdKichBanChoose, cTenKichBanChoose);
			dtgvKichBanChoose.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			dtgvKichBanChoose.Location = new System.Drawing.Point(6, 20);
			dtgvKichBanChoose.MultiSelect = false;
			dtgvKichBanChoose.Name = "dtgvKichBanChoose";
			dtgvKichBanChoose.RowHeadersVisible = false;
			dtgvKichBanChoose.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dtgvKichBanChoose.Size = new System.Drawing.Size(302, 258);
			dtgvKichBanChoose.TabIndex = 76;
			dtgvKichBanChoose.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
			dtgvKichBanChoose.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(dtgvKichBanChoose_RowsAdded);
			dtgvKichBanChoose.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(dtgvKichBanChoose_RowsRemoved);
			cSTTChoose.HeaderText = "STT";
			cSTTChoose.Name = "cSTTChoose";
			cSTTChoose.Width = 35;
			cIdKichBanChoose.HeaderText = "Id kịch bản";
			cIdKichBanChoose.Name = "cIdKichBanChoose";
			cIdKichBanChoose.Visible = false;
			cTenKichBanChoose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			cTenKichBanChoose.HeaderText = "Tên kịch bản";
			cTenKichBanChoose.Name = "cTenKichBanChoose";
			cTenKichBanChoose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.Image = maxcare.Properties.Resources.icons8_up_32px;
			button2.Location = new System.Drawing.Point(314, 19);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(41, 38);
			button2.TabIndex = 78;
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(702, 391);
			base.Controls.Add(groupBox1);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fChonKichBan";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dtgvKichBan).EndInit();
			bunifuCards1.ResumeLayout(false);
			panel1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dtgvKichBanChoose).EndInit();
			ResumeLayout(false);
		}
	}
}
