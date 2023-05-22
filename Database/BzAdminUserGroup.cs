using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzAdminUserGroup
{
    public string GroupUser { get; set; } = null!;

    public short? AdminLevel { get; set; }

    public string? Code { get; set; }

    public short? Enabled { get; set; }

    public virtual ICollection<BzAdminUser> BzAdminUsers { get; } = new List<BzAdminUser>();
}
