using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using servicios;

namespace TP_Web_Equipo_1b
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string codigoVoucher = TxtCodigoVoucher.Text.Trim();
            
            // Validación básica - verificar que no esté vacío
            if (string.IsNullOrEmpty(codigoVoucher))
            {
                MostrarError("Por favor, ingresa un código de voucher.");
                return;
            }

            // Validar el código en la base de datos
            gestionVouchers gestorVouchers = new gestionVouchers();
            try
            {
                if (gestorVouchers.validarCodigo(codigoVoucher))
                {
                    // Código válido - guardamos en sesión y redirigimos
                    Session["CodigoVoucher"] = codigoVoucher;
                    Response.Redirect("ElegirPremio.aspx");
                }
                else
                {
                    MostrarError("El código de voucher ingresado es incorrecto o ya ha sido utilizado.");
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al validar el código de voucher: {ex.Message}. Por favor, inténtalo nuevamente.");
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            // Limpiar controles y ocultar mensaje de error
            TxtCodigoVoucher.Text = "";
            lblError.Visible = false;
            btnInicio.Visible = false;
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
            btnInicio.Visible = true;
        }
    }
}