using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario
{
    public enum TipoAPI { 
        ApiKey,
        Bearer,
        Basic,
    }
    public class ApiInfoBE
    {
        public ApiInfoBE() { }
        public string Url { get; set; }
        public string Metodo { get; set; }
        public TipoAPI Tipo{  get; set; }
        public string TokenValue {  get; set; }
        public string  MediaType { get; set; }
        public object BodyParam {  get; set; }



    }
}
