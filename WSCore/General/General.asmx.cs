using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.General;
using EntidadNegocio.General;

namespace WSCore.General
{
    /// <summary>
    /// Descripción breve de General
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class General : System.Web.Services.WebService
    {
        private string sAmbiente;
            
        public General()
        {
            sAmbiente = ConfigurationManager.AppSettings["Ambiente"];
            if (string.IsNullOrEmpty(sAmbiente))
            {
                throw new Exception("El valor de 'Ambiente' no está configurado en el archivo web.config.");
            }
        }

        [WebMethod(Description = "lista Centros de Costo por nombre o código")]
        public DataTable ListarCentrosCosto(string N_COD_EMP, string V_NOMBRE_CC, string UserName)
        {
            return ((new cCentroCosto()).BuscarCentrosCosto(N_COD_EMP, V_NOMBRE_CC, UserName));
        }
        /* repetido
        [WebMethod(Description = "lista Centros de Costo por nombre o código")]
        public DataTable ListarCentrosCosto(string NombreCC, string UserName)
        {
            return ((new cCentroCosto()).BuscarCentrosCosto(NombreCC, UserName));
        }
        */
        [WebMethod]
        public DataTable ListarItemTablas(string IdTablaGeneral, string UserName)
        {

            return (new CItemTablaGeneral()).ListarTodos(IdTablaGeneral, UserName);
        }

        [WebMethod(Description = "Buscar Clientes")]
        public DataTable BuscarCliente(string RazonSocial, string UserName)
        {
            return (new CCliente()).Buscar(RazonSocial, UserName);
        }
        [WebMethod(Description = "Listar Tablas de Apoyo por modulo")]
        public DataTable ListarTablasdeApoyo(string IdtblModulo, string UserName)
        {
            return (new CItemTablaGeneral()).ListarTablasdeApoyo(IdtblModulo, UserName);
        }

        [WebMethod(Description = "Mantenimiento de Tabla tablas Items")]
        public int InsertaModificaItemsTabla(TablaItemBE oTablaItemBE)
        {
            return (new CItemTablaGeneral()).Modificar(oTablaItemBE);
        }

        [WebMethod(Description = "Gestion de la Configuracion")]
        public DataTable ListarOpcionesConfiguracion(string PageName, string UserName)
        {
            return (new CItemTablaGeneral()).ListaConfiguracion(PageName, UserName);
        }

        [WebMethod(Description = "Lista de Centros Operativos por Perfil")]
        public DataTable ListarCentroOperativoPorPerfil(string IdUsuario, string UserName)
        {
            return ((new cCentroCosto()).ListarCentroOperativoPorPerfil(IdUsuario, UserName));
        }

        [WebMethod]
        public DataTable listactactexcodbanco(string V_NOMBRE, string V_CODIGO, string UserName)
        {
            return (new cGeneralParam()).listactactexcodbanco(V_NOMBRE, V_CODIGO, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listabancosxcodxdescr(string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam()).listabancosxcodxdescr(V_DESCRIPCION, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listatalleresxcodxdescr(string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam()).listatalleresxcodxdescr(V_DESCRIPCION, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listatrabxcodxdescr(string V_CODIGO, string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam()).listatrabxcodxdescr(V_CODIGO, V_DESCRIPCION, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listacc_xceo(string N_COD_EMP, string UserName)
        {
            return (new cGeneralParam()).listacc_xceo(N_COD_EMP, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listalotedetraccxcodigo(string V_CODIGO, string UserName)
        {
            return (new cGeneralParam()).listalotedetraccxcodigo(V_CODIGO, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listaliquidacionesxanio(string V_ANIO, string UserName)
        {
            return (new cGeneralParam()).listaliquidacionesxanio(V_ANIO, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listaclasematxcodxdescrip(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam()).listaclasematxcodxdescrip(V_NOMBRE, UserName, sAmbiente);
        }

        [WebMethod(Description = "Lista Materiales por  Código y descripción")]
        public DataTable listamatxcodxdescrip(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam()).listamatxcodxdescrip(V_NOMBRE, UserName);
        }

        [WebMethod]
        public DataTable listacotizocxcodxdescrip(string V_CODIGO, string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam()).listacotizocxcodxdescrip(V_CODIGO, V_DESCRIPCION, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listapgamxcodxdescrip(string V_CODIGO, string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam()).listapgamxcodxdescrip(V_CODIGO, V_DESCRIPCION, UserName, sAmbiente);
        }

        [WebMethod(Description = "Proyectos - Sin Dependencia")]
        public DataTable ListaProyectosSinDep(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam().ListaProyectosSinDep(V_NOMBRE, UserName));
        }

        [WebMethod(Description = "Proyectos - por Linea Negocio")]
        public DataTable ListaProyectosxLinea(string S_NOMBRE, string S_LINEA, string UserName)
        {
            return (new cGeneralParam().ListaProyectosxLinea(S_NOMBRE, S_LINEA, UserName));
        }
        [WebMethod]
        public DataTable listaproyectosxcodxdescri(string V_CODIGO, string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam()).listaproyectosxcodxdescri(V_CODIGO, V_DESCRIPCION, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listaproyectosxdcxausxdes(string V_CODIGO, string V_DESCRIPCION, string V_DESTINO_COMPRA, string UserName)
        {
            return (new cGeneralParam()).listaproyectosxdcxausxdes(V_CODIGO, V_DESCRIPCION, V_DESTINO_COMPRA, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listatipo_servicios(string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam()).listatipo_servicios(V_DESCRIPCION, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listacartolasxanioxmesxmo(string V_ANIO, string V_MES, string V_MONEDA, string UserName)
        {
            return (new cGeneralParam()).listacartolasxanioxmesxmo(V_ANIO, V_MES, V_MONEDA, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listaprov_pdtepagoxrucxde(string V_CODIGO, string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam()).listaprov_pdtepagoxrucxde(V_CODIGO, V_DESCRIPCION, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listaproyec_pdtepagoxdesc(string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam()).listaproyec_pdtepagoxdesc(V_DESCRIPCION, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listacentro_opera01(string UserName)
        {
            return (new cGeneralParam()).listacentro_opera01(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listacentro_costos02(string UserName)
        {
            return (new cGeneralParam()).listacentro_costos02(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listaalmacenes24(string UserName)
        {
            return (new cGeneralParam()).listaalmacenes24(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listatipo_stock25(string UserName)
        {
            return (new cGeneralParam()).listatipo_stock25(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listaprocedencia_compra26(string UserName)
        {
            return (new cGeneralParam()).listaprocedencia_compra26(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listafin_compra27(string UserName)
        {
            return (new cGeneralParam()).listafin_compra27(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listaestado_ocompra28(string UserName)
        {
            return (new cGeneralParam()).listaestado_ocompra28(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listaclasif_rotacionmat29(string UserName)
        {
            return (new cGeneralParam()).listaclasif_rotacionmat29(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listalineas_simaperu30(string UserName)
        {
            return (new cGeneralParam()).listalineas_simaperu30(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listatipo_ocompra31(string UserName)
        {
            return (new cGeneralParam()).listatipo_ocompra31(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listadest_valesm32(string UserName)
        {
            return (new cGeneralParam()).listadest_valesm32(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listatipo_recurso33(string UserName)
        {
            return (new cGeneralParam()).listatipo_recurso33(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listadecisión34(string UserName)
        {
            return (new cGeneralParam()).listadecisión34(UserName, sAmbiente);
        }

        [WebMethod(Description = "Muestra las opciones de decisión: TODOS o NINGUNO")]
        public DataTable listadecision68(string UserName)
        {
            return (new cGeneralParam()).listadecision68(UserName);
        }

        [WebMethod]
        public DataTable listaestado_registro35(string UserName)
        {
            return (new cGeneralParam()).listaestado_registro35(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listatipo_proveedor36(string UserName)
        {
            return (new cGeneralParam()).listatipo_proveedor36(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listatipo_reportot37(string UserName)
        {
            return (new cGeneralParam()).listatipo_reportot37(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listaestado_ot38(string UserName)
        {
            return (new cGeneralParam()).listaestado_ot38(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listatipo_reportacti39(string UserName)
        {
            return (new cGeneralParam()).listatipo_reportacti39(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listameses40(string UserName)
        {
            return (new cGeneralParam()).listameses40(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listamonedas41(string UserName)
        {
            return (new cGeneralParam()).listamonedas41(UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listatipo_egresos42(string UserName)
        {
            return (new cGeneralParam()).listatipo_egresos42(UserName, sAmbiente);
        }

        [WebMethod(Description = "Lista Líneas de Negocio")]
        public DataTable ListaLineas(string UserName)
        {
            return (new cGeneralParam()).ListaLineas(UserName, sAmbiente);
        }

        [WebMethod(Description = "Lista Líneas de Negocio por Centro Operativo")]
        public DataTable SP_ListaLineas_NegxCEO(string V_CODIGO, string V_UNI_OPE, string UserName)
        {
            if (string.IsNullOrEmpty(V_UNI_OPE))
            {
                V_UNI_OPE = "C";
            }

            return (new cGeneralParam()).SP_ListaLineas_NegxCEO(V_CODIGO, UserName, sAmbiente, V_UNI_OPE);
        }

        [WebMethod(Description = "Lista Líneas de Negocio por Centro Operativo y Unidad Operativa")]
        public DataTable ListaLineasNegxCEOxUO(string V_CEO, string V_UNDOPE, string UserName)
        {
            if (string.IsNullOrEmpty(V_UNDOPE) && V_CEO == "1")
            {
                V_UNDOPE = "C";
            }
            else if (string.IsNullOrEmpty(V_UNDOPE) && V_CEO == "3")
            {
                V_UNDOPE = "A";
            }

            return (new cGeneralParam()).ListaLineasNegxCEOxUO(V_CEO, V_UNDOPE, UserName); ;
        }

        [WebMethod(Description = "Lista Líneas de Negocio por Centro Operativo y Sublinea")]
        public DataTable ListaLineaxCEOxSubLinea(string V_CEO, string V_SUBLINEA, string UserName)
        {

            return (new cGeneralParam()).ListaLineaxCEOxSubLinea(V_CEO, V_SUBLINEA, UserName); ;
        }

        [WebMethod(Description = "Lista Unidad Operativa por Centro Operativo")]
        public DataTable ListaUnidad_OpexCEO(string V_CODIGO, string UserName)
        {
            return (new cGeneralParam()).ListaUnidad_OpexCEO(V_CODIGO, UserName, sAmbiente);
        }

        [WebMethod(Description = "Lista Sub Lineas por Centro Operativo, Unidad Operativa y Linea Negocio")]
        public DataTable ListaSubLineasNegxCEOxUOxL(string V_CEO, string V_UNDOPE, string V_LINEA, string UserName)
        {
            if (string.IsNullOrEmpty(V_UNDOPE) && V_CEO == "1")
            {
                V_UNDOPE = "C";
            }
            else if (string.IsNullOrEmpty(V_UNDOPE) && V_CEO == "3")
            {
                V_UNDOPE = "A";
            }

            return (new cGeneralParam()).ListaSubLineasNegxCEOxUOxL(V_CEO, V_UNDOPE, V_LINEA, UserName);
        }

        [WebMethod(Description = "Lista SubLineas Negocio Callao")]
        public DataTable ListaSubLineasCallao(string UserName)
        {
            return (new cGeneralParam()).ListaSubLineasCallao(UserName);
        }

        [WebMethod(Description = "Lista Usuarios sistema Unisys")]
        public DataTable ListaUserUnisysxNom(string v_descripcion, string UserName)
        {
            return (new cGeneralParam()).ListaUserUnisysxNom(v_descripcion, UserName, sAmbiente);
        }

        [WebMethod(Description = "Lista los nros de cuenta para procedimientos de Contabilidad")]
        public DataTable ListaContabCuentas(string V_NOMBRE, string V_PERIODO, string UserName)
        {
            return (new cGeneralParam()).ListaContabCuentas(V_NOMBRE, V_PERIODO, UserName);
        }

        [WebMethod(Description = "Lista los nros de cuenta mayor para procedimientos de Contabilidad")]
        public DataTable ListaContabCuentaMayor(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam()).ListaContabCuentaMayor(V_NOMBRE, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable ListaSubDiario(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam()).ListaSubDiario(V_NOMBRE, UserName);
        }

        [WebMethod(Description = "Lista los nros de cuenta para procedimientos de Contabilidad")]
        public DataTable ListaContabCuentaSinPeriodo(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam()).ListaContabCuentaSinPeriodo(V_NOMBRE, UserName);
        }

        [WebMethod(Description = "Lista de Provedores para obtener RUC")]
        public DataTable ListaProveedores(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam()).ListaProveedores(V_NOMBRE, UserName);
        }

        [WebMethod(Description = "Lista de Tipos de Documento")]
        public DataTable TipoDocumento(string UserName)
        {
            return (new cGeneralParam()).TipoDocumento(UserName);
        }


        [WebMethod(Description = "Lista de Tipos de Planilla de Mano de obra")]
        public DataTable TipoPlanillaMOB(string UserName)
        {
            return (new cGeneralParam()).TipoPlanillaMOB(UserName);
        }

        [WebMethod(Description = "Lista Áreas usuaria por Linea de Negocio")]
        public DataTable ListaAreasUsuariaxLN(string sLinea, string UserName)
        {
            return (new cGeneralParam()).ListaAreasUsuariaxLN(sLinea, UserName);
        }


        [WebMethod(Description = "Lista los Tipos de Conformidad de Planilla de Mano de obra")]
        public DataTable TipoConformidadPlanMOB(string UserName)
        {
            return (new cGeneralParam()).TipoConformidadPlanMOB(UserName);
        }

        [WebMethod(Description = "Lista los Tipos de Bien")]
        public DataTable TipoBien(string UserName)
        {
            return (new cGeneralParam()).TipoBien(UserName);
        }

        [WebMethod(Description = "Lista los Tipos de Orden")]
        public DataTable TipoOrden(string UserName)
        {
            return (new cGeneralParam()).TipoOrden(UserName);
        }

        [WebMethod(Description = "Meses - AutoComplete")]
        public DataTable ListaMeses50(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam().ListaMeses50(V_NOMBRE, UserName));
        }

        [WebMethod(Description = "Unidades - Autocomplete")]
        public DataTable ListaUnidades(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam().ListaUnidades(V_NOMBRE, UserName));
        }

        [WebMethod(Description = "Unidades 2 - Autocomplete")]
        public DataTable ListaUnidades2(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam().ListaUnidades2(V_NOMBRE, UserName));
        }

        [WebMethod(Description = "Moneda Multiple")]
        public DataTable ListaMonedaMulti(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam().ListaMonedaMulti(V_NOMBRE, UserName));
        }

        [WebMethod(Description = "Busqueda de Recursos")]
        public DataTable BuscarRecursos35(string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam().BuscarRecursos35(V_DESCRIPCION, UserName));
        }

        [WebMethod(Description = "Multiple Documento")]
        public DataTable TipoDocumentoLt(string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam().TipoDocumentoLt(V_DESCRIPCION, UserName));
        }

        [WebMethod(Description = "Multiple Origen")]
        public DataTable OrigenLt(string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam().OrigenLt(V_DESCRIPCION, UserName));
        }

        [WebMethod(Description = "Origen")]
        public DataTable Origen(string UserName)
        {
            return (new cGeneralParam().Origen(UserName));
        }

        [WebMethod(Description = "ListaDoc_Estado")]
        public DataTable ListaDoc_Estado(string UserName)
        {
            return (new cGeneralParam().ListaDoc_Estado(UserName));
        }

        [WebMethod(Description = "ListaTipo_GastosDOT")]
        public DataTable ListaTipo_GastosDOT(string UserName)
        {
            return (new cGeneralParam().ListaTipo_GastosDOT(UserName));
        }

        [WebMethod(Description = "LineasNegocioLt")]
        public DataTable LineasNegocioLt(string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam().LineasNegocioLt(V_DESCRIPCION, UserName));
        }

        [WebMethod]
        public DataTable listalineas_simaperu30Multi(string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam()).listalineas_simaperu30Multi(V_DESCRIPCION, UserName);
        }

        [WebMethod(Description = "Lista Codigos Corte de todos los años")]
        public DataTable Lista_CodigoCorte(string UserName)
        {
            return (new cGeneralParam().Lista_CodigoCorte(UserName));
        }

        [WebMethod]
        public DataTable Listar_GrupoBienesDropdown(string UserName)
        {
            return (new cGeneralParam()).Listar_GrupoBienesDropdown(UserName);
        }

        [WebMethod]
        public DataTable Listar_SubGrupoBienesDropdown(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam()).Listar_SubGrupoBienesDropdown(V_NOMBRE, UserName);
        }

        [WebMethod(Description = "Lista Todos los subgrupos de los bienes")]
        public DataTable Listar_SubGrupoBienesT(string UserName)
        {
            return (new cGeneralParam()).Listar_SubGrupoBienesT(UserName);
        }

        [WebMethod(Description = "Lista embarque segun OC")]
        public DataTable Listar_EmbarquePorOC(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam()).Listar_EmbarquePorOC(V_NOMBRE, UserName);
        }

        [WebMethod(Description = "Lista Tipo de Planilla de MOB")]
        public DataTable Listar_TipoMOB(string UserName)
        {
            return (new cGeneralParam()).Listar_TipoMOB(UserName);
        }

        [WebMethod(Description = "Lista usuarios y filtra por nombre")]
        public DataTable Listar_UsuariosPorNombre(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam()).Listar_UsuariosPorNombre(V_NOMBRE, UserName);
        }

        [WebMethod(Description = "Lista codigo OT y filtra por texto")]
        public DataTable Listar_CodigoOT(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam()).Listar_CodigoOT(V_NOMBRE, UserName);
        }

        [WebMethod(Description = "Listar numero de guia filtrado por OC")]
        public DataTable Listar_NumeroGuiaPorOC(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam()).Listar_NumeroGuiaPorOC(V_NOMBRE, UserName);
        }

        [WebMethod(Description = "Lista numero VDE")]
        public DataTable Listar_NumeroVDE(string V_NOMBRE, string UserName)
        {
            return (new cGeneralParam()).Listar_NumeroVDE(V_NOMBRE, UserName);
        }

        [WebMethod(Description = "Lista ESTADO VDE")]
        public DataTable Listar_ESTADO_VDE(string UserName)
        {
            return (new cGeneralParam()).Listar_ESTADO_VDE(UserName);
        }

        [WebMethod(Description = "Lista tipos de centro de costo")]
        public DataTable Listar_TipoCentroCosto(string UserName)
        {
            return (new cGeneralParam()).Listar_TipoCentroCosto(UserName);
        }

        [WebMethod(Description = "Lista tipo trabajo")]
        public DataTable ListaTipo_Trabajo(string UserName)
        {
            if (sAmbiente == null)
            {
                sAmbiente = "T";
            }
            return (new cGeneralParam()).ListaTipo_Trabajo(UserName, sAmbiente);
        }

        [WebMethod(Description = "Lista estados de la solicitud de trabajo por centro operativo")]
        public DataTable ListaEstado_SolTrabxCEO(string V_CEO, string UserName)
        {
            if (sAmbiente == null)
            {
                sAmbiente = "T";
            }
            return (new cGeneralParam()).ListaEstado_SolTrabxCEO(V_CEO, UserName, sAmbiente);
        }

        [WebMethod(Description = "Lista los tipos de solicitudes existentes")]
        public DataTable ListaTipo_SolTrab(string UserName)
        {
            if (sAmbiente == null)
            {
                sAmbiente = "T";
            }
            return (new cGeneralParam()).ListaTipo_SolTrab(UserName, sAmbiente);
        }

        [WebMethod(Description = "Lista clase de trabajos")]
        public DataTable ListaClase_Trabajo(string UserName)
        {
            if (sAmbiente == null)
            {
                sAmbiente = "T";
            }
            return (new cGeneralParam()).ListaClase_Trabajo(UserName, sAmbiente);
        }

        [WebMethod(Description = "lista diques por centro operativo")]
        public DataTable ListaDiques(string V_CEO, string UserName)
        {
            if (sAmbiente == null)
            {
                sAmbiente = "T";
            }
            return (new cGeneralParam()).ListaDiques(V_CEO, UserName, sAmbiente);
        }

        [WebMethod(Description = "Lista tipos de tarifas")]
        public DataTable ListaTipo_TarifaDique(string UserName)
        {
            if (sAmbiente == null)
            {
                sAmbiente = "T";
            }
            return (new cGeneralParam()).ListaTipo_TarifaDique(UserName, sAmbiente);
        }

        [WebMethod(Description = "Lista SubLinea de las lineas Trabajo por Subcentro Operativo y Lineas de trabajo")]
        public DataTable ListaSubLinea_Trabajo(string s_SubCEO, string s_LineaTrab, string UserName)
        {
            return (new cGeneralParam()).ListaSubLinea_Trabajo(s_SubCEO, s_LineaTrab, UserName);
        }

        [WebMethod(Description = "Lista las areas usuario por linea de negocio y clase")]
        public DataTable Lista_AreaUsuariaxLNxCLS(string V_LINEA, string V_ClaseT, string UserName)
        {
            return (new cGeneralParam()).Lista_AreaUsuariaxLNxCLS(V_LINEA, V_ClaseT, UserName);
        }

        [WebMethod(Description = "Lista los campos de la tabla SG_ELE_TAB en funcion del parametro COD_TAB")]
        public DataTable Lista_SG_ELE_TAB(string V_TAB, string UserName)
        {
            return (new cGeneralParam()).Lista_SG_ELE_TAB(V_TAB, UserName);
        }

        [WebMethod(Description = "Lista paises, departamente, provincias o distritos")]
        public DataTable Lista_PAIS_DPT_PROV_DIST(string V_OPCION, string V_VAR, string UserName)
        {
            return (new cGeneralParam()).Lista_PAIS_DPT_PROV_DIST(V_OPCION, V_VAR, UserName);
        }

        [WebMethod(Description = "Lista diferentes tipos de datos como tipo de cliente, tipo de trabajo,etc")]
        public DataTable Lista_get_tabgeneral(string N_TAB, string C_ESTA, string UserName)
        {
            return (new cGeneralParam()).Lista_get_tabgeneral(N_TAB, C_ESTA, UserName, sAmbiente);
        }

        [WebMethod(Description = "Lista los CIIU visibles")]
        public DataTable Lista_get_ciiu(string UserName)
        {
            return (new cGeneralParam()).Lista_get_ciiu(UserName);
        }

        [WebMethod(Description = "Devuelve el codigo de ubigeo en funcion de la descripcion ingresada")]
        public string GetCodUbigeoByDesc(string ubigeo_desc)
        {
            return (new cGeneralParam()).GetCodUbigeoByDesc(ubigeo_desc, sAmbiente);
        }

        [WebMethod(Description = "Lista los tipos de proyecto")]
        public DataTable listaTipoProyecto(string V_CEO, string UserName)
        {
            return (new cGeneralParam()).listaTipoProyecto(V_CEO, UserName);
        }

        [WebMethod(Description = "Lista las columnas que requieren conversion antes de generar el archivo Excel del reporte")]
        public DataTable Lista_ColumnasExcel(string V_PROCEDIMIENTO)
        {
            return (new cGeneralParam()).Lista_ColumnasExcel(V_PROCEDIMIENTO);
        }

        [WebMethod(Description = "Lista de Tipos de Impresora")]
        public DataTable TipoImpresora(string UserName)
        {
            return (new cGeneralParam()).TipoImpresora(UserName);
        }

        [WebMethod(Description = "Lista de Tipos de Operaciones de Pago")]
        public DataTable ListaOperaciones_Lst(string V_DESCRIPCION, string UserName)
        {
            return (new cGeneralParam()).ListaOperaciones_Lst(V_DESCRIPCION, UserName);
        }

        [WebMethod(Description = "lista Registros detalle de la Tabla general")]
        public DataTable Listar_Reg_TabGeneral(string V_COD_TABLA, string V_ESTADO, string V_ORDEN, string UserName)
        {
            return ((new cGeneralParam()).Listar_Reg_TabGeneral(V_COD_TABLA, V_ESTADO, V_ORDEN, UserName));
        }

        [WebMethod(Description = "Listar items de Tablas generales desde ORACLE")]
        public DataTable ListarTodosOracle(int IdtblModulo, string UserName)
        {
            return (new CItemTablaGeneral()).ListarTodosOracle(IdtblModulo, UserName);
        }

        [WebMethod(Description = "Listar items hijos de Tablas generales desde ORACLE")]
        public DataTable ListarItemChildxItemRelacionadoOracle(int IdTblPadre, int IdItemPadre, string UserName)
        {
            return (new CItemTablaGeneral()).ListarTodosOracle(IdTblPadre, IdItemPadre, UserName);
        }

    }
}
