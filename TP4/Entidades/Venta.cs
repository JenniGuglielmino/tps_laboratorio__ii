using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Venta
    {
        private int id;
        private Cliente cliente;
        private static List<Venta> ventas;
        private Producto producto;
        private int cantidadProductos;
        private static int currentId;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public static int CurrentId
        {
            get { return currentId; }
            set { currentId = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public static List<Venta> Ventas
        {
            get { return ventas; }
            set { ventas = value; }
        }

        public int CantidadProductos
        {
            get { return cantidadProductos; }
            set { cantidadProductos = value; }
        }

        public double TotalAPagar
        {
            get
            {
                return Math.Round(this.Producto.Precio * this.CantidadProductos, 2, MidpointRounding.AwayFromZero);
            }
        }

        static Venta()
        {
            Ventas = new List<Venta>();
        }

        public Venta()
        {

        }

        public Venta(Producto producto, Cliente cliente, int cantidadProductos)
        {
            this.Id = ++currentId;
            CurrentId = this.Id;
            this.Producto = producto;
            this.Cliente = cliente;
            this.CantidadProductos = cantidadProductos;
        }
        /// <summary>
        /// Carga los puntos al cliente segun lo gastado. 1 punto cada 100 pesos
        /// </summary>
        /// <param name="dineroGastado">Dinero gastado en la compra</param>
        /// <returns>Retorna los puntos</returns>
        public int CargarPuntos(double dineroGastado)
        {
            int puntos = 0;
            while (dineroGastado > 0)
            {
                dineroGastado -= 100;
                puntos += 1;
            }
            return puntos;
        }

        public string ObtenerTicket()
        {
            return (string)this;
        }

        public string ObtenerTicket(string firma)
        {
            return $"{this.ObtenerTicket()} \n{firma}";
        }

        public static explicit operator string(Venta venta)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cliente: {venta.Cliente.Nombre}\r");
            sb.AppendLine($"Producto: {venta.Producto.Nombre}\r");
            sb.AppendLine($"Unidades: {venta.CantidadProductos}\r");
            sb.AppendLine($"Precio Unitario: {venta.Producto.Precio}\r");
            sb.AppendLine($"Puntos acumulados: {venta.Cliente.Puntos + venta.CargarPuntos(venta.TotalAPagar)}\r");
            sb.AppendLine($"----------------------------");
            sb.AppendLine($"Total a pagar: {venta.TotalAPagar}\r");
            sb.AppendLine($"Fuiste atendido por: {NucleoAplicacion.EmpleadoLogueado.Usuario}\r");
            sb.AppendLine($"¡Gracias por tu compra!\r");
            return sb.ToString();
        }
        /// <summary>
        /// Agrega una venta a la existente lista de ventas
        /// </summary>
        /// <param name="listaVentas">Lista de ventas</param>
        /// <param name="nuevaVenta">Nueva venta</param>
        /// <returns>Retorna true si pudo agregar, false sino se pudo</returns>
        public static bool operator +(List<Venta> listaVentas, Venta nuevaVenta)
        {
            foreach (Venta venta in listaVentas)
            {
                if (venta == nuevaVenta)
                {
                    return false;
                }
            }
            listaVentas.Add(nuevaVenta);
            return true;
        }

        /// <summary>
        /// Enlista las ventas
        /// </summary>
        /// <returns>Lista de ventas</returns>
        public static List<object> ListarVentas()
        {
            List<object> ventas = new List<object>();
            foreach (object emp in Ventas)
            {
                Venta venta = (Venta)emp;
                ventas.Add(new
                {
                    Id = venta.id,
                    Cliente = venta.Cliente.Nombre,
                    Producto = venta.Producto.Descripcion,
                    venta.CantidadProductos,
                    venta.TotalAPagar
                });
            }
            return ventas;
        }
    }
}
