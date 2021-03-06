﻿using System;
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
    public class LugarPersonaController : BaseApiController
    {
        LugarClienteBW objBusinessLugarCliente = new LugarClienteBW();

        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            var response = default(IActionResult);
            try
            {
                response = Ok(new { 
                atributo="gEEEEEE"
                });
            }
            catch (ExceptionHelper ex)
            {
                response = base.ErrorResponse(ex);
            }
            return response;
        }

        [Produces("application/json")]
        [HttpGet]
        [Route("listaLugarCliente")]
        public IActionResult ListarLugarCliente() {
            var response = default(IActionResult);
            try
            {
                var objUsuario = base.GetUsuario();
                if (objUsuario is null) throw new ExceptionHelper(401,"No se a iniciado sesion");
                //if (!(objUsuario.Perfil == "A" || objUsuario.Perfil == "S")) throw new ExceptionHelper(401, "No tiene los permisos para acceder");
                var tokenSesion = objUsuario.SessionToken;   
                var res = base.validateToken(objUsuario, tokenSesion);
                if (res is null) throw new ExceptionHelper(401,"Token inválido");
            
                var listaLugarCliente = objBusinessLugarCliente.Listar_PersonasId();              
                response = Ok(listaLugarCliente);                                           
            }
            catch (ExceptionHelper ex){
                response = base.ErrorResponse(ex);
            }
            return response;
        }
    }
}