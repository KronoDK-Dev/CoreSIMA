using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionReportes
{
    public class ObjetoMapeoExportBE : BaseBE
    {
        public int IdDataField { get; set; }
        public int IdDataFieldPadre { get; set; }
        public string Nombre { get; set; }
        public string Alias { get; set; }
        public int Tipo { get; set; }
        public string FieldCompute { get; set; }
        public int Exportar { get; set; }
        public int Orden { get; set; }
        public int Prioridad { get; set; }
        public int IdObjeto { get; set; }

        public ObjetoMapeoExportBE() { }
    }
}
