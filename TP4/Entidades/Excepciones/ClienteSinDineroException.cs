using System;

namespace Entidades
{
    /// <summary>
    /// Exepcion que se lanzara si el cliente no tiene dinero
    /// </summary>
    public class ClienteSinDineroException : Exception
    {
        public string nombreCliente;
        public double saldoRestante;

        /// <summary>
        /// Constructor de la excepcion, se requiere el nombre de cliente y su saldo restante, el mensaje es opcional
        /// </summary>
        /// <param name="nombreCliente"></param>
        /// <param name="saldoRestante"></param>
        /// <param name="message"></param>
        public ClienteSinDineroException(string nombreCliente, double saldoRestante, string message = null) : base(message)
        {
            this.nombreCliente = nombreCliente;
            this.saldoRestante = saldoRestante;
        }
        /// <summary>
        /// Devuelve el mensaje de error con nombre y saldo del cliente.
        /// </summary>
        public string MensajeError
        {
            get
            {
                return $"{this.nombreCliente} no tiene suficiente saldo para esta venta, saldo: {saldoRestante}";
            }
        }
    }
}
