using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model;

[Table("MACHINERIES")]
public partial class Machinery
{
    [Column("MACHINERY_ID", TypeName = "int"), Required]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MachineryId { get; set; }

    [Column("LABEL"), Required]
    [StringLength(45)]
    public string Label { get; set; } = null!;

    [Column("FUNKTION"), Required]
    [StringLength(45)]
    public string Function { get; set; } = null!;

    [Column("COMPARTMENT_ID", TypeName = "int")]
    public int CompartmentId { get; set; }

    public virtual Compartment Compartment { get; set; } = null!;

    public virtual EnerySystem? EnerySystem { get; set; }

    public virtual EnvironmentalSystem? EnvironmentalSystem { get; set; }

    public virtual Weapon? Weapon { get; set; }
}
