using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyE.Business.Entities.Response
{
    public class OrdenRqst
    {
        [Required]
        [Display(Name = "lugar_persona_id")]
        [JsonProperty(PropertyName = "lugar_persona_id")]
        public int Lugar_PersonaId { get; set; }

        [Required]
        [Display(Name = "fecha_generacion")]
        [JsonProperty(PropertyName = "fecha_generacion")]
        public DateTime FechaGeneracion { get; set; }

        [Display(Name = "fecha_ejecucion")]
        [JsonProperty(PropertyName = "fecha_ejecucion")]
        public DateTime FechaEjecucion { get; set; }

        [Required]
        [Display(Name = "estado")]
        [JsonProperty(PropertyName = "estado")]
        public string Estado { get; set; }

        [Required]
        [Display(Name = "empleado_id")]
        [JsonProperty(PropertyName = "empleado_id")]
        public int EmpleadoId { get; set; }
    }
}