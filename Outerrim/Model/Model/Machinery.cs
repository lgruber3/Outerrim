using System;
using System.Collections.Generic;

namespace Model.Model;

public partial class Machinery
{
    public int MachineryId { get; set; }

    public string Label { get; set; } = null!;

    public string Function { get; set; } = null!;

    public int CompartmentId { get; set; }

    public virtual Compartment Compartment { get; set; } = null!;

    public virtual EnerySystem? EnerySystem { get; set; }

    public virtual EnvironmentalSystem? EnvironmentalSystem { get; set; }

    public virtual Weapon? Weapon { get; set; }
}
