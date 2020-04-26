﻿using MyE.Business.Component.Helpers;
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

        public List<IngenieroResponse> ListarIngenieros() {
            var response = default(List<IngenieroResponse>);      
            try
            {                
                var ingenieros = context.Usuario
                                        .Include(e=>e.Persona) 
                                        .ThenInclude(e=>e.Empleado)
                                        .Where(e=>e.Persona.Empleado !=null)
                                        .Where(e=>e.Perfil=="I")
                                        .Select(e=>new IngenieroResponse(e.Persona))
                                        .ToList();
                response = ingenieros;                  
            }
            catch (Exception ex){
                throw ex;
            }
            return response;
        }

        public IngenieroResponse ObtenerIngeniero(string usuarioId)
        {
            var response = default(IngenieroResponse);
            try
            {
                var ingeniero = context.Usuario.Include(e => e.Persona).ThenInclude(e => e.Empleado).SingleOrDefault(e => e.UsuarioId == usuarioId);
                //if (persona.Persona is null) throw new ExceptionHelper("No se encontro registros del usuario ingresado");
                //var ingeniero=persona.ThenInclude(e => e.Empleado)

                if (ingeniero.Persona.Empleado is null) throw new ExceptionHelper("No se encontro registros");
                response = new IngenieroResponse
                {
                    Correo = ingeniero.Persona.Empleado.Correo,
                    Direccion = ingeniero.Persona.Empleado.Tdireccion,
                    Dni = ingeniero.Persona.Empleado.Dni,
                    IngenieroId = ingeniero.Persona.Empleado.EmpleadoId,
                    Nombre = ingeniero.Persona.Npersona,
                    NumeroContacto = ingeniero.Persona.Empleado.NumContacto
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }



    }
   
}