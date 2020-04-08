using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace UTILITARIO
{
    public class EMAIL
    {
        private static string fecha_envio = DateTime.Now.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);

        public static int enviarCorreo(Dictionary<string, string> correos, string asunto, string tituloHtml, string mensajeHtml, string firmaHtml)
        {
            try
            {
                String directorio = AppDomain.CurrentDomain.BaseDirectory;
                String template = File.ReadAllText(directorio + "template.html");

                template = String.Format(template, tituloHtml.ToUpper(), fecha_envio, mensajeHtml, firmaHtml);

                String hostName = Dns.GetHostName();
                MailMessage EmailMsg = new MailMessage();
                EmailMsg.From = new MailAddress("contacto@dya.pe", "DYA");
                //EmailMsg.From = new MailAddress("sistemas@manar.pe", "DYA");
                foreach (KeyValuePair<string, string> correo in correos)
                {
                    EmailMsg.To.Add(new MailAddress(correo.Key, correo.Value));
                }
                EmailMsg.Subject = asunto;
                EmailMsg.Body = template;
                EmailMsg.IsBodyHtml = true;
                EmailMsg.Priority = MailPriority.Normal;

                SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587);//465
                MailClient.EnableSsl = true;
                MailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //MailClient.Credentials = new System.Net.NetworkCredential("sistemas@manar.pe", "manar2030.20");
                MailClient.Credentials = new System.Net.NetworkCredential("contacto@dya.pe", "dya.2030");
                MailClient.Send(EmailMsg);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }

            /*var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("DYA", "sistemas@manar.pe"));
            mailMessage.To.Add(new MailboxAddress("Aldo Frank Apaza Colque", "frankapazac@gmail.com"));
            mailMessage.Subject = "Correo de verificación DYA";
            mailMessage.Body = new TextPart("plain")
            {
                Text = "VERIFIQUE SU CORREO"
            };

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                //smtpClient.Authenticate("contacto@dya.pe", "dya.2030");
                smtpClient.Authenticate("sistemas@manar.pe", "manar2030.20");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }*/
        }
    }
}
