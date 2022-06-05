using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado
    {
        int id;
        string usuario;
        string contrasenia;
        private static List<Empleado> empleados;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }

        public static List<Empleado> Empleados 
        {
            get { return empleados; }
            set { empleados = value; }
        }


        public Empleado(string usuario, string contrasenia)
        {
            this.usuario = usuario;
            this.contrasenia = contrasenia;
        }

        public bool ContraseniaCorrecta(string contraseniaIngresada)
        {
            return (!string.IsNullOrEmpty(contraseniaIngresada) && contraseniaIngresada.Trim() == contrasenia.Trim());
        }

        public static bool Login(string usuario, string contrasenia)
        {
            foreach (Empleado empleado in Empleados)
            {
                if (empleado.usuario == usuario.ToLower())
                {
                    if (empleado.ContraseniaCorrecta(contrasenia))
                    {
                        NucleoAplicacion.EmpleadoLogueado = empleado;
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
