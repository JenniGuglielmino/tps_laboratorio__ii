using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void CalcularPuntos_CuandoCompra_DeberiaSerUnoCadaCien()
        {
            //Arrange
            Cliente cliente = new Cliente("Juan", "Gonzalez", 500);
            int puntosEsperados = 5;
            Venta venta = new Venta();
            //Act
            int resultado = venta.CargarPuntos(cliente.Saldo);

            //Assert
            Assert.AreEqual(puntosEsperados, resultado);
        }

        [TestMethod]
        public void CalcularPuntos_CuandoNoTieneSaldo_DeberiaSerCero()
        {
            //Arrange
            Cliente cliente = new Cliente("Juan", "Gonzalez", 0);
            Venta venta = new Venta();
            int resultadoEsperado = 0;
            //Act
            int resultado = venta.CargarPuntos(cliente.Saldo);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void CanjearPremios_CuandoTienePuntosSuficientes_DeberiaSerTrue()
        {
            //Arrange
            Cliente cliente = new Cliente("Juan", "Gonzalez", 0);
            cliente.Puntos = 400;
            Producto producto = new Postre("Torta", "Helada", 1, 2000, 500, Entidades.Enumerados.ETipoProducto.Postre, 1);

            //Act
            bool resultado = cliente.Canjear(producto);

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ClienteSinPuntosException))]
        public void CanjearPremios_CuandoTieneNoPuntosSuficientes_DeberiaLanzarClienteSinPuntosException()
        {
            //Arrange
            Cliente cliente = new Cliente("Juan", "Gonzalez", 0);
            Producto producto = new Postre("Torta", "Helada", 1, 2000, 500, Entidades.Enumerados.ETipoProducto.Postre, 1);

            //Act
            cliente.Canjear(producto);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoSinUnidadesException))]
        public void CanjearPremios_CuandoNoHayMasStock_DeberiaLanzarProductoSinUnidadesException()
        {
            //Arrange
            Cliente cliente = new Cliente("Juan", "Gonzalez", 0);
            cliente.Puntos = 500;
            Producto producto = new Postre("Torta", "Helada", 0, 2000, 500, Entidades.Enumerados.ETipoProducto.Postre, 1);

            //Act
            cliente.Canjear(producto);
        }

        [TestMethod]
        public void CanjearPremios_CuandoTienePuntosSuficientes_DeberiaDescontarPuntosEnCliente()
        {
            //Arrange
            Cliente cliente = new Cliente("Juan", "Gonzalez", 0);
            cliente.Puntos = 400;
            Producto producto = new Postre("Torta", "Helada", 1, 2000, 500, Entidades.Enumerados.ETipoProducto.Postre, 1);

            //Act
            cliente.Canjear(producto);

            //Assert
            Assert.AreEqual(0, cliente.Puntos);
        }

        [TestMethod]
        public void CanjearPremios_CuandoTienePuntosSuficientes_DeberiaDescontarStock()
        {
            //Arrange
            Cliente cliente = new Cliente("Juan", "Gonzalez", 0);
            cliente.Puntos = 400;
            Producto producto = new Postre("Torta", "Helada", 1, 2000, 500, Entidades.Enumerados.ETipoProducto.Postre, 1);

            //Act
            cliente.Canjear(producto);

            //Assert
            Assert.AreEqual(0, producto.Cantidad);
        }
    }
}
