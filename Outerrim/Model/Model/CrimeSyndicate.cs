using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model;
[Table("CRIME_SYNDICATES")]
public partial class CrimeSyndicate
{
    [Column("SYNDICATE_ID", TypeName = "int")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SyndicateId { get; set; }
    
    [Column("NAME"), Required]
    [StringLength(120)]
    public string Name { get; set; } = null!;
    
    [Column("LOCATION"), Required]
    [StringLength(200)]
    public string Location { get; set; } = null!;

    public virtual ICollection<MercenaryReputation> MercenaryReputations { get; set; } = new List<MercenaryReputation>();
}
