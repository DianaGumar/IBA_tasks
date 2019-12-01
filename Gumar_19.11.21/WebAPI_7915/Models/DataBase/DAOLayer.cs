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

                int fieldCount = reader.FieldCount;

                if (reader.HasRows)
                {
                    List<string> names = new List<string>();

                    for(int i = 0; i < fieldCount; i++)
                    {
                        names.Add(reader.GetName(i));
                    }
                    entity.Add(names);

                    while (reader.Read())
                    {
                        List<string> inside = new List<string>();

                        for (int i = 0; i < fieldCount; i++)
                        {
                            inside.Add(reader.GetValue(i).ToString());
                        }

                        entity.Add(inside);
                        
                    }

                    reader.NextResult();
                }
                reader.Close();

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { connection.Close(); }

            return entity;
        }

    }

}
