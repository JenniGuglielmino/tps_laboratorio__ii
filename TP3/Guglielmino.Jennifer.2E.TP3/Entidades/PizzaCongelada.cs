using Entidades.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PizzaCongelada : Producto, IPremiable
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
        public override string CantidadDeProductoPorUnidad { get { return $""; } }

        public bool Intercambiar()
        {
            throw new NotImplementedException();
        }

        public PizzaCongelada(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto, int cantidadDePorciones)
            : base(nombre, descripcion, cantidad, precio, peso, tipoProducto)
        {
            this.CostoEnPuntos = 300;
            this.CantidadDePorciones = cantidadDePorciones;
        }
    }
}
