using System.ComponentModel.DataAnnotations;

namespace InternetProvider.Application.DTOs.RequestDTOs;

public class InternetConnectionRequestRequestDto
{
    [Required]
    public int ClientId { get; set; }
    [Required]
    public int InternetTariffId { get; set; }
    [Required]
    public int InternetConnectionRequestStatusId { get; set; }
    [Required]
    public string Number { get; set; } = null!;
}