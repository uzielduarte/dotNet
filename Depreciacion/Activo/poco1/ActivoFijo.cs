using Activo.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activo.poco1
{
    class ActivoFijo
    {
        public string nombre { get; set; }
        public string codigo { get; set; }
        public decimal valor { get; set; }
        public decimal valorResidual { get; set; }
        public TipoActivo tipoActivo { get; set; }
    }
}
