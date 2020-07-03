using System.ComponentModel.DataAnnotations;
using MyE.Entities;
using Newtonsoft.Json;

namespace MyE.Business.Entities.Response
{
    public class EquipoRes
    {
        [Display(Name = "equipoId")]
        [JsonProperty(PropertyName = "equipoId")]
        public int equipoId { get; set; }

        [Display(Name = "codigoBarra")]
        [JsonProperty(PropertyName = "codigoBarra")]
        public string codigoBarra { get; set; }

        public ModeloRes modelo { get; set; }
              

        public EquipoRes(Equipo equipo, bool isLogin = false)
        {
            this.codigoBarra= equipo.CodBarra;
            this.equipoId = equipo.EquipoId;      
            this.modelo = new ModeloRes(equipo.Modelo);
        }
        public EquipoRes() { }
    }
}
