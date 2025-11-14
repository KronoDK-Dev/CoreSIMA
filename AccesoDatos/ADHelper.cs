using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    internal class ADHelper
    {
        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct Data
        {
            public static object[] ParamsValues(OleDbParameter[] Param)
            {
                object[] objArray = new object[Param.Length];
                int index = 0;
                foreach (OleDbParameter oleDbParameter in Param)
                {
                    objArray[index] = oleDbParameter.Value;
                    ++index;
                }
                return objArray;
            }

            public static OleDbParameter[] ConvertToOleDbParameter(OleDbParameterCollection paramCollection)
            {
                OleDbParameter[] oleDbParameter1 = new OleDbParameter[paramCollection.Count];
                OleDbParameter oleDbParameter2 = new OleDbParameter();
                oleDbParameter1.Initialize();
                IEnumerator enumerator = paramCollection.GetEnumerator();
                for (int index = 0; index < paramCollection.Count; ++index)
                {
                    enumerator.MoveNext();
                    OleDbParameter current = (OleDbParameter)enumerator.Current;
                    oleDbParameter1[index] = current;
                }
                return oleDbParameter1;
            }

            [StructLayout(LayoutKind.Sequential, Size = 1)]
            public struct Oraclei
            {
                public static object[] ParamsValues(object[] Param)
                {
                    object[] objArray = new object[Param.Length];
                    int num = 0;
                    if (Param.GetType() == typeof(Oracle.DataAccess.Client.OracleParameter))
                    {
                        foreach (Oracle.DataAccess.Client.OracleParameter oracleParameter in Param)
                        {
                            if (oracleParameter.DbType == DbType.String)
                                oracleParameter.Value = (object)oracleParameter.Value.ToString().Replace("[s]", " ");
                            ++num;
                        }
                    }
                    return Param;
                }

                public static object[] ParamsValues(Oracle.DataAccess.Client.OracleParameter[] Param)
                {
                    int num = 0;
                    foreach (Oracle.DataAccess.Client.OracleParameter oracleParameter in Param)
                    {
                        if (oracleParameter.DbType == DbType.String)
                            oracleParameter.Value = (object)oracleParameter.Value.ToString().Replace("[s]", " ");
                        ++num;
                    }
                    return (object[])Param;
                }

                public static Oracle.DataAccess.Client.OracleParameter[] ConvertToOracleParameter(
                  Oracle.DataAccess.Client.OracleParameterCollection paramCollection)
                {
                    Oracle.DataAccess.Client.OracleParameter[] oracleParameter1 = new Oracle.DataAccess.Client.OracleParameter[paramCollection.Count];
                    Oracle.DataAccess.Client.OracleParameter oracleParameter2 = new Oracle.DataAccess.Client.OracleParameter();
                    oracleParameter1.Initialize();
                    IEnumerator enumerator = paramCollection.GetEnumerator();
                    for (int index = 0; index < paramCollection.Count; ++index)
                    {
                        enumerator.MoveNext();
                        Oracle.DataAccess.Client.OracleParameter current = (Oracle.DataAccess.Client.OracleParameter)enumerator.Current;
                        oracleParameter1[index] = current;
                    }
                    return oracleParameter1;
                }

                //public static System.Data.OracleClient.OracleParameter[] ConvertToMsOraclebParameter(
                //  System.Data.OracleClient.OracleParameterCollection paramCollection)
                //{
                //    System.Data.OracleClient.OracleParameter[] oraclebParameter = new System.Data.OracleClient.OracleParameter[paramCollection.Count];
                //    System.Data.OracleClient.OracleParameter oracleParameter = new System.Data.OracleClient.OracleParameter();
                //    oraclebParameter.Initialize();
                //    IEnumerator enumerator = paramCollection.GetEnumerator();
                //    for (int index = 0; index < paramCollection.Count; ++index)
                //    {
                //        enumerator.MoveNext();
                //        System.Data.OracleClient.OracleParameter current = (System.Data.OracleClient.OracleParameter)enumerator.Current;
                //        oraclebParameter[index] = current;
                //    }
                //    return oraclebParameter;
                //}
            }
        }
    }
}
