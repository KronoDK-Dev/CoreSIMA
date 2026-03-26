using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionProyecto
{
    public class ProyectoPresupuestoBE : BaseBE
    {
        public int N_ACCION { get; set; } // 1/2/3/4
        public string V_FTPresupuesto_CodProyecto { get; set; } // 11
        public string V_FTPresupuesto_Sucursal { get; set; }    // 1
        public decimal? N_FTPresupuesto_CostoMOB { get; set; }
        public decimal? N_FTPresupuesto_CostoMAT { get; set; }
        public decimal? N_FTPresupuesto_CostoSER { get; set; }
        public decimal? N_FTPresupuesto_CostoIND { get; set; }
        public string V_FTPresupuesto_USUARIO_AUDI { get; set; } // 15
        public string V_FTPresupuesto_ESTACIONW { get; set; }    // 15
        public string V_FTPresupuesto_AUDITORIA { get; set; }    // 200
    }
}
