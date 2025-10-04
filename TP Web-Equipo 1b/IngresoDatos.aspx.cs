using servicios;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Web_Equipo_1b
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar que exista un código de voucher válido en la sesión
            if (Session["CodigoVoucher"] == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }

            // Capturar artículo seleccionado desde query string y guardarlo en sesión
            if (!IsPostBack && Request.QueryString["idArticulo"] != null)
            {
                int idArticulo;
                if (int.TryParse(Request.QueryString["idArticulo"], out idArticulo))
                {
                    Session["ArticuloSeleccionado"] = idArticulo;
                }
            }
        }

        protected void btnBuscarDni_Click(object sender, EventArgs e)
        {
            try
            {
                string documento = txtDni.Text.Trim();
                
                if (string.IsNullOrEmpty(documento))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, ingresa un DNI para buscar.');", true);
                    return;
                }

                gestionClientes gestorClientes = new gestionClientes();
                cliente clienteEncontrado = gestorClientes.buscarPorDocumento(documento);

                if (clienteEncontrado != null)
                {
                    // Autocompletar campos con los datos encontrados
                    txtNombre.Text = clienteEncontrado.Nombre;
                    txtApellido.Text = clienteEncontrado.Apellido;
                    TxtEmail.Text = clienteEncontrado.Email;
                    txtDireccion.Text = clienteEncontrado.Direccion;
                    txtCiudad.Text = clienteEncontrado.Ciudad;
                    txtCodigoPostal.Text = clienteEncontrado.CP.ToString();
                    
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cliente encontrado. Los datos han sido autocompletados.');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se encontró ningún cliente con ese DNI. Puedes completar los datos manualmente.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al buscar cliente: {ex.Message}');", true);
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los términos estén aceptados
                if (!chkboxTerminos.Checked)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Debes aceptar los términos y condiciones para continuar.');", true);
                    return;
                }

                // Crear objeto cliente con los datos del formulario
                cliente nuevoCliente = new cliente
                {
                    Documento = txtDni.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Email = TxtEmail.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Ciudad = txtCiudad.Text.Trim()
                };

                // Validar código postal
                int codigoPostal;
                if (!int.TryParse(txtCodigoPostal.Text.Trim(), out codigoPostal) || codigoPostal <= 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El código postal debe ser un número válido mayor a 0.');", true);
                    return;
                }
                nuevoCliente.CP = codigoPostal;

                // Validar datos del cliente
                string mensajeValidacion = nuevoCliente.ValidarDatos();
                if (!string.IsNullOrEmpty(mensajeValidacion))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{mensajeValidacion}');", true);
                    return;
                }

                // Obtener código de voucher de la sesión
                string codigoVoucher = Session["CodigoVoucher"].ToString();
                
                // Validar que el voucher siga siendo válido
                gestionVouchers gestorVouchers = new gestionVouchers();
                if (!gestorVouchers.validarCodigo(codigoVoucher))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El código de voucher ya no es válido o ha sido utilizado.');", true);
                    return;
                }

                // Procesar cliente (agregar o actualizar)
                gestionClientes gestorClientes = new gestionClientes();
                cliente clienteProcesado = gestorClientes.procesarCliente(nuevoCliente);

                // Obtener artículo seleccionado de la sesión
                // Si no existe, usar artículo por defecto (ID = 1)
                int idArticuloSeleccionado = Session["ArticuloSeleccionado"] != null ? 
                    Convert.ToInt32(Session["ArticuloSeleccionado"]) : 1;

                // Canjear voucher
                gestorVouchers.canjearVoucher(codigoVoucher, clienteProcesado.Id, idArticuloSeleccionado);

                // Enviar email de confirmación (mantener la lógica existente)
                emailServicio mail = new emailServicio();
                mail.armarCorreo(clienteProcesado.Email, clienteProcesado.Nombre);
                mail.enviarEmail();

                // Deshabilitar formulario tras registro exitoso
                DeshabilitarFormulario();

                // Limpiar sesiones
                Session.Remove("CodigoVoucher");
                Session.Remove("ArticuloSeleccionado");

                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('¡Felicidades! Tu participación ha sido registrada exitosamente. Se ha enviado un email de confirmación.');", true);
                //Cuando se canjee el voucher correctamente muestra mensaje , y nos redirige a la página principal Default.aspx
                ClientScript.RegisterStartupScript(this.GetType(),"alertRedirect","alert('¡Felicidades! Tu participación ha sido registrada exitosamente. Se ha enviado un email de confirmación.'); window.location='Default.aspx';", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alertError", $"alert('Error al procesar la participación: {ex.Message}');", true);
               
            }
        }

        private void DeshabilitarFormulario()
        {
            txtDni.Enabled = false;
            btnBuscarDni.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            TxtEmail.Enabled = false;
            txtDireccion.Enabled = false;
            txtCiudad.Enabled = false;
            txtCodigoPostal.Enabled = false;
            chkboxTerminos.Enabled = false;
            btnParticipar.Enabled = false;
        }
    }
}