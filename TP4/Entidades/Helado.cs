using Entidades.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        public override string CantidadDeProductoPorUnidad { get { return $"Bochas: {bochas}"; } }
        public Helado()
        {

        }
        public Helado(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto, int bochas)
            : base(nombre, descripcion, cantidad, precio, peso, tipoProducto)
        {
            this.Bochas = bochas;
        }
    }
}
