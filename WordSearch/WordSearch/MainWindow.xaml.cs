﻿using System;
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
using System.Diagnostics;
using WordSearch.DictionaryFiles;
using System.Collections.ObjectModel;

namespace WordSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<ValidWord> resultsList = new ObservableCollection<ValidWord>();
        public MainWindow()
        {
            InitializeComponent();
            ResultsGrid.ItemsSource = resultsList;
            new DictionaryReader();
        }

        /// <summary>
        /// Listener for InputTextBox
        /// </summary>
        /// <param name="sender">The InputTextBox</param>
        /// <param name="e">The action event</param>
        private void InputTextBoxListener(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                ComputeActions();
            }
        }

        /// <summary>
        /// Listener for Compute button
        /// </summary>
        /// <param name="sender">The compute button</param>
        /// <param name="args">Arguments for the action that has occurred</param>
        private void ComputeListener(object sender, RoutedEventArgs args)
        {
            ComputeActions();
        }

        /// <summary>
        /// Sets UI for processing mode and begins computation
        /// </summary>
        private async void ComputeActions()
        {
            resultsList.Clear();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            StatusBlock.Text = "Status: Processing";
            String input = InputTextBox.Text;
            await Task.Run(() => Compute(input));
            watch.Stop();

            StatusBlock.Text = "Status: " + resultsList.Count() + " results found\n"+"Time elapsed: " + watch.Elapsed;
        }

        /// <summary>
        /// Computes all valid words from input
        /// </summary>
        private void Compute(String input)
        {
            List<char> inputList = new List<char>();

            foreach (char character in input)
            {
                if (character >= 'a' && character <= 'z')
                {
                    inputList.Add(character);
                }
            }
            new Node(inputList);

            inputList.Clear();
        }
        public class ValidWord
        {
            public string Word { get; set; }
            public int Length { get; set; }
            public int Order { get; set; }
        }
    }
}
