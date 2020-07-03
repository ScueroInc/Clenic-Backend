using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyE.Business.Component.Helpers;
using MyE.Business.Entities.Response;
using MyE.Data;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace MyE.Business.Workflow
{
    public class LoginBW
    {
        private SqlContext context;

        public LoginBW() {
            context = new SqlContext();
        }

        public UsuarioRes Loguearse(string username,string psw) {
            var response = default(UsuarioRes);
            try
            {
                var usuario = context.Usuario
                                     .Include(e => e.Persona)
                                     .ThenInclude(e => e.Empleado)
                                     .Where(e=>e.UsuarioId==username && e.Psw==psw)
                                     .SingleOrDefault(x => x.UsuarioId == username);
                if (usuario is null) throw new Exception();
                usuario.Token = SecurityHelper.GenerateToken(usuario);
                context.SaveChanges();
                response = new UsuarioRes(usuario, true);
            }
            catch 
            {
                response = null;
            }
            return response;
        }

        public bool? validarTokenConBd(UsuarioRes objUsuario)
        {
            bool? response = false;
            try
            {
                var usuario = context.Usuario
                                     .Include(e => e.Persona)
                                     .ThenInclude(e => e.Empleado)
                                     .FirstOrDefault(x => x.UsuarioId == objUsuario.UsuarioId);

                if (usuario == null)
                    throw new ExceptionHelper(401,"El usuario no existe.");
                if (usuario.Token!= objUsuario.SessionToken)
                    throw new ExceptionHelper(401,"Sesion invalida, comuniquese con un administrador");           
                response = true;
            }
            catch 
            {
                response = null;
            }
            return response;
        }





    }
   
}
