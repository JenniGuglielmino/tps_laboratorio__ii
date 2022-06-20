using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Entidades
{
    public static class AccesoSql
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;

        static AccesoSql()
        {
            connectionString = @"Data Source=.;Initial Catalog=HELADERIA_FRIDO;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }
        /// <summary>
        /// Guarda una venta en la db
        /// </summary>
        /// <param name="venta">Venta a guardar</param>
        /// <returns>true si pudo guardarse, false si no se pudo</returns>
        public static bool GuardarVenta(Venta venta)
        {
            try
            {
                command.CommandText = $"INSERT INTO Ventas VALUES(@PRODUCTOID, @CLIENTEID , @CANTIDADPRODUCTO)";
                command.Parameters.AddWithValue("@PRODUCTOID", venta.Producto.Id);
                command.Parameters.AddWithValue("@CLIENTEID", venta.Cliente.Id);
                command.Parameters.AddWithValue("@CANTIDADPRODUCTO", venta.CantidadProductos);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (SqlException)
            {
                throw new ErrorSqlException("Ocurrio un eror al intentar guardar en la base");
            }
            catch (Exception ex)
            {
                throw new Exception("No pudo guardarse", ex);
            }

        }
        /// <summary>
        /// Modifica una venta especifica en la db
        /// </summary>
        /// <param name="venta">Venta a modificar</param>
        /// <returns>true si fue exitoso, false si no lo fue</returns>
        public static bool ModificarVenta(Venta venta)
        {
            try
            {
                command.CommandText = $"UPDATE Ventas SET Id_Producto = @PRODUCTOID, Id_Cliente = @CLIENTEID, CantidadProducto = @CANTIDADPRODUCTO) WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", venta.Id);
                command.Parameters.AddWithValue("@PRODUCTOID", venta.Producto.Id);
                command.Parameters.AddWithValue("@CLIENTEID", venta.Cliente.Id);
                command.Parameters.AddWithValue("@CANTIDADPRODUCTO", venta.CantidadProductos);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (SqlException)
            {
                throw new ErrorSqlException("Ocurrio un eror al intentar modificar en la base");
            }
            catch (Exception ex)
            {
                throw new Exception("No pudo modificarse", ex);
            }

        }
        /// <summary>
        /// Enlista las ventas que esten en la base
        /// </summary>
        /// <returns>Retorna la lista de las ventas</returns>
        public static List<Venta> LeerVentas()
        {
            List<Venta> ventas = new List<Venta>();
            try
            {
                connection.Open();
                command.CommandText = "Select * FROM Ventas";
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ventas.Add(new Venta(Convert.ToInt32(dataReader["Id"]), Convert.ToInt32(dataReader["ProductoId"]), Convert.ToInt32(dataReader["ClienteId"]), Convert.ToInt32(dataReader["CantidadDeProductos"])));
                    }
                }   
                return ventas;
            }
            catch (SqlException)
            {
                throw new ErrorSqlException("Ocurrio un eror al intentar modificar en la base");
            }
            catch (Exception ex)
            {

                throw new Exception("No pudo obtenerse la lista", ex);
            }
        }

    }
}
