using System;
using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Orden
    {
        public Orden()
        {
            OrdenDetalle = new HashSet<OrdenDetalle>();
        }

        public int OrdenId { get; set; }
        public int LugarPersonasId { get; set; }
        public DateTime? FechaGeneracion { get; set; }
        public DateTime? FechaEjecucion { get; set; }
        public string Estado { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual LugarCliente LugarPersonas { get; set; }
        public virtual ICollection<OrdenDetalle> OrdenDetalle { get; set; }
    }
}