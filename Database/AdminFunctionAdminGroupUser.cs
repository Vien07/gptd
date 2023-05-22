using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class AdminFunctionAdminGroupUser
{
    public string FunctionName { get; set; } = null!;

    public string? GroupUser { get; set; }

    public short? FunctionLevel { get; set; }

    public string? SecurityCode { get; set; }

    public virtual BzAdminFunction FunctionNameNavigation { get; set; } = null!;

    public virtual BzAdminUserGroup? GroupUserNavigation { get; set; }
}
