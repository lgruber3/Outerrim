using System;
using System.Collections.Generic;

namespace Model.Model;

public partial class Mercenary
{
    public int MercenaryId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int BodySkills { get; set; }

    public int CombatSkill { get; set; }

    public virtual ICollection<AircraftCrewJt> AircraftCrewJts { get; set; } = new List<AircraftCrewJt>();
}
