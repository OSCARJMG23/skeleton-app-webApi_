using Dominio.Interfaces;
using Microsoft.Extensions.Options;
using Aplication.UnitOfWork;

namespace ApiIncidencias.Extensions;

public static class ApplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()        //WithOrigins("https://domini.com")
            .AllowAnyMethod()               //WithMethods(*Get", "POST")
            .AllowAnyHeader());             //WithHeaders(*accept", "content-type")
    });

    public static void AddAplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
