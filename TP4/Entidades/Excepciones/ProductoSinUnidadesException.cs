using System;

namespace Entidades
{
    /// <summary>
    /// Exepcion que se lanza si el producto no cuenta con las unidades necesarias
    /// </summary>
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