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
    public partial class Form2 : Form
    {
        Form1 Form_1;
        String str;
        decimal payDecimal=0;
        decimal aDaySum = 0m;
        decimal bDaySum = 0m;
        decimal cDaySum = 0m;
        decimal aPaySum = 0m;
        decimal bPaySum = 0m;
        decimal cPaySum = 0m;
        decimal aCount = 0m;
        decimal bCount = 0m;
        decimal cCount = 0m;
        public List<String> empDetail = new List<String>();
        public List<Decimal> daysDetail = new List<Decimal>();
        public List<String> payDetail = new List<String>();


        public Form2(Form1 newform) 
        {
            InitializeComponent();
            Form_1 = newform;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            empDetail.AddRange(Form_1.empList);
            daysDetail.AddRange(Form_1.daysList);
            payDetail.AddRange(Form_1.payList);
            for(int i = 0; i < empDetail.Count(); i++)
            {
                lstAll.Items.Add(empDetail[i].ToUpper() + " " + daysDetail[i]);

                str = empDetail[i];
                payDecimal = Convert.ToDecimal(payDetail[i]);
                if(str[0] =='A' ||str[0] == 'a')
                {
                    aDaySum = aDaySum + daysDetail[i];
                    lblADays.Text = aDaySum.ToString();
                    aPaySum = aPaySum + payDecimal;
                    lblAPay.Text = aPaySum.ToString();
                    aCount++;
                    lblACount.Text = aCount.ToString();
                }
                else if (str[0] == 'B' || str[0] == 'b')
                {
                    bDaySum = bDaySum + daysDetail[i];
                    lblBDays.Text = bDaySum.ToString();
                    bPaySum = bPaySum + payDecimal;
                    lblBPay.Text = bPaySum.ToString();
                    bCount++;
                    lblBCount.Text = bCount.ToString();
                }
                else if (str[0] == 'C' || str[0] == 'c')
                {
                    cDaySum = cDaySum + daysDetail[i];
                    lblCDays.Text = cDaySum.ToString();
                    cPaySum = cPaySum + payDecimal;
                    lblCPay.Text = cPaySum.ToString();
                    cCount++;
                    lblCCount.Text = cCount.ToString();
                }



            }

        }
    }
}
