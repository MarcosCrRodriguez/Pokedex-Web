using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class EmptyParametersException : Exception
    {
        public EmptyParametersException(string mensaje) : this(mensaje, null)
        {

        }

        public EmptyParametersException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
