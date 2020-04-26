using System;
using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Modelo
    {
        public Modelo()
        {
            Equipo = new HashSet<Equipo>();
        }

        public int ModeloId { get; set; }
        public string Nmodelo { get; set; }
        public int EquipoId { get; set; }

        public virtual Fabricante EquipoNavigation { get; set; }
        public virtual ICollection<Equipo> Equipo { get; set; }
    }
}
