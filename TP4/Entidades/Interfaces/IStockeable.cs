
namespace Entidades
{
    public interface IStockeable
    {
        public int Cantidad
        {
            get; set ;
        }
        /// <summary>
        /// Verifica que haya stock
        /// </summary>
        /// <param name="unidades">Cantidad de unidades que quieren comprar</param>
        /// <returns>true si hay stock, false si no hay</returns>
        public bool HayStock(int unidades)
        {
            return Cantidad >= unidades;
        }
    }
}
