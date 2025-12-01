using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionComercial
{
    public class ColaboradorProyectoBE : BaseBE
    {
        public string V_COLPROY_SUCURSAL { get; set; } // VARCHAR2(10 BYTE)
        public string V_COLPROY_PROYECTO { get; set; } // VARCHAR2(11 BYTE)
        public string DT_COLPROY_INGRESO { get; set; } // DATE
        public string V_COLPROY_PR { get; set; } // VARCHAR2(5 BYTE)
        public string V_COLPROY_CODTRA { get; set; } // VARCHAR2(11 BYTE)
        public string DT_COLPROY_CESE { get; set; } // DATE (NULLABLE)
        public int N_ACCION { get; set; } // Acción para el SP (1=Insertar, 2=Actualizar, etc.)
    }
}
