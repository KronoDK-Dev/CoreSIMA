using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionContabilidad;

namespace Controladora.GestionContabilidad
{
    public class CEstados
    {
        public DataTable Listar_analisis_cuentas_nat(string D_AÑO, string D_MES_DESDE, string D_MES_HASTA, string V_CENTRO_OPERATIVO, string V_CTA_MAYOR_DESDE, string V_CTA_MAYOR_HASTA, string V_C_COSTO_DESDE, string V_C_COSTO_HASTA, string UserName)
        {
            return (new EstadosNTAD()).Listar_analisis_cuentas_nat(D_AÑO, D_MES_DESDE, D_MES_HASTA, V_CENTRO_OPERATIVO, V_CTA_MAYOR_DESDE, V_CTA_MAYOR_HASTA, V_C_COSTO_DESDE, V_C_COSTO_HASTA, UserName);
        }

        public DataTable Listar_mayor_auxi_pend_rel_res(string D_AÑO, string D_MES, string V_CUENTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new EstadosNTAD()).Listar_mayor_auxi_pend_rel_res(D_AÑO, D_MES, V_CUENTA, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }

        public DataTable Listar_conci_bancaria_resumen(string D_AÑO, string D_MES, string V_COD_BCO, string V_CUENTA_CORRIENTE, string UserName)
        {
            return (new EstadosNTAD()).Listar_conci_bancaria_resumen(D_AÑO, D_MES, V_COD_BCO, V_CUENTA_CORRIENTE, UserName);
        }

        public DataTable Listar_Estado_del_Proceso(string UserName)
        {
            return (new EstadosNTAD()).Listar_Estado_del_Proceso(UserName);
        }
        public DataTable Listar_Mayor_Auxiliar_Pendientes_por_Cuenta_Resumen(string V_Cuenta_Desde, string V_Cuenta_Hasta, string D_Año, string D_Mes, string UserName)
        {
            return (new EstadosNTAD()).Listar_Mayor_Auxiliar_Pendientes_por_Cuenta_Resumen(V_Cuenta_Desde, V_Cuenta_Hasta, D_Año, D_Mes, UserName);
        }
        public DataTable Listar_mayor_auxi_cuenta_resumen(string D_AÑO, string D_MES, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string UserName)
        {
            return (new EstadosNTAD()).Listar_mayor_auxi_cuenta_resumen(D_AÑO, D_MES, V_CUENTA_DESDE, V_CUENTA_HASTA, UserName);
        }
        public DataTable Listar_mayor_auxi_Rela_Resu(string D_AÑO, string D_MES, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new EstadosNTAD()).Listar_mayor_auxi_Rela_Resu(D_AÑO, D_MES, V_CUENTA_DESDE, V_CUENTA_HASTA, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }
    }
}
