using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    class StringProblem2
    {
        //characters repeated
        String s = "ndjsjuehkjkdjdhebbopsjshwjdkahwbbeohjqnwkiwoowwmahaopqdfbsjcbdkzcbzxkjcbakfbskjcfdqiwyrewyruetreysxhcbzxn";

        public void Repeated()
        {
            Char[] arr = s.ToCharArray();
            Dictionary<Char, Int32> myCustomDictionary = new Dictionary<char, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (myCustomDictionary.ContainsKey(arr[i]))
                {
                    myCustomDictionary[arr[i]]++;
                }
                else
                {
                    myCustomDictionary.Add(arr[i], 1);
                }
            }
            Console.WriteLine("\nResult: ");
            foreach (KeyValuePair<Char, Int32> item in myCustomDictionary)
            {
                Console.WriteLine("Character: {0}, No. of times repeated: {1}", item.Key, item.Value);
            }
        }
    }
}
