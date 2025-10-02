using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataManager;

namespace servicios
{
    public class gestionVouchers
    {
        public bool validarCodigo(string codigoVoucher)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @codigo AND IdCliente IS NULL");
                datos.setearParametro("@codigo", codigoVoucher);
                
                int count = Convert.ToInt32(datos.ejecutarScalar());
                return count > 0;
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

        public vouchers obtenerVoucher(string codigoVoucher)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE CodigoVoucher = @codigo");
                datos.setearParametro("@codigo", codigoVoucher);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    vouchers voucher = new vouchers();
                    voucher.codigoArticulo = (string)datos.Lector["CodigoVoucher"];
                    voucher.idCliente = datos.Lector["IdCliente"] != DBNull.Value ? (int)datos.Lector["IdCliente"] : 0;
                    voucher.fechaCanje = datos.Lector["FechaCanje"] != DBNull.Value ? (DateTime)datos.Lector["FechaCanje"] : DateTime.MinValue;
                    voucher.idArticulo = datos.Lector["IdArticulo"] != DBNull.Value ? (int)datos.Lector["IdArticulo"] : 0;
                    
                    return voucher;
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

        public void canjearVoucher(string codigoVoucher, int idCliente, int idArticulo)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Vouchers SET IdCliente = @idCliente, FechaCanje = @fechaCanje, IdArticulo = @idArticulo WHERE CodigoVoucher = @codigo AND IdCliente IS NULL");
                datos.setearParametro("@idCliente", idCliente);
                datos.setearParametro("@fechaCanje", DateTime.Now);
                datos.setearParametro("@idArticulo", idArticulo);
                datos.setearParametro("@codigo", codigoVoucher);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}