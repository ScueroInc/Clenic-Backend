using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Empleado
    {
        public Empleado()
        {
            Orden = new HashSet<Orden>();
        }

        public int EmpleadoId { get; set; }
        public string Dni { get; set; }
        public string Tdireccion { get; set; }
        public int NumContacto { get; set; }
        public string Correo { get; set; }
        public decimal? CordX { get; set; }
        public decimal? CordY { get; set; }

        public virtual Persona EmpleadoNavigation { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
    }
}