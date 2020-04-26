using System;
using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Fabricante
    {
        public Fabricante()
        {
            Modelo = new HashSet<Modelo>();
        }

        public int FabricanteId { get; set; }
        public string Nfabricante { get; set; }

        public virtual ICollection<Modelo> Modelo { get; set; }
    }
}
