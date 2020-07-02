using Microsoft.EntityFrameworkCore;
using MyE.Business.Component.Helpers;
using MyE.Business.Entities.Response;
using MyE.Data;
using System;
using System.Linq;

namespace MyE.Business.Workflow
{
    public class LoginBW
    {
        private SqlContext context;

        public LoginBW()
        {
            context = new SqlContext();
        }

        public UsuarioRes Loguearse(string username, string psw)
        {
            var response = default(UsuarioRes);
            try
            {
                var usuario = context.Usuario
                                     .Include(e => e.Persona)
                                     .ThenInclude(e => e.Empleado)
                                     .FirstOrDefault(x => x.UsuarioId == username);

                if (usuario == null)
                    throw new ExceptionHelper("El usuario no existe.");
                if (usuario.Psw != psw)
                    throw new ExceptionHelper("Contraseña incorrecta.");

                usuario.Token = SecurityHelper.GenerateToken(usuario);
                context.SaveChanges();
                response = new UsuarioRes(usuario, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public bool validarTokenConBd(UsuarioRes objUsuario)
        {
            var response = false;
            try
            {
                var usuario = context.Usuario
                                     .Include(e => e.Persona)
                                     .ThenInclude(e => e.Empleado)
                                     .FirstOrDefault(x => x.UsuarioId == objUsuario.UsuarioId);

                if (usuario == null)
                    throw new ExceptionHelper("El usuario no existe.");
                if (usuario.Token != objUsuario.SessionToken)
                    throw new ExceptionHelper("Sesion invalida, comuniquese con un administrador");
                response = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}