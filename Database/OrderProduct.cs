using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class OrderProduct
{
    public long OrderId { get; set; }

    public long ProductId { get; set; }

    public string? NameProduct { get; set; }

    public long? Quantity { get; set; }

    public long? Price { get; set; }

    public DateTime? OrderDate { get; set; }

    public short? Enabled { get; set; }
}
