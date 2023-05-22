using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzOrder
{
    public long OrderId { get; set; }

    public string? FullName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Company { get; set; }

    public string? Mst { get; set; }

    public string? Giaonhan { get; set; }

    public string? Content { get; set; }

    public short? Enabled { get; set; }

    public DateTime? RegisterDate { get; set; }
}
