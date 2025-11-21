using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public class CComponenteO7Atributos
    {
        public DataSet ListarAtributosComponente(int IdComponente)
        {
            return (new ComponenteO7AtributosNTAD()).ListarAtributos(IdComponente);
        }
    }
}
