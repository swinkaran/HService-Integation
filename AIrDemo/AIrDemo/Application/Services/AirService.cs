using Microsoft.OpenApi.Models;
using RestSharp;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Reflection;

namespace AIrDemo.Application.Services
{
    public class AirService : IAirService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AirService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Authorise(InformationProviderModel model)
        {
            try
            {
                //var httpClient = _httpClientFactory.CreateClient("AirServiceApi");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("https://test.healthclaiming.api.humanservices.gov.au/");
                httpClient.DefaultRequestHeaders.Add("X-IBM-Client-Id", "27e9de6e5d2499e424f2a7394258541b");
                httpClient.DefaultRequestHeaders.Add("dhs-auditId", "ADM00000");
                httpClient.DefaultRequestHeaders.Add("dhs-subjectId", "01012020");
                httpClient.DefaultRequestHeaders.Add("dhs-messageId", "a83f0c71-84a1-42c5-a442-51ea754f088e");
                httpClient.DefaultRequestHeaders.Add("dhs-auditIdType", "Minor Id");
                httpClient.DefaultRequestHeaders.Add("dhs-correlationId", "094077ed-1449-4ac2-b531-60fb043ace0c");
                httpClient.DefaultRequestHeaders.Add("dhs-productId", "RsvpAir 2.0");
                httpClient.DefaultRequestHeaders.Add("dhs-subjectIdType", "Date Of Birth");
                //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJraWQiOiI2dzBZTGF2QUFDYjFMbUVvb1hlTmUwaUoxUmpEdkFUWW5FZG1qMmNDbmtjIiwiYWxnIjoiUlMyNTYifQ.eyJzdWIiOiIxMjg0NDY3NjY2IiwiYXVkIjoiUFJPREEuVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5zd2luc3QiOiJUZXN0UnN2cENvbm4iLCJwcm9kYS50eXBlIjoiVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5vcmciOiIxMjg0NDY3NjY2IiwicHJvZGEucnAiOiJNQ09MIiwicHJvZGEuc3AiOlsiTUNPTCJdLCJwcm9kYS5hdWQiOiJodHRwczovL21lZGljYXJlYXVzdHJhbGlhLmdvdi5hdS9NQ09MIiwiaXNzIjoiaHR0cHM6Ly9wcm9kYS5odW1hbnNlcnZpY2VzLmdvdi5hdSIsImlhdCI6MTY5NjMwMTIwOCwiZXhwIjoxNjk2MzA0ODA4fQ.oxIEmGIskhRaPuv7tlT9CnCPuaw6iKpKdgWVOBRCYoLNPUK2OGg1wjweiWkAKk8ZTMA94Cyd6mzj7XGWMAgw1wd7al8QxOscBr_rzsPvBJ8dD6rTCPEJD3yerO-3_D-u8XrVDCxDMCuOylRoDT46DqrnldOTWmb5eFGvVJVkrrGMcuaOrHD5Lw4uGYuoYYysSTynpu-YXH4B60S-rTCXH4KqjcrGXq0wV5522z_XhfTXR1HSsCUKtbCtLjYa0VpVvSGmpYDu2_MjzSDzyA9-4LlavOV9uvmpxsDPf4QFf_xkJwu6ll7ojMd-lH6jSJg-4Icrz7QD6XxxZJ1IDcKABQ");

                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJraWQiOiI2dzBZTGF2QUFDYjFMbUVvb1hlTmUwaUoxUmpEdkFUWW5FZG1qMmNDbmtjIiwiYWxnIjoiUlMyNTYifQ.eyJzdWIiOiIxMjg0NDY3NjY2IiwiYXVkIjoiUFJPREEuVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5zd2luc3QiOiJUZXN0UnN2cENvbm4iLCJwcm9kYS50eXBlIjoiVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5vcmciOiIxMjg0NDY3NjY2IiwicHJvZGEucnAiOiJNQ09MIiwicHJvZGEuc3AiOlsiTUNPTCJdLCJwcm9kYS5hdWQiOiJodHRwczovL21lZGljYXJlYXVzdHJhbGlhLmdvdi5hdS9NQ09MIiwiaXNzIjoiaHR0cHM6Ly9wcm9kYS5odW1hbnNlcnZpY2VzLmdvdi5hdSIsImlhdCI6MTY5NjMxMTg0MCwiZXhwIjoxNjk2MzE1NDQwfQ.On4ARXmxbkJaqlpeRp-S5HpxCU_75a8--Zl_uI8KpwpDvfpKEDOzDWk9clNHtu3xNgWIGFAyO0q2KfSu2i7wm9t4tgS9MVg63jMWnvpqWV_CQ7dXLpzqd7HHzshgefaWHG2xJLW_RF9wqCWBT2zTcC-MSesnFJKC2o4zJLOXU6stjas2wL9cVUCVvJI3JElO-eLZ8NLVykd8p1Lc4ph34OU8JlsawNGlWgN3IM0S-LMp_e57owF2swgGgwfcw412dRP-yy6IgR-Akt_BKZ_Rrd19_Rb-SY4wsbe4Be7CEblj-rI0SJKqIrvywm4-p8vxmvJbc1Flxy48TA4OlyNONg");
                //httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

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
                return content;
            }
            catch
            {
                return "GetIndividualDetails";
            }
        }

