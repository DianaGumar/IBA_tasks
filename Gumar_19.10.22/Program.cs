using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gumar_List_22._10._19
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> temperatures = new List<int>() { 10, 12, -2, 0, 30, 26, 18};

            int countSomeTemp = 0;
            foreach(int temp in temperatures)
            {
                if(temp >= 25) { countSomeTemp++; }
            }
            Console.WriteLine(countSomeTemp);

            Console.WriteLine(GreaterCount(temperatures, 12));

            Console.ReadLine();
  

        }

        static int GreaterCount (List<int> list, double min)
        {
            int k = 0;

            foreach (double i in list)
            {
                if (i >= min) { k++; }
            }

            return k;
        }
    }
}
