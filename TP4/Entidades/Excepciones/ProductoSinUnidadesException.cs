using System;
using System.Runtime.Serialization;

namespace Entidades
{
    public class ProductoSinUnidadesException : Exception
    {
        /// <summary>
        /// Constructor de la excepcion utiliza el constructor de su clase padre, pasandole un mensaje requerido
        /// </summary>
        /// <param name="message">mensaje a mostrar, opcional </param>
        public ProductoSinUnidadesException(string message = "Producto sin unidades restantes") : base(message)
        {

        }
    }
}