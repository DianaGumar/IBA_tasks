using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WebAPI_7915.Models.DAO;

namespace WebAPI_7915.Models.Book
{ 

    //слой подключения
    public class BookDBController: AbstractDBController<Book, int>
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

        private readonly string sql;
        private readonly string DBName;
        private readonly string login; 
        private readonly string password;


        const string SELECT_WHERE = "SELECT * FROM books WHERE bookPages > 20";
        const string SELECT_BY_ID = "SELECT * FROM books WHERE bookID =";
        const string SELECT_ALL = "SELECT * FROM books";


        //need to be initialize string sql
        public List<Book> getWhere()
        {
            List<Book> entity = new List<Book>();

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

        public override List<Book> reed()
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

        public override Book reed(int id)
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

        public override bool create(Book entity)
        {
            int countRowUpdate = 0;
            MySqlConnection connection = GetConnection(DBName, login, password);
            try
            {
                connection.Open();
                MySqlCommand command = 
                    new MySqlCommand("insert into books(bookName, bookPages) " +
                    "values('" + entity.Name + "'," + entity.Pages + ");", connection);

                countRowUpdate = command.ExecuteNonQuery();

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { connection.Close(); }

            if (countRowUpdate != 0) { return true; }
            else return false;
        }
    }
}
