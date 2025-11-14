using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionFinanciera.Tesoreria.Pagos
{
    public class Archivo
    {
        public Archivo()
        {
        }

        public Archivo(string _CodCope, string NombrePlanilla, string Ext)
        {
            this.codCope = _CodCope;
            this.nombrePlanilla = NombrePlanilla;
            this.nombrePlanillaRpta = "";
            this.base64StringFilePlanilla = "";
            this.base64StringFilePlanillaRpta = "";
            this.extension = Ext;
            this.msjError = "";
        }

        public string codCope { get; set; }

        public string nombrePlanilla { get; set; }

        public string nombrePlanillaRpta { get; set; }

        public string base64StringFilePlanilla { get; set; }

        public string base64StringFilePlanillaRpta { get; set; }

        public string extension { get; set; }

        public string msjError { get; set; }
    }
}
