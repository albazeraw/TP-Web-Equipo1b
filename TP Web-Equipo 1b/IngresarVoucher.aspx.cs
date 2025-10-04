using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using servicios;

namespace TP_Web_Equipo_1b
{
    public partial class IngresarVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string codigoVoucher = TxtCodigoVoucher.Text.Trim();
            
            // Validaci�n b�sica - verificar que no est� vac�o
            if (string.IsNullOrEmpty(codigoVoucher))
            {
                MostrarError("Por favor, ingresa un c�digo de voucher.");
                return;
            }

            // Validar el c�digo en la base de datos
            gestionVouchers gestorVouchers = new gestionVouchers();
            try
            {
                if (gestorVouchers.validarCodigo(codigoVoucher))
                {
                    // C�digo v�lido - guardamos en sesi�n y redirigimos
                    Session["CodigoVoucher"] = codigoVoucher;
                    Response.Redirect("ElegirPremio.aspx");
                }
                else
                {
                    MostrarError("El c�digo de voucher ingresado es incorrecto o ya ha sido utilizado.");
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al validar el c�digo de voucher: {ex.Message}. Por favor, int�ntalo nuevamente.");
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            // Redigimos a la p�gina de inicio nueva que creamos para dar bienvenida 
            Response.Redirect("Default.aspx");
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
            btnInicio.Visible = true;
        }
    }
}