using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionLogistica;

namespace Controladora.GestionLogistica
{
    public class cStock
    {
        public DataTable Listar_TransStockVerFec(string FECHA_DE_TRANSFERENCIA_Inicio,
            string FECHA_DE_TRANSFERENCIA_Termino, string Material_Inicial, string Material_Final, string UserName)
        {
            return (new StockNTAD()).Listar_TransStockVerFec(FECHA_DE_TRANSFERENCIA_Inicio, FECHA_DE_TRANSFERENCIA_Termino,
                Material_Inicial, Material_Final, UserName);
        }

        public DataTable Lista_TransStockVerCon(string Fecha_Inicial, string Fecha_Final, string USUARIO,
            string TERMINAL, string UserName)
        {
            return (new StockNTAD()).Lista_TransStockVerCon(Fecha_Inicial, Fecha_Final, USUARIO, TERMINAL, UserName);
        }

        public DataTable Listar_Valorizacion_Disp_Stock(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            return (new StockNTAD()).Listar_Valorizacion_Disp_Stock(N_CEO, V_CODDIV, V_NROVAL, UserName);
        }

        public DataTable Listar_Punto_Reposicion_Pedido(string TIPO_STOCK, string CLASE_MATERIAL, string CLASIFICACION,
            string MATERIAL_CRITICO, string UserName)
        {
            return (new StockNTAD()).Listar_Punto_Reposicion_Pedido(TIPO_STOCK, CLASE_MATERIAL, CLASIFICACION, MATERIAL_CRITICO,
                UserName);
        }

        public DataTable Listar_liberareservastrf(string FECHA_DE_LIBERACION_INICIO, string FECHA_DE_LIBERACION_TERMINO,
            string MATERIAL_FINAL, string MATERIAL_INICIAL, string UserName)
        {
            return (new StockNTAD()).Listar_liberareservastrf(FECHA_DE_LIBERACION_INICIO, FECHA_DE_LIBERACION_TERMINO,
                MATERIAL_FINAL, MATERIAL_INICIAL, UserName);
        }

        public DataTable Listar_liberareservascon(string FECHA_FINAL, string FECHA_INICIAL, string UserName)
        {
            return (new StockNTAD()).Listar_liberareservascon(FECHA_FINAL, FECHA_INICIAL, UserName);
        }

        public DataTable Listar_InventarioFisicoResultado(string V_CEO, string N_ANIO, string V_CODALM, string V_CODCOR, string V_DIFE, string UserName)
        {
            return (new StockNTAD()).Listar_InventarioFisicoResultado(V_CEO, N_ANIO, V_CODALM, V_CODCOR, V_DIFE, UserName);
        }

        public DataTable Listar_InventarioFisicoToma(string CEO_OPE, string V_ANO_INV, string V_COD_ALM, string V_COD_COR, string DIFE, string UserName)
        {
            return (new StockNTAD()).Listar_InventarioFisicoToma(CEO_OPE, V_ANO_INV, V_COD_ALM, V_COD_COR, DIFE, UserName);
        }

        public DataTable Listar_Paquetes_Materiales(string PAQUETE, string UserName)
        {
            return (new StockNTAD()).Listar_Paquetes_Materiales(PAQUETE, UserName);
        }
        public DataTable Listar_IngresosAlmacen(string V_CEO, string D_FECHAINI, string D_FECHAFIN, string V_CODALM, string V_CODMAT, string UserName)
        {
            return (new StockNTAD()).Listar_IngresosAlmacen(V_CEO, D_FECHAINI, D_FECHAFIN, V_CODALM, V_CODMAT, UserName);
        }
        public DataTable Listar_Ctrolmaterial_consol(string N_CEO, string N_CODMAT, string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new StockNTAD()).Listar_Ctrolmaterial_consol(N_CEO, N_CODMAT, D_FECHAINI, D_FECHAFIN, UserName);
        }
        public DataTable Listar_ControlMatTotalxDia(string V_Centro_Operativo, string D_Fecha_Movimiento_Inicial, string D_Fecha_Movimiento_Final, string V_Codigo_Clase_Material, string UserName)
        {
            return (new StockNTAD()).Listar_ControlMatTotalxDia(V_Centro_Operativo, D_Fecha_Movimiento_Inicial, D_Fecha_Movimiento_Final, V_Codigo_Clase_Material, UserName);
        }
    }
}
