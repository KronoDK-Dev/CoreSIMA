using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionComercial
{
    public class DetalleEmbarcacionBE : BaseBE
    {
        public string V_EMBARCACION_ID { get; set; }
        public string N_IDAREA { get; set; }
        public string N_VALOR { get; set; }
        public string DA_FECHAREGISTRO { get; set; }
        public string C_UM { get; set; }
    }
}
