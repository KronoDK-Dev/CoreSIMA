using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.SIMANET.SeguridadPlanta
{
    public class CCTT_ProgramacionTrabajadoresContratistaBE:BaseBE
    {
        #region Propiedades
        public int IdArea
        {
            get;
            set;
        }
        public int NroProgramacion
        {
            get;
            set;
        }
        public int Periodo
        {
            get;
            set;
        }

        public string NroDNI
        {
            get;
            set;
        }
        public string ApellidosyNombres
        {
            get;
            set;
        }
        public int IdTablaHorario
        {
            get;
            set;
        }

        public int IdHorario
        {
            get;
            set;
        }

        public int IdTablaEstado
        {
            get;
            set;
        }
        public DateTime FechaRegistro
        {
            get;
            set;
        }
        public int IdUsuarioRegistro
        {
            get;
            set;
        }


        public int IdNivelEspecialidad
        {
            get;
            set;
        }

        public DateTime FechaInicio
        {
            get;
            set;
        }
        public DateTime FechaTermino
        {
            get;
            set;
        }
        public string HoraInicio
        {
            get;
            set;
        }
        public string HoraTermino
        {
            get;
            set;
        }

        public string EspecialidadTmp
        {
            get;
            set;
        }
        public string SCTRSalud
        {
            get;
            set;
        }
        public string SCTRPension
        {
            get;
            set;
        }

        #endregion
    }
}
