using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionLogistica;

namespace Controladora.GestionLogistica
{
    public class cProveedores
    {
        public DataTable Listar_PDT601_4TA(string D_FECHAPRO, string UserName)
        {
            return (new ProveedoresNTAD()).Listar_PDT601_4TA(D_FECHAPRO, UserName);
        }

        public DataTable Listar_PDT601_PS4(string D_FECHAPRO, string UserName)
        {
            return (new ProveedoresNTAD()).Listar_PDT601_PS4(D_FECHAPRO, UserName);
        }

        public DataTable Listar_Reg_Retencion_4TA(string D_FECHAPRO, string UserName)
        {
            return (new ProveedoresNTAD()).Listar_Reg_Retencion_4TA(D_FECHAPRO, UserName);
        }

        public DataTable Listar_Salidas_Dev_Prov(string N_CEO, string V_PROCESO, string UserName)
        {
            return (new ProveedoresNTAD()).Listar_Salidas_Dev_Prov(N_CEO, V_PROCESO, UserName);
        }

        public DataTable Listar_ProgramaAdquiEnvioCot(string PROGRAMA_ADQUISICION, string UserName)
        {
            return (new ProveedoresNTAD()).Listar_ProgramaAdquiEnvioCot(PROGRAMA_ADQUISICION, UserName);
        }

        public DataTable Listar_RegistroProveedores(string Fecha_Registro, string Estado, string Tipo, string RUC,
            string Procedencia, string UserName)
        {
            return (new ProveedoresNTAD()).Listar_RegistroProveedores(Fecha_Registro, Estado, Tipo, RUC, Procedencia, UserName);
        }
    }
}
