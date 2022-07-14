using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Parking
{
    internal class Conexiones
    {
        public static MySqlConnection conexion()
        {
            string servidor = "127.0.0.1";
            string puerto = "3306";
            string usuario = "root";
            string password = "1528";
            string bd = "parkingdb";

            string cadenaConexion = "database=" + bd + "; data source=" + servidor + "; port=" + puerto + ";user id=" + usuario + "; password=" + password;


            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                return conexionBD;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
            
        }

        public void IngresarDatos(string patente, int idVehiculo)
        {
            int vehiculo = idVehiculo + 1;
            DataTable datable = new DataTable();


            string sql = "";


            MessageBox.Show(vehiculo.ToString());


            if (String.IsNullOrEmpty(patente))
            {
                MessageBox.Show("Debe llenar el campo patente");

            }

            else if (vehiculo < 0)
            {
                MessageBox.Show("Seleccione el vehículo a ingresar");
            }

            else
            {
                sql = "insert into patentes (idPatente, tarifa, cliente) values ('" + patente + "', '" + 1 + "', '" + 1 + "');" +
                    "insert into ingresoysalida (patente, horaingreso, vehiculo, estado) values ('" + patente + "', '" + DateTime.Now + "', '" + vehiculo + "', '" + 1 + "');";



                MySqlConnection conexionDB = Conexiones.conexion();
                conexionDB.Open();

                try
                {
                    MySqlCommand COMANDO = new MySqlCommand(sql, conexionDB);
                    COMANDO.ExecuteNonQuery();
                    MessageBox.Show("Registro guardado!");


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar! " + ex.Message);
                }
                finally
                {
                    conexionDB.Close();
                    actualizarPlanilla();
                }


            }
        }

        public DataTable actualizarPlanilla()
        {

            MySqlConnection conexionDB = Conexiones.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;

            try
            {

                MySqlCommand actPlanilla = new MySqlCommand("SELECT id, horaIngreso, patente, vehiculo.vehiculo FROM ingresoysalida, vehiculo where estado = 1 and ingresoysalida.vehiculo = vehiculo.idVehiculo;", conexionDB);

                actPlanilla.CommandType = CommandType.Text;

                conexionDB.Open();

                resultado = actPlanilla.ExecuteReader();

                datable.Load(resultado);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

            principal actEstado = new principal();

            return datable;

        }


        public void SaleVehiculo(float total, string idSelected)
        {
            string update = "UPDATE `parkingdb`.`ingresoysalida` SET `horasalida` = '" + DateTime.Now + "', `estado` = '" + 0 + "', `total` = '" + total + "' WHERE(`id` = '" + idSelected + "');";



            MySqlConnection conexionDB = Conexiones.conexion();
            conexionDB.Open();

            try
            {

                MySqlCommand COMANDO = new MySqlCommand(update, conexionDB);
                COMANDO.ExecuteNonQuery();

                //actualiza planilla luego de cargar salida
                actualizarPlanilla();

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