using InternetProvider.Abstraction.Entities;

namespace InternetProvider.Abstraction.Services;

public interface ILocationService : ICrudService<ILocation>, IGetService<ILocation> { }