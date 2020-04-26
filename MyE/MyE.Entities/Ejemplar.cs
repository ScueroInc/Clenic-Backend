using System;
using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Ejemplar
    {
        public Ejemplar()
        {
            OrdenDetalle = new HashSet<OrdenDetalle>();
        }

        public int EjemplarId { get; set; }
        public int NumSerie { get; set; }
        public int EquipoId { get; set; }

        public virtual Equipo Equipo { get; set; }
        public virtual ICollection<OrdenDetalle> OrdenDetalle { get; set; }
    }
}
