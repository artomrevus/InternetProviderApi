﻿namespace InternetProvider.Domain.Entities;

public class CityOutput
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}
