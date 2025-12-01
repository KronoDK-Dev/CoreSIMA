using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk.ChatBot
{
    public class CBContactoGrupoBE : BaseBE
    {
        public int IdContacto { get; set; }
        public int IdMiembro { get; set; }
        public int IsGrupo { get; set; }
        public string NombreGrupo { get; set; }
        public string FotoGrupo { get; set; }
        public string LIB_JS_SRVBROKER { get; set; }
        public string CodPersonal { get; set; }
    }
}
