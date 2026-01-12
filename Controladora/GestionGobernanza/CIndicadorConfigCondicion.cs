using AccesoDatos.NoTransaccional.GestionGobernanza;
using AccesoDatos.Transaccional.GestionGobernanza;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionGobernanza
{
    public class CIndicadorConfigCondicion
    {
        public DataTable ListarTodosCondicion(int IdArea,int Idindicador,  string UserName)
        {
            return (new IndicadorConfigCondicionNTAD()).ListarTodosCondicion(IdArea, Idindicador, UserName);
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new IndicadorConfigCondicionTAD()).ModificaInserta(oBaseBE);            
        }

    }
}
