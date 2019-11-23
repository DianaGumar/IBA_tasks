using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gumar_5_17._10._19
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 5.Look up the Iterator in the documentation. 
               Develop own Iterator, that can work with Collection data types*/


            DataTipes<string> str = new DataTipes<string>(new string[]{ "a","b","c"});

            foreach(string s in str)
            {
                Console.WriteLine(s + " ");
            }


            Console.ReadLine();

        }
    }
}
