using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model;

[Table("AIRCRAFT_SPEZIFICATIONS")]
public partial class AircraftSpezification
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("SPEZIFICATION_ID"), Required]
    public int SpezificationId { get; set; }

    [Column("STRUCTURE", TypeName = "int"), Required]
    public int Structure { get; set; }

    [Column("FUEL_TANK_CAPACITY", TypeName = "int"), Required]
    public int FuelTankCapacity { get; set; }

    [Column("MIN_SPEED", TypeName = "int"), Required]
    public int MinSpeed { get; set; }

    [Column("MAX_SPEED", TypeName = "int"), Required]
    public int MaxSpeed { get; set; }

    [Column("MAX_ALTITUDE", TypeName = "int"), Required]
    public int MaxAltitude { get; set; }

    [Column("SPEZIFICATION_CODE")]
    [StringLength(45), Required]
    public string SpezificationCode { get; set; } = null!;

    public virtual ICollection<Aircraft> Aircraft { get; set; } = new List<Aircraft>();
}
