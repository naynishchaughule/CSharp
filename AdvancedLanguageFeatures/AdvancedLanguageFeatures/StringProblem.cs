using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    class StringProblem
    {
        public void Work()
        {
            Boolean formed = false;
            String super = "sujfjkdkdajhs";
            Char[] superChar = super.ToCharArray();
            String my = "suhas";
            Dictionary<Char, Int32> find = new Dictionary<char, int>();
            Char[] ch = my.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (find.ContainsKey(ch[i]))
                {
                    find[ch[i]]++;
                }
                else
                {
                    find.Add(ch[i], 1);
                }
            }

            for (int i = 0; i < superChar.Length; i++)
            {
                if (find.ContainsKey(superChar[i]))
                {
                    if (find[superChar[i]] > 0)
                    {
                        find[superChar[i]]--;
                    }
                }
            }

            foreach (KeyValuePair<Char, Int32> item in find)
            {
                if (item.Value != 0)
                {
                    formed = false;
                    break;
                }
                else
                    formed = true;
            }

            if (formed)
            {
                Console.WriteLine("\npermutation possible");
            }
            else
            {
                Console.WriteLine("\npermutation NOT possible");
            }
        }
    }
}
