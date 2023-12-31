using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using maxcare;

namespace MCommon
{
	public class Connector
	{
		private static Connector instance;

		private string connectionSTR = "Data Source=" + Base.pathDataBase + "\\database\\db_maxcare.sqlite;Version=3;";

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
				Common.ExportError(ex, "CheckConnectServer");
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
			catch (Exception ex)
			{
				Common.ExportError(null, ex, "ExecuteQuery");
			}
			return dataTable;
		}

		public DataTable ExecuteQuery(List<string> lstQuery)
		{
			DataTable dataTable = new DataTable();
			try
			{
				CheckConnectServer();
				for (int i = 0; i < lstQuery.Count; i++)
				{
					string commandText = lstQuery[i];
					SQLiteCommand cmd = new SQLiteCommand(commandText, connection);
					SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd);
					sQLiteDataAdapter.Fill(dataTable);
				}
			}
			catch (Exception ex)
			{
				Common.ExportError(null, ex, "ExecuteQuery");
			}
			return dataTable;
		}

		public int ExecuteNonQuery(List<string> lstQuery)
		{
			int result = 0;
			try
			{
				CheckConnectServer();
				for (int i = 0; i < lstQuery.Count; i++)
				{
					string commandText = lstQuery[i];
					SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, connection);
					result = sQLiteCommand.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Common.ExportError(null, ex, "ExecuteNonQuery");
			}
			return result;
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
			catch (Exception ex)
			{
				Common.ExportError(null, ex, "ExecuteNonQuery: " + query);
			}
			return result;
		}

		public int ExecuteScalar(string query)
		{
			int result = 0;
			try
			{
				CheckConnectServer();
				SQLiteCommand sQLiteCommand = new SQLiteCommand(query, connection);
				long num = (long)sQLiteCommand.ExecuteScalar();
				result = (int)num;
			}
			catch (Exception ex)
			{
				Common.ExportError(null, ex, "ExecuteScalar: " + query);
			}
			return result;
		}
	}
}
