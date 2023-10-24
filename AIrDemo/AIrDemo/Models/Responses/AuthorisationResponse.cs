namespace AIrDemo.Models.Responses
{
    public class AuthorisationResponse
    {
        public string statusCode { get; set; }
        public string codeType { get; set; }
        public string message { get; set; }
        public IEnumerable<AccessList> accessList { get; set; }
    }

    public class AccessList
    {
        public string code { get; set; }
        public string name { get; set; }
        public bool hasAccess { get; set; }
    }
}