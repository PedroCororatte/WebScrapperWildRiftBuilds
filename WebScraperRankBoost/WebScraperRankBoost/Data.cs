using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace WebScraperRankBoost
{

    public class Data
    {
        public static string tbrsult;
        public static SQLiteConnection dbConnection;
        public static string ConnectionStatus;
        public static void Conect()
        {
            dbConnection = new SQLiteConnection("DataSource = WRDB.sql3");
            if (File.Exists("WRDB.sql3"))
            {
                dbConnection.Open();
            }
            else
            {
                SQLiteConnection.CreateFile("WRDB.sql3");
            }
        }

        public static void Disconnect()
        {

            dbConnection.Close();
        }
        public static void InsertNames(string name)
        {
            string keyName = $"INSERT INTO ITEMS (NAME) VALUES(@param1)";
            
            if (dbConnection == null)
            {
                Conect();
            }
            else
            {
                SQLiteCommand cmd = new SQLiteCommand(keyName, dbConnection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SQLiteParameter("@param1", name));
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertStats(string stats)
        {
            string keyStats = $"INSERT INTO ITEMS (STATS) VALUES(@param2)";
            if (dbConnection == null)
            {
                Conect();
            }
            else
            {
                SQLiteCommand cmd = new SQLiteCommand(keyStats, dbConnection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SQLiteParameter("@param2", stats));
                cmd.ExecuteNonQuery();
            }
        }
    }
}
