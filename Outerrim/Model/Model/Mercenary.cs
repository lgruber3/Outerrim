using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model;

[Table("MERCENARIES")]
public partial class Mercenary
{
    [Column("MERCENARY_ID", TypeName = "int")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MercenaryId { get; set; }
    
    [Column("FIRST_NAME"), Required]
    [StringLength(45)]
    public string FirstName { get; set; } = null!;

    [Column("LAST_NAME"), Required]
    [StringLength(45)]
    public string LastName { get; set; } = null!;

    [Column("BODY_SKILLS", TypeName = "int"), Required]
    public int BodySkills { get; set; }
    
    [Column("COMBAT_SKILLS", TypeName = "int"), Required]
    public int CombatSkill { get; set; }

    public virtual ICollection<AircraftCrewJt> AircraftCrewJts { get; set; } = new List<AircraftCrewJt>();

    public virtual ICollection<MercenaryReputation> MercenaryReputations { get; set; } = new List<MercenaryReputation>();
}
