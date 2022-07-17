using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;
namespace Clinica.Web.Pages
{
    public class FacturasModel : PageModel
    {
        private ClinicaContext db;

        public FacturasModel(ClinicaContext injectedContext)
        {
            db = injectedContext;
        }

        public IEnumerable<Factura>? Facturas { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Facturas";
            Facturas = db.Facturas.OrderBy(f => f.FacturasId);
        }

        [BindProperty]
        public Factura? Factura { get; set; }
        public IActionResult OnPost()
        {
            if ((Factura is not null))
            {
                db.Facturas.Add(Factura);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return Page();
                }
                return RedirectToPage("/Facturas");
            }
            else
            {
                return Page();
            }
        }
    }
}
