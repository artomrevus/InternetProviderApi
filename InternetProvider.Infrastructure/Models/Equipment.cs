namespace InternetProvider.Infrastructure.Models;

public class Equipment
{
    public int EquipmentId { get; set; }

    public int EquipmentTypeId { get; set; }

    public decimal Price { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual EquipmentType EquipmentType { get; set; } = null!;

    public virtual ICollection<OfficeEquipment> OfficeEquipments { get; set; } = new List<OfficeEquipment>();
}
