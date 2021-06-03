using Activo.poco1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activo.model
{
    class ActivoFijoModel
    {
        private ActivoFijo[] activosFijo;

        public ActivoFijoModel()
        {

        }

        public void add(ActivoFijo af)
        {
            if(activosFijo == null)
            {
                activosFijo = new ActivoFijo[1];
                activosFijo[0] = af;
                return;
            }

            ActivoFijo[] temp = new ActivoFijo[activosFijo.Length + 1];
            Array.Copy(activosFijo, temp, activosFijo.Length);
            temp[temp.Length - 1] = af;

            activosFijo = temp;
        }

        public void remove(int index)
        {
            if(index < 0)
                return;

            if(activosFijo == null)
                return;

            if(index >= activosFijo.Length)
                throw new IndexOutOfRangeException($"El index {index} esta fuera de rango");

            if(index == 0 && activosFijo.Length == 1)
            {
                activosFijo = null;
                return;
            }
            
            ActivoFijo[] temp = new ActivoFijo[activosFijo.Length - 1];

            if(index == 0)
            {
                Array.Copy(activosFijo, index + 1, temp, 0, temp.Length);
                activosFijo = temp;
                return;
            }

            if(index == activosFijo.Length - 1)
            {
                Array.Copy(activosFijo, 0, temp, 0, temp.Length);
                activosFijo = temp;
                return;
            }

            Array.Copy(activosFijo, 0, temp, 0, index);
            Array.Copy(activosFijo, index + 1, temp, index, temp.Length - index);
            activosFijo = temp;
        }

        public ActivoFijo[] getAll()
        {
            return activosFijo;
        }
    }
}
