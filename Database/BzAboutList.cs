using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzAboutList
{
    public long AboutId { get; set; }

    public string? TitleVn { get; set; }

    public string? TitleEn { get; set; }

    public string? ContentVn { get; set; }

    public string? ContentEn { get; set; }

    public long? Order { get; set; }

    public short? Enabled { get; set; }

    public string? Upload { get; set; }

    public short? Top { get; set; }
}
