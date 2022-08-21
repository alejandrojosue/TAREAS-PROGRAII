using Aeropuerto.WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Packt.Shared;

namespace Aeropuerto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository? repo;
        public ClientesController(IClienteRepository? repo)
        {
            this.repo = repo;
        }
        //GET: api/clientes
        //GET: api/clientes/?country=[country]
        //Retornará una lista de clientes
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cliente>))]
        public async Task<IEnumerable<Cliente>> Getclientes(string? nombre)
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
        [HttpGet("{id}", Name = nameof(GetCustomer))]
        [ProducesResponseType(200, Type = typeof(Cliente))]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetCustomer(int id)
        {
            Cliente? c = await repo!.GetAsync(id);
            if (c == null)
            {
                return NotFound();//404 Recurso no Encontrado
            }
            return Ok(c);//200 Ok con el Customer en el body
        }
        //POST: api/clientes
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Cliente))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Cliente c)
        {
            if (c == null)
            {
                return BadRequest();//400
            }
            Cliente? customerCreado = await repo!.CreateAsync(c);
            if (customerCreado == null)
            {
                return BadRequest("Repositorio fallo al crear el Cliente");//400

            }
            else
            {
                return CreatedAtRoute(
                    routeName: nameof(GetCustomer),
                    routeValues: new { id = customerCreado.IdCliente },
                    value: customerCreado);
            }
        }

        //PUT: api/Customer/[id]
        //BODY: Customer(JSON, XML)
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] Cliente c)
        {
            if (c == null || c.IdCliente != id)
            {
                return BadRequest();//400
            }
            Cliente? existente = await repo!.GetAsync(id);
            if (existente == null)
            {
                return NotFound(); //404
            }
            await repo.UpdateAsync(id, c);
            return new NoContentResult();//204
        }
        //DELETE: api/clientes/[id]
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
                    Type = "https://localhost:7242/clientes/fail-to-delete",
                    Title = $"Cliente ID{id} se encontró pero falló al eliminar",
                    Detail = "Mas detalle como Cliente ID",
                    Instance = HttpContext.Request.Path
                };
                return BadRequest(problemDetails); //400
            }
            Cliente? existente = await repo!.GetAsync(id);
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
                return BadRequest($"Cliente {id} fue encontrado pero falló el eliminar"); //400
            }
        }
    }
}
