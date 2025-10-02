using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataManager;

namespace servicios
{
    public class gestionClientes
    {
        public cliente buscarPorDocumento(string documento)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @documento");
                datos.setearParametro("@documento", documento);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente cli = new cliente();
                    cli.Id = (int)datos.Lector["Id"];
                    cli.Documento = (string)datos.Lector["Documento"];
                    cli.Nombre = (string)datos.Lector["Nombre"];
                    cli.Apellido = (string)datos.Lector["Apellido"];
                    cli.Email = (string)datos.Lector["Email"];
                    cli.Direccion = (string)datos.Lector["Direccion"];
                    cli.Ciudad = (string)datos.Lector["Ciudad"];
                    cli.CP = (int)datos.Lector["CP"];
                    
                    return cli;
                }
                return null;
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

        public int agregarCliente(cliente cli)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) OUTPUT INSERTED.Id VALUES (@documento, @nombre, @apellido, @email, @direccion, @ciudad, @cp)");
                datos.setearParametro("@documento", cli.Documento);
                datos.setearParametro("@nombre", cli.Nombre);
                datos.setearParametro("@apellido", cli.Apellido);
                datos.setearParametro("@email", cli.Email);
                datos.setearParametro("@direccion", cli.Direccion);
                datos.setearParametro("@ciudad", cli.Ciudad);
                datos.setearParametro("@cp", cli.CP);

                int id = Convert.ToInt32(datos.ejecutarScalar());
                cli.Id = id;
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void actualizarCliente(cliente cli)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Clientes SET Documento = @documento, Nombre = @nombre, Apellido = @apellido, Email = @email, Direccion = @direccion, Ciudad = @ciudad, CP = @cp WHERE Id = @id");
                datos.setearParametro("@id", cli.Id);
                datos.setearParametro("@documento", cli.Documento);
                datos.setearParametro("@nombre", cli.Nombre);
                datos.setearParametro("@apellido", cli.Apellido);
                datos.setearParametro("@email", cli.Email);
                datos.setearParametro("@direccion", cli.Direccion);
                datos.setearParametro("@ciudad", cli.Ciudad);
                datos.setearParametro("@cp", cli.CP);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public cliente procesarCliente(cliente cli)
        {
            // Primero validar los datos
            string mensajeValidacion = cli.ValidarDatos();
            if (!string.IsNullOrEmpty(mensajeValidacion))
            {
                throw new Exception(mensajeValidacion);
            }

            // Buscar si existe cliente con ese documento
            cliente clienteExistente = buscarPorDocumento(cli.Documento);
            
            if (clienteExistente != null)
            {
                // Cliente existe, actualizar datos
                cli.Id = clienteExistente.Id;
                actualizarCliente(cli);
                return cli;
            }
            else
            {
                // Cliente no existe, agregar nuevo
                int nuevoId = agregarCliente(cli);
                cli.Id = nuevoId;
                return cli;
            }
        }
    }
}