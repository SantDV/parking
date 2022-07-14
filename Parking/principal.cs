using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Parking
{
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
            cbxBuscar.SelectedIndex = 0;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Conexiones conexiones = new Conexiones();

            conexiones.IngresarDatos(txtPatente.Text, cmbVehiculo.SelectedIndex);

            dgvEstado.DataSource = conexiones.actualizarPlanilla();

        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {

            MySqlConnection conexionDB = Conexiones.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;
            
            string busquedaTxt = "";

            if (cbxBuscar.SelectedIndex == 0)
            {
                busquedaTxt = "id";
            }
            else if(cbxBuscar.SelectedIndex == 1)
            {
                busquedaTxt = "patente";
            }
            else if (cbxBuscar.SelectedIndex == 2)
            {
                busquedaTxt = "cliente.nombre";
            }

            conexionDB.Open();

            if (txtBuscar.Text != "")
            {
                try
                {

                    MySqlCommand comando = new MySqlCommand("SELECT id, horaIngreso, patente, vehiculo.vehiculo FROM ingresoysalida, vehiculo, clientes where estado = 1 and ingresoysalida.vehiculo = vehiculo.idVehiculo and " + busquedaTxt + " ='" + txtBuscar.Text + "';", conexionDB) ;

                    comando.CommandType = CommandType.Text;

                    resultado = comando.ExecuteReader();

                    datable.Load(resultado);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }

                dgvEstado.DataSource = datable;
            }
            
            
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexiones conexiones = new Conexiones();

            dgvEstado.DataSource = conexiones.actualizarPlanilla();


            tarifas cargarT = new tarifas();

            cargarT.cargarTarifas();
            
        
        }


        private void txtCampo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresos_Click(object sender, EventArgs e)
        {
       
        }

        private void txtPatente_TextChanged(object sender, EventArgs e)
        {
          /*  MySqlConnection conexionDB = Conexion.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;

           conexionDB.Open();    

            string patente = txtPatente.Text;

         
            string consultaBusqueda = "select idPatente from patentes where idpatente = '"+patente+"';";
            
            try
            {
                if(txtPatente.Text.Length >= 6) 
                {
                MySqlCommand buscarPatente = new MySqlCommand(consultaBusqueda, conexionDB);

                buscarPatente.CommandType = CommandType.Text;

                resultado = buscarPatente.ExecuteReader();

                    if (resultado.Read())
                    {
                        txtCliente.Text = resultado.GetString(0);
                        cmbVehiculo.Enabled = false;
                        
                        
                    }
                    else
                    {
                        conexionDB.Close();
                        txtCliente.Text = "Con.Final";
                        cmbVehiculo.Enabled = true;
                        

                        DataTable cmbDatos = new DataTable();
                        

                        conexionDB.Open();
                        MySqlCommand cargarVehiculo = new MySqlCommand("select vehiculo from vehiculo;", conexionDB);

                        MySqlDataReader resultado2 = cargarVehiculo.ExecuteReader();

                        cmbDatos.Load(resultado2);

                        cmbVehiculo.DisplayMember = "vehiculo";
                        cmbVehiculo.DataSource = cmbDatos;


                        conexionDB.Close();

                        conexionDB.Open();

                        MySqlCommand cargarPlan = new MySqlCommand("select plan from planes;", conexionDB);

                        MySqlDataReader resultado3 = cargarPlan.ExecuteReader();

                        cmbDatos.Load(resultado3);

                        

                        conexionDB.Close();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
             */
        

        }

        private void txtPatente_Click(object sender, EventArgs e)
        {
            txtPatente.Text = "";
            txtBuscar.ForeColor = SystemColors.MenuText;
        }


        private void txtCampo_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            txtBuscar.ForeColor = SystemColors.MenuText;
        }

        private int horasTotales() // La funcion calculara el valor a pagar y lo guardara en la bd
        {
            int i = dgvEstado.CurrentCell.RowIndex;
            var fechaIngreso = dgvEstado.Rows[i].Cells[1].Value.ToString();


            string minutosTranscurrido = Convert.ToString((DateTime.Now - (DateTime.Parse(fechaIngreso))).TotalMinutes.ToString());

            string[] minutos = minutosTranscurrido.Split(',');

            int minutosRedondos = ((Convert.ToInt32(minutos[0])) / 60);
            float minutosDecimal = ((Convert.ToSingle(minutos[0])) / 60);

            if (minutosDecimal - minutosRedondos >= 0.10)
            {
                int totalHoras = minutosRedondos + 1;
                return totalHoras;
            }
            else
            {
                return minutosRedondos; ;
            }
            
        }

        private void sale_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("Confirma salida del vehiculo", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataTable datable = new DataTable();

    

                string idSelected = Convert.ToString(dgvEstado.CurrentCell.Value);
                int volverCelda = Convert.ToInt32(dgvEstado.CurrentCell.RowIndex);


                //Monto a pagar segun horas transcurridas


                float total = 0;

                var vehiculo = dgvEstado.Rows[dgvEstado.CurrentCell.RowIndex].Cells[3].Value.ToString();

                if (vehiculo == "AUTO")
                  {
                    total = horasTotales() * (Convert.ToInt32(datos.tarifaAuto));
                

                  }
                  else if (vehiculo == "MOTO")
                  {
                    total = horasTotales() * (Convert.ToInt32(datos.tarifaMoto));

                }
                  else
                  {
                    total = horasTotales() * (Convert.ToInt32(datos.tarifaBici));

                }

                lblTicket.Visible = true;
                lblTicket.Text = dgvEstado.Rows[dgvEstado.CurrentCell.RowIndex].Cells[0].Value.ToString();

                lblPatente.Visible = true;
                lblPatente.Text = dgvEstado.Rows[dgvEstado.CurrentCell.RowIndex].Cells[2].Value.ToString();

                lblHoras.Visible = true;
                lblHoras.Text = horasTotales().ToString();

                lblPesos.Visible = true;
                lblTotal.Visible = true;
                lblTotal.Text = total.ToString();
                /*------------------*/

                Conexiones conexiones = new Conexiones();

                conexiones.SaleVehiculo(total, idSelected);
            }
        
        
        }



     

        private void ckbBici_CheckedChanged(object sender, EventArgs e)
        {

            
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void btnIngresa_MouseHover(object sender, EventArgs e)
        {
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            clientes clientes = new clientes();

            clientes.Show();

        }

        private void ingresosretirosBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string volverCelda = Convert.ToString(dgvEstado.CurrentCell.RowIndex);

            MessageBox.Show(volverCelda);

        }

        private void panelIngresos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            int i = dgvEstado.CurrentCell.RowIndex;
            var fechaIngreso = dgvEstado.Rows[i].Cells[2].Value.ToString();

            string minutosTranscurrido = Convert.ToString((DateTime.Now - (DateTime.Parse(fechaIngreso))).TotalMinutes.ToString());

            string[] minutos = minutosTranscurrido.Split(',');

            int minutosRedondos = ((Convert.ToInt32(minutos[0])) / 60);
            float minutosDecimal = ((Convert.ToSingle(minutos[0])) / 60);

            if (minutosDecimal - minutosRedondos >= 0.10)
            {
                minutosRedondos += 1;
            }

            MessageBox.Show(minutosRedondos.ToString());

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnHistorial_Click(object sender, EventArgs e)
        {
            historial historial = new historial();

            historial.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            empleados empleados1 = new empleados(); 
            empleados1.Show();  
        }

        private void btnIngresos_MouseHover(object sender, EventArgs e)
        {
            btnIngresos.ForeColor = Color.FromArgb(250, 250, 250);
        
        }

        private void txtMoto_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(cmbVehiculo.SelectedIndex == 0)
            {
                imgBici.Visible = true;            
                imgMoto.Visible = false;
                imgAuto.Visible = false;
            }
            else if(cmbVehiculo.SelectedIndex == 1)
            {
                imgBici.Visible = false;
                imgMoto.Visible = true;
                imgAuto.Visible = false;
                
            }
            else
            {
                imgBici.Visible = false;             
                imgMoto.Visible = false;
                imgAuto.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gpbTicket_Enter(object sender, EventArgs e)
        {

        }

        private void lblHoras_Click(object sender, EventArgs e)
        {

        }

        private void lblPatente_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tarifas tarifas = new tarifas();
            tarifas.Show();
        }
    }

    public class Class2
    {
    }
}

