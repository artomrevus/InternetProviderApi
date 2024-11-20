namespace InternetProvider.Infrastructure.Models;

public class OfficeEquipment
{
    public int OfficeEquipmentId { get; set; }

    public int OfficeId { get; set; }

    public int EquipmentId { get; set; }

    public int OfficeEquipmentAmount { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<ConnectionEquipment> ConnectionEquipments { get; set; } = new List<ConnectionEquipment>();

    public virtual Equipment Equipment { get; set; } = null!;

    public virtual Office Office { get; set; } = null!;
}
