using AIrDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIrDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndividualController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<IndividualDetailsResponseModel> GetIndividualDetails(IndividualDetailsRequestModel request)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public IEnumerable<ImmunisationHistoryResponse> GetImmunisationHistory(string individualIdentifier)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
