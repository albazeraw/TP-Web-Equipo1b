using System;
using System.Collections.Generic;
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

            gestionArticulos gestor = new gestionArticulos();
            listaArticulos = gestor.listar();
        }

        protected void btnMouse_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresoDatos.aspx");
        }

        protected void btnSelecconar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresoDatos.aspx");
        }
    }
}