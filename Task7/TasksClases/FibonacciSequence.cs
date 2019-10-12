using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_1.TasksClases
{
    public static class FibonacciSequence
    {
        public static int[] getFibonacci(int count)
        {
            count = Math.Abs(count);

            int[] fibonacci = new int[count];

            for(int i = 0; i < count; i++)
            {

                if (i >= 2) { fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2]; }
                else fibonacci[i] = 1;
                
            }

            return fibonacci;
        }


    }
}
