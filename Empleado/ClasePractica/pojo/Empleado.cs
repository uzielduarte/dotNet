﻿using ClasePractica.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasePractica.pojo
{
    class Empleado
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public Profesiones profesion { get; set; }
        public Cargos cargo { get; set; }
        public decimal salario { get; set; }
    }
}
