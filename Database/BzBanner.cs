using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzBanner
{
    public long BannerId { get; set; }

    public string? FileName { get; set; }

    public string? Url { get; set; }

    public long? Order { get; set; }

    public short? Enabled { get; set; }

    public short? Type { get; set; }
}
