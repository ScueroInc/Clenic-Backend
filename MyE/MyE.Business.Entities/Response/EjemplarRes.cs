using System.ComponentModel.DataAnnotations;
using MyE.Entities;
using Newtonsoft.Json;

namespace MyE.Business.Entities.Response
{
    public class EjemplarRes
    {
        [Display(Name = "ejemplarId")]
        [JsonProperty(PropertyName = "ejemplarId")]
        public int ejemplarId { get; set; }

        [Display(Name = "numeroSerieEjemplar")]
        [JsonProperty(PropertyName = "numeroSerieEjemplar")]
        public int numeroSerieEjemplar { get; set; }

        public EquipoRes Equipo { get; set; }

        public EjemplarRes(Ejemplar objEjemplar, bool isLogin = false)
        {
            this.ejemplarId = objEjemplar.EjemplarId;
            this.numeroSerieEjemplar = objEjemplar.NumSerie;
            this.Equipo = new EquipoRes(objEjemplar.Equipo);
        }
        public EjemplarRes() { }
    }
}
