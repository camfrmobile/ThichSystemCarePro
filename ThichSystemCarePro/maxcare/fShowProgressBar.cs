using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using maxcare.Helper;
using MetroFramework.Controls;

namespace maxcare
{
	public class fShowProgressBar : Form
	{
		private List<string> lstPathFolder = new List<string>();

		private IContainer components = null;

		private Label lblproccess;

		private MetroProgressBar progressBar1;

		public fShowProgressBar(List<string> lstPathFolder)
		{
			InitializeComponent();
			ChangeLanguage();
			this.lstPathFolder = lstPathFolder;
		}

		private void ChangeLanguage()
		{
			Language.GetValue(lblproccess);
		}

		private void frm_progress_Load(object sender, EventArgs e)
		{
			try
			{
				new Thread((ThreadStart)delegate
				{
					string text = "";
					string text2 = "";
					int count = 0;
					int total = lstPathFolder.Count;
					BeginInvoke((MethodInvoker)delegate
					{
						lblproccess.Text = string.Format(Language.GetValue("Đang copy, vui lo\u0300ng chơ\u0300 ({0}/{1})..."), count, total);
					});
					for (int i = 0; i < lstPathFolder.Count; i++)
					{
						text = lstPathFolder[i].Split('|')[0];
						text2 = lstPathFolder[i].Split('|')[1];
						if (FileHelper.DirectoryCopy(text, text2, copySubDirs: true))
						{
							int num = count;
							count = num + 1;
						}
						double percentage = (double)count * 1.0 / (double)total * 100.0;
						BeginInvoke((MethodInvoker)delegate
						{
							lblproccess.Text = string.Format(Language.GetValue("Đang copy, vui lo\u0300ng chơ\u0300 ({0}/{1})..."), count, total);
							progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
						});
					}
					BeginInvoke((MethodInvoker)delegate
					{
						Close();
					});
				}).Start();
			}
			catch (Exception ex)
			{
				MessageBoxHelper.ShowMessageBox("Error: " + ex.Message, 2);
				Close();
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
			lblproccess = new System.Windows.Forms.Label();
			progressBar1 = new MetroFramework.Controls.MetroProgressBar();
			SuspendLayout();
			lblproccess.AutoSize = true;
			lblproccess.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblproccess.Location = new System.Drawing.Point(34, 22);
			lblproccess.Name = "lblproccess";
			lblproccess.Size = new System.Drawing.Size(189, 16);
			lblproccess.TabIndex = 1;
			lblproccess.Text = "Đang copy, vui lo\u0300ng chơ\u0300 (0/0)...";
			progressBar1.Location = new System.Drawing.Point(37, 52);
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new System.Drawing.Size(219, 23);
			progressBar1.TabIndex = 2;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			base.ClientSize = new System.Drawing.Size(294, 104);
			base.Controls.Add(progressBar1);
			base.Controls.Add(lblproccess);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fShowProgressBar";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "frm_progress";
			base.Load += new System.EventHandler(frm_progress_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
