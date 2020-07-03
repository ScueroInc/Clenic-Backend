using System.ComponentModel.DataAnnotations;
using MyE.Entities;
using Newtonsoft.Json;

namespace MyE.Business.Entities.Response
{
    public class FabricanteRes
    {
        [Display(Name = "fabricanteId")]
        [JsonProperty(PropertyName = "fabricanteId")]
        public int fabricanteId { get; set; }

        [Display(Name = "nombreFabricante")]
        [JsonProperty(PropertyName = "nombreFabricante")]
        public string nombreFabricante { get; set; }       
       

        public FabricanteRes(Fabricante objFabricante, bool isLogin = false)
        {
            this.nombreFabricante = objFabricante.Nfabricante;
            this.fabricanteId = objFabricante.FabricanteId;
        }
        public FabricanteRes() { }
    }
}
