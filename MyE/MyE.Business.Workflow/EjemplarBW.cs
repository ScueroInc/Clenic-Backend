using MyE.Data;

namespace MyE.Business.Workflow
{
    public class EjemplarBW
    {
        private SqlContext context;

        public EjemplarBW()
        {
            context = new SqlContext();
        }

        //public List<EjemplarRes> ListarEjemplarsDeIngeniero(int id) {
        //    var response = default(List<EjemplarIngenieroRes>);
        //    try
        //    {
        //        var Ejemplars = context.Ejemplar
        //                            .Include(e => e.OrdenServicio)
        //                            .ThenInclude(e=>e.Servicio)
        //                            .Include(e => e.OrdenServicio.OrdenDetalle)
        //                            .ThenInclude(e => e.Orden)
        //                            .ThenInclude(e => e.Empleado)
        //                            .ThenInclude(e => e.EmpleadoNavigation)
        //                            .Where(e => e.OrdenServicio.OrdenDetalle.Orden.EmpleadoId == id);
        //        if (Ejemplars is null) throw new ExceptionHelper("No se encontraron Ejemplars");
        //        context.SaveChanges();
        //        response = Ejemplars.Select(e=> new EjemplarIngenieroRes(e)).ToList();
        //    }
        //    catch (Exception ex){
        //        throw ex;
        //    }
        //    return response;
        //}

        //public bool RegistrarEjemplar(EjemplarRqst objEjemplarRqst)
        //{
        //    var respuesta = false;
        //    try
        //    {
        //        Ejemplar objEjemplar = new Ejemplar
        //        {
        //            Asunto= objEjemplarRqst.Asunto,
        //            Estado="A",
        //            FechaAtencion=default(DateTime),
        //            FechaEjecucion= default(DateTime),
        //            FechaGeneracion=DateTime.Now,
        //            Observacion= objEjemplarRqst.Observacion,
        //            OrdenServicioId=objEjemplarRqst.OrdenServicioId,
        //        };
        //        context.Ejemplar.Add(objEjemplar);
        //        context.SaveChanges();
        //        respuesta = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return respuesta;
        //}
    }
}