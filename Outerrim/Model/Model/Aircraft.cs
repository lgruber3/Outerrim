using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model;

[Table("AIRCAFTS")]
public partial class Aircraft
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("AIRCRAFT_ID", TypeName = "int"), Required]
    public int AircraftId { get; set; }

    [Column("AIRCRAFT_SPEZIFICATIONSID", TypeName = "int"), Required]
    public int SpezificationId { get; set; }

    
    [Column("FUEL", TypeName = "int"), Required]
    public int Fuel { get; set; }

    [Column("SPEED", TypeName = "int"), Required]
    public int Speed { get; set; }

    [Column("ALTITUDE", TypeName = "int"), Required]
    public int Altitude { get; set; }

    [Column("NAME"), Required]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    public virtual ICollection<AircraftCrewJt> AircraftCrewJts { get; set; } = new List<AircraftCrewJt>();

    public virtual ICollection<Compartment> Compartments { get; set; } = new List<Compartment>();

    public virtual AircraftSpezification Spezification { get; set; } = null!;
}
