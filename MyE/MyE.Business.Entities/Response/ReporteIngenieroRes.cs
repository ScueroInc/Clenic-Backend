using System;
using System.ComponentModel.DataAnnotations;
using MyE.Entities;
using Newtonsoft.Json;

namespace MyE.Business.Entities.Response
{
    public class ReporteIngenieroRes
    {
        [Display(Name = "id_reporte")]
        [JsonProperty(PropertyName = "id_reporte")]
        public int ReporteId { get; set; }

        [Display(Name = "asunto")]
        [JsonProperty(PropertyName = "asunto")]
        public string Asunto { get; set; }
        
        [Display(Name = "observacion")]
        [JsonProperty(PropertyName = "observacion")]
        public string Observacion { get; set; }

        [Display(Name = "fechaGeneracion")]
        [JsonProperty(PropertyName = "fechaGeneracion")]
        public DateTime FechaGeneracion{ get; set; }

        [Display(Name = "fechaEjecucion")]
        [JsonProperty(PropertyName = "fechaEjecucion")]
        public DateTime FechaEjecucion { get; set; }

        [Display(Name = "fechaAtencion")]
        [JsonProperty(PropertyName = "fechaAtencion")]
        public DateTime FechaAtencion { get; set; }

        [Display(Name = "id_ordenServicio")]
        [JsonProperty(PropertyName = "id_ordenServicio")]
        public int OrdenServicioId { get; set; }

        [Display(Name = "id_servicio")]
        [JsonProperty(PropertyName = "id_servicio")]
        public int ServicioId{ get; set; }

        [Display(Name = "nombreServicio")]
        [JsonProperty(PropertyName = "nombreServicio")]
        public string NombreServicio { get; set; }

   
        //[Display(Name = "num_contacto")]
        //[JsonProperty(PropertyName = "num_contacto")]
        //public int NumContacto { get; set; }

        //[Display(Name = "direccion")]
        //[JsonProperty(PropertyName = "direccion")]
        //public string Tdireccion { get; set; }
        //public UsuarioResponse()
        //{

        //}

        public ReporteIngenieroRes(Reporte objReporte)
        {
            this.Asunto= objReporte.Asunto;
            this.FechaAtencion= objReporte.FechaAtencion.Value;
            this.FechaEjecucion= objReporte.FechaEjecucion.Value;
            this.FechaGeneracion = objReporte.FechaGeneracion;
            this.Observacion= objReporte.Observacion;
            this.OrdenServicioId = objReporte.OrdenServicioId;
            this.ServicioId= objReporte.OrdenServicio.ServicioId;
            this.NombreServicio = objReporte.OrdenServicio.Servicio.Nservicio;       
        }
        public ReporteIngenieroRes() { }
    }
}
