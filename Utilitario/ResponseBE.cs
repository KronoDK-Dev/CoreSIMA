using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario
{
    public class ResposeBE
    {
        public HttpStatusCode Status { get; set; }

        public string ObjResult { get; set; }

        public Dictionary<string, string> Mensaje { get; set; }
    }
}
