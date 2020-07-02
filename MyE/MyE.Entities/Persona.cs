using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int PersonaId { get; set; }
        public string Npersona { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}