using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionComercial
{
    public class ProyectoBE : BaseBE
    {
        public string COD_CEO { get; set; } // VARCHAR2(1 BYTE)
        public string COD_PRY { get; set; } // VARCHAR2(11 BYTE)  
        public string COD_PROY_CH { get; set; } // VARCHAR2(11 BYTE)
        public string COD_DIV { get; set; } // VARCHAR2(2 BYTE)
        public string DES_PRY { get; set; } // VARCHAR2(100 BYTE)
        public string COD_ALM { get; set; } // VARCHAR2(3 BYTE)
        public string EST_ATL { get; set; } // VARCHAR2(3 BYTE)
        public string NRO_VAL_PRY { get; set; } // VARCHAR2(11 BYTE)
        public string USR_REG { get; set; } // VARCHAR2(15 BYTE)
        public string PRY_JDE { get; set; } // VARCHAR2(4 BYTE)
        public string EST_PRY { get; set; } // VARCHAR2(3 BYTE)
        public string TIPO_PRY { get; set; } // NUMBER(1,0)
        public string FECINI_PRY { get; set; } // DATE
        public string FECFIN_PRY { get; set; } // DATE
        public string V_PRY_UNDOPER { get; set; } // VARCHAR2(2 BYTE)
        public string V_PRY_SUBLINEA { get; set; } // VARCHAR2(2 BYTE)
        public string V_CLIENTE_ID { get; set; } // VARCHAR2(25 BYTE)
        public string V_PRY_COD_JEFEPROY { get; set; } // VARCHAR2(15 BYTE)
        public string N_PRY_MONTO_SINIMP { get; set; } // NUMBER(15,5)
        public string V_PRY_CODMONEDA { get; set; } // VARCHAR2(10 BYTE)
        public string N_PRY_ESLORA { get; set; } // NUMBER(5,2)
        public string N_PRY_MANGA { get; set; } // NUMBER(5,2)
        public string N_PRY_PUNTAL { get; set; } // NUMBER(5,2)
        public string N_PRY_BODEGA { get; set; } // NUMBER(5,2)
        public string V_PRY_ESTACIONW { get; set; } // VARCHAR2(15 BYTE)
        public string V_PRY_AUDITORIA { get; set; } // VARCHAR2(200 BYTE)
        public string V_PRY_OBSERVACIONES { get; set; } // VARCHAR2(200 BYTE)
        public string CORREO { get; set; } // VARCHAR2(60 BYTE)
        public string NROCASCO { get; set; } // VARCHAR2(15 BYTE)
        public string CLIENTE { get; set; }
        public string V_JEFEPROY { get; set; }
        public string N_PRY_ESLORA_LBP { get; set; } // NUMBER(5,2)
        public string N_PRY_CALADO { get; set; } // NUMBER(5,2)
        public string V_PRY_Convenio { get; set; } // VARCHAR2(50 BYTE)

    }
}
