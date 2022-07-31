
namespace Entidades
{
    public interface IStockeable
    {
        public int Cantidad{ get; set ;}
        public bool HayStock(int unidades);
    }
}
