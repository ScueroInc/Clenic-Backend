using System.ComponentModel.DataAnnotations;
using MyE.Entities;
using Newtonsoft.Json;

namespace MyE.Business.Entities.Response
{
    public class EjemplarRes
    {
        [Display(Name = "id")]
        [JsonProperty(PropertyName = "id")]
        public string UsuarioId { get; set; }

        [Display(Name = "nombre")]
        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }
        
        [Display(Name = "session_token")]
        [JsonProperty(PropertyName = "session_token")]
        public string SessionToken { get; set; }

        //[Display(Name = "correo")]
        //[JsonProperty(PropertyName = "correo")]
        //public string Correo { get; set; }

        [Display(Name = "perfil")]
        [JsonProperty(PropertyName = "perfil")]
        public string Perfil { get; set; }

        [Display(Name = "personaId")]
        [JsonProperty(PropertyName = "personaId")]
        public int PersonaId { get; set; }

        //[Display(Name = "dni")]
        //[JsonProperty(PropertyName = "dni")]
        //public string Dni { get; set; }

        //[Display(Name = "num_contacto")]
        //[JsonProperty(PropertyName = "num_contacto")]
        //public int NumContacto { get; set; }

        //[Display(Name = "direccion")]
        //[JsonProperty(PropertyName = "direccion")]
        //public string Tdireccion { get; set; }
        //public UsuarioResponse()
        //{

        //}

        //public UsuarioRes(Usuario usuario, bool isLogin = false)
        //{
        //    this.UsuarioId = usuario.UsuarioId;
        //    this.Nombre = usuario.Persona.Npersona;
        //    this.PersonaId= usuario.PersonaId;           
        //    this.SessionToken = isLogin ? usuario.Token : "";
        //    this.Perfil = usuario.Perfil;
        //    //this.Dni= usuario.Persona.Empleado.Dni;
        //    //this.NumContacto = usuario.Persona.Empleado.NumContacto;
        //    //this.Tdireccion = usuario.Persona.Empleado.Tdireccion;
        //}
        //public UsuarioRes() { }
    }
}
