using Aeropuerto.WebApi.Repository;
using Microsoft.AspNetCore.Mvc.Formatters;
using Packt.Shared;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text.Json.Serialization;
using static System.Console;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://localhost:7045/");
builder.Services.AddCors();
builder.Services.AddSwaggerGen(
    c => {
        c.SwaggerDoc("v1", new() { Title = "Aeropuerto Service Web Api", Version = "v1" });
    }
    );

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096;
    options.ResponseBodyLogLimit = 4096;
});

// Add services to the container.
builder.Services.addAeropuertoContext();
builder.Services.AddControllers(options =>
{
    WriteLine("Salida de formato por defecto");
    foreach (IOutputFormatter formateador in options.OutputFormatters)
    {
        OutputFormatter? media = formateador as OutputFormatter;
        if (media == null)
        {
            WriteLine($"{formateador.GetType().Name}");
        }
        else
        {
            WriteLine("{0}, Tipo de Media: {1}",
                arg0: media.GetType().Name,
                arg1: string.Join(",",
                media.SupportedMediaTypes));
        }
    }
}).AddXmlDataContractSerializerFormatters()
.AddXmlSerializerFormatters();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICargoRepository, CargosRepository>();
builder.Services.AddScoped<IAvionRepository, AvionesRepository>();
builder.Services.AddScoped<IVueloRepository, VuelosRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuariosRepository>();
builder.Services.AddScoped<IReservacionRepository, ReservacionesRepository>();
var app = builder.Build();
app.UseCors(configurePolicy: options =>
{
    //options.WithMethods("GET", "POST", "PUT", "DELETE");
    options.WithMethods("GET, POST, PUT, DELETE");
    options.WithOrigins("https://localhost:7160");
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseHttpLogging();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aeropuerto Service API Vesion 1");
        c.SupportedSubmitMethods(new[]
        {
            SubmitMethod.Get, SubmitMethod.Post,
            SubmitMethod.Put, SubmitMethod.Delete
        });
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
