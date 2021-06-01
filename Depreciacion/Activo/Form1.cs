using Activo.enums;
using Activo.poco1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activo
{
    public partial class Activo : Form
    {
        private ActivoFijo[] activoFijos;
        public Activo()
        {
            InitializeComponent();
            loadTipoActivo();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Activo_Load(object sender, EventArgs e)
        {

        }

        private void loadTipoActivo()
        {
            cmbTipoActivo.Items.AddRange(Enum.GetValues(typeof(TipoActivo))
                         .Cast<object>()
                         .ToArray());
            cmbTipoActivo.SelectedIndex = 0;
        }
    }
}
