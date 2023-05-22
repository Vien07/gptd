using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzSupport
{
    public long SupportId { get; set; }

    public string? NameFull { get; set; }

    public string? Images { get; set; }

    public string? Phone { get; set; }

    public string? Yahoo { get; set; }

    public short? Enabled { get; set; }

    public string? Skype { get; set; }

    public string? Viber { get; set; }

    public string? Zalo { get; set; }
}
