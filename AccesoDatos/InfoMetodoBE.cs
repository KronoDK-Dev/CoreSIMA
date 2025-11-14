using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class InfoMetodoBE
    {
        private string strOut = "";
        private List<string> lstValues = new List<string>();

        public string FullName { get; set; }

        public string MetodoANDParams { get; set; }

        public string VoidParams { get; set; }

        public override string ToString()
        {
            return $"NAMESAPACE: {this.FullName} ||  METODO:= {this.MetodoANDParams}".ToString();
        }
    }
}
