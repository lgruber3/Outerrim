using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model;

[Table("COMPARTMENTS")]
public partial class Compartment
{
    
    [Column("COMPARTMENT_ID", TypeName = "int")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CompartmentId { get; set; }

    [Column("AIRCRAFT_ID", TypeName = "int")]
    public int AircraftId { get; set; }
    
    public virtual Aircraft Aircraft { get; set; } = null!;

    public virtual ICollection<Machinery> Machineries { get; set; } = new List<Machinery>();
}
