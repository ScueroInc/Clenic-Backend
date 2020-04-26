using System;
using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Servicio
    {
        public Servicio()
        {
            OrdenServicio = new HashSet<OrdenServicio>();
        }

        public int ServicioId { get; set; }
        public string Nservicio { get; set; }
        public decimal Precio { get; set; }

        public virtual ICollection<OrdenServicio> OrdenServicio { get; set; }
    }
}
