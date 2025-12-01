using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionReportes
{
    public class ArchivoCompartidoBE : BaseBE
    {
        public string IdCompartido { get; set; }
        public int IdObjeto { get; set; }
        public int IdUsuarioComp { get; set; }

        public ArchivoCompartidoBE() { }
        public ArchivoCompartidoBE(string _IdCompartido, int _IdObjeto, int _IdUsuarioComp)
        {
            this.IdCompartido = _IdCompartido;
            this.IdObjeto = _IdObjeto;
            this.IdUsuarioComp = _IdUsuarioComp;
        }
    }
}
