using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Languagebasic
{
    public partial class Form1 : Form
    {
        private bool isOperation = false;
        private string operation;
        private double result = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void FlowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FlowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnReciproco_Click(object sender, EventArgs e)
        {

        }

        private void Button17_Click(object sender, EventArgs e)
        {
            Button btnOne = (Button)sender;

            if(lblResult.Text.Equals("0") || isOperation)
            {
                lblResult.Text = "";
            }
            if(btnOne.Text.Equals(".", StringComparison.CurrentCultureIgnoreCase))
            {
                if(lblResult.Text.Contains("."))
                {
                    return;
                }
            }
            lblInput.Text += btnOne.Text;
            
        }

        private void BtnTwo_Click(object sender, EventArgs e)
        {

        }

        private void BtnSum_Click(object sender, EventArgs e)
        {
            Button btnSum = (Button)sender;

            if(result == 0)
            {
                result = Double.Parse(lblResult.Text);
                lblInput.Text = lblResult + " " + btnSum.Text;
                operation = btnSum.Text;
            }else
            {
                lblInput.Text = lblResult.Text + " " + btnSum.Text;
                isOperation = true;
            }
            lblInput.Text = lblResult + " " + btnSum.Text;
            isOperation = true;
        }

        private void doOperation(string operation)
        {

            switch (operation)
            {
                case "+":
                    result += Double.Parse(lblResult.Text);
                    break;
                case "-":
                    result -= Double.Parse(lblResult.Text);
                    break;
                case "*":
                    result *= Double.Parse(lblResult.Text);
                    break;
                case "÷":
                    double temp = Double.Parse(lblResult.Text);
                    if (result == 0 || temp == 0)
                        lblResult.Text = "Undefined";
                    else if (temp == 0)
                        lblResult.Text = "Error";
                    result /= temp;
                    break;
            }
            isOperation = false;
        }
    }
}
