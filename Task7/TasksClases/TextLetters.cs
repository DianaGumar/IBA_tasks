using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_1.TasksClases
{
    public static class TextLetters
    {

        //static List<string> vowels = new List<string>() { "a", "e", "i", "o", "u" };

        static Dictionary<int, String> vowels = new Dictionary<int, string>
        { [0] = "a", [1] = "e", [2] = "i", [3] = "o", [4] = "u" };
       

    public static float getCountVowels(String word)
        {

            int count = 0;
            //word.ToLower().ToCharArray();

            List<Char> txt = new List<Char>();
            txt.AddRange(word.ToLower().ToCharArray());

            foreach (KeyValuePair<int, string> vowel in vowels)
            {
                for (int i = 0; i < txt.Count; i++)
                {
                    if (txt[i] == char.Parse(vowel.Value))
                    {
                        count++;
                    }
                }

            }

            float prosent = 0;
            if (count != 0) { prosent = (count * 100) / txt.Count; }            

            return prosent;
        }

        //is it realy need?
        public static float getCountVowels(StringBuilder text)
        {
            int count = 0;
            //text.ToString().ToLower().ToCharArray();

            List<Char> txt = new List<Char>();
            txt.AddRange(text.ToString().ToLower().ToCharArray());

            foreach (KeyValuePair<int, string> vowel in vowels)
            {
                for (int i = 0; i < txt.Count; i++)
                {
                    if (txt[i] == char.Parse(vowel.Value))
                    {
                        count++;
                    }
                }

            }

            float prosent = 0;
            if (count != 0) { prosent = (count * 100) / txt.Count; }

            return prosent;
        }

    }
}
