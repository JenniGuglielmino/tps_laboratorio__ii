using System;
using System.Collections.Generic;
using System.Linq;

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
        }
        /// <summary>
        /// Contructor con parametros
        /// </summary>
        /// <param name="nombre">Nombre del cliente</param>
        /// <param name="apellido">Apellido del cliente</param>
        /// <param name="saldo">Saldo con el que cuenta el cliente</param>
        public Cliente(int id, string nombre, string apellido, double saldo, int puntos)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.saldo = saldo;
            this.puntos = puntos;
        }
        /// <summary>
        /// Contructor con parametros
        /// </summary>
        /// <param name="nombre">Nombre del cliente</param>
        /// <param name="apellido">Apellido del cliente</param>
        /// <param name="saldo">Saldo con el que cuenta el cliente</param>
        public Cliente(string nombre, string apellido, double saldo, int puntos)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.saldo = saldo;
            this.puntos = puntos;
        }
        /// <summary>
        /// Contructor estatico
        /// </summary>
        static Cliente()
        {
            Clientes = new List<Cliente>();
        }
        /// <summary>
        /// Compara dos clientes por su id
        /// </summary>
        /// <param name="cliente1">Primer cliente</param>
        /// <param name="cliente2">Segundo cliente</param>
        /// <returns>True si son iguales, false si no lo son</returns>
        public static bool operator ==(Cliente cliente1, Cliente cliente2)
        {
            return (cliente1.Id == cliente2.Id);
        }
        /// <summary>
        /// Compara dos clientes por su id
        /// </summary>
        /// <param name="cliente1">Primer cliente</param>
        /// <param name="cliente2">Segundo cliente</param>
        /// <returns>True no son iguales, false si lo son</returns>
        public static bool operator !=(Cliente cliente1, Cliente cliente2)
        {
            return !(cliente1 == cliente2);
        }
        /// <summary>
        /// Agrega un cliente a la lista de clientes si este no existe
        /// </summary>
        /// <param name="clientes">Lista de clientes</param>
        /// <param name="cliente">Cliente a agregar</param>
        /// <returns>True si pudo agregarlo, false si no pudo</returns>
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
        /// <summary>
        /// Carga inicialmente clientes desde un archivo 
        /// </summary>
        public static void CargaClientesInicial()
        {
            List<Cliente> clientes = AccesoSql.LeerClientes();
            Cliente.Clientes.Clear();
            foreach (Cliente cliente in clientes)
            {
                Cliente.Clientes.Add(cliente);
            }
        }
    }
}
