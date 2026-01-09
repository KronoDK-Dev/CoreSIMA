using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;
using AccesoDatos.Transaccional.GestionFinanciera.Tesoreria;
using Controladora.GestionContabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public  class CInterbancario
    {
        public DataTable CabeceraLotePago(string Estado, string UserName)
        {
            return (new InterbancarioNTAD()).CabeceraLotePago(Estado, UserName);
        }
        public DataTable CabeceraLotePago(string CodigoBanco,string LotePago, string Estado, string UserName)
        {
            return (new InterbancarioNTAD()).CabeceraLotePago(CodigoBanco,LotePago, Estado, UserName);
        }


        public DataTable DetalleLotePago(string CodigoBanco, string LotePago, string UserName)
        {
            return (new InterbancarioNTAD()).DetalleLotePago(CodigoBanco,LotePago, UserName);
        }


        public int  CabActulizaEstado(string Nrlote, int Estado, string UserName)
        {
            return (new InterbancarioTAD()).CabActulizaEstado(Nrlote, Estado, UserName);
        }
        public int CabActulizaEstado(string Nrlote, int Estado, string Mensaje, string UserName)
        {
            return (new InterbancarioTAD()).CabActulizaEstado(Nrlote, Estado, Mensaje, UserName);
        }

            public int DetActulizaEstado(string Nrlote, string NroPrv, string Observacion, string UserName)
        {
            return (new InterbancarioTAD()).DetActulizaEstado(Nrlote, NroPrv,  Observacion, UserName);
        }
    }
}
