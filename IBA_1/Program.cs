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

            int key;
            

            while (true)
            {
                Console.WriteLine("\n1 - vampire number \n" +
                    "2 - Fibonacci sequence \n");

                key = int.Parse(Console.ReadLine());

                switch (key)
                {
                    case 1:
                            //1 vampire number
                            List<int> vn = VampireNumber.GetExistVampireNumber(4);
                            for (int i = 0; i < vn.Count; i += 3)
                            {
                                Console.Write(vn.ElementAt(i) + " = " + vn.ElementAt(i + 1) + " * " + vn.ElementAt(i + 2) + "\n");
                            }
                            break;

                    case 2:
                            //2 Fibonacci sequence
                            int[] fibonacci = FibonacciSequence.getFibonacci(10);
                            for (int i = 0; i < fibonacci.Length; i++)
                            {
                                Console.Write(fibonacci[i] + " ");
                            }
                            break;

                    case 3:
                        // work with words
                        Console.WriteLine(TextLetters.getCountVowels("uiggddbifsa"));

                        break;

                }
            }





            //Console.ReadLine();

        }
    }
}
