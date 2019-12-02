using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Data
    {
        public Data(string DBName, string Login, string Password, string SQL)
        {
            this.DBName = DBName;
            this.Login = Login;
            this.Password = Password;
            this.SQL = SQL;
        }

        public string DBName;
        public string Login;
        public string Password;
        public string SQL;
    }
}
