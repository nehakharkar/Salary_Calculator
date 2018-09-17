using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salary_Calculator
{
    public partial class Form1 : Form
    {
        String empText;
        Decimal daysText;
        Decimal payAmtText;
        public List<String> empList = new List<String>();
        public List<Decimal> daysList = new List<Decimal>();
        public List<String> payList = new List<String>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    empText = txtEmpID.Text;
                    daysText = Convert.ToDecimal(txtTotalDays.Text);
                    empList.Add(empText);
                    daysList.Add(daysText);
                    if (empText[0] == 'A' || empText[0] == 'a')
                    {
                        payAmtText = 100 * daysText;

                    }
                    else if (empText[0] == 'B' || empText[0] == 'b')
                    {
                        payAmtText = 200 * daysText;
                    }
                    else
                    {
                        payAmtText = 300 * daysText;
                    }
                    var payAmt = payAmtText.ToString("N2");
                    payList.Add(payAmt);
                    txtPayAmt.Text = payAmt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
            }
           
            
        }

        private bool IsPresent(TextBox textbox, string name)
        {
            if (textbox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textbox.Focus();
                return false;
            }
            return true;
        }
        private bool IsDecimal(TextBox textbox, string name)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textbox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a decimal value.", "Entry Error");
                textbox.Focus();
                return false;
            }
        }
        private bool IsWithinRange(TextBox textbox, string name, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textbox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " + min + " and " + max + ".", "Entry error");
                textbox.Clear();
                textbox.Focus();
                return false;
            }
            return true;
        }
        private bool IsDigit(TextBox textbox, string name)
        {
            String str = Convert.ToString(txtEmpID.Text.ToUpper());
            char second = str[1];
            char third = str[2];
            if(char.IsDigit(second) && char.IsDigit(third))
            {
                return true;
            }
            else
            {
                MessageBox.Show("The 2nd and 3rd character of " + name + " must be a digit.", "Entry error");
                textbox.Clear();
                textbox.Focus();
                return false;
            }
            

        }
        private bool IsLetter(TextBox textbox, string name)
        {

            Char character = Convert.ToChar(txtEmpID.Text[0]);
           
            if (character =='A' || character == 'B'|| character == 'C' || character == 'a' || character == 'b' || character == 'c')
            {
                return true;
            }

            {
                MessageBox.Show(name + " must begin with A or B or C. ", "Entry error");
                textbox.Focus();
                return false;
            }
        }
        private bool IsLength(TextBox textbox, string name)
        {

            if (txtEmpID.Text.Length == 3) 
            {
                return true;
            }

            {
                MessageBox.Show(name + " must contain exactly three characters.", "Entry error");
                textbox.Focus();
                return false;
            }
        }
        private bool IsValidData()
        {
            return
                IsPresent(txtEmpID, "Employee ID") &&
                IsDigit(txtEmpID,"Employee ID") &&
                IsLetter(txtEmpID, "Employee ID") &&
                IsLength(txtEmpID, "Employee ID") &&
                IsPresent(txtTotalDays, "Total Days") &&
                IsDecimal(txtTotalDays, "Total Days") &&
                IsWithinRange(txtTotalDays, " Total Days", 0, 25);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnEnter;
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.ShowDialog();
        }
    }
}
