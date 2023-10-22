using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using maxcare.Helper;
using MetroFramework.Controls;

namespace maxcare
{
	public class frm_progress : Form
	{
		private IContainer components = null;

		private Label lblproccess;

		private MetroProgressBar progressBar1;

		public frm_progress()
		{
			InitializeComponent();
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(lblproccess);
		}

		private void frm_progress_Load(object sender, EventArgs e)
		{
			try
			{
				if (File.Exists("./" + Base.softname + "/" + Base.softname + ".zip"))
				{
					File.Delete("./" + Base.softname + "/" + Base.softname + ".zip");
				}
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				string text = Base.hostname + Base.softname;
				if (InternetConnection.IsConnectedToInternet())
				{
					Uri uri = new Uri(text + "/" + Base.softname + ".zip");
					StartDownload(uri, "./" + Base.softname + "/" + Base.softname + ".zip");
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Không co\u0301 kê\u0301t nô\u0301i Internet, vui lo\u0300ng kiê\u0309m tra la\u0323i!"));
					Close();
				}
			}
			catch (Exception ex)
			{
				MessageBoxHelper.ShowMessageBox("Error: " + ex.Message, 2);
				Close();
			}
		}

		public void Copy(string sourceDirectory, string targetDirectory)
		{
			DirectoryInfo source = new DirectoryInfo(sourceDirectory);
			DirectoryInfo target = new DirectoryInfo(targetDirectory);
			CopyAll(source, target);
		}

		public void CopyAll(DirectoryInfo source, DirectoryInfo target)
		{
			Directory.CreateDirectory(target.FullName);
			int num = 1;
			FileInfo[] files = source.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				Application.DoEvents();
				fileInfo.CopyTo(Path.Combine(target.FullName, fileInfo.Name), overwrite: true);
				num++;
			}
			DirectoryInfo[] directories = source.GetDirectories();
			foreach (DirectoryInfo directoryInfo in directories)
			{
				DirectoryInfo target2 = target.CreateSubdirectory(directoryInfo.Name);
				CopyAll(directoryInfo, target2);
			}
		}

		private void StartDownload(Uri uri, string pathFile)
		{
			Thread thread = new Thread((ThreadStart)delegate
			{
				WebClient webClient = new WebClient();
				webClient.DownloadProgressChanged += client_DownloadProgressChanged;
				webClient.DownloadFileCompleted += client_DownloadFileCompleted;
				webClient.DownloadFileAsync(uri, pathFile);
			});
			thread.Start();
		}

		private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			BeginInvoke((MethodInvoker)delegate
			{
				double num = double.Parse(e.BytesReceived.ToString());
				double num2 = double.Parse(e.TotalBytesToReceive.ToString());
				double d = num / num2 * 100.0;
				lblproccess.Text = string.Format(Language.GetValue("Đang tải xuô\u0301ng, vui lo\u0300ng chơ\u0300 ({0}%)..."), int.Parse(Math.Truncate(d).ToString()));
				progressBar1.Value = int.Parse(Math.Truncate(d).ToString());
			});
		}

		private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			BeginInvoke((MethodInvoker)delegate
			{
				lblproccess.Text = Language.GetValue("Đang gia\u0309i ne\u0301n file...");
			});
			try
			{
				ZipFile.ExtractToDirectory("./" + Base.softname + "/" + Base.softname + ".zip", "./" + Base.softname + "/");
				BeginInvoke((MethodInvoker)delegate
				{
					Close();
				});
			}
			catch (Exception ex)
			{
				MessageBoxHelper.ShowMessageBox("Error: " + ex.Message, 2);
				BeginInvoke((MethodInvoker)delegate
				{
					Close();
				});
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
			lblproccess.Size = new System.Drawing.Size(215, 16);
			lblproccess.TabIndex = 1;
			lblproccess.Text = "Đang tải xuô\u0301ng, vui lo\u0300ng chơ\u0300 (0%)...";
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
			base.Name = "frm_progress";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "frm_progress";
			base.Load += new System.EventHandler(frm_progress_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
