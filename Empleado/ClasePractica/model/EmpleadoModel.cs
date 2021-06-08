using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasePractica.model
{
    class EmpleadoModel
    {
        private Empleado[] empleados;

        public EmpleadoModel()
        {

        }

        public void add(Empleado empleado)
        {
            if (empleados == null)
            {
                empleados = new Empleado[1];
                empleados[0] = empleado;
                return;
            }

            Empleado[] temp = new Empleado[empleados.Length + 1];
            Array.Copy(empleados, temp, empleados.Length);
            temp[temp.Length - 1] = empleado;

            empleados = temp;
        }

        public void remove(int index)
        {
            if (index < 0)
                return;

            if (empleados == null)
                return;

            if (index >= empleados.Length)
                throw new IndexOutOfRangeException($"El index {index} esta fuera de rango");

            if (index == 0 && empleados.Length == 1)
            {
                empleados = null;
                return;
            }

            Empleado[] temp = new Empleado[empleados.Length - 1];

            if (index == 0)
            {
                Array.Copy(empleados, index + 1, temp, 0, temp.Length);
                empleados = temp;
                return;
            }

            if (index == empleados.Length - 1)
            {
                Array.Copy(empleados, 0, temp, 0, temp.Length);
                empleados = temp;
                return;
            }

            Array.Copy(empleados, 0, temp, 0, index);
            Array.Copy(empleados, index + 1, temp, index, temp.Length - index);
            empleados = temp;
        }

        public Empleado[] getAll()
        {
            return empleados;
        }
    }
}
