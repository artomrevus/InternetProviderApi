namespace InternetProvider.Infrastructure.Models;

public class ConnectionTariff
{
    public int ConnectionTariffId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Connection> Connections { get; set; } = new List<Connection>();
}
