using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzLog
{
    public long Idlogin { get; set; }

    public string? AdminUser { get; set; }

    public short? LoginSuccess { get; set; }

    public string? Ip { get; set; }

    public DateTime? LoginTime { get; set; }
}
