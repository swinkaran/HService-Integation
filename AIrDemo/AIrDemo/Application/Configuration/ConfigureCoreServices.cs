using System.Text;

namespace AIrDemo.Application.Configuration;

public static class ConfigureCoreServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services,
IConfiguration configuration)
    {

        services.AddScoped<IAirService, AirService>();
        services.AddScoped<IProdaService, ProdaService>();
        return services;
    }

    public static IServiceCollection AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
    {
        var encoded = Convert.ToBase64String(Encoding.UTF8
               .GetBytes(configuration["AppSettings:MedAdvisorClientId"] + ":" + configuration["AppSettings:MedAdvisorClientSecret"]));
        services.AddHttpClient("ProdaApi", c =>
        {
            c.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);
            c.DefaultRequestHeaders.Add("grant_type", "client_credentials");
            c.DefaultRequestHeaders.Add("x-api-key", configuration["AppSettings:MedAdvisorApiKey"]);
            c.BaseAddress = new Uri("");
        });

        services.AddHttpClient("AirServiceApi", c =>
        {
            c.DefaultRequestHeaders.Add("x-api-key", configuration["AppSettings:MedAdvisorApiKey"]);
            c.BaseAddress = new Uri("");
        });

        return services;
    }

    public static IServiceCollection AddCustomConfigure(this IServiceCollection services,
   IConfiguration configuration)
    {
        services.AddOptions();
        return services;
    }

    public static IServiceCollection AddSupportedService(this IServiceCollection services,
   IConfiguration configuration)
    {
        services.AddSwaggerGen();
        return services;
    }
}
