using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Enumerados;

namespace Entidades
{
    public abstract class Producto : IStockeable, IVendibles, IGuardable<Producto>
    {
        private int id;
        private string nombre;
        private string descripcion;
        private int cantidad;
        private double precio;
        private float peso;
        private static List<Producto> productos;
        ETipoProducto tipoProducto;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public float Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public static List<Producto> Productos
        {
            get { return productos; }
            set { productos = value; }
        }
        public abstract string CantidadDeProductoPorUnidad { get; }

        public ETipoProducto TipoProducto
        {
            get
            {
                return this.tipoProducto;
            }
            set
            {
                this.tipoProducto = value;
            }
        }

        static Producto()
        {
            Productos = new List<Producto>();
        }

        public Producto(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Peso = peso;
            this.TipoProducto = tipoProducto;
        }

        public static bool operator ==(Producto producto1, Producto producto2)
        {
            return (producto1.nombre == producto2.nombre && producto1.tipoProducto == producto2.tipoProducto);
        }
        public static bool operator !=(Producto producto1, Producto producto2)
        {
            return !(producto1 == producto2);
        }

        public static bool operator +(List<Producto> listaProductos, Producto producto)
        {
            foreach (Producto producto1 in listaProductos)
            {
                if (producto1 == producto)
                {
                    return false;
                }
            }
            listaProductos.Add(producto);
            return true;
        }

        public void Escribir(Producto dato, string path)
        {
            throw new NotImplementedException();
        }

        public bool GuardarComo(ETipoArchivo tipoDeArchivo)
        {
            //evaluar tipo de archivo y usar los metodos para guardar de alguna otra clase
            throw new NotImplementedException();
        }

        public Producto Leer(string path)
        {
            throw new NotImplementedException();
        }

        public bool Vender()
        {
            throw new NotImplementedException();
        }
        public static bool operator -(List<Producto> listaProductos, Producto Producto)
        {
            bool removeOk = false;
            foreach (Producto prd in listaProductos)
            {
                if (prd == Producto)
                {
                    listaProductos.Remove(prd);
                    return true;
                }
            }
            return removeOk;
        }
    }
}
