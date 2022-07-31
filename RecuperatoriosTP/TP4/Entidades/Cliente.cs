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

        public int Id
        {
            get { return id; }
            set { id = value; }
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
        /// <summary>
        /// Constructor sin parametros para serializar
        /// </summary>
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
            :this(nombre, apellido, saldo, puntos)
        {
            this.id = id;
        }
        /// <summary>
        /// Contructor con parametros para crear en la base
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
        /// Carga clientes a la lista estatica leyendolos desde la base
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
