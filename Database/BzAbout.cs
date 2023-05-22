using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzAbout
{
    public string Name { get; set; } = null!;

    public string? DescriptionVn { get; set; }

    public string? DescriptionEn { get; set; }

    public string? ContentVn { get; set; }

    public string? ContentEn { get; set; }

    public short? Enabled { get; set; }
}
