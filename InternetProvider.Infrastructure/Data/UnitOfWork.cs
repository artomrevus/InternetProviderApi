using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Data;

public class UnitOfWork(InternetProviderContext context) : IUnitOfWork, IDisposable
{
    public ICityRepository Cities { get; } = new CityRepository(context);
    public IClientRepository Clients { get; } = new ClientRepository(context);
    public IHouseRepository Houses { get; } = new HouseRepository(context);
    public ILocationRepository Locations { get; } = new LocationRepository(context);
    public ILocationTypeRepository LocationTypes { get; } = new LocationTypeRepository(context);
    public IStreetRepository Streets { get; } = new StreetRepository(context);
    public IClientStatusRepository ClientStatuses { get; } = new ClientStatusRepository(context);
    public IInternetTariffStatusRepository InternetTariffStatuses { get; } = new InternetTariffStatusRepository(context);
    public IInternetConnectionRequestStatusRepository InternetConnectionRequestStatuses { get; } = new InternetConnectionRequestStatusRepository(context);
    public IInternetTariffRepository InternetTariffs { get; } = new InternetTariffRepository(context);
    public IInternetConnectionRequestRepository InternetConnectionRequests { get; } = new InternetConnectionRequestRepository(context);

    public async Task CompleteAsync()
    {
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            throw new RepositoryException($"Error while saving changes: {e.InnerException?.Message}");
        }
    }

    void IDisposable.Dispose()
    {
        context.Dispose();
    }
}