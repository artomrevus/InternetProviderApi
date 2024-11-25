using InternetProvider.Abstraction.Entities;

namespace InternetProvider.Abstraction.Repositories;

public interface IClientRepository: IRepository<IClient>, IGetIdByUserIdRepository<IClient>, IGetRepository<IClient> { }