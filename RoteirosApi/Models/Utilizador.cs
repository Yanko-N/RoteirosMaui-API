using System;
using System.Collections.Generic;

namespace RoteirosApi.Models;

public partial class Utilizador
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
