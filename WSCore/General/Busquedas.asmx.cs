using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.General;

namespace WSCore.General
{
    /// <summary>
    /// Descripción breve de Busquedas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Busquedas : System.Web.Services.WebService
    {
         [WebMethod(Description = "Buscar en el Maestro de personal del O7 por apellidos y nombres")]
      public DataTable BuscarPeronal(string ApellidosyNombres,string UserName)
      {
          return (new CBuscar()).BuscarPersonal(ApellidosyNombres, UserName);
      }
    
      [WebMethod(Description = "Buscar en el Maestro de personal del O7 por apellidos y nombres")]
      public DataTable BuscarPeronalPorTipo(string ApellidosNombres, string CodArea,  string UserName)
      {
          return (new CBuscar()).BuscarPersonal(ApellidosNombres, CodArea, UserName);
      }
    
    
      [WebMethod(Description = "Buscar en el Maestro de Areas de UNISYS")]
      public DataTable BuscarArea(string Nombre_Area, string UserName)
      {
          return (new CBuscar()).BuscarArea(Nombre_Area, UserName);
      }
      [WebMethod(Description = "Buscar en el Maestro de Areas de UNISYS por Cia y centro")]
      public DataTable BuscarAreaPorEmpresayCentro(string CodEmpresa,string CodCentro, string Nombre_Area, string UserName)
      {
          return (new CBuscar()).BuscarArea(CodEmpresa, CodCentro, Nombre_Area, UserName);
      }
    }
}
