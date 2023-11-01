using System.Security.Cryptography.X509Certificates;

namespace AIrDemo.Application.Services
{
    public class ProdaService : IProdaService
    {
        public async Task<string> Authorise(InformationProviderModel model)
        {
            try
            {
                //var httpClient = _httpClientFactory.CreateClient("AirServiceApi");
                var handler = new HttpClientHandler();
                var cert = new X509Certificate2("<pk12_file_name.p12>", "<password>");
                handler.ClientCertificates.Add(cert);

                HttpClient httpClient = new HttpClient(handler);

                httpClient.BaseAddress = new Uri("https://test.healthclaiming.api.humanservices.gov.au/");
                httpClient.DefaultRequestHeaders.Add("X-IBM-Client-Id", "27e9de6e5d2499e424f2a7394258541b");
                httpClient.DefaultRequestHeaders.Add("dhs-auditId", "ADM00000");
                httpClient.DefaultRequestHeaders.Add("dhs-subjectId", "01012020");
                httpClient.DefaultRequestHeaders.Add("dhs-messageId", "a83f0c71-84a1-42c5-a442-51ea754f088e");
                httpClient.DefaultRequestHeaders.Add("dhs-auditIdType", "Minor Id");
                httpClient.DefaultRequestHeaders.Add("dhs-correlationId", "094077ed-1449-4ac2-b531-60fb043ace0c");
                httpClient.DefaultRequestHeaders.Add("dhs-productId", "RsvpAir 2.0");
                httpClient.DefaultRequestHeaders.Add("dhs-subjectIdType", "Date Of Birth");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJraWQiOiI2dzBZTGF2QUFDYjFMbUVvb1hlTmUwaUoxUmpEdkFUWW5FZG1qMmNDbmtjIiwiYWxnIjoiUlMyNTYifQ.eyJzdWIiOiIxMjg0NDY3NjY2IiwiYXVkIjoiUFJPREEuVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5zd2luc3QiOiJUZXN0UnN2cENvbm4iLCJwcm9kYS50eXBlIjoiVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5vcmciOiIxMjg0NDY3NjY2IiwicHJvZGEucnAiOiJNQ09MIiwicHJvZGEuc3AiOlsiTUNPTCJdLCJwcm9kYS5hdWQiOiJodHRwczovL21lZGljYXJlYXVzdHJhbGlhLmdvdi5hdS9NQ09MIiwiaXNzIjoiaHR0cHM6Ly9wcm9kYS5odW1hbnNlcnZpY2VzLmdvdi5hdSIsImlhdCI6MTY5NjM4MzI0NSwiZXhwIjoxNjk2Mzg2ODQ1fQ.YdQAqhT4fQYFueXVvzIwtVUJ5HQVispVK5WTrekWrxy-ePmOyxsgLsnB_sshtYIcFvMy9cHGNAEzh9DDCKEx20lKeAzmP9iAsRo2xrlDztG3zXr0d-LD2QC6-CZdQHLEshg2AsPDu-VWb8W4pwbIaymEK831_rT_ucZBdkojzD2rMucTh1w28O8whzan2HRMohFh9EQpUoiinynqmKYCHkzn0eB_GDLjTZzsEzjIhic9QECWfdRLnh6B_CHmd-qkIiuT0iDvJ128RhYlGfeGGsdOAEXr7dgfMIS_BYbZnepGXC4jDxx3M8pOysMstVQzwj1tCMv-xq8wepBlJ9zs7A");
        
                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                //var uri = "claiming/ext-vnd/air/immunisation/v1.2/individual/immunisation-history/details";
                //var json = JsonSerializer.Serialize(model, serializeOptions);

                //var data = new StringContent(json, Encoding.UTF8, "application/json");
                //using var httpResponseMessage = await httpClient.PostAsync(uri, data);

                //var content = await httpResponseMessage.Content.ReadAsStringAsync();

                //if (!httpResponseMessage.IsSuccessStatusCode)
                //{
                //    //Errors
                //}
                //httpResponseMessage.EnsureSuccessStatusCode();
                //return content;
                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}
