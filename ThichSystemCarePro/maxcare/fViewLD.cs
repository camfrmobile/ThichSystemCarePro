using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SystemCarePro.Helper;
using maxcare.Helper;
using maxcare.Properties;
using MCommon;

namespace maxcare
{
	public class fViewLD : Form
	{
		public bool isRunSwap = false;

		private object lock_listPanel = new object();

		public int[] LDSize = new int[6] { 240, 360, -1, -36, 240, 395 };

		public static fViewLD remote;

		private IContainer components = null;

		private ToolTip toolTip1;

		private FlowLayoutPanel panelListDevice;

		public fViewLD()
		{
			InitializeComponent();
			remote = this;
		}

		public void AddLDIntoPanel(IntPtr MainWindowHandle, int indexDevice, int sttTaiKhoan)
		{
			try
			{
				Control control = (from Control h in panelListDevice.Controls
					where h.Tag.Equals(indexDevice)
					select h).FirstOrDefault();
				if (control == null)
				{
					control = (from Control h in panelListDevice.Controls
						where h.Tag.Equals(-1)
						select h).FirstOrDefault();
					UpdateInfoPanelDevice(control, indexDevice, sttTaiKhoan);
					Application.DoEvents();
				}
				Invoke((MethodInvoker)delegate
				{
					User32Helper.SetParent(MainWindowHandle, control.Handle);
					User32Helper.MoveWindow(MainWindowHandle, LDSize[2], LDSize[3], LDSize[4], LDSize[5], repaint: true);
				});
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "AddLDIntoPanel");
			}
		}

		public void RemovePanelDevice(int indexDevice)
		{
			try
			{
				ADBHelper.QuitDevice(ConfigHelper.GetPathLDPlayer(), indexDevice);
				LoadStatus(indexDevice, "");
				LoadHanhDong(indexDevice, "");
				HidePicTurnOffDevice(indexDevice);
				if (!isRunSwap)
				{
					Control control = panelListDevice.Controls["dv" + indexDevice];
					UpdateInfoPanelDevice(control, -1);
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "RemovePanelDevice");
			}
		}

		public void AddPanelDevice(int deviceIndex)
		{
			try
			{
				if (!isRunSwap)
				{
					deviceIndex = -1;
				}
				Panel panel = new Panel();
				panel.Name = "dv" + deviceIndex;
				panel.Tag = deviceIndex;
				panel.Size = new Size(LDSize[0], LDSize[1] + 60);
				panel.BackColor = Color.White;
				panel.BorderStyle = BorderStyle.FixedSingle;
				string text = "";
				text = ((deviceIndex != -1) ? ("LDPlayer-" + deviceIndex) : "LDPlayer-None");
				Label label = new Label
				{
					Text = text,
					Location = new Point(0, LDSize[1]),
					Size = new Size(LDSize[0] - 55, 20),
					BackColor = Color.White,
					BorderStyle = BorderStyle.None,
					ForeColor = Color.Black,
					Name = (deviceIndex.ToString() ?? ""),
					AutoSize = false
				};
				panel.Controls.Add(label);
				label.DoubleClick += CheckDevice;
				Label value = new Label
				{
					Text = ">",
					Location = new Point(0, LDSize[1] + 20),
					Size = new Size(LDSize[0], 20),
					BackColor = Color.White,
					BorderStyle = BorderStyle.None,
					ForeColor = Color.Black,
					Name = (deviceIndex.ToString() ?? ""),
					AutoSize = false
				};
				panel.Controls.Add(value);
				Label value2 = new Label
				{
					Text = "",
					Location = new Point(0, LDSize[1] + 40),
					Size = new Size(LDSize[0], 20),
					BackColor = Color.White,
					BorderStyle = BorderStyle.None,
					ForeColor = Color.Black,
					Name = (deviceIndex.ToString() ?? ""),
					AutoSize = false
				};
				panel.Controls.Add(value2);
				PictureBox pictureBox = new PictureBox
				{
					Image = Resources.icons8_multiply_20px,
					Location = new Point(LDSize[0] - 25, LDSize[1]),
					Name = (deviceIndex.ToString() ?? ""),
					Size = new Size(20, 20),
					Cursor = Cursors.Hand,
					Visible = false
				};
				pictureBox.Click += TurnOffDevice;
				panel.Controls.Add(pictureBox);
				toolTip1.SetToolTip(pictureBox, "Close");
				PictureBox pictureBox2 = new PictureBox
				{
					Image = Resources.icons8_undo_20px,
					Location = new Point(LDSize[0] - 50, LDSize[1]),
					Name = (deviceIndex.ToString() ?? ""),
					Size = new Size(20, 20),
					Cursor = Cursors.Hand,
					Visible = false
				};
				pictureBox2.Click += Back;
				panel.Controls.Add(pictureBox2);
				toolTip1.SetToolTip(pictureBox2, "Back");
				PictureBox pictureBox3 = new PictureBox
				{
					Image = Resources.iconmin,
					SizeMode = PictureBoxSizeMode.Zoom,
					Location = new Point(0, -30),
					Name = "pictureBoxLogo",
					Size = new Size(LDSize[0], LDSize[1] + 60),
					TabIndex = 0,
					TabStop = false
				};
				pictureBox3.BringToFront();
				panel.Controls.Add(pictureBox3);
				lock (lock_listPanel)
				{
					panelListDevice.Invoke((MethodInvoker)delegate
					{
						panelListDevice.Controls.Add(panel);
					});
				}
				for (int i = 0; i < 5; i++)
				{
					if (panelListDevice.Controls["dv" + deviceIndex] != null)
					{
						break;
					}
					Thread.Sleep(1000);
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "AddPanelDevice");
			}
		}

