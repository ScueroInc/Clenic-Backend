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
                SqlContext context = new SqlContext();
                var objUsuario = base.GetUsuario();
                //var _objUsuario = context.Usuario
                //                        .Include(e=>e.Persona)
                //                        .Single(e=>e.UsuarioId=="gonzaloescudero");
                //var objUsuario = new UsuarioRes {
                //    Nombre = _objUsuario.Persona.Npersona,
                //    Perfil=_objUsuario.Perfil,
                //    PersonaId=_objUsuario.PersonaId,
                //    SessionToken=_objUsuario.Token,
                //    UsuarioId=_objUsuario.UsuarioId
                //};
                if (objUsuario is null) throw new ExceptionHelper("No se a iniciado sesion");
                // var tokenAvalidar = objUsuario.SessionToken;
                var tokenAvalidar = objUsuario.SessionToken;
                var res = base.validateToken(objUsuario, tokenAvalidar);

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

        [HttpPost]
        [Route("insertorden")]
        public IActionResult RegistrarOrden(OrdenRqst newOrden)
        {
            var response = default(IActionResult);
            try
            {
                base.ValidarModelo(newOrden);
                var objUsuario = base.GetUsuario();
                if (objUsuario is null) throw new ExceptionHelper("No se a iniciado sesion");
                var tokenAvalidar = objUsuario.SessionToken;
                var res = base.validateToken(objUsuario, tokenAvalidar);
                if (res)
                {
                    var respuesta = objBusinessOrdenes.RegistrarOrden(newOrden);
                    response = Ok();
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

    }
}