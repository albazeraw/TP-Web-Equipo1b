using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace dataManager
{
    public class accesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public accesoDatos()
        {
            conexion = new SqlConnection("server=(local)\\SQLEXPRESS; database=PROMOS_DB; integrated security=true");
            comando = new SqlCommand();
        }
        public void setearConsulta(string consulta)
        {
            comando.Parameters.Clear();//limpia parametros de consultas anteriores
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void setearProcedimiento(string sp) {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }
        public List<articulos> listarConSp()
        {
            List<articulos> lista = new List<articulos>();
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearProcedimiento("ListarArt");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    articulos aux = new articulos();
                    aux.idArticulo = (int)(datos.Lector["idArticulo"]);
                    aux.codigo = (string)(datos.Lector["codigo"]);
                    aux.nombre = (string)(datos.Lector["nombre"]);
                    aux.descripcion = (string)(datos.Lector["descripcion"]);
                    aux.precio = (decimal)(datos.Lector["precio"]);
                    aux.marca = new marcas();
                    aux.marca.idMarca = (int)(datos.Lector["idMarca"]);
                    aux.marca.descripcion = (string)(datos.Lector["descMarca"]);
                    aux.categoria = new categorias();
                    aux.categoria.idCategoria = (int)(datos.Lector["idCategoria"]);
                    aux.categoria.descripcion = (string)(datos.Lector["descCategoria"]);
                    if (datos.Lector["imagenUrl"] is DBNull)
                    {
                        aux.imagenUrl = null;
                    }
                    else
                    {
                        aux.imagenUrl = (string)datos.Lector["imagenUrl"];

                    }
                    lista.Add(aux);

                }
                return lista;
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

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor ?? DBNull.Value);
        }
        public void ejecutarLectura() {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        //ejecuta insert update o delete
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        //ejecuta consulta que devuelve un unico valor
        public object ejecutarScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return comando.ExecuteScalar();//devuelve el primer valor de la primera fila
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            
            conexion.Close();
        }

       


      
    }
}
