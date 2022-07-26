using Entidades.Enumerados;
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
                connection.Open();
                command.CommandText = $"INSERT INTO Ventas VALUES(@CLIENTEID, @PRODUCTOID, @CANTIDADPRODUCTO)";
                command.Parameters.AddWithValue("@CLIENTEID", venta.Cliente.Id);
                command.Parameters.AddWithValue("@PRODUCTOID", venta.Producto.Id);
                command.Parameters.AddWithValue("@CANTIDADPRODUCTO", venta.CantidadProductos);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (SqlException)
            {
                throw new ErrorSqlException("Ocurrio un eror al intentar guardar en la base");
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException("No pudo castearse", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidCastException("Operacion invalida", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No pudo guardarse", ex);
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
                        ventas.Add(new Venta(Convert.ToInt32(dataReader["Id"]), Convert.ToInt32(dataReader["Id_Cliente"]), Convert.ToInt32(dataReader["Id_Producto"]), Convert.ToInt32(dataReader["CantidadProducto"])));
                    }
                }
                connection.Close();
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
        /// <summary>
        /// Enlista los clientes que esten en la base
        /// </summary>
        /// <returns>Retorna la lista de las Clientes</returns>
        public static List<Cliente> LeerClientes()
        {
            List<Cliente> ventas = new List<Cliente>();
            try
            {
                connection.Open();
                command.CommandText = "Select * FROM Clientes";
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ventas.Add(new Cliente(Convert.ToInt32(dataReader["Id"]), dataReader["Nombre"].ToString(), dataReader["Apellido"].ToString(), Convert.ToDouble(dataReader["Saldo"]), Convert.ToInt32(dataReader["Puntos"])));
                    }
                }
                connection.Close();
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

        /// <summary>
        /// Guarda una cliente en la db
        /// </summary>
        /// <param name="cliente">Cliente a guardar</param>
        /// <returns>true si pudo guardarse, false si no se pudo</returns>
        public static bool GuardarCliente(Cliente cliente)
        {
            try
            {
                connection.Open();
                command.CommandText = $"INSERT INTO Clientes VALUES(@NOMBRE, @APELLIDO , @SALDO, @PUNTOS)";
                command.Parameters.AddWithValue("@NOMBRE", cliente.Nombre);
                command.Parameters.AddWithValue("@APELLIDO", cliente.Apellido);
                command.Parameters.AddWithValue("@SALDO", cliente.Saldo);
                command.Parameters.AddWithValue("@PUNTOS", cliente.Puntos);
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
        /// Modifica un cliente especifica en la db
        /// </summary>
        /// <param name="cliente">Cliente a modificar</param>
        /// <returns>true si fue exitoso, false si no lo fue</returns>
        public static bool ModificarCliente(Cliente cliente)
        {
            try
            {
                connection.Open();
                command.CommandText = $"UPDATE Clientes SET Nombre = @NOMBRE, Apellido = @APELLIDO, Saldo = @SALDO, Puntos = @PUNTOS WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", cliente.Id);
                command.Parameters.AddWithValue("@NOMBRE", cliente.Nombre);
                command.Parameters.AddWithValue("@APELLIDO", cliente.Apellido);
                command.Parameters.AddWithValue("@SALDO", cliente.Saldo);
                command.Parameters.AddWithValue("@PUNTOS", cliente.Puntos);
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
        public static List<Producto> LeerProductos()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                connection.Open();
                command.CommandText = "Select * FROM Productos";
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ETipoProducto tipoProducto;
                        if (Enum.TryParse(dataReader["Id_TipoProducto"].ToString(), out tipoProducto))
                        {
                            switch (tipoProducto)
                            {
                                case (ETipoProducto.Postre):
                                    productos.Add(new Postre(Convert.ToInt32(dataReader["Id"]), dataReader["Nombre"].ToString(), dataReader["Descripcion"].ToString(), Convert.ToInt32(dataReader["Cantidad"]), Convert.ToDouble(dataReader["Precio"]), float.Parse(dataReader["Peso"].ToString()), Convert.ToInt32(dataReader["Id_TipoProducto"]), Convert.ToInt32(dataReader["CantidadDeProductoPorUnidad"])));
                                    break;
                                case (ETipoProducto.Helado):
                                    productos.Add(new Helado(Convert.ToInt32(dataReader["Id"]), dataReader["Nombre"].ToString(), dataReader["Descripcion"].ToString(), Convert.ToInt32(dataReader["Cantidad"]), Convert.ToDouble(dataReader["Precio"]), float.Parse(dataReader["Peso"].ToString()), Convert.ToInt32(dataReader["Id_TipoProducto"]), Convert.ToInt32(dataReader["CantidadDeProductoPorUnidad"])));
                                    break;
                                case (ETipoProducto.Pizza_congelada):
                                    productos.Add(new PizzaCongelada(Convert.ToInt32(dataReader["Id"]), dataReader["Nombre"].ToString(), dataReader["Descripcion"].ToString(), Convert.ToInt32(dataReader["Cantidad"]), Convert.ToDouble(dataReader["Precio"]), float.Parse(dataReader["Peso"].ToString()), Convert.ToInt32(dataReader["Id_TipoProducto"]), Convert.ToInt32(dataReader["CantidadDeProductoPorUnidad"])));
                                    break;
                            }
                        }
                    }
                }
                connection.Close();
                return productos;
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

        /// <summary>
        /// Modifica un producto especifico en la db
        /// </summary>
        /// <param name="producto">producto a modificar</param>
        /// <returns>true si fue exitoso, false si no lo fue</returns>
        public static bool ModificarProducto(Producto producto)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE Productos SET Nombre = @NOMBRE, Descripcion = @DESCRIPCION, Cantidad = @CANTIDAD, " +
                                      $"Precio = @PRECIO, Peso = @PESO, Id_TipoProducto = @TIPOPRODUCTOID, " +
                                      $"CantidadDeProductoPorUnidad = @CANTPRODUCTOPORU WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", producto.Id);
                command.Parameters.AddWithValue("@NOMBRE", producto.Nombre);
                command.Parameters.AddWithValue("@DESCRIPCION", producto.Descripcion);
                command.Parameters.AddWithValue("@CANTIDAD", producto.Cantidad);
                command.Parameters.AddWithValue("@PRECIO", producto.Precio);
                command.Parameters.AddWithValue("@PESO", producto.Peso);
                command.Parameters.AddWithValue("@TIPOPRODUCTOID", ((int)producto.TipoProducto));
                if (producto is Helado)
                {
                    command.Parameters.AddWithValue("@CANTPRODUCTOPORU", (producto as Helado).Bochas);
                }
                else if(producto is Postre)
                {
                    command.Parameters.AddWithValue("@CANTPRODUCTOPORU", (producto as Postre).UnidadesPorCaja);
                }
                else if(producto is PizzaCongelada)
                {
                    command.Parameters.AddWithValue("@CANTPRODUCTOPORU", (producto as PizzaCongelada).CantidadDePorciones);
                }
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                throw new ErrorSqlException("Ocurrio un eror al intentar modificar en la base, error: " + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("No pudo modificarse", ex);
            }
        }

        /// <summary>
        /// Guarda un producto en la db
        /// </summary>
        /// <param name="producto">Producto a guardar</param>
        /// <returns>true si pudo guardarse, false si no se pudo</returns>
        public static bool GuardarProducto(Producto producto)
        {
            try
            {
                connection.Open();
                command.Parameters.Clear();
                command.CommandText = $"INSERT INTO Productos VALUES(@NOMBRE, @DESCRIPCION , @CANTIDAD, " +
                                      $"@PRECIO, @PESO, @TIPOPRODUCTOID, @CANTPRODUCTOPORU)";
                command.Parameters.AddWithValue("@NOMBRE", producto.Nombre);
                command.Parameters.AddWithValue("@DESCRIPCION", producto.Descripcion);
                command.Parameters.AddWithValue("@CANTIDAD", producto.Cantidad);
                command.Parameters.AddWithValue("@PRECIO", producto.Precio);
                command.Parameters.AddWithValue("@PESO", producto.Peso);
                command.Parameters.AddWithValue("@TIPOPRODUCTOID", ((int)producto.TipoProducto));
                if (producto is Helado)
                {
                    command.Parameters.AddWithValue("@CANTPRODUCTOPORU", (producto as Helado).Bochas);
                }
                else if (producto is Postre)
                {
                    command.Parameters.AddWithValue("@CANTPRODUCTOPORU", (producto as Postre).UnidadesPorCaja);
                }
                else if (producto is PizzaCongelada)
                {
                    command.Parameters.AddWithValue("@CANTPRODUCTOPORU", (producto as PizzaCongelada).CantidadDePorciones);
                }
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
        /// Guarda un producto en la db
        /// </summary>
        /// <param name="producto">Producto a guardar</param>
        /// <returns>true si pudo guardarse, false si no se pudo</returns>
        public static bool EliminarProducto(Producto producto)
        {
            try
            {
                connection.Open();
                command.Parameters.Clear();
                command.CommandText = $"DELETE from Productos WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", producto.Id);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                throw new ErrorSqlException("Ocurrio un eror al intentar guardar en la base" + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("No pudo guardarse", ex);
            }
        }
    }
}
