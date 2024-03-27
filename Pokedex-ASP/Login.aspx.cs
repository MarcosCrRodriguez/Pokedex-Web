using ClasesDatos;
using Dominio;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokedex_ASP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            
            try
            {
                if (Validacion.ValidaTextoVacio(txtUser.Text) || Validacion.ValidaTextoVacio(txtPassword.Text))
                {
                    lblMensaje.Visible = true;
                    throw new EmptyParametersException("¡Alguno de los campos esta vacio, debe ingesar datos en todos los campos!");
                }
                else
                {
                    lblMensaje.Visible = false;
                }

                usuario.User = txtUser.Text;
                usuario.Pass = txtPassword.Text;

                if (UsuarioDAO.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx");
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No se encuentra el usuario en la DB, ingrese corretamente los datos.\n" +
                        "Si no tiene cuenta, ingrese en la opcion de [Registrar]";
                }
            }
            catch (EmptyParametersException ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (DataBasesException ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrio un error inesperado.\n" + ex.Message;
            }
        }
    }
}