using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyE.Business.Entities.Response
{
    public class OrdenRqst
    {
        [Required]      
        [Display(Name = "lugar_persona_id")]
        [JsonProperty(PropertyName = "lugar_persona_id")]
        public int lugar_PersonaId{ get; set; }

    
        //[Display(Name = "fecha_ejecucion")]
        //[JsonProperty(PropertyName = "fecha_ejecucion")]
        //public DateTime FechaEjecucion { get; set; }

        [Required]
        [Display(Name = "empleadoId")]
        [JsonProperty(PropertyName = "empleadoId")]
        public int empleadoId{ get; set; }

        [Required]
        [Display(Name = "ejemplarId")]
        [JsonProperty(PropertyName = "ejemplarId")]
        public int ejemplarId { get; set; }

        [Required]
        [Display(Name = "servicioId")]
        [JsonProperty(PropertyName = "servicioId")]
        public int servicioId { get; set; }

    }
}
