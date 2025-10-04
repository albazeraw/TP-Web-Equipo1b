using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Web_Equipo_1b
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Página de bienvenida - no necesita lógica especial
        }

        protected void btnCanjearVoucher_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresarVoucher.aspx");
        }
    }
}