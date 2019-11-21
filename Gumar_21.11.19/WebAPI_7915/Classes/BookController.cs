using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebAPI_7915.Classes
{

    //слой подключения
    public class BookController: Controller<Book, String>
    {

        public BookController(string sql)
        {
            this.sql = sql;
        }

        string sql;

        public override List<Book> reed(List<Book> entity)
        {
            //todo руализовать пул

            MySqlConnection connection = GetConnection();
            Console.WriteLine("start");
            try
            {
                connection.Open();
                Console.WriteLine("open");
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
