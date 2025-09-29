using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataManager;

namespace servicios
{
    public class gestionImagenes
    {
        public List<imagen> listarPorArticulo(int idArticulo)
        {
            var lista = new List<imagen>();
            var datos = new accesoDatos();
            try
            {
                datos.setearConsulta(
                    "SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo=@id ORDER BY Id");
                datos.setearParametro("@id", idArticulo);
                datos.ejecutarLectura();

                var lector = datos.Lector;
                while (lector.Read())
                {
                    lista.Add(new imagen
                    {
                        Id = (int)lector["Id"],
                        IdArticulo = (int)lector["IdArticulo"],
                        Url = lector["ImagenUrl"] as string
                    });
                }
                return lista;
            }
            finally { datos.cerrarConexion(); }
        }

        public void agregar(int idArticulo, string url)
        {
            var datos = new accesoDatos();
            datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@id,@url)");
            datos.setearParametro("@id", idArticulo);
            datos.setearParametro("@url", url);
            datos.ejecutarAccion();
        }

        public void eliminar(int idImagen)
        {
            var datos = new accesoDatos();
            datos.setearConsulta("DELETE FROM IMAGENES WHERE Id=@id");
            datos.setearParametro("@id", idImagen);
            datos.ejecutarAccion();
        }
    }
}

