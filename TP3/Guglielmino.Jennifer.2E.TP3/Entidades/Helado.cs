using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Helado : Producto
    {
        public int Bochas { get; set; }
        public override string CantidadDeProductoPorUnidad { get { return $"Peso: {Peso} gramos"; } }
    }
}
