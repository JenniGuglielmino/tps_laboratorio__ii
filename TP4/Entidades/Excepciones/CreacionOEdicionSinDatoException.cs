using System;

namespace Entidades
{
    public class CreacionOEdicionSinDatoException : Exception
    {
        /// <summary>
        /// Constructor de la excepcion utiliza el constructor de su clase padre, pasandole un mensaje requerido
        /// </summary>
        /// <param name="message">mensaje a mostrar, opcional </param>
        public CreacionOEdicionSinDatoException(string message = "Debe completar todos los campos") : base(message)
        {

        }
    }
}