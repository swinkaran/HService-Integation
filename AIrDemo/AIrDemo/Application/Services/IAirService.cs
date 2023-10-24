
using AIrDemo.Models.Responses;

namespace AIrDemo.Application.Services
{
    public interface IAirService
    {
        Task<AuthorisationResponse> Authorise(InformationProviderModel request);
        Task<IndividualDetailsResponse> GetIndividualDetails(IndividualDetailsRequestModel request);
        Task<ImmunisationHistoryResponse> GetIndividualImmunisationHistory(IndividualHistoryRequestModel individualIdentifier);
    }
}
