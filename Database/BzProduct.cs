using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzProduct
{
    public long ProductId { get; set; }

    public string? TitleVn { get; set; }

    public string? TitleEn { get; set; }

    public string? PicThumb { get; set; }

    public string? PicFull { get; set; }

    public string? DesVn { get; set; }

    public string? DesEn { get; set; }

    public long? Price { get; set; }

    public string? ContentVn { get; set; }

    public string? ContentEn { get; set; }

    public long? Order { get; set; }

    public short? Enabled { get; set; }

    public long? CateId { get; set; }

    public string? Tags { get; set; }
}
