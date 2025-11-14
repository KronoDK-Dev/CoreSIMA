using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace EntidadNegocio
{
    [Serializable]
    public class BaseBE
    {
        public string Descripcion { get; set; } = string.Empty;

        public string Observacion { get; set; } = string.Empty;

        public int IdEstado { get; set; }

        public string ImgEstado { get; set; }

        public string NombreEstado { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string IdCodigo { get; set; }

        public int IdUsuario { get; set; }

        public string Token { get; set; }

        public string ambiente { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        public override string ToString()
        {
            int num = 0;
            string str = "";
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                str = str + (num == 0 ? "" : Constante.Caracteres.SeperadorSimple) + property.Name + Constante.Caracteres.Igual + property.GetValue((object)this, (object[])property.GetIndexParameters())?.ToString();
                ++num;
            }
            return str;
        }

        public string ToCliente()
        {
            int num = 0;
            string str = "";
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                str = str + (num == 0 ? "" : Constante.Caracteres.Coma) + property.Name + Constante.Caracteres.DosPunto + property.GetValue((object)this, (object[])property.GetIndexParameters())?.ToString();
                ++num;
            }
            return $"{{{str}}}";
        }

        public string[] ToString(bool AttAndVal)
        {
            return this.ToString().Replace(Constante.Caracteres.SeperadorSimple, "@").Split('@');
        }

        public string Atributos()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (FieldInfo field in this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (field.GetValue((object)this) != null)
                    stringBuilder.Append(field.Name.ToString() + Constante.Caracteres.Igual + field.GetValue((object)this).ToString() + Constante.Caracteres.Coma);
                else
                    stringBuilder.Append($"{field.Name.ToString()}{Constante.Caracteres.Igual} {Constante.Caracteres.Coma}");
            }
            return stringBuilder.ToString().Substring(1, stringBuilder.ToString().Length - 1);
        }

        public string EntityToSerializedXML()
        {
            string comillasDobles = Constante.Caracteres.ComillasDobles;
            Type type = this.GetType();
            string str1 = $"<{type.Name} xmlns:xsd={comillasDobles}http://www.w3.org/2001/XMLSchema{comillasDobles} xmlns:xsi={comillasDobles}http://www.w3.org/2001/XMLSchema-instance{comillasDobles} xmlns={comillasDobles}http://tempuri.org/{comillasDobles}>" + "\r\n";
            foreach (PropertyInfo property in type.GetProperties())
            {
                string str2;
                if (property.GetValue((object)this, (object[])property.GetIndexParameters()) != null)
                    str2 = $"{str1}<{property.Name.ToString()}>{property.GetValue((object)this, (object[])property.GetIndexParameters())?.ToString()}</{property.Name.ToString()}>";
                else
                    str2 = $"{str1}<{property.Name.ToString()}/>";
                str1 = str2 + "\r\n";
            }
            return $"{str1}<{type.Name}/>";
        }
    }
}
