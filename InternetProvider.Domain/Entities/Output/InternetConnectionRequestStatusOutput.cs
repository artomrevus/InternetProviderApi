namespace InternetProvider.Domain.Entities.Output;

public class InternetConnectionRequestStatusOutput
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}