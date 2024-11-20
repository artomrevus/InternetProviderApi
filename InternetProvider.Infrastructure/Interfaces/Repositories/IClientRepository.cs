using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Infrastructure.Interfaces.Repositories;

public interface IClientRepository: IRepository<Client>, IGetIdByUserIdRepository<Client>, IGetRepository<Client> { }