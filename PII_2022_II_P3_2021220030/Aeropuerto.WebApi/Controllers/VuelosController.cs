using Aeropuerto.WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Packt.Shared;

namespace Aeropuerto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private readonly IVueloRepository? repo;
        public VuelosController(IVueloRepository? repo)
        {
            this.repo = repo;
        }
        //GET: api/vuelos
        //GET: api/vuelos/?destino=[destino]
        //Retornará una lista de vuelos
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Vuelo>))]
        public async Task<IEnumerable<Vuelo>> GetVuelos(string? destino)
        {
            if (string.IsNullOrWhiteSpace(destino))
            {
                return await repo!.GetAllAsync();
            }
            else
            {
                return (await repo!.GetAllAsync())
                    .Where(x => x.Destino.ToLower() == destino.ToLower());
            }
        }
        [HttpGet("{id}", Name = nameof(GetVuelo))]
        [ProducesResponseType(200, Type = typeof(Vuelo))]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetVuelo(int id)
        {
            Vuelo? c = await repo!.GetAsync(id);
            if (c == null)
            {
                return NotFound();//404 Recurso no Encontrado
            }
            return Ok(c);//200 Ok con el Vuelo en el body
        }
        //POST: api/vuelos
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Vuelo))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Vuelo vuelo)
        {
            if (vuelo == null)
            {
                return BadRequest();//400
            }
            Vuelo? vueloCreado = await repo!.CreateAsync(vuelo);
            if (vueloCreado == null)
            {
                return BadRequest("Repositorio fallo al crear el Vuelo");//400

            }
            else
            {
                return CreatedAtRoute(
                    routeName: nameof(GetVuelo),
                    routeValues: new { id = vueloCreado.IdVuelo },
                    value: vueloCreado);
            }
        }

        //PUT: api/vuelos/[id]
        //BODY: Customer(JSON, XML)
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] Vuelo c)
        {
            if (c == null || c.IdVuelo != id)
            {
                return BadRequest();//400
            }
            Vuelo? existente = await repo!.GetAsync(id);
            if (existente == null)
            {
                return NotFound(); //404
            }
            await repo.UpdateAsync(id, c);
            return new NoContentResult();//204
        }
        //DELETE: api/vuelos/[id]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                ProblemDetails problemDetails = new()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://localhost:7242/vuelos/fail-to-delete",
                    Title = $"Vuelo ID{id} se encontró pero falló al eliminar",
                    Detail = "Mas detalle como Cliente ID",
                    Instance = HttpContext.Request.Path
                };
                return BadRequest(problemDetails); //400
            }
            Vuelo? existente = await repo!.GetAsync(id);
            if (existente == null)
            {
                return NotFound(); //404
            }
            bool? eliminado = await repo!.DeleteAsync(id);
            if (eliminado.HasValue && eliminado.Value)
            {
                return new NoContentResult(); //204
            }
            else
            {
                return BadRequest($"Vuelo {id} fue encontrado pero falló el eliminar"); //400
            }
        }
    }
}
