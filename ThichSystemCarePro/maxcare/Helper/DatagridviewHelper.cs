using System;
using System.Data;
using System.Windows.Forms;
using MCommon;

namespace maxcare.Helper
{
	internal class DatagridviewHelper
	{
		public static void SetStatusDataGridViewWithWait(DataGridView dgv, int row, string colName, int timeWait = 0, string status = "Đơ\u0323i {time} giây...")
		{
			try
			{
				int time_start = Environment.TickCount;
				while ((Environment.TickCount - time_start) / 1000 - timeWait < 0)
				{
					dgv.Invoke((MethodInvoker)delegate
					{
						dgv.Rows[row].Cells[colName].Value = status.Replace("{time}", (timeWait - (Environment.TickCount - time_start) / 1000).ToString());
					});
					MCommon.Common.DelayTime(0.5);
				}
			}
			catch
			{
			}
		}

		public static void SetStatusDataGridViewWithWait(DataGridView dgv, int row, string colName, int timeWait = 0, int timeStart = 0, string status = "Đơ\u0323i {time} giây...")
		{
			try
			{
				int time_start = Environment.TickCount;
				while ((Environment.TickCount - time_start) / 1000 - timeWait < 0)
				{
					dgv.Invoke((MethodInvoker)delegate
					{
						dgv.Rows[row].Cells[colName].Value = status.Replace("{time}", (timeStart - (Environment.TickCount - time_start) / 1000).ToString());
					});
					MCommon.Common.DelayTime(0.5);
				}
			}
			catch
			{
			}
		}

		public static string GetStatusDataGridView(DataGridView dgv, int row, int col)
		{
			string output = "";
			try
			{
				if (dgv.Rows[row].Cells[col].Value != null)
				{
					try
					{
						output = dgv.Rows[row].Cells[col].Value.ToString();
					}
					catch
					{
						dgv.Invoke((MethodInvoker)delegate
						{
							output = dgv.Rows[row].Cells[col].Value.ToString();
						});
					}
				}
			}
			catch
			{
			}
			return output;
		}

		public static string GetStatusDataGridView(DataGridView dgv, int row, string colName)
		{
			string output = "";
			try
			{
				if (dgv.Rows[row].Cells[colName].Value != null)
				{
					try
					{
						output = dgv.Rows[row].Cells[colName].Value.ToString();
					}
					catch
					{
						dgv.Invoke((MethodInvoker)delegate
						{
							output = dgv.Rows[row].Cells[colName].Value.ToString();
						});
					}
				}
			}
			catch
			{
			}
			return output;
		}

		public static void SetStatusDataGridView(DataGridView dgv, int row, int col, object status)
		{
			try
			{
				try
				{
					dgv.Invoke((MethodInvoker)delegate
					{
						dgv.Rows[row].Cells[col].Value = status;
					});
				}
				catch
				{
					dgv.Rows[row].Cells[col].Value = status;
				}
			}
			catch
			{
			}
		}

		public static void SetStatusDataGridView(DataGridView dgv, int row, string colName, object status)
		{
			try
			{
				if (UpdateStatus.isSaveSettings && colName == "cStatus")
				{
					string statusDataGridView = GetStatusDataGridView(dgv, row, "cId");
					UpdateStatus.SetStatusById(statusDataGridView, status.ToString());
				}
				try
				{
					dgv.Invoke((MethodInvoker)delegate
					{
						dgv.Rows[row].Cells[colName].Value = status;
					});
				}
				catch
				{
					dgv.Rows[row].Cells[colName].Value = status;
				}
			}
			catch
			{
			}
		}

		public static void LoadDtgvAccFromDatatable(DataGridView dgv, DataTable tableAccount)
		{
			for (int i = 0; i < tableAccount.Rows.Count; i++)
			{
				DataRow dataRow = tableAccount.Rows[i];
				dgv.Rows.Add(false, dgv.RowCount + 1, dataRow["id"], dataRow["uid"], dataRow["token"], dataRow["cookie1"], dataRow["email"], dataRow["phone"], dataRow["name"], dataRow["follow"], dataRow["friends"], dataRow["groups"], dataRow["birthday"], dataRow["gender"], dataRow["pass"], "", dataRow["passmail"], dataRow["backup"], dataRow["fa2"], dataRow["useragent"], dataRow["proxy"], dataRow["dateCreateAcc"], dataRow["avatar"], dataRow["profile"], dataRow["nameFile"], dataRow["interactEnd"], dataRow["device"], dataRow["info"], dataRow["ghiChu"], UpdateStatus.GetStatusById(dataRow["id"].ToString()));
			}
		}
	}
}
