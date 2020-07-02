using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyE.Business.Entities.Response
{
    public class ErrorResponse
    {
        [Display(Name = "message")]
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        public ErrorResponse()
        {
        }

        public ErrorResponse(string message)
        {
            this.Message = message;
        }
    }
}