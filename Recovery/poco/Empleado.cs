using Recovery.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recovery.poco
{
    class Empleado
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public Profesion profesion { get; set; }
        public Cargo cargo { get; set; }
        public decimal salario { get; set; }
    }
}
