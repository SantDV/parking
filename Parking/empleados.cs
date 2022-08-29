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

        private bool comprobarCadena(string cadena) //cadena de comprobacion para caracteres ingresados
        {

            bool cadenaCorrecta = false;

            foreach (char c in cadena)
            {
                int unicode = c;

                if (unicode >= 48 && unicode <= 57 || unicode >= 97 && unicode <= 122)
                {
                    cadenaCorrecta = true;
                }
                else
                {
                    cadenaCorrecta = false;
                    break;
                }

            }

            return cadenaCorrecta;
        }

        private bool comprobarNumeros(string cadena) //cadena de comprobacion para caracteres numericos ingresados
        {

            var isNumeric = int.TryParse(cadena, out _);
            return isNumeric;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.ToLower();
            string apellido = txtApellido.Text.ToLower();
            string documento = txtDocumento.Text.ToLower();
            string domicilio = txtDomicilio.Text.ToLower();
            string telefono = txtTelefono.Text.ToLower();
            string mail = txtMail.Text.ToLower();
            string usuario = txtUsuario.Text.ToLower();
            string contraseña = txtPass.Text.ToLower();
            string tipoUsuario = cmbxTempleado.SelectedIndex.ToString();

            Conexiones conexiones = new Conexiones();

            if(comprobarCadena(nombre) && comprobarCadena(apellido) && comprobarCadena(domicilio) && comprobarCadena(usuario) && comprobarCadena(contraseña) && comprobarCadena(documento))
            {
                if(comprobarNumeros(telefono) && comprobarNumeros(tipoUsuario))
                {
                    conexiones.GuardarEmpleado(nombre, apellido, documento, domicilio, telefono, mail, usuario, contraseña, Convert.ToInt32(tipoUsuario));
                }
            }
            else
            {
                MessageBox.Show("Caracteres ingresados incorrectos");
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

           
            if(txtIdEmpleado.Text != "")
            {
                dgvBusqueda.DataSource = conexiones.BuscarEmpleado(txtIdEmpleado.Text, 0);
            }
            if(txtNombre.Text != "")
            {
                dgvBusqueda.DataSource = conexiones.BuscarEmpleado(txtNombre.Text, 1);
            }
            if (txtApellido.Text != "")
            {
                dgvBusqueda.DataSource = conexiones.BuscarEmpleado(txtApellido.Text, 2);
            }
            if (txtDocumento.Text != "")
            {
                dgvBusqueda.DataSource = conexiones.BuscarEmpleado(txtDocumento.Text, 3);
            }

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

            if (txtIdEmpleado.Text == "" || txtIdEmpleado.Text == null)
            {
                MessageBox.Show("Debe ingresar el id del usuario a borrar");
            }
            else
            {
                conexiones.borrarEmpleado(Convert.ToInt32(txtIdEmpleado.Text));
            }
            
            
        }
    }
}
