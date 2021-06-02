using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activo.services
{
    public class LineaRecta : IDeprecicion
    {
        public decimal[] calcularDeprecicion(decimal valor, decimal valorR, int vidaUtil)
        {
            decimal[] dep = new decimal[vidaUtil];
            decimal d = (valor - valorR) / vidaUtil;
            for(int i = 0; i < dep.Length; i++)
            {
                dep[i] = d;
            }

            return dep;
        }
    }
}
