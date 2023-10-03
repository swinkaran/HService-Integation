using Microsoft.AspNetCore.Mvc;

namespace AIrDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualController : ControllerBase
    {
        private readonly IAirService _airService;

        private static readonly string[] Summaries = new[]
        {
        "Flu", "Whooping", "Covid", "Moderna", "Bivalent", "Pfizer", "Meningo", "Novota", "Shrinje", "Influenza"
        };

        public IndividualController(IAirService airService)
        {
            _airService = airService;

            // setup models
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //return await _airService.Authorise(request);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("history")]
        public IEnumerable<WeatherForecast> GetAirHistory()
        {
            //return await _airService.Authorise(request);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("authorise")]
        [HttpPost]
        public async Task<string> Authorise([FromBody] InformationProviderModel request, CancellationToken ct = default)
        {
            return await _airService.Authorise(request);
        }

        [Route("details")]
        [HttpPost]
        public async Task<string> GetIndividualDetails([FromBody] IndividualDetailsRequestModel request, CancellationToken ct = default)
        {
            return await _airService.GetIndividualDetails(request);
        }

        [HttpPost]
        [Route("history")]
        public async Task<string> GetImmunisationHistory(string individualIdentifier)
        {
            return await _airService.GetIndividualImmunisationHistory(individualIdentifier);
        }
    }
}
