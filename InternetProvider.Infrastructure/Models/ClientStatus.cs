namespace InternetProvider.Infrastructure.Models;

public class ClientStatus
{
    public int ClientStatusId { get; set; }

    public string? ClientStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
