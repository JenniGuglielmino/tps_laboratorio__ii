using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class PizzaCongelada : Producto, IPremiable
    {
        private int cantidadDePorciones;
        public int CostoEnPuntos { get; set; }
        public int CantidadDePorciones { get { return cantidadDePorciones; } }
        public override string CantidadDeProductoPorUnidad { get { return $""; } }

        public bool Intercambiar()
        {
            throw new NotImplementedException();
        }
    }
}
