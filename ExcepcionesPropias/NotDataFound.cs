using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class NotDataFound : Exception
    {
        public NotDataFound(string mensaje) : this(mensaje, null)
        {

        }

        public NotDataFound(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
