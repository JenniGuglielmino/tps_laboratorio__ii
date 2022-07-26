using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class EmpleadoTest
    {
        [TestMethod]
        public void VentaExitosa_CuandoElClienteTieneSaldoNecesario_DeberiaSerTrue()
        {
            //Arrange
            Cliente cliente = new Cliente("Juan", "Gonzalez", 300, 0);
            Postre producto = new Postre("McFrido", "Pote", 5, 120, 250, Entidades.Enumerados.ETipoProducto.Helado, 2);
            Empleado empleado = new Empleado("Juan", "1234");
            Venta ventaAux;
            
            //Act
            bool resultado = empleado.Vender(producto, cliente, 1, out ventaAux);

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoSinUnidadesException))]
        public void VentaFallida_CuandoNoAlcanzanLasUnidades_DeberiaLanzarProductoSinUnidadesException()
        {
            //Arrange
            Cliente cliente = new Cliente("Juan", "Gonzalez", 500, 0);
            Postre producto = new Postre("McFrido", "Pote", 1, 120, 250, Entidades.Enumerados.ETipoProducto.Helado, 2);
            Empleado empleado = new Empleado("Juan", "1234");
            Venta ventaAux;

            //Act
            empleado.Vender(producto, cliente, 3, out ventaAux);
        }

        [TestMethod]
        [ExpectedException(typeof(ClienteSinDineroException))]
        public void VentaFallida_CuandoElClienteNoTieneSaldo_DeberiaLanzarClienteSinDineroException()
        {
            //Arrange
            Cliente cliente = new Cliente("Juan", "Gonzalez", 0, 0);
            Postre producto = new Postre("McFrido", "Pote", 5, 120, 250, Entidades.Enumerados.ETipoProducto.Helado, 2);
            Empleado empleado = new Empleado("Juan", "1234");
            Venta ventaAux;

            //Act
            empleado.Vender(producto, cliente, 1, out ventaAux);
        }

        [TestMethod]
        public void ContraseniaCorrecta_CuandoEstaVacio_DeberiaSerFalse()
        {
            //Arrange
            string contraseniaPrueba = " ";
            Empleado empleado = new Empleado("juan", "1234");


            //Act
            bool resultado = empleado.ContraseniaCorrecta(contraseniaPrueba);

            //Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void ContraseniaCorrecta_CuandoTieneEspacios_DeberiaSerTrue()
        {
            //Arrange
            string contraseniaPrueba = "1234 ";
            Empleado empleado = new Empleado("juan", "1234");


            //Act
            bool resultado = empleado.ContraseniaCorrecta(contraseniaPrueba);

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Login_CuandoEsCorrecto_DeberiaSerTrue()
        {
            //Arrange
            string contraseniaPrueba = "1234 ";
            string usuarioPrueba = "juan";
            Empleado empleado = new Empleado("juan", "1234");
            Empleado.Empleados.Add(empleado);


            //Act
            bool resultado = Empleado.Login(usuarioPrueba, contraseniaPrueba);

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Login_CuandoEsIncorrecto_DeberiaSerFalse()
        {
            //Arrange
            string contraseniaPrueba = "1234 ";
            string usuarioPrueba = "juan";
            Empleado empleado = new Empleado("pepe", "1234");
            Empleado.Empleados.Add(empleado);


            //Act
            bool resultado = Empleado.Login(usuarioPrueba, contraseniaPrueba);

            //Assert
            Assert.IsFalse(resultado);
        }

    }
}
