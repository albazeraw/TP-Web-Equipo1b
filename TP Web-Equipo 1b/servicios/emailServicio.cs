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
            server.Credentials = new NetworkCredential("albanosuarez739@gmail.com", "i z b j u x i j n r l t g w n q");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }
        public void armarCorreo(string emailDestino,string nombre)
        {
            email = new MailMessage();
            email.From = new MailAddress("albanosuarez739@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = "premio";
            email.Body = "felicidades " + nombre + " tu voucher se canjeo correctamente";
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
