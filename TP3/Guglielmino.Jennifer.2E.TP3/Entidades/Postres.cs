using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Enumerados;

namespace Entidades
{
    class Postres : Producto, IPremiable
    {
        private int unidadesPorCaja;
        public ETipoPoste tipo { get; set; }

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

        public Postres(int unidadesPorCaja)
        {
            this.unidadesPorCaja = unidadesPorCaja;
        }
    }
}
