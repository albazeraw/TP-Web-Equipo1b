using dataManager;
using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace servicios
{
    public class gestionArticulos
    {
        public List<articulos> listar()
        {
            List<articulos> lista = new List<articulos>();
            accesoDatos datos = new accesoDatos();
            try
            {
                //datos.setearConsulta("SELECT A.id AS idArticulo, A.codigo, A.nombre, A.descripcion, A.precio, M.id AS idMarca, M.Descripcion AS descMarca, C.id AS idCategoria, C.Descripcion AS descCategoria, I.ImagenUrl FROM ARTICULOS A INNER JOIN MARCAS M ON A.idMarca = M.id INNER JOIN CATEGORIAS C ON A.idCategoria = C.id LEFT JOIN IMAGENES I ON I.IdArticulo = A.id;");
                datos.setearConsulta(@"
                SELECT A.Id AS idArticulo, A.Codigo, A.Nombre, A.Descripcion, A.Precio,
                        M.Id AS idMarca, M.Descripcion AS descMarca,
                        C.Id AS idCategoria, C.Descripcion AS descCategoria,
                        I.ImagenUrl AS imagenUrl
                FROM ARTICULOS A
                INNER JOIN MARCAS M ON A.IdMarca = M.Id
                INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id
                LEFT JOIN IMAGENES I 
                    ON I.IdArticulo = A.Id 
                    AND I.Id = (SELECT MIN(Id) FROM IMAGENES WHERE IdArticulo = A.Id)
                ORDER BY A.Nombre;");

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


        public void agregarArticulo(articulos art)
        {
            accesoDatos datos = new accesoDatos();
            try
            {

                datos.setearConsulta(@"insert into articulos (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) 
            VALUES (@codigo, @nombre, @descripcion, @precio, @idMarca, @idCategoria);
            SELECT SCOPE_IDENTITY();");

                datos.setearParametro("@codigo", art.codigo);
                datos.setearParametro("@nombre", art.nombre);
                datos.setearParametro("@descripcion", art.descripcion);
                datos.setearParametro("@precio", art.precio);
                datos.setearParametro("@idMarca", art.marca.idMarca);
                datos.setearParametro("@idCategoria", art.categoria.idCategoria);

                int idArt = Convert.ToInt32(datos.ejecutarScalar());//devuelve el nuevo id

                //si el usuario carga una imagen la agregamos a la tabla
                if (!string.IsNullOrEmpty(art.imagenUrl))
                {
                    datos.setearConsulta("insert into imagenes(IdArticulo,ImagenUrl) values (@idArticulo,@imagenUrl)");
                    datos.setearParametro("@idArticulo", idArt);
                    datos.setearParametro("@imagenUrl", art.imagenUrl);
                    datos.ejecutarAccion();
                }
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

        public void modificar(articulos art) //recibo el objeto que quiero modificar
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS " +
            "SET Codigo = @codigo, " +
            "Nombre = @nombre, " +
            "Descripcion = @descripcion, " +
            "IdMarca = @idMarca, " +
            "IdCategoria = @idCategoria, " +
            "Precio = @precio " +
            "WHERE Id = @id"); //update

                datos.setearParametro("Codigo", art.codigo);
                datos.setearParametro("Nombre", art.nombre);
                datos.setearParametro("Descripcion", art.descripcion);
                datos.setearParametro("IdMarca", art.marca.idMarca);
                datos.setearParametro("IdCategoria", art.categoria.idCategoria);
                datos.setearParametro("Precio", art.precio);
                datos.setearParametro("id", art.idArticulo);

                datos.ejecutarAccion();
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

        public void eliminar(int id) //recibo el id del objeto que quiero borrar
        {
            try
            {
                accesoDatos datos = new accesoDatos();
                datos.setearConsulta("delete from articulos where Id = @id"); //-> consulta para eliminar, @id es una variable
                datos.setearParametro("@id", id); //le asigno el valor que paso por parametro
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

