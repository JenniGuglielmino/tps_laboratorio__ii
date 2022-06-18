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

        public override string CantidadDeProductoPorUnidad { get { return $"Porciones: {cantidadDePorciones}"; } }

        public PizzaCongelada()
        {
        }

        public PizzaCongelada(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto, int cantidadDePorciones)
            : base(nombre, descripcion, cantidad, precio, peso, tipoProducto)
        {
            this.CostoEnPuntos = 300;
            this.CantidadDePorciones = cantidadDePorciones;
        }
    }
}
