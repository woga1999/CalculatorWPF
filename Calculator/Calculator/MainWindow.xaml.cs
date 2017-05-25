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

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        NumberButton numberButton = new NumberButton();
        private string operate = null;
        private double value1 = 0;
        private double value2 = 0;
        private double result = 0;
        private int flag = 0;
        private bool checkVal = false;
        public MainWindow()
        {
            InitializeComponent();
            MainGrid.Children.Add(numberButton);
            numberButton.buttonCE.Click += btn_CE_Click;
            numberButton.buttonC.Click += btn_C_Click;
            numberButton.buttonBackSpace.Click += btn_BS_Click;
            numberButton.buttonDivision.Click += btn_Division_Click;
            numberButton.buttonSeven.Click += btn_Num_Click;
            numberButton.buttonEgiht.Click += btn_Num_Click;
            numberButton.buttonNine.Click += btn_Num_Click;
            numberButton.buttonMultiple.Click += btn_Multiple_Click;
            numberButton.buttonFour.Click += btn_Num_Click;
            numberButton.buttonFive.Click += btn_Num_Click;
            numberButton.buttonSix.Click += btn_Num_Click;
            numberButton.buttonPlus.Click += btn_Plus_Click;
            numberButton.buttonOne.Click += btn_Num_Click;
            numberButton.buttonTwo.Click += btn_Num_Click;
            numberButton.buttonThree.Click += btn_Num_Click;
            numberButton.buttonMinus.Click += btn_Minus_Click;
            numberButton.buttonPlma.Click += btn_Plma_Click;
            numberButton.buttonZero.Click += btn_Num_Click;
            numberButton.buttonDot.Click += btn_Dot_Click;
            numberButton.buttonEqual.Click += btn_Equals_Clikc;
        }
        void btn_C_Click(object sender, RoutedEventArgs e)
        {
            numberButton.textBox.Text = "0";
            numberButton.displayBox.Clear();
            operate = null;
        }

        void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            numberButton.textBox.Text = "0";
        }

        void btn_BS_Click(object sender, RoutedEventArgs e)
        {
            if (!numberButton.textBox.Text.Equals("") || !(numberButton.textBox.Text.Equals("0")))
            {
                if (numberButton.textBox.Text.Contains("-") && numberButton.textBox.Text.Length == 2)
                {
                    numberButton.textBox.Text = "0";
                }
                else if (numberButton.textBox.Text.Length.Equals(1))
                {
                    numberButton.textBox.Text = "0";
                }
                else if(!numberButton.displayBox.Text.Contains("+") && !numberButton.displayBox.Text.Contains("-") && !numberButton.displayBox.Text.Contains("*") && !numberButton.displayBox.Text.Contains("÷"))
                {
                    numberButton.textBox.Text = numberButton.textBox.Text.Remove(numberButton.textBox.Text.Length - 1, 1);
                }
            }
           
        }
        void btn_Num_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (numberButton.textBox.Text == "0")
            {
                numberButton.textBox.Clear();
            }
            if(flag==0 && (numberButton.displayBox.Text.Contains("+")|| numberButton.displayBox.Text.Contains("x") || numberButton.displayBox.Text.Contains("-" )|| numberButton.displayBox.Text.Contains("÷")))
            {
                numberButton.textBox.Clear();
                flag = 1;
            }
            lengthFontSize(btn.Content);
        }
        
        void btn_Dot_Click(object sender, RoutedEventArgs e)
        {
            if (!numberButton.textBox.Text.Contains("."))
            {
                numberButton.textBox.Text = numberButton.textBox.Text + ".";
            }
        }

        void btn_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.displayBox.Text == "")
            {
                numberButton.displayBox.Text = numberButton.textBox.Text + " + ";
                value1 = Convert.ToDouble(numberButton.textBox.Text);
                operate = "+";
                flag = 0;
            }
            else
            {
                numberButton.displayBox.Text = numberButton.displayBox.Text + numberButton.textBox.Text+ " + ";
                flag = 0;
                value2 = Convert.ToDouble(numberButton.textBox.Text);
                checkCalculate(operate);
                operate = "+";
            }
        }

        void btn_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.displayBox.Text == "")
            {
                numberButton.displayBox.Text = numberButton.textBox.Text + " - ";
                value1 = Convert.ToDouble(numberButton.textBox.Text);
                operate = "-";
                flag = 0;
            }
            else
            {
                numberButton.displayBox.Text = numberButton.displayBox.Text + numberButton.textBox.Text + " - ";
                flag = 0;
                value2 = Convert.ToDouble(numberButton.textBox.Text);
                checkCalculate(operate);
                operate = "-";
            }

        }
        void btn_Multiple_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.displayBox.Text == "")
            {
                numberButton.displayBox.Text = numberButton.textBox.Text + " x ";
                value1= Convert.ToDouble(numberButton.textBox.Text);
                operate = "*";
                flag = 0;
            }
            else
            {
                numberButton.displayBox.Text = numberButton.displayBox.Text + numberButton.textBox.Text + " x ";
                flag = 0;
                value2 = Convert.ToDouble(numberButton.textBox.Text);
                checkCalculate(operate);
                operate = "*";
            }
            
        }
        void btn_Division_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.displayBox.Text == "")
            {
                numberButton.displayBox.Text = numberButton.textBox.Text + " ÷ ";
                value1 = Convert.ToDouble(numberButton.textBox.Text);
                operate = "/";
                flag = 0;
            }
            else
            {
                numberButton.displayBox.Text = numberButton.displayBox.Text + numberButton.textBox.Text + " ÷ ";
                flag = 0;
                value2 = Convert.ToDouble(numberButton.textBox.Text);
                checkCalculate(operate);
                operate = "/";
            }
            
        }

        void btn_Plma_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.textBox.Text.Contains("-"))
            {
                numberButton.textBox.Text = numberButton.textBox.Text.Remove(0,1);
            }
            else if (!numberButton.textBox.Text.Contains("-"))
            {
                if (!numberButton.textBox.Text.Equals("0"))
                {
                    numberButton.textBox.Text = "-" + numberButton.textBox.Text;
                }
            }
        }

        void btn_Equals_Clikc(object sender, RoutedEventArgs e)
        {
            if (checkVal.Equals(false))
            {
                value2 = Convert.ToDouble(numberButton.textBox.Text);
                checkVal = true;
            }
            numberButton.displayBox.Clear();
            checkCalculate(operate);
        }

        double Add(double value1, double value2)
        {
            return value1 + value2;
        }

        double Minus(double value1, double value2)
        {
            if (value1 == 0) { value2 = -value2; }
            return value1 - value2;
        }

        double Multiple(double value1, double value2)
        {
            return value1 * value2;
        }

        double Division(double value1, double value2)
        {
            return value1 / value2;
        }

        void lengthFontSize(object btn)
        {
            if (numberButton.textBox.Text.Length < 8)
            {
                numberButton.textBox.Text = numberButton.textBox.Text + btn;
            }
            else if (numberButton.textBox.Text.Length >= 8 && numberButton.textBox.Text.Length < 11)
            {
                numberButton.textBox.FontSize = 69.0;
                numberButton.textBox.Text = numberButton.textBox.Text + btn;
            }
            else if (numberButton.textBox.Text.Length >= 11 && numberButton.textBox.Text.Length < 12)
            {
                numberButton.textBox.FontSize = 60.0;
                numberButton.textBox.Text = numberButton.textBox.Text + btn;
            }
            else if (numberButton.textBox.Text.Length == 12)
            {
                numberButton.textBox.FontSize = 56.0;
                numberButton.textBox.Text = numberButton.textBox.Text + btn;
            }
            else if (numberButton.textBox.Text.Length == 13)
            {
                numberButton.textBox.FontSize = 52.0;
                numberButton.textBox.Text = numberButton.textBox.Text + btn;
            }
            else if (numberButton.textBox.Text.Length >= 14 && numberButton.textBox.Text.Length < 16)
            {
                numberButton.textBox.FontSize = 48.0;
                numberButton.textBox.Text = numberButton.textBox.Text + btn;
            }
        }
        void checkCalculate(string operate)
        {
            if (operate == "+")
            {
                result = Add(value1, value2);
                numberButton.textBox.Text = result.ToString();
                value1 = result;
            }
            else if (operate == "-")
            {
                result = Minus(value1, value2);
                numberButton.textBox.Text = result.ToString();
                value1 = result;
            }
            else if (operate == "*")
            {
                result = Multiple(value1, value2);
                numberButton.textBox.Text = result.ToString();
                value1 = result;
            }
            else if (operate == "/")
            {
                result = Division(value1, value2);
                numberButton.textBox.Text = result.ToString();
                value1 = result;
            }
        }
    }
}
