using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzOrderNew
{
    public long OrderId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Address { get; set; }

    public string? Subject { get; set; }

    public short? Enabled { get; set; }

    public DateTime? PostedDate { get; set; }

    public short? Status { get; set; }

    public short? Payment { get; set; }
}
