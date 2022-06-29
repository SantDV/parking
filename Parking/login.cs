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

        private void btnEntrar_Click(object sender, EventArgs e)
        {


            MySqlConnection conexionDB = Conexion.conexion();
            string busqueda = "select usuario, pass from usuarios where usuario = '"+ txtUsuario.Text +"' and pass = '"+ txtPass.Text +"';";

            conexionDB.Open();

            try
            {
            
                MySqlCommand buscarId = new MySqlCommand(busqueda, conexionDB);

                MySqlDataReader reader = buscarId.ExecuteReader();

                if (reader.Read())
                {
           
                    if(reader.GetString(0) == txtUsuario.Text & reader.GetString(1) == txtPass.Text)
                    {
                        

                        principal abrirMenu = new principal();                    

                        abrirMenu.Show();

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
