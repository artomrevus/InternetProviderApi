namespace InternetProvider.Domain.Entities.Input;

public class InternetTariffInput
{
    public int InternetTariffStatusId { get; set; }
    public int LocationTypeId { get; set; }
    
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int InternetSpeedMbits { get; set; }
    public string Description { get; set; } = null!;
    
    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}