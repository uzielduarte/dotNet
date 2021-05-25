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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TxtEdad_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            int edad = getEdad();
            string categoria = cmbCategoriaEdad.SelectedItem.ToString();
            string message = "Vacio";

            switch (categoria)
            {
                case "Bebe":
                    if(edadValidacion(edad, 0, 4))
                    {
                        message = "La persona es un bebe";
                    }
                    break;
                case "Nino":
                    if (edadValidacion(edad, 5, 11))
                    {
                        message = "La persona es un nino";
                        MessageBox.Show("Nino");
                    }
                    MessageBox.Show("Afuera");
                    break;
                case "Teen":
                    if (edadValidacion(edad, 12, 17))
                    {
                        message = "La persona es un teen";
                    }
                    break;
                case "Joven":
                    if (edadValidacion(edad, 18, 25))
                    {
                        message = "La persona es un joven";
                    }
                    break;
                case "Adulto":
                    if (edadValidacion(edad, 26, 45))
                    {
                        message = "La persona es un nino";
                    }
                    break;
                case "Viejo":
                    if (edadValidacion(edad, 46, 85))
                    {
                        message = "La persona es un viejo";
                    }
                    break;
                case "Prehistorico":
                    if (edadValidacion(edad, 86, int.MaxValue))
                    {
                        message = "La persona es prehistorica";
                    }
                    break;
                default:
                    MessageBox.Show("Ningun case coincide");
                    break;
            }

            MessageBox.Show(message + edad);
            /*if(int.TryParse(txtEdad.Text, out edad))
            {
                MessageBox.Show($"Edad: {edad}");
            }
            else
            {
                MessageBox.Show("ERROR");
            }*/
        }

        private int getEdad()
        {
            if (int.TryParse(txtEdad.Text, out int edad))
            {
                return edad;
            }
            return int.MinValue;
        }

        private bool edadValidacion(int edad, int min, int max)
        {
            if(min <= edad && edad <= max)
            {
                return true;
            }
            MessageBox.Show("Falso");
            return false;
        }
    }
}
