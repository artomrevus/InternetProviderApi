namespace InternetProvider.Domain.Entities.Input;

public class CityInput
{
    public string? Name { get; set; }
    
    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}