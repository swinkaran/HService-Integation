namespace AIrDemo.Models.Responses
{
    public class ImmunisationHistoryResponse
    {
        public string statusCode { get; set; }
        public string codeType { get; set; }
        public string message { get; set; }
        public ImmunisationDetails immunisationDetails { get; set; }
    }

    public class episode
    {
        public string id { get; set; }
        public string vaccineBatch { get; set; }
        public string vaccineCode { get; set; }
        public string vaccineDose { get; set; }
        public string vaccineSerialNumber { get; set; }
        public string vaccineFundingType { get; set; }
        public string routeOfAdministration { get; set; }
        public Information information { get; set; }
        public string editable { get; set; }
        public string actionRequiredIndicator { get; set; }
    }

    public class Information
    {
        public string status { get; set; }
        public string code { get; set; }
        public string text { get; set; }
    }

    public class encounter
    {
        public IList<episode> episodes { get; set; }
        public string editable { get; set; }
        public string dateOfService { get; set; }
        public string dateSubmitted { get; set; }
        public string schoolId { get; set; }
        public string administeredOverseas { get; set; }
        public string countryCode { get; set; }
        public string claimSeqNum { get; set; }
        public string immEncSeqNum { get; set; }
        public string claimId { get; set; }
    }

    public class ImmunisationDetails
    {
        public IList<encounter> encounters { get; set; }
    }
}
