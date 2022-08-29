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
    public partial class Clientes : Form
    {

        private int usuario;
        public Clientes(int usuario)
        {
            InitializeComponent();

            this.usuario = usuario;
        }

        private int getUsuario()
        {
           
            return usuario;
        }
        private void testForm_Load(object sender, EventArgs e)
        {
            txtFechaActual.Text = DateTime.Now.ToString("dd-MM-yyyy");

            Conexiones conexiones = new Conexiones();

            dgvBusqueda.DataSource = conexiones.actualizarPlanillaClientes();

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private int verificarTarifa(int selectedVehiculo, int selectedPlan)
        {
            int tarifa;

            if (selectedVehiculo == 0 & selectedPlan == 0)
            {
                tarifa = 3;
            }
            else if (selectedVehiculo == 0 & selectedPlan == 1)
            {
                tarifa = 4;
            }
            else if (selectedVehiculo == 0 & selectedPlan == 2)
            {
                tarifa = 5;
            }
            else if (selectedVehiculo == 1 & selectedPlan == 0)
            {
                tarifa = 8;
            }
            else if (selectedVehiculo == 1 & selectedPlan == 1)
            {
                tarifa = 9;
            }
            else if (selectedVehiculo == 1 & selectedPlan == 2)
            {
                tarifa = 10;
            }
            else if (selectedVehiculo == 2 & selectedPlan == 0)
            {
                tarifa = 13;
            }
            else if (selectedVehiculo == 2 & selectedPlan == 1)
            {
                tarifa = 14;
            }
            else if (selectedVehiculo == 2 & selectedPlan == 2)
            {
                tarifa = 15;
            }
            else
            {
                tarifa = 0;
            }

            return tarifa;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Conexiones conexiones = new Conexiones();


            string idCliente = txIdCliente.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string documento = txtDocumento.Text;
            string telefono = txtTelefono.Text;
            string patenteR = txtPatenteR.Text.ToUpper();
            string domicilio = txtDomicilio.Text;
            string fechaInicia = dtpFechaInicio.Text;
            string fechaVencimiento = dtpVencimiento.Text;
            string nota = rTxtNota.Text;
            int tarifa = verificarTarifa(cbxVehiculo.SelectedIndex, cmbPlanes.SelectedIndex);
       

            string sqlRegistro = "";

            


            conexiones.GuardarCliente(nombre, apellido, documento, telefono, patenteR, nota, getUsuario());


            /*---------------------------------------*/

            MySqlConnection conexionDB = Conexiones.conexion();

            try
            {
                conexionDB.Open();

                sqlRegistro = "select idCliente from clientes where nombre = '" + nombre + "' and apellido = '" + apellido + "' and documento = '" + documento + "' and telefono = '" + telefono + "';";

                MySqlCommand COMANDO = new MySqlCommand(sqlRegistro, conexionDB);

                COMANDO.CommandType = CommandType.Text;

                MySqlDataReader reader = COMANDO.ExecuteReader();

                if (reader.Read())
                {
                    txIdCliente.Text = reader[0].ToString();

                }
                int cliente = Convert.ToInt32(reader[0].ToString());

                conexionDB.Close();

             
                conexiones.IngresarDatos((txtPatenteR.Text).ToUpper(), cbxVehiculo.SelectedIndex, this.usuario, tarifa, cliente, fechaInicia, fechaVencimiento);

                conexiones.registroFacturas(Convert.ToInt32(txIdCliente.Text), Convert.ToDouble(txtImporte.Text));
                MessageBox.Show("Cliente guardado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar! " + ex.Message);
            }
          

        }

        private void dgvBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void dgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable datable = new DataTable();
            txIdCliente.Text = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[1].Value.ToString();
            txtApellido.Text = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[2].Value.ToString();
            txtDocumento.Text = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[3].Value.ToString();
            txtDomicilio.Text = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[4].Value.ToString();
            txtTelefono.Text = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[5].Value.ToString();
            txtFechaActual.Text = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[6].Value.ToString();
            dtpFechaInicio.Text = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[7].Value.ToString();
            dtpVencimiento.Text = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[8].Value.ToString();
            cbxVehiculo.SelectedItem = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[10].Value.ToString();
            rTxtNota.Text = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[11].Value.ToString();
            txtPatenteR.Text = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[12].Value.ToString();

        }

        private void dgvBusqueda_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string idCliente = txIdCliente.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string documento = txtDocumento.Text;
            string telefono = txtTelefono.Text;
            string patenteR = txtPatenteR.Text.ToUpper();
            string domicilio = txtDomicilio.Text;
            string fechaInicia = dtpFechaInicio.Text;
            string fechaVencimiento = dtpVencimiento.Text;
            string nota = rTxtNota.Text;
            int tarifa = verificarTarifa(cbxVehiculo.SelectedIndex, cmbPlanes.SelectedIndex);

            Conexiones conexiones = new Conexiones();

            conexiones.updateCliente(idCliente, nombre, apellido, documento, domicilio, telefono, fechaVencimiento, nota, patenteR, getUsuario(), tarifa);
        }

        private void cmbPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPagar_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
            rTxtNota.Clear();
            txtDomicilio.Clear();
            txtTelefono.Clear();
            cbxVehiculo.Items.Clear();
            txtPatenteR.Clear();
        }
    }
}
