using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using maxcare.Helper;
using maxcare.Properties;
using MCommon;
using MetroFramework.Controls;

namespace maxcare
{
	public class fIntro : Form
	{
		private IContainer components;

		private Label label1;

		private PictureBox pictureBox1;

		private MetroProgressBar progressBar;

		private Timer timer1;

		private Timer timer2;

		private Label label7;

		private Label label10;

		private Panel panel3;

		private LinkLabel linkLabel4;

		private Label label2;

		private Label label8;

		private Label label9;

		private Label label3;

		private Panel panel2;

		private LinkLabel linkLabel1;

		private LinkLabel linkLabel2;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label11;

		private PictureBox pictureBox2;

		private Label label12;

		[DllImport("kernel32.dll")]
		private static extern long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, uint VolumeNameSize, ref uint VolumeSerialNumber, ref uint MaximumComponentLength, ref uint FileSystemFlags, StringBuilder FileSystemNameBuffer, uint FileSystemNameSize);

		public fIntro()
		{
			InitializeComponent();
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(label1);
			Language.GetValue(label3);
			Language.GetValue(label10);
			Language.GetValue(label7);
		}

		private void Intro_Load(object sender, EventArgs e)
		{
			timer1.Tick += fadeIn;
			timer1.Start();
		}

		private void fadeIn(object sender, EventArgs e)
		{
			if (base.Opacity >= 1.0)
			{
				timer1.Stop();
				try
				{
					string path = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\drivers\\etc\\hosts";
					if (File.Exists(path))
					{
						try
						{
							List<string> list = new List<string> { "app.minsoftware.vn", "minsoftware.vn" };
							using StreamReader streamReader = new StreamReader(path);
							string empty = string.Empty;
							while ((empty = streamReader.ReadLine()) != null)
							{
								foreach (string item in list)
								{
									if (empty.ToLower().Contains(item))
									{
										MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng cấu hình lại file hosts nếu muốn mở phần mềm!"), 2);
										Environment.Exit(0);
									}
								}
							}
						}
						catch
						{
						}
					}
					Hide();
					new fMain("").ShowDialog();
				}
				catch (Exception ex)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng liên hê\u0323 Admin đê\u0309 đươ\u0323c hô\u0303 trơ\u0323!"), 2);
					MCommon.Common.ExportError(null, ex, "Run Program");
					Close();
					return;
				}
			}
			base.Opacity += 0.05;
		}

		private void fadeOut(object sender, EventArgs e)
		{
			if (base.Opacity <= 0.0)
			{
				timer1.Stop();
				Close();
			}
			else
			{
				base.Opacity -= 0.05;
			}
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			if (progressBar.Value < 90)
			{
				progressBar.Value += 10;
			}
			else
			{
				timer2.Stop();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fIntro));
			label1 = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			progressBar = new MetroFramework.Controls.MetroProgressBar();
			timer1 = new System.Windows.Forms.Timer(components);
			timer2 = new System.Windows.Forms.Timer(components);
			label7 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			linkLabel4 = new System.Windows.Forms.LinkLabel();
			label2 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			linkLabel2 = new System.Windows.Forms.LinkLabel();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			label12 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel3.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			label1.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(61, 152);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(653, 21);
			label1.TabIndex = 1;
			label1.Text = "PHẦN MỀM HỖ TRỢ KINH DOANH ONLINE - TỰ ĐỘNG HÓA MỌI THAO TÁC CỦA BẠN";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(77, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(620, 130);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox1.TabIndex = 5;
			pictureBox1.TabStop = false;
			progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			progressBar.Location = new System.Drawing.Point(38, 506);
			progressBar.Name = "progressBar";
			progressBar.Size = new System.Drawing.Size(723, 23);
			progressBar.Step = 50;
			progressBar.TabIndex = 7;
			timer1.Interval = 30;
			timer2.Enabled = true;
			timer2.Tick += new System.EventHandler(timer2_Tick);
			label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.ForeColor = System.Drawing.Color.DarkViolet;
			label7.Location = new System.Drawing.Point(611, 486);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(155, 16);
			label7.TabIndex = 9;
			label7.Text = "Đang kiểm tra thông tin...";
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
			label10.Location = new System.Drawing.Point(235, 305);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(274, 25);
			label10.TabIndex = 18;
			label10.Text = "Liên hệ code tool theo yêu cầu:";
			panel3.BackColor = System.Drawing.Color.WhiteSmoke;
			panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel3.Controls.Add(linkLabel4);
			panel3.Controls.Add(label2);
			panel3.Controls.Add(label8);
			panel3.Controls.Add(label9);
			panel3.Location = new System.Drawing.Point(266, 331);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(495, 65);
			panel3.TabIndex = 16;
			linkLabel4.AutoSize = true;
			linkLabel4.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			linkLabel4.Location = new System.Drawing.Point(94, 32);
			linkLabel4.Name = "linkLabel4";
			linkLabel4.Size = new System.Drawing.Size(180, 25);
			linkLabel4.TabIndex = 9;
			linkLabel4.TabStop = true;
			linkLabel4.Text = "http://bit.ly/MINSoft";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.Black;
			label2.Location = new System.Drawing.Point(3, 5);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(77, 25);
			label2.TabIndex = 2;
			label2.Text = "Hotline:";
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
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
			label3.Location = new System.Drawing.Point(235, 181);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(228, 25);
			label3.TabIndex = 19;
			label3.Text = "Liên hệ hỗ trợ phần mềm:";
			panel2.BackColor = System.Drawing.Color.WhiteSmoke;
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(linkLabel1);
			panel2.Controls.Add(linkLabel2);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(label11);
			panel2.Location = new System.Drawing.Point(266, 207);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(495, 95);
			panel2.TabIndex = 17;
			linkLabel1.AutoSize = true;
			linkLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			linkLabel1.Location = new System.Drawing.Point(94, 6);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(207, 25);
			linkLabel1.TabIndex = 9;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "https://minsoftware.vn/";
			linkLabel2.AutoSize = true;
			linkLabel2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			linkLabel2.Location = new System.Drawing.Point(94, 63);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new System.Drawing.Size(180, 25);
			linkLabel2.TabIndex = 9;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "http://bit.ly/MINSoft";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.ForeColor = System.Drawing.Color.Black;
			label4.Location = new System.Drawing.Point(3, 6);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(83, 25);
			label4.TabIndex = 2;
			label4.Text = "Website:";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.ForeColor = System.Drawing.Color.Black;
			label5.Location = new System.Drawing.Point(3, 36);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(77, 25);
			label5.TabIndex = 2;
			label5.Text = "Hotline:";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.ForeColor = System.Drawing.Color.Black;
			label6.Location = new System.Drawing.Point(3, 63);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(87, 25);
			label6.TabIndex = 2;
			label6.Text = "Fanpage:";
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label11.ForeColor = System.Drawing.Color.Black;
			label11.Location = new System.Drawing.Point(94, 36);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(120, 25);
			label11.TabIndex = 2;
			label11.Text = "0969.078.803";
			pictureBox2.Image = maxcare.Properties.Resources._1kH0ai7;
			pictureBox2.Location = new System.Drawing.Point(9, 184);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(220, 238);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox2.TabIndex = 15;
			pictureBox2.TabStop = false;
			label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label12.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label12.ForeColor = System.Drawing.Color.Red;
			label12.Location = new System.Drawing.Point(235, 399);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(526, 77);
			label12.TabIndex = 20;
			label12.Text = "Chú ý: Ngiêm cấm sử dụng phần mềm vào các mục đích xấu, vi phạm pháp luật. Nếu cố tình sẽ bị xóa khỏi hệ thống vĩnh viễn, và phải chịu hoàn toàn trách nhiệm trước pháp luật.";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.WhiteSmoke;
			base.ClientSize = new System.Drawing.Size(801, 541);
			base.Controls.Add(label12);
			base.Controls.Add(label10);
			base.Controls.Add(panel3);
			base.Controls.Add(label3);
			base.Controls.Add(panel2);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(label7);
			base.Controls.Add(progressBar);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "fIntro";
			base.Opacity = 0.0;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Kiểm tra thông tin";
			base.TopMost = true;
			base.Load += new System.EventHandler(Intro_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
