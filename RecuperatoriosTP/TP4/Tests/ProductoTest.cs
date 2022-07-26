using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ProductoTest
    {
        [TestMethod]
        public void AgregarProducto_CuandoSeSumaUnProductoDistinto_DeberiaSerTrue()
        {
            //Arrange
            Postre producto = new Postre("McFrido", "Pote", 5, 120, 250, Entidades.Enumerados.ETipoProducto.Helado, 2);

            //Act
            bool resultado = Producto.Productos + producto;

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void AgregarProducto_CuandoSeSumaUnProductoIgual_DeberiaSerFalse()
        {
            //Arrange
            Postre producto1 = new Postre("McFrido", "Pote", 5, 120, 250, Entidades.Enumerados.ETipoProducto.Helado, 2);
            Postre producto2 = new Postre("McFrido", "Pote", 5, 120, 250, Entidades.Enumerados.ETipoProducto.Helado, 2);
            producto1.Id = 1;
            producto2.Id = 1;

            //Act
            bool resultado = Producto.Productos + producto1;
            resultado = Producto.Productos + producto2;

            //Assert
            Assert.IsFalse(resultado);
        }
    }
}
