using System;
using System.Collections.Generic;

namespace Model.Model;

public partial class Aircraft
{
    public int AircraftId { get; set; }

    public int SpezificationId { get; set; }

    public int Fuel { get; set; }

    public int Speed { get; set; }

    public int Altitude { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AircraftCrewJt> AircraftCrewJts { get; set; } = new List<AircraftCrewJt>();

    public virtual ICollection<Compartment> Compartments { get; set; } = new List<Compartment>();

    public virtual AircraftSpezification Spezification { get; set; } = null!;
}
