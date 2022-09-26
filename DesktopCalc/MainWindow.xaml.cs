using System;
using System.Windows;
using System.Windows.Controls;

namespace DesktopCalc
{
    public partial class MainWindow : Window
    {
        static double num1 = default;
        static double num2 = default;
        static string op = String.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            String num = button.Content.ToString();
            if (txtValue.Text == "0")
                txtValue.Text = num;
            else
                txtValue.Text += num;

            if (op == "")
                num1 = Double.Parse(txtValue.Text);
            else
                num2 = Double.Parse(txtValue.Text);
        }

        private void btn_op_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string str = button.Content.ToString();
            op = str;
        }

        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            double result = default;
            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                case "max":
                    result = Math.Max(num1, num2);
                    break;
                case "min":
                    result = Math.Min(num1, num2);
                    break;
                case "avg":
                    result = (num1 + num2) / 2;
                    break;
                case "x^y":
                    result = (int)Math.Pow(num1, num2);
                    break;
            }
            num1 = result;
            num2 = 0;
            op = "";
            txtValue.Text = result.ToString();
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            op = "";
            num1 = 0;
            num2 = 0;
            txtValue.Text = "0";
        }

        private void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
                num1 = 0;
            else
                num2 = 0;
            txtValue.Text = "0";
        }

        private void btn_backspce_Click(object sender, RoutedEventArgs e)
        {
            txtValue.Text = DropLast(txtValue.Text);
            if (op == "")
                num1 = double.Parse(txtValue.Text);
            else
                num2 = double.Parse(txtValue.Text);
        }

        private string DropLast(string text)
        {
            if (text.Length == 1)
                return "0";
            text = text.Remove(text.Length - 1, 1);

            if (text[^1] == ',')
                text = text.Remove(text.Length - 1, 1);
            return text;

        }

        private void btn_plusminus_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
            {
                num1 *= -1;
                txtValue.Text = num1.ToString();
            }
            else
            {
                num2 *= -1;
                txtValue.Text = num2.ToString();
            }
        }

        private void btn_comma_Click(object sender, RoutedEventArgs e)
        {
            if (!txtValue.Text.Contains(','))
                txtValue.Text += ",";
        }
    }
}
