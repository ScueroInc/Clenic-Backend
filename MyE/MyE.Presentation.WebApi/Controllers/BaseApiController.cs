using MyE.Business.Component.Helpers;
using MyE.Business.Entities.Response;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Primitives;
using X.PagedList;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MyE.Business.Workflow;

namespace MyE.Presentation.WebApi.Controllers
{
    public class BaseApiController : ControllerBase
    {

        private LoginBW objBusinessLogin = new LoginBW();

        [NonAction]
        protected bool validateToken(UsuarioRes objUsuario, string tokenAvalidar)
        {
            SecurityHelper.ValidateTimeToken(tokenAvalidar);
            return objBusinessLogin.validarTokenConBd(objUsuario);
        }

        [NonAction]
        protected UsuarioRes Login(LoginRequest model)
        {
            var res = objBusinessLogin.Loguearse(model.Username, model.Password);
            HttpContext.Session.Set("USUARIO", ConvertHelper.ToByteArray(JsonConvert.SerializeObject(res)));
            return res;

        }

        [NonAction]
        protected bool IsAuthorized()
        {
            var isAuth = false;
            var bUsuario = default(byte[]);
            if (HttpContext.Session.TryGetValue("USUARIO", out bUsuario))
            {
                var jsonUsuario = ConvertHelper.FromByteArray<string>(bUsuario);
                var usuario = JsonConvert.DeserializeObject<UsuarioRes>(jsonUsuario);
                isAuth = true;//usuario.Perfil == ConstantsHelper.USUARIO_PERFIL_ADMINISTRADOR;
            }
            return isAuth;
        }

        [NonAction]
        protected UsuarioRes GetUsuario()
        {
            if (!IsAuthorized()) return null;

            var bUsuario = default(byte[]);
            HttpContext.Session.TryGetValue("USUARIO", out bUsuario);
            var jsonUsuario = ConvertHelper.FromByteArray<string>(bUsuario);
            var usuario = JsonConvert.DeserializeObject<UsuarioRes>(jsonUsuario);
            return usuario;
        }
        
        [NonAction]
        protected void ValidarModelo(object model)
        {
            if (model == null)
                throw new Exception("No se ha enviado ningún dato.");

            if (!ModelState.IsValid)
            {
                var result = new List<string>();

                var errorMessages = ModelState.Values.Select(x => x.Errors.Select(y => new { y.ErrorMessage }));

                foreach (var x in errorMessages)
                    foreach (var y in x)
                        result.Add(y.ErrorMessage ?? "");

                result.RemoveAll(string.IsNullOrEmpty);

                var message = (result.Count > 1 ? "-" : "") + string.Join("\n-", result.ToArray());

                throw new Exception(message);
            }
        }

        [NonAction]
        protected void AddLogTrace(object requestData, object responseData)
        {
            // TODO
        }

        [NonAction]
        protected IActionResult ErrorResponse(Exception ex)
        {
            var message = ex.Message;
            return BadRequest(new { message });
        }

        [NonAction]
        protected IActionResult ToPagedResponse<DataType, ResponseType>(int? page, int? limit, IQueryable<DataType> query,
            Func<IEnumerable<DataType>, IEnumerable<ResponseType>> responseFunction)
        {
            var _page = page ?? 1;
            var _limit = limit ?? 1;

            var pagedCollection = query.ToPagedList(_page, _limit);
            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}".ToLower();
            var linkBaseUrl = $"{baseUrl}{Request.QueryString}".ToLower();

            var response = new
            {
                data = responseFunction(pagedCollection),

                links = new[]
                {
                    new
                    {
                        rel = "self",
                        href = $"{linkBaseUrl}?page={_page}&limit={_limit}"
                    },
                    new
                    {
                        rel = "prev",
                        href = pagedCollection.HasPreviousPage ? $"{linkBaseUrl}?page={_page - 1}&limit={_limit}" : ""
                    },
                    new
                    {
                        rel = "next",
                        href = pagedCollection.HasNextPage ? $"{linkBaseUrl}?page={_page + 1}&limit={_limit}" : ""
                    }
                },

                current_page = _page,
                items_on_page = _limit,

                total_items = query.Count(),
                total_pages = pagedCollection.PageCount,

                has_more_items = pagedCollection.HasNextPage
            };

            return Ok(response);
        }

        [NonAction]
        protected string GetRequestToken()
        {
            var tokenName = ConfigurationBC.API_TOKEN_HEADER;
            try
            {
                var hasHeader = Request.Headers.TryGetValue(tokenName, out StringValues sessionToken);
                if (hasHeader) return sessionToken;
                else throw new Exception();
            }
            catch
            {
                throw new Exception($"Token inválido ({tokenName}).");
            }
        }
    }
}
