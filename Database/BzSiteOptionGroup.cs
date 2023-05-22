using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzSiteOptionGroup
{
    public string GroupOption { get; set; } = null!;

    public long? Order { get; set; }

    public short? Enabled { get; set; }

    public virtual ICollection<BzSiteOption> BzSiteOptions { get; } = new List<BzSiteOption>();
}
