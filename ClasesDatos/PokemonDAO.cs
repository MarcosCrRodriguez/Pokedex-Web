using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using ClasesDatos;
using ExcepcionesPropias;

namespace ClasesDatos
{
    public class PokemonDAO
    {
        private static string connectionString;
        private static SqlCommand command;
        private static SqlConnection connection;

        static PokemonDAO()
        {
            connectionString = @"Data Source=.;Initial Catalog=POKEDEX_DB;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        public static bool AgregarPokemon(Pokemon pokemon)
        {
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"Insert INTO POKEMONS (NumeroPokedex, Nombre, Descripcion, UrlImagen, Tipo, Resistencia, Debilidad) " +
                    $"VALUES (@NumeroPokedex, @Nombre, @Descripcion, @UrlImagen, @Tipo, @Resistencia, @Debilidad)";
                command.Parameters.AddWithValue("@NumeroPokedex", pokemon.NumeroPokedex);
                command.Parameters.AddWithValue("@Nombre", pokemon.Nombre);
                command.Parameters.AddWithValue("@Descripcion", pokemon.Descripcion);
                command.Parameters.AddWithValue("@UrlImagen", pokemon.UrlImagen);
                command.Parameters.AddWithValue("@Tipo", pokemon.Tipo);
                command.Parameters.AddWithValue("@Resistencia", pokemon.Resistencia);
                command.Parameters.AddWithValue("@Debilidad", pokemon.Debilidad);
                int rows = command.ExecuteNonQuery();
                rtn = true;
            }
            catch (SqlException ex)
            {
                throw new SqlExceptionDuplicateUserDB("No se pudo cargar el Pokemon con un Numero de Pokedex ya existente", ex);
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Error a la hora de trabajar con la DB", ex);
            }
            finally
            {
                connection.Close();
            }
            return rtn;
        }

        public static Pokemon LeerPorID(int id)
        {
            Pokemon pokemon = null;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM POKEMONS WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pokemon = new Pokemon(Convert.ToInt32(reader["NumeroPokedex"]),
                            reader["Nombre"].ToString(),
                            reader["Descripcion"].ToString(),
                            reader["UrlImagen"].ToString(),
                            reader["Tipo"].ToString(),
                            reader["Resistencia"].ToString(),
                            reader["Debilidad"].ToString(),
                            Convert.ToInt32(reader["ID"])
                            );
                    }
                }
                return pokemon;
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Hubo problemas con la carga de la lista desde la BD", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public static Pokemon LeerPorNumeroPokedex(int numeroPokedex)
        {
            Pokemon pokemon = null;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM POKEMONS WHERE NumeroPokedex = @NumeroPokedex";
                command.Parameters.AddWithValue("@NumeroPokedex", numeroPokedex);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pokemon = new Pokemon(Convert.ToInt32(reader["NumeroPokedex"]),
                            reader["Nombre"].ToString(),
                            reader["Descripcion"].ToString(),
                            reader["UrlImagen"].ToString(),
                            reader["Tipo"].ToString(),
                            reader["Resistencia"].ToString(),
                            reader["Debilidad"].ToString(),
                            Convert.ToInt32(reader["ID"])
                            );
                    }
                }
                return pokemon;
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Hubo problemas con la carga de la lista desde la BD", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<Pokemon> LeerPokemonesFiltro(string tipo, string debilidad)
        {
            List<Pokemon> listaPokemones = new List<Pokemon>();
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT NumeroPokedex, Nombre, Descripcion, UrlImagen, Tipo, Resistencia, Debilidad, ID FROM POKEMONS WHERE Tipo = @Tipo AND Debilidad = @Debilidad";
                command.Parameters.AddWithValue("@Tipo", tipo);
                command.Parameters.AddWithValue("@Debilidad", debilidad);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaPokemones.Add(new Pokemon(Convert.ToInt32(reader["NumeroPokedex"]),
                            reader["Nombre"].ToString(),
                            reader["Descripcion"].ToString(),
                            reader["UrlImagen"].ToString(),
                            reader["Tipo"].ToString(),
                            reader["Resistencia"].ToString(),
                            reader["Debilidad"].ToString(),
                            Convert.ToInt32(reader["ID"]))
                            );
                    }
                }
                return listaPokemones;
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Hubo problemas con la carga de la lista desde la BD", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<Pokemon> LeerPokemones()
        {
            List<Pokemon> listaPokemones = new List<Pokemon>();
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM POKEMONS";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaPokemones.Add(new Pokemon(Convert.ToInt32(reader["NumeroPokedex"]),
                            reader["Nombre"].ToString(),
                            reader["Descripcion"].ToString(),
                            reader["UrlImagen"].ToString(),
                            reader["Tipo"].ToString(),
                            reader["Resistencia"].ToString(),
                            reader["Debilidad"].ToString(),
                            Convert.ToInt32(reader["ID"]))
                            );
                    }
                }
                return listaPokemones;
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Hubo un problema al cargar la \nlista desde la BD", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool ModificarPokemon(Pokemon pokemon)
        {
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE POKEMONS SET NumeroPokedex = @NumeroPokedex, Nombre = @Nombre, Descripcion = @Descripcion, UrlImagen = @UrlImagen, Tipo = @Tipo, Resistencia = @Resistencia, Debilidad = @Debilidad " +
                    $"WHERE ID = @ID";
                command.Parameters.AddWithValue("@NumeroPokedex", pokemon.NumeroPokedex);
                command.Parameters.AddWithValue("@Nombre", pokemon.Nombre);
                command.Parameters.AddWithValue("@Descripcion", pokemon.Descripcion);
                command.Parameters.AddWithValue("@UrlImagen", pokemon.UrlImagen);
                command.Parameters.AddWithValue("@Tipo", pokemon.Tipo);
                command.Parameters.AddWithValue("@Resistencia", pokemon.Resistencia);
                command.Parameters.AddWithValue("@Debilidad", pokemon.Debilidad);
                command.Parameters.AddWithValue("@ID", pokemon.ID);
                if (command.ExecuteNonQuery() == 1)
                {
                    rtn = true;
                }
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Error a la hora de trabajar con la DB", ex);
            }
            finally
            {
                connection.Close();
            }
            return rtn;
        }

        public static bool Eliminar(int id, int numeroPokedex, string nombre)
        {
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"DELETE FROM POKEMONS WHERE ID = @ID AND NumeroPokedex = @NumeroPokedex AND Nombre = @Nombre";
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@NumeroPokedex", numeroPokedex);
                command.Parameters.AddWithValue("@Nombre", nombre);
                if (command.ExecuteNonQuery() == 1)
                {
                    rtn = true;
                }
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Error a la hora de trabajar con la DB", ex);
            }
            finally
            {
                connection.Close();
            }
            return rtn;
        }
    }

}
