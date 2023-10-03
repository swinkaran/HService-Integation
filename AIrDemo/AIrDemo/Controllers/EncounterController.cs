using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIrDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncounterController : ControllerBase
    {
        private readonly IAirService _airService;

        public EncounterController(IAirService airService)
        {
            _airService = airService;
        }

        [HttpGet]
        public IEnumerable<IndividualDetailsResponseModel> RecordEncounter(EncounterRequestModel request)
        {
            return null;
        }

    }
}
