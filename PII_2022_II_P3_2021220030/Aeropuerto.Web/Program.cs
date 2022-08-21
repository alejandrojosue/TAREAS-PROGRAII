using Microsoft.EntityFrameworkCore;
using Packt.Shared;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<aeropuertoDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("aeropuertoDBContext") ?? throw new InvalidOperationException("Connection string 'aeropuertoDBContext' not found.")));

builder.Services.AddHttpClient(name: "Aeropuerto.WebApi",
    configureClient: options =>
    {
        options.BaseAddress = new Uri("https://localhost:7045/");
        options.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json", 1.0));
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
