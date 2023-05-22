using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzSlide
{
    public long SlideId { get; set; }

    public string? FileName { get; set; }

    public string? Url { get; set; }

    public long? Order { get; set; }

    public short? Enabled { get; set; }

    public string? DesVn { get; set; }

    public string? DesEn { get; set; }

    public string? TitleVn { get; set; }

    public string? TitleEn { get; set; }
}
