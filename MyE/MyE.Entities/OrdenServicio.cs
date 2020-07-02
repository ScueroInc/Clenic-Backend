using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class OrdenServicio
    {
        public OrdenServicio()
        {
            Reporte = new HashSet<Reporte>();
        }

        public int OrdenServicioId { get; set; }
        public int ServicioId { get; set; }
        public int OrdenDetalleId { get; set; }
        public decimal Precio { get; set; }

        public virtual OrdenDetalle OrdenDetalle { get; set; }
        public virtual Servicio Servicio { get; set; }
        public virtual ICollection<Reporte> Reporte { get; set; }
    }
}