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
    public partial class ListaPokemons : System.Web.UI.Page
    {
        private static List<Pokemon> pokemons;

        public bool FiltroAvanzado {  get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtMensaje.Visible = false;
            lblSeAgregoCorrect.Visible = false;
            lblSeModificoCorrect.Visible = false;
            lblSeEliminoCorrect.Visible = false;

            try
            {
                if (!(Seguridad.EsAdmin(Session["usuario"]) == "Admin"))
                {
                    Session.Add("Error", "Se requieren permisos de Admin para acceder a esta pantalla");
                    Response.Redirect("Error.aspx", false);
                }

                FiltroAvanzado = chkAvanzado.Checked;

                pokemons = PokemonDAO.LeerPokemones();
                ListaPokemons.OrdenarPorValor(pokemons);
                dgvPokemons.DataSource = pokemons;
                dgvPokemons.DataBind();
            }
            catch (DataBasesException ex)
            {
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx");
            }

            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());

                switch (id)
                {
                    case 1:
                        lblSeAgregoCorrect.Text = Session["Complete"].ToString();
                        lblSeAgregoCorrect.Visible = true;
                        break;
                    case 2:
                        lblSeModificoCorrect.Text = Session["Complete"].ToString();
                        lblSeModificoCorrect.Visible = true;
                        break;
                    case 0:
                        lblSeEliminoCorrect.Text = Session["Complete"].ToString();
                        lblSeEliminoCorrect.Visible = true;
                        break;
                    default:
                        lblSeAgregoCorrect.Visible = false;
                        lblSeModificoCorrect.Visible = false;
                        lblSeEliminoCorrect.Visible = false;
                        break;
                }
            }
            else
            {
                lblSeAgregoCorrect.Visible = false;
                lblSeModificoCorrect.Visible = false;
                lblSeEliminoCorrect.Visible = false;
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
                try
                {
                    pokemons = PokemonDAO.LeerPokemones();
                    ListaPokemons.OrdenarPorValor(pokemons);
                    dgvPokemons.DataSource = pokemons;
                    dgvPokemons.DataBind();
                }
                catch (DataBasesException ex)
                {
                    Session.Add("Error", ex.Message);
                    Response.Redirect("Error.aspx");
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.Message);
                    Response.Redirect("Error.aspx");
                }
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

                if (listaFiltrada.Count == 0)
                {
                    throw new NotDataFound("¡No hay ningun pokémon con los filtros ingresados, intenta de ingresar otros filtros!");
                }
            }
            catch (NotDataFound ex)
            {
                txtMensaje.Visible = true;
                txtMensaje.Text = ex.Message;
            }
            catch (DataBasesException ex)
            {
                txtMensaje.Visible = true;
                txtMensaje.Text = ex.Message;
            }
            catch (Exception)
            {
                txtMensaje.Visible = true;
                txtMensaje.Text = "¡Hubo un error al al filtrar el pokemon, intenta filtrar nuevamente los datos del mismo!";
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