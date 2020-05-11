using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /***********************************************************************
         * Team 4 - George Gachoki, Jason Thomas, Tonya Martinez, Travis Johnson
         * 5-12-2020
         * "Week 5 Murach Coding Assignments (Teamwork)"
         * "Extra 7-2 Add Data Validation to the simple calculator"
         ***********************************************************************/
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData() == true) // check if user entries are valid
                {
                    decimal operand1 = Convert.ToDecimal(txtOperand1.Text); // create & assign operand 1 variable
                    string operator1 = txtOperator.Text; // create & assign operator variable
                    decimal operand2 = Convert.ToDecimal(txtOperand2.Text); // create & assign oeprand 2 variable
                    decimal result = Calculate(operand1, operator1, operand2); // create & calculate result variable

                    result = Math.Round(result, 4); // format result to four decimals
                    this.txtResult.Text = result.ToString(); // display result
                    txtOperand1.Focus(); // assign focus to operand 1
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +
                ex.GetType().ToString() + "\n" +
                ex.StackTrace, "Exception"); // display exception ex error message
            }
        }

        public bool IsValidData()
        {
            return
                IsPresent(txtOperand1, "Operand 1") // check if operand 1 is empty
                && IsDecimal(txtOperand1, "Operand 1") // check if operand 1 is decimal
                && IsWithinRange(txtOperand1, "Operand 1", 0, 1000000) // check if operand 1 is between 0 & 1000000 exclusive

                && IsPresent(txtOperator, "Operator") // check if operator is empty
                && IsOperator(txtOperator, "Operator") // check if operator is valid

                && IsPresent(txtOperand2, "Operand 2") // check if operand 2 is empty
                && IsDecimal(txtOperand2, "Operand 2") // check if operand 2 is decimal
                && IsWithinRange(txtOperand2, "Operand 2", 0, 1000000); // check if operand 2 is between 0 & 1000000 exclusive
        }

        public bool IsPresent(TextBox textbox, string name)
        {
            if (textbox.Text == "") // check if textbox is empty
            {
                MessageBox.Show(name + " is a required field.", "Entry Error"); // display empty textbox error message
                textbox.Focus(); // assign focus to textbox
                return false; // return false to calling method
            }
            return true; // return true to calling method
        }

        public bool IsDecimal(TextBox textbox, string name)
        {
            decimal number = 0m; // create & initialize number variable to zero
            if (decimal.TryParse(textbox.Text, out number)) // check if textbox entry is decimal
            {
                return true; // return true to calling method
            }
            else
            {
                MessageBox.Show(name + " must be a decimal value.", "Entry Error"); // display decimal error message
                textbox.Focus(); // assign focus to textbox
                return false; // return false to calling method
            }
        }

        public bool IsWithinRange(TextBox textbox, string name, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textbox.Text); // create & assign number variable to textbox entry
            if (number <= min || number >= max) // check if textbox entry is between min and max values (exclusive)
            {
                MessageBox.Show(name + " must be between " + min + " and " + max + ".", "Entry Error"); // display range error message
                textbox.Focus(); // assign focus to textbox
                return false; // return false to calling method
            }
            return true; // return true to calling method
        }

        public bool IsOperator(TextBox textbox, string name)
        {
            string operator1 = textbox.Text; // create & assign user operator variable to textbox entry
            if (operator1 == "+" || operator1 == "-" 
                || operator1 == "*" || operator1 == "/") // check if textbox entry is valid operator
            {
                return true; // return true to calling method
            }
            else
            {
                MessageBox.Show(name + " must be a valid operator (+, -, *, or /).", "Entry Error"); // display operator error message
                textbox.Focus(); // assign focus to textbox
                return false; // return false to calling method
            }
        }

        private decimal Calculate(decimal operand1, string operator1,
            decimal operand2)
        {
            decimal result = 0; // create & initialize result variable to zero
            if (operator1 == "+") // check if operator is addition
                result = operand1 + operand2; // calculate result using addition
            else if (operator1 == "-") // check if operator is subtraction
                result = operand1 - operand2; // calculate result using subtraction
            else if (operator1 == "*") // check if operator is multiplication
                result = operand1 * operand2; // calculate result using multiplication
            else if (operator1 == "/") // check if operator is division
                result = operand1 / operand2; // calculate result using division
            return result; // return result to calling method
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); // close form
        }

        private void ClearResult(object sender, EventArgs e)
        {
            this.txtResult.Text = ""; // clear result textbox
        }
    }
}