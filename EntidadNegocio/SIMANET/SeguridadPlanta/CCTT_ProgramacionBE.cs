using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.SIMANET.SeguridadPlanta
{
    public class CCTT_ProgramacionBE:BaseBE
    {
        public CCTT_ProgramacionBE()
        { }

        #region Atributos
        private int nroProgramacion;
        private int periodo;
        /*Atributos Agregados con respecto a Entidad*/
        private int idTipoEntidad;
        private int idEntidad;

        private int idProveedor;
        private string nroRuc;
        private string razonSocial;
        private int idJefeProyecto;
        private string apellidosyNombres;

        private string nroRegistroIngreso;
        private string nroDocumentodeRef;
        private DateTime fechaInicio;
        private DateTime fechaTermino;
        private string horaInicio;
        private string horaTermino;
        private int idtablaCIASeguros;
        private int idCIASeguros;
        private string nombreCIASeguros;
        private string nroPoliza;

        private DateTime fechaInicioPoliza;
        private DateTime fechaTerminoPoliza;
        private DateTime fechaInicioPolizaS;
        private DateTime fechaTerminoPolizaS;

        private string nroPensionPoliza;
        private string nroSaludPoliza;
        private string trabajosARealizar;
        private int idArea;
        private string nombreArea;
        //private NullableTypes.NullableString lugardeTrabajo;
        private int idlugardeTrabajo;
        private string nombreLugarTrabajo;


        private string nombreNave;
        //private NullableTypes.NullableInt32 idContacto;
        private string nombreContacto;

        private string observaciones;
        private int idEstado;

        private string nroOrdenServicio;
        private string idOrdenServicio;
        private int tipoProgramacion;

        private int noProgramado;

        #endregion

        #region Propiedades
        public int NroProgramacion
        {
            get { return this.nroProgramacion; }
            set { this.nroProgramacion = value; }
        }
        public int Periodo
        {
            get { return this.periodo; }
            set { this.periodo = value; }
        }
        /*Propiedades Agregadas Con respecto a Entidad*/
        public int IdTipoEntidad
        {
            get { return this.idTipoEntidad; }
            set { this.idTipoEntidad = value; }
        }
        public int IdEntidad
        {
            get { return this.idEntidad; }
            set { this.idEntidad = value; }
        }
        public int IdProveedor
        {
            get { return this.idProveedor; }
            set { this.idProveedor = value; }
        }
        public string NroRuc
        {
            get { return this.nroRuc; }
            set { this.nroRuc = value; }
        }

        public string RazonSocial
        {
            get { return this.razonSocial; }
            set { this.razonSocial = value; }
        }



        public int IdJefeProyecto
        {
            get { return this.idJefeProyecto; }
            set { this.idJefeProyecto = value; }
        }
        public string ApellidosyNombres
        {
            get { return this.apellidosyNombres; }
            set { this.apellidosyNombres = value; }
        }


        public string NroRegistroIngreso
        {
            get { return this.nroRegistroIngreso; }
            set { this.nroRegistroIngreso = value; }
        }

        public string NroDocumentodeRef
        {
            get { return this.nroDocumentodeRef; }
            set { this.nroDocumentodeRef = value; }
        }

        public DateTime FechaInicio
        {
            get { return this.fechaInicio; }
            set { this.fechaInicio = value; }
        }

        public DateTime FechaTermino
        {
            get { return this.fechaTermino; }
            set { this.fechaTermino = value; }
        }

        public string HoraInicio
        {
            get { return this.horaInicio; }
            set { this.horaInicio = value; }
        }

        public string HoraTermino
        {
            get { return this.horaTermino; }
            set { this.horaTermino = value; }
        }

        public int IdtablaCIASeguros
        {
            get { return this.idtablaCIASeguros; }
            set { this.idtablaCIASeguros = value; }
        }


        public int IdCIASeguros
        {
            get { return this.idCIASeguros; }
            set { this.idCIASeguros = value; }
        }
        public string NombreCIASeguros
        {
            get { return this.nombreCIASeguros; }
            set { this.nombreCIASeguros = value; }
        }
        public string NroPoliza
        {
            get { return this.nroPoliza; }
            set { this.nroPoliza = value; }
        }


        public DateTime FechaInicioPoliza
        {
            get { return this.fechaInicioPoliza; }
            set { this.fechaInicioPoliza = value; }
        }

        public DateTime FechaTerminoPoliza
        {
            get { return this.fechaTerminoPoliza; }
            set { this.fechaTerminoPoliza = value; }
        }
        public DateTime FechaInicioPolizaS
        {
            get { return this.fechaInicioPolizaS; }
            set { this.fechaInicioPolizaS = value; }
        }

        public DateTime FechaTerminoPolizaS
        {
            get { return this.fechaTerminoPolizaS; }
            set { this.fechaTerminoPolizaS = value; }
        }


        public string NroPensionPoliza
        {
            get { return this.nroPensionPoliza; }
            set { this.nroPensionPoliza = value; }
        }

        public string NroSaludPoliza
        {
            get { return this.nroSaludPoliza; }
            set { this.nroSaludPoliza = value; }
        }

        public string TrabajosARealizar
        {
            get { return this.trabajosARealizar; }
            set { this.trabajosARealizar = value; }
        }


        public int IdArea
        {
            get { return this.idArea; }
            set { this.idArea = value; }
        }
        public string NombreArea
        {
            get { return this.nombreArea; }
            set { this.nombreArea = value; }
        }

        public int IdLugardeTrabajo
        {
            get { return this.idlugardeTrabajo; }
            set { this.idlugardeTrabajo = value; }
        }
        public string NombreLugardeTrabajo
        {
            get { return this.nombreLugarTrabajo; }
            set { this.nombreLugarTrabajo = value; }
        }



        public string NombreNave
        {
            get { return this.nombreNave; }
            set { this.nombreNave = value; }
        }

        public string NombreContacto
        {
            get { return this.nombreContacto; }
            set { this.nombreContacto = value; }
        }


        public string Observaciones
        {
            get { return this.observaciones; }
            set { this.observaciones = value; }
        }

        public int IdEstado
        {
            get { return this.idEstado; }
            set { this.idEstado = value; }
        }

        public string NroOrdenServicio
        {
            get { return nroOrdenServicio; }
            set { this.nroOrdenServicio = value; }
        }

        public string IdOrdenServicio
        {
            get { return idOrdenServicio; }
            set { this.idOrdenServicio = value; }
        }

        public int TipoProgramacion
        {
            get { return tipoProgramacion; }
            set { this.tipoProgramacion = value; }
        }

        public int NoProgramado
        {
            get { return noProgramado; }
            set { this.noProgramado = value; }
        }

        #endregion
      

    }
}
