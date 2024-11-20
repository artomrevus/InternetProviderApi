namespace InternetProvider.Infrastructure.Models;

public class EmployeePosition
{
    public int EmployeePositionId { get; set; }

    public string? EmployeePositionName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
