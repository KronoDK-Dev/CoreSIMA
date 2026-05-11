using AccesoDatos.NoTransaccional.GestionPersonal;
using AccesoDatos.Transaccional.GestionPersonal.EvaluacionDese;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionPersonal.EvaluacionDesem
{
    public class CEvaluacionDesempenio
    {
      
        public DataTable BuscarObjetivosxDescripcion(string V_DESCRIPCION, string UserName)
        {
            return (new PersonalNTAD()).BuscarObjetivosxDescripcion(V_DESCRIPCION, UserName);
        }

        public string ActualizarAccesoEvaluacion(string V_TIPO_EVAL, int V_VALOR, string V_OPCION, string V_DNI_JEFE, string UserName)
        {
            return (new EvaluacionDesempenioTAD()).ActualizarAccesoEvaluacion(V_TIPO_EVAL, V_VALOR, V_OPCION, V_DNI_JEFE, UserName);
        }


    }
}
