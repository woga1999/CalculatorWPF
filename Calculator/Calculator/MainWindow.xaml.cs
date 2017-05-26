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
        ScaleTransform scale = new ScaleTransform();//윈도우 크기 바뀔 때 필요한 객체
        NumberButton numberButton = new NumberButton(); 
        double orginalWidth, originalHeight;
        private string operate = null;
        private double value1 = 0;
        private double value2 = 0;
        private double result = 0;
        private int flag = 0;
        private bool checkVal = false;
        bool plus = false; //연산자 다시 눌러도 계산 안되게끔 하는 장치
        bool minus = false; 
        bool multiple = false;
        bool division = false;
        bool numCE = false;
        bool resultCE = false;
        bool equalCheck;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded); //윈도우 사이즈 바뀔 때마다 이벤트 발생
            MainGrid.Children.Add(numberButton);
            numberButton.buttonCE.Click += btn_CE_Click;
            numberButton.buttonC.Click += btn_C_Click;
            numberButton.buttonBackSpace.Click += btn_BackSpace_Click;
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
        void btn_C_Click(object sender, RoutedEventArgs e) //모두 초기화하는 함수
        {
            numberButton.textBox.FontSize = 85.8; //계산 시 length가 길어지면 폰트가 작아지게 해놓았기 때문에 초기화시 폰트도 처음 크기로
            numberButton.textBox.Text = "0"; //계산기 기본 텍스트가 0이기에 0이라고 표시
            numberButton.displayBox.Clear();  //위로 조그맣게 연산 기록하는 것도 보여주는 텍스트박스도 초기화!
            operate = null;
            value1 = 0;
            value2 = 0;
        }

        void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            numberButton.textBox.FontSize = 85.8;
            numCE = true;
            resultCE = true;
            numberButton.textBox.Text = "0";
        }

        void btn_BackSpace_Click(object sender, RoutedEventArgs e)
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
            plus = false;
            minus = false;
            multiple = false;
            division = false;
            numCE = false;
            resultCE = false;

            if (numberButton.textBox.Text == "0")
            {
                resultCE = false;
                numberButton.textBox.Clear();
            }

            if(flag==0 && (numberButton.displayBox.Text.Contains("+")|| numberButton.displayBox.Text.Contains("x") || numberButton.displayBox.Text.Contains("-" )|| numberButton.displayBox.Text.Contains("÷")))
            {
                resultCE = false;
                numberButton.textBox.Clear();
                flag = 1;
            }
            else if (numberButton.textBox.Text.Contains("니다."))
            {
                resultCE = false;
                numberButton.buttonPlus.IsEnabled = true;
                numberButton.buttonMinus.IsEnabled = true;
                numberButton.buttonDivision.IsEnabled = true;
                numberButton.buttonMultiple.IsEnabled = true;
                numberButton.buttonPlma.IsEnabled = true;
                numberButton.buttonDot.IsEnabled = true;
                operate = null;
                numberButton.textBox.FontSize = 94.0;
                numberButton.textBox.Clear();
            }
            else if (equalCheck.Equals(true))
            {
                numberButton.textBox.Clear();
                resultCE = true;
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
            if (plus.Equals(false))
            {
                if (numberButton.displayBox.Text == "")
                {
                    numberButton.displayBox.Text = numberButton.textBox.Text + " + ";
                    value1 = Convert.ToDouble(numberButton.textBox.Text);
                    operate = "+";
                    flag = 0; checkVal = false;
                }
                else
                {
                    if (numberButton.displayBox.Text.Length >= 25)
                    {
                        numberButton.displayBox.Text = numberButton.displayBox.Text.Remove(0, numberButton.textBox.Text.Length + 3);
                    }
                    numberButton.displayBox.Text = numberButton.displayBox.Text + numberButton.textBox.Text + " + ";
                    flag = 0; checkVal = false;
                    value2 = Convert.ToDouble(numberButton.textBox.Text);
                    checkCalculate(operate);
                    operate = "+";
                }
                plus = true;
                minus = false;
                multiple = false;
                division = false;
            }
        }

        void btn_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (minus.Equals(false))
            {
                if (numberButton.displayBox.Text == "")
                {
                    numberButton.displayBox.Text = numberButton.textBox.Text + " - ";
                    value1 = Convert.ToDouble(numberButton.textBox.Text);
                    operate = "-";
                    flag = 0; checkVal = false;
                }
                else
                {
                    if (numberButton.displayBox.Text.Length >= 25)
                    {
                        numberButton.displayBox.Text = numberButton.displayBox.Text.Remove(0, numberButton.textBox.Text.Length + 3);
                    }
                    numberButton.displayBox.Text = numberButton.displayBox.Text + numberButton.textBox.Text + " - ";
                    flag = 0; checkVal = false;
                    value2 = Convert.ToDouble(numberButton.textBox.Text);
                    checkCalculate(operate);
                    operate = "-";
                }
                plus = false;
                minus = true;
                multiple = false;
                division = false;
            }
        }
        void btn_Multiple_Click(object sender, RoutedEventArgs e)
        {
            if (multiple.Equals(false))
            {
                if (numberButton.displayBox.Text == "")
                {
                    numberButton.displayBox.Text = numberButton.textBox.Text + " x ";
                    value1 = Convert.ToDouble(numberButton.textBox.Text);
                    operate = "*";
                    flag = 0; checkVal = false;
                }
                else
                {
                    if (numberButton.displayBox.Text.Length >= 25)
                    {
                        numberButton.displayBox.Text = numberButton.displayBox.Text.Remove(0, numberButton.textBox.Text.Length + 3);
                    }
                    numberButton.displayBox.Text = numberButton.displayBox.Text + numberButton.textBox.Text + " x ";
                    flag = 0; checkVal = false;
                    value2 = Convert.ToDouble(numberButton.textBox.Text);
                    checkCalculate(operate);
                    operate = "*";
                }
                plus = false;
                minus = false;
                multiple = true;
                division = false;
            }
        }
        void btn_Division_Click(object sender, RoutedEventArgs e)
        {
            if (division.Equals(false))
            {
                if (numberButton.displayBox.Text == "")
                {
                    numberButton.displayBox.Text = numberButton.textBox.Text + " ÷ ";
                    value1 = Convert.ToDouble(numberButton.textBox.Text);
                    operate = "/";
                    flag = 0; checkVal = false;
                }
                else
                {
                    if (numberButton.displayBox.Text.Length >= 25)
                    {
                        numberButton.displayBox.Text = numberButton.displayBox.Text.Remove(0, numberButton.textBox.Text.Length + 3);
                    }
                    numberButton.displayBox.Text = numberButton.displayBox.Text + numberButton.textBox.Text + " ÷ ";
                    flag = 0; checkVal = false;
                    value2 = Convert.ToDouble(numberButton.textBox.Text);
                    checkCalculate(operate);
                    operate = "/";
                }
                plus = false;
                minus = false;
                multiple = false;
                division = true;
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
            if (numberButton.textBox.Text.Contains("니다."))
            {
                numberButton.buttonPlus.IsEnabled = true;
                numberButton.buttonMinus.IsEnabled = true;
                numberButton.buttonDivision.IsEnabled = true;
                numberButton.buttonMultiple.IsEnabled = true;
                numberButton.buttonPlma.IsEnabled = true;
                numberButton.buttonDot.IsEnabled = true;
                operate = null;
                numberButton.textBox.FontSize = 94.0;
                numberButton.textBox.Text = "0";
            }
            else
            {
                if (checkVal.Equals(false))
                {
                    if (numCE.Equals(true))
                    {
                        value2 = 0;
                        resultCE = false;
                    }
                    else
                    {
                        value2 = Convert.ToDouble(numberButton.textBox.Text);
                    }
                    checkVal = true;
                }
                if (resultCE.Equals(true))
                {
                    value1 = 0;
                }
                numberButton.displayBox.Clear();
                checkCalculate(operate);
            }
            plus = false;
            minus = false;
            multiple = false;
            division = false;
            equalCheck = true;
        }

        double Add(double value1, double value2)
        {
            return value1 + value2;
        }

        double Minus(double value1, double value2)
        {
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

        void lengthFontSize(object btn) //텍스트 길이에 따라 크기 변화하는 함수
        {
            if (numberButton.textBox.Text.Length < 8)
            {
                numberButton.textBox.FontSize = 85.8;
                //numberButton.textBox.Text = string.Format("{0:n}", numberButton.textBox.Text+ btn);
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
            else if (numberButton.textBox.Text.Length >= 14 && !numberButton.textBox.Text.Contains(".")&& numberButton.textBox.Text.Length < 16)
            {
                numberButton.textBox.FontSize = 38.0;
                numberButton.textBox.Text = numberButton.textBox.Text + btn;
            }
            else if (numberButton.textBox.Text.Length>=14 && numberButton.textBox.Text.Contains(".") && numberButton.textBox.Text.Length < 17)
            {
                numberButton.textBox.FontSize = 36.0;
                numberButton.textBox.Text = numberButton.textBox.Text + btn;
            }
        }

        void checkCalculate(string operate)
        {
            if (operate == "+")
            {
                result = Add(value1, value2);
                numberButton.textBox.Text = result.ToString();
                if (resultCE.Equals(false))
                {
                    value1 = result;
                }
            }
            else if (operate == "-")
            {
                result = Minus(value1, value2);
                numberButton.textBox.Text = result.ToString();
                if (resultCE.Equals(false))
                {
                    value1 = result;
                }
            }
            else if (operate == "*")
            {
                result = Multiple(value1, value2);
                numberButton.textBox.Text = result.ToString();
                if (resultCE.Equals(false))
                {
                    value1 = result;
                }
            }
            else if (operate == "/")
            {
                if (value1 != 0 && value2 == 0)
                {
                    numberButton.textBox.FontSize = 36.0;
                    numberButton.textBox.Text = "0으로 나눌 수 없습니다. ";
                    value1 = 0;
                    numberButton.buttonPlus.IsEnabled = false;
                    numberButton.buttonMinus.IsEnabled = false;
                    numberButton.buttonDivision.IsEnabled = false;
                    numberButton.buttonMultiple.IsEnabled = false;
                    numberButton.buttonPlma.IsEnabled = false;
                    numberButton.buttonDot.IsEnabled = false;
                    
                }
                else if (value1 == 0 && value2 == 0)
                {
                    numberButton.textBox.FontSize = 30.0;
                    numberButton.textBox.Text = "정의되지 않는 결과입니다. ";
                    numberButton.buttonPlus.IsEnabled = false;
                    numberButton.buttonMinus.IsEnabled = false;
                    numberButton.buttonDivision.IsEnabled = false;
                    numberButton.buttonMultiple.IsEnabled = false;
                    numberButton.buttonPlma.IsEnabled = false;
                    numberButton.buttonDot.IsEnabled = false;
                }
                else
                {
                    result = Division(value1, value2);
                    numberButton.textBox.Text = result.ToString();
                    if (resultCE.Equals(false))
                    {
                        value1 = result;
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------
        //여기서부턴 윈도우 사이즈에 따라 컨트롤 크기도 바뀌기 위해 쓰이는 함수들
        void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ChangeSize(e.NewSize.Width, e.NewSize.Height);
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            orginalWidth = this.Width;
            originalHeight = this.Height;

            if (this.WindowState == WindowState.Maximized)
            {
                ChangeSize(this.ActualWidth, this.ActualHeight);
            }

            this.SizeChanged += new SizeChangedEventHandler(Window_SizeChanged);
        }

        private void ChangeSize(double width, double height)
        {
            scale.ScaleX = width / orginalWidth;
            scale.ScaleY = height / originalHeight;

            FrameworkElement rootElement = this.Content as FrameworkElement;

            rootElement.LayoutTransform = scale;
        }
    }
}
