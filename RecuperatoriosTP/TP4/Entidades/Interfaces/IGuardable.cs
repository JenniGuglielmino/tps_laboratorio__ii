namespace Entidades
{
    public interface IGuardable<T>
    {
        public enum ETipoArchivo { XML, JSON, TXT };
        public T Leer(string path);
        public void Escribir(T dato, string filename);
    }
}