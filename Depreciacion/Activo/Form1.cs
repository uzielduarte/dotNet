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
        private ActivoFijoModel activoFijoModel;
        public Activo()
        {
            InitializeComponent();
            loadTipoActivo();
            activoFijoModel = new ActivoFijoModel();
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
                throw new ArgumentException("El codigo es requerido");

            if(string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es requerido");

            if (!decimal.TryParse(txtValor.Text, out decimal v))
                throw new ArgumentException($"El valor {txtValor.Text} es invalido");
            valor = v;
            if (!decimal.TryParse(txtValorResidual.Text, out decimal vr))
                throw new ArgumentException($"El valor {txtValorResidual.Text} es invalido");
            valorR = vr;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvActivos.Rows.Count == 0)
                return;

            int index = dgvActivos.CurrentCell.RowIndex;
            activoFijoModel.remove(index);
            dgvActivos.DataSource = activoFijoModel.getAll();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string code = txtCodigo.Text;
                string name = txtNombre.Text;
                int index = cmbTipoActivo.SelectedIndex;
                TipoActivo tipoActivo = (TipoActivo)Enum.GetValues(typeof(TipoActivo)).GetValue(index);

                validateActivoFijo(code, name, out decimal valor, out decimal valorR);

                ActivoFijo activoFijo = new ActivoFijo()
                {
                    codigo = code,
                    nombre = name,
                    tipoActivo = tipoActivo,
                    valor = valor,
                    valorResidual = valorR
                };

                activoFijoModel.add(activoFijo);
                MessageBox.Show("Activo agregado satisfactoriamente");
                dgvActivos.DataSource = activoFijoModel.getAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
