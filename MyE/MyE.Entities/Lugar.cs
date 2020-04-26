using System;
using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Lugar
    {
        public Lugar()
        {
            LugarCliente = new HashSet<LugarCliente>();
        }

        public int LugarId { get; set; }
        public string Tdireccion { get; set; }
        public string LugarReferencia { get; set; }
        public string Ubigeo { get; set; }

        public virtual Distrito UbigeoNavigation { get; set; }
        public virtual ICollection<LugarCliente> LugarCliente { get; set; }
    }
}
