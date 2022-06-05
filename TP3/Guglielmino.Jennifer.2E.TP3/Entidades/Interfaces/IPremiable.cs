using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    interface IPremiable
    {
        public int CostoEnPuntos { get; set; }
        bool Intercambiar();
    }
}
