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
    public partial class Default : System.Web.UI.Page
    {
        public static List<Pokemon> pokemons;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            lblMensaje.Visible = false;

            try
            {
                pokemons = PokemonDAO.LeerPokemones();
                pokemons = OrdenarPorValor(pokemons);

                //if (!IsPostBack)
                //{
                //    repRepetidor.DataSource = pokemons;
                //    repRepetidor.DataBind();
                //}
            }
            catch (DataBasesException ex)
            {
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx");
            }
            catch (Exception)
            {
                Session.Add("Error", "NO se pudieron cargar los pokémons de la pokedex, intente nuevamente en unos minutos");
                Response.Redirect("Error.aspx");
            }
        }

        public static List<Pokemon> OrdenarPorValor(List<Pokemon> lista)
        {
            // Ordenar la lista por la propiedad "Valor"
            return lista = lista.OrderBy(pokemon => pokemon.NumeroPokedex).ToList();
        }

        //protected void btnAcceder_Click(object sender, EventArgs e)
        //{
        //    string dato = ((Button)sender).CommandArgument;
        //    Response.Redirect("DetallePokemon.aspx?id=" + dato);
        //}

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validacion.ValidaTextoVacio(txtNumeroSerch.Text))
                {
                    lblInfo.Visible = false;
                    lblMensaje.Visible = true;
                    throw new EmptyParametersException("¡Alguno de los campos esta vacio, debe ingesar datos en todos los campos!");
                }
                else
                {
                    lblInfo.Visible = true;
                    lblMensaje.Visible = false;
                }

                Pokemon pokemon = PokemonDAO.LeerPorNumeroPokedex(Convert.ToInt32(txtNumeroSerch.Text));
                if (pokemon != null)
                {
                    Response.Redirect("DetallePokemon.aspx?id=" + pokemon.ID, false);
                }
                else
                {
                    throw new Exception("Es posible que el pokemon que estas buscando no se encuentre en la Pokedex, ingresa un nuevo numero en el buscador.");
                }
            }
            catch (EmptyParametersException ex)
            {
                lblInfo.Visible = false;
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx?id=" + -1);
            }

        }

        public string ValidarCadenaNinguno(string cadena)
        {
            if (!(cadena == "Ninguno"))
            {
                return "[" + cadena + "]";
            }
            else
            {
                return "";
            }
        }

        public string VerificarNumero(int numero)
        {
            string cadena = $"{numero}";

            if (numero < 10)
            {
                cadena = $"000{numero}";
            }
            else if (numero < 100)
            {
                cadena = $"00{numero}";
            }
            else if (numero < 1000)
            {
                cadena = $"0{numero}";
            }

            return cadena;
        }
    }
}