using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online
{
    public partial class FrmImperative : Form
    {
        private List<int> numeros;
        public FrmImperative()
        {
            InitializeComponent();
            numeros = new List<int>();
        }

        private int? getValue(String value)
        {
            if(int.TryParse(value, out int v))
            {
                return v;
            }
            return null;
        }

        private void TxtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            int? value = null;
            if(e.KeyCode == Keys.Enter)
            {
                if( (value = getValue(txtNumber.Text)) == null)
                {
                    return;
                }
                numeros.Add(value ?? 0);
                txtNumber.Text = "";
                if (numeros.Count == 10)
                {
                    txtNumber.Enabled = false;
                    calcular();
                    return;
                }
            }
        }

        private void calcular()
        {
            long resultado = 0;
            /*for(int i = 0; i < numeros.Count; i++)
            {
                resultado += (long) Math.Pow(numeros.ElementAt(i), 2);
                txtResultados.AppendText($"{numeros.ElementAt(i)}^2 = {Math.Pow(numeros.ElementAt(i), 2)}\n");
            }*/

            foreach (int i in numeros)
            {
                resultado += (long)Math.Pow(i, 2);
                txtResultados.AppendText($"{i}^2 = {Math.Pow(i, 2)}" + Environment.NewLine);
            }

            txtResultados.AppendText($"Total = {resultado}");

            //resultado = (long) numeros.Select(i => Math.Pow(i, 2)).Sum();
            //numeros.ForEach(i => txtResultados.AppendText($"{i}^2 = {Math.Pow(i, 2)}" + Environment.NewLine);
            //txtResultados.AppendText($"Total = {resultado}");
        }

    }
}
