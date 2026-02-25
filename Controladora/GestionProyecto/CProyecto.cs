using AccesoDatos.NoTransaccional.GestionProyecto;
using AccesoDatos.Transaccional.GestionProyecto;
using EntidadNegocio;
using EntidadNegocio.GestionProyecto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionProyecto
{
    public class CProyecto
    {
        public DataTable ListarProyectos(string V_CEO, string V_UND_OPER, string V_LINEA, string V_FILTRO, string V_FECHAINI, string V_FECHAFIN, string V_AMBIENTE = "T")
        {
            return (new ProyectoNTAD()).ListarProyectos(V_CEO, V_UND_OPER, V_LINEA, V_FILTRO, V_FECHAINI, V_FECHAFIN, V_AMBIENTE);
        }
        public string GEN_PROYECTO_ID(string p_ceo, string p_unidOpe, string P_linea, string p_sublinea, string P_V_CLIENTE_ID, string V_AMBIENTE = "T")
        {
            return (new ProyectoNTAD()).GEN_PROYECTO_ID(p_ceo, p_unidOpe, P_linea, p_sublinea, P_V_CLIENTE_ID, V_AMBIENTE);
        }

        public BaseBE ListarProyectoPorId(string V_PRY_ID, string UserName, string sAmbiente = "T")
        {
            return (new ProyectoNTAD()).ListarProyectoPorId(V_PRY_ID, UserName, sAmbiente);
        }

        public DataTable ListarOtSPorProyecto(string V_COD_PRY, string V_AMBIENTE = "T")
        {
            return (new ProyectoNTAD()).ListarOtSPorProyecto(V_COD_PRY, V_AMBIENTE);
        }

        public DataTable ListarAdendasPorProyecto(string V_COD_PRY, string V_AMBIENTE = "T")
        {
            return (new ProyectoNTAD()).ListarAdendasPorProyecto(V_COD_PRY, V_AMBIENTE);
        }

        public DataTable Listar_CartaFianzas(string v_ANIOCARTA, string V_CODPROYECTO, string UserName)
        {
            return (new ProyectoNTAD()).Listar_CartaFianzas(v_ANIOCARTA, V_CODPROYECTO, UserName);
        }

        public DataTable Listar_ViaticosProyectos(string v_ANIOCARTA, string V_CODPROYECTO, string UserName)
        {
            return (new ProyectoNTAD()).Listar_ViaticosProyectos(v_ANIOCARTA, V_CODPROYECTO, UserName);
        }

        public DataTable Listar_Rendicion_Recibo_Caja_xProyecto(string v_CEO, string v_ANIO, string V_CODPROYECTO, string v_TIPO, string UserName)
        {
            return (new ProyectoNTAD()).Listar_Rendicion_Recibo_Caja_xProyecto(v_CEO, v_ANIO, V_CODPROYECTO, v_TIPO, UserName);
        }

        public DataTable Listar_OT_Costos_estimados_xProyecto(string v_CEO, string V_CODPROYECTO, string UserName)
        {
            return (new ProyectoNTAD()).Listar_OT_Costos_estimados_xProyecto(v_CEO, V_CODPROYECTO, UserName);
        }

        public DataTable Listar_Viaticos_Rendidos(string V_CEO, string V_CODPROYECTO, string UserName)
        {
            return (new ProyectoNTAD()).Listar_Viaticos_Rendidos(V_CEO, V_CODPROYECTO, UserName);
        }

        public DataTable Listar_Cartas_Fianzas(string V_CEO, string V_CODPROYECTO, string UserName)
        {
            return (new ProyectoNTAD()).Listar_Cartas_Fianzas(V_CEO, V_CODPROYECTO, UserName);
        }

        public DataTable Listar_Aportes_Sencico(string V_CEO, string V_CODPROYECTO, string UserName)
        {
            return (new ProyectoNTAD()).Listar_Aportes_Sencico(V_CEO, V_CODPROYECTO, UserName);
        }

        public DataTable Listar_Ingresos_Proyecto(string V_CEO, string V_CODPROYECTO, string UserName)
        {
            return (new ProyectoNTAD()).Listar_Ingresos_Proyecto(V_CEO, V_CODPROYECTO, UserName);
        }

        public DataTable Listar_Planilla_Proyecto(string V_CEO, string V_CODPROYECTO, string V_PERIODO, string UserName)
        {
            return (new ProyectoNTAD()).Listar_Planilla_Proyecto(V_CEO, V_CODPROYECTO, V_PERIODO, UserName);
        }

        public DataTable Listar_ColaboradoresProyecto(string V_SUCURSAL, string V_PROYECTO)
        {
            return (new ProyectoNTAD()).Listar_ColaboradoresProyecto(V_SUCURSAL, V_PROYECTO);
        }

        public DataTable Get_ProyectoPresupuesto(string V_FTPresupuesto_CodProyecto, string V_FTPresupuesto_Sucursal,string UserName)
        {
            return (new ProyectoNTAD()).Get_ProyectoPresupuesto(V_FTPresupuesto_CodProyecto, V_FTPresupuesto_Sucursal, UserName);
        }

        #region TRANSACCIONALES

        public string InsertarProyecto(BaseBE oBaseBE, string accion, string sAmbiente = "T")
            {
                return (new ProyectoTAD()).InsertarProyecto(oBaseBE, accion, sAmbiente);
            }

            public string InsertarAdendaProyecto(BaseBE oBaseBE, string accion, string sAmbiente = "T")
            {
                return (new ProyectoTAD()).InsertarAdendaProyecto(oBaseBE, accion, sAmbiente);
            }

            public string Ins_upd_ColaboradorProy(BaseBE oBaseBE)
            {
                return (new ProyectoTAD()).Ins_upd_ColaboradorProy(oBaseBE);
            }

            public string Del_ColaboradorProy(BaseBE oBaseBE)
            {
                return (new ProyectoTAD()).Del_ColaboradorProy(oBaseBE);
            }

            public string DEL_ADENDAPROYECTO(string P_CODPRY, string P_NROADENDA, string UserName, string V_AMBIENTE = "T")
            {
                return (new ProyectoTAD()).DEL_ADENDAPROYECTO(P_CODPRY, P_NROADENDA, UserName, V_AMBIENTE);
            }

            public string InsertarUsuarioProyecto(string userId, string proyId, string UserName)
            {
                return (new ProyectoTAD()).InsertarUsuarioProyecto(userId, proyId, UserName);
            }

            public string InsUpdDel_ProyectoPresupuesto(ProyectoPresupuestoBE oBE)
            {
                return (new ProyectoTAD()).InsUpdDel_ProyectoPresupuesto(oBE);
            }

            #endregion
        }
    }
