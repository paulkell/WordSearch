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
            ReadDictionaryFromFile(DictionaryName);
        }

        /// <summary>
        /// Initializes internal dictionary from input file
        /// </summary>
        /// <param name="DictionaryName">The dictionary file to be read</param>
        private static void ReadDictionaryFromFile(String DictionaryName)
        {
            DictionaryList = File.ReadAllLines(DictionaryName);
        }

        /// <summary>
        /// Searches dictionary for input word
        /// </summary>
        /// <param name="Word">The word to be searched for in dictionary</param>
        /// <returns></returns>
        public static bool DictionarySearch(String Word)
        {
            return Array.BinarySearch(DictionaryList, Word) > 0;
        }

        /// <summary>
        /// Removes all words in input list from dictionary
        /// </summary>
        /// <param name="removeList">A list of words to be removed from dictionary</param>
        public static void RemoveWords(List<string> removeList)
        {
            DictionaryList = DictionaryList.Where(word => !removeList.Contains(word)).ToArray();
            OverwriteDictionaryFile();
        }

        /// <summary>
        /// Adds all words in input list to dictionary
        /// </summary>
        /// <param name="addList">A list of words to be added to dictionary</param>
        public static void AddWords(List<string> addList)
        {
            int locationIndex;

            foreach (String Word in addList)
            {
                locationIndex = Array.BinarySearch(DictionaryList, Word);
                if(locationIndex >= 0)
                {
                    //DictionaryList already contains this word
                    continue;
                }
                else
                {
                    locationIndex = ~locationIndex;
                    string[] beforeIndex = new string[locationIndex];
                    string[] afterIndex = new string[DictionaryList.Length - locationIndex];

                    Array.Copy(DictionaryList, 0, beforeIndex, 0, locationIndex);
                    Array.Copy(DictionaryList, locationIndex, afterIndex, 0, DictionaryList.Length - locationIndex);

                    List<string> temp = beforeIndex.Append(Word).ToList();
                    temp.AddRange(afterIndex.ToList());
                    DictionaryList = temp.ToArray();
                }
            }

            OverwriteDictionaryFile();
        }

        /// <summary>
        /// Overwrites dictionary file with internal dictionary
        /// </summary>
        private static void OverwriteDictionaryFile()
        {
            File.WriteAllLines(DictionaryName, DictionaryList);
        }
    }
}
