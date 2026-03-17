using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.SIMANET.SeguridadPlanta
{
    public class CCTT_TrabajadorBE:BaseBE
    {
        public string NroDNI
        {
            get;
            set;
        }
        public string NroDNIOld
        {
            get;
            set;
        }
        public string ApellidoPaterno
        {
            get;
            set;
        }
        public string ApellidoMaterno
        {
            get;
            set;
        }
        public string Nombres
        {
            get;
            set;
        }
        public int IdNacionalidad
        {
            get;
            set;
        }
        public string ApellidosyNombres
        {
            get;
            set;
        }

    }
}
