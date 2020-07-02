using Microsoft.AspNetCore.Mvc;
using MyE.Business.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyE.Business.Component.Helpers
{
    public class ExceptionHelper : Exception
    {
        public ExceptionHelper(string message) : base(message) { }
        public ContentResult contentRespuesta { get; set; }
        public ExceptionHelper(ContentResult objeto)
        {
            this.contentRespuesta = objeto;
        }  

        public ExceptionHelper(int statusCode=400,string mensaje="Ocurrio un error") : base() {
            contentRespuesta = new ContentResult
            {
                StatusCode = statusCode,
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject( new {mensaje })
            };
        }
    }
}
