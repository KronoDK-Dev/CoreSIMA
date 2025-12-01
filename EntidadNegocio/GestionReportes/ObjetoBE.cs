using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionReportes
{
    public class ObjetoBE : BaseBE
    {
        public int IdObjeto { get; set; }
        public int IdPadre { get; set; }
        public string Nombre { get; set; }
        public int IdTipo { get; set; }
        public int IdTipoControl { get; set; }
        public string Descripcion { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        public string Ref4 { get; set; }
        public int IdUsuarioAnalista { get; set; }
        public int OrdenXNivel { get; set; }
        public int IdUsuarioSolicitante { get; set; }

        public ObjetoBE() { }
        public ObjetoBE(int _IdObjeto, int _IdPadre, string _Nombre)
        {
            this.IdObjeto = _IdObjeto;
            this.IdPadre = _IdPadre;
            this.Nombre = _Nombre;
        }
    }
}
