using Entidades.Enumerados;
using System;

namespace Entidades
{
    [Serializable]
    public class PizzaCongelada : Producto, ICanjeable
    {
        private int cantidadDePorciones;
        private int costoEnPuntos;

        public int CostoEnPuntos
        {
            get { return costoEnPuntos; }
            set { costoEnPuntos = value; }
        }

        public int CantidadDePorciones
        {
            get { return cantidadDePorciones; }
            set { cantidadDePorciones = value; }
        }
        /// <summary>
        /// Sobreescribe para esta propiedad, devolviendo porciones del prodcuto como dato en el string
        /// </summary>
        public override string CantidadDeProductoPorUnidad { get { return $"Porciones: {cantidadDePorciones}"; } }
        /// <summary>
        /// Constructor sin parametros para serializar
        /// </summary>
        public PizzaCongelada()
        {
        }
        /// <summary>
        /// Constructor con parametro Id para leer desde la base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="peso"></param>
        /// <param name="tipoProductoId"></param>
        /// <param name="cantidadDePorciones"></param>
        /// <param name="eliminado"></param>
        public PizzaCongelada(int id, string nombre, string descripcion, int cantidad, double precio, float peso, int tipoProductoId, int cantidadDePorciones, bool eliminado)
            : base(id, nombre, descripcion, cantidad, precio, peso, tipoProductoId, eliminado)
        {
            this.CostoEnPuntos = 300;
            this.CantidadDePorciones = cantidadDePorciones;
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
        /// <param name="cantidadDePorciones"></param>
        public PizzaCongelada(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto, int cantidadDePorciones)
            : base(nombre, descripcion, cantidad, precio, peso, tipoProducto)
        {
            this.CostoEnPuntos = 300;
            this.CantidadDePorciones = cantidadDePorciones;
        }
        /// <summary>
        /// Metodo de implementacion de interfaz para verificar si los puntos son suficientes
        /// (Quiza es una implementacion innecesaria pero la agregue para mostrar uso de interfaces)
        /// </summary>
        /// <param name="puntosCliente">Puntos totales del cliente</param>
        /// <returns>True si se puede canjear, false si no se puede</returns>
        public bool SePuedeCanjear(int puntosCliente)
        {
            return puntosCliente >= CostoEnPuntos;
        }
    }
}