        public async Task<string> GetIndividualDetails(IndividualDetailsRequestModel model)
        {
            try
            {
                //var httpClient = _httpClientFactory.CreateClient("AirServiceApi");

                HttpClient httpClient = new HttpClient();
                
                httpClient.BaseAddress = new Uri("https://test.healthclaiming.api.humanservices.gov.au/");
                httpClient.DefaultRequestHeaders.Add("X-IBM-Client-Id", "27e9de6e5d2499e424f2a7394258541b");
                httpClient.DefaultRequestHeaders.Add("dhs-auditId", "ADM00000");
                httpClient.DefaultRequestHeaders.Add("dhs-subjectId", "01012020");
                httpClient.DefaultRequestHeaders.Add("dhs-messageId", "a83f0c71-84a1-42c5-a442-51ea754f088e");
                httpClient.DefaultRequestHeaders.Add("dhs-auditIdType", "Minor Id");
                httpClient.DefaultRequestHeaders.Add("dhs-correlationId", "094077ed-1449-4ac2-b531-60fb043ace0c");
                httpClient.DefaultRequestHeaders.Add("dhs-productId", "RsvpAir 2.0");
                httpClient.DefaultRequestHeaders.Add("dhs-subjectIdType", "Date Of Birth");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJraWQiOiI2dzBZTGF2QUFDYjFMbUVvb1hlTmUwaUoxUmpEdkFUWW5FZG1qMmNDbmtjIiwiYWxnIjoiUlMyNTYifQ.eyJzdWIiOiIxMjg0NDY3NjY2IiwiYXVkIjoiUFJPREEuVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5zd2luc3QiOiJUZXN0UnN2cENvbm4iLCJwcm9kYS50eXBlIjoiVU5BVFRFTkRFRC5CMkIiLCJwcm9kYS5vcmciOiIxMjg0NDY3NjY2IiwicHJvZGEucnAiOiJNQ09MIiwicHJvZGEuc3AiOlsiTUNPTCJdLCJwcm9kYS5hdWQiOiJodHRwczovL21lZGljYXJlYXVzdHJhbGlhLmdvdi5hdS9NQ09MIiwiaXNzIjoiaHR0cHM6Ly9wcm9kYS5odW1hbnNlcnZpY2VzLmdvdi5hdSIsImlhdCI6MTY5NjMxMTg0MCwiZXhwIjoxNjk2MzE1NDQwfQ.On4ARXmxbkJaqlpeRp-S5HpxCU_75a8--Zl_uI8KpwpDvfpKEDOzDWk9clNHtu3xNgWIGFAyO0q2KfSu2i7wm9t4tgS9MVg63jMWnvpqWV_CQ7dXLpzqd7HHzshgefaWHG2xJLW_RF9wqCWBT2zTcC-MSesnFJKC2o4zJLOXU6stjas2wL9cVUCVvJI3JElO-eLZ8NLVykd8p1Lc4ph34OU8JlsawNGlWgN3IM0S-LMp_e57owF2swgGgwfcw412dRP-yy6IgR-Akt_BKZ_Rrd19_Rb-SY4wsbe4Be7CEblj-rI0SJKqIrvywm4-p8vxmvJbc1Flxy48TA4OlyNONg");
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
                return content;
            }
            catch
            {
                return "GetIndividualDetails";
            }
        }

        public async Task<string> GetIndividualImmunisationHistory(string individualIdentifier)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                return "GetIndividualImmunisationHistory";
            }
        }
    }
}
