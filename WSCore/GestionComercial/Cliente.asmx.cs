using Controladora.General;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using Controladora.GestionComercial;
using EntidadNegocio.GestionComercial;

namespace WSCore.GestionComercial
{
    /// <summary>
    /// Descripción breve de Cliente
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Cliente : System.Web.Services.WebService
    {
        string sAmbiente = ConfigurationManager.AppSettings["Ambiente"];

        [WebMethod(Description = "Busca los Clientes en la BD del SIMANET")]
        public DataTable BuscarCliente(string RazonSocialCliente, string UserName)
        {
            return ((new CCliente()).Buscar(RazonSocialCliente, UserName));
        }

        [WebMethod(Description = "Busqueda de cliente multi CEO")]
        public DataTable ListarClientes(string N_OPCION, string V_FILTRO, string V_CEO, string V_UND_OPER, string UserName)
        {
            return (new cCliente()).ListarClientes(N_OPCION, V_FILTRO, V_CEO, V_UND_OPER, UserName, sAmbiente);
        }

        [WebMethod(Description = "Busca un registro de la tabla cliente por ID")]
        public ClienteBE ListarClientePorId(string V_CLIENTE_ID, string UserName)
        {
            return (ClienteBE)(new cCliente()).ListarClientePorId(V_CLIENTE_ID, UserName, sAmbiente);
        }

        [WebMethod(Description = "Generar o actualizar cliente")]
        public string InsertarCliente(
            string X_TIP_CLI, string X_NOM_APS, string X_CIIU, string X_PAIS, string X_DOCUM_EXT,
            string X_NRO_RUC, string X_COD_PRC, string X_ENT_CLI, string X_UBC_GEO, string X_DIR_LGL, string X_EST_ATL,
            string X_TLX1, string X_TLX2, string X_COD_USR, string X_COD_USR_INA, string X_V_CLI_AUDITORIA, string ACCION, string X_V_CLIENTE_ID)
        {

            ClienteBE oClienteBE = new ClienteBE
            {
                TIP_CLI = X_TIP_CLI,
                NOM_APS = X_NOM_APS,
                CIIU = X_CIIU,
                PAIS = X_PAIS,
                DOCUM_EXT = X_DOCUM_EXT,
                NRO_RUC = string.IsNullOrEmpty(X_NRO_RUC) ? 0 : Convert.ToInt64(X_NRO_RUC),
                COD_PRC = X_COD_PRC,
                ENT_CLI = X_ENT_CLI,
                UBC_GEO = X_UBC_GEO,
                DIR_LGL = X_DIR_LGL,
                EST_ATL = X_EST_ATL,
                TLX1 = X_TLX1,
                TLX2 = X_TLX2,
                V_CLIENTE_ID = X_V_CLIENTE_ID,
                COD_USR = X_COD_USR,
                COD_USR_INA = X_COD_USR_INA,
                V_CLI_AUDITORIA = X_V_CLI_AUDITORIA
            };
            string result = (new cCliente()).InsertarCliente(oClienteBE, ACCION, sAmbiente);

            return result;
        }

        [WebMethod(Description = "Generar o actualizar contacto de un cliente")]
        public string InsertarContactoCliente(string X_C_CLIE_CODCARGO,
            string X_C_CLIE_NOMBRE, string X_C_CLIE_TELEF1, string X_C_CLIE_TELEF2, string X_C_CLIE_FECHANAC, string X_C_CLIE_EMAIL,
            string X_C_CLIE_TIPOENVIO, string X_V_CLIENTE_ID, string X_N_CLIE_IDCONTACTO, string opcion)
        {
            ContactoClienteBE oContactoClienteBE = new ContactoClienteBE
            {
                V_CLIENTE_ID = X_V_CLIENTE_ID,
                C_CLIE_CODCARGO = X_C_CLIE_CODCARGO,
                C_CLIE_NOMBRE = X_C_CLIE_NOMBRE,
                C_CLIE_TELEF1 = X_C_CLIE_TELEF1,
                C_CLIE_TELEF2 = X_C_CLIE_TELEF2,
                C_CLIE_FECHANAC = X_C_CLIE_FECHANAC,
                C_CLIE_EMAIL = X_C_CLIE_EMAIL,
                C_CLIE_TIPOENVIO = X_C_CLIE_TIPOENVIO,
                N_CLIE_IDCONTACTO = (X_N_CLIE_IDCONTACTO == "") ? 0 : Convert.ToInt32(X_N_CLIE_IDCONTACTO)
            };

            string result = (new cCliente()).InsertarContactoCliente(oContactoClienteBE, opcion, sAmbiente);

            return result;
        }

        [WebMethod(Description = "Generar o actualizar contacto de un cliente")]
        public DataTable ListarContactosDeCliente(string X_V_CLIENTE_ID)
        {

            return (new cCliente()).ListarContactosDeCliente(X_V_CLIENTE_ID, sAmbiente);
        }

        [WebMethod(Description = "Elimina un contacto de cliente")]
        public string EliminarContactoCliente(string v_cliente_id, string contacto_id)
        {

            return (new cCliente()).EliminarContactoCliente(v_cliente_id, contacto_id, sAmbiente);
        }

        [WebMethod(Description = "Inserta o actualiza una embarcacion")]
        public string InsertarEmbarcacion(
            string X_NOM_UND, string X_TIP_UND, string X_EST_ATL, string X_COD_USR
            , string X_CODCOPE, string X_NOMBREANTERIOR, string X_TIPO, string X_ASTILLERO_CONSTRUCTOR,
            string X_MATRICULA, string X_ID_MATERIAL, string X_FEC_INGRESO,
            string X_OBSERVACION, string X_ESLORA, string X_MANGA, string X_PUNTAL, string X_BODEGA,
            string X_SISTEMAPESCA, string X_MOTOR, string X_V_EMBARCACION_ID, string X_V_CLIENTE_ID, string ACCION)
        {

            EmbarcacionBE oEmbarcacionBE = new EmbarcacionBE
            {
                NOM_UND = X_NOM_UND,
                TIP_UND = X_TIP_UND,
                EST_ATL = X_EST_ATL,
                COD_USR = X_COD_USR,
                CODCOPE = X_CODCOPE,
                NOMBREANTERIOR = X_NOMBREANTERIOR,
                TIPO = X_TIPO,
                ASTILLERO_CONSTRUCTOR = X_ASTILLERO_CONSTRUCTOR,
                MATRICULA = X_MATRICULA,
                ID_MATERIAL = X_ID_MATERIAL,
                FEC_INGRESO = X_FEC_INGRESO,
                OBSERVACION = X_OBSERVACION,
                ESLORA = X_ESLORA,
                MANGA = X_MANGA,
                PUNTAL = X_PUNTAL,
                BODEGA = X_BODEGA,
                SISTEMAPESCA = X_SISTEMAPESCA,
                MOTOR = X_MOTOR,
                V_EMBARCACION_ID = X_V_EMBARCACION_ID,
                V_CLIENTE_ID = X_V_CLIENTE_ID
            };

            string result = (new cCliente()).InsertarEmbarcacion(oEmbarcacionBE, ACCION, sAmbiente);

            return result;
        }

        [WebMethod(Description = "Inserta o actualiza registros del detalle de una embarcacion")]
        public string InsertarDetalleEmbarcacion(
            string X_EMBARCACION_ID, string X_IDAREA, string X_VALOR, string X_FECHAREGISTRO, string X_UM)
        {
            DetalleEmbarcacionBE oDetalleEmbarcacionBE = new DetalleEmbarcacionBE
            {
                V_EMBARCACION_ID = X_EMBARCACION_ID,
                N_IDAREA = X_IDAREA,
                N_VALOR = X_VALOR,
                DA_FECHAREGISTRO = X_FECHAREGISTRO,
                C_UM = X_UM
            };

            string result = (new cCliente()).InsertarDetalleEmbarcacion(oDetalleEmbarcacionBE, sAmbiente);

            return result;
        }

        [WebMethod(Description = "Filtra la tabla  TB_EMBARCACIONESDATOS en funcion de V_EMBARCACION_ID")]
        public DataTable ListarDetalleDeEmbarcacionPorID(string X_V_EMBARCACION_ID)
        {

            return (new cCliente()).ListarDetalleDeEmbarcacionPorID(X_V_EMBARCACION_ID, sAmbiente);
        }

        [WebMethod(Description = "Busca un registro de la tabla PD_UND_CLI por ID")]
        public EmbarcacionBE ListarEmbarcacionPorId(string V_EMBARCACION_ID, string UserName)
        {
            return (EmbarcacionBE)(new cCliente()).ListarEmbarcacionPorId(V_EMBARCACION_ID, UserName, sAmbiente);
        }

        [WebMethod(Description = "Lista de embarcaciones")]
        public string ListarEmbarcaciones(string V_FILTRO)
        {
            try
            {
                DataTable dt = (new cEmbarcaciones()).ListarEmbarcaciones(V_FILTRO, sAmbiente);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "PR_GET_EMBARCACIONES";

                DataSet dset = new DataSet();
                dset.Tables.Add(dtCopy);

                using (StringWriter sw = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sw))
                    {
                        dset.WriteXml(writer, XmlWriteMode.IgnoreSchema);
                        return sw.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new HttpException(500, "Error interno del servidor", ex);
            }
        }

        [WebMethod(Description = "Genera el codigo de la embarcacion en funcion del v_cliente_id")]
        public string GEN_EMBARCACION_ID(string P_V_CLIENTE_ID)
        {
            return (new cCliente()).GEN_EMBARCACION_ID(P_V_CLIENTE_ID, sAmbiente);
        }

        [WebMethod(Description = "")]
        public DataTable BusquedaEmbarcacionyCliente(string V_NOMBRE, string UserName)
        {
            return (new cCliente()).BusquedaEmbarcacionyCliente(V_NOMBRE, sAmbiente, UserName);
        }

        [WebMethod(Description = "Busqueda de Cliente 3")]
        public DataTable ListaBuscarCliente3(string V_NOMBRE, string UserName)
        {
            return (new cCliente().ListaBuscarCliente3(V_NOMBRE, UserName));
        }

        [WebMethod]
        public DataTable listaclientesxcodxdescr(string V_CODIGO, string V_DESCRIPCION, string UserName)
        {
            return (new cCliente()).listaclientesxcodxdescr(V_CODIGO, V_DESCRIPCION, UserName, sAmbiente);
        }

        [WebMethod]
        public DataTable listaunidxcliexcodxdescr(string V_CLIENTE, string V_CODIGO, string V_DESCRIPCION, string UserName)
        {
            return (new cCliente()).listaunidxcliexcodxdescr(V_CLIENTE, V_CODIGO, V_DESCRIPCION, UserName, sAmbiente);
        }

        [WebMethod(Description = "Busqueda de Cliente")]
        public DataTable ListaBuscarCliente2(string V_NOMBRE, string UserName)
        {
            return (new cCliente().ListaBuscarCliente2(V_NOMBRE, UserName));
        }
    }
}
