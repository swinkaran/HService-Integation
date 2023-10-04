using System.Text.Json.Serialization;

namespace AIrDemo.Models
{
    public class IndividualHistoryRequestModel
    {
        [JsonPropertyName("individualIdentifier")]
        public string individualIdentifier { get; set; }

        [JsonPropertyName("informationProvider")]
        public InformationProvider informationProvider { get; set; }
    }
}
