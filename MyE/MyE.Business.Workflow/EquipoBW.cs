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
    public class EquipoId
    {
        private SqlContext context;

        public EquipoId() {
            context = new SqlContext();
        }

        public List<ReporteIngenieroRes> ListarReportesDeIngeniero(int id) {
            var response = default(List<ReporteIngenieroRes>);
            try
            {
                var reportes = context.Reporte
                                    .Include(e => e.OrdenServicio)
                                    .ThenInclude(e=>e.Servicio)
                                    .Include(e => e.OrdenServicio.OrdenDetalle)
                                    .ThenInclude(e => e.Orden)
                                    .ThenInclude(e => e.Empleado)
                                    .ThenInclude(e => e.EmpleadoNavigation)
                                    .Where(e => e.OrdenServicio.OrdenDetalle.Orden.EmpleadoId == id);
                if (reportes is null) throw new ExceptionHelper("No se encontraron reportes");                
                context.SaveChanges();
                response = reportes.Select(e=> new ReporteIngenieroRes(e)).ToList();               
            }
            catch (Exception ex){
                throw ex;
            }
            return response;
        }

        public bool RegistrarReporte(ReporteRqst objReporteRqst)
        {
            var respuesta = false;
            try
            {
                Reporte objReporte = new Reporte
                {
                    Asunto= objReporteRqst.Asunto,
                    Estado="A",
                    FechaAtencion=default(DateTime),
                    FechaEjecucion= default(DateTime),
                    FechaGeneracion=DateTime.Now,
                    Observacion= objReporteRqst.Observacion,
                    OrdenServicioId=objReporteRqst.OrdenServicioId,                    
                };
                context.Reporte.Add(objReporte);
                context.SaveChanges();
                respuesta = true;               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }
    }
   
}
