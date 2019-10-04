using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBA_1.TasksClases;

namespace IBA_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 vampire number

            List<int> vn = VampireNumber.GetExistVampireNumber(4);

            for(int i = 0; i < vn.Count; i+=3)
            {
                Console.Write(vn.ElementAt(i) + " = " + vn.ElementAt(i+1) + " * " + vn.ElementAt(i+2) + "\n");
            }

            Console.ReadLine();
        }
    }
}
