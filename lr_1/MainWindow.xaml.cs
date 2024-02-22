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

namespace lr_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double argument1;
        double argument2;
        char operation;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "0") {
                textBox.Text = (sender as Button)?.Content.ToString();
            } else if (textBox.Text.Length < 17)  {
                textBox.Text += (sender as Button)?.Content.ToString();
            }

        }

        private void ButtonOperation_Click(object sender, RoutedEventArgs e)
        {
            argument1 = Convert.ToDouble(textBox.Text);

            operation = (sender as Button).Content.ToString()[0];

            textBox.Text = "0";
        }

        private void ButtonEqual_Click(object sender, RoutedEventArgs e)
        {
            argument2 = Convert.ToDouble(textBox.Text);

            double result;

            switch (operation)
            {
                case '+': result = argument1 + argument2 ; break;
                case '-': result = argument1 - argument2 ; break;
                case '/': result = argument1 / argument2 ; break;
                case '*': result = argument1 * argument2 ; break;
                default: result=0 ; break;
            }

            textBox.Text = result.ToString();
        }

        private void ButtonPoint_Click(object sender, RoutedEventArgs e)
        {
            if(textBox.Text.Contains(',') == false && textBox.Text.Length < 17) {
                textBox.Text += ",";
            }
        }

        private void ButtonClean_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "0";
            argument1 = 0;
            argument2 = 0;
            operation = '0';
        }

        private void ButtonRollback_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length < 1) {
                textBox.Text = "0";
            }

            textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);

        }
    }
}
