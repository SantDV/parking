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


            if (estacionamientoLleno() || yaIngresado() || vehiculoNoSeleccionado())
            {
                
            }
            else //si las validaciones son correctas, se realiza el ingreso
            {
                conexiones.IngresarDatos((txtPatente.Text).ToUpper(), cmbVehiculo.SelectedIndex, Convert.ToInt32(lblIdUsuario.Text));
            }

            dgvEstado.DataSource = conexiones.actualizarPlanillaPrincipal();
            lblOcupados.Text = Convert.ToString(dgvEstado.Rows.Count);

        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {

            Conexiones conexiones = new Conexiones();

            MySqlConnection conexionDB = Conexiones.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;
            
            string busquedaTxt = "";

            if (cbxBuscar.SelectedIndex == 0)
            {
                busquedaTxt = "id";
            }
            else
            {
                busquedaTxt = "patente";
            }
  

            conexionDB.Open();

            if (txtBuscar.Text != "")
            {
                try
                {
                    
                    MySqlCommand comando = new MySqlCommand("SELECT id, horaIngreso, patente, vehiculo.vehiculo, usuarios.usuario FROM ingresoysalida, vehiculo, usuarios where estado = 1 and ingresoysalida.vehiculo = vehiculo.idVehiculo and ingresoysalida.ingresoUsuario = usuarios.idUsuario and " + busquedaTxt + " = '" + txtBuscar.Text + "';", conexionDB) ;

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
            else
            {
                dgvEstado.DataSource = conexiones.actualizarPlanillaPrincipal();
            }
            
            
        }


        //validaciones para ingreso de estacionamiento, ingresos y seleccion de vehículos
        private bool estacionamientoLleno()
        {
            if (Convert.ToInt32(lblOcupados.Text) == Convert.ToInt32(lblPlazasTotal.Text))
            {
                MessageBox.Show("Estacionamiento lleno");
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool yaIngresado()
        {
            Conexiones conexiones = new Conexiones();
            conexiones.actualizarPlanillaPrincipal();

            int i=0;

            int j= 1;

            while (i < dgvEstado.Rows.Count)
            {

                if (Convert.ToString(dgvEstado.Rows[i].Cells[2].Value) == txtPatente.Text)
                {
                    MessageBox.Show("Vehículo ya ingresado!");
                    j = 1;                           
                }
                else
                {
                    j = 0;
                }

                i++;
            }

            if(j == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool vehiculoNoSeleccionado()
        {
            if(cmbVehiculo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el tipo de vehículo");
                return true;
            }
            else
            {
                return false;
            }
        }
        //fin validaciones
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexiones conexiones = new Conexiones();
            configuracion configuracion = new configuracion();

            conexiones.vencimientos();
            dgvEstado.DataSource = conexiones.actualizarPlanillaPrincipal();
            lblOcupados.Text = Convert.ToString(dgvEstado.Rows.Count);
            lblPlazasTotal.Text = Convert.ToString(configuracion.getCantidad());
        }


        private void txtCampo_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtPatente_TextChanged(object sender, EventArgs e)
        {

           

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
            Conexiones conexiones = new Conexiones();

            string patente = dgvEstado.Rows[dgvEstado.CurrentCell.RowIndex].Cells[2].Value.ToString();

            //Mensaje en pantalla nos pide confirmacion y verifica si el vehiculo seleccionado es cliente común o registrado
            //de ser registrado no dejará retirarlo

            if (!conexiones.esCliente(patente))
            {
                if (MessageBox.Show("Confirma salida del vehiculo", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataTable datable = new DataTable();

                    dgvTarifas.DataSource = conexiones.cargarTarifas();

                    /* La salida del vehiculo la hacemos seleccionandolo directamente en el datagrid, podemos tambien realizar la buscada
                    desde un textbox si hay demasiados vehiculos */
                    string idSelected = Convert.ToString(dgvEstado.CurrentCell.Value);
                    int volverCelda = Convert.ToInt32(dgvEstado.CurrentCell.RowIndex);


                    //Monto a pagar segun horas transcurridas


                    float total;

                    var vehiculo = dgvEstado.Rows[dgvEstado.CurrentCell.RowIndex].Cells[3].Value.ToString();

                    //La funcion "horasTotales" nos permite calcular el tiempo transcurrido de acuerdo al tipo de vehiculo
                    if (vehiculo == "Auto")
                    {
                        //se lee el monto de acuerdo al cargado en el datagrid "tarifas"
                        total = horasTotales() * (Convert.ToInt32(dgvTarifas.Rows[10].Cells[2].Value));
                    }
                    else if (vehiculo == "Moto")
                    {
                        total = horasTotales() * (Convert.ToInt32(dgvTarifas.Rows[5].Cells[2].Value));

                    }
                    else
                    {
                        total = horasTotales() * (Convert.ToInt32(dgvTarifas.Rows[0].Cells[2].Value));

                    }

                    //enviamos la factura a la BD
                    


                    /*------------------*/
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

                    conexiones.SaleVehiculo(total, idSelected, Convert.ToInt32(lblIdUsuario.Text));
                    lblOcupados.Text = Convert.ToString(dgvEstado.Rows.Count);

                    conexiones.registroFacturas(1, total);
                }
            }
            else
            {
                MessageBox.Show("El vehiculo seleccionado es de un cliente con plan registrado");
            }

            dgvEstado.DataSource = conexiones.actualizarPlanillaPrincipal();
            lblOcupados.Text = Convert.ToString(dgvEstado.Rows.Count);

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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes(Convert.ToInt32(lblIdUsuario.Text));

            clientes.Show();

        }


        private void panelIngresos_Paint(object sender, PaintEventArgs e)
        {

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

        private void btnConfig_Click(object sender, EventArgs e)
        {
            configuracion configuracion = new configuracion();

            configuracion.Show();
        }

        private void lblOcupados_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }


        private void lblPlazasTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
           facturacion facturacion = new facturacion();

            facturacion.Show();
        }
    }

}

