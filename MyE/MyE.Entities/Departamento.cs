using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Departamento
    {
        public Departamento()
        {
            Provincia = new HashSet<Provincia>();
        }

        public string DepartamentoId { get; set; }
        public string Ndepartamento { get; set; }

        public virtual ICollection<Provincia> Provincia { get; set; }
    }
}