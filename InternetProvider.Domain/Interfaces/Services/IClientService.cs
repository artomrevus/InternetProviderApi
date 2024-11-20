using InternetProvider.Domain.Entities;

namespace InternetProvider.Domain.Interfaces.Services;

public interface IClientService: IDomainCrudService<ClientInput, ClientOutput>, IGetIdByUserIdService<ClientOutput>, IGetService<ClientOutput>{ }