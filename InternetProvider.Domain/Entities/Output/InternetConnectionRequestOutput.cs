namespace InternetProvider.Domain.Entities.Output;

public class InternetConnectionRequestOutput
{
    public string ClientPhoneNumber { get; set; } = null!;
    public string ClientEmail { get; set; } = null!;
    public string InternetTariffName { get; set; } = null!;
    public decimal InternetTariffPrice { get; set; }
    public int InternetTariffSpeedMbits { get; set; }
    public string? InternetConnectionRequestStatusName { get; set; }
    
    public string Number { get; set; } = null!;
    public DateOnly RequestDate { get; set; }
    
    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}