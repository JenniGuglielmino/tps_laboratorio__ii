using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Serializador<T> : IGuardable<T> where T : class
    {

        private IGuardable<T>.ETipoArchivo tipo;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tipo"></param>
        public Serializador(IGuardable<T>.ETipoArchivo tipo)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Metodo que escribe
        /// </summary>
        /// <param name="dato">Dato a escribir</param>
        /// <param name="path">Path donde escribir</param>
        public void Escribir(T dato, string path)
        {
            try
            {
                if (this.tipo == IGuardable<T>.ETipoArchivo.XML)
                {
                    if (Path.GetExtension(path) == ".xml")
                    {
                        using (XmlTextWriter xmlTextWriter = new XmlTextWriter(path, Encoding.UTF8))
                        {
                            xmlTextWriter.Formatting = Formatting.Indented;
                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                            xmlSerializer.Serialize(xmlTextWriter, dato);
                        }
                    }
                    else
                    {
                        throw new ExtensionInvalidaException("Extension Invalida para XML");
                    }
                }
                else
                {
                    if (Path.GetExtension(path) == ".json")
                    {
                        ArchivoTexto archivoTexto = new ArchivoTexto();
                        archivoTexto.Escribir(JsonSerializer.Serialize(dato, typeof(T)), path);
                    }
                    else
                    {
                        throw new ExtensionInvalidaException("Extension Invalida para JSON");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al Serializar", ex);
            }
        }
        /// <summary>
        /// Metodo para leer
        /// </summary>
        /// <param name="path">De donde leer</param>
        /// <returns></returns>
        public T Leer(string path)
        {

            try
            {
                if (this.tipo == IGuardable<T>.ETipoArchivo.XML)
                {
                    if (Path.GetExtension(path) == ".xml")
                    {
                        using (XmlTextReader xmlTextReader = new XmlTextReader(path))
                        {
                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                            return (T)xmlSerializer.Deserialize(xmlTextReader);
                        }
                    }
                    else
                    {
                        throw new ExtensionInvalidaException("Extension Invalida para XML");
                    }
                }
                else
                {
                    if (Path.GetExtension(path) == ".json")
                    {
                        ArchivoTexto archivoTexto = new ArchivoTexto();
                        string texto = archivoTexto.Leer(path);
                        return JsonSerializer.Deserialize<T>(texto);
                    }
                    else
                    {
                        throw new ExtensionInvalidaException("Extension Invalida para JSON");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al Deserializar", ex);
            }
        }
    }
}
