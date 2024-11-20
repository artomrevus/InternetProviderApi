namespace InternetProvider.Infrastructure.Models;

public class EmployeeStatus
{
    public int EmployeeStatusId { get; set; }

    public string? EmployeeStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
