using AccesoDatos.NoTransaccional.GestionSeguridadIndustrial;
using Controladora.GestionSeguridadIndustrial;
using EntidadNegocio;
using EntidadNegocio.GestionSeguridadIndustrial;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;

namespace WSCore.GestionSeguridadIndustrial
{
    /// <summary>
    /// Descripción breve de SeguridadIndustrial
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class SeguridadIndustrial : System.Web.Services.WebService
    {

        [WebMethod(Description = "Lista de Antecedentes General")]
        public DataTable Listar(string IdAntecedente, string UserName)
        {
            return (new CCCTT_TrabajadorAntecedente()).Listar(IdAntecedente, UserName);
        }

        [WebMethod(Description = "Detalle de Antecedente")]
        public AntecedenteTrabajadorContratistaBE Detalle(string IdAntecedente, string UserName)
        {
            return (AntecedenteTrabajadorContratistaBE)new CCCTT_TrabajadorAntecedente().Detalle(IdAntecedente,
                UserName);
        }

        [WebMethod(Description = "Generar Antecedente")]
        public string Insertar(AntecedenteTrabajadorContratistaBE oAntecedente)
        {
            return new CCCTT_TrabajadorAntecedente().Insertar(oAntecedente);
        }

        [WebMethod(Description = "Generar Anexo de Antecedente")]
        public string InsertarAnexo(AntecedenteAnexoBE oAntecedenteAnexoBE)
        {
            return new CCCTT_TrabajadorAntecedente().InsertarAnexo(oAntecedenteAnexoBE);
        }

        [WebMethod(Description = "Modificacion del Antecedente")]
        public int Modificar(AntecedenteTrabajadorContratistaBE oAntecedente)
        {
            return new CCCTT_TrabajadorAntecedente().Modificar(oAntecedente);
        }

        [WebMethod(Description = "Elimnar Antecedente")]
        public int Eliminar(string IdAntecedente)
        {
            return new CCCTT_TrabajadorAntecedente().Eliminar(IdAntecedente);
        }

        #region SCTR

        [WebMethod(Description = "SCTR: Listar SCTR por Entidad")]
        public DataTable ListarSCTRporEntidad(string IdEntidad, string UserName)
        {
            return new CCCTT_Sctr().ListarTodos(IdEntidad, UserName);
        }

        [WebMethod(Description = "SCTR: Detalle por SCTR")]
        public DataTable DetalleSctr(string IdTipoSCTR, string NroSCTR, string IdSCTR, string UserName)
        {
            return new CCCTT_Sctr().DetalleSctr(IdTipoSCTR, NroSCTR, IdSCTR, UserName);
        }

        #endregion
    }
}
