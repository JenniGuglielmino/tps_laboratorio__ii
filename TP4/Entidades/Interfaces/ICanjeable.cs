
namespace Entidades
{
    public interface ICanjeable
    {
        public int CostoEnPuntos { get; set; }

        public bool SePuedeCanjear(int puntosCliente)
        {
            return puntosCliente >= CostoEnPuntos;
        }
    }
}
