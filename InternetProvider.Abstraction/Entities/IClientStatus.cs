namespace InternetProvider.Abstraction.Entities;

public interface IClientStatus
{
    public int ClientStatusId { get; set; }

    public string? ClientStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<IClient> Clients { get; set; }
}