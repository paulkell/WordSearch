//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;

//namespace WordSearchCS
//{
//    class WordSearch
//    {
//        public static String[] DictionaryList;

//        static void Main(string[] args)
//        {

//            List<char> LetterList = new List<char>();
//            String FileName = "dictionary.txt";

//            var t = Task.Run(() => GetInput(LetterList));
//            var s = Task.Run(() => ReadDictionary(FileName));

//            t.Wait();
//            new Node(LetterList);

//            Console.WriteLine("Press any key to end program...");
//            Console.ReadKey();
//        }

//        public static void GetInput(List<char> LetterList)
//        {
//            char input = ' ';
//            Console.Write("Enter characters: ");
//            do
//            {
//                input = (char)Console.Read();
//                if (input >= 'a' && input <= 'z')
//                {
//                    LetterList.Add(input);
//                }
//            } while (input >= 'a' && input <= 'z');
//        }

//        public static void ReadDictionary(String FileName)
//        {
//            DictionaryList = File.ReadAllLines(FileName);
//        }

//        public static bool DictionarySearch(String Word)
//        {
//            return Array.BinarySearch(DictionaryList, Word) > 0;
//        }
//    }

//class Node
//{
//    public List<Node> children = new List<Node>();
//    public char data;
//    public String Word = "";

//    public Node(List<char> LetterList)
//    {
//        CreateLevel(LetterList);
//    }

//    private Node(char letter, List<char> LetterList, String ParentWord)
//    {
//        data = letter;
//        Word = ParentWord + data;
//        if (WordSearch.DictionarySearch(Word))
//        {
//            Console.WriteLine(Word);
//        }
//        CreateLevel(LetterList);
//    }

//    private void CreateLevel(List<char> LetterList)
//    {
//        if (LetterList.Count > 0)
//        {
//            List<char> TemporaryLetterList;

//            for (int i = 0; i < LetterList.Count; i++)
//            {
//                TemporaryLetterList = new List<char>(LetterList.ToArray());
//                TemporaryLetterList.RemoveAt(i);
//                children.Add(new Node(LetterList[i], TemporaryLetterList, Word));
//            }
//        }
//    }

//    public void ShowChildren()
//    {
//        foreach (Node child in children)
//        {
//            Console.Write(child.data + " ");
//        }
//        Console.WriteLine();
//    }
//}
//}