using InternetProvider.Abstraction.Entities;

namespace InternetProvider.Abstraction.Services;

public interface IClientService: ICrudService<IClient>, IGetIdByUserIdService<IClient>, IGetService<IClient>, IAccessCheckService<IClient>{ }