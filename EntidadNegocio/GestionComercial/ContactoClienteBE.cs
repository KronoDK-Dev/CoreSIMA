using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionComercial
{
    public class ContactoClienteBE : BaseBE
    {
        public int N_CLIE_IDCONTACTO { get; set; }
        public string V_CLIENTE_ID { get; set; }
        public string C_CLIE_CODCARGO { get; set; }
        public string C_CLIE_NOMBRE { get; set; }
        public string C_CLIE_TELEF1 { get; set; }
        public string C_CLIE_TELEF2 { get; set; }
        public string C_CLIE_FECHANAC { get; set; }
        public string C_CLIE_EMAIL { get; set; }
        public string C_CLIE_TIPOENVIO { get; set; }
    }
}
