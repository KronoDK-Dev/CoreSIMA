using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.SIMANET.SeguridadPlanta
{
    public class AnexosBE:BaseBE
    {


        public int NroProgramacion { get; set; }
        public int Periodo { get; set; }
        public int NroArchivo { get; set; }
        public string Nombre { get; set; }
        public int IdTablaEstado { get; set; }

        // Auditoría específica del registro
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public int? IdUsuarioEliminacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public AnexosBE()
        {      }

    }
}
