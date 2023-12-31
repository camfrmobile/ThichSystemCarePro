using System;
using System.Data;
using System.Data.SQLite;
using MCommon;

namespace maxcare.KichBan
{
	public class Connector
	{
		private static Connector instance;

		private string connectionSTR = "Data Source=interact\\interact.sqlite;Version=3;";

		private SQLiteConnection connection = null;

		public static Connector Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Connector();
				}
				return instance;
			}
			private set
			{
				instance = value;
			}
		}

		private Connector()
		{
		}

		private void CheckConnectServer()
		{
			try
			{
				if (connection == null)
				{
					connection = new SQLiteConnection(connectionSTR);
				}
				if (connection.State == ConnectionState.Closed)
				{
					connection.Open();
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "CheckConnectServer");
			}
		}

		public DataTable ExecuteQuery(string query)
		{
			DataTable dataTable = new DataTable();
			try
			{
				CheckConnectServer();
				SQLiteCommand cmd = new SQLiteCommand(query, connection);
				SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd);
				sQLiteDataAdapter.Fill(dataTable);
			}
			catch
			{
			}
			return dataTable;
		}

		public int ExecuteNonQuery(string query)
		{
			int result = 0;
			try
			{
				CheckConnectServer();
				SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
				result = sQLiteCommand.ExecuteNonQuery();
			}
			catch
			{
			}
			return result;
		}

		public int ExecuteScalar(string query)
		{
			int result = -1;
			try
			{
				CheckConnectServer();
				SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
				long num = (long)sQLiteCommand.ExecuteScalar();
				result = (int)num;
			}
			catch
			{
			}
			return result;
		}
	}
}
