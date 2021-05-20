using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double primerOperando;
        private double segundoOperando;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnOne_Click(object sender, EventArgs e)
        {
            Button btnOne = (Button)sender;
            if (btnOne.Text.Equals(".", StringComparison.CurrentCultureIgnoreCase))
            {
                if (lblEntrada.Text.Contains("."))
                {
                    return;
                }
            }
            lblEntrada.Text = "";
            lblEntrada.Text += btnOne.Text;
        }
    }
}
