using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario
{
    public class Mail
    {
        private string From = "";
        private string To;
        private string[] Cc;
        private string Message;
        private string Subject;
        private List<string> Archivo = new List<string>();
        private string DE = "";
        private string PASS = "";
        private MailMessage Email;
        public string error = "";

        public Mail(
          string FROM,
          string Para,
          string[] _Cc,
          string Mensaje,
          string Asunto,
          List<string> ArchivoPedido_ = null)
        {
            this.From = FROM;
            this.To = Para;
            this.Cc = _Cc.Length != 0 ? _Cc : (string[])null;
            this.Message = Mensaje;
            this.Subject = Asunto;
            this.Archivo = ArchivoPedido_;
        }

        public Mail(
          string FROM,
          string Para,
          string Mensaje,
          string Asunto,
          List<string> ArchivoPedido_ = null)
        {
            this.From = FROM;
            this.To = Para;
            this.Cc = (string[])null;
            this.Message = Mensaje;
            this.Subject = Asunto;
            this.Archivo = ArchivoPedido_;
        }

        public Mail(string FROM, string Para, string Mensaje, string Asunto)
        {
            this.From = FROM;
            this.To = Para;
            this.Cc = (string[])null;
            this.Message = Mensaje;
            this.Subject = Asunto;
            this.Archivo = (List<string>)null;
        }

        public MailResult enviaMail()
        {
            string message1 = "";
            bool exitoso = true;
            if (this.To.Trim().Equals(""))
            {
                message1 = "El mail del destino no se ha ingresado";
                exitoso = false;
            }
            if (this.Message.Trim().Equals(""))
            {
                message1 = $"{message1}{(message1.Length > 0 ? " y " : "")}El mensaje no se ha ingresado";
                exitoso = false;
            }
            if (this.Subject.Trim().Equals(""))
            {
                message1 = $"{message1}{(message1.Length > 0 ? " y " : "")}El Asunto no se ha ingresado";
                exitoso = false;
            }
            if (this.From.Trim().Equals(""))
            {
                message1 = $"{message1}{(message1.Length > 0 ? " y " : "")}El eMail del remitente no se ha ingresado";
                exitoso = false;
            }
            if (!exitoso)
                return new MailResult(message1, exitoso);
            string message2;
            try
            {
                this.Email = new MailMessage(this.From, this.To, this.Subject, this.Message);
                if (this.Archivo != null)
                {
                    foreach (string str in this.Archivo)
                    {
                        if (File.Exists(str))
                            this.Email.Attachments.Add(new Attachment(str));
                    }
                }
                this.Email.IsBodyHtml = true;
                this.Email.From = new MailAddress(this.From);
                if (this.Cc != null)
                {
                    foreach (string address in this.Cc)
                        this.Email.CC.Add(new MailAddress(address));
                }
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.EnableSsl = false;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Host = Helper.Archivo.Configuracion.getKey("ConfigBase", "ServerEMail");
                smtpClient.Port = Convert.ToInt32(Helper.Archivo.Configuracion.getKey("ConfigBase", "ServerEMailPort"));
                smtpClient.Send(this.Email);
                smtpClient.Dispose();
                return new MailResult("Se envio correo de manera satisfatoria", true);
            }
            catch (Exception ex)
            {
                message2 = ex.Message.Replace("'", " ");
            }
            return new MailResult(message2, false);
        }
    }
}
