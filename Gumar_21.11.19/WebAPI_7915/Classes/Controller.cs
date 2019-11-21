using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WebAPI_7915.Classes
{

    //подобие дао слоя
    public abstract class Controller<E, K>
    {

        public abstract List<E> reed(List<E> entity);

        public static MySqlConnection GetConnection()
        {
            String connString = "Server=localhost;Database=IBA;Uid=root;Pwd=1111";

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }


    }
}
