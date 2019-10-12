using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.TasksClases
{
    public static class VampireNumber
    {
        //todo переписать комменты на английском

        /*
         1. Число вампира имеет четное число цифр и формируется путем умножения пары чисел, 
         содержащих половину числа цифр результата. Цифры берутся из исходного номера в 
         любом порядке. Пары трейлинг-нулей не допускаются. Примеры включают в себя: 
         1260 = 21 * 60 1827 = 21 * 87 2187 = 27 * 81 напишите программу, которая находит 
         все 4-значные числа вампиров
         */

        // 1000 - 9999

        // что использовать github or bitbucket?

        /// <summary>
        /// вычисляет все числа вампиров в пределах разряда
        /// </summary>
        /// <param name="itemsCount"></param>
        /// <returns>List</returns>
        public static List<int> GetExistVampireNumber(int itemsCount /*количество знаков в числе*/)
        {
            //проверка на чётность 
            if (itemsCount % 2 != 0) { itemsCount++; }

            List<int> existVampire = new List<int>();
            int[] iMs = new int[itemsCount];
            
            int i, end = (int)Math.Pow(10, itemsCount);
            for (i = (int)Math.Pow(10, itemsCount - 1); i < end; i++){
                
                //получаем массив цифр числа
                 iMs = GetNumberParts(i);
                //список всех пар цифр числа
                List<int> pairs = GetNumberTwoVariants(iMs);
                //перемножаем и сравниваем с i
                
                //второй метод
                int[] par = IsRealMakeVimpireNumber(i, pairs, iMs);

                if (par[0] != 0 && par[1] != 0 )
                {
                    existVampire.Add(i);
                    existVampire.Add(par[0]);
                    existVampire.Add(par[1]);
                }

            }
            return existVampire;
        }


        /// <summary>
        /// работает из мат утверждения для любого числа:
        /// 1573 = 3*100 + 7*101 + 5*102 + 1*103.
        /// </summary>
        /// <param name="x"></param>
        /// <returns>массив из цифр числа от едениц к десяткам+</returns>
        public static int[] GetNumberParts(int x)
        {
            int i = x.ToString().Length;
            int[] ans = new int[i];

            while(i > 0)
            {
                ans[i-1] = x / (int)Math.Pow(10, i-1);
                x = x - ans[i-1] * (int)Math.Pow(10, i-1);

                i--;
            }

            return ans;
        }

        /// <summary>
        /// находит все возможные пары из цифр числа
        /// </summary>
        /// <param name="iMs"></param>
        /// <returns>List</returns>
        public static List<int> GetNumberTwoVariants(int[] iMs)
        {
            int j, jj;

            //список всех пар обьектов
            List<int> pairs = new List<int>();
            for (j = 0; j < iMs.Length; j++)
            {
                //составляю различные пары чисел в массиве
                //4321  1 2 3 4    12 13 14   21 23 24   31 32 34  41 42 43
                //321 1 2 3   32 31  23 21  13 12
                for (jj = 0; jj < iMs.Length; jj++)
                {
                    if (j != jj) { pairs.Add(iMs[j] * 10 + iMs[jj]); }
                }
            }

            return pairs;
        }

        /// <summary>
        /// является ли число числом-вампиром
        /// </summary>
        /// <param name="pairs"></param>
        /// <param name="i"></param>
        /// <returns>bool</returns>
        public static Boolean IsRealMakeVimpireNumber(List<int> pairs, int i)
        {
            int j, jj;

            for (j = 0; j < pairs.Count; j++)
            {
                for (jj = j + 1; jj < pairs.Count; jj++)
                {
                    if (pairs.ElementAt(j) * pairs.ElementAt(jj) == i)
                    {
                        //место ошибки при работе с разрядами != 4
                        if (!(pairs.ElementAt(j)%10 == 0 && pairs.ElementAt(jj) % 10 == 0))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// проверяет действительно ли число является числом-вампиром
        /// </summary>
        /// <param name="i"></param>
        /// <param name="pairs"></param>
        /// <param name="iMs"></param>
        /// <returns></returns>
        public static int[] IsRealMakeVimpireNumber(int i,List<int> pairs, int[] iMs)
        {
            int j, jj;
            int[] par = new int[] { 0 , 0 };

            for (j = 0; j < pairs.Count; j++)
            {
                for (jj = j + 1; jj < pairs.Count; jj++)
                {
                    if (pairs.ElementAt(j) * pairs.ElementAt(jj) == i)
                    {
                        //место ошибки при работе с разрядами != 4
                        //проверка на двойственность нулей
                        if (!(pairs.ElementAt(j) % 10 == 0 && pairs.ElementAt(jj) % 10 == 0))
                        {
                            //4321  1 2 3 4    12 13 14   21 23 24   31 32 34  41 42 43
                            //8918 = 98 * 91

                            //получаем два массива, упорядочиваем и сравниваем их= если не равны- не пропускаем
                            int[] iMs_pairs = ArrayAppend(pairs.ElementAt(j), pairs.ElementAt(jj));
                           
                            //сортировка двух массивов через метод sort by list
                            iMs_pairs = ArraySort(iMs_pairs);
                            iMs = ArraySort(iMs);

                            //если массивы равны- метод завершает работу
                            if (iMs.SequenceEqual(iMs_pairs))
                            {
                                par = new int[] { pairs.ElementAt(j), pairs.ElementAt(jj) };
                                return par;
                            }
 
                        }
                    }
                }
            }

            return par;
        }

        /// <summary>
        /// сортирует через встроенную функцию списка
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int[] ArraySort(int[] x)
        {
            List<int> list = new List<int>();
            list.AddRange(x);
            list.Sort();

            return list.ToArray();
        }

        /// <summary>
        /// преобразует числа в массивы и соединяет в один
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int[] ArrayAppend(int a, int b)
        {
            int[] c = new int[a.ToString().Length * 2];

            int[] aa = GetNumberParts(a);
            int[] bb = GetNumberParts(b);

            for (int z = 0, k = 0; z < aa.Length * 2; z++)
            {
                if (z < aa.Length) { c[z] = aa[z]; }
                else { c[z] = bb[k]; k++; }
            }


            return c;
        }



    }
}
