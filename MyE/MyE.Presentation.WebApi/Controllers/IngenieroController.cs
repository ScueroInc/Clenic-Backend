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
    public class IngenieroController : BaseApiController
    {
        IngenierosBW objBusinessIngenieros = new IngenierosBW();
     
        [Produces("application/json")]
        [HttpGet]
        [Route("listaIngenieros")]
        public IActionResult ListarIngenieros() {
            var response = default(IActionResult);
            try
            {
                var objUsuario = base.GetUsuario();
                if (objUsuario is null) throw new ExceptionHelper("No se a iniciado sesion");
                var tokenAvalidar = objUsuario.SessionToken;   

                var res = base.validateToken(objUsuario, tokenAvalidar);


                if (res)
                {
                    var listaIngenieros = objBusinessIngenieros.ListarIngenieros();
                    response = Ok(listaIngenieros);
                }
                else {
                    throw new ExceptionHelper("HACKER");
                }                
            }
            catch (Exception ex){
                response = base.ErrorResponse(ex);
            }
            return response;
        }

        [Produces("application/json")]
        [HttpGet]
        [Route("getingeniero")]
        public IActionResult ObtenerIngeniero(int ingenieroId)
        {
            var response = default(IActionResult);
            try
            {
                var objUsuario = base.GetUsuario();
                if (objUsuario is null) throw new ExceptionHelper("No se a iniciado sesion");
                var tokenAvalidar = objUsuario.SessionToken;
                var res = base.validateToken(objUsuario, tokenAvalidar);

                if (res)
                {
                    var ingeniero = objBusinessIngenieros.ObtenerIngeniero(ingenieroId);
                    response = Ok(ingeniero);
                }
                else
                {
                    throw new ExceptionHelper("Ocurrio un error inesperado, vuelva a intentarlo");
                }
            }
            catch (Exception ex)
            {
                response = base.ErrorResponse(ex);
            }
            return response;
        }
    }
}