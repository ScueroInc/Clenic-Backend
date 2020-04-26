using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
