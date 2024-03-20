using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class ExistingDataOnDB : Exception
    {
        public ExistingDataOnDB(string mensaje) : this(mensaje, null)
        {

        }

        public ExistingDataOnDB(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
