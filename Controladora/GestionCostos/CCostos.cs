using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionCostos;

namespace Controladora.GestionCostos
{
    public class CCostos
    {
        public DataTable Listar_costo_prod_linea_neg_resu(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_LINEA_NEGOCIO, string UserName)
        {
            return (new CostosNTAD()).Listar_costo_prod_linea_neg_resu(D_AÑO, D_MES, V_CENTRO_OPERATIVO, V_LINEA_NEGOCIO, UserName);
        }

        public DataTable Listar_costo_prod_linea_neg_det(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_LINEA_NEGOCIO, string UserName)
        {
            return (new CostosNTAD()).Listar_costo_prod_linea_neg_det(D_AÑO, D_MES, V_CENTRO_OPERATIVO, V_LINEA_NEGOCIO, UserName);
        }

        public DataTable Listar_ManoObra_ImprodNatuG_Det(string V_Centro_Operativo, string D_Año_de_Proceso,
            string D_Mes, string UserName)
        {
            return (new CostosNTAD()).Listar_ManoObra_ImprodNatuG_Det(V_Centro_Operativo, D_Año_de_Proceso,
            D_Mes, UserName);
        }

        public DataTable Listar_Costo_Prod_Linea_Neg_Det(string D_Año, string D_Mes, string V_Centro_Operativo,
            string V_Linea_Negocio, string UserName)
        {
            return (new CostosNTAD()).Listar_Costo_Prod_Linea_Neg_Det(D_Año, D_Mes, V_Centro_Operativo,
             V_Linea_Negocio, UserName);
        }

        public DataTable Listar_Costo_VentasLineaNegocioRes(string V_Centro_Operativo, string D_Año, string D_Mes,
            string V_Linea_Negocio, string UserName)
        {
            return (new CostosNTAD()).Listar_Costo_VentasLineaNegocioRes(V_Centro_Operativo, D_Año, D_Mes,
             V_Linea_Negocio, UserName);
        }

        public DataTable Listar_CostPro_por_Linea_Neg_R(string Centro_Operativo, string Periodo, string Linea_Negocio,
            string UserName)
        {
            return (new CostosNTAD()).Listar_CostPro_por_Linea_Neg_R(Centro_Operativo, Periodo, Linea_Negocio,
             UserName);
        }

        public DataTable Listar_CostPro_por_Linea_Neg_D(string Centro_Operativo, string Periodo, string Linea_Negocio,
            string UserName)
        {
            return (new CostosNTAD()).Listar_CostPro_por_Linea_Neg_D(Centro_Operativo, Periodo, Linea_Negocio,
            UserName);
        }

        public DataTable Listar_Hors_HombreNormalUtili_Divi(string V_Centro_Operativo, string D_Año, string D_Mes,
            string UserName)
        {
            return (new CostosNTAD()).Listar_Hors_HombreNormalUtili_Divi(V_Centro_Operativo, D_Año, D_Mes, UserName);
        }

        public DataTable Listar_Distri_Costo_Grup_Resu(string V_Centro_Operativo, string D_Año, string D_Mes,
           string UserName)
        {
            return (new CostosNTAD()).Listar_Distri_Costo_Grup_Resu(V_Centro_Operativo, D_Año, D_Mes, UserName);
        }

        public DataTable Listar_Distri_Costo_Grup_CC_Det(string V_Centro_Operativo, string D_Año, string D_Mes, string V_Grupo_CC_Desde, string V_Grupo_CC_Hasta,
          string UserName)
        {
            return (new CostosNTAD()).Listar_Distri_Costo_Grup_CC_Det(V_Centro_Operativo, D_Año, D_Mes, V_Grupo_CC_Desde, V_Grupo_CC_Hasta,
           UserName);
        }

        public DataTable Listar_Mano_Obra_Directa_Div_Det(string V_Centro_Operativo, string D_Año, string D_Mes, string V_Division_Inicial, string V_Division_Final,
        string UserName)
        {
            return (new CostosNTAD()).Listar_Mano_Obra_Directa_Div_Det(V_Centro_Operativo, D_Año, D_Mes, V_Division_Inicial, V_Division_Final,
         UserName);
        }

        public DataTable Listar_CostosDirectos_OT_CC(string V_Centro_Operativo, string v_Anio, string v_Mes, string V_Linea_Neg, string UserName)
        {
            return (new CostosNTAD()).Listar_CostosDirectos_OT_CC(V_Centro_Operativo, v_Anio, v_Mes, V_Linea_Neg, UserName);
        }

        public DataTable Listar_Materiales_en_Proyectos(string V_Centro_Operativo, string v_materiales, string UserName)
        {
            return (new CostosNTAD()).Listar_Materiales_en_Proyectos(V_Centro_Operativo, v_materiales, UserName);
        }
    }
}