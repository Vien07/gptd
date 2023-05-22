using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzAdminFunctionGroup
{
    public string GroupName { get; set; } = null!;

    public long? Order { get; set; }

    public short? Enabled { get; set; }

    public virtual ICollection<BzAdminFunction> BzAdminFunctions { get; } = new List<BzAdminFunction>();
}