		public void UpdateInfoPanelDevice(Control control, int deviceIndex, int sttTaiKhoan = 0)
		{
			try
			{
				control.Invoke((MethodInvoker)delegate
				{
					control.Name = "dv" + deviceIndex;
					control.Tag = deviceIndex;
					if (deviceIndex == -1)
					{
						control.Controls[0].Text = "LDPlayer-None";
					}
					else
					{
						control.Controls[0].Text = "LDPlayer-" + deviceIndex;
					}
					if (sttTaiKhoan > 0)
					{
						Control control2 = control.Controls[0];
						control2.Text = control2.Text + ": Ta\u0300i khoa\u0309n " + sttTaiKhoan;
					}
					control.Controls[0].Name = deviceIndex.ToString();
					control.Controls[1].Name = deviceIndex.ToString();
					control.Controls[2].Name = deviceIndex.ToString();
					control.Controls[3].Name = deviceIndex.ToString();
				});
			}
			catch
			{
			}
		}

		public void UpdateDeviceIdForBackButton(int deviceIndex, string deviceId)
		{
			try
			{
				Control control = (from Control h in panelListDevice.Controls
					where h.Tag.Equals(deviceIndex)
					select h).FirstOrDefault();
				if (control != null)
				{
					control.Invoke((MethodInvoker)delegate
					{
						control.Controls[4].Name = deviceId;
					});
					Application.DoEvents();
				}
			}
			catch
			{
			}
		}

		public bool CheckExistPanelDevice(int indexDevice)
		{
			return (from Control h in panelListDevice.Controls
				where h.Tag.Equals(indexDevice)
				select h).Count() == 1;
		}

