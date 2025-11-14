using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio
{
    public class RequestBE
    {
        public string TransResul { get; set; }

        public int IntIdrow { get; set; }

        public string StrIdrow { get; set; }

        public RequestBE(string _TransResult, int _IntIdRow, string _strIdRow)
        {
            this.TransResul = _TransResult;
            this.IntIdrow = _IntIdRow;
            this.StrIdrow = _strIdRow;
        }

        public RequestBE(string _TransResult)
        {
            this.TransResul = _TransResult;
            this.IntIdrow = 0;
            this.StrIdrow = "@";
        }

        public RequestBE()
        {
        }
    }
}
