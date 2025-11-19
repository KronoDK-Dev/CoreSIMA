using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionCalidad
{
    public class InspectorBE : BaseBE
    {
        public string IdInspector { get; set; }
        public string IdInspeccion { get; set; }
        public int IdPersonal { get; set; }
        public int Principal { get; set; }

        public InspectorBE()
        {
        }

        public InspectorBE(string _IdInspector, string _IdInspeccion, int _IdPersonal, int _Principal)
        {
            this.IdInspector = _IdInspector;
            this.IdInspeccion = _IdInspeccion;
            this.IdPersonal = _IdPersonal;
            this.Principal = _Principal;
        }
    }
}
