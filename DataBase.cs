using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ISAccounting
{
    
    public class DataBase : DbContext
    {
        public static string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        private SqliteConnection connection = new SqliteConnection(@"Data Source=" + DataBase.strExeFilePath.Substring(0, strExeFilePath.Length-10) + @"\post.sqlite");
        
        // если не заводится бд, то вставить путь строчкой ниже, и убрать верхнюю строчку вообще
        // private SqliteConnection connection = new SqliteConnection(@"Data Source=C:\какая-тоЕщеПапка\post.sqlite");

        
        public DataBase()
        {
            connection.Open();
        }

        public SqliteDataReader GetReader(string cmdText)
        {
            var command = connection.CreateCommand();
            command.CommandText = cmdText;

            return command.ExecuteReader();
        }

        public void ExecuteNonQuery(string cmdText)
        {
            var command = connection.CreateCommand();
            command.CommandText = cmdText;
            command.ExecuteNonQuery();
        }
    }
}