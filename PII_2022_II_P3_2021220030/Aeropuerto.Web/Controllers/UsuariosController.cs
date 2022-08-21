using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Packt.Shared;

namespace Aeropuerto.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IHttpClientFactory clientFactory;

        public UsuariosController( IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index(string? nombre)
        {
            string uri;
            if (string.IsNullOrEmpty(nombre))
            {
                ViewData["Title"] = "Todos los Usuarios";
                uri = "api/Usuarios/";
            }
            else
            {
                ViewData["Title"] = $"Usuarios de {nombre}";
                uri = $"api/Usuarios/?nombre={nombre}";
            }
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                IEnumerable<Usuario>? model = await res.Content.ReadFromJsonAsync<IEnumerable<Usuario>>();
                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            string uri;
            if (id <= 0)
            {
                return NotFound();
            }
            else
            {
                uri = $"api/Usuarios/{id}";
            }
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Usuario? model = await res.Content.ReadFromJsonAsync<Usuario>();
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Create()
        {
            string uri = "api/Usuarios";
            
            try
            {
                //Usuarios
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                Usuario? model = new Usuario();// = await res.Content.ReadFromJsonAsync<Usuario>();
                                               //Cargos
                uri = "api/Cargos";
                HttpRequestMessage reqCargo = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage resCargo = await client.SendAsync(reqCargo);
                IEnumerable<Cargo>? modelCargo = await resCargo.Content.ReadFromJsonAsync<IEnumerable<Cargo>>();
                if (modelCargo is not null)
                {
                    ViewData["IdCargo"] = new SelectList(modelCargo, "IdCargo", "Nombre", model!.IdCargo);
                }
                return View();
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario, Nombre, Apellido, Usuario1, Clave, IdCargo, Direccion, Telefono")] Usuario Usuario)
        {
            string uri;
            if (ModelState.IsValid)
            {
                uri = "api/Usuarios/";
                var content = new StringContent(JsonConvert.SerializeObject(Usuario),
                    Encoding.UTF8, "application/json");
                
                try
                {
                    HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                    HttpRequestMessage req = new(method: HttpMethod.Post, requestUri: uri);
                    req.Content = content;
                    HttpResponseMessage res = await client.SendAsync(req);
                    if ((int)res.StatusCode == 201)
                    {
                        Usuario? model = await res.Content.ReadFromJsonAsync<Usuario>();
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
                
            }
            return View(Usuario);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            string uri;
            if (id <= 0)
            {
                return NotFound();
            }
            else
            {
                uri = $"api/Usuarios/{id}";
            }
            
            try
            {
                //Usuarios
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Usuario? model = await res.Content.ReadFromJsonAsync<Usuario>();
                //Cargos
                uri = "api/Cargos";
                HttpRequestMessage reqCargo = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage resCargo = await client.SendAsync(reqCargo);
                IEnumerable<Cargo>? modelCargo = await resCargo.Content.ReadFromJsonAsync<IEnumerable<Cargo>>();
                if (modelCargo is not null)
                {
                    ViewData["IdCargo"] = new SelectList(modelCargo, "IdCargo", "Nombre", model!.IdCargo);
                }
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario, Nombre, Apellido, Usuario1, Clave, IdCargo, Direccion, Telefono")] Usuario Usuario)
        {
            if (id != Usuario.IdUsuario)
            {
                return NotFound();
            }
            string uri;
            if (ModelState.IsValid)
            {
                uri = $"api/Usuarios/{id}";
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Usuario), Encoding.UTF8, "application/json");
                    HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                    HttpRequestMessage req = new(method: HttpMethod.Put, requestUri: uri);
                    req.Content = content;
                    HttpResponseMessage res = await client.SendAsync(req);
                    if ((int)res.StatusCode == 204)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    if ((int)res.StatusCode == 400)
                    {
                        return BadRequest();
                    }
                    return NotFound();
                }
                catch (Exception)
                {
                    return NotFound();
                }
            }
            return View(Usuario);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            string uri;
            if (id <= 0)
            {
                return NotFound();
            }
            else
            {
                uri = $"api/Usuarios/{id}";
            }
            
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Usuario? model = await res.Content.ReadFromJsonAsync<Usuario>();
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            string uri;
            uri = $"api/Usuarios/{id}";
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Delete, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                if ((int)res.StatusCode == 204)
                {
                    return RedirectToAction(nameof(Index));
                }

                if ((int)res.StatusCode == 400)
                {
                    return BadRequest();
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
    }
}
