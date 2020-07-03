using System.ComponentModel.DataAnnotations;
using MyE.Entities;
using Newtonsoft.Json;

namespace MyE.Business.Entities.Response
{
    public class IngenieroRes
    {
        [Display(Name = "id")]
        [JsonProperty(PropertyName = "id")]
        public int IngenieroId { get; set; }

        [Display(Name = "nombreIngeniero")]
        [JsonProperty(PropertyName = "nombreIngeniero")]
        public string Nombre { get; set; }

        [Display(Name = "direccion")]
        [JsonProperty(PropertyName = "direccion")]
        public string Direccion { get; set; }


        [Display(Name = "email")]
        [JsonProperty(PropertyName = "email")]
        public string Correo{ get; set; }

        [Display(Name = "NumeroContacto")]
        [JsonProperty(PropertyName = "NumeroContacto")]
        public int NumeroContacto{ get; set; }

        [Display(Name = "numeroDni")]
        [JsonProperty(PropertyName = "numeroDni")]
        public string Dni{ get; set; }

        [Display(Name = "cordX")]
        [JsonProperty(PropertyName = "cordX")]
        public decimal? cordX { get; set; }

        [Display(Name = "cordY")]
        [JsonProperty(PropertyName = "cordY")]
        public decimal? cordY { get; set; }

        public IngenieroRes(Persona objIngeniero)
        {
            this.IngenieroId = objIngeniero.Empleado.EmpleadoId;
            this.Nombre = objIngeniero.Npersona;
            this.NumeroContacto = objIngeniero.Empleado.NumContacto;
            this.Direccion = objIngeniero.Empleado.Tdireccion;
            this.Correo = objIngeniero.Empleado.Correo;
            this.Dni = objIngeniero.Empleado.Dni;
            this.cordX = objIngeniero.Empleado.CordX;
            this.cordY = objIngeniero.Empleado.CordY;
        }
        public IngenieroRes() { }
    }
}
