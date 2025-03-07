using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model;

[Table("AIRCRAFT_CREW_JT")]
public partial class AircraftCrewJt
{
    [Column("AIRCRAFT_ID", TypeName = "int")]
    public int AircraftId { get; set; }

    [Column("MERCENARY_ID", TypeName = "int")]
    public int MercenaryId { get; set; }

    [Column("JOINED_DATE"), Required]
    public DateOnly JoinedAt { get; set; }

    public virtual Aircraft Aircraft { get; set; } = null!;

    public virtual Mercenary Mercenary { get; set; } = null!;
}
