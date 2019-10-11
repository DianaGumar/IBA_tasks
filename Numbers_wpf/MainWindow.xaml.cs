using IBA_1.TasksClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Numbers_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void task1(object sender, RoutedEventArgs e)
        {
            textBox_unsver.Text = "";

            //1 vampire number
            List<int> vn = VampireNumber.GetExistVampireNumber(4);
            for (int i = 0; i < vn.Count; i += 3)
            {
                textBox_unsver.Text += vn.ElementAt(i) + " = " + vn.ElementAt(i + 1) + " * " + vn.ElementAt(i + 2) + "\n";
            }

            textBox_task.Text = "1. A vampire number has an even number " +
                "of digits and is formed by multiplying a pair of numbers " +
                "containing half the number of digits of the result. The digits" +
                " are taken from the original number in any order. Pairs of " +
                "trailing zeroes are not allowed. Examples include: 1260 = 21 * " +
                "60 1827 = 21 * 87 2187 = 27 * 81 Write a program that finds all " +
                "the 4-digit vampire numbers";
        }

        private void task2(object sender, RoutedEventArgs e)
        {
            textBox_unsver.Text = "";

            //2 Fibonacci sequence
            int[] fibonacci = FibonacciSequence.getFibonacci(int.Parse(textBox_user.Text));
            for (int i = 0; i < fibonacci.Length; i++)
            {
                textBox_unsver.Text += fibonacci[i] + " ";
            }

            textBox_task.Text = "2.  A Fibonacci sequence is the sequence of numbers" +
                " 1, 1, 2, 3, 5, 8, 13, 21, 34, and so on," +
                " where each number (from the third on) is the" +
                " sum of the previous two. Create a method " +
                "that takes an integer as an argument and " +
                "displays that many Fibonacci numbers starting " +
                "from the beginning, e.g., If you run java Fibonacci " +
                "5 (where Fibonacci is the name of the class) the " +
                "output will be: 1, 1, 2, 3, 5.";

        }
        private void task3(object sender, RoutedEventArgs e)
        {
            // work with words
            //защита от неверного ввода
            textBox_unsver.Text = TextLetters.getCountVowels(textBox_user.Text) + "%";

            textBox_task.Text = "3.Create a Set of the vowels.Count and " +
                "display the number of vowels in each input word, and also " +
                "display the total number of vowels in the input text, percent of each of them.";

        }



    }
}
