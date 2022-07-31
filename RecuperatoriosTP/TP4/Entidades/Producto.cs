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
        private static List<Producto> productosFiltrados;
        ETipoProducto tipoProducto;
        private bool eliminado;

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

        [XmlIgnore]
        public static List<Producto> ProductosFiltrados
        {
            get { return productosFiltrados; }
            set { productosFiltrados = value; }
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

        public bool Eliminado
        {
            get { return eliminado; }
            set { eliminado = value; }
        }

        /// <summary>
        /// Constructor estatico para inicializar listas estaticas
        /// </summary>
        static Producto()
        {
            Productos = new List<Producto>();
            ProductosFiltrados = new List<Producto>();
        }
        /// <summary>
        /// Constructor sin parametros para serializar
        /// </summary>
        public Producto()
        {
        }
        /// <summary>
        /// Constructor para leer desde la base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="peso"></param>
        /// <param name="tipoProductoId"></param>
        /// <param name="eliminado"></param>
        public Producto(int id, string nombre, string descripcion, int cantidad, double precio, float peso, int tipoProductoId, bool eliminado)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Peso = peso;
            this.TipoProducto = (ETipoProducto)tipoProductoId;
            this.Eliminado = eliminado;
        }
        /// <summary>
        /// Constructor para guardar en la base
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="peso"></param>
        /// <param name="tipoProducto"></param>
        public Producto(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Peso = peso;
            this.TipoProducto = tipoProducto;
        }
        /// <summary>
        /// Compara dos productos por su id
        /// </summary>
        /// <param name="producto1">Primer producto</param>
        /// <param name="producto2">Segundo producto</param>
        /// <returns>True si son iguales, false si no lo son</returns>
        public static bool operator ==(Producto producto1, Producto producto2)
        {
            return (producto1.Id == producto2.Id);
        }
        /// <summary>
        /// Compara dos productos por su id
        /// </summary>
        /// <param name="producto1">Primer producto</param>
        /// <param name="producto2">Segundo producto</param>
        /// <returns>True si no son iguales, false si lo son</returns>
        public static bool operator !=(Producto producto1, Producto producto2)
        {
            return !(producto1 == producto2);
        }
        /// <summary>
        /// Agrega un producto inexistente a una lista
        /// </summary>
        /// <param name="listaProductos">Lista de productos</param>
        /// <param name="producto">Producto a agregar</param>
        /// <returns>True si pudo agregarlo, false si no pudo</returns>
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

        /// <summary>
        /// Carga inicial de productos desde la base de datos
        /// Carga la lista de productos y la lista filtrada sin los eliminados
        /// </summary>
        public static void CargaProductosInicial()
        {
            List<Producto> productos = AccesoSql.LeerProductos();
            Producto.Productos.Clear();
            Producto.ProductosFiltrados.Clear();
            foreach (Producto producto in productos)
            {
                Producto.Productos.Add(producto);
                if (!producto.Eliminado)
                {
                    Producto.ProductosFiltrados.Add(producto);
                }
            }
        }
        /// <summary>
        /// Metodo de implementacion de interfaz para verificar si hay stock suficiente
        /// (Quiza es una implementacion innecesaria pero la agregue para mostrar uso de interfaces)
        /// </summary>
        /// <param name="unidades">Cantidad de unidades</param>
        /// <returns>True si hay stock, false si no alcanzan las unidades</returns>
        public bool HayStock(int unidades)
        {
            return Cantidad >= unidades;
        }
    }
}
