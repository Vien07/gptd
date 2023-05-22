using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzThongKe
{
    public int OnlineId { get; set; }

    public DateTime Times { get; set; }

    public long TotalVisitor { get; set; }
}
