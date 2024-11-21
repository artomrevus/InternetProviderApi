using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;

namespace InternetProvider.Domain.Interfaces.Services;

public interface IInternetTariffService : IDomainCrudService<InternetTariffInput, InternetTariffOutput> { }