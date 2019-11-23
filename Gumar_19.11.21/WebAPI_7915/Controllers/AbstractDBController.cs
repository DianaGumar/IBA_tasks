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

        public abstract List<E> reed(List<E> entity);

        public static MySqlConnection GetConnection(string str)
        {
            str = "Server=localhost;Database=IBA;Uid=root;Pwd=1111";

            MySqlConnection conn = new MySqlConnection(str);

            return conn;
        }


    }
}
