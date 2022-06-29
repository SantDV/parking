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
            cargarTarifas();
        }

        public void cargarTarifas()
        {
            MySqlConnection conexionDB = Conexion.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;

            try
            {

                MySqlCommand actTarifas = new MySqlCommand("select vehiculo.vehiculo, planes.plan, tarifa from tarifas, vehiculo, planes where tipoVehiculo = vehiculo.idvehiculo and tarifas.plan = planes.idplan;", conexionDB);

                actTarifas.CommandType = CommandType.Text;

                conexionDB.Open();

                resultado = actTarifas.ExecuteReader();

                datable.Load(resultado);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

            
            dgrvTarifas.DataSource = datable;

            datos.tarifaBici = (dgrvTarifas.Rows[0].Cells[2].Value).ToString();
            datos.tarifaMoto = (dgrvTarifas.Rows[1].Cells[2].Value).ToString();
            datos.tarifaCamioneta = (dgrvTarifas.Rows[2].Cells[2].Value).ToString();
            datos.tarifaAuto = (dgrvTarifas.Rows[3].Cells[2].Value).ToString();

           
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
