namespace InternetProvider.Infrastructure.Models;

public class Office
{
    public int OfficeId { get; set; }

    public int CityId { get; set; }

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<OfficeEquipment> OfficeEquipments { get; set; } = new List<OfficeEquipment>();
}
