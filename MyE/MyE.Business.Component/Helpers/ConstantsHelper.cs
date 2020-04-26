using Microsoft.Extensions.Configuration;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyE.Business.Component.Helpers
{
    public static class ConstantsHelper
    {
        

        public const string API_KEYSECRETA= "MyE_astra_keytoken";   //clave creo

        //public static string GetWebSettingValue(string key)
        //   => WebConfigurationManager.AppSettings[key];

        public const string API_VERSION = "v1";
        public static string SESSION_EXPIRED_MESSAGE = "Su sesión ha caducado. Por favor, ingrese nuevamente.";

        public const string ENTIDAD_ESTADO_ACTIVO = "ACT";
        public const string ENTIDAD_ESTADO_INACTIVO = "INA";
        public const string USUARIO_ESTADO_BLOQUEADO = "BLO";
       

        public const string ROL_CODIGO_ADMINISTRADOR = "ADM";
        public const string ROL_CODIGO_CONDUCTOR = "CON";
        public const string ROL_CODIGO_CLIENTE = "CLI";
        public const string ROL_CODIGO_AGENTE_ADUANERO = "ADU";
        public const string ROL_CODIGO_SUPERVISOR = "SUP";

        public static string[] USUARIO_ROLES_PERMITIDOS = { ROL_CODIGO_CLIENTE, ROL_CODIGO_AGENTE_ADUANERO, ROL_CODIGO_SUPERVISOR, ROL_CODIGO_ADMINISTRADOR };

        public static string ToSafeString(this object obj, string strDefault = "")
        {
            return obj == null ? strDefault : obj.ToString();
        }

        public static string WithStringIsEmpty(this object obj, string strDefault)
        {
            return string.IsNullOrEmpty(ToSafeString(obj)) ? strDefault : ToSafeString(obj);
        }

        public static string GenerateShortUniqueString()
        {
            return Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-")).ToUpper();
        }
        public static string GetAppSettingValue(string key, string strDefault = "")
        {           
            return string.IsNullOrEmpty(key) ? "" : ConfigurationManager.AppSettings[key].ToSafeString(strDefault);
        }



        public static string RenderEntidadEstado(string estado)
        {
            return "<span class=\"\" style=\"color: " + GetEntidadEstadoColor(estado) + " !important;\">" + GetEntidadEstadoTexto(estado) + "</span>";
        }
        public static string GetEntidadEstadoColor(string estado)
        {
            var color = "";

            switch (estado)
            {
                case ENTIDAD_ESTADO_ACTIVO: color = "green"; break;
                case ENTIDAD_ESTADO_INACTIVO: color = "blue"; break;
                case USUARIO_ESTADO_BLOQUEADO: color = "red"; break;
                default: return "";
            }

            return color;
        }
        public static string GetEntidadEstadoTexto(string estado)
        {
            var texto = "";

            switch (estado)
            {
                case ENTIDAD_ESTADO_ACTIVO: texto = "Activo"; break;
                case ENTIDAD_ESTADO_INACTIVO: texto = "Inactivo"; break;
                case USUARIO_ESTADO_BLOQUEADO: texto = "Bloqueado"; break;
                default: return "";
            }

            return texto;
        }
    }
}
