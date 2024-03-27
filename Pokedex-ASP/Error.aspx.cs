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
    public partial class Error : System.Web.UI.Page
    {
        public int DebeLogearse { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());

                DebeLogearse = id;
            }
            else
            {
                DebeLogearse = 1;
            }

            if (Session["Error"] != null)
            {
                lblError.Text = Session["Error"].ToString();
            }
            else
            {
                lblError.Text = "Hubo un error al cargar la página... intenta nuevamente en unos minutos. Estamos intentando de resolver el problema.";
            }
        }
    }
}