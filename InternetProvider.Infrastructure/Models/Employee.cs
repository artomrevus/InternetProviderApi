namespace InternetProvider.Infrastructure.Models;

public class Employee
{
    public int EmployeeId { get; set; }

    public int EmployeePositionId { get; set; }

    public int EmployeeStatusId { get; set; }

    public int OfficeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Connection> Connections { get; set; } = new List<Connection>();

    public virtual EmployeePosition EmployeePosition { get; set; } = null!;

    public virtual EmployeeStatus EmployeeStatus { get; set; } = null!;

    public virtual Office Office { get; set; } = null!;
}
