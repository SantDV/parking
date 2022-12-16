using System;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;

namespace Parking
{
    public partial class configuracion : Form
    {

        public configuracion()
        {
            InitializeComponent();
            txtCantidad.Text = Convert.ToString(getCantidad());

        }
        public void botonAplicar_Click(object sender, EventArgs e)
        {

            principal principal = new principal();

            try
            {
                bool correcto = false;

                foreach (char c in txtCantidad.Text)
                {
                    int unicode = c;

                    if (unicode >= 48 && unicode <= 57)
                    {
                        correcto = true;
                    }
                    else
                    {
                        correcto = false;
                        break;
                    }

                }

                if (correcto)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Remove("cantidadPlazas");
                    config.AppSettings.Settings.Add("cantidadPlazas", txtCantidad.Text);

                    config.Save(ConfigurationSaveMode.Modified);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Solo números enteros positivos!");
                }

            
             
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
               
                Application.Restart();

            }
                
            
        }

        public string getCantidad()
        {
            string cantidad = ConfigurationManager.AppSettings["cantidadPlazas"];

            return cantidad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ckbUsuario_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
