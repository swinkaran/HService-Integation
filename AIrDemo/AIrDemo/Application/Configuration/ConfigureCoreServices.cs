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
            c.DefaultRequestHeaders.Add("Authorization", "Basic " + "eyJraWQiOiI2dzBZTGF2QUFDYjFMbUVvb1hlTmUwaUoxUmpEdkFUWW5FZG1qMmNDbmtjIiwiYWxnIjoiUlMyNTYifQ.eyJzdWIiOiIxMjg0NDY3NjY2IiwiYXVkIjoiUFJPREEuVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5zd2luc3QiOiJUZXN0UnN2cENvbm4iLCJwcm9kYS50eXBlIjoiVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5vcmciOiIxMjg0NDY3NjY2IiwicHJvZGEucnAiOiJNQ09MIiwicHJvZGEuc3AiOlsiTUNPTCJdLCJwcm9kYS5hdWQiOiJodHRwczovL21lZGljYXJlYXVzdHJhbGlhLmdvdi5hdS9NQ09MIiwiaXNzIjoiaHR0cHM6Ly9wcm9kYS5odW1hbnNlcnZpY2VzLmdvdi5hdSIsImlhdCI6MTY5NzY3Nzc1OSwiZXhwIjoxNjk3NjgxMzU5fQ.TREgNlmoBvOoFWHFwKnKyJt-PFTLohNOtU7CjHS5Yi_jKF1qN_MY04W3UAS4jndWVnNrR9SBbxQ6lzGFjcRv8JxEqHP8StAgBsO6dP1AEFqFzqJXwCjpPZ_XtIn14oa6ir_HsNXgxkio9C8IjabK_jUwg8boY1f-vWPCUpTCk2Wo9dvV1MM7gIQCX29jfN3dFugNBMXojmqcVNiNh5z_8wUryUnVObtasy-9ginPpzqX8bB1ksD8CU8KJfHenfyB25bEk89bt7e04R2LYEIOFFi6d7gUkINAYkL8V46BEkaTZGXaHESGWrOv9IKlljRkWc2ZwM0rEg5WddddLOhDKg");
            c.BaseAddress = new Uri("");
        });

        services.AddHttpClient("AirServiceApi", c =>
        {
            c.BaseAddress = new Uri("https://test.healthclaiming.api.humanservices.gov.au/");
            c.DefaultRequestHeaders.Add("Authorization", "Bearer " + "eyJraWQiOiI2dzBZTGF2QUFDYjFMbUVvb1hlTmUwaUoxUmpEdkFUWW5FZG1qMmNDbmtjIiwiYWxnIjoiUlMyNTYifQ.eyJzdWIiOiIxMjg0NDY3NjY2IiwiYXVkIjoiUFJPREEuVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5zd2luc3QiOiJUZXN0UnN2cENvbm4iLCJwcm9kYS50eXBlIjoiVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5vcmciOiIxMjg0NDY3NjY2IiwicHJvZGEucnAiOiJNQ09MIiwicHJvZGEuc3AiOlsiTUNPTCJdLCJwcm9kYS5hdWQiOiJodHRwczovL21lZGljYXJlYXVzdHJhbGlhLmdvdi5hdS9NQ09MIiwiaXNzIjoiaHR0cHM6Ly9wcm9kYS5odW1hbnNlcnZpY2VzLmdvdi5hdSIsImlhdCI6MTY5Nzc4MjAwMSwiZXhwIjoxNjk3Nzg1NjAxfQ.EVzXJNCrQy9T0RPwuORhKohG3N7Qs26FF0rgpAO0E3VlXDjnlqK6dUZl1fgbjXmjs7RPZTFOotYiVmedGUB0Jw3eMpNCIqI7DcwshkaROVK7yA_x60-UzpKu4cYNpFrUPjRazUZEwu1dkttVFwgKibP_qiqQ-mfVyruMeCSdoP1IB_o6d3VnidtuEWdUBAItOWRPytUzLW3a7rgOs1RXGkmLz2nRxfFD1BU_2E3yGOXyw4677HWzhAf1Orf6vrc9m6jPTsnHEgL2tmd8ro1pzcAE5siK_e-e-zEK4kFQ2u6GlHj_LyX7HLDdqnzS6Bu7aUiJTebSlvD826Az2nSYcA");
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
