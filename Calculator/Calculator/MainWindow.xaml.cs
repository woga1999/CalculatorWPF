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
        List<string> number = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            MainGrid.Children.Add(numberButton);
            numberButton.textBlock.Text = "";
            numberButton.buttonCE.Click += btn_CE_Click;
            //numberButton.buttonC.Click += btnCEClick;
            numberButton.buttonBackSpace.Click += btn_BS_Click;
            //numberButton.buttonDivision.Click += btnCEClick;
            numberButton.buttonSeven.Click += btn_Seven_Click;
            numberButton.buttonEgiht.Click += btn_Egiht_Click;
            numberButton.buttonNine.Click += btn_Nine_Click;
            //numberButton.buttonMultiple.Click += btnCEClick;
            numberButton.buttonFour.Click += btn_Four_Click;
            numberButton.buttonFive.Click += btn_Five_Click;
            numberButton.buttonSix.Click += btn_Six_Click;
            //numberButton.buttonPlus.Click += btnCEClick;
            numberButton.buttonOne.Click += btn_One_Click;
            numberButton.buttonTwo.Click += btn_Two_Click;
            numberButton.buttonThree.Click += btn_Three_Click;
            //numberButton.buttonMinus.Click += btnCEClick;
            numberButton.buttonPlma.Click += btn_Plma_Click;
            numberButton.buttonZero.Click += btn_Zero_Click;
            numberButton.buttonDot.Click += btn_Dot_Click;
            //numberButton.buttonEqual.Click += btnCEClick;
        }
       
        void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            numberButton.textBox.Text = "0";
        }
        void btn_BS_Click(object sender, RoutedEventArgs e)
        {
            if (!numberButton.textBox.Text.Equals("") || !(numberButton.textBox.Text.Equals("0")) )
            {
                if (numberButton.textBox.Text.Length.Equals(1))
                {
                    numberButton.textBox.Text = "0";
                }
                else
                {
                    numberButton.textBox.Text = numberButton.textBox.Text.Remove(numberButton.textBox.Text.Length - 1, 1);
                }
            }
        }
        void btn_Zero_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.textBox.Text == "0")
            {
                numberButton.textBox.Clear();
            }
            numberButton.textBox.Text = numberButton.textBox.Text + "0";
        }
        void btn_One_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (numberButton.textBox.Text == "0")
            {
                numberButton.textBox.Clear();
            }
            numberButton.textBox.Text = numberButton.textBox.Text + "1";
        }
        void btn_Two_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.textBox.Text == "0")
            {
                numberButton.textBox.Clear();
            }
            numberButton.textBox.Text = numberButton.textBox.Text + "2";
        }
        void btn_Three_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.textBox.Text == "0")
            {
                numberButton.textBox.Clear();
            }
            numberButton.textBox.Text = numberButton.textBox.Text + "3";
        }
        void btn_Four_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.textBox.Text == "0")
            {
                numberButton.textBox.Clear();
            }
            numberButton.textBox.Text = numberButton.textBox.Text + "4";
        }
        void btn_Five_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.textBox.Text == "0")
            {
                numberButton.textBox.Clear();
            }
            numberButton.textBox.Text = numberButton.textBox.Text + "5";
        }
        void btn_Six_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.textBox.Text == "0")
            {
                numberButton.textBox.Clear();
            }
            numberButton.textBox.Text = numberButton.textBox.Text + "6";
        }
        void btn_Seven_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.textBox.Text == "0")
            {
                numberButton.textBox.Clear();
            }
            numberButton.textBox.Text = numberButton.textBox.Text + "7";
        }
        void btn_Egiht_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.textBox.Text == "0")
            {
                numberButton.textBox.Clear();
            }
            numberButton.textBox.Text = numberButton.textBox.Text + "8";
        }
        void btn_Nine_Click(object sender, RoutedEventArgs e)
        {
            if (numberButton.textBox.Text == "0")
            {
                numberButton.textBox.Clear();
            }
            numberButton.textBox.Text = numberButton.textBox.Text + "9";
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

        }
        void btn_Minus_Click(object sender, RoutedEventArgs e)
        {

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
        void btn_Division_Click(object sender, RoutedEventArgs e)
        {

        }
        void Calculate()
        {
            numberButton.textBox.FontSize = 24;
        }
    }
}
