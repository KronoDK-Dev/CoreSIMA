using Log;
using ManejadorException;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilitario;

namespace WSCore.Produccion
{
    /// <summary>
    /// Descripción breve de Produccion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Produccion : System.Web.Services.WebService
    {
        DataTable DT;
        private string c_pto = "";
        //  produccion:   String sServicio = "http://10.10.90.138:7060/xml_oracle/xml_api.";
        //  desarrollo:   String sServicio = "http://10.10.90.168:7060/xml_oracle/xml_api."; // antes
        //   String sServicio = "http://10.10.90.138:7060/xml_oracle/xml_api.";
        string MODULO = "";
        string UserName = "";

        // TODOS LAS INSTANCIAS APUNTAN AL MISMO SERVIDOR, Solo se diferencian en el nombre del metodo, si termina en: _test es para desarrollo
        readonly string sMetodo_lee = "get_planilla_test";
        readonly string sMetodo_envia = "post_planilla_test";

        readonly string sMetodo_lee_ok = "get_planilla";
        readonly string sMetodo_envia_ok = "post_planilla";

        // String sMetodo = "get_planilla?"; // En este metodo esta expuesta toda la información necesaria




        [WebMethod(Description = "Listado de Los Tipos de Planilla para la Conformidad de la Planilla de mano de obra")]
        public DataTable ListarTiposPlanilla()
        {
            prCargaCombos(2);
            if (DT is null)
            {
                prCargaCombos(2);
                return DT;
            }
            else
            {
                return DT;
            }
        }


        [WebMethod(Description = "Listado de Las Lineas de Negocio para la Planilla para la Conformidad de mano de obra")]
        public DataTable ListarLineasNegocio()
        {
            prCargaCombos(3);
            if (DT is null)
            {
                prCargaCombos(3);
                return DT;
            }
            else
            {
                return DT;
            }
        }

        [WebMethod(Description = "Listado de Los Niveles de Conformidad para la Planilla de Conformidad mano de obra")]
        public DataTable ListarNivelesConformidad()
        {
            prCargaCombos(4);
            if (DT is null)
            {
                prCargaCombos(4);
                return DT;
            }
            else
            {
                return DT;
            }
        }

        [WebMethod(Description = "Listado de Las Áreas Usuarias para la Conformidad de la Planilla de mano de obra")]
        public DataTable ListarAreasUsuarias(String sLinea = "*")
        {
            prCargaCombos(1, sLinea);
            if (DT is null)
            {
                prCargaCombos(1, sLinea);
                return DT;
            }
            else
            {
                return DT;
            }
        }

        [WebMethod(Description = "Lista la Planilla de conformidad de mano de obra | Desarrollo")]
        public DataTable BuscarPlanilla(String sTipoPL, String cTaller, String cFecha, Int64 n_opcion = 0)
        {
            prListar(sMetodo_lee, sTipoPL, cTaller, cFecha, n_opcion);
            if (DT is null)
            {
                prListar(sMetodo_lee, sTipoPL, cTaller, cFecha, n_opcion);
                return DT;
            }
            else
            {
                return DT;
            }
        }


        [WebMethod(Description = "Lista la Planilla de conformidad de mano de obra")]
        public DataTable BuscarPlanilla_ok(String sTipoPL, String cTaller, String cFecha, Int64 n_opcion = 0)
        {
            prListar(sMetodo_lee_ok, sTipoPL, cTaller, cFecha, n_opcion);
            if (DT is null)
            {
                prListar(sMetodo_lee_ok, sTipoPL, cTaller, cFecha, n_opcion);
                return DT;
            }
            else
            {
                return DT;
            }
        }

        [WebMethod(Description = "Buscar El Nivel de Aprobación asginado a un usuario especifico")]
        public DataTable BuscarNivelAprobacion(String sUser)
        {
            prBuscarNivelAprobacion(sUser);
            if (DT is null)
            {
                prBuscarNivelAprobacion(sUser);
                return DT;
            }
            else
            {
                return DT;
            }
        }


        [WebMethod(Description = "Retorna el Login del usuario Aprobador de un Nivel de una Planilla de conformidad de mano de obra")]
        public DataTable BuscarAprobador(String sTipoPL, String cTaller, String cFecha, Int64 n_nivel = 0)
        {
            prAprobador(sTipoPL, cTaller, cFecha, n_nivel);
            if (DT is null)
            {
                prAprobador(sTipoPL, cTaller, cFecha, n_nivel);
                return DT;
            }
            else
            {
                return DT;
            }
        }

        [WebMethod(Description = "Realiza los Procesos colocar o quitar la Conformidad en la Planilla de conformidad de mano de obra | Desarrollo")]
        public DataTable Conformidad(Int64 N_opera, string sFecha, string sUser, string sNivelC = "L", Int64 N_PR = 0, string sTipoPL = null, string sTaller = "X32", string sLinea = "RN",
                                         string sfiltro = "NO", string sTipo_filtro = "", string sdata_filtro = "")
        {
            prConformidad(sMetodo_envia, N_opera, sFecha, sUser, sNivelC, N_PR, sTipoPL, sTaller, sLinea,
                             sfiltro, sTipo_filtro, sdata_filtro);
            if (DT is null)
            {
                prConformidad(sMetodo_envia, N_opera, sFecha, sUser, sNivelC, N_PR, sTipoPL, sTaller, sLinea,
                                 sfiltro, sTipo_filtro, sdata_filtro);
                return DT;
            }
            else
            {
                return DT;
            }
        }

        [WebMethod(Description = "Realiza los Procesos colocar o quitar la Conformidad en la Planilla de conformidad de mano de obra")]
        public DataTable Conformidad_ok(Int64 N_opera, string sFecha, string sUser, string sNivelC = "L", Int64 N_PR = 0, string sTipoPL = null, string sTaller = "X32", string sLinea = "RN",
                                      string sfiltro = "NO", string sTipo_filtro = "", string sdata_filtro = "")
        {
            prConformidad(sMetodo_envia_ok, N_opera, sFecha, sUser, sNivelC, N_PR, sTipoPL, sTaller, sLinea,
                             sfiltro, sTipo_filtro, sdata_filtro);
            if (DT is null)
            {
                prConformidad(sMetodo_envia_ok, N_opera, sFecha, sUser, sNivelC, N_PR, sTipoPL, sTaller, sLinea,
                                 sfiltro, sTipo_filtro, sdata_filtro);
                return DT;
            }
            else
            {
                return DT;
            }
        }

        [WebMethod(Description = "Prueba el funcionamiento basico del servicio Mano de Obra")]
        public DataTable Test()
        {
            MODULO = "Test";
            try
            {

                prPruebas();
                if (DT is null)
                {
                    prPruebas();
                    return DT;
                }
                else
                {
                    return DT;
                }
            }
            catch (SIMAExcepcionLog oSIMAExcepcionLog)
            {
                LogTransaccional.GrabarLogErrorArchivo(new LogErrorBE(UserName, MODULO, "SIMAExcepcionLog", oSIMAExcepcionLog.Message));

                return null;

            }

        }

        [WebMethod(Description = "Prueba 2 del funcionamiento basico del servicio Mano de Obra")]
        public DataTable Test2()
        {
            MODULO = "Test2";
            try
            {

                //*************CABECERA DEL REPORTE *************************
                // creamos UN datatable
                DataTable dtcabecera = new DataTable("Cab_Planilla");
                // definimos las columnas
                DataColumn col_1 = new DataColumn("cod_ceo");
                DataColumn col_2 = new DataColumn("fec_tbj");
                DataColumn col_3 = new DataColumn("mod_tbj");
                DataColumn col_4 = new DataColumn("cod_div");
                DataColumn col_5 = new DataColumn("cod_tll");

                // insertamos las columnas a la tabla
                dtcabecera.Columns.Add(col_1);
                dtcabecera.Columns.Add(col_2);
                dtcabecera.Columns.Add(col_3);
                dtcabecera.Columns.Add(col_4);
                dtcabecera.Columns.Add(col_5);
                // pasamos los valores a la tabla
                DataRow fila = dtcabecera.NewRow();
                fila["cod_ceo"] = "1";
                fila["fec_tbj"] = "15/05/2023";
                fila["mod_tbj"] = "NOR";
                fila["cod_div"] = "RN";
                fila["cod_tll"] = "X32";

                // insertamos los valores de la fila a la tabla
                dtcabecera.Rows.Add(fila);

                return dtcabecera;
            }
            catch (SIMAExcepcionLog oSIMAExcepcionLog)
            {
                LogTransaccional.GrabarLogErrorArchivo(new LogErrorBE(UserName, MODULO, "SIMAExcepcionLog", oSIMAExcepcionLog.Message));

                return null;

            }

        }

        //*********** LISTADO DE PROCEDIMIENTOS PARA SER USADOS POR LOS METODOS ********************
        #region Procedimientos
        protected void prCargaCombos(Int64 n_caso = 0, string slinea = "*") // parametro caso: sirve para reutilizar este procedimiento y ejecutar solo una parte de el
        {
            // 1:AreaUsuaria
            // 2:TipoPlanilla
            // 3:LineaNegocio
            // 4:TipoConformidad

            //  Int64 contador = 0;
            Int64 n_opcion;
            string sParametros = "";
            // credenciales, Estos valores se deberian encriptar con con un algoritmo y guardado en un archivo txt


            // Llamada al servicio REST, el ip es del servicio de producción oracle JDE

            //***************** AREA USUARIA*****************************************
            if (n_caso == 0 || n_caso == 1)
            {
                if (n_caso == 0)
                {
                    n_opcion = 1;  //1:AreaUsuaria
                    slinea = "*"; //---muestra todas
                }
                else
                {
                    n_opcion = n_caso; // 1:AreaUsuaria
                    if (slinea.Trim().Replace("\r", "").Replace("\r\n", "") == "")
                    {
                        slinea = "*";
                    }
                }



                sParametros = "n_opcion=" + n_opcion + "&c_linea=" + slinea;

                try
                {
                    DT = Helper.CallServiceRestOracle(sMetodo_lee, sParametros);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("fallo:", "prCargaCombos " + n_caso + " " + ex.Message);
                }
            }
            //***************** TIPO PLANILLA****************************************
            if (n_caso == 0 || n_caso == 2)
            {
                if (n_caso == 0)
                {
                    n_opcion = 2; // 2:TipoPlanilla
                }
                else
                {
                    n_opcion = n_caso; // 2:TipoPlanilla
                }



                sParametros = "n_opcion=" + n_opcion;

                try
                {
                    DT = Helper.CallServiceRestOracle(sMetodo_lee, sParametros);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("fallo:", "prCargaCombos " + n_caso + " " + ex.Message);
                }
            }
            //**************** LINEA DE NEGOCIO *************************************
            if (n_caso == 0 || n_caso == 3)
            {
                // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
                if (n_caso == 0)
                {
                    n_opcion = 3; // 3:LineaNegocio
                }
                else
                {
                    n_opcion = n_caso; // 3:LineaNegocio
                }

                //slinea

                sParametros = "n_opcion=" + n_opcion;

                try
                {
                    DT = Helper.CallServiceRestOracle(sMetodo_lee, sParametros);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("fallo:", "prCargaCombos " + n_caso + " " + ex.Message);

                }

            }
            //**************** NIVELES CONFORMIDAD**************************************
            if (n_caso == 0 || n_caso == 4)
            {
                if (n_caso == 0)
                {
                    n_opcion = 4; // 4:TipoConformidad
                }
                else
                {
                    n_opcion = n_caso; // 4:TipoConformidad
                }

                sParametros = "n_opcion=" + n_opcion;

                try
                {
                    DT = Helper.CallServiceRestOracle(sMetodo_lee, sParametros);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("fallo:", "prCargaCombos " + n_caso + " " + ex.Message);
                }
            }



        }
        protected void prListar(String sMetodo, String sTipoPL, String cTaller, String cFecha, Int64 n_opcion = 0) // OBTIENE UNA PLANILLA según su condicion de aprobado o NO

        // //PARAMETROS: TIPO PLANILLA, TALLER, FECHA, OPCION (1:filtra solo los que tiene aprobacion)
        {

            string C_Linea;  //--- * muestra todos los registros 
            c_pto = "1";

            // ******* validacion de datos de variables*************
            if (sTipoPL == null)
            { sTipoPL = "inc"; }
            if (n_opcion == 1)
            { C_Linea = ""; }
            else
            { C_Linea = "*"; }


            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
            c_pto = "2";
            String sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + cTaller + "&d_fecha=" + cFecha + "&c_linea=" + C_Linea;

            try
            {
                DT = Helper.CallServiceRestOracle(sMetodo, sParametros);
            }
            catch (Exception ex)
            {

                LogTransaccional.GrabarLogErrorArchivo(new LogErrorBE(UserName, MODULO, "Exception", ex.Message));

            }
        }

        protected void prBuscarNivelAprobacion(String sUser) // OBTIENE EL NIVEL DE APROBACION ASIGNADO A UN USUARIO

        // //PARAMETROS: TIPO PLANILLA, TALLER, FECHA, OPCION (1:filtra solo los que tiene aprobacion)
        {


            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
            c_pto = "1";
            String sParametros = "n_opcion=5&c_linea=" + sUser;

            try
            {
                c_pto = "2";
                DT = Helper.CallServiceRestOracle(sMetodo_lee, sParametros);

            }
            catch (Exception ex)
            {

                LogTransaccional.GrabarLogErrorArchivo(new LogErrorBE(UserName, MODULO, "Exception", ex.Message));

            }
        }

        protected void prAprobador(String sTipoPL, String cTaller, String cFecha, Int64 n_nivel = 0) // OBTIENE EL APROBADOR DE LA  PLANILLA según el Nivel enviado

        // //PARAMETROS: TIPO PLANILLA, TALLER, FECHA, NIVEL (de aprobacion)
        //    n_opcion=6&c_mod=" + sTipoPL + "&c_tll_ini=" + cTaller + "&d_fecha=" + C_FECHA + "&c_linea=" + inivel

        {


            c_pto = "1";


            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
            c_pto = "2";
            String sParametros = "n_opcion=6&c_mod=" + sTipoPL + "&c_tll_ini=" + cTaller + "&d_fecha=" + cFecha.Trim() + "&c_linea=" + n_nivel;

            try
            {

                DT = Helper.CallServiceRestOracle(sMetodo_lee, sParametros);



            }
            catch (Exception ex)
            {

                LogTransaccional.GrabarLogErrorArchivo(new LogErrorBE(UserName, MODULO, "Exception", ex.Message));

            }
        }

        protected void prConformidad(string sMetodo, Int64 N_opera, string sFecha, string sUser, string sNivelC = "L", Int64 N_PR = 0, string sTipoPL = null, string sTaller = "X32", string sLinea = "RN",
                                         string sfiltro = "NO", string sTipo_filtro = "", string sdata_filtro = "")
        {
            // PARAMETROS: PR Y OPCION DE PROCEDIMIENTO (0:Captura del form principal, 1: captura del popup) 
            /* **** PARAMETROS **************
                N_opera // operacion a realizar, 1: dar conformidad , -1 quitar conformidad, eso se pasara a la variable  n_opcion
                sTipoPL  // TIPO DE PLANILLA (se esta capturando de un txt pero deberia ser una lista desplegable asociada al servicio web oracle
                sTaller  // taller como ejemplo, se coloca en duro, pero eberia ser una lista desplegable asociada al servicio web oracle
                sLinea   // Lineas de neogocio
                sNivelC  // NIvel de conformidad
                sUser    // codigo de usuario de red quien realizar la transaccion
                sfiltro  // especifica si se usará  filtros para la conformidad
                sTipo_filtro // nombre los filtros que se empleara
                sdata_filtro  // datos del filtros a realizar
                */


            try
            {
                Int64 n_opcion = N_opera;// el valor de 1 es para dar conformidad
                String sParametros = "";

                if (sfiltro == "SI")
                {

                    switch (sTipo_filtro.ToUpper())
                    {
                        case "OT":
                        case "PROYECTO":
                            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
                            if (N_PR > 0)
                            {
                                sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + sFecha + "&c_linea=" + sLinea
                                          + "&C_conformidad=" + sNivelC + "&n_opcion=" + n_opcion + "&n_pr=" + N_PR + "&c_user=" + sUser;
                                DT = Helper.ReplyServiceRestOracle(sMetodo, sParametros);
                            }
                            else
                            {

                                sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + sFecha + "&c_linea=" + sLinea
                                          + "&C_conformidad=" + sNivelC + "&n_opcion=" + n_opcion + "&n_pr=" + N_PR + "&c_user=" + sUser
                                          + "&c_firma=" + sdata_filtro.Trim() + "&C_filtro=" + sTipo_filtro.ToUpper();
                                DT = Helper.ReplyServiceRestOracle(sMetodo, sParametros);
                            }

                            break;



                        default:
                            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
                            if (N_PR > 0)
                            {
                                sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + sFecha + "&c_linea=" + sLinea
                                          + "&C_conformidad=" + sNivelC + "&n_opcion=" + n_opcion + "&n_pr=" + N_PR + "&c_user=" + sUser;
                                DT = Helper.ReplyServiceRestOracle(sMetodo, sParametros);
                            }
                            else //---- masiva
                            {
                                sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + sFecha + "&c_linea=" + sLinea
                                              + "&C_conformidad=" + sNivelC + "&n_opcion=" + n_opcion + "&c_user=" + sUser;
                                DT = Helper.ReplyServiceRestOracle(sMetodo, sParametros);
                            }

                            break;
                    }
                }
                else
                {
                    if (N_PR > 0) // unico y sin filtros
                    {
                        sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + sFecha + "&c_linea=" + sLinea
                                  + "&C_conformidad=" + sNivelC + "&n_opcion=" + n_opcion + "&n_pr=" + N_PR + "&c_user=" + sUser + "&c_firma=-";
                        DT = Helper.ReplyServiceRestOracle(sMetodo, sParametros);
                    }
                    else //---- masiva
                    {
                        sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + sFecha + "&c_linea=" + sLinea
                                      + "&C_conformidad=" + sNivelC + "&n_opcion=" + n_opcion + "&c_user=" + sUser + "&c_firma=-";
                        DT = Helper.ReplyServiceRestOracle(sMetodo, sParametros);
                    }
                }
                //*************************************************************

                //  DT =prListar();




            }

            catch (Exception ex)
            {
                LogTransaccional.GrabarLogErrorArchivo(new LogErrorBE(UserName, MODULO, "Exception", ex.Message));
            }
        }



        public void prPruebas()
        {

            //*************CABECERA DEL REPORTE *************************
            // creamos UN datatable
            DataTable dtcabecera = new DataTable("Cab_Planilla");
            // definimos las columnas
            DataColumn col_1 = new DataColumn("cod_ceo");
            DataColumn col_2 = new DataColumn("fec_tbj");
            DataColumn col_3 = new DataColumn("mod_tbj");
            DataColumn col_4 = new DataColumn("cod_div");
            DataColumn col_5 = new DataColumn("cod_tll");

            // insertamos las columnas a la tabla
            dtcabecera.Columns.Add(col_1);
            dtcabecera.Columns.Add(col_2);
            dtcabecera.Columns.Add(col_3);
            dtcabecera.Columns.Add(col_4);
            dtcabecera.Columns.Add(col_5);
            // pasamos los valores a la tabla
            DataRow fila = dtcabecera.NewRow();
            fila["cod_ceo"] = "1";
            fila["fec_tbj"] = "15/05/2023";
            fila["mod_tbj"] = "NOR";
            fila["cod_div"] = "RN";
            fila["cod_tll"] = "X32";

            // insertamos los valores de la fila a la tabla
            dtcabecera.Rows.Add(fila);

            DT = dtcabecera;

        }
        #endregion
    }
}
