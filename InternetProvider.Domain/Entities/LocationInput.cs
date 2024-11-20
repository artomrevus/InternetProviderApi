namespace InternetProvider.Domain.Entities;

public class LocationInput
{
    public int LocationTypeId { get; set; }
    public int HouseId { get; set; }

    public int? ApartmentNumber { get; set; }

    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}