using Activo.enums;
using Activo.model;
using Activo.poco1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activo
{
    public partial class Activo : Form
    {
        private ActivoFijo[] activoFijos;
        private ActivoFijoModel activoFijoModel;
        public Activo()
        {
            InitializeComponent();
            loadTipoActivo();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Activo_Load(object sender, EventArgs e)
        {

        }

        private void loadTipoActivo()
        {
            cmbTipoActivo.Items.AddRange(Enum.GetValues(typeof(TipoActivo))
                         .Cast<object>()
                         .ToArray());
            cmbTipoActivo.SelectedIndex = 0;
        }

        private void validateActivoFijo(string codigo, string nombre,
            out decimal valor, out decimal valorR)
        {
            if(string.IsNullOrWhiteSpace(codigo))
            {
                throw new ArgumentException("El codigo es requerido");
            }

            if(string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre es requerido");
            }

            if(!)
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int index = dgvActivos.CurrentCell.RowIndex;
            activoFijoModel.remove(index);
            dgvActivos.DataSource = activoFijoModel.getAll();
        }
    }
}
