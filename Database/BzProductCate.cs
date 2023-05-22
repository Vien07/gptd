using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzProductCate
{
    public long CateId { get; set; }

    public string? NameVn { get; set; }

    public string? NameEn { get; set; }

    public long? Order { get; set; }

    public short? Enabled { get; set; }

    public string? DesVn { get; set; }

    public string? DesEn { get; set; }
}
