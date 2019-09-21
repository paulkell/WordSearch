using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordSearch.DictionaryFiles
{
    class DictionaryReader
    {
        private static String[] DictionaryList;
        private static String DictionaryName = "dictionary.txt";

        public DictionaryReader()
        {
            ReadDictionary(DictionaryName);
        }
        private static void ReadDictionary(String DictionaryName)
        {
            DictionaryList = File.ReadAllLines(DictionaryName);
        }

        public static bool DictionarySearch(String Word)
        {
            return Array.BinarySearch(DictionaryList, Word) > 0;
        }
        public static void RemoveWords(List<string> removeList)
        {
            DictionaryList = DictionaryList.Where(word => !removeList.Contains(word)).ToArray();
            File.WriteAllLines(DictionaryName, DictionaryList);
        }
    }
}
