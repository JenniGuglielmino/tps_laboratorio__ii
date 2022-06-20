
namespace Entidades
{
    public interface ICanjeable
    {
        public int CostoEnPuntos { get; set; }
        /// <summary>
        /// Metodo que controla que los puntos del cliente sean suficientes
        /// </summary>
        /// <param name="puntosCliente"> int Puntos del cliente</param>
        /// <returns>true si alcanza, false si no alcanza</returns>
        public bool SePuedeCanjear(int puntosCliente)
        {
            return puntosCliente >= CostoEnPuntos;
        }
    }
}
