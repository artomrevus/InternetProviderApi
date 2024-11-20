namespace InternetProvider.Infrastructure.Models;

public class EmployeesReport
{
    public string EmployeeFirstName { get; set; } = null!;

    public string EmployeeLastName { get; set; } = null!;

    public string? EmployeeStatus { get; set; }

    public string? EmployeePosition { get; set; }

    public string? OfficeCity { get; set; }

    public string OfficeAddress { get; set; } = null!;

    public string OfficePhone { get; set; } = null!;

    public string OfficeEmail { get; set; } = null!;

    public int? ConnectionsCount { get; set; }

    public DateOnly? FirstConnectionDate { get; set; }

    public DateOnly? LastConnectionDate { get; set; }

    public int? DaysWithoutConnection { get; set; }
}
