using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;

namespace maxcare
{
	public class fChonThuMuc : Form
	{
		private bool isFromBin = false;

		public static List<string> lstChooseIdFiles;

		public static List<string> lstChooseIdFilesFromBin;

		public static bool isAdd;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnMinimize;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuDragControl bunifuDragControl1;

		private PictureBox pictureBox1;

		private Label label1;

		private Label lblCountTotal;

		private Label label3;

		private Label lblCountChoose;

		private Label label2;

		public DataGridView dtgvAcc;

		private CheckBox checkBox1;

		private DataGridViewCheckBoxColumn cChose;

		private DataGridViewTextBoxColumn cStt;

		private DataGridViewTextBoxColumn cId;

		private DataGridViewTextBoxColumn cThuMuc;

		public fChonThuMuc(bool isFromBin = false)
		{
			InitializeComponent();
			isAdd = false;
			this.isFromBin = isFromBin;
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label2);
			Language.GetValue(label3);
			Language.GetValue(label1);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			foreach (DataGridViewColumn column in dtgvAcc.Columns)
			{
				Language.GetValue(column);
			}
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			isAdd = true;
			if (isFromBin)
			{
				lstChooseIdFilesFromBin = new List<string>();
				for (int i = 0; i < dtgvAcc.Rows.Count; i++)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
					{
						lstChooseIdFilesFromBin.Add(DatagridviewHelper.GetStatusDataGridView(dtgvAcc, i, "cId"));
					}
				}
				if (lstChooseIdFilesFromBin.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn ít nhất 1 thư mục!"), 2);
					return;
				}
			}
			else
			{
				lstChooseIdFiles = new List<string>();
				for (int j = 0; j < dtgvAcc.Rows.Count; j++)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
					{
						lstChooseIdFiles.Add(DatagridviewHelper.GetStatusDataGridView(dtgvAcc, j, "cId"));
					}
				}
				if (lstChooseIdFiles.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn ít nhất 1 thư mục!"), 2);
					return;
				}
			}
			Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void fClearProfile_Load(object sender, EventArgs e)
		{
			if (isFromBin)
			{
				if (lstChooseIdFilesFromBin == null)
				{
					lstChooseIdFilesFromBin = new List<string>();
				}
				LoadListFiles(lstChooseIdFilesFromBin);
			}
			else
			{
				if (lstChooseIdFiles == null)
				{
					lstChooseIdFiles = new List<string>();
				}
				LoadListFiles(lstChooseIdFiles);
			}
		}

		private void LoadListFiles(List<string> lstIdFile = null)
		{
			try
			{
				DataTable dataTable = ((!isFromBin) ? CommonSQL.GetAllFilesFromDatabase() : CommonSQL.GetAllFilesFromDatabaseForBin());
				if (lstIdFile != null && lstIdFile.Count > 0)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						if (lstIdFile.Contains(dataTable.Rows[i]["id"].ToString()))
						{
							dtgvAcc.Rows.Add(true, i + 1, dataTable.Rows[i]["id"], dataTable.Rows[i]["name"]);
						}
						else
						{
							dtgvAcc.Rows.Add(false, i + 1, dataTable.Rows[i]["id"], dataTable.Rows[i]["name"]);
						}
					}
				}
				else
				{
					for (int j = 0; j < dataTable.Rows.Count; j++)
					{
						dtgvAcc.Rows.Add(false, j + 1, dataTable.Rows[j]["id"], dataTable.Rows[j]["name"]);
					}
				}
				UpdateSelectCountRecord();
				UpdateTotalCountRecord();
				if (CountSelectRow() == dtgvAcc.RowCount)
				{
					checkBox1.Checked = true;
				}
				else
				{
					checkBox1.Checked = false;
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "LoadListFiles");
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Có lỗi xảy ra, vui lòng thử lại sau!"), 2);
			}
		}

		private void UpdateSelectCountRecord()
		{
			try
			{
				lblCountChoose.Text = CountSelectRow().ToString();
			}
			catch
			{
			}
		}

		private void DtgvAcc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				UpdateSelectCountRecord();
				if (CountSelectRow() == dtgvAcc.RowCount)
				{
					checkBox1.Checked = true;
				}
				else
				{
					checkBox1.Checked = false;
				}
			}
		}

		private void UpdateTotalCountRecord()
		{
			try
			{
				lblCountTotal.Text = dtgvAcc.Rows.Count.ToString();
			}
			catch
			{
			}
		}

		private void dtgvAcc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (Convert.ToBoolean(dtgvAcc.CurrentRow.Cells["cChose"].Value))
				{
					dtgvAcc.CurrentRow.Cells["cChose"].Value = false;
				}
				else
				{
					dtgvAcc.CurrentRow.Cells["cChose"].Value = true;
				}
			}
			catch
			{
			}
		}

		private int CountSelectRow()
		{
			int num = 0;
			for (int i = 0; i < dtgvAcc.Rows.Count; i++)
			{
				if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
				{
					num++;
				}
			}
			return num;
		}

		private void dtgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex != 0)
			{
				return;
			}
			try
			{
				if (Convert.ToBoolean(dtgvAcc.CurrentRow.Cells["cChose"].Value))
				{
					dtgvAcc.CurrentRow.Cells["cChose"].Value = false;
				}
				else
				{
					dtgvAcc.CurrentRow.Cells["cChose"].Value = true;
				}
			}
			catch
			{
			}
		}

		private void checkBox1_Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				for (int i = 0; i < dtgvAcc.Rows.Count; i++)
				{
					DatagridviewHelper.SetStatusDataGridView(dtgvAcc, i, "cChose", true);
				}
			}
			else
			{
				for (int j = 0; j < dtgvAcc.Rows.Count; j++)
				{
					DatagridviewHelper.SetStatusDataGridView(dtgvAcc, j, "cChose", false);
				}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fChonThuMuc));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			label1 = new System.Windows.Forms.Label();
			lblCountTotal = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			lblCountChoose = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			dtgvAcc = new System.Windows.Forms.DataGridView();
			cChose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			cStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cThuMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			checkBox1 = new System.Windows.Forms.CheckBox();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dtgvAcc).BeginInit();
			SuspendLayout();
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.SaddleBrown;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(0, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(317, 34);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(317, 28);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 17;
			pictureBox1.TabStop = false;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(285, 0);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 28);
			btnMinimize.TabIndex = 9;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(BtnMinimize_Click);
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(317, 28);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Chọn Danh sách thư mục";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(156, 280);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Đo\u0301ng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(52, 280);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Lưu";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(145, 252);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 16);
			label1.TabIndex = 6;
			label1.Text = "Tổng số:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lblCountTotal.AutoSize = true;
			lblCountTotal.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCountTotal.ForeColor = System.Drawing.Color.DarkRed;
			lblCountTotal.Location = new System.Drawing.Point(203, 253);
			lblCountTotal.Name = "lblCountTotal";
			lblCountTotal.Size = new System.Drawing.Size(15, 16);
			lblCountTotal.TabIndex = 6;
			lblCountTotal.Text = "0";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(49, 252);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(60, 16);
			label3.TabIndex = 6;
			label3.Text = "Đã chọn:";
			lblCountChoose.AutoSize = true;
			lblCountChoose.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCountChoose.ForeColor = System.Drawing.Color.DarkGreen;
			lblCountChoose.Location = new System.Drawing.Point(107, 253);
			lblCountChoose.Name = "lblCountChoose";
			lblCountChoose.Size = new System.Drawing.Size(15, 16);
			lblCountChoose.TabIndex = 6;
			lblCountChoose.Text = "0";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.DarkRed;
			label2.Location = new System.Drawing.Point(12, 227);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(178, 16);
			label2.TabIndex = 6;
			label2.Text = "(Click đúp vào dòng để chọn!)";
			dtgvAcc.AllowUserToAddRows = false;
			dtgvAcc.AllowUserToDeleteRows = false;
			dtgvAcc.AllowUserToResizeRows = false;
			dtgvAcc.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dtgvAcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dtgvAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dtgvAcc.Columns.AddRange(cChose, cStt, cId, cThuMuc);
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			dtgvAcc.DefaultCellStyle = dataGridViewCellStyle2;
			dtgvAcc.Location = new System.Drawing.Point(15, 40);
			dtgvAcc.Name = "dtgvAcc";
			dtgvAcc.ReadOnly = true;
			dtgvAcc.RowHeadersVisible = false;
			dtgvAcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dtgvAcc.Size = new System.Drawing.Size(287, 184);
			dtgvAcc.TabIndex = 7;
			dtgvAcc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvAcc_CellClick);
			dtgvAcc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvAcc_CellDoubleClick);
			dtgvAcc.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(DtgvAcc_CellValueChanged);
			cChose.HeaderText = "";
			cChose.Name = "cChose";
			cChose.ReadOnly = true;
			cChose.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			cChose.Width = 30;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			cStt.DefaultCellStyle = dataGridViewCellStyle3;
			cStt.HeaderText = "STT";
			cStt.Name = "cStt";
			cStt.ReadOnly = true;
			cStt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			cStt.Width = 35;
			cId.HeaderText = "Id";
			cId.Name = "cId";
			cId.ReadOnly = true;
			cId.Visible = false;
			cId.Width = 90;
			cThuMuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			cThuMuc.HeaderText = "Thư mục";
			cThuMuc.Name = "cThuMuc";
			cThuMuc.ReadOnly = true;
			checkBox1.AutoSize = true;
			checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			checkBox1.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			checkBox1.Location = new System.Drawing.Point(25, 45);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(15, 14);
			checkBox1.TabIndex = 8;
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.Click += new System.EventHandler(checkBox1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(317, 322);
			base.Controls.Add(checkBox1);
			base.Controls.Add(dtgvAcc);
			base.Controls.Add(lblCountChoose);
			base.Controls.Add(label2);
			base.Controls.Add(lblCountTotal);
			base.Controls.Add(label3);
			base.Controls.Add(label1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(bunifuCards1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fChonThuMuc";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fClearProfile_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)dtgvAcc).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
