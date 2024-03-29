﻿using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Empleado
    {
        public event Action ContarVentasEmpleado;

        string usuario;
        string contrasenia;
        private static List<Empleado> empleados;

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

        /// <summary>
        /// Valida que la contraseña no ese vacia o contenga espacios al principio o al final
        /// </summary>
        /// <param name="contraseniaIngresada">Contraseña ingresada</param>
        /// <returns>True si es valida, false si no lo es</returns>
        public bool ContraseniaCorrecta(string contraseniaIngresada)
        {
            return (!string.IsNullOrEmpty(contraseniaIngresada) && contraseniaIngresada.Trim() == contrasenia.Trim());
        }
        /// <summary>
        /// Permite el logueo del empleado comparando su contraseña y usuario
        /// </summary>
        /// <param name="usuario">Usuario ingresado</param>
        /// <param name="contrasenia">Contraseña ingresada</param>
        /// <returns>True si puede loguearse, false si no</returns>
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
        /// <summary>
        /// Realiza la venta
        /// </summary>
        /// <param name="producto">Producto a vender</param>
        /// <param name="cliente">Cliente</param>
        /// <param name="unidades">Cantidad de unidades a comprar</param>
        /// <param name="outVenta">Salida de venta</param>
        /// <returns>True si pudo realizar la venta, false si no pudo</returns>
        public bool Vender(Producto producto, Cliente cliente, int unidades, out Venta outVenta)
        {
            Venta auxVenta = new Venta(cliente, producto, unidades);
            bool altaOk;
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
                        AccesoSql.ModificarCliente(cliente);
                        AccesoSql.ModificarProducto(producto);
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
