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
    public partial class facturacion : Form
    {
        public facturacion()
        {
            InitializeComponent();
        }

        private void facturacion_Load(object sender, EventArgs e)
        {
            Conexiones conexiones = new Conexiones();

            dgvFacturacion.DataSource = conexiones.actualizarFacturacion(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"+1));
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Conexiones conexiones = new Conexiones();

            dgvFacturacion.DataSource = conexiones.actualizarFacturacion(fechaDesde.Text, fechaHasta.Text);
        }



        public double[] resumenTotal()
        {

            double cliente = 0, consFinal = 0;

            for (int i = 0; i < dgvFacturacion.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvFacturacion.Rows[i].Cells[2].Value) != 1)
                {
                    cliente += Convert.ToInt32(dgvFacturacion.Rows[i].Cells[3].Value);
                }
                else
                {
                    consFinal += Convert.ToInt32(dgvFacturacion.Rows[i].Cells[3].Value);
                }
            }

            double[] str = new double[2];

            str[0] = cliente;
            str[1] = consFinal;

            return str;
        }

        private void dgvFacturacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnResumen_Click(object sender, EventArgs e)
        {


            Resumen resumen = new Resumen(resumenTotal());

            resumen.Show();
        }

        
    }
}
