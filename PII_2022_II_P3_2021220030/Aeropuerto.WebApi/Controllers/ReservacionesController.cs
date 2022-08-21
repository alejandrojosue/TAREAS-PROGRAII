using Aeropuerto.WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Packt.Shared;

namespace Aeropuerto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionesController : ControllerBase
    {
        private readonly IReservacionRepository? repo;
        public ReservacionesController(IReservacionRepository? repo)
        {
            this.repo = repo;
        }
        //GET: api/Reservaciones
        //GET: api/Reservaciones/?Numero_Asiento=[Numero_Asiento]
        //Retornará una lista de Reservaciones
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reservacione>))]
        public async Task<IEnumerable<Reservacione>> GetReservaciones(int NumeroAsiento)
        {
            if (NumeroAsiento<=0)
            {
                return await repo!.GetAllAsync();
            }
            else
            {
                return (await repo!.GetAllAsync())
                    .Where(x => x.NumeroAsiento == NumeroAsiento);
            }
        }
        [HttpGet("{id}", Name = nameof(GetReservacion))]
        [ProducesResponseType(200, Type = typeof(Reservacione))]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetReservacion(int id)
        {
            Reservacione? c = await repo!.GetAsync(id);
            if (c == null)
            {
                return NotFound();//404 Recurso no Encontrado
            }
            return Ok(c);//200 Ok con el Reservacion en el body
        }
        //POST: api/Reservaciones
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Reservacione))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Reservacione c)
        {
            if (c == null)
            {
                return BadRequest();//400
            }
            Reservacione? ReservacionCreado = await repo!.CreateAsync(c);
            if (ReservacionCreado == null)
            {
                return BadRequest("Repositorio fallo al crear la Reservación");//400

            }
            else
            {
                return CreatedAtRoute(
                    routeName: nameof(GetReservacion),
                    routeValues: new { id = ReservacionCreado.IdReservacion },
                    value: ReservacionCreado);
            }
        }

        //PUT: api/Reservacion/[id]
        //BODY: Reservacion(JSON, XML)
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] Reservacione c)
        {
            if (c == null || c.IdReservacion != id)
            {
                return BadRequest();//400
            }
            Reservacione? existente = await repo!.GetAsync(id);
            if (existente == null)
            {
                return NotFound(); //404
            }
            await repo.UpdateAsync(id, c);
            return new NoContentResult();//204
        }
        //DELETE: api/Reservaciones/[id]
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
                    Type = "https://localhost:7242/Reservaciones/fail-to-delete",
                    Title = $"Reservacion ID{id} se encontró pero falló al eliminar",
                    Detail = "Mas detalle como Cliente ID",
                    Instance = HttpContext.Request.Path
                };
                return BadRequest(problemDetails); //400
            }
            Reservacione? existente = await repo!.GetAsync(id);
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
                return BadRequest($"Reservacion {id} fue encontrado pero falló el eliminar"); //400
            }
        }
    }
}
