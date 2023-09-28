namespace AIrDemo.Application.Services
{
    public class AirService : IAirService
    {
        public async Task<string> Authorise(InformationProviderModel request)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                return "Authorise";
            }
        }

        public async Task<string> GetIndividualDetails(IndividualDetailsRequestModel request)
        {
            try
            {
                throw new NotImplementedException();
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
