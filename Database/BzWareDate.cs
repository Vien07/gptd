using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzWareDate
{
    public long WareId { get; set; }

    public DateTime? WareDate { get; set; }

    public short? Enabled { get; set; }

    public long? Phone { get; set; }

    public DateTime? PostedDate { get; set; }

    public string? Ware { get; set; }

    public long? Trans { get; set; }

    public short? Sales { get; set; }

    public long? Pay { get; set; }

    public long? Congno { get; set; }

    public short? Status { get; set; }

    public short? Datcoc { get; set; }

    public DateTime? DateCongno { get; set; }

    public DateTime? DateDelivery { get; set; }

    public string? AddressDelivery { get; set; }

    public string? UserLast { get; set; }
}
