using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzKho
{
    public long Id { get; set; }

    public string? NameVn { get; set; }

    public string? NameEn { get; set; }

    public string? FileName { get; set; }

    public string? Url { get; set; }

    public short? Enabled { get; set; }

    public long? Order { get; set; }
}
