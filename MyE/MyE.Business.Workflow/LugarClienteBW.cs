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
    public class LugarClienteBW
    {
        private SqlContext context;

        public LugarClienteBW() {
            context = new SqlContext();
        }

        public List<LugarClienteRes> Listar_PersonasId() {
            var response = default(List<LugarClienteRes>);
            try
            {
                var LugarClientees = context.LugarCliente
                                    .Include(e => e.Cliente)
                                    .ThenInclude(e=>e.ClienteNavigation)
                                    .Include(e=>e.Lugar)                                        
                                    .AsQueryable();              

               response =LugarClientees.Select(e => new LugarClienteRes(e)).ToList();
            }
            catch {
                response = null;
            }
            return response;
        }       
    }
   
}
