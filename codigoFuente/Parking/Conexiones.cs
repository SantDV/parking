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
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }

        }

        public bool consultarPatenteBD(string patente)
        {
            MySqlConnection conexionDB = Conexiones.conexion();
            string busqueda = "select idPatente from patentes where idPatente = '"+ patente +"';";

            conexionDB.Open();

            MySqlCommand buscarId = new MySqlCommand(busqueda, conexionDB);

            MySqlDataReader reader = buscarId.ExecuteReader();



            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void IngresarDatos(string patente, int idVehiculo, int usuario, int tarifa = 1, int cliente = 1, string fechaInicia = "0", string fechaVencimiento = "0")
        {
            int vehiculo = idVehiculo + 1;

            DataTable datable = new DataTable();


            bool correcto = false;

            foreach (char c in patente)
            {
                int unicode = c;

                if (unicode >= 48 && unicode <= 57 || unicode >= 65 && unicode <= 90)
                {
                    correcto = true;
                }
                else
                {
                    correcto = false;
                    break;
                }
            }

            string sql = "";

            if (consultarPatenteBD(patente))
            {
                sql = "insert into ingresoysalida (patente, horaingreso, vehiculo, estado, ingresoUsuario) values ('" + patente + "', '" + DateTime.Now + "'" +
                    ", '" + vehiculo + "', '" + 1 + "', '" + usuario + "');";
            }
            else
            {
                sql = "insert into patentes (idPatente, tarifa, cliente, fechaInicio, fechaVencimiento) values ('" + patente + "', '" + tarifa + "', '" + cliente + "', '" + fechaInicia + "', '" + fechaVencimiento + "');" +
                    "insert into ingresoysalida (patente, horaingreso, vehiculo, estado, ingresoUsuario) values ('" + patente + "', '" + DateTime.Now + "'" +
                    ", '" + vehiculo + "', '" + 1 + "', '" + usuario + "');";
            }
            

            if (correcto)
            {
                MySqlConnection conexionDB = Conexiones.conexion();
                conexionDB.Open();

                try
                {
                    MySqlCommand COMANDO = new MySqlCommand(sql, conexionDB);
                    COMANDO.ExecuteNonQuery();



                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al guardar! " + ex.Message);

                }
                finally
                {
                    MessageBox.Show("Registro guardado!");
                    conexionDB.Close();
                }
            }
            else
            {
                MessageBox.Show("Datos ingresados no validos!");
            }



        }

        public DataTable actualizarPlanillaPrincipal()
        {

            MySqlConnection conexionDB = Conexiones.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;

            try
            {

                MySqlCommand actPlanilla = new MySqlCommand("SELECT id, horaIngreso, patente, vehiculo.vehiculo, usuarios.usuario FROM ingresoysalida, vehiculo, usuarios where estado = 1 and ingresoysalida.vehiculo = vehiculo.idVehiculo and ingresoysalida.ingresoUsuario = usuarios.idUsuario;", conexionDB);

                actPlanilla.CommandType = CommandType.Text;

                conexionDB.Open();

                resultado = actPlanilla.ExecuteReader();

                datable.Load(resultado);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

            return datable;

        }


        public DataTable actualizarPlanillaClientes()
        {
            MySqlConnection conexionDB = Conexiones.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;

            try
            {

                MySqlCommand actPlanilla = new MySqlCommand("SELECT idCliente, nombre, apellido, documento, domicilio, telefono, fechaRegistro, patentes.fechaInicio, patentes.fechaVencimiento, usuarios.usuario, vehiculo.vehiculo, nota, patentes.idPatente FROM clientes, usuarios, patentes, vehiculo, ingresoysalida where usuarioR = usuarios.idUsuario and idCliente = patentes.cliente and ingresoysalida.vehiculo = vehiculo.idvehiculo;", conexionDB);

                actPlanilla.CommandType = CommandType.Text;

                conexionDB.Open();

                resultado = actPlanilla.ExecuteReader();

                datable.Load(resultado);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

            return datable;
        }



        //conexiones.updateCliente(idCliente, nombre, apellido, documento, domicilio, telefono, fechaVencimiento, nota, getUsuario);
        public void updateCliente(string idCliente, string nombre, string apellido, string documento, string domicilio, string telefono, string fechaVencimiento, string nota, string patenteR, int usuario, int tarifa)
        {
            string update = "UPDATE `parkingdb`.`clientes` SET `nombre` = '" + nombre + "', `apellido` = '" + apellido + "', `documento` = '" + documento + "', `domicilio` = '" + domicilio + "', `telefono` = '" + telefono + "', `nota` = '" + nota + "', `usuarioR` = '" + usuario + "' WHERE(`idCliente` = '" + idCliente + "');" +
                "UPDATE `parkingdb`.`patentes` SET `tarifa` = '32', `fechaVencimiento` = '" + fechaVencimiento + "' WHERE(`idPatente` = '" + patenteR + "');";


            MySqlConnection conexionDB = Conexiones.conexion();
            conexionDB.Open();

            try
            {

                MySqlCommand COMANDO = new MySqlCommand(update, conexionDB);
                COMANDO.ExecuteNonQuery();

                //actualiza planilla luego de cargar salida
                actualizarPlanillaPrincipal();

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

        public DataTable actualizarPlanillaEmpleado()
        {
            MySqlConnection conexionDB = Conexiones.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;

            try
            {

                MySqlCommand actPlanilla = new MySqlCommand("select idEmpleado, nombre, apellido, documento, domicilio, telefono, mail, usuarios.usuario from empleados, usuarios where usuarios.idUsuario = empleados.usuario;", conexionDB);

                actPlanilla.CommandType = CommandType.Text;

                conexionDB.Open();

                resultado = actPlanilla.ExecuteReader();

                datable.Load(resultado);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

            return datable;
        }
        public void SaleVehiculo(float total, string idSelected, int usuario)
        {
            //se actualiza la tabla con los datos del vehiculo que sale del estancionamiento, junto con los datos del usuario que lo gestionó
            string update = "UPDATE `parkingdb`.`ingresoysalida` SET `horasalida` = '" + DateTime.Now + "', `estado` = '" + 0 + "', `egresoUsuario` = '" + usuario + "', `total` = '" + total + "' WHERE(`id` = '" + idSelected + "');";


            MySqlConnection conexionDB = Conexiones.conexion();
            conexionDB.Open();

            try
            {

                MySqlCommand COMANDO = new MySqlCommand(update, conexionDB);
                COMANDO.ExecuteNonQuery();

                //actualiza planilla luego de cargar salida
                actualizarPlanillaPrincipal();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar! " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
                actualizarPlanillaPrincipal();
            }
        }

        //sale vehiculo para clientes con plazos vencidos
        public void saleVehiculo(string patente, int usuario)
        {
            //se actualiza la tabla con los datos del vehiculo que sale del estancionamiento, junto con los datos del usuario que lo gestionó
            string update = "UPDATE `parkingdb`.`ingresoysalida` SET `horasalida` = '" + DateTime.Now + "', `estado` = '" + 0 + "', `egresoUsuario` = '" + usuario + "', `total` = '" + 0 + "' WHERE(`patente` = '" + patente + "');";


            MySqlConnection conexionDB = Conexiones.conexion();
            conexionDB.Open();

            try
            {

                MySqlCommand COMANDO = new MySqlCommand(update, conexionDB);
                COMANDO.ExecuteNonQuery();

                //actualiza planilla luego de cargar salida
                actualizarPlanillaPrincipal();

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

        public DataTable historial()
        {
            MySqlConnection conexionDB = Conexiones.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;

            string consulta = "SELECT id, patente,horaIngreso, horaSalida, nombre, total, estado, vehiculo.vehiculo, usuarios.usuario from ingresoysalida, " +
                "clientes, usuarios, patentes, vehiculo where clientes.idCliente = patentes.cliente and ingresoysalida.patente = patentes.idPatente and vehiculo.idVehiculo = " +
                "ingresoysalida.vehiculo;";

            try
            {

                MySqlCommand actPlanilla = new MySqlCommand(consulta, conexionDB);

                actPlanilla.CommandType = CommandType.Text;

                conexionDB.Open();

                resultado = actPlanilla.ExecuteReader();

                datable.Load(resultado);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

            return datable;
        }

        public DataTable CargarClientes()
        {
            MySqlConnection conexionDB = Conexiones.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;

            string consulta = "SELECT idCliente, nombre, apellido, vehiculo.vehiculo, idpatente, telefono, patentes.idPatente, planes.plan from clientes, patentes, planes, tarifas, vehiculo where idvehiculo = tarifas.tipoVehiculo and tarifas.plan = idPlan and patentes.tarifa = tarifas.idtarifas and patentes.cliente = clientes.idcliente and clientes.nombre != 'Sin registrar';";

            try
            {

                MySqlCommand actPlanilla = new MySqlCommand(consulta, conexionDB);

                actPlanilla.CommandType = CommandType.Text;

                conexionDB.Open();

                resultado = actPlanilla.ExecuteReader();

                datable.Load(resultado);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

            return datable;
        }


        public void GuardarCliente(string nombre, string apellido, string documento, string telefono, string patenteR, string nota, int usuario)
        {
            MySqlConnection conexionDB = Conexiones.conexion();
            string sqlRegistro = "";
            conexionDB.Open();

            try
            {
                sqlRegistro = "insert into clientes (nombre, apellido, documento, telefono, fechaRegistro, nota, usuarioR) values ('" + nombre + "', '" + apellido + "', " + documento + " , " + telefono + ", '" + DateTime.Now + "','" + nota + "', '" + usuario + "');";

                MySqlCommand COMANDO = new MySqlCommand(sqlRegistro, conexionDB);
                COMANDO.ExecuteNonQuery();


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

        public DataTable cargarTarifas()
        {
            MySqlConnection conexionDB = Conexiones.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;

            try
            {

                MySqlCommand actTarifas = new MySqlCommand("select vehiculo.vehiculo, planes.plan, tarifa from tarifas, vehiculo, planes where tipoVehiculo = vehiculo.idvehiculo and tarifas.plan = planes.idplan;", conexionDB);

                actTarifas.CommandType = CommandType.Text;

                conexionDB.Open();

                resultado = actTarifas.ExecuteReader();

                datable.Load(resultado);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }


            return datable;

        }

        public DataTable BuscarClientes(string id, string nombre, string apellido, string documento, string telefono, string patente)
        {
            MySqlConnection conexionDB = Conexiones.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;

            conexionDB.Open();

            string consultaBusqueda = "";


            if (!String.IsNullOrEmpty(id))
            {
                consultaBusqueda = "SELECT nombre, idpatente, planes.plan from clientes, patentes, planes, tarifas where idCliente= '" + id + "' and tarifas.plan = idPlan and patentes.tarifa = tarifas.idtarifas and patentes.cliente = clientes.idcliente;";
            }
            else if (!string.IsNullOrEmpty(nombre))
            {
                consultaBusqueda = "SELECT nombre, idpatente, planes.plan from clientes, patentes, planes, tarifas where nombre= '" + nombre + "' and tarifas.plan = idPlan and patentes.tarifa = tarifas.idtarifas and patentes.cliente = clientes.idcliente;";
            }
            else if (!string.IsNullOrEmpty(apellido))
            {
                consultaBusqueda = "SELECT nombre, idpatente, planes.plan from clientes, patentes, planes, tarifas where apellido= '" + apellido + "' and tarifas.plan = idPlan and patentes.tarifa = tarifas.idtarifas and patentes.cliente = clientes.idcliente;";
            }
            else if (!string.IsNullOrEmpty(documento))
            {
                consultaBusqueda = "SELECT nombre, idpatente, planes.plan from clientes, patentes, planes, tarifas where documento= " + documento + " and tarifas.plan = idPlan and patentes.tarifa = tarifas.idtarifas and patentes.cliente = clientes.idcliente;";
            }
            else if (!string.IsNullOrEmpty(patente))
            {
                consultaBusqueda = "SELECT nombre, idpatente, planes.plan from clientes, patentes, planes, tarifas where patentes.idpatente = '" + patente + "' and tarifas.plan = idPlan and patentes.tarifa = tarifas.idtarifas and patentes.cliente = clientes.idcliente;";
            }



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

            return datable;
        }

        public void GuardarEmpleado(string nombre, string apellido, string documento, string domicilio, string telefono, string mail, string usuario, string contraseña, int tipoUsuario)
        {

            string idUsuario = "";

            string sqlRegistro = "insert into usuarios (usuario, pass, tipoUsuario) values ('" + usuario + "', '" + contraseña + "', '" + tipoUsuario + "');";


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

            string consultaId = "select idusuario from usuarios where usuario = '" + usuario + "' and pass = '" + contraseña + "';";

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

        public DataTable BuscarEmpleado()
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

            return datable;
        }

        public void borrarEmpleado(int idEmpleado)
        {

            string deleteFrom = "DELETE FROM `parkingdb`.`empleados` WHERE (`idEmpleado` = '" + idEmpleado + "');" +
                "";


            MySqlConnection conexionDB = Conexiones.conexion();

            conexionDB.Open();

            try
            {
                MySqlCommand COMANDO = new MySqlCommand(deleteFrom, conexionDB);
                COMANDO.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar! " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        public void vencimientos()
        {

            principal principal = new principal();

            MySqlConnection conexionDB = Conexiones.conexion();
            string fechasVencimiento = "SELECT * FROM patentes;";

            conexionDB.Open();

            try
            {


                MySqlCommand buscarId = new MySqlCommand(fechasVencimiento, conexionDB);

                MySqlDataReader reader = buscarId.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader.GetString(2)) > 1)
                        {
                            DateTime fechaVencimiento = DateTime.Parse(Convert.ToString(reader.GetString(4)));

                            if (fechaVencimiento < DateTime.Now)
                            {
                                saleVehiculo(Convert.ToString(reader.GetString(0)), 1);
                            }
                        }

                    }
                }

                reader.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool esCliente(string patente)
        {
            MySqlConnection conexionDB = Conexiones.conexion();
            DataTable datable = new DataTable();


            conexionDB.Open();

            string consultaBusqueda = "SELECT cliente FROM patentes where idPatente = '" + patente + "' and cliente > 1;";


            MySqlCommand buscarCliente = new MySqlCommand(consultaBusqueda, conexionDB);

            MySqlDataReader reader = buscarCliente.ExecuteReader();

            if (reader.Read() && Convert.ToInt32(reader.GetString(0)) > 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public void registroFacturas(int idCliente, double importe)
        {

            DataTable datable = new DataTable();

            string factura = "insert into factura(fecha, idCliente, importeTotal) values('" + DateTime.Now + "', '" + idCliente + "', '" + importe + "');";


            MySqlConnection conexionDB = Conexiones.conexion();
            conexionDB.Open();

            try
            {
                MySqlCommand COMANDO = new MySqlCommand(factura, conexionDB);
                COMANDO.ExecuteNonQuery();



            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al guardar! " + ex.Message);

            }
            finally
            {
                MessageBox.Show("Registro guardado!");
                conexionDB.Close();
            }

        }

        public DataTable actualizarFacturacion(string fechaDesde, string fechaHasta)
        {

            MySqlConnection conexionDB = Conexiones.conexion();
            DataTable datable = new DataTable();
            MySqlDataReader resultado;

            try
            {

                MySqlCommand actFacturacion = new MySqlCommand("select * from factura where fecha between '" + fechaDesde + "' and '" + fechaHasta + "';", conexionDB);

                actFacturacion.CommandType = CommandType.Text;

                conexionDB.Open();

                resultado = actFacturacion.ExecuteReader();

                datable.Load(resultado);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

            return datable;
        }

    }
}