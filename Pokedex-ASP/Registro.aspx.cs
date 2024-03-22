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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario(0, txtUser.Text, txtPassword.Text, "Normal");
                if (!(Usuario.VerificarExistePokemon(UsuarioDAO.LeerUsuarios(), txtUser.Text)))
                {
                    if (UsuarioDAO.AgregarUsuario(usuario))
                    {
                        Session.Add("Registrado", "Se registro el usuario correctamente");
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "¡Ya existe un Usuario en la DB con esos mismos datos!\n" +
                        "Registre un Usuario con un nombre distinto";
                }
            }
            catch (Exception)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "¡Hubo un problema con la DB!";
            }
        }
    }
}