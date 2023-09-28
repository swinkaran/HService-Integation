namespace AIrDemo.Application.Services
{
    public interface IProdaService
    {
        Task<string> Authorise(InformationProviderModel request);
    }
}
