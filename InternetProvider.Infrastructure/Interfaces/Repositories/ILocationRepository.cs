using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Infrastructure.Interfaces.Repositories;

public interface ILocationRepository: IRepository<Location>, IGetRepository<Location> { }