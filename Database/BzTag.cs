using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzTag
{
    public long TagsId { get; set; }

    public string? NameVn { get; set; }

    public string? NameEn { get; set; }

    public short? Enabled { get; set; }

    public int? View { get; set; }
}
