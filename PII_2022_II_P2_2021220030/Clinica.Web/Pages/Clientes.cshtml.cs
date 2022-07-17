using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace Clinica.Web.Pages
{
    public class ClientesModel : PageModel
    {
        private ClinicaContext db;

        public ClientesModel(ClinicaContext injectedContext)
        {
            db= injectedContext;
        }

        public IEnumerable<Cliente>? customers { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Clientes";
            customers = db.Clientes.OrderBy(cliente =>cliente.Nombre).ThenBy(cliente=>cliente.Apellido);
        }
        [BindProperty]
        public Cliente? Cliente { get; set; }
        public IActionResult OnPost()
        {
  
            if ((Cliente is not null))//&& ModelState.IsValid
            {

                db.Clientes.Add(Cliente);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return Page();
                }
                
                return RedirectToPage("/Clientes");
            }
            else
            {
                return Page();
            }
        }
    }
}
