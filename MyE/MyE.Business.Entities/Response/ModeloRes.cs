using System.ComponentModel.DataAnnotations;
using MyE.Entities;
using Newtonsoft.Json;

namespace MyE.Business.Entities.Response
{
    public class ModeloRes
    {
        [Display(Name = "modeloId")]
        [JsonProperty(PropertyName = "modeloId")]
        public int modeloId { get; set; }

        [Display(Name = "nombreModelo")]
        [JsonProperty(PropertyName = "nombreModelo")]
        public string nombreModelo { get; set; }

        public FabricanteRes fabricante { get; set; }

        public ModeloRes(Modelo objModelo, bool isLogin = false)
        {
            this.modeloId = objModelo.ModeloId;
            this.nombreModelo = objModelo.Nmodelo;
            this.fabricante = new FabricanteRes(objModelo.Fabricante);
        }
        public ModeloRes() { }
    }
}
