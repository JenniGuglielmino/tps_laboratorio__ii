namespace Entidades
{
    public static class ClienteExtensiones
    {
        /// <summary>
        /// Metodo de extension para la clase Cliente
        /// </summary>
        /// <param name="cliente">Cliente this</param>
        /// <param name="producto">Producto por el cual quiera canjear</param>
        /// <returns>true si pudo concretar el canje, false si no se pudo</returns>
        public static bool Canjear(this Cliente cliente, Producto producto)
        {
            bool canjeOk = false;
            if ((producto as ICanjeable).SePuedeCanjear(cliente.Puntos))
            {
                if ((producto as IStockeable).HayStock(1))
                {
                    canjeOk = true;
                    if (canjeOk)
                    {
                        cliente.Puntos -= (producto as ICanjeable).CostoEnPuntos;
                        producto.Cantidad -= 1;
                        AccesoSql.ModificarCliente(cliente);
                        AccesoSql.ModificarProducto(producto);
                    }
                }
                else
                {
                    throw new ProductoSinUnidadesException("No hay suficientes unidades del producto, verifique los datos ingresados");
                }
            }
            else
            {
                throw new ClienteSinPuntosException(cliente.Nombre, "Error en la venta, los puntos no son suficiente");
            }
            return canjeOk;
        }
    }
}
