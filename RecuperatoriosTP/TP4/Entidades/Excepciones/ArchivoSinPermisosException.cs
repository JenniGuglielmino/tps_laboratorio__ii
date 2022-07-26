using System;

namespace Entidades
{
    /// <summary>
    /// Excepcion que se lanzara si el archivo no tiene permisos
    /// </summary>
    public class ArchivoSinPermisosException : Exception
    {
        private const string SinPermisoError = "No tiene permisos";
        public ArchivoSinPermisosException() : base(SinPermisoError)
        {
        }
    }
}