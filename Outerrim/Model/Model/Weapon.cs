﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model;

[Table("WEAPON")]
public partial class Weapon : Machinery
{
    [Column("MACHINERY_ID", TypeName = "int"), Required ]
    public int MachineryId { get; set; }

    public virtual Machinery Machinery { get; set; } = null!;
}
