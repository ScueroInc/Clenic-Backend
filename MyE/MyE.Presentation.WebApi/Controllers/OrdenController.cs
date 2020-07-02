using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyE.Business.Component.Helpers;
using MyE.Business.Entities.Response;
using MyE.Business.Workflow;
using MyE.Data;
using MyE.Entities;

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
        public IActionResult ListarOrdenes() {
            var response = default(IActionResult);
            try
            {
                var objUsuario = base.GetUsuario();
                if (objUsuario is null) throw new ExceptionHelper(401, "No se a iniciado sesion");               
                var tokenSesion = objUsuario.SessionToken;

                var res = base.validateToken(objUsuario, tokenSesion);
                if (res is null) throw new ExceptionHelper(401, "Token inválido");
                                               
                var listaOrdenes = objBusinessOrdenes.ListarOrdenesDeIngeniero(objUsuario);
                response = Ok(listaOrdenes);                         
            }
            catch (ExceptionHelper ex){
                response = base.ErrorResponse(ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertorden")]
        public IActionResult RegistrarOrden(OrdenRqst newOrden)
        {
            var response = default(IActionResult);
            try
            {
                var objUsuario = base.GetUsuario();
                if (objUsuario is null) throw new ExceptionHelper(401, "No se a iniciado sesion");
                var tokenSesion = objUsuario.SessionToken;

                var res = base.validateToken(objUsuario, tokenSesion);
                if (res is null) throw new ExceptionHelper(401, "Token inválido");
            
                var respuesta = objBusinessOrdenes.RegistrarOrden(newOrden);
                response = Ok();           
            }
            catch (ExceptionHelper ex)
            {
                response = base.ErrorResponse(ex);
            }
            return response;
        }

    }
}