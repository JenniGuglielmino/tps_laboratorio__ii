using System;

namespace Entidades
{
    public class ArchivoSinPermisosException : Exception
    {
        private const string SinPermisoError = "No tiene permisos";
        public ArchivoSinPermisosException() : base(SinPermisoError)
        {
        }
    }
}