using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using WebAPI_7915.Models;

namespace WebAPI_7915.Controllers
{ 

    //слой подключения
    public class BookDBController: AbstractDBController<Book, String>
    {
        public BookDBController(string sql, string DBName, string login, string password)
        {
            this.sql = sql;
            this.DBName = DBName;
            this.login = login;
            this.password = password;
        }

        public BookDBController(string DBName, string login, string password)
        {
            this.DBName = DBName;
            this.login = login;
            this.password = password;
        }

        string sql;
        string DBName;
        string login;
        string password;


        const string SELECT_WHERE = "SELECT * FROM books WHERE bookPages > 20";
        const string SELECT_BY_ID = "SELECT * FROM books WHERE bookID =";
        const string SELECT_ALL = "SELECT * FROM books";

        public override List<Book> reed(List<Book> entity)
        {
            MySqlConnection connection = GetConnection(DBName, login, password);
            try
            {
                connection.Open();
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

        public List<Book> reed()
        {
            List<Book> entity = new List<Book>();

            MySqlConnection connection = GetConnection(DBName, login, password);
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(SELECT_ALL, connection);

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

        public Book reed(int id)
        {
            Book entity = null;
            MySqlConnection connection = GetConnection(DBName, login, password);
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(SELECT_BY_ID + id, connection);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        entity = new Book(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
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
