using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyE.Presentation.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class healthController : BaseApiController
    {
        [HttpHead]
        [Route("")]
        public IActionResult Test()
        {
            var response = default(IActionResult);
            try
            {
                response = Ok(new
                {
                    StatusCode = "Up"
                });
            }
            catch (Exception ex)
            {
                response = base.ErrorResponse(ex);
            }
            return response;
        }
    }
}
