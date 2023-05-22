using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzContact
{
    public long ContactId { get; set; }

    public string? NameFull { get; set; }

    public string? Company { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? Subject { get; set; }

    public string? Content { get; set; }

    public DateTime? PostedDate { get; set; }

    public short? Enabled { get; set; }
}
