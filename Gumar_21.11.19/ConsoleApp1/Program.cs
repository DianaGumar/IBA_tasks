using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//ДЛЯ ПРОВЕРКИ СЕКДИНЕНИЯ С БД

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            String connString = "Server=localhost;Database=IBA;Uid=root;Pwd=1111";
            MySqlConnection connection = new MySqlConnection(connString);

            Console.WriteLine("start");
            try
            {
                connection.Open();
                Console.WriteLine("open");

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { connection.Close(); }

            Console.ReadLine();
        }

    }
}
