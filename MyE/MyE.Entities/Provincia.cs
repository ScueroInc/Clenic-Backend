using System;
using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Provincia
    {
        public Provincia()
        {
            Distrito = new HashSet<Distrito>();
        }

        public string ProvinciaId { get; set; }
        public string DepartamentoId { get; set; }
        public string Nprovincia { get; set; }

        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<Distrito> Distrito { get; set; }
    }
}
