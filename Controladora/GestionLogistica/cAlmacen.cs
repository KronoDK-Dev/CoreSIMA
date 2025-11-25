using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionLogistica;

namespace Controladora.GestionLogistica
{
    public class cAlmacen
    {
        public DataTable Listar_OC_Locales_Montos_AlmFac(string V_CEO, string V_OC, string UserName)
        {
            return (new AlmacenNTAD()).Listar_OC_Locales_Montos_AlmFac(V_CEO, V_OC, UserName);
        }

        public DataTable Listar_SALDO_HIST_ALMACEN_DETALLE(string Centro_Operativo, string Fecha_de_Proceso,
            string UserName)
        {
            return (new AlmacenNTAD()).Listar_SALDO_HIST_ALMACEN_DETALLE(Centro_Operativo, Fecha_de_Proceso, UserName);
        }

        public DataTable Listar_KARDEX_UF_EXONERADO(string V_MES, string V_ANIO, string UserName)
        {
            return (new AlmacenNTAD()).Listar_KARDEX_UF_EXONERADO(V_MES, V_ANIO, UserName);    
        }

        public DataTable Listar_KARDEX_UF_GRAVADO(string D_Periodo_Saldo, string D_Mes_Periodo, string UserName)
        {
            return (new AlmacenNTAD()).Listar_KARDEX_UF_GRAVADO(D_Periodo_Saldo, D_Mes_Periodo, UserName);
        }

        public DataTable Listar_CTRL_MAT_ALM_OCO(string Fec_inic, string Fec_Final, string Codigo_OT, string UserName)
        {
            return (new AlmacenNTAD()).Listar_CTRL_MAT_ALM_OCO(Fec_inic, Fec_Final, Codigo_OT, UserName);
        }

        public DataTable Listar_SALDO_HIST_ALMACEN_RESUMEN(string Centro_Operativo, string Fecha_de_Proceso, string UserName)
        {
            return (new AlmacenNTAD()).Listar_SALDO_HIST_ALMACEN_RESUMEN(Centro_Operativo, Fecha_de_Proceso, UserName);
        }

        public DataTable Listar_CTRLMATERIAL_SINFORMAT(string N_CEO, string N_CODMAT, string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new AlmacenNTAD()).Listar_CTRLMATERIAL_SINFORMAT(N_CEO, N_CODMAT, D_FECHAINI, D_FECHAFIN, UserName);
        }

        public DataTable Listar_SALDO_ALMACEN_DETALLE(string Centro_Operativo, string Codigo_Clase_Material, string UserName)
        {
            return (new AlmacenNTAD()).Listar_SALDO_ALMACEN_DETALLE(Centro_Operativo, Codigo_Clase_Material, UserName);
        }

        public DataTable Listar_SALDO_ALMACEN_RESUMEN(string Centro_Operativo, string Codigo_Clase, string UserName)
        {
            return (new AlmacenNTAD()).Listar_SALDO_ALMACEN_RESUMEN(Centro_Operativo, Codigo_Clase, UserName);
        }

        public DataTable Listar_OcoImpGuias_v1(string ORDEN_COMPRA, string NUMERO_GUIA, string UserName)
        {
            return (new AlmacenNTAD()).Listar_OcoImpGuias_v1(ORDEN_COMPRA, NUMERO_GUIA, UserName);
        }

        public DataTable Listar_SALIDAS_DEV_PROV_EMB_V1(string Fecha_Guia, string UserName)
        {
            return (new AlmacenNTAD()).Listar_SALIDAS_DEV_PROV_EMB_V1(Fecha_Guia, UserName);
        }

        public DataTable Listar_Vales_Dev_Pqt(string v_CEO, string V_PERIODO, string V_Estado_VDE, string V_Numero_VDE, string UserName)
        {
            return (new AlmacenNTAD()).Listar_Vales_Dev_Pqt(v_CEO, V_PERIODO, V_Estado_VDE, V_Numero_VDE, UserName);
        }

        public DataTable Listar_SaldosAlmacenBalance_Dif(string V_AÑO, string V_MES, string UserName)
        {
            return (new AlmacenNTAD()).Listar_SaldosAlmacenBalance_Dif(V_AÑO, V_MES, UserName);
        }
    }
}
