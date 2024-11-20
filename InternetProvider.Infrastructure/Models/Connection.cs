namespace InternetProvider.Infrastructure.Models;

public class Connection
{
    public int ConnectionId { get; set; }

    public int? InternetConnectionRequestId { get; set; }

    public int ConnectionTariffId { get; set; }

    public int EmployeeId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateOnly ConnectionDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<ConnectionEquipment> ConnectionEquipments { get; set; } = new List<ConnectionEquipment>();

    public virtual ConnectionTariff ConnectionTariff { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual InternetConnectionRequest? InternetConnectionRequest { get; set; }
}
