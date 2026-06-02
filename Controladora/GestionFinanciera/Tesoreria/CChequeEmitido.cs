using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;
using AccesoDatos.Transaccional.GestionFinanciera.Tesoreria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public  class CChequeEmitido
    {
        public DataTable ListarBancos(string UserName)
        {
            return (new ChequeEmitidoNTAD()).ListarBancos(UserName);
        }
        public DataTable ListarCtasBancos(string CodBco, string Moneda, string UserName)
        {
            return (new ChequeEmitidoNTAD()).ListarCtasBancos(CodBco, Moneda, UserName);
        }
        public DataTable ListarBancosxUsuario(int IdUsuario, string UserName)
        {
            return (new ChequeEmitidoNTAD()).ListarBancosxUsuario(IdUsuario, UserName);
        }
        public DataTable ListarAll(int CodCeo, int Año, string CodBco, string CtaCte, string Moneda, int Impreso, string UserName)
        {
            return (new ChequeEmitidoNTAD()).ListarAll(CodCeo, Año, CodBco, CtaCte, Moneda, Impreso, UserName);
        }
        public string InsActBancoxUsuario(int IdUsuario, int IdEntidad, string UserName)
        {
                return (new ChequeEmitidoTAD()).InsActBancoxUsuario(IdUsuario, IdEntidad, UserName);
        }
        public string ActEstadoCheque(string CodigoBanco, string CodigoCtaCte, string NroCheque, string NroFolio, string Moneda, string Yymmdd, int Impreso, string UserName)
        {
            return (new ChequeEmitidoTAD()).ActEstadoCheque(CodigoBanco, CodigoCtaCte, NroCheque, NroFolio, Moneda, Yymmdd, Impreso, UserName);
        }
        public string ActBeneficiario(int Año, string CodigoBanco, string NroFolio, string Moneda, string CodigoCtaCte, string Beneficiario, string UserName)
        {
            return (new ChequeEmitidoTAD()).ActBeneficiario(Año, CodigoBanco, NroFolio, Moneda, CodigoCtaCte, Beneficiario, UserName);
        }

    }
}
