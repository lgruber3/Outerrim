using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model;
 [Table("ENVIRONMENTALSYSTEM")]
public partial class EnvironmentalSystem : Machinery
{
    [Column("MACHINERY_ID", TypeName = "int"), Required]
    public int MachineryId { get; set; }

    public virtual Machinery Machinery { get; set; } = null!;
}
