using Aeropuerto.WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Packt.Shared;

namespace Aeropuerto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly ICargoRepository? repo;
        public CargosController(ICargoRepository? repo)
        {
            this.repo = repo;
        }
        //GET: api/customers
        //GET: api/cargos/?nombre=[nombre]
        //Retornará una lista de customers
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cargo>))]
        public async Task<IEnumerable<Cargo>> GetCargos(string? nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return await repo!.GetAllAsync();
            }
            else
            {
                return (await repo!.GetAllAsync())
                    .Where(x => x.Nombre.ToLower() == nombre.ToLower());
            }
        }
        [HttpGet("{id}", Name = nameof(GetCargo))]
        [ProducesResponseType(200, Type = typeof(Cargo))]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetCargo(int id)
        {
            Cargo? c = await repo!.GetAsync(id);
            if (c == null)
            {
                return NotFound();//404 Recurso no Encontrado
            }
            return Ok(c);//200 Ok con el Customer en el body
        }
        //POST: api/customers
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Cargo))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Cargo c)
        {
            if (c == null)
            {
                return BadRequest();//400
            }
            Cargo? cargoCreado = await repo!.CreateAsync(c);
            if (cargoCreado == null)
            {
                return BadRequest("Repositorio fallo al crear el Cliente");//400

            }
            else
            {
                return CreatedAtRoute(
                    routeName: nameof(GetCargo),
                    routeValues: new { id = cargoCreado.IdCargo },
                    value: cargoCreado);
            }
        }

        //PUT: api/Customer/[id]
        //BODY: Customer(JSON, XML)
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] Cargo c)
        {
            if (c == null || c.IdCargo != id)
            {
                return BadRequest();//400
            }
            Cargo? existente = await repo!.GetAsync(id);
            if (existente == null)
            {
                return NotFound(); //404
            }
            await repo.UpdateAsync(id, c);
            return new NoContentResult();//204
        }
        //DELETE: api/customers/[id]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <=0)
            {
                ProblemDetails problemDetails = new()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://localhost:7242/customers/fail-to-delete",
                    Title = $"Avion ID{id} se encontró pero falló al eliminar",
                    Detail = "Mas detalle como Cliente ID",
                    Instance = HttpContext.Request.Path
                };
                return BadRequest(problemDetails); //400
            }
            Cargo? existente = await repo!.GetAsync(id);
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
