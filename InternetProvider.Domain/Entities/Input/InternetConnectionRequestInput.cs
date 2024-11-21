namespace InternetProvider.Domain.Entities.Input;

public class InternetConnectionRequestInput
{
    public int ClientId { get; set; }
    public int InternetTariffId { get; set; }
    public int InternetConnectionRequestStatusId { get; set; }
    
    public string Number { get; set; } = null!;
    public DateOnly RequestDate { get; set; }
    
    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}