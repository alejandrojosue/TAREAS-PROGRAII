using System;
using System.Collections;
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
    public class ReservacionesController : Controller
    {
        private readonly IHttpClientFactory clientFactory;

        public ReservacionesController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
                
        public async Task<IActionResult> Index(int NumeroAsiento=0)
        {
            string uri;
            if (NumeroAsiento<=0)
            {
                ViewData["Title"] = "Todos los Reservaciones";
                uri = "api/Reservaciones/";
            }
            else
            {
                ViewData["Title"] = $"Reservaciones de {NumeroAsiento}";
                uri = $"api/Reservaciones/?NumeroAsiento={NumeroAsiento}"; 
            }
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                IEnumerable<Reservacione>? model = await res.Content.ReadFromJsonAsync<IEnumerable<Reservacione>>();
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
                uri = $"api/Reservaciones/{id}";
            }
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Reservacione? model = await res.Content.ReadFromJsonAsync<Reservacione>();
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
            
            try
            {
                string uri = "api/Reservaciones";
                //Reservaciones
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                Reservacione? model = new Reservacione();// = await res.Content.ReadFromJsonAsync<Reservacione>();
                                                         //Clientes
                uri = "api/Clientes";
                HttpRequestMessage reqCliente = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage resCliente = await client.SendAsync(reqCliente);
                IEnumerable<Cliente>? modelCliente = await resCliente.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
                //Vuelos
                uri = "api/Vuelos";
                HttpRequestMessage reqVuelo = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage resVuelo = await client.SendAsync(reqVuelo);
                IEnumerable<Vuelo>? modelVuelo = await resVuelo.Content.ReadFromJsonAsync<IEnumerable<Vuelo>>();
                if (modelCliente is not null)
                {
                    ViewData["IdCliente"] = new SelectList(modelCliente, "IdCliente", "Identidad", model!.IdCliente);
                }

                if (modelVuelo is not null)
                {
                    ViewData["IdVuelo"] = new SelectList(modelVuelo, "IdVuelo", "Destino", model!.IdVuelo);
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
        public async Task<IActionResult> Create([Bind("IdCliente, IdVuelo, NumeroAsiento, Fecha, Precio, Isv, Descuento, Total")] Reservacione Reservacione)
        {
            string uri;
            if (ModelState.IsValid)
            {
                uri = "api/Reservaciones/";
                var content = new StringContent(JsonConvert.SerializeObject(Reservacione),
                    Encoding.UTF8, "application/json");
                
                try
                {
                    HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                    HttpRequestMessage req = new(method: HttpMethod.Post, requestUri: uri);
                    req.Content = content;
                    HttpResponseMessage res = await client.SendAsync(req);
                    if ((int)res.StatusCode == 201)
                    {
                        Reservacione? model = await res.Content.ReadFromJsonAsync<Reservacione>();
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
                
            }
            return View(Reservacione);
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
                uri = $"api/Reservaciones/{id}";
            }
            
            try
            {
                //Reservaciones
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Reservacione? model = await res.Content.ReadFromJsonAsync<Reservacione>();
                //Clientes
                uri = "api/Clientes";
                HttpRequestMessage reqCliente = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage resCliente = await client.SendAsync(reqCliente);
                IEnumerable<Cliente>? modelCliente = await resCliente.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
                //Vuelos
                uri = "api/Vuelos";
                HttpRequestMessage reqVuelo = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage resVuelo = await client.SendAsync(reqVuelo);
                IEnumerable<Vuelo>? modelVuelo = await resVuelo.Content.ReadFromJsonAsync<IEnumerable<Vuelo>>();
                if (modelCliente is not null)
                {
                    ViewData["IdCliente"] = new SelectList(modelCliente, "IdCliente", "Identidad", model!.IdCliente);
                }

                if (modelVuelo is not null)
                {
                    ViewData["IdVuelo"] = new SelectList(modelVuelo, "IdVuelo", "Destino", model!.IdVuelo);
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
        public async Task<IActionResult> Edit(int id, [Bind("IdReservacion, IdCliente, IdVuelo, NumeroAsiento, Fecha, Precio, Isv, Descuento, Total")] Reservacione Reservacione)
        {
            if (id != Reservacione.IdReservacion)
            {
                return NotFound();
            }
            string uri;
            if (ModelState.IsValid)
            {
                uri = $"api/Reservaciones/{id}";
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Reservacione), Encoding.UTF8, "application/json");
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
            return View(Reservacione);
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
                uri = $"api/Reservaciones/{id}";
            }
            
            try
            {
                HttpClient client = clientFactory.CreateClient(name: "Aeropuerto.WebApi");
                HttpRequestMessage req = new(method: HttpMethod.Get, requestUri: uri);
                HttpResponseMessage res = await client.SendAsync(req);
                Reservacione? model = await res.Content.ReadFromJsonAsync<Reservacione>();
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
            uri = $"api/Reservaciones/{id}";
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
