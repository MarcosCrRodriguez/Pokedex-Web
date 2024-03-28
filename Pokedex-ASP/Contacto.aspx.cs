using ClasesDatos;
using Dominio;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokedex_ASP
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblComentario.Visible = false;
            lblError.Visible = false;
            lblInfo.Text = "En esta apartado tenes la oportunidad de contarnos que te parece la página, comentanos que te gusto o no de esta, y si cambiarias algo asi podempos aprender acerca de otros puntos de vista. " +
                "Espero que estes disfrutando del contenido de la página, y esperamos tu apoyo para mejorar (≧◡≦)";
            imgContacto.ImageUrl = "./FotosUtilizadas/initials-beasts.jpg";
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validacion.ValidaTextoVacio(txtEmail.Text) || Validacion.ValidaTextoVacio(txtAsunto.Text) || Validacion.ValidaTextoVacio(txtMensaje.Text))
                {
                    lblError.Visible = true;
                    throw new EmptyParametersException("¡Alguno de los campos esta vacio, debe ingesar datos en todos los campos!");
                }
                else
                {
                    lblError.Visible = false;
                }

                EmailService emailService = new EmailService();
                emailService.ComentarioUsuario(txtEmail.Text, txtAsunto.Text, txtMensaje.Text);
                emailService.EnviarEmail();

                txtEmail.Text = "";
                txtAsunto.Text = "";
                txtMensaje.Text = "";
                lblComentario.Visible = true;
                lblComentario.Text = "Se envió correctamente el mensaje";
            }
            catch (EmptyParametersException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (Exception)
            {
                Session.Add("Error", "Error al enviar el comentario");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}