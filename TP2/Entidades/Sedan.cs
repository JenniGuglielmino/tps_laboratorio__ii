using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo { CuatroPuertas, CincoPuertas }

        ETipo tipo;

        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca">Marca del vehiculo Sedan</param>
        /// <param name="chasis">Chasis del vehiculo Sedan</param>
        /// <param name="color">Color del vehiculo Sedan</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            :this(marca, chasis, color, ETipo.CuatroPuertas)
        {
            
        }
        /// <summary>
        /// Constructor de la clase Sedan
        /// </summary>
        /// <param name="marca">Marca del vehiculo Sedan</param>
        /// <param name="chasis">Chasis del vehiculo Sedan</param>
        /// <param name="color">Color del vehiculo Sedan</param>
        /// <param name="tipo">Cantidad de puertas del vehiculo Sedan</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            :base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Genera un string
        /// </summary>
        /// <returns>string con los datos del Sedan</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine($"{base.Mostrar()}TIPO : {this.tipo}\r\n");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
