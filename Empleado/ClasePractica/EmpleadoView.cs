using ClasePractica.enums;
using ClasePractica.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClasePractica
{
    public partial class Empleado : Form
    {
        private EmpleadoModel empleadoModel;
        public Empleado()
        {
            InitializeComponent();
            loadComboBoxes();
            empleadoModel = new EmpleadoModel();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtID.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string cedula = txtCedula.Text;
                string telefono = txtTelefono.Text;
                string correo = txtCorreo.Text;
                int index = cmbProfesion.SelectedIndex;
                Profesiones profesion = (Profesiones)Enum.GetValues(typeof(Profesiones)).GetValue(index);
                index = cmbCargo.SelectedIndex;
                Cargos cargo = (Cargos)Enum.GetValues(typeof(Cargos)).GetValue(index);
                string salario = txtSalario.Text

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

        private void validarEmpleado(string telefono, string correo, out decimal salario)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El telefono es requerido");

            if (string.IsNullOrWhiteSpace(correo))
                throw new ArgumentException("El correo es requerido");

            if (!decimal.TryParse(txtSalario.Text, out decimal v))
                throw new ArgumentException($"El valor {txtSalario.Text} es invalido");
            salario = v;
        }

        private void loadComboBoxes()
        {
            cmbProfesion.Items.AddRange(Enum.GetValues(typeof(Profesiones))
                         .Cast<object>()
                         .ToArray());
            cmbProfesion.SelectedIndex = 0;

            cmbCargo.Items.AddRange(Enum.GetValues(typeof(Cargos))
                         .Cast<object>()
                         .ToArray());
            cmbCargo.SelectedIndex = 0;
        }
    }
}
