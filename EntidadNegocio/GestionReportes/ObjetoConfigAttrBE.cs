using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionReportes
{
    public class ObjetoConfigAttrBE : BaseBE
    {
        public int IdAtributoValor { get; set; }
        public int IdObjeto { get; set; }
        public int IdAtributo { get; set; }
        public string Valor { get; set; }
        public int IdGrp { get; set; }
        public int Orden { get; set; }

        public ObjetoConfigAttrBE() { }
    }
}
