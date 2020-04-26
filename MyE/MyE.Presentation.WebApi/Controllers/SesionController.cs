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
                var res = base.Login(model);
                response = Ok(res);
                }
                catch (Exception ex)
                {
                    response = base.ErrorResponse(ex);
                }
                return response;
        }


    }
}