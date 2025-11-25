using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionLogistica;

namespace Controladora.GestionLogistica
{
    public class cMateriales
    {
        public DataTable Listar_ConsumoAnualMateriales(string N_CEO, string PERIODO, string TIPO,
            string CLASIFICACION, string UserName)
        {
            return (new MaterialesNTAD()).Listar_ConsumoAnualMateriales(N_CEO, PERIODO, TIPO, CLASIFICACION, UserName);
        }

        public DataTable Listar_Mat_CentroOperativo(string Fecha_Emision_Inicio, string Fecha_Emision_Termino,
            string UserName)
        {
            return (new MaterialesNTAD()).Listar_Mat_CentroOperativo(Fecha_Emision_Inicio, Fecha_Emision_Termino, UserName);
        }

        public DataTable Listar_MatLLegadoCompras(string Codigo_Division, string Codigo_OT, string Fecha_LLegada_Inicio,
            string Fecha_Llegada_Termino, string UserName)
        {
            return (new MaterialesNTAD()).Listar_MatLLegadoCompras(Codigo_Division, Codigo_OT, Fecha_LLegada_Inicio,
                Fecha_Llegada_Termino, UserName);
        }

        public DataTable Listar_CatalogoMaterialesFC(string D_FechaIEmision, string D_FechaFEmision, string UserName)
        {
            return (new MaterialesNTAD()).Listar_CatalogoMaterialesFC(D_FechaIEmision, D_FechaFEmision, UserName);
        }

        public DataTable Listar_VM_CC(string N_CEO, string V_CODCC, string D_FECHAINI, string D_FECHAFIN,
            string UserName)
        {
            return (new MaterialesNTAD()).Listar_VM_CC(N_CEO, V_CODCC, D_FECHAINI, D_FECHAFIN, UserName);
        }

        public DataTable Listar_MoviMatIOCVSMVD(string Centro_Operativo, string FECHA_INICIAL_MOVIMIENTO,
            string FECHA_FINAL_MOVIMIENTO, string CODIGO_MATERIAL, string UserName)
        {
            return (new MaterialesNTAD()).Listar_MoviMatIOCVSMVD(Centro_Operativo, FECHA_INICIAL_MOVIMIENTO, FECHA_FINAL_MOVIMIENTO,
                CODIGO_MATERIAL, UserName);
        }

        public DataTable Listar_MoviMaterialAud(string Almacen, string año_Inventario, string Corte,
            string Fecha_Inicial, string Fecha_Final, string UserName)
        {
            return (new MaterialesNTAD()).Listar_MoviMaterialAud(Almacen, año_Inventario, Corte, Fecha_Inicial, Fecha_Final,
                UserName);
        }

        public DataTable Listar_EQUIVA2013(string V_MATERIAL, string V_DIMLARGO, string V_DIMANCHO, string V_UNMEDIDA,
            string V_CANTREQ, string UserName)
        {
            return (new MaterialesNTAD()).Listar_EQUIVA2013(V_MATERIAL, V_DIMLARGO, V_DIMANCHO, V_UNMEDIDA, V_CANTREQ, UserName);
        }

        public DataTable Listar_VM_CC_ESPECIFICO(string N_CEO, string V_CODCC, string D_FECHAINI, string D_FECHAFIN,
            string UserName)
        {
            return (new MaterialesNTAD()).Listar_VM_CC_ESPECIFICO(N_CEO, V_CODCC, D_FECHAINI, D_FECHAFIN, UserName);
        }

        public DataTable Listar_ControlReservaMat(string V_CODIGO_MATERIAL, string D_FECHA_RESERVA_inicial,
            string D_FECHA_RESERVA_final, string UserName)
        {
            return (new MaterialesNTAD()).Listar_ControlReservaMat(V_CODIGO_MATERIAL, D_FECHA_RESERVA_inicial,
                D_FECHA_RESERVA_final, UserName);
        }

        public DataTable Listar_SaldoAlmacen(string Material_Inicial, string Material_Final, string UserName)
        {
            return (new MaterialesNTAD()).Listar_SaldoAlmacen(Material_Inicial, Material_Final, UserName);
        }

        public DataTable Listar_AtencionMaterialesCC(string V_Centro_Operativo, string D_Fecha_Inicio,
            string D_Fecha_Termino, string V_CC, string UserName)
        {
            return (new MaterialesNTAD()).Listar_AtencionMaterialesCC(V_Centro_Operativo, D_Fecha_Inicio, D_Fecha_Termino, V_CC,
                UserName);
        }

        public DataTable Listar_CONSUMO_VM_VALJDE(string V_TIPO_VALE, string D_FECHAINI, string D_FECHAFIN,
            string UserName)
        {
            return (new MaterialesNTAD()).Listar_CONSUMO_VM_VALJDE(V_TIPO_VALE, D_FECHAINI, D_FECHAFIN, UserName);
        }

