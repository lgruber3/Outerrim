using System;
using System.Collections.Generic;

namespace Model.Model;

public partial class CrimeSyndicate
{
    public int SyndicateId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public virtual ICollection<MercenaryReputation> MercenaryReputations { get; set; } = new List<MercenaryReputation>();
}
