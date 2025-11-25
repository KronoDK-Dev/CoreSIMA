using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionPersonal
{
    public class PersonalUbicacionBE : BaseBE
    {
        public int IdPersonal { get; set; }
        public string NroPersonal { get; set; }
        public string DocIdentidad { get; set; }
        public string ApellidosyNombres { get; set; }
        public string NombreArea { get; set; }
        public string EMail { get; set; }
        public string CodigoArea { get; set; }
    }
}
