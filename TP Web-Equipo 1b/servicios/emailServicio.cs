using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace servicios
{
    public class emailServicio
    {
        private MailMessage email;
        private SmtpClient server;

        public emailServicio()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("albanosuarezdev@gmail.com", "vqhi etdv mnxu jfbv");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }
        public void armarCorreo(string emailDestino,string nombre)
        {
            emailDestino = emailDestino.Trim();
            email = new MailMessage();
            email.From = new MailAddress("albanosuarezdev@gmail.com");
            email.To.Add(new MailAddress(emailDestino.Trim()));
            //email.To.Add(emailDestino);
            email.Subject = "Confirmación de participación";
            email.Body = $"¡Felicidades {nombre}! Tu voucher se canjeó correctamente.";
        }
        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

}
