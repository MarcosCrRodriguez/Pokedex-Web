using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int ID { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string TipoUser { get; set; }

        public Usuario()
        {

        }

        public Usuario(int id, string user, string pass, string tipoUsuario)
        {
            ID = id;
            User = user;
            Pass = pass;
            TipoUser = tipoUsuario;
        }

        public static bool VerificarExistePokemon(List<Usuario> listaUsuario, string user)
        {
            if (listaUsuario.Count > 0 && listaUsuario != null)
            {
                foreach (var us in listaUsuario)
                {
                    if (us.User == user)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool UsuarioIsAdmin()
        {
            //

            return true;
        }
    }
}
