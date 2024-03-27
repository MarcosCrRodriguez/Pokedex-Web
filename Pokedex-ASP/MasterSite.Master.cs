using ClasesDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokedex_ASP
{
    public partial class MasterSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(this.Page is Login || this.Page is Registro || this.Page is Default || this.Page is DetallePokemon || this.Page is Error))
            {
                if (!(Seguridad.SesionActiva(Session["usuario"])))
                {
                    Session.Add("Error", "Primero debe logearse para poder ingresar a esta página");
                    Response.Redirect("Error.aspx?id=" + 0, false);
                }
            }

            if (Seguridad.SesionActiva(Session["usuario"]))
            {
                txtUsuario.Text = ((Usuario)Session["usuario"]).User;

                if (!(((Usuario)Session["usuario"]).ImagenPerfil == null || ((Usuario)Session["usuario"]).ImagenPerfil == ""))
                {
                    imgAvatar.ImageUrl = "~/Images/" + ((Usuario)Session["usuario"]).ImagenPerfil;
                    //podriamos ponerlo en una funcion asi me devuelve esta ruta
                }
                else
                {
                    imgAvatar.ImageUrl = "https://as1.ftcdn.net/v2/jpg/03/39/45/96/1000_F_339459697_XAFacNQmwnvJRqe1Fe9VOptPWMUxlZP8.jpg";
                }
            }
            else
            {
                imgAvatar.ImageUrl = "https://as1.ftcdn.net/v2/jpg/03/39/45/96/1000_F_339459697_XAFacNQmwnvJRqe1Fe9VOptPWMUxlZP8.jpg";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}