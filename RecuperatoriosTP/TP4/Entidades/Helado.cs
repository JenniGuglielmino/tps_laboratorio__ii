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
        public Helado()
        {

        }
        public Helado(int id, string nombre, string descripcion, int cantidad, double precio, float peso, int tipoProductoId, int bochas)
            : base(id, nombre, descripcion, cantidad, precio, peso, tipoProductoId)
        {
            this.Bochas = bochas;
        }
        public Helado(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto, int bochas)
    : base(nombre, descripcion, cantidad, precio, peso, tipoProducto)
        {
            this.Bochas = bochas;
        }
    }
}
