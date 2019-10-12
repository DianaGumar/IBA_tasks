using Task7.TasksClases;
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

        private int ValidInspector(String str)
        {
            int value = 0;
            int.TryParse(str, out value);
            return value;
        }


        private void task1(object sender, RoutedEventArgs e)
        {
            textBox_unsver.Text = "";

            //1 vampire number
            List<int> vn = VampireNumber.GetExistVampireNumber(4);

            //vn.ForEach(value => textBox_unsver.Text += value);

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
            int[] fibonacci = FibonacciSequence.getFibonacci(ValidInspector(textBox_user.Text));
            
            foreach (int i in fibonacci)
            {
                textBox_unsver.Text += i + " ";
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
            //todo защита от неверного ввода

            textBox_unsver.Text = TextLetters.getCountVowels(textBox_user.Text) + "%";

            textBox_task.Text = "3.Create a Set of the vowels.Count and " +
                "display the number of vowels in each input word, and also " +
                "display the total number of vowels in the input text, percent of each of them.";

        }

        private void task4(object sender, RoutedEventArgs e)
        {

            if(textBox_user.Text != "")
                textBox_unsver.Text = TextLetters.translateExpression(textBox_user.Text).ToString();
            else textBox_unsver.Text = TextLetters.translateExpression("+U+n+c--+e+r+t--+a-+i-+n+t+y--+ -+r+u--+l+e+s--").ToString();

            textBox_task.Text = "4. Stacks are often used to evaluate expressions " +
                "in programming languages. Evaluate the following expression, " +
                "where’+’ means 'push the following letter onto the stack,' " +
                "and’-’ means 'pop the top of the stack and print it'" +
                ": ' + U + n + c—+e + r + t—+a - +i - +n + t + y—+-+r + u—+l + e + s—'";

        }

        private void task5(object sender, RoutedEventArgs e)
        {

            textBox_task.Text = "5. Look up the Iterator in the documentation. " +
                "Develop own Iterator, that can work with Collection data types";
        }
        private void task6(object sender, RoutedEventArgs e)
        {

            textBox_task.Text = "6. Need to use Dictionary for two List, " +
                "it holds a single List objects. Verify that the " +
                "modified version works correctly. Test the speed " +
                "of your new Dictionary. Now change the add( ) method " +
                "so that it performs a sort( ) after each pair is entered." +
                " Compare the performance of the new version with the old ones";
        }
        private void task7(object sender, RoutedEventArgs e)
        {

            textBox_task.Text = "7. Create a new source file. In a method, declare a variable " +
                "temperatures of type List. (The C# collection type List is similar to Java’s ArrayList). " +
                "Add some numbers to the list. Write a foreach loop to count the number of " +
                "temperatures that equal or exceed 25 degrees. Write a method GreaterCount with " +
                "signature static int GreaterCount(List list, double min) { ... } that returns " +
                "the number of elements of list that are greater than or equal to min. Note that " +
                "the method is not generic, but the type of one of its parameters is a type instance " +
                "of the generic type List. Call the method on your temperatures list.";
        }


    }
}
