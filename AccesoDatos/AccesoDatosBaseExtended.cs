using Microsoft.Practices.EnterpriseLibrary.Data;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Utilitario;

namespace AccesoDatos
{
    public static class AccesoDatosBaseExtended
    {
        public static DataSet ExecuteDataSet(
          this Database odbGeneral,
          bool Sup,
          string storeProcedureName,
          OracleParameter[] Params)
        {
            try
            {
                DataSet dataSet = new DataSet();
                OracleConnection connection = (OracleConnection)odbGeneral.CreateConnection();
                connection.Open();
                OracleCommand selectCommand = new OracleCommand(storeProcedureName, connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                if (Params != null)
                {
                    foreach (OracleParameter oracleParameter in Params)
                    {
                        if (oracleParameter.OracleDbType == OracleDbType.Varchar2)
                            oracleParameter.Value = (object)oracleParameter.Value.ToString().Replace("[s]", " ");
                        selectCommand.Parameters.Add(oracleParameter);
                    }
                }
                new OracleDataAdapter(selectCommand).Fill(dataSet);
                connection.Close();
                connection.Dispose();
                return dataSet;
            }
            catch (Exception ex)
            {
                return (DataSet)null;
            }
        }

        public static DataSet ExecuteDataSet(
          this Database odbGeneral,
          bool Sup,
          string storeProcedureName,
          MySqlParameter[] Params)
        {
            try
            {
                DataSet dataSet = new DataSet();
                MySqlConnection connection = (MySqlConnection)odbGeneral.CreateConnection();
                connection.Open();
                MySqlCommand selectCommand = new MySqlCommand(storeProcedureName, connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                foreach (MySqlParameter mySqlParameter in Params)
                {
                    if (mySqlParameter.MySqlDbType == MySqlDbType.VarChar)
                        mySqlParameter.Value = (object)mySqlParameter.Value.ToString().Replace("[s]", " ");
                    selectCommand.Parameters.Add(mySqlParameter);
                }
                new MySqlDataAdapter(selectCommand).Fill(dataSet);
                connection.Close();
                connection.Dispose();
                return dataSet;
            }
            catch (Exception ex)
            {
                return odbGeneral.ExecuteDataSet(CommandType.StoredProcedure, storeProcedureName);
            }
        }

        public static object ExecuteScalar(this Database odbGeneral, bool Sup, string storeProcedureName)
        {
            return odbGeneral.ExecuteScalar(Sup, storeProcedureName, (OracleParameter[])null);
        }

        public static object ExecuteScalar(
          this Database odbGeneral,
          bool Sup,
          string storeProcedureName,
          OracleParameter[] Params)
        {
            try
            {
                OracleConnection connection = (OracleConnection)odbGeneral.CreateConnection();
                connection.Open();
                OracleCommand oracleCommand = new OracleCommand(storeProcedureName, connection);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                if (Params != null)
                {
                    foreach (OracleParameter oracleParameter in Params)
                    {
                        if (oracleParameter.OracleDbType == OracleDbType.Varchar2 && oracleParameter.Value != null)
                            oracleParameter.Value = (object)oracleParameter.Value.ToString().Replace("[s]", " ");
                        oracleCommand.Parameters.Add(oracleParameter);
                    }
                }
                object obj = oracleCommand.ExecuteScalar();
                connection.Close();
                connection.Dispose();
                return obj;
            }
            catch (Exception ex)
            {
                return odbGeneral.ExecuteScalar(storeProcedureName, ADHelper.Data.Oraclei.ParamsValues(Params));
            }
        }

        public static object ExecuteNonQuery(
          this Database odbGeneral,
          bool Sup,
          string storeProcedureName,
          OracleParameter[] Params)
        {
            string[] strArray = new string[Params.Length];
            int index1 = 0;
            string str1 = "";
            try
            {
                OracleConnection connection = (OracleConnection)odbGeneral.CreateConnection();
                connection.Open();
                OracleCommand oracleCommand = new OracleCommand(storeProcedureName, connection);
                oracleCommand.CommandType = CommandType.StoredProcedure;
                if (Params != null)
                {
                    foreach (OracleParameter oracleParameter in Params)
                    {
                        if (oracleParameter.OracleDbType == OracleDbType.Varchar2 && oracleParameter.Value != null)
                            oracleParameter.Value = (object)oracleParameter.Value.ToString().Replace("[s]", " ");
                        if (oracleParameter.Direction == ParameterDirection.Output || oracleParameter.Direction == ParameterDirection.InputOutput)
                            strArray[index1] = oracleParameter.ParameterName;
                        ++index1;
                        oracleCommand.Parameters.Add(oracleParameter);
                    }
                }
                object obj = (object)oracleCommand.ExecuteNonQuery();
                int index2 = 0;
                int num = 0;
                foreach (string name in strArray)
                {
                    if (name != null)
                    {
                        Params[index2].Value = (object)oracleCommand.Parameters[name].Value.ToString();
                        str1 = $"{str1}{(num == 0 ? "" : ",")}{Params[index2].ParameterName}:'{Params[index2].Value?.ToString()}'";
                        ++num;
                    }
                    ++index2;
                }
                string str2 = $"{{{str1}}}";
                connection.Close();
                connection.Dispose();
                return index2 > 0 ? (object)str2 : obj;
            }
            catch (Exception ex)
            {
                return odbGeneral.ExecuteScalar(storeProcedureName, ADHelper.Data.Oraclei.ParamsValues(Params));
            }
        }

        //public static object ExecuteNonQuery(
        //  this Database odbGeneral,
        //  bool Sup,
        //  string storeProcedureName,
        //  MySqlParameter[] Params)
        //{
        //    try
        //    {
        //        MySqlConnection connection = (MySqlConnection)odbGeneral.CreateConnection();
        //        connection.Open();
        //        MySqlCommand mySqlCommand = new MySqlCommand(storeProcedureName, connection);
        //        mySqlCommand.CommandType = CommandType.StoredProcedure;
        //        foreach (MySqlParameter mySqlParameter in Params)
        //        {
        //            if (mySqlParameter.MySqlDbType == MySqlDbType.VarChar)
        //                mySqlParameter.Value = (object)mySqlParameter.Value.ToString().Replace("[s]", " ");
        //            mySqlCommand.Parameters.Add(mySqlParameter);
        //        }
        //        // ISSUE: variable of a boxed type
        //        __Boxed<int> local = (System.ValueType)mySqlCommand.ExecuteNonQuery();
        //        connection.Close();
        //        connection.Dispose();
        //        return (object)local;
        //    }
        //    catch (Exception ex)
        //    {
        //        return (object)0;
        //    }
        //}
    }
}
