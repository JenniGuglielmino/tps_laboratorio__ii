using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Empleado
    {
        public event Action ContarVentasEmpleado;

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

        static Empleado()
        {
            Empleados = new List<Empleado>();
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

        public bool Vender(Producto producto, Cliente cliente, int unidades, out Venta outVenta)
        {
            Venta auxVenta = new Venta(producto, cliente, unidades);
            bool altaOk = false;
            if (cliente.Saldo >= auxVenta.TotalAPagar)
            {
                if ((producto as IStockeable).HayStock(unidades))
                {
                    altaOk = Venta.Ventas + auxVenta;
                    if (altaOk)
                    {
                        ContarVentasEmpleado?.Invoke();
                        cliente.Saldo -= auxVenta.TotalAPagar;
                        producto.Cantidad -= unidades;
                        cliente.Puntos += auxVenta.CargarPuntos(auxVenta.TotalAPagar);
                    }
                }
                else
                {
                    throw new ProductoSinUnidadesException("No hay suficientes unidades del producto, verifique los datos ingresados");
                }
            }
            else
            {
                throw new ClienteSinDineroException(cliente.Nombre, cliente.Saldo, "Error en la venta, el saldo no es suficiente");
            }
            outVenta = auxVenta;
            return altaOk;
        }
    }
}
