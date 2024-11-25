using InternetProvider.Abstraction.Entities;

namespace InternetProvider.Abstraction.Repositories;

public interface IInternetConnectionRequestRepository: IRepository<IInternetConnectionRequest>, IGetRepository<IInternetConnectionRequest> { }