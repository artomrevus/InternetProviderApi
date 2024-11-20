namespace InternetProvider.Infrastructure.Models;

public class EquipmentType
{
    public int EquipmentTypeId { get; set; }

    public string? EquipmentTypeName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}
