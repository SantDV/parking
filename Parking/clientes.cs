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
using System.Runtime.InteropServices;

namespace Parking
{
    public partial class clientes : Form
    {
        public clientes()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string documento = txtDocumento.Text;
            string telefono = txtTelefono.Text;
            
            string patenteR = txtPatenteR.Text;
            string sqlRegistro = "";


           

            /*---------------------------------------*/


            MySqlConnection conexionDB = Conexion.conexion();

            conexionDB.Open();

            try
            {
                sqlRegistro = "insert into clientes (nombre, apellido, documento, telefono, fechaRegistro) values ('" + nombre + "', '" + apellido + "', " + documento + " , " + telefono + ", '" + DateTime.Now + "');";

                MySqlCommand COMANDO = new MySqlCommand(sqlRegistro, conexionDB);
                COMANDO.ExecuteNonQuery();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar! " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }


            try
            {
                conexionDB.Open();

                sqlRegistro = "select idCliente from clientes where nombre = '"+nombre+"' and apellido = '"+apellido+"' and documento = '"+documento+"' and telefono = '"+telefono+"';";

                MySqlCommand COMANDO = new MySqlCommand(sqlRegistro, conexionDB);

                COMANDO.CommandType = CommandType.Text;

                MySqlDataReader reader = COMANDO.ExecuteReader();

                if (reader.Read())
                {
                    txIdCliente.Text = reader[0].ToString();
                }


               /*sqlRegistro = "insert into patenes (idPatente, tarifa, cliente) values ('" + patenteR + "', '"+ + "', " + txIdCliente.Text +"');";

                MySqlCommand COMANDO = new MySqlCommand(sqlRegistro, conexionDB);
                COMANDO.ExecuteNonQuery();
                MessageBox.Show("Cliente guardado!");*/

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar! " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection conexionDB = Conexion.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;

            conexionDB.Open();

            string id = txIdCliente.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string documento = txtDocumento.Text;
            string telefono = txtTelefono.Text;
            string patente = txtPatenteR.Text;
            string consultaBusqueda = "";


            if (!String.IsNullOrEmpty(id))
            {
                consultaBusqueda = "SELECT nombre, idpatente, planes.plan from clientes, patentes, planes, tarifas where idCliente= '"+id+"' and tarifas.plan = idPlan and patentes.tarifa = tarifas.idtarifas and patentes.cliente = clientes.idcliente;";
            }
            else if(!string.IsNullOrEmpty(nombre))
                {
                consultaBusqueda = "SELECT nombre, idpatente, planes.plan from clientes, patentes, planes, tarifas where nombre= '"+nombre+ "' and tarifas.plan = idPlan and patentes.tarifa = tarifas.idtarifas and patentes.cliente = clientes.idcliente;";
            }
            else if (!string.IsNullOrEmpty(apellido))
            {
                consultaBusqueda = "SELECT nombre, idpatente, planes.plan from clientes, patentes, planes, tarifas where apellido= '"+apellido+ "' and tarifas.plan = idPlan and patentes.tarifa = tarifas.idtarifas and patentes.cliente = clientes.idcliente;";
            }
            else if (!string.IsNullOrEmpty(documento))
            {
                consultaBusqueda = "SELECT nombre, idpatente, planes.plan from clientes, patentes, planes, tarifas where documento= "+documento+ " and tarifas.plan = idPlan and patentes.tarifa = tarifas.idtarifas and patentes.cliente = clientes.idcliente;";
            }
            else if (!string.IsNullOrEmpty(patente))
            {
                consultaBusqueda = "SELECT nombre, idpatente, planes.plan from clientes, patentes, planes, tarifas where patentes.idpatente = '"+patente+"' and tarifas.plan = idPlan and patentes.tarifa = tarifas.idtarifas and patentes.cliente = clientes.idcliente;";
            }



            try
                {

                    MySqlCommand actPlanilla = new MySqlCommand(consultaBusqueda, conexionDB);

                    actPlanilla.CommandType = CommandType.Text;

                    resultado = actPlanilla.ExecuteReader();

                    datable.Load(resultado);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
            

            dgvBusqueda.DataSource = datable;


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPatenteR_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbxVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conexionDB = Conexion.conexion();
        }

        private void clientes_Load(object sender, EventArgs e)
        {
            {
                MySqlConnection conexionDB = Conexion.conexion();
                DataTable datable = new DataTable();
                MySqlDataReader resultado;

                string consulta = "SELECT idCliente, nombre, apellido, vehiculo.vehiculo, idpatente, telefono, patentes.idPatente, planes.plan from clientes, patentes, planes, tarifas, vehiculo where idvehiculo = tarifas.tipoVehiculo and tarifas.plan = idPlan and patentes.tarifa = tarifas.idtarifas and patentes.cliente = clientes.idcliente and clientes.nombre != 'Sin registrar';";

                try
                {

                    MySqlCommand actPlanilla = new MySqlCommand(consulta, conexionDB);

                    actPlanilla.CommandType = CommandType.Text;

                    conexionDB.Open();

                    resultado = actPlanilla.ExecuteReader();

                    datable.Load(resultado);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }

                dgvBusqueda.DataSource = datable;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txIdCliente.Clear();
            txtNombre.Clear(); 
            txtApellido.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtPatenteR.Clear();
        }

        private void dgvBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgragarV_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string documento = txtDocumento.Text;
            string telefono = txtTelefono.Text;
            int vehiculo = 0;
            string patenteR = txtPatenteR.Text;
            string sqlRegistro = "";


            if (cbxVehiculo.SelectedItem.ToString() == "Auto")
            {
                vehiculo = 1; //auto
            }
            else if (cbxVehiculo.SelectedItem.ToString() == "Moto")
            {
                vehiculo = 2; //moto
            }
            else
            {
                vehiculo = 3; //bicicleta
                patenteR = "0";
            }

            sqlRegistro = "insert into clientes (nombre, apellido, documento, telefono, vehiculo, patente, fechaRegistro) values ('" + nombre + "', '" + apellido + "','" + documento + "', '" + telefono + "', '" + vehiculo + "', '" + patenteR + "', '" + DateTime.Now + "');";


            MySqlConnection conexionDB = Conexion.conexion();

            conexionDB.Open();

            try
            {
                MySqlCommand COMANDO = new MySqlCommand(sqlRegistro, conexionDB);
                COMANDO.ExecuteNonQuery();
                MessageBox.Show("Cliente guardado!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar! " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }
    }
    
}
