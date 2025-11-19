using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionCalidad
{
    public class InspeccionAnexoBE : BaseBE
    {
        public string IdAnexo { get; set; }
        public string IdInspeccion { get; set; }
        public string Archivo { get; set; }
        public int Orden { get; set; }

        public InspeccionAnexoBE() { }

        public InspeccionAnexoBE(string _IdAnexo, string _IdInspeccion, string _Archivo)
        {
            this.IdAnexo = _IdAnexo;
            this.IdInspeccion = _IdInspeccion;
            this.Archivo = _Archivo;
        }
    }
}
