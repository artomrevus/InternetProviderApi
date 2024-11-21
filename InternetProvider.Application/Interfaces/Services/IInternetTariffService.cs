using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;

namespace InternetProvider.Application.Interfaces.Services;

public interface IInternetTariffService : IAppCrudService<InternetTariffRequestDto, InternetTariffResponseDto> { }