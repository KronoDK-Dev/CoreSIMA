using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionComercial
{
    public class ClienteBE : BaseBE
    {
        public int COD_CLI { get; set; }
        public string COD_CLIENTE { get; set; }
        public string TIP_CLI { get; set; }
        public string CIIU { get; set; }
        public string PAIS { get; set; }
        public long NRO_RUC { get; set; }
        public string DOCUM_EXT { get; set; }
        public string NOM_APS { get; set; }
        public string COD_PRC { get; set; }
        public string ENT_CLI { get; set; }
        public string UBC_GEO { get; set; }
        public string DIR_LGL { get; set; }
        public string TLX1 { get; set; }
        public string TLX2 { get; set; }
        public DateTime FEC_RGT { get; set; }
        public string EST_ATL { get; set; }
        public string COD_USR { get; set; }
        public string CSF_DB { get; set; }
        public string COD_USR_INA { get; set; }
        public string V_CLI_AUDITORIA { get; set; }
        public string V_CLIENTE_ID { get; set; }
    }
}
