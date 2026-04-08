using AccesoDatos.NoTransaccional.SIMANET.SeguridadPlanta;
using AccesoDatos.Transaccional.SIMANET.SeguridadPlanta;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SIMANET.SeguridadPlanta
{
    public  class CAutorizaFeriado
    {
        public DataTable ListaFeriadoPorTrabajador(string NroDNI, DateTime FIniProg, DateTime FFinProg, string UserName)
        {
            return (new AutorizaFeriadoNTAD()).ListaFeriadoPorTrabajador(NroDNI, FIniProg, FFinProg, UserName);
        }
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new AutorizaFeriadoTAD()).ModificaInserta(oBaseBE);
        }
    }
}
