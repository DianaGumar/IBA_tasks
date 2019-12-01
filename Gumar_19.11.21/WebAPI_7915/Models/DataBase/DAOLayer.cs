using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WebAPI_7915.Models.DAO;

namespace WebAPI_7915.Models.DataBase
{
    public class DAOLayer : AbstractDAOLAyer<string, int>
    {
        public DAOLayer(string sql, string DBName, string login, string password)
        {

            this.sql = sql;
            this.DBName = DBName;
            this.login = login;
            this.password = password;
        }

        private readonly string sql;
        private readonly string DBName;
        private readonly string login;
        private readonly string password;

        //need to be initialize string sql
        public override List<List<string>> reed()
        {
            List<List<string>> entity = new List<List<string>>();
            

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
                        //добавить возможность считывать больше строк с помощью парсинга sql строки
                        //или нет
                        List<string> inside = new List<string>();
                        inside.Add(reader.GetInt32(0).ToString());
                        inside.Add(reader.GetString(1));
                        inside.Add(reader.GetInt32(2).ToString());

                        entity.Add(inside);
                        //reader.get
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
