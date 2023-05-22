using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzWare
{
    public long Phone { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Ware { get; set; }

    public short? Enabled { get; set; }

    public DateTime? RegisterDate { get; set; }

    public long? Cate { get; set; }

    public long? Id { get; set; }

    public short? Status { get; set; }
}
