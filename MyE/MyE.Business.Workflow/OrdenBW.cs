using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyE.Business.Component.Helpers;
using MyE.Business.Entities.Response;
using MyE.Data;
using MyE.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyE.Business.Workflow
{
    public class OrdenBW
    {
        private SqlContext context;

        public OrdenBW() {
            context = new SqlContext();
        }

        public List<OrdenesIngenieroRes> ListarOrdenesDeIngeniero(UsuarioRes objUsuario) {
            var response = default(List<OrdenesIngenieroRes>);
            try
            {
                var Ordenes = context.Orden     
                                    .Include(e=>e.Empleado)
                                    .ThenInclude(e=>e.EmpleadoNavigation)
                                    .Include(e=>e.OrdenDetalle)
                                    .ThenInclude(e=>e.OrdenServicio)
                                    .ThenInclude(e=>e.Servicio)
                                    .Include(e => e.OrdenDetalle)
                                    .ThenInclude(e=>e.Ejemplar)
                                    .Include(e => e.LugarPersonas)
                                    .ThenInclude(e => e.Lugar)
                                    .Include(e => e.Empleado)
                                    .Include(e => e.LugarPersonas.Cliente)
                                    .ThenInclude(e => e.ClienteNavigation)
                                    .AsQueryable();
                if (objUsuario.Perfil == "S")
                {
                    var subditos = context.Empleado.Where(e => e.JefeId == objUsuario.PersonaId)
                                                    .Select(e => e.EmpleadoId)
                                                    .ToList();
                    Ordenes = Ordenes.Where(e => subditos.Contains(e.EmpleadoId) || e.EmpleadoId == objUsuario.PersonaId);
                }
                else if (objUsuario.Perfil == "I") {
                    Ordenes = Ordenes.Where(e => e.EmpleadoId == objUsuario.PersonaId);
                }

                    response =Ordenes.Select(e => new OrdenesIngenieroRes(e)).ToList();
            }
            catch {
                response = null;
            }
            return response;
        }

        public bool? RegistrarOrden(OrdenRqst objOrden) {
            bool? respuesta;
            try
            {
                Orden newOrden = new Orden
                {
                    EmpleadoId=objOrden.empleadoId,
                    LugarPersonasId=objOrden.lugar_PersonaId,
                    Estado="Pendiente",
                    //FechaEjecucion=objOrden.FechaEjecucion,
                    FechaGeneracion=DateTime.Now
                };
                context.Orden.Add(newOrden);
                OrdenDetalle newOrdenDetalle = new OrdenDetalle {
                    Orden = newOrden,
                    EjemplarId=objOrden.ejemplarId,
                    Estado="Pendiente",                    
                };
                context.OrdenDetalle.Add(newOrdenDetalle);

                var precioServicio = context.Servicio.FirstOrDefault(e=>e.ServicioId==objOrden.servicioId);
                OrdenServicio newOrdenService = new OrdenServicio
                {
                    OrdenDetalle= newOrdenDetalle,
                    Precio=precioServicio==null?0:precioServicio.Precio,
                    ServicioId=objOrden.servicioId,
                };
                context.OrdenServicio.Add(newOrdenService);
                context.SaveChanges();
                respuesta = true;
            }
            catch 
            {
                respuesta = null;
            }
            return respuesta;
        } 


    }
   
}
