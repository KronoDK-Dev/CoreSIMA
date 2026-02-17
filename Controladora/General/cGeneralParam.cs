using AccesoDatos.NoTransaccional.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.General
{
    public class cGeneralParam
    {
        public DataTable listactactexcodbanco(string V_NOMBRE, string V_CODIGO, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listactactexcodbanco(V_NOMBRE, V_CODIGO, UserName, v_ambiente);
        }

        public DataTable listabancosxcodxdescr(string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listabancosxcodxdescr(V_DESCRIPCION, UserName, v_ambiente);
        }

        public DataTable listaproyectosxdcxausxdes(string V_CODIGO, string V_DESCRIPCION, string V_DESTINO_COMPRA, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listaproyectosxdcxausxdes(V_CODIGO, V_DESCRIPCION, V_DESTINO_COMPRA, UserName, v_ambiente);
        }

        public DataTable listatalleresxcodxdescr(string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listatalleresxcodxdescr(V_DESCRIPCION, UserName, v_ambiente);
        }

        public DataTable listatrabxcodxdescr(string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listatrabxcodxdescr(V_CODIGO, V_DESCRIPCION, UserName, v_ambiente);
        }

        public DataTable listacc_xceo(string N_COD_EMP, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listacc_xceo(N_COD_EMP, UserName, v_ambiente);
        }

        public DataTable listalotedetraccxcodigo(string V_CODIGO, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listalotedetraccxcodigo(V_CODIGO, UserName, v_ambiente);
        }

        public DataTable listaliquidacionesxanio(string V_ANIO, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listaliquidacionesxanio(V_ANIO, UserName, v_ambiente);
        }

        public DataTable listaclasematxcodxdescrip(string V_NOMBRE, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listaclasematxcodxdescrip(V_NOMBRE, UserName, v_ambiente);
        }

        public DataTable listamatxcodxdescrip(string V_NOMBRE, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listamatxcodxdescrip(V_NOMBRE, UserName);
        }

        public DataTable listacotizocxcodxdescrip(string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listacotizocxcodxdescrip(V_CODIGO, V_DESCRIPCION, UserName, v_ambiente);
        }

        public DataTable listapgamxcodxdescrip(string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listapgamxcodxdescrip(V_CODIGO, V_DESCRIPCION, UserName, v_ambiente);
        }

        public DataTable listaproyectosxcodxdescri(string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listaproyectosxcodxdescri(V_CODIGO, V_DESCRIPCION, UserName, v_ambiente);
        }

        public DataTable listatipo_servicios(string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listatipo_servicios(V_DESCRIPCION, UserName, v_ambiente);
        }

        public DataTable listacartolasxanioxmesxmo(string V_ANIO, string V_MES, string V_MONEDA, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listacartolasxanioxmesxmo(V_ANIO, V_MES, V_MONEDA, UserName, v_ambiente);
        }

        public DataTable sp_listacc_xceo_nombre(string N_COD_EMP, string V_NOMBRE_CC, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).sp_listacc_xceo_nombre(N_COD_EMP, V_NOMBRE_CC, UserName, v_ambiente);
        }

        public DataTable listaprov_pdtepagoxrucxde(string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listaprov_pdtepagoxrucxde(V_CODIGO, V_DESCRIPCION, UserName, v_ambiente);
        }

        public DataTable listaproyec_pdtepagoxdesc(string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listaproyec_pdtepagoxdesc(V_DESCRIPCION, UserName, v_ambiente);
        }

        public DataTable listacentro_opera01(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listacentro_opera01(UserName, v_ambiente);
        }

        public DataTable listacentro_costos02(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listacentro_costos02(UserName, v_ambiente);
        }

        public DataTable listaalmacenes24(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listaalmacenes24(UserName, v_ambiente);
        }

        public DataTable listatipo_stock25(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listatipo_stock25(UserName, v_ambiente);
        }

        public DataTable listaprocedencia_compra26(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listaprocedencia_compra26(UserName, v_ambiente);
        }

        public DataTable listafin_compra27(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listafin_compra27(UserName, v_ambiente);
        }

        public DataTable listaestado_ocompra28(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listaestado_ocompra28(UserName, v_ambiente);
        }

        public DataTable listaclasif_rotacionmat29(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listaclasif_rotacionmat29(UserName, v_ambiente);
        }

        public DataTable listalineas_simaperu30(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listalineas_simaperu30(UserName, v_ambiente);
        }

        public DataTable listatipo_ocompra31(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listatipo_ocompra31(UserName, v_ambiente);
        }

        public DataTable listadest_valesm32(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listadest_valesm32(UserName, v_ambiente);
        }

        public DataTable listatipo_recurso33(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listatipo_recurso33(UserName, v_ambiente);
        }

        public DataTable listadecisión34(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listadecisión34(UserName, v_ambiente);
        }

        public DataTable listadecision68(string UserName)
        {
            return (new InformacionGeneralNTAD()).listadecision68(UserName);
        }

        public DataTable listaestado_registro35(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listaestado_registro35(UserName, v_ambiente);
        }

        public DataTable listatipo_proveedor36(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listatipo_proveedor36(UserName, v_ambiente);
        }

        public DataTable listatipo_reportot37(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listatipo_reportot37(UserName, v_ambiente);
        }

        public DataTable listaestado_ot38(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listaestado_ot38(UserName, v_ambiente);
        }

        public DataTable listatipo_reportacti39(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listatipo_reportacti39(UserName, v_ambiente);
        }

        public DataTable listameses40(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listameses40(UserName, v_ambiente);
        }

        public DataTable listamonedas41(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listamonedas41(UserName, v_ambiente);
        }

        public DataTable listatipo_egresos42(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).listatipo_egresos42(UserName, v_ambiente);
        }

        public DataTable ListaLineas(string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).ListaLineas(UserName, v_ambiente);
        }

        public DataTable SP_ListaLineas_NegxCEO(string V_CODIGO, string UserName, string v_ambiente = "T", string V_UNI_OPE = "")
        {
            return (new InformacionGeneralNTAD()).SP_ListaLineas_NegxCEO(V_CODIGO, UserName, v_ambiente, V_UNI_OPE);
        }

        public DataTable ListaLineasNegxCEOxUO(string V_CEO, string V_UNDOPE, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListaLineasNegxCEOxUO(V_CEO, V_UNDOPE, UserName);
        }

        public DataTable ListaLineaxCEOxSubLinea(string V_CEO, string V_SUBLINEA, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListaLineaxCEOxSubLinea(V_CEO, V_SUBLINEA, UserName);
        }

        public DataTable ListaSubLineasNegxCEOxUOxL(string V_CEO, string V_UNDOPE, string V_LINEA, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListaSubLineasNegxCEOxUOxL(V_CEO, V_UNDOPE, V_LINEA, UserName);
        }

        public DataTable ListaUnidad_OpexCEO(string V_CODIGO, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).ListaUnidad_OpexCEO(V_CODIGO, UserName, v_ambiente);
        }

        public DataTable ListaSubLineasCallao(string UserName)
        {
            return (new InformacionGeneralNTAD()).ListaSubLineasCallao(UserName);
        }

        public DataTable ListaUserUnisysxNom(string v_descripcion, string UserName, string v_ambiente = "T")
        {
            return (new InformacionGeneralNTAD()).ListaUserUnisysxNom(v_descripcion, UserName, v_ambiente);
        }

        public DataTable ListaContabCuentas(string V_NOMBRE, string V_PERIODO, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListaContabCuentas(V_NOMBRE, V_PERIODO, UserName);
        }

        public DataTable ListaContabCuentaSinPeriodo(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListaContabCuentaSinPeriodo(V_NOMBRE, UserName);
        }

        public DataTable ListaContabCuentaMayor(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListaContabCuentaMayor(V_NOMBRE, UserName);
        }

        public DataTable ListaSubDiario(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListaSubDiario(V_NOMBRE, UserName);
        }

        public DataTable ListaProveedores(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListaProveedores(V_NOMBRE, UserName);
        }

        public DataTable TipoDocumento(string UserName)
        {
            return (new InformacionGeneralNTAD()).TipoDocumento(UserName);
        }

        public DataTable TipoPlanillaMOB(string UserName)
        {
            return (new InformacionGeneralNTAD()).TipoPlanillaMOB(UserName);
        }

        public DataTable ListaAreasUsuariaxLN(string sLinea, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListaAreasUsuariaxLN(sLinea, UserName);
        }

        public DataTable TipoConformidadPlanMOB(string UserName)
        {
            return (new InformacionGeneralNTAD()).TipoConformidadPlanMOB(UserName);
        }

        public DataTable TipoBien(string UserName)
        {
            return (new InformacionGeneralNTAD()).TipoBien(UserName);
        }

        public DataTable TipoOrden(string UserName)
        {
            return (new InformacionGeneralNTAD()).TipoOrden(UserName);
        }

        public DataTable ListaProyectosSinDep(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD().ListaProyectosSinDep(V_NOMBRE, UserName));
        }

        public DataTable ListaProyectosxLinea(string S_Nombre, string S_Linea, string UserName)
        {
            return (new InformacionGeneralNTAD().ListaProyectosxLinea(S_Nombre, S_Linea, UserName));
        }

        public DataTable ListaMeses50(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD().ListaMeses50(V_NOMBRE, UserName));
        }

        public DataTable ListaUnidades(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD().ListaUnidades(V_NOMBRE, UserName));
        }

        public DataTable ListaUnidades2(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD().ListaUnidades2(V_NOMBRE, UserName));
        }

        public DataTable ListaMonedaMulti(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD().ListaMonedaMulti(V_NOMBRE, UserName));
        }

        public DataTable BuscarRecursos35(string V_DESCRIPCION, string UserName)
        {
            return (new InformacionGeneralNTAD().BuscarRecursos35(V_DESCRIPCION, UserName));
        }

        public DataTable Origen(string UserName)
        {
            return (new InformacionGeneralNTAD().Origen(UserName));
        }

        public DataTable OrigenLt(string V_DESCRIPCION, string UserName)
        {
            return (new InformacionGeneralNTAD().OrigenLt(V_DESCRIPCION, UserName));
        }

        public DataTable TipoDocumentoLt(string V_DESCRIPCION, string UserName)
        {
            return (new InformacionGeneralNTAD().TipoDocumentoLt(V_DESCRIPCION, UserName));
        }

        public DataTable ListaDoc_Estado(string UserName)
        {
            return (new InformacionGeneralNTAD().ListaDoc_Estado(UserName));
        }

        public DataTable ListaTipo_GastosDOT(string UserName)
        {
            return (new InformacionGeneralNTAD().ListaTipo_GastosDOT(UserName));
        }

        public DataTable LineasNegocioLt(string V_DESCRIPCION, string UserName)
        {
            return (new InformacionGeneralNTAD().LineasNegocioLt(V_DESCRIPCION, UserName));
        }

        public DataTable listalineas_simaperu30Multi(string V_DESCRIPCION, string UserName)
        {
            return (new InformacionGeneralNTAD().listalineas_simaperu30Multi(V_DESCRIPCION, UserName));
        }

        public DataTable Lista_CodigoCorte(string UserName)
        {
            return (new InformacionGeneralNTAD().Lista_CodigoCorte(UserName));
        }

        public DataTable Listar_GrupoBienesDropdown(string UserName)
        {
            return (new InformacionGeneralNTAD()).Listar_GrupoBienesDropdown(UserName);
        }

        public DataTable Listar_SubGrupoBienesDropdown(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD()).Listar_SubGrupoBienesDropdown(V_NOMBRE, UserName);
        }

        public DataTable Listar_SubGrupoBienesT(string UserName)
        {
            return (new InformacionGeneralNTAD()).Listar_SubGrupoBienesT(UserName);
        }

        public DataTable Listar_EmbarquePorOC(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD()).Listar_EmbarquePorOC(V_NOMBRE, UserName);
        }

        public DataTable Listar_TipoMOB(string UserName)
        {
            return (new InformacionGeneralNTAD()).Listar_TipoMOB(UserName);
        }

        public DataTable Listar_UsuariosPorNombre(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD()).Listar_UsuariosPorNombre(V_NOMBRE, UserName);
        }

        public DataTable Listar_CodigoOT(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD()).Listar_CodigoOT(V_NOMBRE, UserName);
        }

        public DataTable Listar_NumeroVDE(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD()).Listar_NumeroVDE(V_NOMBRE, UserName);
        }

        public DataTable Listar_NumeroGuiaPorOC(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD()).Listar_NumeroGuiaPorOC(V_NOMBRE, UserName);
        }

        public DataTable Listar_ESTADO_VDE(string UserName)
        {
            return (new InformacionGeneralNTAD()).Listar_ESTADO_VDE(UserName);
        }

        public DataTable Listar_TipoCentroCosto(string UserName)
        {
            return (new InformacionGeneralNTAD()).Listar_TipoCentroCosto(UserName);
        }

        public DataTable ListaTipo_Trabajo(string UserName, string sAmbiente = "T")
        {
            return (new InformacionGeneralNTAD()).ListaTipo_Trabajo(UserName, sAmbiente);
        }

        public DataTable ListaEstado_SolTrabxCEO(string V_CEO, string UserName, string sAmbiente = "T")
        {
            return (new InformacionGeneralNTAD()).ListaEstado_SolTrabxCEO(V_CEO, UserName, sAmbiente);
        }

        public DataTable ListaTipo_SolTrab(string UserName, string sAmbiente = "T")
        {
            return (new InformacionGeneralNTAD()).ListaTipo_SolTrab(UserName, sAmbiente);
        }

        public DataTable ListaClase_Trabajo(string UserName, string sAmbiente = "T")
        {
            return (new InformacionGeneralNTAD()).ListaClase_Trabajo(UserName, sAmbiente);
        }

        public DataTable ListaDiques(string V_CEO, string UserName, string sAmbiente = "T")
        {
            return (new InformacionGeneralNTAD()).ListaDiques(V_CEO, UserName, sAmbiente);
        }

        public DataTable ListaTipo_TarifaDique(string UserName, string sAmbiente = "T")
        {
            return (new InformacionGeneralNTAD()).ListaTipo_TarifaDique(UserName, sAmbiente);
        }

        public DataTable ListaSubLinea_Trabajo(string s_SubCEO, string s_LineaTrab, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListaSubLinea_Trabajo(s_SubCEO, s_LineaTrab, UserName);
        }

        public DataTable Lista_AreaUsuariaxLNxCLS(string V_LINEA, string V_ClaseT, string UserName)
        {
            return (new InformacionGeneralNTAD()).Lista_AreaUsuariaxLNxCLS(V_LINEA, V_ClaseT, UserName);
        }

        public DataTable Lista_SG_ELE_TAB(string V_TAB, string UserName)
        {
            return (new InformacionGeneralNTAD()).Lista_SG_ELE_TAB(V_TAB, UserName);
        }

        public DataTable Lista_PAIS_DPT_PROV_DIST(string V_OPCION, string V_VAR, string UserName)
        {
            return (new InformacionGeneralNTAD()).Lista_PAIS_DPT_PROV_DIST(V_OPCION, V_VAR, UserName);
        }

        public DataTable Lista_get_tabgeneral(string N_TAB, string C_ESTA, string UserName, string sAmbiente = "T")
        {
            return (new InformacionGeneralNTAD()).Lista_get_tabgeneral(N_TAB, C_ESTA, UserName, sAmbiente);
        }

        public DataTable Lista_get_ciiu(string UserName)
        {
            return (new InformacionGeneralNTAD()).Lista_get_ciiu(UserName);
        }

        public string GetCodUbigeoByDesc(string ubigeo_desc, string sAmbiente = "T")
        {
            return (new InformacionGeneralNTAD()).GetCodUbigeoByDesc(ubigeo_desc, sAmbiente);
        }

        public DataTable listaTipoProyecto(string V_CEO, string UserName)
        {
            return (new InformacionGeneralNTAD()).listaTipoProyecto(V_CEO, UserName);
        }

        public DataTable Lista_ColumnasExcel(string V_PROCEDIMIENTO)
        {
            return (new InformacionGeneralNTAD()).Lista_ColumnasExcel(V_PROCEDIMIENTO);
        }

        public DataTable TipoImpresora(string UserName)
        {
            return (new InformacionGeneralNTAD()).TipoImpresora(UserName);
        }

        public DataTable ListaOperaciones_Lst(string V_DESCRIPCION, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListaOperaciones_Lst(V_DESCRIPCION, UserName);
        }

        public DataTable Listar_Reg_TabGeneral(string V_COD_TABLA, string V_ESTADO, string V_ORDEN, string UserName)
        {
            return (new InformacionGeneralNTAD()).Listar_Reg_TabGeneral(V_COD_TABLA, V_ESTADO, V_ORDEN, UserName);
        }

        public DataTable ConsultarTrabajadorXApellido(string ApellidoyNombres, string UserName)
        {
            return (new InformacionGeneralNTAD()).ConsultarTrabajadorXApellido(ApellidoyNombres, UserName);
        }

        public DataTable ListarAreaYPseudoArea(string NombreArea, string nCEO, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListarAreaYPseudoArea(NombreArea, nCEO, UserName);
        }

        public DataTable ListarProveedoresSIMANET(string V_NOMBRE, string V_CRITERIO, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListarProveedoresSIMANET(V_NOMBRE, V_CRITERIO, UserName);
        }

        public DataTable BuscarPersonal(string V_NOMBRE, string UserName)
        {
            return (new InformacionGeneralNTAD()).BuscarPersonal(V_NOMBRE, UserName);

        }
    }
}
