using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyE.Business.Component.Helpers;
using MyE.Business.Entities;
using MyE.Business.Entities.Response;
using MyE.Business.Workflow;
using Newtonsoft.Json;

namespace MyE.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SesionController : BaseApiController
    {
        LoginBW objBusiness = new LoginBW();
        [HttpPost]
        [Route("login")]
        public IActionResult Loguearse([FromBody] LoginRequest model)
        {            
            var response = default(IActionResult);
            try
            {
                base.ValidarModelo(model);
                var UsuarioRes = objBusiness.Loguearse(model.Username, model.Password);
                if (UsuarioRes == null) throw new ExceptionHelper(401,"¡Autenticacion fallida!");
                HttpContext.Session.Set("USUARIO", ConvertHelper.ToByteArray(JsonConvert.SerializeObject(UsuarioRes)));
            
                response = Ok(UsuarioRes);
            }
            catch (ExceptionHelper ex)
            {                
                response = base.ErrorResponse(ex); 
            }
                return response;
        }

        [HttpDelete]
        [Route("cerrarsesion")]
        public IActionResult CerrarSesion()
        {
            var response = default(IActionResult);
            try
            {
                HttpContext.Session.Clear();             
                response = Ok();
            }
            catch 
            {
                response = base.ErrorResponse(new ExceptionHelper(400,"Error inesperado al cerrar sesion"));
            }
            return response;
        }


    }
}