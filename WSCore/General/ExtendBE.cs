using Controladora.General;
using EntidadNegocio.GestionFinanciera.Tesoreria.Pagos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WSCore.General
{
    public static class ExtendBE
    {
        public static PlanCabProv SetAttrValue(this PlanCabProv oPlanCabProv, DataRow dr)
        {
            oPlanCabProv.SetAttr(dr);
            return oPlanCabProv;
        }

        public static PlanDetProv SetAttrValue(this PlanDetProv oPlanDetProv, DataRow dr)
        {
            oPlanDetProv.SetAttr(dr);
            return oPlanDetProv;
        }

        public static Archivo SetAttrValue(this Archivo oArchivo, DataRow dr)
        {
            oArchivo.SetAttr(dr);
            return oArchivo;
        }

        public static DetDocBenef SetAttrValue(this DetDocBenef oDetDocBenef, DataRow dr)
        {
            oDetDocBenef.SetAttr(dr);
            return oDetDocBenef;
        }

        private static void SetAttr(this object obj, DataRow drValor)
        {
            DataTable dataTable = new cClaseExtend().ListarPropiedades(obj.GetType().Name, "SIMANetSuite");
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return;
            foreach (DataRow row in (InternalDataCollectionBase)dataTable.Rows)
            {
                string str1 = "";
                try
                {
                    string str2 = row["PROPIEDAD"].ToString();
                    string columnName = row["Field"].ToString();
                    string pValoPropiedad = drValor[columnName].ToString().TrimEnd();
                    str1 = obj.GetType().GetProperty(str2).PropertyType.ToString();
                    obj.ConvertValueRefProperty(str2, pValoPropiedad);
                }
                catch (Exception ex)
                {
                }
            }
        }

        public static void ConvertValueRefProperty(
          this object obj,
          string propertyName,
          string pValoPropiedad)
        {
            PropertyInfo property = obj.GetType().GetProperty(propertyName);
            switch (property.PropertyType.ToString())
            {
                case "System.DateTime":
                    property.SetValue(obj, (object)Convert.ToDateTime(pValoPropiedad), (object[])null);
                    break;
                case "System.Nullable`1[System.DateTime]":
                    object obj1 = ExtendBE.NullableSafeChangeType(pValoPropiedad, property.PropertyType);
                    if (string.IsNullOrEmpty(pValoPropiedad))
                        break;
                    property.SetValue(obj, obj1, (object[])null);
                    break;
                case "System.Decimal":
                    property.SetValue(obj, (object)Convert.ToDecimal(pValoPropiedad), (object[])null);
                    break;
                case "System.Nullable`1[System.Decimal]":
                    object obj2 = ExtendBE.NullableSafeChangeType(pValoPropiedad, property.PropertyType);
                    if (string.IsNullOrEmpty(pValoPropiedad))
                        break;
                    property.SetValue(obj, obj2, (object[])null);
                    break;
                case "System.String":
                    property.SetValue(obj, (object)pValoPropiedad.ToString(), (object[])null);
                    break;
                case "System.Int16":
                    property.SetValue(obj, (object)Convert.ToInt16(pValoPropiedad), (object[])null);
                    break;
                case "System.Int32":
                    property.SetValue(obj, (object)Convert.ToInt32(pValoPropiedad), (object[])null);
                    break;
            }
        }

        private static object NullableSafeChangeType(string input, Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType == (Type)null)
                return Convert.ChangeType((object)input, type);
            return input != null && !(input == "") ? Convert.ChangeType((object)input, underlyingType) : (object)null;
        }
    }
}