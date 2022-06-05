using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [Serializable]
    internal class ExtensionInvalidaException : Exception
    {
        public ExtensionInvalidaException()
        {
        }

        public ExtensionInvalidaException(string message) : base(message)
        {
        }

        public ExtensionInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExtensionInvalidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}