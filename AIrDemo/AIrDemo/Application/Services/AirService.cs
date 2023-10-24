namespace AIrDemo.Application.Services
{
    public class AirService : IAirService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AirService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<AuthorisationResponse> Authorise(InformationProviderModel model)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("AirServiceApi");

                //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJraWQiOiI2dzBZTGF2QUFDYjFMbUVvb1hlTmUwaUoxUmpEdkFUWW5FZG1qMmNDbmtjIiwiYWxnIjoiUlMyNTYifQ.eyJzdWIiOiIxMjg0NDY3NjY2IiwiYXVkIjoiUFJPREEuVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5zd2luc3QiOiJUZXN0UnN2cENvbm4iLCJwcm9kYS50eXBlIjoiVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5vcmciOiIxMjg0NDY3NjY2IiwicHJvZGEucnAiOiJNQ09MIiwicHJvZGEuc3AiOlsiTUNPTCJdLCJwcm9kYS5hdWQiOiJodHRwczovL21lZGljYXJlYXVzdHJhbGlhLmdvdi5hdS9NQ09MIiwiaXNzIjoiaHR0cHM6Ly9wcm9kYS5odW1hbnNlcnZpY2VzLmdvdi5hdSIsImlhdCI6MTY5NjM4MzI0NSwiZXhwIjoxNjk2Mzg2ODQ1fQ.YdQAqhT4fQYFueXVvzIwtVUJ5HQVispVK5WTrekWrxy-ePmOyxsgLsnB_sshtYIcFvMy9cHGNAEzh9DDCKEx20lKeAzmP9iAsRo2xrlDztG3zXr0d-LD2QC6-CZdQHLEshg2AsPDu-VWb8W4pwbIaymEK831_rT_ucZBdkojzD2rMucTh1w28O8whzan2HRMohFh9EQpUoiinynqmKYCHkzn0eB_GDLjTZzsEzjIhic9QECWfdRLnh6B_CHmd-qkIiuT0iDvJ128RhYlGfeGGsdOAEXr7dgfMIS_BYbZnepGXC4jDxx3M8pOysMstVQzwj1tCMv-xq8wepBlJ9zs7A");

                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var uri = "claiming/ext-vnd/air/immunisation/v1/authorisation/access/list";
                var json = JsonSerializer.Serialize(model, serializeOptions);

                var data = new StringContent(json, Encoding.UTF8, "application/json");
                using var httpResponseMessage = await httpClient.PostAsync(uri, data);

                var content = await httpResponseMessage.Content.ReadAsStringAsync();

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    //Errors
                }
                httpResponseMessage.EnsureSuccessStatusCode();
                var result = JsonSerializer.Deserialize<AuthorisationResponse>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                    ?? new AuthorisationResponse { };
                return result;
            }
            catch
            {
                return new AuthorisationResponse { };
            }
        }

        public async Task<IndividualDetailsResponse> GetIndividualDetails(IndividualDetailsRequestModel model)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("AirServiceApi");
                
                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var uri = "claiming/ext-vnd/air/immunisation/v1.1/individual/details";
                var json = JsonSerializer.Serialize(model, serializeOptions);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                using var httpResponseMessage = await httpClient.PostAsync(uri, data);
                var content = await httpResponseMessage.Content.ReadAsStringAsync();

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    //Errors
                }

                httpResponseMessage.EnsureSuccessStatusCode();
                var result = JsonSerializer.Deserialize<IndividualDetailsResponse>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                    ?? new IndividualDetailsResponse { };
                return result;
            }
            catch
            {
                return new IndividualDetailsResponse { };
            }
        }

        public async Task<ImmunisationHistoryResponse> GetIndividualImmunisationHistory(IndividualHistoryRequestModel model)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("AirServiceApi");

                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var uri = "claiming/ext-vnd/air/immunisation/v1.2/individual/immunisation-history/details";
                var json = JsonSerializer.Serialize(model, serializeOptions);

                var data = new StringContent(json, Encoding.UTF8, "application/json");
                using var httpResponseMessage = await httpClient.PostAsync(uri, data);

                var content = await httpResponseMessage.Content.ReadAsStringAsync();

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    //Errors
                }
                httpResponseMessage.EnsureSuccessStatusCode();

                var result = JsonSerializer.Deserialize<ImmunisationHistoryResponse>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
                    ?? new ImmunisationHistoryResponse { };
                return result;
            }
            catch
            {
                return new ImmunisationHistoryResponse {
                 codeType ="AIRError",
                  statusCode= "AIR-E-0000",
                  message="Error reading from AIR, invoking mock server to read data.",
                   immunisationDetails = new ImmunisationDetails { 
                    encounters = new List<encounter> {
                     new encounter { claimId = "WB00ZH3$",  },
                     new encounter {}
                    }
                   }

                };
            }
        }
    }
}
