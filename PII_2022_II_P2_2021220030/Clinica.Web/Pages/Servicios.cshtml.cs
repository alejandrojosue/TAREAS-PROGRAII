using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace Clinica.Web.Pages
{
    public class ServiciosModel : PageModel
    {
        private ClinicaContext db;

        public ServiciosModel(ClinicaContext injectedContext)
        {
            db = injectedContext;
        }

        public IEnumerable<Servicio>? Servicios { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Servicios";
            Servicios = db.Servicios.OrderBy(s=>s.Nombre);
        }
        [BindProperty]
        public Servicio? Servicio { get; set; }
        public IActionResult OnPost()
        {
            if((Servicio is not null) && ModelState.IsValid)
            {
                db.Servicios.Add(Servicio);
                db.SaveChanges();
                return RedirectToPage("/Servicios");
            }
            else
            {
                return Page();
            }
        }
    }
}
