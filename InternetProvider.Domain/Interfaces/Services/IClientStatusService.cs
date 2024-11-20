using InternetProvider.Domain.Entities;

namespace InternetProvider.Domain.Interfaces.Services;

public interface IClientStatusService: IDomainCrudService<ClientStatusInput, ClientStatusOutput> { }