using System;
using Entidades.Enumerados;

namespace Entidades
{
    [Serializable]
    public class Postre : Producto, ICanjeable
    {
        private int unidadesPorCaja;
        public ETipoProducto tipo { get; set; }

        private int costoEnPuntos;

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
        /// Sobreescribe para esta propiedad, devolviendo las unidades por caja como dato en el string en lugar de porciones o peso
        /// </summary>
        public override string CantidadDeProductoPorUnidad { get { return $"Unidades: {UnidadesPorCaja}"; } }

        public int CostoEnPuntos
        {
            get { return costoEnPuntos; }
            set { costoEnPuntos = value; }
        }

        public Postre()
        {

        }

        public Postre(int id, string nombre, string descripcion, int cantidad, double precio, float peso, int tipoProductoId, int unidadesPorCaja)
            :base(id, nombre, descripcion, cantidad, precio, peso, tipoProductoId)
        {

            this.unidadesPorCaja = unidadesPorCaja;
            this.costoEnPuntos = 400;
        }
        public Postre(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto, int unidadesPorCaja)
            : base(nombre, descripcion, cantidad, precio, peso, tipoProducto)
        {

            this.unidadesPorCaja = unidadesPorCaja;
            this.costoEnPuntos = 400;
        }
    }
}
