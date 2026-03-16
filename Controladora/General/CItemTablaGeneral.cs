using AccesoDatos;
using AccesoDatos.NoTransaccional.General;
using AccesoDatos.NoTransaccional.GestionSeguridadPlanta;
using AccesoDatos.Transaccional.General;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.General
{
    public class CItemTablaGeneral
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new ItemTablaGeneralNTAD()).ListarTodos(Id1, UserName);
        }

        public DataTable ListarTablasdeApoyo(string IdtblModulo, string UserName)
        {
            return (new ItemTablaGeneralNTAD()).ListarTablasdeApoyo(IdtblModulo, UserName);
        }

        public DataTable ListarTodosOracle(int IdTbl, string UserName)
        {
            return (new ItemTablaGeneralNTAD()).ListarTodosOracle(IdTbl, UserName);
        }

        public DataTable ListarTodosOracle(int IdTblPadre, int IdItemPadre, string UserName)
        {
            return (new ItemTablaGeneralNTAD()).ListarTodosOracle(IdTblPadre, IdItemPadre, UserName);
        }

        public int Modificar(BaseBE oBaseBE)
        {
            return (new ItemTablaGeneralTAD()).Modificar(oBaseBE);
        }

        public DataTable ListaConfiguracion(string PageName, string UserName)
        {
            return (new ItemTablaGeneralNTAD()).ListaConfiguracion(PageName, UserName);
        }

        public string Buscar_Var1_DetalleCatologo(string IdMaestra, string IdDetalle, string UserName)
        {
            return (new ItemTablaGeneralNTAD()).Buscar_Var1_DetalleCatologo(IdMaestra, IdDetalle, UserName);
        }

        // Retorno de objeto dicccionario para JSON
        // DataTable tiene overhead de esquema, columnas, estados de fila, índices; está pensado para data-binding y operaciones in-memory(relaciones, constraints).
        // List<Dictionary<...>> mantiene solo los datos: para el uso típico de “consultar y serializar a JSON”, es más liviano en memoria y CPU.
        public List<Dictionary<string, object>> ListarAreaPorNombre_JSON(int iIdCentroOperativo, string sNombreArea, string UserName)
        {
            return (new ItemTablaGeneralNTAD()).ListarAreaPorNombre_JSON(iIdCentroOperativo, sNombreArea, UserName);
        }

        public DataTable ListarTablaGeneral(string codTabla, string codVar, string UserName)
        {
            
                return (new InformacionGeneralNTAD()).ListarTablaGeneral(codTabla, codVar, UserName);
          
        }


      

    }
}
