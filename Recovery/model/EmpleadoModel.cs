using Recovery.poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recovery.model
{
    class EmpleadoModel
    {
        private Empleado[] empleados;
        int id = 1;

        public EmpleadoModel()
        {

        }

        public void add(Empleado empleado)
        {
            empleado.id = id;
            if (empleados == null)
            {
                empleados = new Empleado[1];
                empleados[0] = empleado;
                id++;
                return;
            }

            Empleado[] temp = new Empleado[empleados.Length + 1];
            Array.Copy(empleados, temp, empleados.Length);
            temp[temp.Length - 1] = empleado;

            empleados = temp;
            id++;
        }

        public void remove(int id)
        {
            Empleado[] temp = new Empleado[empleados.Length - 1];
            int index = 0;
            foreach (Empleado p in empleados)
            {
                if (p.id != id)
                {
                    temp[index] = p;
                    index++;
                }
            }
            empleados = temp;
        }

        public Empleado[] getAll()
        {
            return empleados;
        }

        public Empleado GetEmpleado(int id)
        {
            foreach (Empleado p in empleados)
                if (p.id == id)
                    return p;
            return null;
        }

        public void Acutalizar(int id, Empleado e)
        {
            foreach (Empleado p in empleados)
            {
                if (p.id == id)
                {
                    p.id = e.id;
                    p.nombre = e.nombre;
                    p.apellido = e.apellido;
                    p.cedula = e.cedula;
                    p.telefono = e.telefono;
                    p.correo = e.correo;
                    p.salario = e.salario;
                    p.profesion = e.profesion;
                    p.cargo = e.cargo;
                }
            }
            
        }

    }
}
