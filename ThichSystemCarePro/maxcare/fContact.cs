using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Properties;

namespace maxcare
{
	public class fContact : Form
	{
		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnMinimize;

		private BunifuDragControl bunifuDragControl1;

		private PictureBox pictureBox1;

		private Panel panel1;

		private Panel panel2;

		private Label label3;

		private Label label4;

		private Label label6;

		private Label label5;

		private PictureBox pictureBox2;

		private PictureBox pictureBox3;

		private Label label10;

		private Panel panel3;

		private LinkLabel linkLabel4;

		private Label label7;

		private Label label8;

		private Label label9;

		private Label label1;

		private LinkLabel linkLabel2;

		private Label label12;

		public LinkLabel linkLabel1;

		public fContact()
		{
			InitializeComponent();
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label1);
			Language.GetValue(label10);
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
		}

		private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string text = (sender as LinkLabel).Text;
			try
			{
				Process.Start("chrome.exe", text);
			}
			catch
			{
				Process.Start(text);
			}
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string text = (sender as LinkLabel).Text;
			try
			{
				Process.Start("chrome.exe", text);
			}
			catch
			{
				Process.Start(text);
			}
		}

		private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string text = (sender as LinkLabel).Text;
			try
			{
				Process.Start("chrome.exe", text);
			}
			catch
			{
				Process.Start(text);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fContact));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			panel1 = new System.Windows.Forms.Panel();
			label12 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			linkLabel4 = new System.Windows.Forms.LinkLabel();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			linkLabel2 = new System.Windows.Forms.LinkLabel();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			panel3.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			SuspendLayout();
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.SaddleBrown;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(1, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(808, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(808, 32);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 17;
			pictureBox1.TabStop = false;
			btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(775, -1);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(808, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Thông tin liên hệ";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(label12);
			panel1.Controls.Add(label10);
			panel1.Controls.Add(panel3);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(pictureBox2);
			panel1.Controls.Add(pictureBox3);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(809, 522);
			panel1.TabIndex = 5;
			label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label12.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label12.ForeColor = System.Drawing.Color.Red;
			label12.Location = new System.Drawing.Point(243, 429);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(524, 77);
			label12.TabIndex = 21;
			label12.Text = "Chú ý: Ngiêm cấm sử dụng phần mềm vào các mục đích xấu, vi phạm pháp luật. Nếu cố tình sẽ bị xóa khỏi hệ thống vĩnh viễn, và phải chịu hoàn toàn trách nhiệm trước pháp luật.";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
			label10.Location = new System.Drawing.Point(238, 335);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(274, 25);
			label10.TabIndex = 14;
			label10.Text = "Liên hệ code tool theo yêu cầu:";
			panel3.BackColor = System.Drawing.Color.White;
			panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel3.Controls.Add(linkLabel4);
			panel3.Controls.Add(label7);
			panel3.Controls.Add(label8);
			panel3.Controls.Add(label9);
			panel3.Location = new System.Drawing.Point(269, 361);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(498, 65);
			panel3.TabIndex = 13;
			linkLabel4.AutoSize = true;
			linkLabel4.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			linkLabel4.Location = new System.Drawing.Point(94, 32);
			linkLabel4.Name = "linkLabel4";
			linkLabel4.Size = new System.Drawing.Size(180, 25);
			linkLabel4.TabIndex = 9;
			linkLabel4.TabStop = true;
			linkLabel4.Text = "http://bit.ly/MINSoft";
			linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel4_LinkClicked);
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.ForeColor = System.Drawing.Color.Black;
			label7.Location = new System.Drawing.Point(3, 5);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(77, 25);
			label7.TabIndex = 2;
			label7.Text = "Hotline:";
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.ForeColor = System.Drawing.Color.Black;
			label8.Location = new System.Drawing.Point(3, 32);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(87, 25);
			label8.TabIndex = 2;
			label8.Text = "Fanpage:";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.ForeColor = System.Drawing.Color.Black;
			label9.Location = new System.Drawing.Point(94, 5);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(120, 25);
			label9.TabIndex = 2;
			label9.Text = "035.839.4040";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
			label1.Location = new System.Drawing.Point(238, 211);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(228, 25);
			label1.TabIndex = 14;
			label1.Text = "Liên hệ hỗ trợ phần mềm:";
			panel2.BackColor = System.Drawing.Color.White;
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(linkLabel1);
			panel2.Controls.Add(linkLabel2);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(label5);
			panel2.Location = new System.Drawing.Point(269, 237);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(498, 95);
			panel2.TabIndex = 13;
			linkLabel1.AutoSize = true;
			linkLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			linkLabel1.Location = new System.Drawing.Point(94, 6);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(207, 25);
			linkLabel1.TabIndex = 9;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "https://minsoftware.vn/";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked_1);
			linkLabel2.AutoSize = true;
			linkLabel2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			linkLabel2.Location = new System.Drawing.Point(94, 63);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new System.Drawing.Size(180, 25);
			linkLabel2.TabIndex = 9;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "http://bit.ly/MINSoft";
			linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.Black;
			label3.Location = new System.Drawing.Point(3, 6);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(83, 25);
			label3.TabIndex = 2;
			label3.Text = "Website:";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.ForeColor = System.Drawing.Color.Black;
			label4.Location = new System.Drawing.Point(3, 36);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(77, 25);
			label4.TabIndex = 2;
			label4.Text = "Hotline:";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.ForeColor = System.Drawing.Color.Black;
			label6.Location = new System.Drawing.Point(3, 63);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(87, 25);
			label6.TabIndex = 2;
			label6.Text = "Fanpage:";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.ForeColor = System.Drawing.Color.Black;
			label5.Location = new System.Drawing.Point(94, 36);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(120, 25);
			label5.TabIndex = 2;
			label5.Text = "0969.078.803";
			pictureBox2.Image = maxcare.Properties.Resources._1kH0ai7;
			pictureBox2.Location = new System.Drawing.Point(12, 214);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(220, 238);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox2.TabIndex = 12;
			pictureBox2.TabStop = false;
			pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
			pictureBox3.Location = new System.Drawing.Point(84, 47);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(620, 130);
			pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox3.TabIndex = 11;
			pictureBox3.TabStop = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(809, 522);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fContact";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			ResumeLayout(false);
		}
	}
}
