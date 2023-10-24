using System.Text.Json.Serialization;

namespace AIrDemo.Models.Responses
{
    public class IndividualDetailsResponse
    {
        public string statusCode { get; set; }
        public string codeType { get; set; }
        public string message { get; set; }

        public IndividualDetails individualDetails { get; set; }
    }

    public class IndividualDetails
    {
        public string individualIdentifier { get; set; }
        public Individual individual { get; set; }
    }
    
}
