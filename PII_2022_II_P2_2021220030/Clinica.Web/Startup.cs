using Packt.Shared;

namespace Clinica.Web
{
    public class Startup
    {
        public void configureServices(IServiceCollection services)
        { 
            services.AddRazorPages();
            services.addClinicaContext();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseAuthorization();
            app.UseEndpoints(enpoints =>
            {
                enpoints.MapRazorPages();
                //enpoints.MapGet("/", ()=> "Hello Word");
            });
        }


    }
}
