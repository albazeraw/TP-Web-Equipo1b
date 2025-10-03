using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using servicios;

namespace TP_Web_Equipo_1b
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<articulos> listaArticulos { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Verificar que exista un código de voucher válido en la sesión
                if (Session["CodigoVoucher"] == null)
                {
                    Response.Redirect("Default.aspx");
                    return;
                }

                if (!IsPostBack)
                {
                    lblCodigoVoucher.Text = $"Código: {Session["CodigoVoucher"].ToString()}";
                }
                //cargar la lista articulos desde la db
                gestionArticulos gestor = new gestionArticulos();
                listaArticulos = gestor.listar();

                if (listaArticulos == null || listaArticulos.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alertError", "alert('No hay premios disponibles en este momento.'); window.location='Default.aspx';", true);
                }
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(),"alertError", $"alert('Error al cargar los premios: {ex.Message}'); window.location='Default.aspx';", true);
            }
        }
        protected void btnSelecconar_Click(object sender, EventArgs e)
        {
            try
            {
                var boton = (Button)sender;
                int idArticulo;
                if (int.TryParse(boton.CommandArgument, out idArticulo))
                {
                    Session["ArticuloSeleccionado"] = idArticulo;
                    Response.Redirect("IngresoDatos.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(),"alertError", "alert('Ocurrió un error al seleccionar el premio. Intente nuevamente.');", true);

                }
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alertError", $"alert('Error al procesar la selección: {ex.Message}');", true);
            }
        }
    }
}