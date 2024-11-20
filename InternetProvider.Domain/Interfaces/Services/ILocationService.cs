using InternetProvider.Domain.Entities;

namespace InternetProvider.Domain.Interfaces.Services;

public interface ILocationService : IDomainCrudService<LocationInput, LocationOutput>, IGetService<LocationOutput> { }