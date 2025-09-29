using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataManager;
using System.Linq.Expressions;

namespace servicios
{
    public class gestionCategoria
    {
        public List<categorias> listar()
        {
            List<categorias> lista = new List<categorias>();
            accesoDatos datos = new accesoDatos();

            try
            {
                datos.setearConsulta("select distinct min(Id) as Id, Descripcion from CATEGORIAS group by Descripcion order by Descripcion;");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    categorias aux = new categorias();
                    aux.idCategoria = (int)datos.Lector["Id"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);

                }
                return lista;
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
