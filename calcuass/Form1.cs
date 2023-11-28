using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calcuass
{
    public partial class Form1 : Form
    {
        double firstNumber;
        double secondNumber;
       

        CalculatorState currentState = CalculatorState.firstNumberInput;

        OperationState currentOperation;


        public Form1()
        {
            InitializeComponent();
        }



        private void addNumber_click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;

            txtresult.Text += currentButton.Text;
        }
        private void allOperationBtn_click(object sender, EventArgs e)
        {
            if (txtresult.Text != "")
            {
                firstNumber = double.Parse(txtresult.Text);

                txtresult.Text = "";

                currentState = CalculatorState.secondNumberInput;

                Button currentButton = (Button)sender;

                if (currentButton.Name == "btnpl")
                {
                    currentOperation = OperationState.Add;
                }
                else if (currentButton.Name == "btnmin")
                {
                    currentOperation = OperationState.Subtract;
                }
                else if (currentButton.Name == "btnmult")
                {
                    currentOperation = OperationState.Multiply;
                }
                else if (currentButton.Name == "btndiv")
                {
                    currentOperation = OperationState.Divide;
                }
            }

        }

      



        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.btn0.Click += new EventHandler(addNumber_click);
            this.btn1.Click += new EventHandler(addNumber_click);
            this.btn2.Click += new EventHandler(addNumber_click);
            this.btn3.Click += new EventHandler(addNumber_click);
            this.btn4.Click += new EventHandler(addNumber_click);
            this.btn5.Click += new EventHandler(addNumber_click);
            this.btn6.Click += new EventHandler(addNumber_click);
            this.btn7.Click += new EventHandler(addNumber_click);
            this.btn8.Click += new EventHandler(addNumber_click);
            this.btn4.Click += new EventHandler(addNumber_click);
            this.btn9.Click += new EventHandler(addNumber_click);

            this.btnpl.Click += new EventHandler(allOperationBtn_click);
            this.btnmin.Click += new EventHandler(allOperationBtn_click);
            this.btnmult.Click += new EventHandler(allOperationBtn_click);
            this.btndiv.Click += new EventHandler(allOperationBtn_click);
        }

        private void btneq_Click(object sender, EventArgs e)
        {
            if (currentState == CalculatorState.secondNumberInput && txtresult.Text != "")
            {
                double result = 0;
                secondNumber = double.Parse(txtresult.Text);

                if (currentOperation == OperationState.Add)
                {
                    result = firstNumber + secondNumber;
                }
                else if (currentOperation == OperationState.Subtract)
                {
                    result = firstNumber - secondNumber;
                }
                else if (currentOperation == OperationState.Multiply)
                {
                    result = firstNumber * secondNumber;
                }
                else if (currentOperation == OperationState.Divide)
                {
                    result = firstNumber / secondNumber;
                }

                txtresult.Text = result.ToString();
                currentState = CalculatorState.firstNumberInput;
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtresult.Text = "";
            firstNumber = 0;
            secondNumber = 0;
            currentState = CalculatorState.firstNumberInput;
        }
    }
}
