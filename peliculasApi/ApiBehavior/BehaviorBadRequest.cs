using Microsoft.AspNetCore.Mvc;

namespace peliculasApi.ApiBehavior
{
    public static class BehaviorBadRequest
    {
        public static void Parsear(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = ActionContext =>
            {
                var respuesta = new List<string>();
                foreach (var llave in ActionContext.ModelState.Keys)
                {
                    foreach (var errro in ActionContext.ModelState[llave].Errors)
                    {
                        respuesta.Add($"{llave}: {errro.ErrorMessage}");
                    }
                }
                return new BadRequestObjectResult(respuesta);
            };
        }
    }
}