		public void LoadStatus(int indexDevice, string content)
		{
			try
			{
				Application.DoEvents();
				if (content.Trim() != "")
				{
					content = content.Replace("\"", "");
					content += (content.EndsWith("...") ? "" : "...");
				}
				panelListDevice.Invoke((MethodInvoker)delegate
				{
					panelListDevice.Controls["dv" + indexDevice].Controls[2].Text = content;
				});
				Application.DoEvents();
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "LoadStatus");
			}
		}

		public void LoadHanhDong(int indexDevice, string content)
		{
			try
			{
				Application.DoEvents();
				if (content.Trim() != "")
				{
					content = content.Replace("\"", "");
					content += (content.EndsWith("...") ? "" : "...");
				}
				panelListDevice.Invoke((MethodInvoker)delegate
				{
					panelListDevice.Controls["dv" + indexDevice].Controls[1].Text = ">" + content;
				});
				LoadStatus(indexDevice, "");
				Application.DoEvents();
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "LoadHanhDong");
			}
		}

		private void Back(object sender, EventArgs e)
		{
			try
			{
				string name = (sender as PictureBox).Name;
				ADBHelper.RunCMD(name, "shell input keyevent 4");
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "Back");
			}
		}

		private void TurnOffDevice(object sender, EventArgs e)
		{
			try
			{
				int indexDevice = Convert.ToInt32((sender as PictureBox).Name);
				RemovePanelDevice(indexDevice);
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "TurnOffDevice");
			}
		}

		private void CheckDevice(object sender, EventArgs e)
		{
			try
			{
				int indexDevice = Convert.ToInt32((sender as Label).Name);
				ExportLog(indexDevice);
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "CheckDevice");
			}
		}

		public void ExportLog(int indexDevice, string activity = "", string html = "", string folderPath = "")
		{
			try
			{
				string text = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
				string text2 = indexDevice + "_" + text;
				if (folderPath == "")
				{
					folderPath = "CheckDevice";
				}
				MCommon.Common.CreateFolder(folderPath);
				MCommon.Common.CreateFolder(folderPath + "\\" + indexDevice);
				string deviceByIndex = ADBHelper.GetDeviceByIndex(indexDevice);
				if (deviceByIndex != "")
				{
					ADBHelper.ScreenShot(deviceByIndex, folderPath + "\\" + indexDevice + "\\" + text2 + ".png");
					File.AppendAllText(folderPath + "\\" + indexDevice + "\\" + text2 + ".txt", panelListDevice.Controls["dv" + indexDevice].Controls[1].Text + "\r\n");
					if (activity == "")
					{
						activity = ADBHelper.DumpActivity(deviceByIndex).Split('{', '}')[1].Split(' ')[2];
					}
					File.AppendAllText(folderPath + "\\" + indexDevice + "\\" + text2 + ".txt", activity + "\r\n");
					if (html == "")
					{
						html = ADBHelper.GetXML(deviceByIndex);
					}
					File.AppendAllText(folderPath + "\\" + indexDevice + "\\" + text2 + ".txt", html);
				}
			}
			catch
			{
			}
		}

		public void ShowPicTurnOffDevice(int indexDevice, string deviceId)
		{
			try
			{
				Invoke((MethodInvoker)delegate
				{
					panelListDevice.Controls["dv" + indexDevice].Controls[3].Visible = true;
					panelListDevice.Controls["dv" + indexDevice].Controls[4].Visible = true;
					panelListDevice.Controls["dv" + indexDevice].Controls[4].Name = deviceId;
				});
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "ShowPicTurnOffDevice");
			}
		}

		public void HidePicTurnOffDevice(int indexDevice)
		{
			try
			{
				Invoke((MethodInvoker)delegate
				{
					panelListDevice.Controls["dv" + indexDevice].Controls[3].Visible = false;
					panelListDevice.Controls["dv" + indexDevice].Controls[4].Visible = false;
				});
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "HidePicTurnOffDevice");
			}
		}

		private void fViewChrome_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				foreach (Panel control in panelListDevice.Controls)
				{
					int indexDevice = Convert.ToInt32(control.Name.Replace("dv", ""));
					RemovePanelDevice(indexDevice);
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "fViewChrome_FormClosing");
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fViewLD));
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			panelListDevice = new System.Windows.Forms.FlowLayoutPanel();
			SuspendLayout();
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 5000;
			toolTip1.InitialDelay = 0;
			toolTip1.ReshowDelay = 100;
			toolTip1.ShowAlways = true;
			panelListDevice.AutoScroll = true;
			panelListDevice.BackColor = System.Drawing.Color.White;
			panelListDevice.Dock = System.Windows.Forms.DockStyle.Fill;
			panelListDevice.Location = new System.Drawing.Point(0, 0);
			panelListDevice.Name = "panelListDevice";
			panelListDevice.Padding = new System.Windows.Forms.Padding(10);
			panelListDevice.Size = new System.Drawing.Size(1044, 441);
			panelListDevice.TabIndex = 2;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1044, 441);
			base.Controls.Add(panelListDevice);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fViewLD";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "View LDPlayer - MIN SOFTWARE";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(fViewChrome_FormClosing);
			ResumeLayout(false);
		}
	}
}
