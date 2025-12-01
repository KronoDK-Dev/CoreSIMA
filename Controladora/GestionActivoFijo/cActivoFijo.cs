using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionActivoFijo;

namespace Controladora.GestionActivoFijo
{
    public class cActivoFijo
    {
        public DataTable Listar_actfijo_cons_inv(string UserName)
        {
            return (new ActivoFijoNTAD()).Listar_actfijo_cons_inv(UserName);
        }

        public DataTable Listar_formato_7_1(string COD_EMP, string N_ANIO, string UserName)
        {
            return (new ActivoFijoNTAD()).Listar_formato_7_1(COD_EMP, N_ANIO, UserName);
        }

        public DataTable Listar_invent_actxgrupoysubgrsmn(string COD_EMPE, string GRUPOBN, string SUBGRUPOBN,
            string TIPOACTV, string UserName)
        {
            return (new ActivoFijoNTAD()).Listar_invent_actxgrupoysubgrsmn(COD_EMPE, GRUPOBN, SUBGRUPOBN, TIPOACTV, UserName);
        }

        public DataTable Listar_inventario_activosxcc(string CCOSTO1, string CCOSTO2, string COD_EMPE, string COD_PANOL,
            string TIPOACTV, string UserName)
        {
            return (new ActivoFijoNTAD()).Listar_inventario_activosxcc(CCOSTO1, CCOSTO2, COD_EMPE, COD_PANOL, TIPOACTV, UserName);
        }

        public DataTable Listar_inventario_activosxccrsm(string CCOSTO1, string CCOSTO2, string COD_EMPE,
            string TIPOACTV, string UserName)
        {
            return (new ActivoFijoNTAD()).Listar_inventario_activosxccrsm(CCOSTO1, CCOSTO2, COD_EMPE, TIPOACTV, UserName);
        }

        public DataTable Listar_inventario_activosxcustod(string COD_EMPE, string COD_ROL, string TIPOACTV,
            string UserName)
        {
            return (new ActivoFijoNTAD()).Listar_inventario_activosxcustod(COD_EMPE, COD_ROL, TIPOACTV, UserName);
        }

        public DataTable Listar_inventario_actsgrup_sub(string COD_EMP, string EST_BIEN, string GRUPO, string SUBGRUPO,
            string TIPO_BIEN, string UserName)
        {
            return (new ActivoFijoNTAD()).Listar_inventario_actsgrup_sub(COD_EMP, EST_BIEN, GRUPO, SUBGRUPO, TIPO_BIEN, UserName);
        }

        public DataTable Lista_Bienes_toma_inventario(string CODEMP, string NRO_PR, string CCO_INI, string CCO_FIN,
            string UserName)
        {
            return (new ActivoFijoNTAD()).Lista_Bienes_toma_inventario(CODEMP, NRO_PR, CCO_INI, CCO_FIN, UserName);
        }

        public DataTable Lista_actfijo_Pen(string UserName)
        {
            return (new ActivoFijoNTAD()).Lista_actfijo_Pen(UserName);
        }

        public DataTable Lista_AltasMes_ActF(string Anio, string Mes, string UserName)
        {
            return (new ActivoFijoNTAD()).Lista_AltasMes_ActF(Anio, Mes, UserName);
        }

        public DataTable Lista_AltasCuentOrd_M(string Anio, string Mes, string UserName)
        {
            return (new ActivoFijoNTAD()).Lista_AltasCuentOrd_M(Anio, Mes, UserName);
        }

        public DataTable Lista_Inventario_ActsGrup_Sub(string COD_EMP, string EST_BIEN, string TIPO_BIEN,
            string sGRUPO, string sSUBGRUPO, string UserName)
        {
            return (new ActivoFijoNTAD()).Lista_Inventario_ActsGrup_Sub(COD_EMP, EST_BIEN, TIPO_BIEN, sGRUPO, sSUBGRUPO, UserName);
        }

        public DataTable Lista_Inventario_ActsGrup_Sub2(string COD_EMP, string EST_BIEN, string TIPO_BIEN,
            string sGRUPO, string sSUBGRUPO, string UserName)
        {
            return (new ActivoFijoNTAD()).Lista_Inventario_ActsGrup_Sub2(COD_EMP, EST_BIEN, TIPO_BIEN, sGRUPO, sSUBGRUPO, UserName);
        }

        public DataTable Lista_Invent_ActxGrupoySubGRSMN(string COD_EMP, string TIPOACTV, string GRUPOBN, string SUBGRUPOBN, string UserName)
        {
            return (new ActivoFijoNTAD()).Lista_Invent_ActxGrupoySubGRSMN(COD_EMP, TIPOACTV, GRUPOBN, SUBGRUPOBN, UserName);
        }

        public DataTable Lista_Inventario_ActivosxCC(string CCOSTO1, string CCOSTO2, string COD_EMPE, string COD_PANOL,
            string TIPOACTV, string UserName)
        {
            return (new ActivoFijoNTAD()).Lista_Inventario_ActivosxCC(CCOSTO1, CCOSTO2, COD_EMPE, COD_PANOL, TIPOACTV, UserName);
        }
    }
}
