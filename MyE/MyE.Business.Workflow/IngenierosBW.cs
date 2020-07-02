using MyE.Business.Component.Helpers;
using MyE.Business.Entities.Response;
using MyE.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MyE.Business.Workflow
{
    public class IngenierosBW
    {
        private SqlContext context;
        public IngenierosBW() {
            context = new SqlContext();
        }

        public List<IngenieroRes> ListarIngenieros(UsuarioRes objUsuario) {
            var response = default(List<IngenieroRes>);      
            try
            {
                var ingenieros = context.Persona
                                       .Include(e => e.Empleado)
                                       .AsQueryable();
                if (objUsuario.Perfil == "A") {
                    ingenieros = ingenieros.Where(e => e.Empleado.JefeId != default(int?));
                }
                else
                {
                    ingenieros = ingenieros.Where(e => e.Empleado.JefeId == objUsuario.PersonaId);
                }

                response = ingenieros
                                .Select(e => new IngenieroRes(e))
                                .ToList();
            }
            catch {
                response = null;
            }
            return response;
        }

        public IngenieroRes ObtenerIngeniero(int ingenieroId)
        {
            var response = default(IngenieroRes);
            try
            {
                var ingeniero = context.Usuario
                                        .Include(e => e.Persona)
                                        .ThenInclude(e => e.Empleado)
                                        .SingleOrDefault(e => e.Persona.PersonaId == ingenieroId);
                
                if (ingeniero is null) throw new Exception();
                response = new IngenieroRes
                {
                    Correo = ingeniero.Persona.Empleado.Correo,
                    Direccion = ingeniero.Persona.Empleado.Tdireccion,
                    Dni = ingeniero.Persona.Empleado.Dni,
                    IngenieroId = ingeniero.Persona.Empleado.EmpleadoId,
                    Nombre = ingeniero.Persona.Npersona,
                    NumeroContacto = ingeniero.Persona.Empleado.NumContacto
                };
            }
            catch
            {
                response = null;
            }
            return response;
        }

        public bool RegistrarIngeniero(int ingenieroId)
        {
            var response = default(bool);
            try
            {
                var ingeniero = context.Usuario
                                        .Include(e => e.Persona)
                                        .ThenInclude(e => e.Empleado)
                                        .SingleOrDefault(e => e.Persona.PersonaId == ingenieroId);

                if (ingeniero is null) throw new Exception();
                //response = new IngenieroRes
                //{
                //    Correo = ingeniero.Persona.Empleado.Correo,
                //    Direccion = ingeniero.Persona.Empleado.Tdireccion,
                //    Dni = ingeniero.Persona.Empleado.Dni,
                //    IngenieroId = ingeniero.Persona.Empleado.EmpleadoId,
                //    Nombre = ingeniero.Persona.Npersona,
                //    NumeroContacto = ingeniero.Persona.Empleado.NumContacto
                //};
            }
            catch
            {
                response = false;
            }
            return response;
        }


    }
   
}
