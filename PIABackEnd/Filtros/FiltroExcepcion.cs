using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PIABackEnd.Filtros
{
    public class FiltroExcepcion : ExceptionFilterAttribute
    {
        private readonly ILogger<FiltroExcepcion> logger;

        public FiltroExcepcion(ILogger<FiltroExcepcion> logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception, "Ocurrió un error.");


            var resultado = new JsonResult(new { error = "Ocurrió un error." })
            {

                StatusCode = 404
            };

            context.Result = resultado;
        }
    }
}
