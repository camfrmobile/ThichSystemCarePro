using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;
using MetroFramework;
using MetroFramework.Controls;

namespace maxcare
{
	public class fEditFile : Form
	{
		private string idFile;

		private string nameFileOld;

		public bool isSuccess = false;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnMinimize;

		private Button btnCancel;

		private Button btnAdd;

		private Label label1;

		private BunifuDragControl bunifuDragControl1;

		private MetroTextBox txtNameFileOld;

		private PictureBox pictureBox1;

		private MetroTextBox txtNameFileNew;

		private Label label2;

		public fEditFile(string idFile, string namefile)
		{
			InitializeComponent();
			ChangeLanguage();
			this.idFile = idFile;
			nameFileOld = namefile;
			isSuccess = false;
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label1);
			Language.GetValue(label2);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			string text = txtNameFileNew.Text.Trim();
			if (text == "")
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng điền tên thư mục mới!"), 3);
				txtNameFileNew.Focus();
			}
			else if (CommonSQL.CheckExitsFile(text))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Tên thư mục này đã tồn tại, vui lòng nhập tên khác!"), 3);
				txtNameFileNew.Focus();
			}
			else if (text.Equals(txtNameFileOld.Text.Trim()))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Tên thư mục mới phải khác thư mục cũ!"), 3);
				txtNameFileNew.Focus();
			}
			else if (CommonSQL.UpdateFileNameToDatabase(idFile, text))
			{
				isSuccess = true;
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Cập nhật thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?")) == DialogResult.Yes)
				{
					Close();
				}
			}
			else
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Cập nhật tên thư mục lỗi!"));
			}
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void txbNameFile_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				BtnAdd_Click(null, null);
			}
		}

		private void fEditFile_Load(object sender, EventArgs e)
		{
			txtNameFileOld.Text = nameFileOld;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fEditFile));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			txtNameFileOld = new MetroFramework.Controls.MetroTextBox();
			txtNameFileNew = new MetroFramework.Controls.MetroTextBox();
			label2 = new System.Windows.Forms.Label();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
			bunifuCards1.Size = new System.Drawing.Size(396, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(396, 32);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(4, 1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 77;
			pictureBox1.TabStop = false;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(362, -2);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 32);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(396, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Cập nhật Tên thư mục";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(204, 138);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Hủy";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(100, 138);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Cập nhật";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label1.Location = new System.Drawing.Point(33, 69);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(103, 16);
			label1.TabIndex = 20;
			label1.Text = "Tên thư mu\u0323c cũ:";
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			txtNameFileOld.CustomButton.Image = null;
			txtNameFileOld.CustomButton.Location = new System.Drawing.Point(187, 1);
			txtNameFileOld.CustomButton.Name = "";
			txtNameFileOld.CustomButton.Size = new System.Drawing.Size(21, 21);
			txtNameFileOld.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			txtNameFileOld.CustomButton.TabIndex = 1;
			txtNameFileOld.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			txtNameFileOld.CustomButton.UseSelectable = true;
			txtNameFileOld.CustomButton.Visible = false;
			txtNameFileOld.Enabled = false;
			txtNameFileOld.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			txtNameFileOld.Lines = new string[0];
			txtNameFileOld.Location = new System.Drawing.Point(150, 66);
			txtNameFileOld.MaxLength = 32767;
			txtNameFileOld.Name = "txtNameFileOld";
			txtNameFileOld.PasswordChar = '\0';
			txtNameFileOld.ScrollBars = System.Windows.Forms.ScrollBars.None;
			txtNameFileOld.SelectedText = "";
			txtNameFileOld.SelectionLength = 0;
			txtNameFileOld.SelectionStart = 0;
			txtNameFileOld.ShortcutsEnabled = true;
			txtNameFileOld.Size = new System.Drawing.Size(209, 23);
			txtNameFileOld.TabIndex = 2;
			txtNameFileOld.UseSelectable = true;
			txtNameFileOld.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
			txtNameFileOld.WaterMarkFont = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtNameFileOld.KeyDown += new System.Windows.Forms.KeyEventHandler(txbNameFile_KeyDown);
			txtNameFileNew.CustomButton.Image = null;
			txtNameFileNew.CustomButton.Location = new System.Drawing.Point(187, 1);
			txtNameFileNew.CustomButton.Name = "";
			txtNameFileNew.CustomButton.Size = new System.Drawing.Size(21, 21);
			txtNameFileNew.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			txtNameFileNew.CustomButton.TabIndex = 1;
			txtNameFileNew.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			txtNameFileNew.CustomButton.UseSelectable = true;
			txtNameFileNew.CustomButton.Visible = false;
			txtNameFileNew.Lines = new string[0];
			txtNameFileNew.Location = new System.Drawing.Point(150, 95);
			txtNameFileNew.MaxLength = 32767;
			txtNameFileNew.Name = "txtNameFileNew";
			txtNameFileNew.PasswordChar = '\0';
			txtNameFileNew.ScrollBars = System.Windows.Forms.ScrollBars.None;
			txtNameFileNew.SelectedText = "";
			txtNameFileNew.SelectionLength = 0;
			txtNameFileNew.SelectionStart = 0;
			txtNameFileNew.ShortcutsEnabled = true;
			txtNameFileNew.Size = new System.Drawing.Size(209, 23);
			txtNameFileNew.TabIndex = 2;
			txtNameFileNew.UseSelectable = true;
			txtNameFileNew.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
			txtNameFileNew.WaterMarkFont = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtNameFileNew.KeyDown += new System.Windows.Forms.KeyEventHandler(txbNameFile_KeyDown);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label2.Location = new System.Drawing.Point(33, 98);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(111, 16);
			label2.TabIndex = 20;
			label2.Text = "Tên thư mu\u0323c mới:";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(396, 182);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(txtNameFileNew);
			base.Controls.Add(txtNameFileOld);
			base.Controls.Add(bunifuCards1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fEditFile";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fEditFile_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
