using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WebAPI_7915.Controllers
{

    //Abstract dao controller
    public abstract class AbstractDBController<E, K>
    {

        public abstract E reed(K id); 
        public abstract List<E> reed(); 
        public abstract bool create(E entity);

        public static MySqlConnection GetConnection(string DBName, string login, string password)
        {
            //str = "Server=localhost;Database=IBA;Uid=root;Pwd=1111";
            string str = "Server=localhost;Database=" + DBName + ";Uid=" + login + ";Pwd=" + password;

            MySqlConnection conn = new MySqlConnection(str);

            return conn;
        }


    }
}
