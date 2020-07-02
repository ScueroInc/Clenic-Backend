using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Equipo
    {
        public Equipo()
        {
            Ejemplar = new HashSet<Ejemplar>();
        }

        public int EquipoId { get; set; }
        public string CodBarra { get; set; }
        public int ModeloId { get; set; }

        public virtual Modelo Modelo { get; set; }
        public virtual ICollection<Ejemplar> Ejemplar { get; set; }
    }
}