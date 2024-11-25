namespace InternetProvider.Abstraction.Repositories;

public interface IUnitOfWork
{
    ICityRepository Cities { get; }
    IClientRepository Clients { get; }
    IHouseRepository Houses { get; }
    ILocationRepository Locations { get; }
    ILocationTypeRepository LocationTypes { get; }
    IStreetRepository Streets { get; }
    IClientStatusRepository ClientStatuses { get; }
    IInternetTariffStatusRepository InternetTariffStatuses { get; }
    IInternetConnectionRequestStatusRepository InternetConnectionRequestStatuses { get; }
    IInternetTariffRepository InternetTariffs { get; }
    IInternetConnectionRequestRepository InternetConnectionRequests { get; }
    Task CompleteAsync();
}