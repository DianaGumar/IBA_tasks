using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace WebAPI_7915.Models.DAO
{

    //Abstract dao controller
    public abstract class AbstractDAOLAyer<E, K>
    {

        public abstract List<E[]> reed();

        public static MySqlConnection GetConnection(string DBName, string login, string password)
        {
            //str = "Server=localhost;Database=IBA;Uid=root;Pwd=1111";
            string str = "Server=localhost;Database=" + DBName + ";Uid=" + login + ";Pwd=" + password;

            MySqlConnection conn = new MySqlConnection(str);

            return conn;
        }


    }
}
