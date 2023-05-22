using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzAdsSend
{
    public long SendId { get; set; }

    public string? Email { get; set; }

    public string? Admin { get; set; }

    public DateTime? PostedDate { get; set; }

    public string? Note { get; set; }

    public short? Enabled { get; set; }

    public long? AdsId { get; set; }
}
