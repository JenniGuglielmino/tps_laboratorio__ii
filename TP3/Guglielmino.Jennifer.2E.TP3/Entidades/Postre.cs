using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Enumerados;

namespace Entidades
{
    public class Postre : Producto, IPremiable
    {
        private int unidadesPorCaja;
        public ETipoProducto tipo { get; set; }

        public int UnidadesPorCaja
        {
            get
            {
                return unidadesPorCaja;
            }
            set
            {
                if (value > 0)
                {
                    unidadesPorCaja = value;
                }
            }
        }

        /// <summary>
        /// Sobreescribe para esta clase, devolviendo las unidades por caja como dato en el string en lugar de porciones o peso
        /// </summary>
        public override string CantidadDeProductoPorUnidad { get { return $"Unidades: {UnidadesPorCaja}"; } }

        public int CostoEnPuntos { get; set; }

        public bool Intercambiar()
        {
            throw new NotImplementedException();
        }

        public Postre(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto, int unidadesPorCaja)
            :base(nombre, descripcion, cantidad, precio, peso, tipoProducto)
        {

            this.unidadesPorCaja = unidadesPorCaja;
        }
    }
}
