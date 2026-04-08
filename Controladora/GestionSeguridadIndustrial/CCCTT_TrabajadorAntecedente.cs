using AccesoDatos.NoTransaccional.GestionSeguridadIndustrial;
using AccesoDatos.Transaccional.GestionSeguridadIndustrial;
using EntidadNegocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionSeguridadIndustrial
{
    public class CCCTT_TrabajadorAntecedente
    {
        public DataTable Listar(string IdAntecedente, string UserName)
        {
            return (new CCTT_TrabajadorAntecedenteNTAD()).Listar(IdAntecedente, UserName);
        }

        public BaseBE Detalle(string IdAntecedente, string UserName)
        {
            return (new CCTT_TrabajadorAntecedenteNTAD()).Detalle(IdAntecedente, UserName);
        }

        public string InsertarAnexo(BaseBE oBaseBE)
        {
            return (new CCTT_TrabajadorAntecedenteTAD()).InsertaAnexo(oBaseBE);
        }

        //public int Modificar(BaseBE oBaseBE, ArrayList AnexosBE, ArrayList AnexosEliminadosBE)
        //{
        //    return new AntecedentesLN().Modificar(oBaseBE, AnexosBE, AnexosEliminadosBE);
        //}

        public string Insertar(BaseBE oBaseBE)
        {
            return new CCTT_TrabajadorAntecedenteTAD().Inserta(oBaseBE);
        }

        public int Modificar(BaseBE oBaseBE)
        {
            return new CCTT_TrabajadorAntecedenteTAD().Modificar(oBaseBE);
        }

        public int Eliminar(string IdAntecedente)
        {
            return new CCTT_TrabajadorAntecedenteTAD().Eliminar(IdAntecedente);
        }
    }
}
