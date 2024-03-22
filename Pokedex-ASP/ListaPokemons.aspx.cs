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
    public partial class ListaPokemons : System.Web.UI.Page
    {
        private static List<Pokemon> pokemons;

        public bool FiltroAvanzado {  get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Seguridad.EsAdmin(Session["usuario"]) == "Admin"))
            {
                Session.Add("Error", "Se requieren permisos de Admin para acceder a esta pantalla");
                Response.Redirect("Error.aspx");
            }

            FiltroAvanzado = chkAvanzado.Checked;
            if (!IsPostBack)
            {
                pokemons = PokemonDAO.LeerPokemones();
                ListaPokemons.OrdenarPorValor(pokemons);
                dgvPokemons.DataSource = pokemons;
                dgvPokemons.DataBind();
            }
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("FormPokemon.aspx?id=" + id);
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataBind();
        }

        public static void OrdenarPorValor(List<Pokemon> lista)
        {
            pokemons = lista.OrderBy(pokemon => pokemon.NumeroPokedex).ToList();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada = pokemons.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;

            if (FiltroAvanzado == false)
            {
                pokemons = PokemonDAO.LeerPokemones();
                ListaPokemons.OrdenarPorValor(pokemons);
                dgvPokemons.DataSource = pokemons;
                dgvPokemons.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pokemon> listaFiltrada = PokemonDAO.LeerPokemonesFiltro(ddlTipo.SelectedItem.ToString(), ddlDebilidad.SelectedItem.ToString());
                ListaPokemons.OrdenarPorValor(listaFiltrada);
                dgvPokemons.DataSource = listaFiltrada;
                dgvPokemons.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ddlDebilidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}