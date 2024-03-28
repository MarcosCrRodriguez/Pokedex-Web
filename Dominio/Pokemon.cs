using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pokemon
    {
        private int numeroPokedex;
        private string nombre;
        private string descripcion;
        private string urlImagen;
        private string tipo;
        private string subTtipo;
        private string resistencia;
        private string debilidad;
        private int id;

        public Pokemon(int numeroPokedex, string nombre, string descripcion, string urlImagen, string tipo, string subTtipo, string resistencia, string debilidad, int id)
        {
            this.numeroPokedex = numeroPokedex;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.urlImagen = urlImagen;
            this.tipo = tipo;
            this.subTtipo = subTtipo;
            this.resistencia = resistencia;
            this.debilidad = debilidad;
            this.id = id;
        }

        #region Propiedades
        public int NumeroPokedex
        {
            get { return this.numeroPokedex; }
            set { this.numeroPokedex = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }
        public string UrlImagen
        {
            get { return this.urlImagen; }
            set { this.urlImagen = value; }
        }
        public string Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }
        public string SubTipo
        {
            get { return this.subTtipo; }
            set { this.subTtipo = value; }
        }
        public string Resistencia {
            get { return this.resistencia; }
            set { this.resistencia = value; }
        }
        public string Debilidad {
            get { return this.debilidad; }
            set { this.debilidad = value; }
        }
        public int ID
        {
            get { return this.id; }
        }
        #endregion

        public static bool VerificarExistePokemon(List<Pokemon> listaPokemons, int numeroPokedex)
        {
            if (listaPokemons.Count > 0 && listaPokemons != null)
            {
                foreach (var poke in listaPokemons)
                {
                    if (poke.NumeroPokedex == numeroPokedex)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
