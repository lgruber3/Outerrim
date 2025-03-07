using System;
using System.Collections.Generic;

namespace Model.Model;

public partial class EfmigrationsHistory : Machinery
{
    public string MigrationId { get; set; } = null!;

    public string ProductVersion { get; set; } = null!;
}
