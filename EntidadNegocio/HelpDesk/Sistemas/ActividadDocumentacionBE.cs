using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk.Sistemas
{
    public class ActividadDocumentacionBE : BaseBE
    {
        public string IDocumentacion { get; set; }
        public string IDocPadre{ get; set; }
        public string IdActividad { get; set; }
        public int IdTipoDocumentacion { get; set; }
        public string NombreTipoDoc { get; set; }
        public string IdPersonal { get; set; }
        public string ApellidosYNombres { get; set; } = string.Empty;
        public string Puesto { get; set; } = string.Empty;
        public string NroDocDNI { get; set; } = string.Empty;
    }
}
