namespace InternetProvider.Infrastructure.Models;

public class ConnectionsReport
{
    public string? CityName { get; set; }

    public string InternetTariffName { get; set; } = null!;

    public int? ConnectionsCount { get; set; }

    public int? MultiApartmentBuildingConnections { get; set; }

    public int? SmallApartmentBuildingConnections { get; set; }

    public int? PrivateSectorConnections { get; set; }

    public decimal? AvarageConnectionPrice { get; set; }

    public decimal? MinConnectionPrice { get; set; }

    public decimal? MaxConnectionPrice { get; set; }
}
