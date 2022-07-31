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

        public int Id
        {
            get { return id; }
            set { id = value; }
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
        /// <summary>
        /// Constructor estatico para inicializar la lista estatica
        /// </summary>
        static Venta()
        {
            Ventas = new List<Venta>();
        }
        /// <summary>
        /// Constructor sin parametro
        /// </summary>
        public Venta()
        {

        }

        /// <summary>
        /// Constructor de venta para guardar en la base
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="cliente"></param>
        /// <param name="cantidadProductos"></param>
        public Venta(Cliente cliente, Producto producto, int cantidadProductos)
        {
            PoblarDatosVenta(cliente, producto, cantidadProductos);
        }
        /// <summary>
        /// Constructor con id para leer de sql
        /// </summary>
        /// <param name="id"></param>
        /// <param name="producto"></param>
        /// <param name="cliente"></param>
        /// <param name="cantidadProductos"></param>
        public Venta(int id,  int clienteId, int productoId, int cantidadProductos)
        {
            this.Id = id;
            Producto producto = null;
            Cliente cliente = null;
            foreach (Producto prod in Producto.Productos)
            {
                if (prod.Id == productoId)
                {
                    producto = prod;
                }
            }
            foreach (Cliente cli in Cliente.Clientes)
            {
                if (cli.Id == clienteId)
                {
                    cliente = cli;
                }
            }
            PoblarDatosVenta(cliente, producto, cantidadProductos);
        }
        /// <summary>
        /// Funcion para settear los valores comunes de ventas
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="cliente"></param>
        /// <param name="cantidadProductos"></param>
        public void PoblarDatosVenta(Cliente cliente, Producto producto, int cantidadProductos)
        {
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
            sb.AppendLine($"Puntos acumulados: {venta.CargarPuntos(venta.TotalAPagar)}\r");
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
                    Producto = venta.Producto.Nombre,
                    venta.CantidadProductos,
                    venta.TotalAPagar
                });
            }
            return ventas;
        }

        /// <summary>
        /// Carga inicialmente ventas desde la db 
        /// </summary>
        public static void CargaVentasInicial()
        {
            List<Venta> ventas = AccesoSql.LeerVentas();
            Venta.Ventas.Clear();
            foreach (Venta venta in ventas)
            {
                Venta.Ventas.Add(venta);
            }
        }
    }
}
