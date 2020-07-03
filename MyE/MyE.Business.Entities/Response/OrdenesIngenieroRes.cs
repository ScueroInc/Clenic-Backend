using System;
using System.ComponentModel.DataAnnotations;
using MyE.Entities;
using Newtonsoft.Json;

namespace MyE.Business.Entities.Response
{
    public class OrdenesIngenieroRes
    {
        [Display(Name = "id_orden")]
        [JsonProperty(PropertyName = "id_orden")]
        public int OrdenId { get; set; }

        [Display(Name = "nombreIngeniero")]
        [JsonProperty(PropertyName = "nombreIngeniero")]
        public string nombreIngeniero { get; set; }

        [Display(Name = "seriesEjemplar")]
        [JsonProperty(PropertyName = "seriesEjemplar")]
        public string seriesEjemplar { get; set; }

        [Display(Name = "serviciosNombre")]
        [JsonProperty(PropertyName = "serviciosNombre")]
        public string serviciosNombre { get; set; }

        [Display(Name = "fechaGeneracion")]
        [JsonProperty(PropertyName = "fechaGeneracion")]
        public DateTime? FechaGeneracion { get; set; }
        
        [Display(Name = "fechaEjecucion")]
        [JsonProperty(PropertyName = "fechaEjecucion")]
        public DateTime? FechaEjecucion { get; set; }

        [Display(Name = "estado")]
        [JsonProperty(PropertyName = "estado")]
        public string Estado { get; set; }

        [Display(Name = "id_lugar_personas")]
        [JsonProperty(PropertyName = "id_lugar_personas")]
        public int Lugar_PersonasId { get; set; }

        [Display(Name = "id_cliente")]
        [JsonProperty(PropertyName = "id_cliente")]
        public int ClienteId{ get; set; }


        [Display(Name = "nombreCliente")]
        [JsonProperty(PropertyName = "nombreCliente")]
        public string NombreCliente { get; set; }

        [Display(Name = "direccionLugar")]
        [JsonProperty(PropertyName = "direccionLugar")]
        public string DireccionLugar { get; set; }

        [Display(Name = "correoCliente")]
        [JsonProperty(PropertyName = "correoCliente")]
        public string CorreoCliente { get; set; }

        public OrdenesIngenieroRes(Orden objOrden)
        {
            this.nombreIngeniero = objOrden.Empleado.EmpleadoNavigation.Npersona;
            this.CorreoCliente= objOrden.LugarPersonas.Correo;
            this.DireccionLugar= objOrden.LugarPersonas.Lugar.Tdireccion;
            this.FechaEjecucion= objOrden.FechaEjecucion;
            this.FechaGeneracion = objOrden.FechaGeneracion.Value;
            this.Estado= objOrden.Estado;
            this.Lugar_PersonasId= objOrden.LugarPersonasId;
            this.NombreCliente= objOrden.LugarPersonas.Cliente.ClienteNavigation.Npersona;
            this.ClienteId = objOrden.LugarPersonas.Cliente.ClienteId;
            this.OrdenId= objOrden.OrdenId;
            this.serviciosNombre = "";
            this.seriesEjemplar = "";
            foreach (var elem in objOrden.OrdenDetalle) {
                this.seriesEjemplar += elem.Ejemplar.NumSerie;
                foreach (var elem2 in elem.OrdenServicio)
                {
                    this.serviciosNombre += elem2.Servicio.Nservicio;
                }
            }
            
        }
        public OrdenesIngenieroRes() { }
    }
}
