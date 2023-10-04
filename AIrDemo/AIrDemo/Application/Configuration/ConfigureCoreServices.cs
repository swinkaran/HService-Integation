using System.Net.Http;
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
            c.BaseAddress = new Uri("https://test.healthclaiming.api.humanservices.gov.au/");
            c.DefaultRequestHeaders.Add("X-IBM-Client-Id", "27e9de6e5d2499e424f2a7394258541b");
            c.DefaultRequestHeaders.Add("dhs-auditId", "ADM00000");
            c.DefaultRequestHeaders.Add("dhs-subjectId", "01012020");
            c.DefaultRequestHeaders.Add("dhs-messageId", "a83f0c71-84a1-42c5-a442-51ea754f088e");
            c.DefaultRequestHeaders.Add("dhs-auditIdType", "Minor Id");
            c.DefaultRequestHeaders.Add("dhs-correlationId", "094077ed-1449-4ac2-b531-60fb043ace0c");
            c.DefaultRequestHeaders.Add("dhs-productId", "RsvpAir 2.0");
            c.DefaultRequestHeaders.Add("dhs-subjectIdType", "Date Of Birth");
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
