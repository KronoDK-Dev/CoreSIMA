using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionContabilidad;

namespace Controladora.GestionContabilidad
{
    public class CPagos
    {
        public DataTable Listar_voucher_por_documento(string V_NUMERO, string V_PROVEEDOR, string V_SERIE, string V_TIPO, string UserName)
        {
            return (new PagosNTAD()).Listar_voucher_por_documento(V_NUMERO, V_PROVEEDOR, V_SERIE, V_TIPO, UserName);
        }

        public DataTable Listar_registro_retenciones_suna(string N_CEO, string V_ANIO, string V_NROMES, string UserName)
        {
            return (new PagosNTAD()).Listar_registro_retenciones_suna(N_CEO, V_ANIO, V_NROMES, UserName);
        }

        public DataTable Listar_pagos_por_cuenta_detraccion(string N_CEO, string V_ANIO, string V_MESFIN, string V_MESINI, string UserName)
        {
            return (new PagosNTAD()).Listar_pagos_por_cuenta_detraccion(N_CEO, V_ANIO, V_MESFIN, V_MESINI, UserName);
        }
    }
}
