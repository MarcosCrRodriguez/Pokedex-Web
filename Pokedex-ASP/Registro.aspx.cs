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
                if (Validacion.ValidaTextoVacio(txtUser.Text) || Validacion.ValidaTextoVacio(txtPassword.Text))
                {
                    lblMensaje.Visible = true;
                    throw new EmptyParametersException("¡Alguno de los campos esta vacio, debe ingesar datos en todos los campos!");
                }
                else
                {
                    lblMensaje.Visible = false;
                }

                EmailService emailService = new EmailService();
                Usuario usuario = new Usuario(0, txtUser.Text, txtPassword.Text, "Normal");
                if (!(Usuario.VerificarExistePokemon(UsuarioDAO.LeerUsuarios(), txtUser.Text)))
                {
                    if (UsuarioDAO.AgregarUsuario(usuario))
                    {
                        Usuario user = new Usuario();

                        user.User = txtUser.Text;
                        user.Pass = txtPassword.Text;

                        if (UsuarioDAO.Loguear(user))
                        {
                            Session.Add("usuario", user);

                            emailService.ArmarCorreo(txtUser.Text, "Registrado correctamente en la Pokedex-Web", "Te deseamos una agradable estadía en nuestra página, esperamos que disfrutes del contenido");
                            emailService.EnviarEmail();

                            Response.Redirect("MiPerfil.aspx");
                        }
                    }
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "¡Ya existe un Usuario en la DB con esos mismos datos!\n" +
                        "Registre un Usuario con un nombre distinto";
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
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message;
            }
        }
    }
}