using MySql.Data.MySqlClient;
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
    public partial class tarifas : Form
    {
        public tarifas()
        {
            InitializeComponent();
        }

        private void tarifas_Load(object sender, EventArgs e)
        {
            Conexiones conexiones = new Conexiones();

            dgrvTarifas.DataSource = conexiones.cargarTarifas();
        }

        

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        public static void dgrvTarifas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgrvTarifas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
