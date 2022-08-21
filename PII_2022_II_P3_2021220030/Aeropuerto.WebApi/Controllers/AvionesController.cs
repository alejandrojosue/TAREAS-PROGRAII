using Aeropuerto.WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Packt.Shared;

namespace Aeropuerto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvionesController : ControllerBase
    {
        private readonly IAvionRepository? repo;
        public AvionesController(IAvionRepository? repo)
        {
            this.repo = repo;
        }
        //GET: api/Avioness
        //GET: api/Aviones/?Compania=[Compania]
        //Retornará una lista de aviones
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Avione>))]
        public async Task<IEnumerable<Avione>> GetAviones(string? compania)
        {
            if (string.IsNullOrWhiteSpace(compania))
            {
                return await repo!.GetAllAsync();
            }
            else
            {
                return (await repo!.GetAllAsync())
                    .Where(x => x.Compania?.ToLower() == compania.ToLower());
            }
        }
        [HttpGet("{id}", Name = nameof(GetAvion))]
        [ProducesResponseType(200, Type = typeof(Avione))]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetAvion(int id)
        {
            Avione? c = await repo!.GetAsync(id);
            if (c == null)
            {
                return NotFound();//404 Recurso no Encontrado
            }
            return Ok(c);//200 Ok con el Aviones en el body
        }
        //POST: api/Avioness
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Avione))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Avione c)
        {
            if (c == null)
            {
                return BadRequest();//400
            }
            Avione? avionCreado = await repo!.CreateAsync(c);
            if (avionCreado == null)
            {
                return BadRequest("Repositorio fallo al crear el Cliente");//400

            }
            else
            {
                return CreatedAtRoute(
                    routeName: nameof(GetAvion),
                    routeValues: new { id = avionCreado.IdAvion },
                    value: avionCreado);
            }
        }

        //PUT: api/Aviones/[id]
        //BODY: Aviones(JSON, XML)
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] Avione c)
        {
            if (c == null || c.IdAvion != id)
            {
                return BadRequest();//400
            }
            Avione? existente = await repo!.GetAsync(id);
            if (existente == null)
            {
                return NotFound(); //404
            }
            await repo.UpdateAsync(id, c);
            return new NoContentResult();//204
        }
        //DELETE: api/Avioness/[id]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <=0) //Aqui
            {
                ProblemDetails problemDetails = new()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://localhost:7242/Avioness/fail-to-delete",
                    Title = $"Avion ID{id} se encontró pero falló al eliminar",
                    Detail = "Mas detalle como Cliente ID",
                    Instance = HttpContext.Request.Path
                };
                return BadRequest(problemDetails); //400
            }
            Avione? existente = await repo!.GetAsync(id);
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
                return BadRequest($"Avion {id} fue encontrado pero falló el eliminar"); //400
            }
        }
    }
}
