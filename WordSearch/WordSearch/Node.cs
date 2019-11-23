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
            if (DictionaryReader.DictionarySearch(Word))
            {
                App.Current.Dispatcher.Invoke((System.Action)delegate
                {
                    MainWindow.resultsList.Add(new ValidWord(Word, MainWindow.resultsList.Count + 1));
                });
            }
            CreateLevel(LetterList);
        }

        private void CreateLevel(List<char> LetterList)
        {
            if (LetterList.Count > 0)
            {
                List<char> TemporaryLetterList;

                foreach (char letter in LetterList.Distinct())
                {
                    TemporaryLetterList = new List<char>(LetterList);
                    TemporaryLetterList.Remove(letter);
                    children.Add(new Node(letter, TemporaryLetterList, Word));

                    // Removes children so they can be handled by garbage collector
                    children.Clear();
                }
            }
        }
    }
}