        public DataTable Listar_SeguiRequeDeta_OTS(string Codigo_Division, string Codigo_OT,
            string FECHA_EMISION_OT_Inicio, string FECHA_EMISION_OT_Termino, string FECHA_ATENCION_INICIO,
            string FECHA_ATENCION_TERMINO, string UserName)
        {
            return (new MaterialesNTAD()).Listar_SeguiRequeDeta_OTS(Codigo_Division, Codigo_OT, FECHA_EMISION_OT_Inicio,
                FECHA_EMISION_OT_Termino, FECHA_ATENCION_INICIO, FECHA_ATENCION_TERMINO, UserName);
        }

        public DataTable Listar_PRECIOSREPOSICION(string CLAS_MATERIAL, string UserName)
        {
            return (new MaterialesNTAD()).Listar_PRECIOSREPOSICION(CLAS_MATERIAL, UserName);
        }

        public DataTable Listar_Punto_Reposicion(string TIPO_STOCK, string CLASE_MATERIAL, string MAT_CRI,
            string UserName)
        {
            return (new MaterialesNTAD()).Listar_Punto_Reposicion(TIPO_STOCK, CLASE_MATERIAL, MAT_CRI, UserName);
        }

        public DataTable Listar_Punto_Repo_Precios_Prome(string TIPO_STOCK, string CLASE_MATERIAL, string MAT_CRI,
            string UserName)
        {
            return (new MaterialesNTAD()).Listar_Punto_Repo_Precios_Prome(TIPO_STOCK, CLASE_MATERIAL, MAT_CRI, UserName);
        }

        public DataTable Listar_PedidoMateMultipropo(string NUMERO_PEDIDO, string EMISION_INICIAL_PEDIDO,
            string EMISION_FINAL_PEDIDO, string CODIGO_MATERIAL, string CODIGO_AUXILIAR, string UserName)
        {
            return (new MaterialesNTAD()).Listar_PedidoMateMultipropo(NUMERO_PEDIDO, EMISION_INICIAL_PEDIDO, EMISION_FINAL_PEDIDO,
                CODIGO_MATERIAL, CODIGO_AUXILIAR, UserName);
        }

        public DataTable Listar_Reserva_OT_Produccion(string Codigo_OT, string Codigo_Material, string Estado_OT,
            string Estado_Seguimiento_OT, string UserName)
        {
            return (new MaterialesNTAD()).Listar_Reserva_OT_Produccion(Codigo_OT, Codigo_Material, Estado_OT,
                Estado_Seguimiento_OT, UserName);
        }

        public DataTable Listar_MAT_MASIVA(string CLASE_SUBCLASE, string UserName)
        {
            return (new MaterialesNTAD()).Listar_MAT_MASIVA(CLASE_SUBCLASE, UserName);
        }

        public DataTable Listar_ReserMateAreasUsua(string Area_Usuaria, string división, string Material, string OT,
            string UserName)
        {
            return (new MaterialesNTAD()).Listar_ReserMateAreasUsua(Area_Usuaria, división, Material, OT, UserName);
        }

        public DataTable Listar_CODIFICACION_CUBSO(string CLASE, string UserName)
        {
            return (new MaterialesNTAD()).Listar_CODIFICACION_CUBSO(CLASE, UserName);
        }

        public DataTable Listar_PedidoMaterialCompraOTS(string DIVISION, string NRO_PEDIDO, string UserName)
        {
            return (new MaterialesNTAD()).Listar_PedidoMaterialCompraOTS(DIVISION, NRO_PEDIDO, UserName);
        }

        public DataTable Listar_MatlesSinMov_PDR8701(string Centro_Operativo, string Almacen, string Fecha_Inicial,
            string Fecha_Final, string Clase, string Stock, string UserName)
        {
            return (new MaterialesNTAD()).Listar_MatlesSinMov_PDR8701(Centro_Operativo, Almacen, Fecha_Inicial, Fecha_Final, Clase,
                Stock, UserName);
        }

        public DataTable Listar_Vale_Salida_Mat(string s_CEO, string s_NRO_VALE, string s_COD_ALMA, string s_AREA_USU,
              string UserName)
        {
            return (new MaterialesNTAD()).Listar_Vale_Salida_Mat(s_CEO, s_NRO_VALE, s_COD_ALMA, s_AREA_USU,
               UserName);
        }

        public DataTable Listar_controlmateriales(string N_OPC, string N_CEO, string D_FECHAINI, string D_FECHAFIN, string C_DESTINO_OPER, string V_COD_CLASE_MAT, string UserName)
        {
            return (new MaterialesNTAD()).Listar_controlmateriales(N_OPC, N_CEO, D_FECHAINI, D_FECHAFIN, C_DESTINO_OPER, V_COD_CLASE_MAT, UserName);
        }

        public DataTable Listar_saldo_historico_mat(string CENTRO_OPERATIVO, string FECHA_DE_PROCESO, string MATERIAL,
            string UserName)
        {
            return (new MaterialesNTAD()).Listar_saldo_historico_mat(CENTRO_OPERATIVO, FECHA_DE_PROCESO, MATERIAL, UserName);
        }

        public DataTable Listar_DET_G_PRY_OT_VSM_PCI(string Centro_Operativo, string Division, string Proyecto, string Fecha_Emision, string UserName)
        {
            return (new MaterialesNTAD()).Listar_DET_G_PRY_OT_VSM_PCI(Centro_Operativo, Division, Proyecto, Fecha_Emision, UserName);
        }
    }
}
