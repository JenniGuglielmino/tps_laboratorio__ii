using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Entidades.Enumerados;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Helado))]
    [XmlInclude(typeof(Postre))]
    [XmlInclude(typeof(PizzaCongelada))]
    public abstract class Producto : IStockeable, IVendibles
    {
        private int id;
        private string nombre;
        private string descripcion;
        private int cantidad;
        private double precio;
        private float peso;
        private static List<Producto> productos;
        ETipoProducto tipoProducto;
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

        public Producto()
        {
        }

        public Producto(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto)
        {
            this.Id = ++currentId;
            CurrentId = this.Id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Peso = peso;
            this.TipoProducto = tipoProducto;
        }

        public static bool operator ==(Producto producto1, Producto producto2)
        {
            return (producto1.Id == producto2.Id);
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

        public static bool CargaProductosInicial()
        {
            Serializador<List<Producto>> serializador = new Serializador<List<Producto>>(IGuardable<List<Producto>>.ETipoArchivo.XML);
            string ruta = Environment.CurrentDirectory;
            ruta += @"\ArchivosIniciales";
            string path = ruta + @"\CargaProductosIniciales.xml";
            List<Producto> clientesJson = serializador.Leer(path);
            foreach (Producto item in clientesJson)
            {
                Producto.Productos.Add(item);
            }
            return true;
        }
    }
}
