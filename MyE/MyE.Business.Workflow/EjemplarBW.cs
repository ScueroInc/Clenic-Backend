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
    public class EjemplarBW
    {
        private SqlContext context;

        public EjemplarBW() {
            context = new SqlContext();
        }

        public List<EjemplarRes> ListarEjemplares()
        {
            var response = default(List<EjemplarRes>);
            try
            {
                var ejemplares = context.Ejemplar
                                    .Include(e => e.Equipo)
                                    .ThenInclude(e => e.Modelo)
                                    .ThenInclude(e => e.Fabricante)                                   
                                    .ToList();
                if (ejemplares is null) throw new Exception();
                context.SaveChanges();
                response = ejemplares.Select(e => new EjemplarRes(e)).ToList();
            }
            catch 
            {
                response = null;
            }
            return response;
        }

    }

}
