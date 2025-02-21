using System;
using System.Collections.Generic;

namespace Model.Model;

public partial class MercenaryReputation
{
    public int SyndicateId { get; set; }

    public int MercenaryId { get; set; }

    public string ReputationChange { get; set; } = null!;

    public virtual Mercenary Mercenary { get; set; } = null!;

    public virtual CrimeSyndicate Syndicate { get; set; } = null!;
}
