using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv: Vehiculo
    {
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        /// <summary>
        /// Constructor de la clase Suv
        /// </summary>
        /// <param name="marca">Marca del vehiculos Suv</param>
        /// <param name="chasis">Chasis del vehiculos Suv</param>
        /// <param name="color">Color del vehiculos Suv</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Genera el string para la clase de vehiculo Suv
        /// </summary>
        /// <returns>Retorna un string con los datos del vehiculo suv</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("---------------------\r");

            return sb.ToString();
        }
    }
}
