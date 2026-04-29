using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.SIMANET.SeguridadPlanta
{


    public class ProgramacionBE : BaseBE
    {
        public int NRO_PROGRAMACION { get; set; }
        public int PERIODO { get; set; }
        public int ID_TABLA_TIPO_ENTIDAD { get; set; }
        public int ID_TIPO_VISITA { get; set; } // ID_TIPO_ENTIDAD
        public int ID_ENTIDAD { get; set; }
        public int? ID_JEFE_PROYECTO { get; set; }

        public string NRO_REGISTRO_INGRESO { get; set; }
        public string NRO_DOCUMENTO_REF { get; set; }

        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_TERMINO { get; set; }
        public string HORA_INICIO { get; set; }
        public string HORA_TERMINO { get; set; }

        public int ID_TABLA_CIA_SEGUROS { get; set; }
        public int ID_CIA_SEGUROS { get; set; }
        public string NRO_POLIZA { get; set; }
        public DateTime? FECHA_INICIO_POLIZA { get; set; }
        public DateTime? FECHA_TERMINO_POLIZA { get; set; }
        public string NRO_PENSION_POLIZA { get; set; }
        public string NRO_SALUD_POLIZA { get; set; }

        public string TRABAJOS_A_REALIZAR { get; set; }

        public int? ID_TABLA_LUGAR_TRABAJO { get; set; }
        public int? ID_LUGAR_TRABAJO { get; set; }
        public string NOMBRE_NAVE { get; set; }

        public string CONTACTO_NOMBRES { get; set; }
        public string OBSERVACIONES { get; set; }

        public int ID_TABLA_ESTADO { get; set; }
        public int ID_ESTADO { get; set; }

        public int ID_USUARIO_REGISTRO { get; set; }
        public int? ID_USUARIO_MODIFICACION { get; set; }
        public int? ID_USUARIO_ELIMINACION { get; set; }

        public DateTime FECHA_REGISTRO { get; set; }
        public DateTime? FECHA_MODIFICACION { get; set; }
        public DateTime? FECHA_ELIMINACION { get; set; }

        public int TIPO_PROGRAMACION { get; set; }
        public int? ID_USUARIO_APROBACION { get; set; }

        public int? INTERF_ENVIADO { get; set; }
        public string NRO_DOC { get; set; }
        public string ID_OS { get; set; }
        public string PC_IP { get; set; }

        public int? NO_PROG { get; set; }
        public DateTime? FECHA_INICIO_POLIZA_S { get; set; }
        public DateTime? FECHA_TERMINO_POLIZA_S { get; set; }
    }

}
