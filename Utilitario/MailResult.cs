using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario
{
    public class MailResult
    {
        public string Message { get; set; }

        public bool Exitoso { get; set; }

        public MailResult(string message, bool exitoso)
        {
            this.Message = message;
            this.Exitoso = exitoso;
        }
    }
}
