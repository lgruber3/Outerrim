using System;
using System.Collections.Generic;

namespace Model.Model;

public partial class AircraftSpezification
{
    public int SpezificationId { get; set; }

    public int Structure { get; set; }

    public int FuelTankCapacity { get; set; }

    public int MinSpeed { get; set; }

    public int MaxSpeed { get; set; }

    public int MaxAltitude { get; set; }

    public string SpezificationCode { get; set; } = null!;

    public virtual ICollection<Aircraft> Aircraft { get; set; } = new List<Aircraft>();
}
