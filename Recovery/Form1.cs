using Recovery.enums;
using Recovery.model;
using Recovery.poco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recovery
{
    public partial class Form1 : Form
    {
        EmpleadoModel empleadoModel;
        public Form1()
        {
            InitializeComponent();
            empleadoModel = new EmpleadoModel();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = "Uziel";
                string apellido = "Duarte";
                string cedula = "nono";
                string telefono = "83811309";
                string correo = "uzieljduarte@gmail.com";
                int index = 1;//cmbProfesion.SelectedIndex;
                Profesion profesion = (Profesion)Enum.GetValues(typeof(Profesion)).GetValue(index);
                index = 2;// cmbCargo.SelectedIndex;
                Cargo cargo = (Cargo)Enum.GetValues(typeof(Cargo)).GetValue(index);
                //string salario = txtSalario.Text;

                //validarEmpleado(nombre, apellido, cedula, telefono, correo, out decimal salario, out int id);

                Empleado empleado = new Empleado()
                {
                    //id = id,
                    nombre = nombre,
                    apellido = apellido,
                    cedula = cedula,
                    telefono = telefono,
                    correo = correo,
                    profesion = profesion,
                    cargo = cargo,
                    salario = 64000,
                };

                empleadoModel.add(empleado);
                MessageBox.Show("Empleado agregado satisfactoriamente");
                dgvEmpleados.DataSource = empleadoModel.getAll();
                dgvEmpleados.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.Rows.Count == 0)
                return;

            if (dgvEmpleados.CurrentCell.RowIndex < 0)
                return;

            int index = dgvEmpleados.CurrentCell.RowIndex;
            //to be continue
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.Rows.Count == 0 || dgvEmpleados.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Tabla sin datos o fila no seleccionada");
                return;
            }

            int index = dgvEmpleados.CurrentCell.RowIndex;
            string id = dgvEmpleados.Rows[index].Cells[0].Value.ToString();

            empleadoModel.remove(int.Parse(id));
            dgvEmpleados.DataSource = empleadoModel.getAll();
            dgvEmpleados.Refresh();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (dgvEmpleados.Rows.Count == 0)
                return;

            List<Empleado> filtro = new List<Empleado>();
            string Clave = txtBuscar.Text;
            foreach (Empleado emp in empleadoModel.getAll())
            {
                if ((emp.id + "").Contains(Clave) || emp.nombre.Contains(Clave) || emp.apellido.Contains(Clave)
                    || emp.cedula.Contains(Clave) || emp.telefono.Contains(Clave) || emp.correo.Contains(Clave)
                    || (emp.salario + "").Contains(Clave))
                    filtro.Add(emp);

            }

            if (filtro.Count > 0)
                dgvEmpleados.DataSource = filtro;
            else
                dgvEmpleados.DataSource = empleadoModel.getAll();
        }
    }
}
