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
    public partial class empleados : Form
    {
        public empleados()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string documento = txtDocumento.Text;
            string domicilio = txtDomicilio.Text;
            string telefono = txtTelefono.Text;
            string mail = txtMail.Text;
            string usuario = txtUsuario.Text;
            string contraseña = txtPass.Text;
            string idUsuario = "";

            string sqlRegistro = "insert into usuarios (usuario, pass) values ('"+usuario+"', '"+contraseña+"');";
            

            MySqlConnection conexionDB = Conexiones.conexion();


            // TRY para guardar usuario y contraseña
            conexionDB.Open();

            try
            {
                MySqlCommand COMANDO = new MySqlCommand(sqlRegistro, conexionDB);
                COMANDO.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar! " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }


            //TRY para buscar id del usuario y contraseña con el que se guardaran los datos completos del nuevo empelado
            conexionDB.Open();

            string consultaId = "select idusuario from usuarios where usuario = '"+usuario+"' and pass = '"+contraseña+"';";

            try
            {

                MySqlCommand buscarId = new MySqlCommand(consultaId, conexionDB);

                MySqlDataReader reader = buscarId.ExecuteReader();

                while (reader.Read())
                {
                    idUsuario = reader.GetString(0);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }



            //TRY para guardar datos completos nuevo empleado

            string registrarEmpleado = "insert into empleados (nombre, apellido, documento, domicilio, telefono, mail, usuario) values ('" + nombre + "', '" + apellido + "'," + documento + ", '" + domicilio + "', '" + telefono + "', '" + mail + "', " + idUsuario + ");";
            conexionDB.Open();

            try
            {
                MySqlCommand COMANDO = new MySqlCommand(registrarEmpleado, conexionDB);
                COMANDO.ExecuteNonQuery();
                MessageBox.Show("Empleado registrado!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar! " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }

        }

        private void txtIdEmpleado_TextChanged(object sender, EventArgs e)
        {
           
            
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length >= 3)
            {

                txtUsuario.Text = txtNombre.Text.Substring(0, 3);
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
       
                if (txtApellido.Text.Length <= 1)
                {
                    txtUsuario.Text += txtApellido.Text.Substring(0);
                }
         
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void empleados_Load(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            
        }

  
        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection conexionDB = Conexiones.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;

            conexionDB.Open();

            string consultaBusqueda = "select idEmpleado, nombre, apellido, documento, domicilio, telefono, mail, usuarios.usuario from empleados, usuarios where empleados.usuario = usuarios.idusuario and idEmpleado = 7;";

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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtIdEmpleado.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtDomicilio.Clear();
            txtMail.Clear();
            txtUsuario.Clear();
            txtPass.Clear();
        }
    }
}
