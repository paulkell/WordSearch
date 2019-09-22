using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WordSearch.DictionaryFiles;

namespace WordSearch
{
    class Node
    {
        public List<Node> children = new List<Node>();
        public char data;
        public String Word = "";

        public Node(List<char> LetterList)
        {
            CreateLevel(LetterList);
        }

        private Node(char letter, List<char> LetterList, String ParentWord)
        {
            data = letter;
            Word = ParentWord + data;
            if (DictionaryReader.DictionarySearch(Word) && !MainWindow.resultsList.Contains(Word))
            {
                MainWindow.resultsList.Add(Word);
            }
            CreateLevel(LetterList);
        }

        private void CreateLevel(List<char> LetterList)
        {
            if (LetterList.Count > 0)
            {
                List<char> TemporaryLetterList;

                for (int i = 0; i < LetterList.Count; i++)
                {
                    TemporaryLetterList = new List<char>(LetterList.ToArray());
                    TemporaryLetterList.RemoveAt(i);
                    children.Add(new Node(LetterList[i], TemporaryLetterList, Word));
                }
            }
        }
    }
}
