﻿using Microsoft.AspNetCore.Http;
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

        public List<OrdenesIngenieroRes> ListarOrdenesDeIngeniero(int id) {
            var response = default(List<OrdenesIngenieroRes>);
            try
            {
                var Ordenes = context.Orden
                                    .Include(e => e.LugarPersonas)
                                    .ThenInclude(e => e.Lugar)
                                    .Include(e => e.LugarPersonas.Cliente)
                                    .ThenInclude(e => e.ClienteNavigation)
                                    .Where(e => e.LugarPersonas.Cliente.ClienteId == id)
                                    .ToList();
                                    
                if (Ordenes is null) throw new ExceptionHelper("No se encontraron Ordenes"); 
                response =Ordenes.Select(e => new OrdenesIngenieroRes(e)).ToList();
            }
            catch (Exception ex){
                throw ex;
            }
            return response;
        }
    }
   
}