using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Museum
{
    public sealed class DBConnection
    {
        private static DBConnection instance;
        private readonly MySqlCommand cmd;
        private readonly MySqlConnection conn;
        private readonly string connectionParameters = "server = localhost; uid=root;database=mydb";

        private DBConnection()
        {
            conn = new MySqlConnection(connectionParameters);
            cmd = new MySqlCommand();
            cmd.Connection = conn;
        }

        public static DBConnection Instance
        {
            get
            {
                Console.WriteLine("Singleton");
                if (instance == null) instance = new DBConnection();
                return instance;
            }
        }

        public void OpenConn()
        {
            conn.Open();
        }


        public void CloseConn()
        {
            conn.Close();
        }

        public IList<Dictionary<string, string>> Query(string query)
        {
            try
            {
                OpenConn();
                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();
                IList<Dictionary<string, string>> aList = ReaderToDictionary(reader);
                CloseConn();
                return aList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                CloseConn();
                return null;
            }
        }

        //tem de ser long
        public long Execute(string SQLstatement)
        {
            try
            {
                OpenConn();
                cmd.CommandText = SQLstatement;
                cmd.ExecuteNonQuery();
                var id = cmd.LastInsertedId;
                CloseConn();
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                CloseConn();
                return 0;
            }
        }

        private List<Dictionary<string, string>> ReaderToDictionary(MySqlDataReader reader)
        {
            var aList = new List<Dictionary<string, string>>();
            if (reader.HasRows)
                while (reader.Read())
                {
                    var dictionary = new Dictionary<string, string>();
                    for (var i = 0; i < reader.FieldCount; i++)
                        try
                        {
                            dictionary.Add(reader.GetName(i), reader.GetString(reader.GetName(i)));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            dictionary.Add(reader.GetName(i), null);
                        }

                    aList.Add(dictionary);
                }

            return aList;
        }
    }
}