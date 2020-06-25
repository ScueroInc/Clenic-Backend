using System;
using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class LugarCliente
    {
        public LugarCliente()
        {
            Orden = new HashSet<Orden>();
        }

        public int LugarClienteId { get; set; }
        public int LugarId { get; set; }
        public string NombreSede { get; set; }
        public int ClienteId { get; set; }
        public int NumContacto { get; set; }
        public string Correo { get; set; }
        public decimal? CordX { get; set; }
        public decimal? CordY { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Lugar Lugar { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
    }
}
