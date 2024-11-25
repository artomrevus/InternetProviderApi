using InternetProvider.Abstraction.Entities;

namespace InternetProvider.Abstraction.Repositories;

public interface ILocationRepository: IRepository<ILocation>, IGetRepository<ILocation> { }