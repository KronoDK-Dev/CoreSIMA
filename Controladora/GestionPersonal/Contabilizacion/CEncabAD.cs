using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.GestionPersonal.Contabilizacion;

namespace Controladora.GestionPersonal.Contabilizacion
{
    public class CEncabAD
    {
        public int Eliminar(string codEmp, string codSuc, string Año, string mes, string SubDiario)
        {
            return (new EncabADTAD()).Eliminar(codEmp, codSuc, Año, mes, SubDiario);
        }

        public int Insertar(BaseBE oBaseBE)
        {
            return (new EncabADTAD()).Insertar(oBaseBE);
        }
    }
}
