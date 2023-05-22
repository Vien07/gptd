using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class WareProduct
{
    public long WareId { get; set; }

    public long ProductId { get; set; }

    public long Phone { get; set; }

    public string? TitleVn { get; set; }

    public long? Quantity { get; set; }

    public long? Price { get; set; }

    public string? PicThumb { get; set; }

    public string? PicFull { get; set; }
}
