using System;
using Xamarin.Forms;

namespace calculadora_M
{
    public partial class MainPage : ContentPage
    {
        string currentNumber = "";
        string operation = "";
        double firstNumber = 0;
        double secondNumber = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        void NumberButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentNumber += button.Text;
            resultLabel.Text = currentNumber;
        }

        void OperatorButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            firstNumber = double.Parse(currentNumber);
            currentNumber = "";
        }

        void EqualsButton_Clicked(object sender, EventArgs e)
        {
            secondNumber = double.Parse(currentNumber);
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                        result = firstNumber / secondNumber;
                    else
                        resultLabel.Text = "Error";
                    break;
            }

            resultLabel.Text = result.ToString();
            currentNumber = result.ToString();
        }

        void ClearButton_Clicked(object sender, EventArgs e)
        {
            currentNumber = "";
            firstNumber = 0;
            secondNumber = 0;
            operation = "";
            resultLabel.Text = "0";
        }

        void BackspaceButton_Clicked(object sender, EventArgs e)
        {
            if (currentNumber.Length > 0)
            {
                currentNumber = currentNumber.Substring(0, currentNumber.Length - 1);
                resultLabel.Text = currentNumber;
            }
        }
    }
}
