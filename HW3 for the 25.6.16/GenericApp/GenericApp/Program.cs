using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var englishJapaneseDictionary = new MultiDictionary<int, string> ();

            Console.WriteLine("Testing counter: MultiDictionary has {0} values.", englishJapaneseDictionary.Count);

            Console.WriteLine();
            Console.WriteLine("Initial values:");
            englishJapaneseDictionary.Add(1, "one");
            englishJapaneseDictionary.Add(2, "two");
            englishJapaneseDictionary.Add(3, "three");
            englishJapaneseDictionary.Add(1, "ice");
            englishJapaneseDictionary.Add(2, "nee");
            englishJapaneseDictionary.Add(3, "sun");
            englishJapaneseDictionary.PrintDictionary();

            Console.WriteLine();
            Console.WriteLine("Testing Add \"tres\" and \"trois\" to key number 3:");
            englishJapaneseDictionary.Add(3,"tres");
            englishJapaneseDictionary.Add(3, "trois");
            englishJapaneseDictionary.PrintDictionary();

            Console.WriteLine();
            Console.WriteLine("Testing Remove with 1 and 2 parameters, removing value \"three\" and all values at key number 2:");
            englishJapaneseDictionary.Remove(3,"three");
            englishJapaneseDictionary.Remove(2);
            englishJapaneseDictionary.PrintDictionary();
            Console.WriteLine("Testing Remove when there is nothing to remove- same parameters as before:");
            Console.WriteLine(englishJapaneseDictionary.Remove(3, "three"));
            Console.WriteLine(englishJapaneseDictionary.Remove(2));

            Console.WriteLine();
            Console.WriteLine("Testing counter: MultiDictionary has {0} values.", englishJapaneseDictionary.Count);

            Console.WriteLine();
            Console.WriteLine("Testing Contains \"ice\" at key number 1:");
            Console.WriteLine(englishJapaneseDictionary.Contains(1, "ice"));
            Console.WriteLine("Testing Contains \"ice\" at key number 3:");
            Console.WriteLine(englishJapaneseDictionary.Contains(3, "ice"));
            Console.WriteLine("Testing ContainsKey 3:");
            Console.WriteLine(englishJapaneseDictionary.ContainsKey(3));
            Console.WriteLine("Testing ContainsKey 2:");
            Console.WriteLine(englishJapaneseDictionary.ContainsKey(2));

            Console.WriteLine();
            Console.WriteLine("Testing Clear:");
            englishJapaneseDictionary.Clear();
            Console.WriteLine("Printing Table:");
            englishJapaneseDictionary.PrintDictionary();
            Console.WriteLine("Testing counter: MultiDictionary has {0} values.", englishJapaneseDictionary.Count);
        }
    }
}
