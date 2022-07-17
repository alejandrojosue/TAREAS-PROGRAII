using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public static class ClinicaContextExtensions
    {
        public static IServiceCollection addClinicaContext(this IServiceCollection services,
            string relativePath= "..\\Clinica.Common.DataContext.Sqlite\\bin\\Debug\\net6.0")
        {
            string databasePath = Path.Combine(relativePath, "Clinica.db");
            services.AddDbContext<ClinicaContext>(options =>
            options.UseSqlite($"Data Source={databasePath}"));
            return services;
        }
    }
}
