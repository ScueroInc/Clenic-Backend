using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class OrdenDetalle
    {
        public OrdenDetalle()
        {
            OrdenServicio = new HashSet<OrdenServicio>();
        }

        public int OrdenDetalleId { get; set; }
        public int OrdenId { get; set; }
        public int EjemplarId { get; set; }
        public string Estado { get; set; }

        public virtual Ejemplar Ejemplar { get; set; }
        public virtual Orden Orden { get; set; }
        public virtual ICollection<OrdenServicio> OrdenServicio { get; set; }
    }
}