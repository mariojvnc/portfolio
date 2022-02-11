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

namespace Calculator_WPF
{
    enum BinaryOperation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Power,
        Sqrt,
        None
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BinaryOperation operation = BinaryOperation.None;
        private bool enteringANumber = false;
        private double firstOperand;
        private double memory_variable = 0;
        private bool second_switch = false;
        private bool history_is_written = false;

        public MainWindow()
        {
            InitializeComponent();
            Clear_History_Calculation();
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button))
                return;
            if (history_is_written)
            {
                History_Calculation.Content = string.Empty;
                history_is_written = false;
            }
            // "1", "2", .... "9"
            int digit = 0;
            //int digit = int.Parse(button.Content.ToString());
            switch (button.Name)
            {
                case "Eins": digit = 1; break;
                case "Zwei": digit = 2; break;
                case "Drei": digit = 3; break;
                case "Vier": digit = 4; break;
                case "Fünf": digit = 5; break;
                case "Sechs": digit = 6; break;
                case "Sieben": digit = 7; break;
                case "Acht": digit = 8; break;
                case "Neun": digit = 9; break;
                case "Null": digit = 0; break;
                default: MessageBox.Show("Fatal Error"); break;
            }
            if (!enteringANumber)
            {
                Display.Content = String.Empty;
                enteringANumber = true;
            }
            if (Display.Content.ToString() == "0")
                Display.Content = string.Empty;

            Display.Content += digit.ToString();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            enteringANumber = false;

            double result = 0;
            double secondOperand = double.Parse(Display.Content.ToString());
            History_Calculation.Content += $" {secondOperand} =";
            history_is_written = true;
            switch (operation)
            {
                case BinaryOperation.Addition:
                    //History_Calculation.Content = $"{firstOperand} + {secondOperand} =";
                    result = firstOperand + secondOperand;
                    break;
                case BinaryOperation.Subtraction:
                    result = firstOperand - secondOperand;
                    break;
                case BinaryOperation.Multiplication:
                    result = firstOperand * secondOperand;
                    break;
                case BinaryOperation.Division:
                    result = firstOperand / secondOperand;
                    break;
                case BinaryOperation.Power:
                    result = Math.Pow(firstOperand, secondOperand);
                    break;
                case BinaryOperation.Sqrt:
                    result = Math.Pow(firstOperand, secondOperand);
                    break;

            }

            Display.Content = result.ToString();
            //Clear_History_Calculation();
        }
        private void Clear_History_Calculation() { History_Calculation.Content = string.Empty; }
        private void DecimalPoint_Click(object sender, RoutedEventArgs e)
        {
            Display.Content += ",";
        }

        public void CE_Click(object sender, RoutedEventArgs e)
        {
            Display.Content = "0";
            History_Calculation.Content = String.Empty;
            firstOperand = 0;
        }

        private void WriteHistory()
        {
            history_is_written = false;
           
            switch (operation)
            {
                case BinaryOperation.Addition:
                    History_Calculation.Content = $"{firstOperand} +";
                    break;
                case BinaryOperation.Subtraction:
                    History_Calculation.Content = $"{firstOperand} -";
                    break;
                case BinaryOperation.Multiplication:
                    History_Calculation.Content = $"{firstOperand} *";
                    break;
                case BinaryOperation.Division:
                    History_Calculation.Content = $"{firstOperand} /";
                    break;
                case BinaryOperation.Power:
                    History_Calculation.Content = $"{firstOperand} ^";
                    break;
                case BinaryOperation.Sqrt:
                    History_Calculation.Content = $"{firstOperand} ^";
                    break;
                case BinaryOperation.None:
                    break;
                default:
                    break;
            }
        }

        #region Calculations
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            enteringANumber = false;
            firstOperand += double.Parse(Display.Content.ToString());

            operation = BinaryOperation.Addition;
           
            WriteHistory();
        }
        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            enteringANumber = false;
            firstOperand = double.Parse(Display.Content.ToString());

            operation = BinaryOperation.Subtraction;

            WriteHistory();
        }
        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            enteringANumber = false;
            firstOperand -= double.Parse(Display.Content.ToString());

            operation = BinaryOperation.Multiplication;
            WriteHistory();
        }
        private void Division_Click(object sender, RoutedEventArgs e)
        {
            enteringANumber = false;
            firstOperand = double.Parse(Display.Content.ToString());

            operation = BinaryOperation.Division;
            WriteHistory();
        }
        #endregion

        #region Pi, e, x²
        private void Pi_Click(object sender, RoutedEventArgs e)
        {
            firstOperand = 3.1415926535;
            Display.Content = "3,1415926535";
        }
        private void E_number_Click(object sender, RoutedEventArgs e)
        {
            firstOperand = 2.7182818284590452353602874713527;
            Display.Content = "2,7182818284590452353602874713527";
        }
        private void X_pow_Click(object sender, RoutedEventArgs e)
        {
            //double display = double.Parse(Display.Content.ToString());
            //Display.Content = Math.Pow(display, 2).ToString();

            enteringANumber = false;
            firstOperand = double.Parse(Display.Content.ToString());

            operation = BinaryOperation.Power;
            WriteHistory();
        }
        #endregion

        private void Plusminus_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse((string)Display.Content);
            number = number * -1;
            firstOperand = number;
            Display.Content = firstOperand.ToString();

        }

        #region Memory
        private void Memory_Clear_Click(object sender, RoutedEventArgs e)
        {
            Memory_Label.Visibility = Visibility.Hidden;
            memory_variable = 0;
        }
        private void MemoryRecall_Click(object sender, RoutedEventArgs e)
        {
            Display.Content = memory_variable.ToString();
        }
        private void M_plus_Click(object sender, RoutedEventArgs e)
        {
            //enteringANumber = false;
            Memory_Label.Visibility = Visibility.Visible;
            try
            {
                memory_variable += double.Parse((string)Display.Content);
                Display.Content = "0";
                Memory_Label.Content = $"M: {memory_variable}";

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void M_minus_Click(object sender, RoutedEventArgs e)
        {
            Memory_Label.Visibility = Visibility.Visible;
            try
            {
                memory_variable -= double.Parse((string)Display.Content);
                Display.Content = "0";
                Memory_Label.Content = $"M: {memory_variable}";

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        #endregion

        #region Sin, Tan, Cos etc.
        public void Second_Click(object sender, RoutedEventArgs e)
        {
            if (!second_switch)
            {
                // Ist nicht getriggert
                // Content ändern
                sinus.Content = "sin-1";
                cosinus.Content = "cos-1";
                tangens.Content = "tan-1";
                sinus_h.Content = "sinh-1";
                cosinus_h.Content = "cosh-1";
                tangens_h.Content = "tanh-1";
                second_switch = true;
            }
            else
            {
                // Ist getriggert
                // Content ändern
                sinus.Content = "sin";
                cosinus.Content = "cos";
                tangens.Content = "tan";
                sinus_h.Content = "sinh";
                cosinus_h.Content = "cosh";
                tangens_h.Content = "tanh";
                second_switch = false;
            }

        }
        private void Sinus_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse((string)Display.Content);
            if (!second_switch)
            {
                // Second is not on
                number = Math.Sin(number);
            }
            else
            {
                // Second is on
                number = Math.Asin(number);

            }
            Display.Content = number;
        }
        private void Cosinus_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse((string)Display.Content);
            if (!second_switch)
            {
                // Second is not on
                number = Math.Cos(number);
            }
            else
            {
                // Second is on
                number = Math.Acos(number);
            }
            Display.Content = number.ToString();
        }
        private void Tangens_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse((string)Display.Content);
            if (!second_switch)
            {
                // Second is not on
                number = Math.Tan(number);
            }
            else
            {
                // Second is on
                number = Math.Atan(number);
            }

            Display.Content = number.ToString();
        }
        private void Tangens_h_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse((string)Display.Content);
            if (!second_switch)
            {
                // Second is not on
                number = Math.Tanh(number);
            }
            else
            {
                // Second is on
                number = ATanh(number);
            }
            number = Math.Tanh(number);
            Display.Content = number.ToString();
        }
        private void Cosinus_h_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse((string)Display.Content);
            if (!second_switch)
            {
                // Second is not on
                number = Math.Cosh(number);
            }
            else
            {
                // Second is on
                // number = Math.Acosh(number);
                // FINDE NICHT
            }
            Display.Content = number.ToString();
        }
        private void Sinus_h_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse((string)Display.Content);
            if (!second_switch)
            {
                // Second is not on
                number = Math.Sinh(number);
            }
            else
            {
                // Second is on
                // number = Math.Asinh(number); 
                // FINDE NICHT 
            }
            Display.Content = number.ToString();
        }
        //
        private static double ATanh(double x)
        {
            return (Math.Log(1 + x) - Math.Log(1 - x)) / 2;
        }
        #endregion

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse((string)Display.Content);
            number = Math.Sqrt(number);
            operation = BinaryOperation.Sqrt;
            ///Display.Content = number;
            WriteHistory();
        }
    }
}
