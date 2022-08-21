using Aeropuerto.WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Packt.Shared;

namespace Aeropuerto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository? repo;
        public UsuariosController(IUsuarioRepository? repo)
        {
            this.repo = repo;
        }
        //GET: api/Usuarios
        //GET: api/Usuarios/?Nombre=[Nombre]
        //Retornará una lista de Usuarios
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Usuario>))]
        public async Task<IEnumerable<Usuario>> GetUsuarios(string? nombre)
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
        [HttpGet("{id}", Name = nameof(GetUsuario))]
        [ProducesResponseType(200, Type = typeof(Usuario))]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetUsuario(int id)
        {
            Usuario? c = await repo!.GetAsync(id);
            if (c == null)
            {
                return NotFound();//404 Recurso no Encontrado
            }
            return Ok(c);//200 Ok con el Usuario en el body
        }
        //POST: api/Usuarios
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Usuario))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Usuario c)
        {
            if (c == null)
            {
                return BadRequest();//400
            }
            Usuario? UsuarioCreado = await repo!.CreateAsync(c);
            if (UsuarioCreado == null)
            {
                return BadRequest("Repositorio fallo al crear el Usuario");//400

            }
            else
            {
                return CreatedAtRoute(
                    routeName: nameof(GetUsuario),
                    routeValues: new { id = UsuarioCreado.IdUsuario },
                    value: UsuarioCreado);
            }
        }

        //PUT: api/Usuario/[id]
        //BODY: Usuario(JSON, XML)
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] Usuario c)
        {
            if (c == null || c.IdUsuario != id)
            {
                return BadRequest();//400
            }
            Usuario? existente = await repo!.GetAsync(id);
            if (existente == null)
            {
                return NotFound(); //404
            }
            await repo.UpdateAsync(id, c);
            return new NoContentResult();//204
        }
        //DELETE: api/Usuarios/[id]
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
                    Type = "https://localhost:7242/Usuarios/fail-to-delete",
                    Title = $"Usuario ID{id} se encontró pero falló al eliminar",
                    Detail = "Mas detalle como Usuario ID",
                    Instance = HttpContext.Request.Path
                };
                return BadRequest(problemDetails); //400
            }
            Usuario? existente = await repo!.GetAsync(id);
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
                return BadRequest($"Usuario {id} fue encontrado pero falló el eliminar"); //400
            }
        }
    }
}
