using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public static class AeropuertoDBContextExtensions
    {
        public static IServiceCollection addAeropuertoContext(this IServiceCollection services)
        {
            string dbPath = "Server=tcp:aeropuerto-server.database.windows.net,1433;Initial Catalog=aeropuertoDB;Persist Security Info=False;User ID=Administrador;Password=zFD@wvF76rQ9NaS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
            services.AddDbContext<aeropuertoDBContext> (options =>
               options.UseSqlServer($"{dbPath}") );
            return services;
        }
    }
}
