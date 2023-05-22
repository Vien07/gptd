using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzAd
{
    public long AdsId { get; set; }

    public string? Logo { get; set; }

    public string? Banner { get; set; }

    public string? Domain { get; set; }

    public string? Company { get; set; }

    public string? Ware { get; set; }

    public string? Time { get; set; }

    public string? Hotline { get; set; }

    public string? Product { get; set; }

    public string? Footer { get; set; }

    public short? Enabled { get; set; }

    public short? Status { get; set; }

    public DateTime? PostedDate { get; set; }
}
