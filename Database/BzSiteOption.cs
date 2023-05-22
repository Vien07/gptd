using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzSiteOption
{
    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public string? NameVn { get; set; }

    public string? NameEn { get; set; }

    public string? ValueOption { get; set; }

    public string? ValueSelect { get; set; }

    public string? ValueNameVn { get; set; }

    public string? ValueNameEn { get; set; }

    public long? Order { get; set; }

    public short? Enabled { get; set; }

    public string? Note { get; set; }

    public string? GroupOption { get; set; }

    public virtual BzSiteOptionGroup? GroupOptionNavigation { get; set; }
}
