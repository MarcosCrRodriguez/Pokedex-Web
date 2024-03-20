using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClasesDatos;
using Dominio;

namespace Pokedex_ASP
{
    public partial class Default : System.Web.UI.Page
    {
        private static List<Pokemon> pokemons;
        protected void Page_Load(object sender, EventArgs e)
        {
            pokemons = PokemonDAO.LeerPokemones();
            pokemons = OrdenarPorValor(pokemons);

            if (!IsPostBack)
            {
                repRepetidor.DataSource = pokemons;
                repRepetidor.DataBind();
            }
        }

        public static List<Pokemon> OrdenarPorValor(List<Pokemon> lista)
        {
            // Ordenar la lista por la propiedad "Valor"
            return lista = lista.OrderBy(pokemon => pokemon.NumeroPokedex).ToList();
        }

        protected void btnAcceder_Click(object sender, EventArgs e)
        {
            string dato = ((Button)sender).CommandArgument;
            Response.Redirect("DetallePokemon.aspx?id=" + dato);
        }
    }
}