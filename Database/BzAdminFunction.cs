using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzAdminFunction
{
    public string FunctionName { get; set; } = null!;

    public string? Url { get; set; }

    public long? Order { get; set; }

    public short? Enabled { get; set; }

    public string? GroupName { get; set; }

    public string? TableName { get; set; }

    public virtual BzAdminFunctionGroup? GroupNameNavigation { get; set; }
}
