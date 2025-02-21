using System;
using System.Collections.Generic;

namespace Model.Model;

public partial class AircraftCrewJt
{
    public int AircraftId { get; set; }

    public int MercenaryId { get; set; }

    public DateOnly JoinedAt { get; set; }

    public virtual Aircraft Aircraft { get; set; } = null!;

    public virtual Mercenary Mercenary { get; set; } = null!;
}
