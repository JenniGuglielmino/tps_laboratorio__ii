using Entidades.Enumerados;
using System;

namespace Entidades
{
    [Serializable]

    public class Helado : Producto
    {
        private int bochas;
        public int Bochas 
        {
            get { return bochas; }
            set { bochas = value; }
        }
        /// <summary>
        /// Sobreescribe para esta propiedad, devolviendo la cantidad de bochas de helado
        /// </summary>
        public override string CantidadDeProductoPorUnidad { get { return $"Bochas: {bochas}"; } }

        /// <summary>
        /// Constructor sin parametros para serializar
        /// </summary>
        public Helado()
        {

        }
        /// <summary>
        /// Constructor con parametros para leer desde la base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="peso"></param>
        /// <param name="tipoProductoId"></param>
        /// <param name="bochas"></param>
        /// <param name="eliminado"></param>
        public Helado(int id, string nombre, string descripcion, int cantidad, double precio, float peso, int tipoProductoId, int bochas, bool eliminado)
            : base(id, nombre, descripcion, cantidad, precio, peso, tipoProductoId, eliminado)
        {
            this.Bochas = bochas;
        }
        /// <summary>
        /// Constructor con parametros para guardar en la base
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="peso"></param>
        /// <param name="tipoProducto"></param>
        /// <param name="bochas"></param>
        public Helado(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto, int bochas)
               : base(nombre, descripcion, cantidad, precio, peso, tipoProducto)
        {
            this.Bochas = bochas;
        }
    }
}
