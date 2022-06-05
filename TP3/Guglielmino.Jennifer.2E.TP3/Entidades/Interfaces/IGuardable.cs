using Entidades.Enumerados;

namespace Entidades
{
    public interface IGuardable<T>
    {
        public enum ETipoArchivo { XML, JSON };
        public T Leer(string path);
        public void Escribir(T dato, string path);
    }
}