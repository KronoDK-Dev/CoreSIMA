using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.HelpDesk.ChatBot;

namespace Controladora.HelpDesk.ChatBot
{
    public class CCBMensajeContendido
    {
        public string Inserta(BaseBE oBaseBE)
        {
            return (new CBMensajeContendidoTAD()).Inserta(oBaseBE);
        }
    }
}
