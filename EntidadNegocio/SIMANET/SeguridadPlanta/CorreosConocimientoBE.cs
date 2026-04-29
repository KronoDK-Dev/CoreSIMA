using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.SIMANET.SeguridadPlanta
{
    public class CorreosConocimientoBE:BaseBE
    {
        public int NroProgramacion { get; set; }
        public int Periodo { get; set; }
        public int IdPersonal { get; set; }
        public int Enviado { get; set; }

        public int IdTablaEstado { get; set; }
       // public int IdEstado { get; set; }

        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public int? IdUsuarioEliminacion { get; set; }

        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public DateTime? FechaEnvio { get; set; }

        public CorreosConocimientoBE()
        {
        }

    }
}
