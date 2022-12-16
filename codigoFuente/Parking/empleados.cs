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
            int tipoUsuario = cmbxTempleado.SelectedIndex;

            Conexiones conexiones = new Conexiones();

            conexiones.GuardarEmpleado(nombre, apellido, documento, domicilio, telefono, mail, usuario, contraseña, tipoUsuario);

            

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
            Conexiones conexiones = new Conexiones();

            dgvBusqueda.DataSource = conexiones.actualizarPlanillaEmpleado();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            
        }

  
        private void button4_Click(object sender, EventArgs e)
        {
            Conexiones conexiones = new Conexiones();

            dgvBusqueda.DataSource = conexiones.BuscarEmpleado();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Conexiones conexiones = new Conexiones();
            conexiones.borrarEmpleado(Convert.ToInt32(txtIdEmpleado.Text));
        }
    }
}
