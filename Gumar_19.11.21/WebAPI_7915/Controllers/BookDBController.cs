using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using WebAPI_7915.Classes;

namespace WebAPI_7915.Controllers
{ 

    //слой подключения
    public class BookDBController: AbstractDBController<Book, String>
    {

        public BookDBController(string sql, string connectStr)
        {
            this.sql = sql;
            this.connectStr = connectStr;
        }

        string sql;
        string connectStr;


        public override List<Book> reed(List<Book> entity)
        { 
            MySqlConnection connection = GetConnection(this.connectStr);
            try
            {
                connection.Open();
                string sql = this.sql;
                MySqlCommand command = new MySqlCommand(sql, connection);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        entity.Add(new Book(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                    }
                }
                reader.Close();
        
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { connection.Close(); }

            return entity;

        }

    }
}
