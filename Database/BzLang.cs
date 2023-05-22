using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzLang
{
    public string Name { get; set; } = null!;

    public string? ValueVn { get; set; }

    public string? ValueEn { get; set; }

    public short? Enabled { get; set; }

    public string? Note { get; set; }
}
