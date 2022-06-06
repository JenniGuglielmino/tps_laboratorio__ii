using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta : IImprimible
    {
        private Cliente cliente;
        private Empleado vendedor;
        private static List<Venta> ventas;
        private List<Producto> productos;

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        public Empleado Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }
        public static List<Venta> Ventas
        {
            get { return ventas; }
            set { ventas = value; }
        }

        public List<Producto> Productos
        {
            get { return productos; }
            set { productos = value; }
        }

        static Venta()
        {
            Ventas = new List<Venta>();
        }
        public Venta()
        {
        }


        public static Venta operator+(Venta venta, Producto producto)
        {
            foreach(Producto p in venta.Productos)
            {
                if (p != producto)
                {
                    venta.Productos.Add(producto);
                }
            }
            return venta;
        }

        public static Venta operator -(Venta venta, Producto producto)
        {
            foreach (Producto p in venta.Productos)
            {
                if (p == producto)
                {
                    venta.Productos.Remove(producto);
                    break;
                }
            }
            return venta;
        }

        protected double Facturar()
        {
            double costoTotal = 0;
            foreach(Producto p in this.Productos)
            {
                costoTotal += p.Precio;
            }
            return costoTotal;
        }

        protected int CargarPuntos()
        {
            double dineroGastado = Facturar();
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
            StringBuilder strB = new StringBuilder();
            strB.AppendLine($"Factura de: {this.Cliente.Nombre}");
            strB.AppendLine($"Detalle:");
            foreach (Producto item in this.Productos)
            {
                strB.AppendLine($"{item}");
            }
            strB.AppendLine($"Importe a facturar: {this.Facturar()}");
            strB.AppendLine($"Puntos acumulados: {this.Cliente.Puntos + CargarPuntos()}");
            strB.AppendLine($"Vendedor: {this.Vendedor.Usuario}");
            return this.ToString();
        }
    }
}
