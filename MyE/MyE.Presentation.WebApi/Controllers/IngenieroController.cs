using Microsoft.AspNetCore.Mvc;
using MyE.Business.Component.Helpers;
using MyE.Business.Workflow;
using System;

namespace MyE.Presentation.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IngenieroController : BaseApiController
    {
        private IngenierosBW objBusinessIngenieros = new IngenierosBW();

        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            var response = default(IActionResult);
            try
            {
                response = Ok(new
                {
                    atributo = "gaaa"
                });
            }
            catch (Exception ex)
            {
                response = base.ErrorResponse(ex);
            }
            return response;
        }

        [Produces("application/json")]
        [HttpGet]
        [Route("listaIngenieros")]
        public IActionResult ListarIngenieros()
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
                    var listaIngenieros = objBusinessIngenieros.ListarIngenieros();
                    response = Ok(listaIngenieros);
                }
                else
                {
                    throw new ExceptionHelper("HACKER");
                }
            }
            catch (Exception ex)
            {
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