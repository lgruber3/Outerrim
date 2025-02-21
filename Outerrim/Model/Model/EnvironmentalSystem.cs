using System;
using System.Collections.Generic;

namespace Model.Model;

public partial class EnvironmentalSystem
{
    public int MachineryId { get; set; }

    public virtual Machinery Machinery { get; set; } = null!;
}
