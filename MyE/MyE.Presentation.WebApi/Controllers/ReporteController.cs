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
    public class ReporteController : BaseApiController
    {
        ReporteBW objBusinessReportes = new ReporteBW();
     
        //[Produces("application/json")]
        //[HttpGet]
        //[Route("listaReportes")]
        //public IActionResult ListarReportes() {
        //    var response = default(IActionResult);
        //    try
        //    {
        //        var objUsuario = base.GetUsuario();
        //        if (objUsuario is null) throw new ExceptionHelper("No se ha iniciado sesion");
        //        var tokenAvalidar = objUsuario.SessionToken;
        //        var res = base.validateToken(objUsuario, tokenAvalidar);

        //        if (res)
        //        {
        //            var listaReportes = objBusinessReportes.ListarReportesDeIngeniero(objUsuario.PersonaId);
        //            response = Ok(listaReportes);
        //        }
        //        else {
        //            throw new ExceptionHelper("HACKER");
        //        }                
        //    }
        //    catch (ExceptionHelper ex){
        //        response = base.ErrorResponse(ex);
        //    }
        //    return response;
        //}

        //[Produces("application/json")]
        //[HttpPost]
        //[Route("insertreporte")]
        //public IActionResult RegistrarReporte(ReporteRqst objReporte)
        //{                     
        //    var response = default(IActionResult);
        //    try
        //    {
        //        base.ValidarModelo(objReporte);
        //        var objUsuario = base.GetUsuario();
        //        if (objUsuario is null) throw new ExceptionHelper("No se a iniciado sesion");
        //        var tokenAvalidar = objUsuario.SessionToken;
        //        var res = base.validateToken(objUsuario, tokenAvalidar);
        //        if (res)
        //        {
        //            var respuesta=objBusinessReportes.RegistrarReporte(objReporte);
        //            response = Ok();
        //        }
        //        else
        //        {
        //            throw new ExceptionHelper("HACKER");
        //        }
        //    }
        //    catch (ExceptionHelper ex)
        //    {
        //        response = base.ErrorResponse(ex);
        //    }
        //    return response;
        //}

        //[Produces("application/json")]
        //[HttpGet]
        //[Route("getReporte")]
        //public IActionResult ObtenerReporte(string UsuarioId)
        //{
        //    var response = default(IActionResult);
        //    try
        //    {
        //        var objUsuario = base.GetUsuario();
        //        if (objUsuario is null) throw new ExceptionHelper("No se a iniciado sesion");
        //        var tokenAvalidar = objUsuario.SessionToken;
        //        SecurityHelper.ValidateToken(tokenAvalidar);

        //        var res = base.validarTokenConData(objUsuario.UsuarioId, tokenAvalidar);

        //        if (res)
        //        {
        //            var Reporte = objBusinessReportes.ObtenerReporte(UsuarioId);
        //            response = Ok(Reporte);
        //        }
        //        else
        //        {
        //            throw new ExceptionHelper("Ocurrio un error inesperado, vuelva a intentarlo");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response = base.ErrorResponse(ex);
        //    }
        //    return response;
        //}
    }
}