using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyE.Business.Component.Helpers;
using MyE.Business.Workflow;

namespace MyE.Presentation.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EjemplarController : BaseApiController
    {
        EjemplarBW objBusinessIngenieros = new EjemplarBW();

   
        [Produces("application/json")]
        [HttpGet]
        [Route("listarEjemplares")]
        public IActionResult ListarEjemplares() {
            var response = default(IActionResult);
            try
            {
                //var objUsuario = base.GetUsuario();
                //if (objUsuario is null) throw new ExceptionHelper(401,"No se a iniciado sesion");
                //if (!(objUsuario.Perfil == "A" || objUsuario.Perfil == "S")) throw new ExceptionHelper(401, "No tiene los permisos para acceder");
                //var tokenSesion = objUsuario.SessionToken;   
                //var res = base.validateToken(objUsuario, tokenSesion);
                //if (res is null) throw new ExceptionHelper(401,"Token inválido");
            
                var listaEjemplares = objBusinessIngenieros.ListarEjemplares();              
                response = Ok(listaEjemplares);                                           
            }
            catch (ExceptionHelper ex){
                response = base.ErrorResponse(ex);
            }
            return response;
        }

    }
}