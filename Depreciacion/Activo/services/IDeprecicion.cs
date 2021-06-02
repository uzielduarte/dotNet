
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activo.services
{
    public interface IDeprecicion
    {
        decimal[] calcularDeprecicion(decimal valor, decimal valorR, int vidaUtil);
    }
}
