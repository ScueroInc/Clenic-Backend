using System;
using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Distrito
    {
        public Distrito()
        {
            Lugar = new HashSet<Lugar>();
        }

        public string Ubigeo { get; set; }
        public string DistritoId { get; set; }
        public string Ndistrito { get; set; }
        public string ProvinciaId { get; set; }
        public string DepartamentoId { get; set; }

        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<Lugar> Lugar { get; set; }
    }
}
