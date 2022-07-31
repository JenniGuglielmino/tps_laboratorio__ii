using System;
using Entidades.Enumerados;

namespace Entidades
{
    [Serializable]
    public class Postre : Producto, ICanjeable
    {
        private int unidadesPorCaja;

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

        /// <summary>
        /// Constructor sin parametros para serializar
        /// </summary>
        public Postre()
        {

        }
        /// <summary>
        /// Constructor con parametro Id para leer desde la base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="peso"></param>
        /// <param name="tipoProductoId"></param>
        /// <param name="unidadesPorCaja"></param>
        /// <param name="eliminado"></param>
        public Postre(int id, string nombre, string descripcion, int cantidad, double precio, float peso, int tipoProductoId, int unidadesPorCaja, bool eliminado)
            : base(id, nombre, descripcion, cantidad, precio, peso, tipoProductoId, eliminado)
        {

            this.unidadesPorCaja = unidadesPorCaja;
            this.costoEnPuntos = 400;
        }
        /// <summary>
        /// Constructor para guardar en la base
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="peso"></param>
        /// <param name="tipoProducto"></param>
        /// <param name="unidadesPorCaja"></param>
        public Postre(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto, int unidadesPorCaja)
            : base(nombre, descripcion, cantidad, precio, peso, tipoProducto)
        {

            this.unidadesPorCaja = unidadesPorCaja;
            this.costoEnPuntos = 400;
        }

        /// <summary>
        /// Metodo de implementacion de interfaz para verificar si los puntos son suficientes
        /// (Quiza es una implementacion innecesaria pero la agregue para mostrar uso de interfaces)
        /// </summary>
        /// <param name="puntosCliente">Puntos totales del cliente</param>
        /// <returns>True si se puede canjear, false si no se puede</returns>
        public bool SePuedeCanjear(int puntosCliente)
        {
            return puntosCliente >= CostoEnPuntos;
        }
    }
}
