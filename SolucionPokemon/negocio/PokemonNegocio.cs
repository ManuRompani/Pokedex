using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using negocio;
using System.CodeDom;

namespace negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon > lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, E.Descripcion as Tipo, UrlImagen, D.Descripcion Debilidad,P.IdTipo, P.IdDebilidad, P.Id from POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.Id = P.IdTipo and D.Id = P.IdDebilidad and P.Activo = 1";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon pokemonAux = new Pokemon();
                    pokemonAux.Id = (int)lector["Id"];
                    pokemonAux.Numero = (int)lector["Numero"];
                    pokemonAux.Nombre = (string)lector["Nombre"];
                    pokemonAux.Descripcion = (string)lector["Descripcion"];
                    if (!(lector["UrlImagen"] is DBNull))
                    {
                        pokemonAux.UrlImagen = (string)lector["UrlImagen"];
                    }
                    pokemonAux.Tipo = new Elemento();
                    pokemonAux.Tipo.Id = (int)lector["IdTipo"];
                    pokemonAux.Tipo.Descripcion = (string)lector["Tipo"];
                    pokemonAux.Debilidad = new Elemento();
                    pokemonAux.Debilidad.Id = (int)lector["IdDebilidad"];
                    pokemonAux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(pokemonAux);
                }

                conexion.Close(); 
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void agregar(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen)values(" + nuevo.Numero + ",'" + nuevo.Nombre + "','" + nuevo.Descripcion + "',1, @idTipo ,@idDebilidad, @UrlImagen)");
                datos.setearParametros("@idTipo", nuevo.Tipo.Id);
                datos.setearParametros("@idDebilidad", nuevo.Debilidad.Id);
                datos.setearParametros("@UrlImagen", nuevo.UrlImagen);
                datos.insertarDatos();
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Pokemon pokemon)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @descripcion, UrlImagen = @UrlImagen, IdTipo = @IdTipo, IdDebilidad = @IdDebilidad Where Id = @Id");
                datos.setearParametros("@numero", pokemon.Numero);
                datos.setearParametros("@nombre", pokemon.Nombre);
                datos.setearParametros("@descripcion", pokemon.Descripcion);
                datos.setearParametros("@UrlImagen", pokemon.UrlImagen);
                datos.setearParametros("@IdTipo", pokemon.Tipo.Id);
                datos.setearParametros("@IdDebilidad", pokemon.Debilidad.Id);
                datos.setearParametros("@Id",pokemon.Id);

                datos.ejeccutarLectura();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion();}
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from POKEMONS where id = @id");
                datos.setearParametros("@id", id);
                datos.ejeccutarLectura();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public void darBaja(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update POKEMONS set Activo = 0 where Id = @id");
                datos.setearParametros("@id", id);
                datos.ejeccutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  List<Pokemon> filtrado(string criterio, string campo, string filtro)
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = ("Select Numero, Nombre, P.Descripcion, E.Descripcion as Tipo, UrlImagen, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id from POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.Id = P.IdTipo and D.Id = P.IdDebilidad and P.Activo = 1 and ");

                if(campo == "Numero")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;

                        case "Igual a":
                            consulta += "Numero = " + filtro;
                            break;

                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%'";
                            break;

                        case "Contiene":
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;

                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejeccutarLectura();

                while (datos.Lector.Read())
                {
                    Pokemon pokemonAux = new Pokemon();
                    pokemonAux.Id = (int)datos.Lector["Id"];
                    pokemonAux.Numero = (int)datos.Lector["Numero"];
                    pokemonAux.Nombre = (string)datos.Lector["Nombre"];
                    pokemonAux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                    {
                        pokemonAux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    }
                    pokemonAux.Tipo = new Elemento();
                    pokemonAux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    pokemonAux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    pokemonAux.Debilidad = new Elemento();
                    pokemonAux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    pokemonAux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    lista.Add(pokemonAux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
