using AccesoDatos.NoTransaccional.General;
using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public  class CComponenteO7AtributoObligatorio
    {
        public DataSet ConsultarComponentesAtributosObligatorios()
        {
            return (new ComponenteO7AtributoObligatorioNTAD()).Listar();
        }
    }
}
