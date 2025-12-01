using Controladora.GestionLogistica;
using Controladora.HelpDesk.ITIL;
using Controladora.HelpDesk.Sistemas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.HelpDesk;
using EntidadNegocio.HelpDesk;

namespace WSCore.HelpDesk
{
    /// <summary>
    /// Descripción breve de AdministrarHD
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class AdministrarHD : System.Web.Services.WebService
    {
        [WebMethod(Description = "Listar Requerimientos por usuario")]
        public DataTable Requerimientos_lst(int IdUsuario, string IdRequerientoPadre, string UserName)
        {
            return (new CRequermiento()).ListarTodos(IdUsuario.ToString(), IdRequerientoPadre, UserName);
        }

        [WebMethod(Description = "Listar Requerimientos generados por chatbots")]
        public DataTable RequerimientosInMSG_lst(int IdContacto, string UserName)
        {
            return (new CRequermiento()).ListarTodosInMsg(IdContacto, UserName);
        }

        [WebMethod(Description = "Detalle de Requerimiento")]
        public RequerimientoBE Requerimientos_Det(int IdUsuario, string IdRequerimiento, string UserName)
        {
            return (RequerimientoBE)(new CRequermiento()).Detalle(IdUsuario.ToString(), IdRequerimiento, UserName);
        }

        [WebMethod(Description = "Lista los Archvis Adjunto del requerimiento")]
        public DataTable Requerimientos_adj(string IdRequerimiento, string UserName)
        {
            return (new CRequermiento()).ListarTodosAttach(IdRequerimiento, UserName);
        }

        [WebMethod(Description = "Modificar Aprobadores de Requerimiento")]
        public string Requerimientos_Aprobador_ins(string IdResponsable, string IdRequerimiento, string IdPersona, int IUsuario, string UserName)
        {
            AprobadorBE oAprobadorBE = new AprobadorBE(IdRequerimiento, IdResponsable, IdPersona, IUsuario, UserName);
            return (new CAprobador()).ModificaInserta(oAprobadorBE);
        }

        [WebMethod(Description = "Lista los Responsable aprobación de requerimiento")]
        public DataTable Requerimientos_Aprobador_Lst(string IdRequerimiento, string UserName)
        {
            return (new CAprobador()).ListarTodos(IdRequerimiento, UserName);
        }
        //AProbacion de requerimiento del area solicitante

        [WebMethod(Description = "Envia Mensaje para la aprobacion del requerimiento por el Rol respnsable")]
        public string SolicitarAprobaciondeRequerimiento(string IdResponsableAprobRqr, string Token, int IdUsuario, string UserName)
        {
            return (new CRequerimientoResponsable()).ModificaInserta(IdResponsableAprobRqr, Token, IdUsuario, UserName);
        }

        [WebMethod(Description = "Actualiza estado del aprobador del requerimiento")]
        public string ApruebaRequerimientoPorAprobador(string IdResponsableAprobRqr, int Aprobado, string Token, int IdUsuario, string UserName)
        {
            return (new CRequerimientoResponsable()).ModificaInserta(IdResponsableAprobRqr, Token, Aprobado, IdUsuario, UserName);
        }

        [WebMethod(Description = "Lista los Archivo adjunto de requerimiento")]
        public DataTable Requerimientos_File_Lst(string IdRequerimiento, string UserName)
        {
            return (new CFileRequerimiento()).ListarTodos(IdRequerimiento, UserName);
        }

        [WebMethod(Description = "TEST")]
        public string Requerimientos_insTest(string IdRequerimiento, string IdRequerientoPadre, string IdServicioArea, string NroTicket, string IdPersonal, string Descripcion, int IdPrioridadSolicitada, int IdUsuario, string UserName)
        {
            RequerimientoBE oRequerimientoBE = new RequerimientoBE();
            oRequerimientoBE.IdRequerimiento = IdRequerimiento;
            oRequerimientoBE.IdRequerientoPadre = IdRequerientoPadre;
            oRequerimientoBE.IdServicioArea = IdServicioArea;
            oRequerimientoBE.NroTicket = NroTicket;
            oRequerimientoBE.IdPersonal = IdPersonal;
            oRequerimientoBE.Descripcion = Descripcion;
            oRequerimientoBE.IdPrioridadSolicitada = IdPrioridadSolicitada;
            oRequerimientoBE.IdUsuario = IdUsuario;
            oRequerimientoBE.UserName = UserName;
            return Requerimientos_ins(oRequerimientoBE);
        }

        [WebMethod(Description = "Transaccion Atomica Requerimiento,Aprobadores y Archivos ")]
        //public string Requerimientos_ins(RequerimientoBE oRequerimientoBE,List<AprobadorBE> LstAprobadorBE,List<ArchivoAdjuntoBE> LstArchivoAdjuntoBE)
        public string Requerimientos_ins(RequerimientoBE oRequerimientoBE)
        {
            return (new CRequermiento()).ModificaInserta(oRequerimientoBE);
        }

        [WebMethod(Description = "Cambio de Estado del Requerimiento con params")]
        public string Requerimiento_est(string IdRequerimiento, int IdEstado, int IdUsuario, string UserName)
        {
            RequerimientoBE oRequerimientoBE = new RequerimientoBE();
            oRequerimientoBE.IdRequerimiento = IdRequerimiento;
            oRequerimientoBE.IdEstado = IdEstado;
            oRequerimientoBE.IdUsuario = IdUsuario;
            oRequerimientoBE.UserName = UserName;
            return (new CRequermiento()).CambiarEstado(oRequerimientoBE);
        }

        [WebMethod(Description = "Cambio de Estado del Requerimiento con object")]
        public string Requerimiento_Estado(RequerimientoBE oRequerimientoBE)
        {
            return (new CRequermiento()).CambiarEstado(oRequerimientoBE);
        }

        [WebMethod(Description = "Archivos adjuntos de reqerimientos")]
        public string RequerimientosArhivo_ins(ArchivoAdjuntoBE oArchivoAdjuntoBE)
        {
            return (new CFileRequerimiento()).ModificaInserta(oArchivoAdjuntoBE);
        }

        [WebMethod(Description = "Archivos adjuntos de reqerimientos")]
        public string RequerimientosAprobador_ins(AprobadorBE oAprobadorBE)
        {
            return (new CAprobador()).ModificaInserta(oAprobadorBE);
        }

        [WebMethod(Description = "Cambio de Estado del Aprobador en funcion del requerimiento Asociado")]
        public string RequerimientosAprobador_est(string IdRqrResponsable, int IdEstado, int IdUsuario, string UserName)
        {
            AprobadorBE oAprobadorBE = new AprobadorBE();
            oAprobadorBE.IdResponsable = IdRqrResponsable;
            oAprobadorBE.IdEstado = IdEstado;
            oAprobadorBE.IdUsuario = IdUsuario;
            oAprobadorBE.UserName = UserName;
            return (new CAprobador()).CambiarEstado(oAprobadorBE);
        }

        #region Atencion de requerimientos

        [WebMethod(Description = "Lsistado de todos los requerimientos al area al que pertenece un usuario y a otras asignadas para su administracion")]
        public DataTable BandejadeEntrada(string CodigoArea, int IdUsuario, string IdRqrPadre, string UserName)
        {
            return (new CBandejadeEntrada()).ListarTodos(CodigoArea, IdUsuario.ToString(), IdRqrPadre, UserName);
        }

        [WebMethod(Description = "Lsistado de todos los responsables por requerimiento")]
        public DataTable RequerimientoResponsable_lst(string IdRequerimiento, string UserName)
        {
            return (new CRequerimientoResponsable()).ListarTodos(IdRequerimiento, UserName);
        }

        [WebMethod(Description = "Listado de Sprint Por Requerimiento y responsable")]
        public DataTable RequerimientoResponsableSprint_lst(string IdRequerimiento, string IdPersonal, string IdPlandeTrabajo, string UserName)
        {
            return (new CRequerimientoSprint()).ListarTodos(IdRequerimiento, IdPersonal, IdPlandeTrabajo, UserName);
        }

        #endregion

        #region administra rescurso

        [WebMethod(Description = "Listado de Sprint Por Requerimiento y responsable")]
        public DataTable RecurosDisponiblePorArea_lst(string IdRequerimiento, string CodigoArea, int IdUsuario, string UserName)
        {
            return (new CBandejadeEntrada()).ListarRecursoDisponible(IdRequerimiento, CodigoArea, IdUsuario, UserName);
        }

        [WebMethod(Description = "Inserta o Modifica el Respoesnable de unrequerimiento")]
        public string RequerimientoResponsableAtencion_InsMod(string IdResponsable, string IdRequerimiento, string IdPersonal, int IdUsuario, int IdEstado, string UserName)
        {
            ResponsableAtencionBE oResponsableAtencionBE = new ResponsableAtencionBE();
            oResponsableAtencionBE.IdResponsable = IdResponsable;
            oResponsableAtencionBE.IdRequerimiento = IdRequerimiento;
            oResponsableAtencionBE.IdPersonal = IdPersonal;
            oResponsableAtencionBE.IdUsuario = IdUsuario;
            oResponsableAtencionBE.IdEstado = IdEstado;
            oResponsableAtencionBE.UserName = UserName;

            return (new CRequerimientoResponsableATencion()).ModificaInserta(oResponsableAtencionBE);
        }

        [WebMethod(Description = "Inserta o Modifica el Respoesnable de unrequerimiento")]
        public string RequerimientoResponsableAtencion_Del(string IdResponsable, int IdUsuario, string UserName)
        {
            return (new CRequerimientoResponsableATencion()).Eliminar(IdResponsable, IdUsuario.ToString(), UserName).ToString();
        }

        [WebMethod(Description = "Inserta o Modifica el estado de atencionn del responsable")]
        public string RequerimientoResposableAtencionEstado_ins_Mod(string IdResponsable, string Descripcion, int IdEstado, string UserName)
        {
            return (new CRequerimientoResponsableEstado()).ModificaInserta(IdResponsable, Descripcion, IdEstado, UserName);
        }

        [WebMethod(Description = "Listar los responsables de un determinado requerimiento")]
        public DataTable RequerimientoResponsableAtencionEst_Lst(string IdResponsableAtencion, string UserName)
        {
            return (new CRequerimientoResponsableEstado()).ListarTodos(IdResponsableAtencion, UserName);
        }

        [WebMethod(Description = "Lsia los responsables de un determinado requerimiento")]
        public DataTable RequerimientoResponsableAtencion_Lst(string IdRequerimiento, string UserName)
        {
            return (new CRequerimientoResponsableATencion()).ListarTodos(IdRequerimiento, UserName);
        }

        #endregion

        #region atencion

        [WebMethod(Description = "Listado de Requerimientos Asignados para su atension")]
        public DataTable RequerimientoAsignados_lst(string IdPersonal, string UserName)
        {
            return (new CRequerimientosAtencion()).ListarTodos(IdPersonal, UserName);
        }

        #endregion

        #region Plan de Trabajo

        [WebMethod(Description = "Listado de plan de trabajo por Requerimiento")]
        public DataTable PlandeTrabajo_lst(string IdRequerimiento, string UserName)
        {
            return (new CPlandeTrabajo()).ListarTodos(IdRequerimiento, UserName);
        }
        [WebMethod(Description = "Detalle de plan de trabajo por Requerimiento")]
        public PlandeTrabajoBE PlandeTrabajo_Det(string IdPlan, string IdRequerimiento, string UserName)
        {
            return (PlandeTrabajoBE)(new CPlandeTrabajo()).Detalle(IdPlan, IdRequerimiento, UserName);
        }

        [WebMethod(Description = "Listado de tareas de una actividad seleccionada del plande trabajos")]
        public DataTable PlandeTrabajoTareas_lst(string IdItem, string IdTarea, string UserName)
        {
            return (new CPlanTrabajoTareas()).ListarTodos(IdItem, IdTarea, UserName);
        }

        [WebMethod(Description = "Listado de tareas de una actividad seleccionada del plande trabajos")]
        public PlanCronogramaActividadTareaBE PlandeTrabajoTareas_Det(string IdItem, string IdTarea, string UserName)
        {
            return (PlanCronogramaActividadTareaBE)(new CPlanTrabajoTareas()).Detalle(IdItem, IdTarea, UserName);
        }

        [WebMethod(Description = "Inserta o Modifica una tarea de una actividad de un requerimiento solicitado")]
        public string PlandeTrabajoActividadTareas_ins(string IdTarea, string IdItemPlanCrono, string IdActividadTarea, string Descripcion, int Avance, int IdUsuario, string UserName)
        {
            PlanCronogramaActividadTareaBE oPlanCronogramaActividadTareaBE = new PlanCronogramaActividadTareaBE();
            oPlanCronogramaActividadTareaBE.IdTarea = IdTarea;
            oPlanCronogramaActividadTareaBE.IdItemCronograma = IdItemPlanCrono;
            oPlanCronogramaActividadTareaBE.IdAccionTarea = IdActividadTarea;
            oPlanCronogramaActividadTareaBE.Descripcion = Descripcion;
            oPlanCronogramaActividadTareaBE.IdUsuario = IdUsuario;
            oPlanCronogramaActividadTareaBE.UserName = UserName;
            oPlanCronogramaActividadTareaBE.Avance = Avance;
            return (new CPlanCronogramaActividadTarea()).ModificaInserta(oPlanCronogramaActividadTareaBE);
        }

        [WebMethod(Description = "Eliminar una tarea de una actividad de un requerimiento solicitado")]
        public string PlandeTrabajoActividadTareas_Del(string IdTarea, int IdUsuario, string UserName)
        {
            return (new CPlanCronogramaActividadTarea()).Eliminar(IdTarea, IdUsuario.ToString(), UserName).ToString();
        }

        [WebMethod(Description = "Listado de actividad disponibles para plan de trabajo")]
        public DataTable PlanActividadDisponiblexServicio_lst(string IdServicioArea, string UserName)
        {
            return (new CPlanTrabajoActividad()).ListarTodos(IdServicioArea, UserName);
        }

        [WebMethod(Description = "Listado de Servicios Otorgados a una actividad")]
        public DataTable ServiciosOtorgadosAUnaActividad_lst(string IdActividad, string UserName)
        {
            return (new CServicios()).ListarServiciosOtorgadosPorActividad(IdActividad, UserName);
        }

        /*Mateniumiento del cronograma de actividades de un plan*/
        //CPlanTrabajoTareas
        [WebMethod(Description = "Inserta o Modifica Una Actividad en el Plan Cronograma")]
        public string PlanCronogramaActividad_ins(string IdCronogramaActividad
                        , string IdCronogramaActividadPadre
                        , string Descripcion
                        , string IdActividad
                        , string IdPlan
                        , int IdUsuario
                        , string UserName)
        {
            PlanCronogramaActividadBE oPlanCronogramaActividadBE = new PlanCronogramaActividadBE();
            oPlanCronogramaActividadBE.IdConogramaActividad = IdCronogramaActividad;
            oPlanCronogramaActividadBE.IdConogramaActividadPadre = IdCronogramaActividad;
            oPlanCronogramaActividadBE.Descripcion = Descripcion;
            oPlanCronogramaActividadBE.IdActividad = IdActividad;
            oPlanCronogramaActividadBE.IdPlan = IdPlan;
            oPlanCronogramaActividadBE.IdUsuario = IdUsuario;
            oPlanCronogramaActividadBE.UserName = UserName;
            return (new CPlanTrabajoActividad()).ModificaInserta(oPlanCronogramaActividadBE);
        }

        [WebMethod(Description = "Inserta o Modifica Una Actividad en el Plan Cronograma")]
        public string PlanCronogramaActividad_del(string IdCronogramaActividad, int IdUsuario, string UserName)
        {

            return (new CPlanTrabajoActividad()).Eliminar(IdCronogramaActividad, IdUsuario.ToString(), UserName).ToString();
        }

        [WebMethod(Description = "Listar la Historia de atencion de una tarea vinculada a una actividad de un plan")]
        public DataTable PlanCronogramaActividadTaskHistory_lst(string IdTarea, string UserName)
        {
            return (new CPlanTrabajoActividadTareaHistorial()).ListarTodos(IdTarea, UserName);
        }

        [WebMethod(Description = "Listar de participantes por cada historia")]
        public DataTable PlanCronogramaActividadTaskHistory_Participantes(string IdHistoria, string UserName)
        {
            return (new CPlanTrabajoActividadTareaHistorial()).ListarTodosParticipantes(IdHistoria, UserName);

        }

        [WebMethod(Description = "Inserta o Modifica Una accion de una tarea vinculada a un plan")]
        public string PlanCronogramaActividadTaskHistory_ins(string IdHistorial, string IdTarea
                                                                , string Nombre
                                                                , string Descripcion
                                                                , int IdTipoAccion
                                                                , int IdTipoTiempo
                                                                , int valTipoTime
                                                                , int IdUsuario
                                                                , string UserName)
        {
            PlanTrabajoActividadTareaHistorialBE oPlanTrabajoActividadTareaHistorialBE = new PlanTrabajoActividadTareaHistorialBE();
            oPlanTrabajoActividadTareaHistorialBE.IdHistorial = IdHistorial;
            oPlanTrabajoActividadTareaHistorialBE.IdTarea = IdTarea;
            oPlanTrabajoActividadTareaHistorialBE.Nombre = Nombre;
            oPlanTrabajoActividadTareaHistorialBE.Descripcion = Descripcion;
            oPlanTrabajoActividadTareaHistorialBE.IdTipoAccion = IdTipoAccion;
            oPlanTrabajoActividadTareaHistorialBE.IdTipoTiempo = IdTipoTiempo;
            oPlanTrabajoActividadTareaHistorialBE.valTipoTime = valTipoTime;
            oPlanTrabajoActividadTareaHistorialBE.IdUsuario = IdUsuario;
            oPlanTrabajoActividadTareaHistorialBE.UserName = UserName;

            return (new CPlanTrabajoActividadTareaHistorial()).Modifica(oPlanTrabajoActividadTareaHistorialBE);
        }

        [WebMethod(Description = "Inserta o Modifica Una accion de una tarea vinculada a un plan")]
        public string PlanCronogramaActividadTaskHistory_del(string IdHistorial, int IdUsuario, string UserName)
        {
            int idEst = (new CPlanTrabajoActividadTareaHistorial()).Eliminar(IdHistorial, IdUsuario.ToString(), UserName);
            return "1";
        }

        //lISTADE ACTIVIDADES AFECTADAS POR UN REQUERIMIENTO
        [WebMethod(Description = "Lsita de actividades afectadas en atencion al reqquerimiento")]
        public DataTable RequerimientoActividaAfectada_lst(int IdPersonalAtencion, string IdRequerimiento, int IdPersonalRequerimiento, string UserName)
        {
            return (new CSistemaProcesoSubProceso()).ListarActividadesAtendidasXRequerimiento(IdPersonalAtencion, IdRequerimiento, IdPersonalRequerimiento, UserName);
        }

        //lista requerimientos por activiad
        [WebMethod(Description = "Lsita de reqquerimiento POR ACTIVIDAD SOLICITADA")]
        public DataTable ListaRequerimientoPorAcvtividad(string IdActividad, string IdServicio, string UserName)
        {
            return (new CServicios()).ListarRequerimientoPorActividadAtendida(IdActividad, IdServicio, UserName);
        }

        //Actualizar atencion de actividad por servicios solicitado por requerimiento
        [WebMethod(Description = "Actualliza Actividad considerrada en servicio prestado")]
        public string ActividadServicioPorRequerimiento(string IdRequerimiento, string IdActividad, int IdPersonalAtiende, string Descripcion, int IdEstado, int IdUsuario, string UserName)
        {
            ActividadAtendidaBE oActividadAtendidaBE = new ActividadAtendidaBE();
            oActividadAtendidaBE.IdRequerimiento = IdRequerimiento;
            oActividadAtendidaBE.IdActividad = IdActividad;
            oActividadAtendidaBE.IdPersonalAtiende = IdPersonalAtiende;
            oActividadAtendidaBE.Descripcion = Descripcion;
            oActividadAtendidaBE.IdUsuario = IdUsuario;
            oActividadAtendidaBE.IdEstado = IdEstado;

            return (new CActividadesAtendidas()).ModificaInserta(oActividadAtendidaBE);
        }

        //Actualizar atencion de actividad por servicios solicitado por requerimiento
        [WebMethod(Description = "Inserta o Modifica el Plan de Trabajo")]
        public string PlandeTrabajo_ins(string IdPlan, string IdRequerimiento, string IdServicioArea, string IdResponsableAtiende, string Nombre, string Descripcion, int IdTipo, int IdUsuario, string UserName)
        {
            PlandeTrabajoBE oPlandeTrabajoBE = new PlandeTrabajoBE();
            oPlandeTrabajoBE.IdPlan = IdPlan;
            oPlandeTrabajoBE.IdServicioArea = IdServicioArea;
            oPlandeTrabajoBE.IdResponsableAtencion = IdResponsableAtiende;
            oPlandeTrabajoBE.Nombre = Nombre;
            oPlandeTrabajoBE.Descripcion = Descripcion;
            oPlandeTrabajoBE.IdTipo = IdTipo;
            oPlandeTrabajoBE.IdRequerimiento = IdRequerimiento;
            return (new CPlandeTrabajo()).ModificaInserta(oPlandeTrabajoBE);
        }

        //Actualizar atencion de actividad por servicios solicitado por requerimiento
        [WebMethod(Description = "Elimina el Plan de Trabajo")]
        public string PlandeTrabajo_del(string IdPlan, int IdUsuario, string UserName)
        {
            return (new CPlandeTrabajo()).Eliminar(IdPlan, IdUsuario.ToString(), UserName).ToString();
        }

        [WebMethod(Description = "Agrega personal participante en la tarea")]
        public string TareaHistorialParticipantes_ins(string IdParticipante, int IdPersonal, string IdHistorial, int IdUsuario, string UserName)
        {
            TaskHistoryParticipanteBE oTaskHistoryParticipanteBE = new TaskHistoryParticipanteBE();
            oTaskHistoryParticipanteBE.IdParticipante = IdParticipante;
            oTaskHistoryParticipanteBE.IdPersonal = IdPersonal;
            oTaskHistoryParticipanteBE.IdHistory = IdHistorial;
            oTaskHistoryParticipanteBE.IdUsuario = IdUsuario;
            oTaskHistoryParticipanteBE.UserName = UserName;
            return (new CTaskHistoryParticipante()).ModificaInserta(oTaskHistoryParticipanteBE).ToString();
        }

        [WebMethod(Description = "Elimina personal participante de la tarea")]
        public string TareaHistorialParticipantes_del(string IdParticipante, int IdPersonal, string IdHistorial, int IdUsuario, string UserName)
        {
            return (new CTaskHistoryParticipante()).Eliminar(IdParticipante, IdUsuario.ToString(), UserName).ToString();
        }

        [WebMethod(Description = "Actualiza Nro de solicitudes ENVIADAS de aprobacion de servicios brindados")]
        public string SolicitarAprobaciondeAtencionxServ(string IdRequerimiento, string Token, int IdEstado, int IdUsuario, string UserName)
        {
            return (new CRequermiento()).EnviaSolAprobServicio(IdRequerimiento, Token, IdEstado, IdUsuario, UserName);
        }

        #endregion
    }
}
