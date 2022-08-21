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
    public class CargoesController : Controller
    {
        private readonly IHttpClientFactory clientFactory;

        public CargoesController( IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index(string? Nombre)
        {
            string uri;
            if (string.IsNullOrEmpty(Nombre))
            {
                ViewData["Title"] = "Todos los Cargos";
                uri = "api/Cargos/";
            }
            else
            {
                ViewData["Title"] = $"Cargos de {Nombre}";
                uri = $"api/Cargos/?Nombre={Nombre}";
            }
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                IEnumerable<Cargo>? model = await res.Content.ReadFromJsonAsync<IEnumerable<Cargo>>();
                return View(model);
            }
            catch(Exception)
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
                uri = $"api/Cargos/{id}";
            }
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Cargo? model = await res.Content.ReadFromJsonAsync<Cargo>();
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre")] Cargo Cargo)
        {
            string uri;
            if (ModelState.IsValid)
            {
                uri = "api/Cargos/";
                var content = new StringContent(JsonConvert.SerializeObject(Cargo),
                    Encoding.UTF8, "application/json");
                
                try
                {
                    HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                    HttpRequestMessage req = new(method: HttpMethod.Post, requestUri: uri);
                    req.Content = content;
                    HttpResponseMessage res = await client.SendAsync(req);
                    if ((int)res.StatusCode == 201)
                    {
                        Cargo? model = await res.Content.ReadFromJsonAsync<Cargo>();
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
                
            }
            return View(Cargo);
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
                uri = $"api/Cargos/{id}";
            }
            
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Cargo? model = await res.Content.ReadFromJsonAsync<Cargo>();
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
        public async Task<IActionResult> Edit(int id, [Bind("IdCargo, Nombre")] Cargo Cargo)
        {
            if (id != Cargo.IdCargo)
            {
                return NotFound();
            }
            string uri;
            if (ModelState.IsValid)
            {
                uri = $"api/Cargos/{id}";
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Cargo), Encoding.UTF8, "application/json");
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
            return View(Cargo);
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
                uri = $"api/Cargos/{id}";
            }
            
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Cargo? model = await res.Content.ReadFromJsonAsync<Cargo>();
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
            uri = $"api/Cargos/{id}";
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
