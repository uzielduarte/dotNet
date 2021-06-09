using ClasePractica.enums;
using ClasePractica.model;
using ClasePractica.pojo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClasePractica
{
    public partial class FrmEmpleado : Form
    {
        private EmpleadoModel empleadoModel;
        Boolean CamposCargados = false;
        int FilaEditableIndex = -1;
        public FrmEmpleado()
        {
            InitializeComponent();
            loadComboBoxes();
            empleadoModel = new EmpleadoModel();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                //string id = txtID.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string cedula = txtCedula.Text;
                string telefono = txtTelefono.Text;
                string correo = txtCorreo.Text;
                int index = cmbProfesion.SelectedIndex;
                Profesiones profesion = (Profesiones)Enum.GetValues(typeof(Profesiones)).GetValue(index);
                index = cmbCargo.SelectedIndex;
                Cargos cargo = (Cargos)Enum.GetValues(typeof(Cargos)).GetValue(index);
                //string salario = txtSalario.Text;

                validarEmpleado(nombre, apellido, cedula, telefono, correo, out decimal salario, out int id);

                Empleado empleado = new Empleado()
                {
                    id = id,
                    nombre = nombre,
                    apellido = apellido,
                    cedula = cedula,
                    telefono = telefono,
                    correo = correo,
                    profesion = profesion,
                    cargo = cargo,
                    salario = salario,
                };

                empleadoModel.add(empleado);
                MessageBox.Show("Empleado agregado satisfactoriamente");
                dgvEmpleados.DataSource = empleadoModel.getAll();
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void validarEmpleado(string nombre, string apellido, string cedula,
            string telefono, string correo, out decimal salario, out int id)
        {
            if (string.IsNullOrWhiteSpace((string)txtID.Text))
                throw new ArgumentException("El id es requerido");

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es requerido");

            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido es requerido");

            if (string.IsNullOrWhiteSpace(cedula))
                throw new ArgumentException("La cedula es requerida");

            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El telefono es requerido");
            
            if (!IsPhoneNumber(telefono))
                throw new ArgumentException("Numero telefonico incorrecto. Un numero de telefono valido contiene: "
                    +"menos de 9 caracteres, un + al comienzo y solo dígitos.");

            if (!IsValidEmail(correo))
                throw new ArgumentException("El correo no es valido");

            if (!decimal.TryParse(txtSalario.Text, out decimal v))
                throw new ArgumentException($"El valor {txtSalario.Text} es invalido");
            salario = v;
            if (!int.TryParse(txtID.Text, out int ide))
                throw new ArgumentException($"El valor {txtID.Text} es invalido");
            id = ide;
        }
        //https://www.it-swarm-es.com/es/c%23/como-validar-un-numero-de-telefono/1052119912/
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{8})$").Success;
        }

        //https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.Rows.Count == 0)
                return;

            int index = dgvEmpleados.CurrentCell.RowIndex;
            empleadoModel.remove(index);
            dgvEmpleados.DataSource = empleadoModel.getAll();
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtSalario.Text = "";
            cmbProfesion.SelectedIndex = 0;
            cmbCargo.SelectedIndex = 0;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.Rows.Count == 0)
                return;

            if (dgvEmpleados.CurrentCell.RowIndex < 0)
                return;

            int index = dgvEmpleados.CurrentCell.RowIndex;
            CargarCamposEmpleado(index);
            CamposCargados = true;
            FilaEditableIndex = index;
        }

        private void CargarCamposEmpleado(int index)
        {
            Empleado empleado = empleadoModel.GetEmpleado(index);

            txtID.Text = empleado.id + "";
            txtNombre.Text = empleado.nombre;
            txtApellido.Text = empleado.apellido;
            txtCedula.Text = empleado.cedula;
            txtTelefono.Text = empleado.telefono;
            txtCorreo.Text = empleado.correo;
            txtSalario.Text = empleado.salario + "";
            cmbProfesion.SelectedIndex = (int)empleado.profesion;
            cmbCargo.SelectedIndex = (int)empleado.cargo;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (!CamposCargados || FilaEditableIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la fila que desea actualizar y posteriormente guardar los cambios");
                return;
            }
            try
            {
                //string id = txtID.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string cedula = txtCedula.Text;
                string telefono = txtTelefono.Text;
                string correo = txtCorreo.Text;
                int index = cmbProfesion.SelectedIndex;
                Profesiones profesion = (Profesiones)Enum.GetValues(typeof(Profesiones)).GetValue(index);
                index = cmbCargo.SelectedIndex;
                Cargos cargo = (Cargos)Enum.GetValues(typeof(Cargos)).GetValue(index);
                //string salario = txtSalario.Text;

                validarEmpleado(nombre, apellido, cedula, telefono, correo, out decimal salario, out int id);

                Empleado empleado = new Empleado()
                {
                    id = id,
                    nombre = nombre,
                    apellido = apellido,
                    cedula = cedula,
                    telefono = telefono,
                    correo = correo,
                    profesion = profesion,
                    cargo = cargo,
                    salario = salario,
                };

                empleadoModel.Acutalizar(FilaEditableIndex, empleado);
                MessageBox.Show("Fila editada exitosamente");
                dgvEmpleados.DataSource = empleadoModel.getAll();
                limpiarCampos();
                CamposCargados = false;
                FilaEditableIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPalabraFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            if (dgvEmpleados.Rows.Count == 0)
                return;

            List<Empleado> filtro = new List<Empleado>();
            string Clave = txtPalabraFiltro.Text;
            foreach (Empleado emp in empleadoModel.GetEmpleados())
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
