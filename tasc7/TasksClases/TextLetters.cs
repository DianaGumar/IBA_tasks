using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_1.TasksClases
{
    public static class TextLetters
    {

        static List<string> vowels = new List<string>() { "a", "e", "i", "o", "u" };

        public static float getCountVowels(String word)
        {
            int count = 0;
            word.ToLower().ToCharArray();

            List<Char> txt = new List<Char>();
            txt.AddRange(word.ToLower().ToCharArray());

            for (int j = 0; j < vowels.Count; j++)
            {

                for (int i = 0; i < txt.Count; i++)
                {
                    if (txt[i] == char.Parse(vowels[j]))
                    {
                        count++;
                    }
                }

            }

            float prosent = (count * 100) / txt.Count;

            return prosent;
        }


        public static float getCountVowels(StringBuilder text)
        {
            int count = 0;
            text.ToString().ToLower().ToCharArray();

            List<Char> txt = new List<Char>();
            txt.AddRange(text.ToString().ToLower().ToCharArray());

            for (int j = 0; j < vowels.Count; j++)
            {

                for (int i = 0; i < txt.Count; i++)
                {
                    if (txt[i] == char.Parse(vowels[j]))
                    {
                        count++;
                    }
                }

            }

            float prosent = (count * 100) / txt.Count;

            return prosent;
        }

    }
}
