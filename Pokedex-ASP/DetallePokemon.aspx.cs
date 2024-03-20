using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using ClasesDatos;
using System.Web.Configuration;

namespace Pokedex_ASP
{
    public partial class DetallePokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());

                Pokemon pokemon = PokemonDAO.LeerPorID(id);
                lblDatosPokemon.Text = $"{pokemon.Nombre} - {pokemon.NumeroPokedex}";
                srcUrl.ImageUrl = pokemon.UrlImagen;
                lblTipo.Text = "Tipo: "; 
                lblTipoBorder.Text = pokemon.Tipo;
                lblResistencia.Text = "Resistencia: ";
                lblResistenciaBorder.Text = pokemon.Resistencia;
                lblDebilidad.Text = "Debilidad: ";
                lblDebilidadBorder.Text = pokemon.Debilidad;
                prfPokemon.Text = pokemon.Descripcion;
            }
        }

        protected void btnVolverPokedex_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}