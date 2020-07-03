using System.ComponentModel.DataAnnotations;
using MyE.Entities;
using Newtonsoft.Json;

namespace MyE.Business.Entities.Response
{
    public class LugarClienteRes
    {     
        public int lugarClienteId { get; set; }

        public string direccion { get; set; }

        public string lugarReferencia { get; set; }

        public string ubigeo{ get; set; }

        public string nombreSede { get; set; }
       
        public string nombreCliente { get; set; }

        public int numContacto{ get; set; }

        public string correo{ get; set; }

        public decimal? cordX{ get; set; }

        public decimal? cordY{ get; set; }


        public LugarClienteRes(LugarCliente objLugarPersona)
        {
            this.lugarClienteId = objLugarPersona.ClienteId;
            this.lugarReferencia= objLugarPersona.Lugar.LugarReferencia;
            this.nombreCliente = objLugarPersona.Cliente.ClienteNavigation.Npersona;
            this.nombreSede = objLugarPersona.NombreSede;
            this.numContacto = objLugarPersona.NumContacto;
            this.direccion = objLugarPersona.Lugar.Tdireccion;
            this.ubigeo = objLugarPersona.Lugar.Ubigeo;
            this.cordX = objLugarPersona.CordX;
            this.cordY = objLugarPersona.CordY;
        }
        public LugarClienteRes() { }
    }
}
