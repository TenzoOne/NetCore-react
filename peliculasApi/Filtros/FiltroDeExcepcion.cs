using Microsoft.AspNetCore.Mvc.Filters;

namespace peliculasApi.Filtros
{
    public class FiltroDeExcepcion: ExceptionFilterAttribute
    {
        public ILogger<FiltroDeExcepcion> Logger;
        public FiltroDeExcepcion(ILogger<FiltroDeExcepcion> logger)
        {
            Logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            Logger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);
        }


    }
}
