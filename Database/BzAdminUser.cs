using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzAdminUser
{
    public string AdminUser { get; set; } = null!;

    public string? AdminPassword { get; set; }

    public string? Email { get; set; }

    public string? Ip { get; set; }

    public string? LoginId { get; set; }

    public DateTime? LoginTime { get; set; }

    public string? PassChange { get; set; }

    public string? Code { get; set; }

    public short? Enabled { get; set; }

    public string? GroupUser { get; set; }

    public string? AdminCreate { get; set; }

    public string? AdminEdit { get; set; }

    public DateTime? DateCreate { get; set; }

    public DateTime? DateEdit { get; set; }

    public short? AdminDelete { get; set; }

    public short? StartEdit { get; set; }

    public virtual BzAdminUserGroup? GroupUserNavigation { get; set; }
}
