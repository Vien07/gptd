using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzProductSize
{
    public long SizeId { get; set; }

    public long? CateId { get; set; }

    public string? TitleVn { get; set; }

    public string? TitleEn { get; set; }

    public string? DesVn { get; set; }

    public string? DesEn { get; set; }

    public string? Photo { get; set; }

    public short? Enabled { get; set; }

    public string? Order { get; set; }

    public string? AddDate { get; set; }

    public string? AddUser { get; set; }
}
