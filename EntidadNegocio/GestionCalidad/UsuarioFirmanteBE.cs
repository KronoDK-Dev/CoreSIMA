using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionCalidad
{
    public class UsuarioFirmanteBE : BaseBE
    {
        public string IdInspeccion { get; set; }
        public int IdPersonaFirmante { get; set; }
        public int IdTipoFirmante { get; set; }
        public string Descripcion { get; set; }
        public string Recomendaciones { get; set; }
        public string Firma { get; set; }
        public int UpDateEmail { get; set; }
        public int IdTipoPlazo { get; set; }
        public int TiempoPlazo { get; set; }
    }
}
