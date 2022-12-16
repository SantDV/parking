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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private bool comprobar(string cadena) //cadena de comprobacion para caracteres ingresados
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

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.ToLower();
            string pass = txtPass.Text.ToLower();



            if (comprobar(usuario) == true && comprobar(pass) == true)
            {
                principal principal = new principal();
            
                MySqlConnection conexionDB = Conexiones.conexion();
                string busqueda = "select idUsuario, usuario, pass, tipoUsuario from usuarios where usuario = '" + usuario + "' and pass = '" + pass + "';";

                conexionDB.Open();

                try
                {


                    MySqlCommand buscarId = new MySqlCommand(busqueda, conexionDB);

                    MySqlDataReader reader = buscarId.ExecuteReader();



                    if (reader.Read())
                    {

                        if (reader.GetString(1) == txtUsuario.Text & reader.GetString(2) == txtPass.Text)
                        {                        

                            principal.lblUserName.Text = txtUsuario.Text;
                            
                           

                            int idUsuario = Convert.ToInt32(reader.GetString(0));
                            principal.lblIdUsuario.Text = Convert.ToString(idUsuario);   
                          
                            

                    

                            if (reader.GetString(3) == "1")
                            {
                                principal.btnConfig.Enabled = true;
                                principal.btnEmpleados.Enabled = true;

                            }

                            principal.Show();
                            this.Hide();
                        }
                    
                    }
                    else
                    {
                        lblError.Visible = true;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    
                    conexionDB.Close();
                    
                }
            }
            else
            {
                MessageBox.Show("Caracteres ingresados incorrectos!");
            }
            

        }

        private void frmLogin_Load(object sender, EventArgs e)
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
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnEntrar_Click(sender, e);
                }
            }
        }
    }
}
