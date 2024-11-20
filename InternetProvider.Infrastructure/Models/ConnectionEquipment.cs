namespace InternetProvider.Infrastructure.Models;

public class ConnectionEquipment
{
    public int ConnectionEquipmentId { get; set; }

    public int ConnectionId { get; set; }

    public int OfficeEquipmentId { get; set; }

    public int ConnectionEquipmentAmount { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual Connection Connection { get; set; } = null!;

    public virtual OfficeEquipment OfficeEquipment { get; set; } = null!;
}
