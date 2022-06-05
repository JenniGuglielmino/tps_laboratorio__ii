using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    interface IVendibles
    {
        public float Precio { get; set; }
        bool Vender();
    }
}
