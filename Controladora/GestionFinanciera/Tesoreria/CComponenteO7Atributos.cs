using AccesoDatos.NoTransaccional.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public  class CComponenteO7Atributos
    {
        public DataSet ListarAtributosComponente(int IdComponente)
        {
            return (new ComponenteO7AtributosNTAD()).ListarAtributos(IdComponente);
        }
    }
}
