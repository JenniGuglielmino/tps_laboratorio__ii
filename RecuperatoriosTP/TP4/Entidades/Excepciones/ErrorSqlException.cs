using System;
using System.Runtime.Serialization;

namespace Entidades
{
    /// <summary>
    /// Exepcion que se lanza si ocurrio un error con sql
    /// </summary>
    internal class ErrorSqlException : Exception
    {
        public ErrorSqlException()
        {
        }

        public ErrorSqlException(string message) : base(message)
        {
        }

        public ErrorSqlException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}