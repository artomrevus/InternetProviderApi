using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Infrastructure.Interfaces.Repositories;

public interface IInternetConnectionRequestRepository: IRepository<InternetConnectionRequest>, IGetRepository<InternetConnectionRequest> { }