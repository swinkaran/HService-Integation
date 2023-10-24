using System.Text.Json.Serialization;

namespace AIrDemo.Models
{
    public class IndividualDetailsRequestModel
    {
        [JsonPropertyName("individual")]
        public Individual individual { get; set; }

        [JsonPropertyName("informationProvider")]
        public InformationProvider informationProvider { get; set; }
    }

    public class InformationProvider
    {
        [JsonPropertyName("providerNumber")]
        public string providerNumber { get; set; }
        [JsonPropertyName("hpioNumber")]
        public string hpioNumber { get; set; }
        [JsonPropertyName("hpiiNumber")]
        public string hpiiNumber { get; set; }
    }

    public class MedicareCard
    {
        [JsonPropertyName("medicareCardNumber")]
        public string medicareCardNumber { get; set; }
        [JsonPropertyName("medicareIRN")]
        public string medicareIRN { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("postCode")]
        public string postCode { get; set; }
    }

    public class PersonalDetails
    {
        [JsonPropertyName("dateOfBirth")]
        public string dateOfBirth { get; set; }
        [JsonPropertyName("gender")]
        public string gender { get; set; }
        [JsonPropertyName("firstName")]
        public string firstName { get; set; }
        [JsonPropertyName("lastName")]
        public string lastName { get; set; }
        [JsonPropertyName("initial")]
        public string initial { get; set; }
        [JsonPropertyName("onlyNameIndicator")]
        public bool onlyNameIndicator { get; set; }
    }
    public class Individual
    {
        [JsonPropertyName("personalDetails")]
        public PersonalDetails personalDetails { get; set; }

        [JsonPropertyName("medicareCard")]
        public MedicareCard medicareCard { get; set; }

        [JsonPropertyName("address")]
        public Address address { get; set; }

        [JsonPropertyName("ihiNumber")]
        public string ihiNumber { get; set; }
    }
}