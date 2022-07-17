using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;
namespace Clinica.Web.Pages
{
    public class detallesFacturaModel : PageModel
    {
        private ClinicaContext db;

        public detallesFacturaModel(ClinicaContext injectedContext)
        {
            db = injectedContext;
        }

        public IEnumerable<DetallesFactura>? Detalles { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Facturas";
            Detalles = db.DetallesFacturas.OrderBy(d => d.FacturasId);
        }

        [BindProperty]
        public DetallesFactura? Detalle { get; set; }
        public IActionResult OnPost()
        {
            if ((Detalle is not null) && ModelState.IsValid)
            {
                db.DetallesFacturas.Add(Detalle);
                db.SaveChanges();
                return RedirectToPage("/detallesFactura");
            }
            else
            {
                return Page();
            }
        }
    }
}
