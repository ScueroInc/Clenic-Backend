using System;
using System.Collections.Generic;

namespace MyE.Entities
{
    public partial class Usuario
    {
        public string UsuarioId { get; set; }
        public int PersonaId { get; set; }
        public string Psw { get; set; }
        public string Perfil { get; set; }
        public string Token { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
