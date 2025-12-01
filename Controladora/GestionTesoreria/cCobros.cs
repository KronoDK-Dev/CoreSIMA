using Controladora.GestionContabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionTesoreria;

namespace Controladora.GestionTesoreria
{
    public class cCobros
    {
        public DataTable Listar_folios_pendientes_o7(string D_AÑO, string D_MES, string UserName)
        {
            return (new CobrosNTAD()).Listar_folios_pendientes_o7(D_AÑO, D_MES, UserName);
        }

        public DataTable Listar_ingresos_contabilizados(string D_FECHA_DESDE, string D_FECHA_HASTA,
            string V_CENTRO_OPERATIVO, string V_CONCEPTO, string V_DESDE, string V_EMPRESA_DESDE,
            string V_EMPRESA_HASTA, string V_HASTA, string V_MONEDA, string UserName)
        {
            return (new CobrosNTAD()).Listar_ingresos_contabilizados(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO, V_CONCEPTO,
                V_DESDE, V_EMPRESA_DESDE, V_EMPRESA_HASTA, V_HASTA, V_MONEDA, UserName);
        }

        public DataTable Listar_ventas_x_orden_trabajo(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_NUMERO_OT,
            string UserName)
        {
            return (new CobrosNTAD()).Listar_ventas_x_orden_trabajo(V_CENTRO_OPERATIVO, V_DIVISION, V_NUMERO_OT, UserName);
        }

        public DataTable Listar_fact_cobrar_sector_privado(string UserName)
        {
            return (new CobrosNTAD()).Listar_fact_cobrar_sector_privado(UserName);
        }

        public DataTable Listar_fact_cobrar_sector_marina(string UserName)
        {
            return (new CobrosNTAD()).Listar_fact_cobrar_sector_marina(UserName);
        }

        public DataTable Listar_Parte_de_Cobranzas(string V_Centro_Operativo, string D_Año, string D_Mes, string UserName)
        {
            return (new CobrosNTAD()).Listar_Parte_de_Cobranzas(V_Centro_Operativo, D_Año, D_Mes, UserName);
        }

        public DataTable Listar_Documentos_por_Cliente(string V_Centro_Operativo, string V_Cliente, string D_Año_Desde, string D_Año_Hasta, string UserName)
        {
            return (new CobrosNTAD()).Listar_Documentos_por_Cliente(V_Centro_Operativo, V_Cliente, D_Año_Desde, D_Año_Hasta, UserName);
        }

        public DataTable Listar_Fact_Men_X_Linea_Neg(string V_Centro_Operativo, string D_Año, string UserName)
        {
            return (new CobrosNTAD()).Listar_Fact_Men_X_Linea_Neg(V_Centro_Operativo, D_Año, UserName);
        }

        public DataTable Listar_Orden_Trabajo_Datos_Gener(string V_Centro_Operativo, string V_Division, string V_Numero_OT, string UserName)
        {
            return (new CobrosNTAD()).Listar_Orden_Trabajo_Datos_Gener(V_Centro_Operativo, V_Division, V_Numero_OT, UserName);
        }

        public DataTable Listar_Anexo_Diques(string V_Centro_Operativo, string V_Division, string V_Numero_OT, string UserName)
        {
            return (new CobrosNTAD()).Listar_Anexo_Diques(V_Centro_Operativo, V_Division, V_Numero_OT, UserName);
        }
    }
}
