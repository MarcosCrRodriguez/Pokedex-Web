using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Pokedex_ASP
{
    public static class Validacion
    {
        public static bool ValidaTextoVacio(string texto)
        {
            bool rtn = false;

            if (string.IsNullOrEmpty(texto))
            {
                rtn = true;
            }
            else
            {
                rtn = false;
            }

            return rtn;
        }

        public static string VerificarNumero(int numero)
        {
            string cadena = $"{numero}";

            if (numero < 10)
            {
                cadena = $"000{numero}";
            }
            else if (numero < 100)
            {
                cadena = $"00{numero}";
            }
            else if (numero < 1000)
            {
                cadena = $"0{numero}";
            }

            return cadena;
        }

        public static string ValidarCadenaNinguno(string cadena)
        {
            if (!(cadena == "Ninguno"))
            {
                return "[" + cadena + "]";
            }
            else
            {
                return "";
            }
        }
    }
}