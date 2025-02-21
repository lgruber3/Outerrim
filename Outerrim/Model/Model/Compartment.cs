using System;
using System.Collections.Generic;

namespace Model.Model;

public partial class Compartment
{
    public int CompartmentId { get; set; }

    public int AircraftId { get; set; }

    public virtual Aircraft Aircraft { get; set; } = null!;

    public virtual ICollection<Machinery> Machineries { get; set; } = new List<Machinery>();
}
