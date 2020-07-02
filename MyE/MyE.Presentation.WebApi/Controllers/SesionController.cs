using Microsoft.AspNetCore.Mvc;
using MyE.Business.Entities.Response;
using MyE.Business.Workflow;
using System;

namespace MyE.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SesionController : BaseApiController
    {
        private LoginBW objBusiness = new LoginBW();

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