using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk.ChatBot
{
    public class MensajeContenidoBE:BaseBE
    {
        public int IdMiembro{  get; set; }
        public string Texto { get; set; }
        public int  IdContactoOrigen { get; set; }
        public int IdContactoDestino { get; set; }
        public string JSonBE { get; set; }
        public int IdTablaInfo{ get; set; }
        public string IdInfo { get; set; }
    }
}
