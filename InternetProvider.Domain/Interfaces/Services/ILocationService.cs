using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;

namespace InternetProvider.Domain.Interfaces.Services;

public interface ILocationService : IDomainCrudService<LocationInput, LocationOutput>, IGetService<LocationOutput> { }