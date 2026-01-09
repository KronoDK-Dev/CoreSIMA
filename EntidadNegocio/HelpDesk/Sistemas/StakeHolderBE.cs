using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk.Sistemas
{
    public  class StakeHolderBE:BaseBE
    {
        public string IdStakeHolder { get; set; }
        public string IdActividad { get; set; }
        public string IdPersonal{ get; set; }
        public int IdTipoStakeHolder { get; set; }
        public string ApellidosYNombres { get; set; } = string.Empty;
        public string Puesto { get; set; } = string.Empty;
        public string NroDocDNI { get; set; } = string.Empty;

        public string NombreImg { get; set; } = string.Empty;
        public string Firma { get; set; } = string.Empty;

    }
}
