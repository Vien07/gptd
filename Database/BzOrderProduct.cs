using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzOrderProduct
{
    public long Id { get; set; }

    public long? OrderId { get; set; }

    public long? ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? Price { get; set; }
}
