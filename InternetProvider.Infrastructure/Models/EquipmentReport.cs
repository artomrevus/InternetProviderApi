namespace InternetProvider.Infrastructure.Models;

public class EquipmentReport
{
    public string EquipmentName { get; set; } = null!;

    public string? EquipmentType { get; set; }

    public int? CountOfficesHave { get; set; }

    public int? TotalInOffices { get; set; }

    public int? CountConnectionsUse { get; set; }
}
