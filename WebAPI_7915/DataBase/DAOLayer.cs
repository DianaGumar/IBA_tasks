using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WebAPI_7915.Models.DAO;

namespace WebAPI_7915.Models.DataBase
{
    public class DAOLayer : AbstractDAOLAyer<Object, int>
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

        public override List<Object[]> reed()
        {
            List<Object[]> entity = new List<Object[]>();
            
            MySqlConnection connection = GetConnection(DBName, login, password);
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Object[] names = new Object[reader.FieldCount];

                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        names[i] = reader.GetName(i);
                    }
                    entity.Add(names);

                    while (reader.Read())
                    {
                        Object[] inside = new Object[reader.FieldCount];
                        reader.GetValues(inside);
                        entity.Add(inside);
                        
                    }

                    reader.NextResult();
                }
                reader.Close();

            }
            catch (Exception e) 
            {
                //MessageBox.Show();
                Console.WriteLine(e.Message); 
            }
            finally { connection.Close(); }

            return entity;
        }

    }

}
