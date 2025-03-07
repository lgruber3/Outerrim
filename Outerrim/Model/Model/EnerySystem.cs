using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model;

[Table("ENERGYSYSTEM")]
public partial class EnerySystem : Machinery
{
    [Column("MACHINERY_ID"), Required]
    public int MachineryId { get; set; }

    public virtual Machinery Machinery { get; set; } = null!;
}
