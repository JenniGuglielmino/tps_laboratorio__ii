using Entidades.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Helado : Producto
    {
        private int bochas;
        public int Bochas { get; set; }
        public override string CantidadDeProductoPorUnidad { get { return $"Peso: {Peso} gramos"; } }
        public Helado(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto, int bochas)
            : base(nombre, descripcion, cantidad, precio, peso, tipoProducto)
        {
            this.Bochas = bochas;
        }
    }
}
