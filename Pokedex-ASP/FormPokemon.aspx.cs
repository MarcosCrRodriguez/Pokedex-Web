﻿using System;
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
    public partial class FormPokemon : System.Web.UI.Page
    {
        private List<string> tipoElementos;
        private static int idPokemon;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
            lblMensaje.Text = string.Empty;

            if (!IsPostBack)
            {
                this.tipoElementos = new List<string>();
                this.CargarDatos();

                foreach (var tipo in tipoElementos)
                {
                    ddlTipo.Items.Add(tipo);
                    ddlResistencia.Items.Add(tipo);
                    ddlDebilidad.Items.Add(tipo);
                }

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());

                    Pokemon pokemon = PokemonDAO.LeerPorID(id);
                    idPokemon = pokemon.ID;
                    txtNumeroPokedex.Text = pokemon.NumeroPokedex.ToString();
                    txtNombre.Text = pokemon.Nombre;
                    txtDescripcion.Text = pokemon.Descripcion;
                    txtUrlImagen.Text = pokemon.UrlImagen;
                    ddlTipo.SelectedValue = pokemon.Tipo;
                    ddlResistencia.SelectedValue = pokemon.Resistencia;
                    ddlDebilidad.SelectedValue = pokemon.Debilidad;

                    btnAceptar.Visible = false;
                    btnModificar.Visible = true;
                    btnEliminar.Visible = true;
                    btnConirmarBaja.Visible = false;
                }
                else
                {
                    btnAceptar.Visible = true;
                    btnModificar.Visible = false;
                    btnEliminar.Visible = false;
                    btnConirmarBaja.Visible = false;
                }
            }
        }

        public void CargarDatos()
        {
            this.tipoElementos.Add("");
            this.tipoElementos.Add("Fuego");
            this.tipoElementos.Add("Agua");
            this.tipoElementos.Add("Planta");
            this.tipoElementos.Add("Eléctrico");
            this.tipoElementos.Add("Roca");
            this.tipoElementos.Add("Lucha");
            this.tipoElementos.Add("Tierra");
            this.tipoElementos.Add("Acero");
            this.tipoElementos.Add("Hielo");
            this.tipoElementos.Add("Psiquico");
            this.tipoElementos.Add("Siniestro");
            this.tipoElementos.Add("Fantasma");
            this.tipoElementos.Add("Bicho");
            this.tipoElementos.Add("Veneno");
            this.tipoElementos.Add("Hada");
            this.tipoElementos.Add("Dragón");
            this.tipoElementos.Add("Volador");
            this.tipoElementos.Add("Normal");
            this.tipoElementos.Add("Ninguno");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validacion.ValidaTextoVacio(txtNumeroPokedex.Text) || Validacion.ValidaTextoVacio(txtNombre.Text) || Validacion.ValidaTextoVacio(txtDescripcion.Text) ||
                    Validacion.ValidaTextoVacio(txtUrlImagen.Text) || ddlTipo.Items.Count == 0 || ddlResistencia.Items.Count == 0 || ddlDebilidad.Items.Count == 0) 
                {
                    lblMensaje.Visible = true;
                    throw new EmptyParametersException("¡Alguno de los campos esta vacio, debe ingesar datos en todos los campos!");
                }
                else
                {
                    lblMensaje.Visible = false;
                }

                Pokemon pokemon = new Pokemon(Convert.ToInt32(txtNumeroPokedex.Text), txtNombre.Text, txtDescripcion.Text, txtUrlImagen.Text, ddlTipo.SelectedValue, ddlResistencia.SelectedValue, ddlDebilidad.SelectedValue, 0); 
                if (!(Pokemon.VerificarExistePokemon(PokemonDAO.LeerPokemones(), pokemon.NumeroPokedex)))
                {
                    if (PokemonDAO.AgregarPokemon(pokemon))
                    {
                        Session.Add("Complete", "Se agrego al pokemon correctamente en la pokedex");
                        Response.Redirect("ListaPokemons.aspx?id=" + 1);
                    }
                }
                else
                {
                    lblMensaje.Visible = true;
                    throw new ExistingDataOnDB("¡No se pudo cargar el Pokemon con un Numero de Pokedex ya existente!");
                }
            }
            catch (EmptyParametersException ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (SqlExceptionDuplicateUserDB ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message;
            }
            catch (ExistingDataOnDB ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (DataBasesException ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validacion.ValidaTextoVacio(txtNumeroPokedex.Text) || Validacion.ValidaTextoVacio(txtNombre.Text) || Validacion.ValidaTextoVacio(txtDescripcion.Text) ||
                    Validacion.ValidaTextoVacio(txtUrlImagen.Text) || ddlTipo.Items.Count == 0 || ddlResistencia.Items.Count == 0 || ddlDebilidad.Items.Count == 0)
                {
                    lblMensaje.Visible = true;
                    throw new EmptyParametersException("¡Alguno de los campos esta vacio, debe ingesar datos en todos los campos!");
                }
                else
                {
                    lblMensaje.Visible = false;
                }

                Pokemon pokemon = new Pokemon(Convert.ToInt32(txtNumeroPokedex.Text), txtNombre.Text, txtDescripcion.Text, txtUrlImagen.Text, ddlTipo.SelectedValue, ddlResistencia.SelectedValue, ddlDebilidad.SelectedValue, idPokemon);
                if (PokemonDAO.ModificarPokemon(pokemon))
                {
                    Session.Add("Complete", "Se modifico correctamente al pokemon");
                    Response.Redirect("ListaPokemons.aspx?id=" + 2);
                }
                else
                {
                    lblMensaje.Visible = true;
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
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // reingresar Numero Pokedex para poder eliminarlo de la DB
            txtNumeroPokedex.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtUrlImagen.Text = "";
            ddlTipo.SelectedValue = "";
            ddlResistencia.SelectedValue = "";
            ddlDebilidad.SelectedValue = "";

            txtNumeroPokedex.Enabled = true;
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = false;
            txtUrlImagen.Enabled = false;
            ddlTipo.Enabled = false;
            ddlResistencia.Enabled = false;
            ddlDebilidad.Enabled = false;

            lblMensaje.Text = "Ingrese unicamente Numero de Pokedex y Nombre para confirmar la baja del Pokemon";
            lblMensaje.Visible = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnConirmarBaja.Visible = true;
        }

        protected void btnConirmarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                //ingresar nuevamente para confirmar la baja del pokemon
                if (Validacion.ValidaTextoVacio(txtNumeroPokedex.Text) || Validacion.ValidaTextoVacio(txtNombre.Text))
                {
                    lblMensaje.Visible = true;
                    throw new EmptyParametersException("¡Alguno de los campos esta vacio, debe ingesar datos en todos los campos!");
                }
                else
                {
                    lblMensaje.Visible = false;
                }

                if (Pokemon.VerificarExistePokemon(PokemonDAO.LeerPokemones(), Convert.ToInt32(txtNumeroPokedex.Text)))
                {
                    if (PokemonDAO.Eliminar(idPokemon, Convert.ToInt32(txtNumeroPokedex.Text), txtNombre.Text))
                    {
                        Session.Add("Complete", "Se dio de baja correctamente al pokemon");
                        Response.Redirect("ListaPokemons.aspx?id=" + 0);
                    }
                }
                else
                {
                    lblMensaje.Visible = true;
                    throw new ExistingDataOnDB("¡No existe este Pokemon en la DB!");
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
            catch (ExistingDataOnDB ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtUrlImagen.Text;
        }
    }
}