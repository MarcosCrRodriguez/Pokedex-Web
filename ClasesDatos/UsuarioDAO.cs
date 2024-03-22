using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesDatos
{
    public class UsuarioDAO
    {
        private static string connectionString;
        private static SqlCommand command;
        private static SqlConnection connection;

        static UsuarioDAO()
        {
            connectionString = @"Data Source=.;Initial Catalog=POKEDEX_DB;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        public static bool AgregarUsuario(Usuario usuario)
        {
            bool rtn = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"Insert INTO USUARIOS (Usuario, Pass, TipoUsuario) " +
                    $"VALUES (@Usuario, @Pass, @TipoUsuario)";
                command.Parameters.AddWithValue("@Usuario", usuario.User);
                command.Parameters.AddWithValue("@Pass", usuario.Pass);
                command.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUser);
                int rows = command.ExecuteNonQuery();
                rtn = true;
            }
            //catch (SqlException ex)
            //{
            //    throw new SqlExceptionDuplicateUserDB("No se pudo cargar el Pokemon con un Numero de Pokedex ya existente", ex);
            //}
            //catch (Exception ex)
            //{
            //    throw new DataBasesException("Error a la hora de trabajar con la DB", ex);
            //}
            catch (Exception ex)
            {
                throw new Exception("Error a la hora de trabajar con la DB", ex);
            }
            finally
            {
                connection.Close();
            }
            return rtn;
        }

        public static List<Usuario> LeerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM USUARIOS";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaUsuarios.Add(new Usuario(Convert.ToInt32(reader["ID"]),
                            reader["Usuario"].ToString(),
                            reader["Pass"].ToString(),
                            reader["TipoUsuario"].ToString())
                            );
                    }
                }
                return listaUsuarios;
            }
            //catch (Exception ex)
            //{
            //    throw new DataBasesException("Hubo problemas con la carga de la \nlista desde la BD", ex); 
            //}
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool Loguear(Usuario usuario)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT ID, TipoUsuario FROM USUARIOS WHERE Usuario = @Usuario AND Pass = @Pass";
                command.Parameters.AddWithValue("@Usuario", usuario.User);
                command.Parameters.AddWithValue("@Pass", usuario.Pass);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario.ID = Convert.ToInt32(reader["ID"]);
                        usuario.TipoUser = reader["TipoUsuario"].ToString();

                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static Usuario LeerPorID(int id)
        {
            Usuario usuario = null;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT ID, Usuario, Pass, TipoUsuario FROM USUARIOS WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new Usuario(Convert.ToInt32(reader["ID"]),
                        reader["Usuario"].ToString(),
                        reader["Pass"].ToString(),
                        reader["TipoUsuario"].ToString()
                        );
                    }
                }
                return usuario;
            }
            //catch (exception ex)
            //{
            //    throw new databasesexception("error a la hora de trabajar con la db", ex);
            //}
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
