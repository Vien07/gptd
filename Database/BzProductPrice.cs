using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzProductPrice
{
    public long SizeId { get; set; }

    public long ProductId { get; set; }

    public long? Price { get; set; }

    public long? PriceSale { get; set; }

    public string? DesVn { get; set; }

    public string? DesEn { get; set; }
}
