using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionContabilidad;

namespace Controladora.GestionContabilidad
{
    public class CBalance
    {
        public DataTable Listar_balance_de_comprobacion(string D_MES, string D_PERIODO, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUNETA_HASTA, string UserName)
        {
            return (new BalanceNTAD()).Listar_balance_de_comprobacion(D_MES, D_PERIODO, V_CENTRO_OPERATIVO, V_CUENTA_DESDE, V_CUNETA_HASTA, UserName);
        }

        public DataTable Listar_balance_de_comprobacion_3_Digitos(string D_PERIODO, string D_MES, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string UserName)
        {
            return (new BalanceNTAD()).Listar_balance_de_comprobacion_3_Digitos(D_PERIODO, D_MES, V_CENTRO_OPERATIVO, V_CUENTA_DESDE, V_CUENTA_HASTA, UserName);
        }

        public DataTable Listar_balance_10_Columnas_2_Digit(string N_CEO, string V_ANIO, string V_MES, string UserName)
        {
            return (new BalanceNTAD()).Listar_balance_10_Columnas_2_Digit(N_CEO, V_ANIO, V_MES, UserName);
        }

        public DataTable Listar_balance_de_comprobacion_SUNAT(string N_CEO, string V_ANIO, string V_MES, string V_CUENTAINI, string V_CUENTAFIN, string UserName)
        {
            return (new BalanceNTAD()).Listar_balance_de_comprobacion_SUNAT(N_CEO, V_ANIO, V_MES, V_CUENTAINI, V_CUENTAFIN, UserName);
        }

        public DataTable Listar_balance_de_comprobacion_p(string D_AÑO, string D_MES, string D_MES_AJUSTE, string UserName)
        {
            return (new BalanceNTAD()).Listar_balance_de_comprobacion_p(D_AÑO, D_MES, D_MES_AJUSTE, UserName);
        }

        public DataTable Listar_balance_constructivo_mef(string D_AÑO, string D_MES, string D_MES_AJUSTE, string V_CODCEO, string UserName)
        {
            return (new BalanceNTAD()).Listar_balance_constructivo_mef(D_AÑO, D_MES, D_MES_AJUSTE, V_CODCEO, UserName);
        }

        public DataTable Listar_bal_constructivo_susalud(string D_AÑO, string D_MES, string UserName)
        {
            return (new BalanceNTAD()).Listar_bal_constructivo_susalud(D_AÑO, D_MES, UserName);
        }

        public DataTable Listar_MaXAuxi_Pend_Det_Conci(string V_Cuenta, string D_Año, string D_Mes, string V_Relacion_Desde, string V_Relacion_Hasta, string V_Documento, string V_Menos_Subdiario, string UserName)
        {
            return (new BalanceNTAD()).Listar_MaXAuxi_Pend_Det_Conci(V_Cuenta, D_Año, D_Mes, V_Relacion_Desde, V_Relacion_Hasta, V_Documento, V_Menos_Subdiario, UserName);
        }
    }
}
