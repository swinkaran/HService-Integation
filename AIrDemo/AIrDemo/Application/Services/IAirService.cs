
namespace AIrDemo.Application.Services
{
    public interface IAirService
    {
        Task<string> Authorise(InformationProviderModel request);
        Task<string> GetIndividualDetails(IndividualDetailsRequestModel request);
        Task<string> GetIndividualImmunisationHistory(IndividualHistoryRequestModel individualIdentifier);
    }
}
