using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace ClasesDatos
{
    public static class Seguridad
    {

        public static bool SesionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;

            if (usuario != null && usuario.ID != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static string EsAdmin(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            return usuario != null ? usuario.TipoUser : "Normal";
        }
    }
}
