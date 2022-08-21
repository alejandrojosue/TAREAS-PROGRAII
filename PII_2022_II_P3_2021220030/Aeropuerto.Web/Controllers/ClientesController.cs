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
    public class ClientesController : Controller
    {
        private readonly IHttpClientFactory clientFactory;

        public ClientesController( IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index(string nombre)
        {
            string uri;
            if (string.IsNullOrEmpty(nombre))
            {
                ViewData["Title"] = "Todos los Clientes";
                uri = "api/clientes/";
            }
            else
            {
                ViewData["Title"] = $"Clientes de {nombre}";
                uri = $"api/clientes/?nombre={nombre}";
            }
            
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                IEnumerable<Cliente>? model = await res.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
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
                uri = $"api/Clientes/{id}";
            }
                try { 
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Cliente? model = await res.Content.ReadFromJsonAsync<Cliente>();
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
            catch (Exception) {
                return BadRequest();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre, Apellido, Direccion, Telefono, Identidad, Fechanac")] Cliente Cliente)
        {
            string uri;
            if (ModelState.IsValid)
            {
                uri = "api/Clientes/";
                var content = new StringContent(JsonConvert.SerializeObject(Cliente),
                    Encoding.UTF8, "application/json");
                
                try
                {
                    HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                    HttpRequestMessage req = new(method: HttpMethod.Post, requestUri: uri);
                    req.Content = content;
                    HttpResponseMessage res = await client.SendAsync(req);
                    if ((int)res.StatusCode == 201)
                    {
                        Cliente? model = await res.Content.ReadFromJsonAsync<Cliente>();
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
                
            }
            return View(Cliente);
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
                uri = $"api/Clientes/{id}";
            }
            
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Cliente? model = await res.Content.ReadFromJsonAsync<Cliente>();
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
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente, Nombre, Apellido, Direccion, Telefono, Identidad, Fechanac")] Cliente Cliente)
        {
            if (id != Cliente.IdCliente)
            {
                return NotFound();
            }
            string uri;
            if (ModelState.IsValid)
            {
                uri = $"api/Clientes/{id}";
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Cliente), Encoding.UTF8, "application/json");
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
            return View(Cliente);
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
                uri = $"api/Clientes/{id}";
            }
            
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Cliente? model = await res.Content.ReadFromJsonAsync<Cliente>();
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
        [ValidateAntiForgeryToken]//Regresar Are you sure you want to delete this?
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            string uri;
            uri = $"api/Clientes/{id}";
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
