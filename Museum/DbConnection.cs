using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Museum
{
    internal class DBConnection
    {
        private readonly string connectionParameters = "server = localhost; uid=root;database=mydb";
        private readonly MySqlCommand cmd;
        private readonly MySqlConnection conn;

        public DBConnection()
        {
            conn = new MySqlConnection(connectionParameters);
            cmd = new MySqlCommand();
            cmd.Connection = conn;
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
            OpenConn();
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();
            IList<Dictionary<string, string>> aList = ReaderToDictionary(reader);
            CloseConn();
            return aList;
        }

        //tem de ser long
        public void Execute(string SQLstatement)
        {
            OpenConn();
            cmd.CommandText = SQLstatement;
            cmd.ExecuteNonQuery();
            CloseConn();
        }

        private List<Dictionary<string, string>> ReaderToDictionary(MySqlDataReader reader)
        {
            var aList = new List<Dictionary<string, string>>();
            if (reader.HasRows)
                while (reader.Read())
                {
                    var dictionary = new Dictionary<string, string>();
                    for (var i = 0; i < reader.FieldCount; i++)
                        dictionary.Add(reader.GetName(i), reader.GetString(reader.GetName(i)));
                    aList.Add(dictionary);
                }

            return aList;
        }
    }
}