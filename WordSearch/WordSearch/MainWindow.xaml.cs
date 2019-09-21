using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;
using WordSearch.DictionaryFiles;

namespace WordSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<string> resultsList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            new DictionaryReader();
        }

        /// <summary>
        /// Computes all valid words from input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Compute(object sender, RoutedEventArgs args)
        {
            List<char> inputList = new List<char>();

            foreach (char character in InputTextBox.Text)
            {
                if (character >= 'a' && character <= 'z')
                {
                    inputList.Add(character);
                }
            }
            new Node(inputList);
            ResultsTextBox.Clear();
            ResultsTextBox.Text = String.Join(Environment.NewLine, resultsList);

            inputList.Clear();
            resultsList.Clear();
        }
    }
}
