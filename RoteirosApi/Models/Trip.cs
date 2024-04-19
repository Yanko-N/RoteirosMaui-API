using System;
using System.Collections.Generic;

namespace RoteirosApi.Models;

public partial class Trip
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<Spot> Spots { get; set; } = new List<Spot>();

    public virtual Utilizador? User { get; set; }
}
