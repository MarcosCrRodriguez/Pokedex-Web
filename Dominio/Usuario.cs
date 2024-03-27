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
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ImagenPerfil { get; set; }
        public DateTime FechaNacimiento { get; set; }

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

        public Usuario(int id, string user, string pass, string tipoUsuario, string nombre, string apellido, string imagenPerfil, DateTime fechaNacimiento)
        {
            ID = id;
            User = user;
            Pass = pass;
            TipoUser = tipoUsuario;
            Nombre = nombre;
            Apellido = apellido;
            ImagenPerfil = imagenPerfil;
            FechaNacimiento = fechaNacimiento;
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
    }
}
