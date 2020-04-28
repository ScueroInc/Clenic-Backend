using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyE.Business.Component.Helpers;
using MyE.Business.Entities.Response;
using MyE.Business.Workflow;

namespace MyE.Presentation.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdenController : BaseApiController
    {
        OrdenBW objBusinessOrdenes = new OrdenBW();
     
        [Produces("application/json")]
        [HttpGet]
        [Route("listaOrdenes")]
        public IActionResult ListarOrdens() {
            var response = default(IActionResult);
            try
            {
                var objUsuario = base.GetUsuario();
                if (objUsuario is null) throw new ExceptionHelper("No se a iniciado sesion");
                var tokenAvalidar = objUsuario.SessionToken;
                SecurityHelper.ValidateToken(tokenAvalidar);

                var res = base.validarTokenConData(objUsuario.UsuarioId, tokenAvalidar);


                if (res)
                {
                    var listaOrdenes = objBusinessOrdenes.ListarOrdenesDeIngeniero(objUsuario.PersonaId);
                    response = Ok(listaOrdenes);
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

       

    }
}