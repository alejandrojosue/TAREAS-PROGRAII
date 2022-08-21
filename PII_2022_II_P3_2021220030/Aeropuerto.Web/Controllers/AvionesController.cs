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
    public class AvionesController : Controller
    {
        private readonly IHttpClientFactory clientFactory;

        public AvionesController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index(string compania)
        {
            string uri;
            if (string.IsNullOrEmpty(compania))
            {
                ViewData["Title"] = "Todos los Aviones";
                uri = "api/Aviones/";
            }
            else
            {
                ViewData["Title"] = $"Aviones de {compania}";
                uri = $"api/Aviones/?compania={compania}";
            }
            try { 
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                IEnumerable<Avione>? model = await res.Content.ReadFromJsonAsync<IEnumerable<Avione>>();
                return View(model);
            }catch (Exception)
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
                uri = $"api/Aviones/{id}";
            }
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Avione? model = await res.Content.ReadFromJsonAsync<Avione>();
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
        public async Task<IActionResult> Create([Bind("Capacidad, Longitud, Envergadura, Velocidad, Compania, Numero, Fechadquisicion")] Avione Avione)
        {
            string uri;
            if (ModelState.IsValid)
            {
                uri = "api/Aviones/";
                var content = new StringContent(JsonConvert.SerializeObject(Avione),
                    Encoding.UTF8, "application/json");
                
                try
                {
                    HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                    HttpRequestMessage req = new(method: HttpMethod.Post, requestUri: uri);
                    req.Content = content;
                    HttpResponseMessage res = await client.SendAsync(req);
                    if ((int)res.StatusCode == 201)
                    {
                        Avione? model = await res.Content.ReadFromJsonAsync<Avione>();
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
                
            }
            return View(Avione);
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
                uri = $"api/Aviones/{id}";
            }
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Avione? model = await res.Content.ReadFromJsonAsync<Avione>();
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
        public async Task<IActionResult> Edit(int id, [Bind("IdAvion, Capacidad, Longitud, Envergadura, Velocidad, Compania, Numero, Fechadquisicion")] Avione Avione)
        {
            if (id != Avione.IdAvion)
            {
                return NotFound();
            }
            string uri;
            if (ModelState.IsValid)
            {
                uri = $"api/Aviones/{id}";
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Avione), Encoding.UTF8, "application/json");
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
            return View(Avione);
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
                uri = $"api/Aviones/{id}";
            }
            
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Avione? model = await res.Content.ReadFromJsonAsync<Avione>();
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
            uri = $"api/Aviones/{id}";
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
