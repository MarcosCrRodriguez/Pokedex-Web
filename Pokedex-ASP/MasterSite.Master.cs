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
            if(!(this.Page is Login || this.Page is Registro || this.Page is Home || this.Page is Default))
            {
                if (!(Seguridad.SesionActiva(Session["usuario"])))
                {
                    Response.Redirect("Login.aspx", false);
                }
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
            Session["usuario"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}