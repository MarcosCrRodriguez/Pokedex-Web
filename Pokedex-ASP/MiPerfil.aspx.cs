using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClasesDatos;
using Dominio;
using ExcepcionesPropias;

namespace Pokedex_ASP
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //cargar los datos del usuario cuando me haya logeado en el perfil
            //pasados por sesion
            if (Seguridad.SesionActiva(Session["usuario"]))
            {
                txtUsuario.Text = ((Usuario)Session["usuario"]).User;
                txtUsuario.Enabled = false;
                txtTipoUser.Text = ((Usuario)Session["usuario"]).TipoUser;
                txtTipoUser.Enabled = false;

                if (!(((Usuario)Session["usuario"]).ImagenPerfil == null || ((Usuario)Session["usuario"]).ImagenPerfil == ""))
                {
                    imgPerfil.ImageUrl = "~/Images/" + ((Usuario)Session["usuario"]).ImagenPerfil;
                    lblMensaje.Visible = false;
                    //podriamos ponerlo en una funcion asi me devuelve esta ruta
                }
                else
                {
                    imgPerfil.ImageUrl = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder-1024x683.png";
                    lblMensaje.Visible = true;
                }

                if (!(((Usuario)Session["usuario"]).Nombre == null || ((Usuario)Session["usuario"]).Nombre == ""))
                {
                    txtNombre.Text = ((Usuario)Session["usuario"]).Nombre;
                    lblMensaje.Visible = false;
                }
                else
                {
                    lblMensaje.Visible = true;
                }

                if (!(((Usuario)Session["usuario"]).Apellido == null || ((Usuario)Session["usuario"]).Apellido == ""))
                {
                    txtApellido.Text = ((Usuario)Session["usuario"]).Apellido;
                    lblMensaje.Visible = false;
                }
                else
                {
                    lblMensaje.Visible = true;
                }

                if (!(((Usuario)Session["usuario"]).FechaNacimiento == null || ((Usuario)Session["usuario"]).FechaNacimiento.ToString("yyyy-MM-dd") == "" || ((Usuario)Session["usuario"]).FechaNacimiento.ToString("yyyy-MM-dd") == "0001-01-01"))
                {
                    txtFechaNacimiento.Text = ((Usuario)Session["usuario"]).FechaNacimiento.ToString("yyyy-MM-dd");
                    lblMensaje.Visible = false;
                }
                else
                {
                    lblMensaje.Visible = true;
                }
            }
            else
            {
                imgPerfil.ImageUrl = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder-1024x683.png";
            }

            if (lblMensaje.Visible)
            {
                lblMensaje.Text = "Tienes que completar datos en los campos faltantes asi se guardará su registro de los mismos en tu perfil";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                if (Validacion.ValidaTextoVacio(txtNombre.Text) || Validacion.ValidaTextoVacio(txtApellido.Text) || Validacion.ValidaTextoVacio(txtFechaNacimiento.Text))
                {
                    lblMensaje.Visible = true;
                    throw new EmptyParametersException("¡Alguno de los campos esta vacio, debe ingesar datos en todos los campos!");
                }
                else
                {
                    lblMensaje.Visible = false;
                }

                Usuario usuario = (Usuario)Session["usuario"];

                if (txtImage.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImage.PostedFile.SaveAs(ruta + "perfil-" + $"{usuario.ID}.jpg");
                    usuario.ImagenPerfil = "perfil-" + $"{usuario.ID}.jpg";
                }

                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                if (UsuarioDAO.ActualizarUsuario(usuario))
                {
                    Image img = (Image)Master.FindControl("imgAvatar");
                    img.ImageUrl = "~/Images/" + usuario.ImagenPerfil;

                    Session.Add("Completed", "Se cargaron correctamente los datos");
                    Response.Redirect("MiPerfil.aspx", false);
                }
            }
            catch (EmptyParametersException ex)
            {
                lblMensaje.Text = "¡Alguno de los campos esta vacio, debe ingesar datos en todos los campos!";
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }
    }
}