using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking
{
    public partial class Resumen : Form
    {
        double clientes = 0;
        double consFinal = 0;

        public Resumen(double[] clientes)
        {
            this.clientes = clientes[0];
            this.consFinal = clientes[1];
            InitializeComponent();
        }

        private void Resumen_Load(object sender, EventArgs e)
        {
            
            dgvResumen.Rows.Add("Cliente:  ");
            dgvResumen.Rows.Add("Cons final:  ");

    

            dgvResumen.Rows[0].Cells[1].Value = clientes;
            dgvResumen.Rows[1].Cells[1].Value = consFinal;

        }
    }
}
