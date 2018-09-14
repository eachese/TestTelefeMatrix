using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConection
{
    public class Conection
    {
        SqlConnectionStringBuilder Builder;
        public Conection(string host, string user, string password, string database)
        {
            Builder = new SqlConnectionStringBuilder
            {
                DataSource = host, 
                UserID = user,     
                Password = password,
                InitialCatalog = database
            };
            CreateDataBase(database);
        }

        private void CreateDataBase(string db)
        {
            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                try { 
                connection.Open();
                string sql = "ALTER OR CREATE DATABASE [" + db + "  ]";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }

                StringBuilder sb = new StringBuilder();
                sb.Append("USE " + db + "; ");
                sb.Append("CREATE TABLE Searchs ( ");
                sb.Append(" Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, ");
                sb.Append(" Word VARCHAR(50), ");
                sb.Append(" Result VARCHAR(200) ");
                sb.Append("); ");
                sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
             } catch  (Exception ex)
            {
                // TODO: Call Elmah
                Console.WriteLine(ex.Message);
            }


               
               
            }
        }
        public void InsertNewSearch(string word, string result)
        {

            // INSERT demo
            StringBuilder sb = new StringBuilder();
            string sql = "";

            sb.Append("INSERT Searchs (Word, Result) ");
            sb.Append("VALUES (@word, @result);");
            sql = sb.ToString();
            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@word", word);
                    command.Parameters.AddWithValue("@result", result);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }
        public List<string> GetResult()
        {
            // READ demo
            Console.WriteLine("Reading data from table, press any key to continue...");
            Console.ReadKey(true);
            string sql = "SELECT Id, Word, Result FROM Searchs;";
            List<string> searchResult = new List<string>();
            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchResult.Add(String.Format("{0} {1} {2}", reader.GetString(0), reader.GetString(1), reader.GetString(2)));
                        }
                    }
                }
            }
            return searchResult;
        }
    }
}
