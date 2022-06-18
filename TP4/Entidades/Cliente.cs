using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Cliente
    {
        private int id;
        private string nombre;
        private string apellido;
        private int puntos;
        private double saldo;
        private static List<Cliente> clientes;
        private static int currentId;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public static int CurrentId
        {
            get { return currentId; }
            set { currentId = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }
        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public static List<Cliente> Clientes
        {
            get { return clientes; }
            set { clientes = value; }
        }
        public Cliente()
        {
            currentId++;
            this.id = currentId;
        }

        public Cliente(string nombre, string apellido, double saldo): this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.saldo = saldo;
            
        }

        static Cliente()
        {
            Clientes = new List<Cliente>();
        }

        public static bool operator +(List<Cliente> clientes, Cliente cliente)
        {
            bool altaOk = false;
            foreach (Cliente cliente1 in clientes)
            {
                if (cliente1 == cliente)
                {
                    return false;
                }
            }
            clientes.Add(cliente);
            altaOk = true;
            return altaOk;
        }

        public static void CargaClientesInicial()
        {
            Serializador<List<Cliente>> serializador = new Serializador<List<Cliente>>(IGuardable<List<Cliente>>.ETipoArchivo.JSON);
            string ruta = Environment.CurrentDirectory;
            ruta += @"\ArchivosIniciales";
            string path = ruta + @"\CargaClientesInicial.json";
            List<Cliente> clientesJson = serializador.Leer(path);
            foreach (Cliente item in clientesJson)
            {
                Cliente.Clientes.Add(item);
            }
        }
    }
}
