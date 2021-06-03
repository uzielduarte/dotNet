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
    public partial class FrmMdi : Form
    {
        public FrmMdi()
        {
            InitializeComponent();
        }

        private void ActivosFijosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activo a = new Activo();
            a.MdiParent = this;
            a.Show();
        }

        private void FrmMdi_Load(object sender, EventArgs e)
        {

        }
    }
}
