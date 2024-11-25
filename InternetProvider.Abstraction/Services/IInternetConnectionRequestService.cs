using InternetProvider.Abstraction.Entities;

namespace InternetProvider.Abstraction.Services;

public interface IInternetConnectionRequestService : ICrudService<IInternetConnectionRequest>, IGetService<IInternetConnectionRequest> { }