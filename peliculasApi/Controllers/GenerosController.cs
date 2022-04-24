using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using peliculasApi.DTOs;
using peliculasApi.Entidades;
using peliculasApi.Utils;

namespace peliculasApi.Controllers
{
    [Route("api/generos")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] //nivel controllador
    public class GenerosController : ControllerBase
    {
        private readonly ILogger<GenerosController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerosController(ILogger<GenerosController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> Get([FromQuery] PaginacionDto paginacionDto)
        {
            var queryable = context.Generos.AsQueryable();

            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            
            var generos = queryable.OrderBy(x => x.Nombre).Paginar(paginacionDto).ToListAsync();


            var algo = mapper.Map<List<GeneroDTO>>(generos);
            return algo;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id) //   /api/generos/3/felipe
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GeneroDTO generoCreacionDTO)
        {
            var generoMap = mapper.Map<Genero>(generoCreacionDTO);

            context.Add(generoMap);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] GeneroEliminacionDTO generoEliminacionDTO)
        {
            var generoEliminar = mapper.Map<Genero>(generoEliminacionDTO);
            context.Remove(generoEliminar);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }

}
