using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyE.Business.Entities.Response
{
    public class ReporteRqst
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "asunto")]
        [JsonProperty(PropertyName = "asunto")]
        public string Asunto { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "observacion")]
        [JsonProperty(PropertyName = "observacion")]
        public string Observacion { get; set; }

        [Display(Name = "fechaAtencion")]
        [JsonProperty(PropertyName = "fechaAtencion")]
        public DateTime FechaAtencion { get; set; }

        [Display(Name = "fechaEjecucion")]
        [JsonProperty(PropertyName = "fechaEjecucion")]
        public DateTime FechaEjecucion { get; set; }

        [Required]
        [Display(Name = "ordenServicioId")]
        [JsonProperty(PropertyName = "ordenServicioId")]
        public int OrdenServicioId { get; set; }
    }
}