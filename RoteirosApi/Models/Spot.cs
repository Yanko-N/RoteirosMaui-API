using System;
using System.Collections.Generic;

namespace RoteirosApi.Models;

public partial class Spot
{
    public int Id { get; set; }

    public int? TripId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Adress { get; set; }

    public bool? IsVisited { get; set; }

    public virtual Trip? Trip { get; set; }
}
