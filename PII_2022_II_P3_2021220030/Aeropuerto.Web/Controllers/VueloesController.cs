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
    public class VueloesController : Controller
    {
        private readonly IHttpClientFactory clientFactory;
        
        public VueloesController( IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory; 
        }

        public async Task<IActionResult> Index(string Destino)
        {
            string uri;
            if (string.IsNullOrEmpty(Destino))
            {
                ViewData["Title"] = "Todos los Vuelos";
                uri = "api/Vuelos/";
            }
            else
            {
                ViewData["Title"] = $"Vuelos de {Destino}";
                uri = $"api/Vuelos/?Destino={Destino}";
            }
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                IEnumerable<Vuelo>? model = await res.Content.ReadFromJsonAsync<IEnumerable<Vuelo>>();
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
                uri = $"api/Vuelos/{id}";
            }
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Vuelo? model = await res.Content.ReadFromJsonAsync<Vuelo>();
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

        public async Task<IActionResult> Create()
        {
            string uri = "api/Vuelos";
            
            try
            {
                //Vuelos
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                Vuelo? model = new Vuelo();// = await res.Content.ReadFromJsonAsync<Vuelo>();
                                           //Aviones
                uri = "api/Aviones";
                HttpRequestMessage reqAvione = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage resAvione = await client.SendAsync(reqAvione);
                IEnumerable<Avione>? modelAvione = await resAvione.Content.ReadFromJsonAsync<IEnumerable<Avione>>();
                //Usuarios
                uri = "api/Usuarios";
                HttpRequestMessage reqUsuario = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage resUsuario = await client.SendAsync(reqUsuario);
                IEnumerable<Usuario>? modelUsuario = await resUsuario.Content.ReadFromJsonAsync<IEnumerable<Usuario>>();
                if (modelAvione is not null)
                {
                    ViewData["IdAvion"] = new SelectList(modelAvione, "IdAvion", "Numero", model!.IdAvion);
                }

                if (modelUsuario is not null)
                {
                    ViewData["IdPiloto"] = new SelectList(modelUsuario, "IdUsuario", "Usuario1", model!.IdPiloto);
                }
                return View();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Horariosalida, Horariollegada, Origen, Destino, IdAvion, IdPiloto")] Vuelo Vuelo)
        {
            string uri;
            if (ModelState.IsValid)
            {
                uri = "api/Vuelos/";
                var content = new StringContent(JsonConvert.SerializeObject(Vuelo),
                    Encoding.UTF8, "application/json");
                
                try
                {
                    HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                    HttpRequestMessage req = new(method: HttpMethod.Post, requestUri: uri);
                    req.Content = content;
                    HttpResponseMessage res = await client.SendAsync(req);
                    if ((int)res.StatusCode == 201)
                    {
                        Vuelo? model = await res.Content.ReadFromJsonAsync<Vuelo>();
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
                
            }
            return View(Vuelo);
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
                uri = $"api/Vuelos/{id}";
            }
            
            try
            {
                //Vuelos
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Vuelo? model = await res.Content.ReadFromJsonAsync<Vuelo>();
                //Aviones
                uri = "api/Aviones";
                HttpRequestMessage reqAvione = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage resAvione = await client.SendAsync(reqAvione);
                IEnumerable<Avione>? modelAvione = await resAvione.Content.ReadFromJsonAsync<IEnumerable<Avione>>();
                // Usuarios
                uri = "api/Usuarios";
                HttpRequestMessage reqUsuario = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage resUsuario = await client.SendAsync(reqUsuario);
                IEnumerable<Usuario>? modelUsuario = await resUsuario.Content.ReadFromJsonAsync<IEnumerable<Usuario>>();
                if (modelAvione is not null)
                {
                    ViewData["IdAvion"] = new SelectList(modelAvione, "IdAvion", "Numero", model!.IdAvion);
                }

                if (modelUsuario is not null)
                {
                    ViewData["IdPiloto"] = new SelectList(modelUsuario, "IdUsuario", "Usuario1", model!.IdPiloto);
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
        public async Task<IActionResult> Edit(int id, [Bind("IdVuelo, Horariosalida, Horariollegada, Origen, Destino, IdAvion, IdPiloto")] Vuelo Vuelo)
        {
            if (id != Vuelo.IdVuelo)
            {
                return NotFound();
            }
            string uri;
            if (ModelState.IsValid)
            {
                uri = $"api/Vuelos/{id}";
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Vuelo), Encoding.UTF8, "application/json");
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
            return View(Vuelo);
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
                uri = $"api/Vuelos/{id}";
            }
            
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Vuelo? model = await res.Content.ReadFromJsonAsync<Vuelo>();
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
            uri = $"api/Vuelos/{id}";
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
