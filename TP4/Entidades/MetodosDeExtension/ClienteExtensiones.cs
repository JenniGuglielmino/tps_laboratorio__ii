namespace Entidades
{
    public static class ClienteExtensiones
    {
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
