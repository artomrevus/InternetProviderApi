namespace InternetProvider.Domain.Entities.Input;

public class StreetInput
{
    public int CityId { get; set; }

    public string? Name { get; set; }

    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}