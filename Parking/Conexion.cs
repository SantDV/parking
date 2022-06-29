using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking
{
    internal class Conexion
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

    }

}