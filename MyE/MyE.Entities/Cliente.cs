using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            LugarCliente = new HashSet<LugarCliente>();
        }

        public int ClienteId { get; set; }
        public string Nsector { get; set; }

        public virtual Persona ClienteNavigation { get; set; }
        public virtual ICollection<LugarCliente> LugarCliente { get; set; }
    }
}