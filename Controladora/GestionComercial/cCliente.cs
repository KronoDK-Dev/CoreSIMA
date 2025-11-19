using AccesoDatos.NoTransaccional.General;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.GestionComercial;
using ClienteNTAD = AccesoDatos.NoTransaccional.GestionComercial.ClienteNTAD;

namespace Controladora.GestionComercial
{
    public class cCliente
    {
        public DataSet Consultar(string CodCli, int CentroOperativo)
        {
            return (new ClienteNTAD()).Consultar(CodCli, CentroOperativo);
        }

        public DataTable ListarClientes(string N_OPCION, string V_FILTRO, string V_CEO, string V_UND_OPER, string UserName, string V_AMBIENTE = "T")
        {
            return (new ClienteNTAD()).ListarClientes(N_OPCION, V_FILTRO, V_CEO, V_UND_OPER, UserName, V_AMBIENTE);
        }

        public BaseBE ListarClientePorId(string V_CLIENTE_ID, string UserName, string sAmbiente = "T")
        {
            return (new ClienteNTAD()).ListarClientePorId(V_CLIENTE_ID, UserName, sAmbiente);
        }

        public string InsertarCliente(BaseBE oBaseBE, string accion, string sAmbiente = "T")
        {
            return (new ClienteTAD()).InsertarCliente(oBaseBE, accion, sAmbiente);
        }

        public string InsertarContactoCliente(BaseBE oBaseBE, string opcion, string sAmbiente = "T")
        {
            return (new ClienteTAD()).InsertarContactoCliente(oBaseBE, opcion, sAmbiente);
        }

        public DataTable ListarContactosDeCliente(string X_V_CLIENTE_ID, string V_AMBIENTE = "T")
        {
            return (new ClienteNTAD()).ListarContactosDeCliente(X_V_CLIENTE_ID, V_AMBIENTE);
        }

        public string EliminarContactoCliente(string v_cliente_id, string contacto_id, string sAmbiente = "T")
        {
            return (new ClienteTAD()).EliminarContactoCliente(v_cliente_id, contacto_id, sAmbiente);
        }

        public DataTable ListarEmbarcaciones(string V_FILTRO, string V_AMBIENTE = "T")
        {
            return (new ClienteNTAD()).ListarEmbarcaciones(V_FILTRO, V_AMBIENTE);
        }

        public BaseBE ListarEmbarcacionPorId(string V_EMBARCACION_ID, string UserName, string sAmbiente = "T")
        {
            return (new ClienteNTAD()).ListarEmbarcacionPorId(V_EMBARCACION_ID, UserName, sAmbiente);
        }

        public string InsertarEmbarcacion(BaseBE oBaseBE, string accion, string sAmbiente = "T")
        {
            return (new ClienteTAD()).InsertarEmbarcacion(oBaseBE, accion, sAmbiente);
        }

        public string InsertarDetalleEmbarcacion(BaseBE oBaseBE, string sAmbiente = "T")
        {
            return (new ClienteTAD()).InsertarDetalleEmbarcacion(oBaseBE, sAmbiente);
        }

        public DataTable ListarDetalleDeEmbarcacionPorID(string X_V_EMBARCACION_ID, string V_AMBIENTE = "T")
        {
            return (new ClienteNTAD()).ListarDetalleDeEmbarcacionPorID(X_V_EMBARCACION_ID, V_AMBIENTE);
        }

        public string GEN_EMBARCACION_ID(string P_V_CLIENTE_ID, string V_AMBIENTE = "T")
        {
            return (new ClienteNTAD()).GEN_EMBARCACION_ID(P_V_CLIENTE_ID, V_AMBIENTE);
        }

        public DataTable ListaBuscarCliente3(string V_NOMBRE, string UserName)
        {
            return (new ClienteNTAD().ListaBuscarCliente3(V_NOMBRE, UserName));
        }

        public DataTable listaclientesxcodxdescr(string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            return (new ClienteNTAD()).listaclientesxcodxdescr(V_CODIGO, V_DESCRIPCION, UserName, v_ambiente);
        }

        public DataTable listaunidxcliexcodxdescr(string V_CLIENTE, string V_CODIGO, string V_DESCRIPCION, string UserName, string v_ambiente = "T")
        {
            return (new ClienteNTAD()).listaunidxcliexcodxdescr(V_CLIENTE, V_CODIGO, V_DESCRIPCION, UserName, v_ambiente);
        }

        public DataTable ListaBuscarCliente2(string V_NOMBRE, string UserName)
        {
            return (new ClienteNTAD().ListaBuscarCliente2(V_NOMBRE, UserName));
        }

        public DataTable BusquedaEmbarcacionyCliente(string V_NOMBRE, string V_AMBIENTE, string UserName)
        {
            return (new ClienteNTAD()).BusquedaEmbarcacionyCliente(V_NOMBRE, V_AMBIENTE, UserName);
        }
    }
}
