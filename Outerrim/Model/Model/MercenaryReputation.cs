using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model;

[Table("MERCENARY_REPUTATION")]
public partial class MercenaryReputation
{
    [Column("SYNDICATE_ID", TypeName = "int"), Required]
    public int SyndicateId { get; set; }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("MERCENARY_ID", TypeName = "int"), Required]
    public int MercenaryId { get; set; }

    [Column("REPUTATION_CHANGE"), Required]
    [StringLength(50)]
    public string ReputationChange { get; set; } = null!;

    public virtual Mercenary Mercenary { get; set; } = null!;

    public virtual CrimeSyndicate Syndicate { get; set; } = null!;
}
