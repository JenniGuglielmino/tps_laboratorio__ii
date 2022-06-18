using System;
using System.IO;

namespace Entidades
{
    public class ArchivoTexto : IGuardable<string>
    {
        public void Escribir(string dato, string path)
        {
            try
            {
                using (Stream s = File.Open(path, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.WriteLine(dato);
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw new ArchivoSinPermisosException();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al guardar el archivo", ex);
            }
        }

        public string Leer(string path)
        {
            string returnAux = string.Empty;
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    while (!streamReader.EndOfStream)
                    {
                        returnAux += $"{streamReader.ReadLine()}\n";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al leer el archivo", ex);
            }
            return returnAux;
        }
    }
}
