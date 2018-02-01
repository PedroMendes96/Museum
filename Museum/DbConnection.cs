using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Museum
{
    public sealed class DbConnection
    {
        private static DbConnection _instance;
        private readonly MySqlCommand _cmd;
        private readonly MySqlConnection _conn;
        private readonly string _connectionParameters = "server = localhost; uid=root;database=mydb";

        private DbConnection()
        {
            _conn = new MySqlConnection(_connectionParameters);
            _cmd = new MySqlCommand();
            _cmd.Connection = _conn;
        }

        public static DbConnection Instance => _instance ?? (_instance = new DbConnection());

        public void OpenConn()
        {
            _conn.Open();
        }


        public void CloseConn()
        {
            _conn.Close();
        }

        public IList<Dictionary<string, string>> Query(string query)
        {
            try
            {
                OpenConn();
                _cmd.CommandText = query;
                var reader = _cmd.ExecuteReader();
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

        public int Execute(string sqLstatement)
        {
            try
            {
                OpenConn();
                _cmd.CommandText = sqLstatement;
                _cmd.ExecuteNonQuery();
                var id = _cmd.LastInsertedId;
                CloseConn();
                return (int) id;
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