namespace InternetProvider.Domain.Entities.Input;

public class InternetConnectionRequestStatusInput
{
    public string? Name { get; set; }

    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}