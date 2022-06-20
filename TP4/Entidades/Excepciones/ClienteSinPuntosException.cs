using System;

namespace Entidades
{
    /// <summary>
    /// Exepcion que se lanzara si el cliente no tiene puntos suficientes 
    /// </summary>
    public class ClienteSinPuntosException : Exception
    {
        public string nombreCliente;

        /// <summary>
        /// Constructor de la excepcion, se requiere el nombre de cliente, el mensaje es opcional
        /// </summary>
        /// <param name="nombreCliente"></param>
        /// <param name="message"></param>
        public ClienteSinPuntosException(string nombreCliente, string message = null) : base(message)
        {
            this.nombreCliente = nombreCliente;
        }
        /// <summary>
        /// Devuelve el mensaje de error con nombre del cliente.
        /// </summary>
        public string MensajeError
        {
            get
            {
                return $"{this.nombreCliente} no tiene suficientes puntos para este canje";
            }
        }
    }
}
