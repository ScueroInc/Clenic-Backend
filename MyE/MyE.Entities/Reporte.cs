using System;

namespace MyE.Entities
{
    public partial class Reporte
    {
        public int ReporteId { get; set; }
        public string Asunto { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public DateTime? FechaEjecucion { get; set; }
        public string Estado { get; set; }
        public int OrdenServicioId { get; set; }

        public virtual OrdenServicio OrdenServicio { get; set; }
    }
}