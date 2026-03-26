
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionSeguridadIndustrial
{
    public class AntecedenteTrabajadorContratistaBE : BaseBE
    {
        private string idAntecedente;
        private string nroDNI;
        private string apellidosyNombres;
        private DateTime fecha;
        private string hora;
        private int idLugardeTrabajo;
        private string nombreLugardeTrabajo;
        private int idTipoAntecedente;
        private string descripcion;
        private int idProveedor;
        private string razonSocial;
        private int lugarCritico;
        private int contratista;
        private string idJefeDirecto;
        private string nombresJefeDirecto;
        private int idPersonalFamiliar;
        private string nombresFamiliar;
        private int idParentesco;
        private string nombresParentesco;
        private string descripcioEvento;
        private string idPersonalInterviene;
        private string nombrePersonalInterviene;
        private int ingresoPermitido;
        private string extension;

        public string IdAntecedente
        {
            get => this.idAntecedente;
            set => this.idAntecedente = value;
        }

        public string NroDNI
        {
            get => this.nroDNI;
            set => this.nroDNI = value;
        }

        public string ApellidosyNombres
        {
            get => this.apellidosyNombres;
            set => this.apellidosyNombres = value;
        }

        public DateTime Fecha
        {
            get => this.fecha;
            set => this.fecha = value;
        }

        public string Hora
        {
            get => this.hora;
            set => this.hora = value;
        }

        public int IdLugardeTrabajo
        {
            get => this.idLugardeTrabajo;
            set => this.idLugardeTrabajo = value;
        }

        public string NombreLugardeTrabajo
        {
            get => this.nombreLugardeTrabajo;
            set => this.nombreLugardeTrabajo = value;
        }

        public int IdTipoAntecedente
        {
            get => this.idTipoAntecedente;
            set => this.idTipoAntecedente = value;
        }

        public string Descripcion
        {
            get => this.descripcion;
            set => this.descripcion = value;
        }

        public int IdProveedor
        {
            get => this.idProveedor;
            set => this.idProveedor = value;
        }

        public string RazonSocial
        {
            get => this.razonSocial;
            set => this.razonSocial = value;
        }

        public int LugarCritico
        {
            get => this.lugarCritico;
            set => this.lugarCritico = value;
        }

        public int Contratista
        {
            get => this.contratista;
            set => this.contratista = value;
        }

        public string IdJefeDirecto
        {
            get => this.idJefeDirecto;
            set => this.idJefeDirecto = value;
        }

        public string NombresJefeDirecto
        {
            get => this.nombresJefeDirecto;
            set => this.nombresJefeDirecto = value;
        }

        public int IdPersonalFamiliar
        {
            get => this.idPersonalFamiliar;
            set => this.idPersonalFamiliar = value;
        }

        public string NombresFamiliar
        {
            get => this.nombresFamiliar;
            set => this.nombresFamiliar = value;
        }

        public int IdParentesco
        {
            get => this.idParentesco;
            set => this.idParentesco = value;
        }

        public string NombresParentesco
        {
            get => this.nombresParentesco;
            set => this.nombresParentesco = value;
        }

        public string DescripcioEvento
        {
            get => this.descripcioEvento;
            set => this.descripcioEvento = value;
        }

        public string IdPersonalInterviene
        {
            get => this.idPersonalInterviene;
            set => this.idPersonalInterviene = value;
        }

        public string NombrePersonalInterviene
        {
            get => this.nombrePersonalInterviene;
            set => this.nombrePersonalInterviene = value;
        }

        public int IngresoPermitido
        {
            get => this.ingresoPermitido;
            set => this.ingresoPermitido = value;
        }

        public string Extension
        {
            get => this.extension;
            set => this.extension = value;
        }
    }
}
