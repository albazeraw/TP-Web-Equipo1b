using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataManager;
using dominio;

namespace servicios
{
    public class gestionMarcas
    {
        public List<marcas> listar() {
            List<marcas> lista = new List<marcas>();
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("select distinct min(Id) as Id, Descripcion from MARCAS group by Descripcion order by Descripcion;");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    marcas aux = new marcas();
                    aux.idMarca = (int)datos.Lector["id"];
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
