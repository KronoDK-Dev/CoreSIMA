using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.GestionFinanciera.Tesoreria;
using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public class CInterbancario
    {
        public DataTable CabeceraLotePago(string Estado, string UserName)
        {
            return new InterbancarioNTAD().CabeceraLotePago(Estado, UserName);
        }

        public DataTable CabeceraLotePago(string LotePago, string Estado, string UserName)
        {
            return new InterbancarioNTAD().CabeceraLotePago(LotePago, Estado, UserName);
        }

        public DataTable DetalleLotePago(string LotePago, string UserName)
        {
            return new InterbancarioNTAD().DetalleLotePago(LotePago, UserName);
        }

        public int CabActulizaEstado(string Nrlote, int Estado, string UserName)
        {
            return new InterbancarioTAD().CabActulizaEstado(Nrlote, Estado, UserName);
        }

        public int CabActulizaEstado(string Nrlote, int Estado, string Mensaje, string UserName)
        {
            return new InterbancarioTAD().CabActulizaEstado(Nrlote, Estado, Mensaje, UserName);
        }

        public int DetActulizaEstado(string Nrlote, string NroPrv, string Observacion, string UserName)
        {
            return new InterbancarioTAD().DetActulizaEstado(Nrlote, NroPrv, Observacion, UserName);
        }
    }
}
