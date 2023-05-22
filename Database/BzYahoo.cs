using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzYahoo
{
    public long YahooId { get; set; }

    public string? NameFull { get; set; }

    public string? DepartmentVn { get; set; }

    public string? DepartmentEn { get; set; }

    public string? NickName { get; set; }

    public short? Enabled { get; set; }

    public short? Type { get; set; }
}
