using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Cliente
    {
        private int id;
        private string nombre;
        private int puntos;
        private float saldo;
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
        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }
        public float Saldo
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
            this.id = Clientes.Last().id++;
        }
        public Cliente(string nombre, float saldo): this()
        {
            this.nombre = nombre;
            this.saldo = saldo;
            
        }

        public bool CrearCliente(string nombre, float saldo)
        {

            try
            {
                Cliente cliente = new Cliente(nombre, saldo);
                Clientes.Add(cliente);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
